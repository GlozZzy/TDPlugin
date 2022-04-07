using TDPlugin.Models;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace TDPlugin.EditorUI.DocumentedCodeHighlighter
{
    public class HighlightTag : TextMarkerTag
    {
        public HighlightTag() : base("MarkerFormatDefinition/DocumentedCodeFormatDefinition")
        {

        }
    }
}
