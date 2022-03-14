using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;

namespace TDPlugin.Models
{
    public class DocumentationFragment
    {
        public TextViewSelection Selection { get; set; }
        public string Documentation { get; set; }
    }

    public class FileDocumentation
    {
        public List<DocumentationFragment> Fragments { get; set; } = new List<DocumentationFragment>();
    }
}