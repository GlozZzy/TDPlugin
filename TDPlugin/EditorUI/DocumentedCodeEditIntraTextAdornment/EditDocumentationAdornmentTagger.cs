using System;
using System.Collections.Generic;
using TDPlugin.EditorUI.AdornmentSupport;
using TDPlugin.EditorUI.DocumentedCodeHighlighter;
using TDPlugin.Events;
using TDPlugin.Utils;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace TDPlugin.EditorUI.DocumentedCodeEditIntraTextAdornment
{
    // Наследование от базового класса Microsoft IntraTextAdornmentTagger необходимо
    // для решения проблем с производительностью.
    internal sealed class EditDocumentationAdornmentTagger : IntraTextAdornmentTagger<DocumentationTag, YellowNotepadAdornment>
    {
        // Агрегатор тегов необходим для поиска тегов выделения текста
        private ITagAggregator<DocumentationTag> _tagAggregator;
        private ITextBuffer _buffer;
        private string _TDPluginFilename;

        public EditDocumentationAdornmentTagger(IWpfTextView view, ITagAggregator<DocumentationTag> tagAggregator)
            : base(view)
        {
            this._tagAggregator = tagAggregator;
            _tagAggregator.TagsChanged += OnTagsChanged;
            _buffer = view.TextBuffer;
            _TDPluginFilename = view.TextBuffer.GetTDPluginFileName();

        }

        private void OnTagsChanged(object sender, TagsChangedEventArgs e)
        {
            var snapshotSpan = e.Span.GetSnapshotSpan();//Extension method
            InvokeTagsChanged(sender, new SnapshotSpanEventArgs(snapshotSpan));

        }
        
        public void Dispose()
        {
            _tagAggregator.Dispose();

            view.Properties.RemoveProperty(typeof(EditDocumentationAdornmentTagger));
        }

        // Агрегатор тегов нужен для сбора тегов выделения (DocumentedCodeHighlighterTag).
        // Для каждого тега выделения мы создаем собственный тег, начиная с конца диапазона тегов выделения
        // и с длиной 0. Длина 0 важна для того, чтобы украшение не занимало места и не скрывало код.
        protected override IEnumerable<Tuple<SnapshotSpan, PositionAffinity?, DocumentationTag>> GetAdornmentData(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
                yield break;

            ITextSnapshot snapshot = spans[0].Snapshot;

            var commentTags = _tagAggregator.GetTags(spans);

            foreach (IMappingTagSpan<DocumentationTag> commentTag in commentTags)
            {
                NormalizedSnapshotSpanCollection colorTagSpans = commentTag.Span.GetSpans(snapshot);

                // Ignore data tags that are split by projection.
                if (colorTagSpans.Count != 1)
                    continue;
                if (commentTag.Span.GetSpan().Length == 0)
                    continue;

                SnapshotSpan adornmentSpan = new SnapshotSpan(colorTagSpans[0].End, 0);

                yield return Tuple.Create(adornmentSpan, (PositionAffinity?)PositionAffinity.Successor, commentTag.Tag);
            }
        }

        protected override YellowNotepadAdornment CreateAdornment(DocumentationTag additionalData, SnapshotSpan span)
        {
            return new YellowNotepadAdornment()
            {
                DocumentationTag = additionalData,
                Buffer = _buffer
            };
        }

        protected override bool UpdateAdornment(YellowNotepadAdornment adornment, DocumentationTag additionalData)
        {
            //adornment.Update(additionalData);
            return false;
        }
    }

}
