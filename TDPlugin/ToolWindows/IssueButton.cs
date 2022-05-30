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
using System.Windows.Media;
using TDPlugin.Dialogs;
using TDPlugin.EditorUI.DocumentedCodeHighlighter;
using TDPlugin.Events;
using TDPlugin.Models;

namespace TDPlugin.ToolWindows
{
    public class IssueButton : Button
    {
        public DocumentationFragment fragment;
        public IServiceProvider service;
        public string filename;

        public IssueButton(DocumentationFragment fragment, string filename, IServiceProvider service)
        {
            this.fragment = fragment;
            this.service = service;
            this.filename = filename;

            Content = fillgrid();
            Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
            this.BorderThickness = new Thickness(0);
            Click += IssueButtonClick;
        }

        private void IssueButtonClick(object sender, RoutedEventArgs e)
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

        public Grid fillgrid()
        {
            Grid gr = new Grid();
            gr.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(62) });
            gr.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(72) });
            gr.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(72) });
            gr.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40) });
            gr.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(120) });
            gr.ColumnDefinitions.Add(new ColumnDefinition() { MinWidth = 200, Width = new GridLength(1,GridUnitType.Star) });

            //date
            var shortyear = "" + fragment.Documentation.CreationDateTime.Year;
            shortyear = shortyear.Remove(0, 2);
            TextBlock datetxt = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Height = 25,
                Text = "" + fragment.Documentation.CreationDateTime.Day +
                "." + fragment.Documentation.CreationDateTime.Month +
                "." + shortyear,
            };
            Grid.SetColumn(datetxt, 0);
            //priority
            TextBlock prioritytxt = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Height = 25,
                Text = Gettxt(fragment.Documentation.Priority),
            };
            Grid.SetColumn(prioritytxt, 1);
            //effort
            TextBlock efforttxt = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Height = 25,
                Text = Gettxt(fragment.Documentation.Effort),
            };
            Grid.SetColumn(efforttxt, 2);
            
            //upvotes
            TextBlock upvotestxt = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14,
                Height = 25,
                Text = "" + (fragment.Documentation.ClientsUpvotes.Count - 1),
            };
            Grid.SetColumn(upvotestxt, 3);
            //filename
            string filename_ = filename.Substring(filename.LastIndexOf("\\") + 1, filename.Length - filename.LastIndexOf("\\") - 6);
            if (filename_.Length > 10) filename_ = filename_.Substring(0, 14)+"..";
            
            var i = filename.Substring(0, filename.LastIndexOf("\\"));
            string tooltiptext = filename.Substring(i.LastIndexOf("\\")+1, filename.LastIndexOf(".cdoc")- i.LastIndexOf("\\") - 1);
            TextBlock filetxt = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 14,
                Height = 25,
                Padding = new Thickness(5, 0, 0, 0),
                Text = filename_,
                ToolTip = tooltiptext,
            };
            Grid.SetColumn(filetxt, 4);
            //title
            TextBlock titletxt = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 14,
                Height = 25,
                Padding = new Thickness(5,0,0,0),
                Text = fragment.Documentation.Title,
            };
            Grid.SetColumn(titletxt, 5);

            gr.Children.Add(datetxt);
            gr.Children.Add(efforttxt);
            gr.Children.Add(prioritytxt);
            gr.Children.Add(upvotestxt);
            gr.Children.Add(filetxt);
            gr.Children.Add(titletxt);

            return gr;
        }

        private string Gettxt(int val)
        {
            switch (val)
            {
                case 0:
                    return "◉○○○○";
                case 1:
                    return "◉◉○○○";
                case 2:
                    return "◉◉◉○○";
                case 3:
                    return "◉◉◉◉○";
                case 4:
                    return "◉◉◉◉◉";
            }
            return "";
        }
    }
}
