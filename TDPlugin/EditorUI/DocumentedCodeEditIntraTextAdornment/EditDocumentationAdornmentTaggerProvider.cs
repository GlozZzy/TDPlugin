using System;
using System.ComponentModel.Composition;
using System.Windows;
using TDPlugin.EditorUI.DocumentedCodeHighlighter;
using TDPlugin.Events;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;


namespace TDPlugin.EditorUI.DocumentedCodeEditIntraTextAdornment
{
    // Этот класс служит фабрикой классов ITagger.
    // Метод CreateTagger вызывается каждый раз, когда открывается новый документ
    // IntraTextAdornmentTag — это специальный тег, созданный для украшений,
    // которые вставляются между текстовыми символами.
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(IntraTextAdornmentTag))]
    internal sealed class EditDocumentationAdornmentTaggerProvider : IViewTaggerProvider
    {

#pragma warning disable 649 // "field never assigned to" -- field is set by MEF.
        // Импортируем  ViewTagAggregatorFactoryService, который  является фабрикой для создания TagAggregator,
        // Который нужен для поиска тегов выделения.
        [Import]
        internal IViewTagAggregatorFactoryService ViewTagAggregatorFactoryService;
#pragma warning restore 649

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            if (textView == null)
                throw new ArgumentNullException("textView");

            if (buffer == null)
                throw new ArgumentNullException("buffer");

            if (buffer != textView.TextBuffer)
                return null;

            ITagAggregator< DocumentationTag> tagAggregator = 
                ViewTagAggregatorFactoryService.CreateTagAggregator<DocumentationTag>(textView);

            return textView.Properties.GetOrCreateSingletonProperty(() => 
                new EditDocumentationAdornmentTagger((IWpfTextView)textView, tagAggregator) as ITagger<T>);
        }
    }
}
