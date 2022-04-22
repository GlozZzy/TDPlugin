using TDPlugin.Models;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;

namespace TDPlugin.EditorUI.DocumentedCodeHighlighter
{
    // Тип тега, который будет создаваться.
    // Он происходит от TextMarkerTag - это особый тип тега,
    // который позволяет выделять код.
    // Передаваемое имя «MarkerFormatDefinition/DocumentedCodeFormatDefinition»,
    // используется для установки формата кода для этого тега.
    public class HighlightTag : TextMarkerTag
    {
        public HighlightTag() : base("MarkerFormatDefinition/DocumentedCodeFormatDefinition")
        {

        }
    }
}
