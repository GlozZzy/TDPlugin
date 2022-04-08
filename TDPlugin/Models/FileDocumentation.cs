﻿//using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.Models
{
    public class DocumentationFragment
    {
        public TextViewSelection Selection { get; set; }
        
        public SelectionDocumentation Documentation { get; set; }
        
    }

    public class FileDocumentation
    {
        public List<DocumentationFragment> Fragments { get; set; } = new List<DocumentationFragment>();
    }

    public class SelectionDocumentation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Effort { get; set; }
        //public GitHubClient[] ClietsUpvotes { get; set; }
    }
}
