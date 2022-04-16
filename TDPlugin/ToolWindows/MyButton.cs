using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TDPlugin.Dialogs;
using TDPlugin.EditorUI.DocumentedCodeHighlighter;
using TDPlugin.Events;
using TDPlugin.Models;

namespace TDPlugin.ToolWindows
{
    public class MyButton : Button
    {
        public DocumentationFragment fragment;
        public IServiceProvider service;
        public string filename;

        public MyButton(DocumentationFragment fragment, string filename, IServiceProvider service)
        {
            this.fragment = fragment;
            this.service = service;
            this.filename = filename;

            Content = fragment.Documentation.Title;
            Click += MyCustomClick;
        }

        private void MyCustomClick(object sender, RoutedEventArgs e)
        {
            EnvDTE80.DTE2 applicationObject = service.GetService(typeof(DTE)) as EnvDTE80.DTE2;
            applicationObject.ItemOperations.OpenFile(filename.Substring(0, filename.LastIndexOf(".cdoc"))).Activate();

            var textManager = service.GetService(typeof(SVsTextManager)) as IVsTextManager2;
            IVsTextView view;
            textManager.GetActiveView2(1, null, (uint)_VIEWFRAMETYPE.vftCodeWindow, out view);
            int line;
            int column;
            view.GetLineAndColumn(fragment.Selection.EndPosition, out line, out column);
            view.SetCaretPos(line, column);


        }
    }
}
