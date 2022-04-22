using TDPlugin.Events;
using TDPlugin.Services;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Linq;
using System.Collections.Generic;
using TDPlugin.Models;
using TDPlugin.Utils;
using EnvDTE;

namespace TDPlugin.EditorUI.DocumentedCodeHighlighter
{
    class DocumentationTagger : ITagger<DocumentationTag>
    {
        private ITextView _textView;
        private ITextBuffer _buffer;
        private IEventAggregator _eventAggregator;
        private readonly DelegateListener<DocumentationAddedEvent> _documentationAddedListener;
        private DelegateListener<DocumentSavedEvent> _documentSavedListener;
        private DelegateListener<DocumentationUpdatedEvent> _documentationUpdatedListener;
        private readonly DelegateListener<DocumentClosedEvent> _documentatiClosedListener;
        private readonly string _filename;
        private readonly DelegateListener<DocumentationDeletedEvent> _documentationDeletedListener;

        private string TDPluginFilename { get {  return _filename + Consts.CODY_DOCS_EXTENSION; } }
        Dictionary<ITrackingSpan, SelectionDocumentation> _trackingSpans;

        // ITextView представляет собой визуальный элемент текстового представления в документе.
        // ITextBuffer — это данные текстового представления.
        // Свойство CurrentSnapshot представляет текущий текст в буфере.
        // Каждый раз, при изменении текста, создается новый экземпляр Snapshot.
        public DocumentationTagger(ITextView textView, ITextBuffer buffer, IEventAggregator eventAggregator)
        {
            _textView = textView;
            _buffer = buffer;
            _eventAggregator = eventAggregator;
            _filename = buffer.GetFileName();
            
            _documentationAddedListener = new DelegateListener<DocumentationAddedEvent>(OnDocumentationAdded);
            _eventAggregator.AddListener<DocumentationAddedEvent>(_documentationAddedListener);
            _documentSavedListener = new DelegateListener<DocumentSavedEvent>(OnDocumentSaved);
            _eventAggregator.AddListener<DocumentSavedEvent>(_documentSavedListener);
            _documentatiClosedListener = new DelegateListener<DocumentClosedEvent>(OnDocumentatClosed);
            _eventAggregator.AddListener<DocumentClosedEvent>(_documentatiClosedListener);
            _documentationUpdatedListener = new DelegateListener<DocumentationUpdatedEvent>(OnDocumentationUpdated);
            _eventAggregator.AddListener<DocumentationUpdatedEvent>(_documentationUpdatedListener);
            _documentationDeletedListener = new DelegateListener<DocumentationDeletedEvent>(OnDocumentationDeleted);
            _eventAggregator.AddListener<DocumentationDeletedEvent>(_documentationDeletedListener);

            CreateTrackingSpans();
        }

        
        private void OnDocumentatClosed(DocumentClosedEvent obj)
        {
            if (obj.DocumentFullName == _filename)
            {
                _eventAggregator.RemoveListener(_documentationAddedListener);
                _eventAggregator.RemoveListener(_documentSavedListener);
                _eventAggregator.RemoveListener(_documentationUpdatedListener);
                _eventAggregator.RemoveListener(_documentatiClosedListener);
            }

        }

        private void CreateTrackingSpans()
        {
            _trackingSpans = new Dictionary<ITrackingSpan, SelectionDocumentation>();
            var documentation = Services.DocumentationFileSerializer.Deserialize(TDPluginFilename);
            var currentSnapshot = _buffer.CurrentSnapshot;
            foreach (var fragment in documentation.Fragments)
            {
                Span span = fragment.GetSpan();
                // CreateTrackingSpan необходим для того, чтобы следить за спаном (диапазоном) кода
                var trackingSpan = currentSnapshot.CreateTrackingSpan(span, SpanTrackingMode.EdgeExclusive);
                _trackingSpans.Add(trackingSpan, fragment.Documentation);
            }
        }

        // OnDocumentSaved — обработчик события, который вызывается, когда пользователь сохраняет документ
        private void OnDocumentSaved(DocumentSavedEvent documentSavedEvent)
        {
            if (documentSavedEvent.DocumentFullName == _filename)
            {
                RemoveEmptyTrackingSpans();
                FileDocumentation fileDocumentation = CreateFileDocumentationFromTrackingSpans();
                DocumentationFileSerializer.Serialize(TDPluginFilename, fileDocumentation);
            }
        }
        
        private void OnDocumentationUpdated(DocumentationUpdatedEvent ev)
        {
            if (_trackingSpans.ContainsKey(ev.TrackingSpan))
            {
                _trackingSpans[ev.TrackingSpan] = ev.NewDocumentation;
                TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(
                    new SnapshotSpan(_buffer.CurrentSnapshot, ev.TrackingSpan.GetSpan(_buffer.CurrentSnapshot))));
                MarkDocumentAsUnsaved();
            }
        }

        private void OnDocumentationDeleted(DocumentationDeletedEvent ev)
        {
            if (_trackingSpans.ContainsKey(ev.Tag.TrackingSpan))
            {
                _trackingSpans.Remove(ev.Tag.TrackingSpan);
                TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(
                    new SnapshotSpan(_buffer.CurrentSnapshot, ev.Tag.TrackingSpan.GetSpan(_buffer.CurrentSnapshot))));
                MarkDocumentAsUnsaved();
            }
        }


        private void MarkDocumentAsUnsaved()
        {
            Document document = DocumentLifetimeManager.GetDocument(_filename);
            if (document != null)
                document.Saved = false;
        }

        private void RemoveEmptyTrackingSpans()
        {
            var currentSnapshot = _buffer.CurrentSnapshot;
            var keysToRemove = _trackingSpans.Keys.Where(ts => ts.GetSpan(currentSnapshot).Length == 0).ToList();
            foreach (var key in keysToRemove)
            {
                _trackingSpans.Remove(key);
            }
        }

        // CreateFileDocumentationFromTrackingSpans — основной метод.
        // Просматривает все диапазоны отслеживания (Tracking Spans) и используем GetStartPoint, GetEndPoint и GetText,
        // чтобы узнать диапазон для текущего снимка и текущий текст диапазона.
        private FileDocumentation CreateFileDocumentationFromTrackingSpans()
        {
            var currentSnapshot = _buffer.CurrentSnapshot;
            List<DocumentationFragment> fragments = _trackingSpans
                .Select(ts => new DocumentationFragment()
                {
                    Selection = new TextViewSelection()
                    {
                        StartPosition = ts.Key.GetStartPoint(currentSnapshot),
                        EndPosition = ts.Key.GetEndPoint(currentSnapshot),
                        Text = ts.Key.GetText(currentSnapshot)
                    },
                    Documentation = ts.Value

                }).ToList();
            
            var fileDocumentation = new FileDocumentation() { Fragments = fragments };
            return fileDocumentation;
        }

        // OnDocumentationAdded — когда документация добавляется, нам нужно обновить теги.
        // Для этого мы вызываем событие TagsChanged (которое является частью интерфейса ITagger).
        // Параметр представляет собой SnapshotSpan, который представляет текстовый диапазон (диапазон текста) в снимке.
        private void OnDocumentationAdded(DocumentationAddedEvent e)
        {

            string filepath = e.Filepath;
            if (filepath == TDPluginFilename)
            {
                var span = e.DocumentationFragment.GetSpan();
                var trackingSpan = _buffer.CurrentSnapshot.CreateTrackingSpan(span, SpanTrackingMode.EdgeExclusive);
                _trackingSpans.Add(trackingSpan, e.DocumentationFragment.Documentation);
                TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(
                    new SnapshotSpan(_buffer.CurrentSnapshot, span)));
                MarkDocumentAsUnsaved();
            }
        }

        // TagsChanged — этот вызов уведомляет Visual Studio о том,
        // что теги должны быть обновлены в заданном диапазоне.
        // GetTags будет вызываться для получения обновленных тегов.
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        // GetTags — основной метод ITagger. Указывает, какие части кода необходимо выделить.
        // Вызывается GetTags при первом открытии документа и каждый раз, когда требуется обновление
        // (например, если пользователь редактирует код или при прокрутке).
        // Мы используем наши диапазоны отслеживания, чтобы узнать текущие диапазоны с помощью метода GetSpan
        public IEnumerable<ITagSpan<DocumentationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            List<ITagSpan<DocumentationTag>> tags = new List<ITagSpan<DocumentationTag>>();
            if (spans.Count == 0)
                return tags;

            var relevantSnapshot = spans.First().Snapshot;
            foreach (var trackingSpan in _trackingSpans.Keys)
            {
                var spanInCurrentSnapshot = trackingSpan.GetSpan(relevantSnapshot);
                if (spans.Any(sp => spanInCurrentSnapshot.IntersectsWith(sp)))
                {
                    var snapshotSpan = new SnapshotSpan(relevantSnapshot, spanInCurrentSnapshot);
                    var documentationDescription = _trackingSpans[trackingSpan];
                    tags.Add(new TagSpan<DocumentationTag>(snapshotSpan, 
                        new DocumentationTag(documentationDescription, trackingSpan, _buffer)));
                }
                
            }
            return tags;
        }
    }
}
