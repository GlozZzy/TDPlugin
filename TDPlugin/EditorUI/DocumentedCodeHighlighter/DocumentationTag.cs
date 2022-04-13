using TDPlugin.Models;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace TDPlugin.EditorUI.DocumentedCodeHighlighter
{
    public class DocumentationTag : IGlyphTag
    {
        public SelectionDocumentation DocumentationFragment { get; private set; }
        public ITrackingSpan TrackingSpan { get; set; }
        public ITextBuffer TextBuffer { get; set; }

        public DocumentationTag(SelectionDocumentation fragment, ITrackingSpan trackingSpan, ITextBuffer buffer)
        {
            DocumentationFragment = fragment;
            TrackingSpan = trackingSpan;
            TextBuffer = buffer;
        }

    }
}
