using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using TDPlugin.Dialogs;
using TDPlugin.Models;
using TDPlugin.Utils;

namespace TDPlugin.ToolWindows
{
    /// <summary>
    /// Interaction logic for ToolWindowMarkControl.
    /// </summary>
    public partial class ToolWindowStatControl : UserControl
    {
        //public string directoryPath;
        public IServiceProvider serviceProvider;
        private int filterVal;
        private bool reverse;

        private const int date = 0;
        private const int priority = 1;
        private const int effort = 2;
        private const int upvotes = 3;
        private const int filename = 4;
        private const int title = 5;
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowMarkControl"/> class.
        /// </summary>
        public ToolWindowStatControl()
        {
            this.InitializeComponent();
            filterVal = date;
            reverse = false;
            this.UpdateFunc();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]

        private void UpdateBttn_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.RemoveRange(6, mainGrid.Children.Count - 1);
            if (mainGrid.RowDefinitions.Count > 1) mainGrid.RowDefinitions.RemoveRange(1, mainGrid.RowDefinitions.Count - 1);
            UpdateFunc();
        }

        public void UpdateFunc()
        {
            if (serviceProvider == null) { issues_textblock.Text = "Open the project to tracking issues and reopen this toolwindow"; return; };
            EnvDTE80.DTE2 applicationObject = serviceProvider.GetService(typeof(DTE)) as EnvDTE80.DTE2;
            var solutionName = applicationObject.Solution.FullName;
            if (solutionName == "") { issues_textblock.Text = "Open the project to tracking issues and reopen this toolwindow"; return; };
            var directoryPath = solutionName.Substring(0, solutionName.LastIndexOf("\\"));
            var directoryName = solutionName.Substring(solutionName.LastIndexOf("\\"));
            directoryName = directoryName.Substring(0, directoryName.LastIndexOf("."));
            directoryPath += directoryName;

            if (directoryPath != null)
            {
                issues_textblock.Text = "To add an issue, highlight and right-click on the bad code";
                List<IssueButton> bttns = recursiveGetallbttns(directoryPath);

                switch (filterVal)
                {
                    case date:
                        if (!reverse) bttns.Sort(delegate (IssueButton x, IssueButton y) {
                            return y.fragment.Documentation.CreationDateTime.CompareTo(x.fragment.Documentation.CreationDateTime);
                        });
                        else bttns.Sort(delegate (IssueButton y, IssueButton x) {
                            return y.fragment.Documentation.CreationDateTime.CompareTo(x.fragment.Documentation.CreationDateTime);
                        });
                        break;
                    case priority:
                        if (!reverse) bttns.Sort(delegate (IssueButton x, IssueButton y) {
                            return y.fragment.Documentation.Priority.CompareTo(x.fragment.Documentation.Priority);
                        });
                        else bttns.Sort(delegate (IssueButton y, IssueButton x) {
                            return y.fragment.Documentation.Priority.CompareTo(x.fragment.Documentation.Priority);
                        });
                        break;
                    case effort:
                        if (!reverse) bttns.Sort(delegate (IssueButton x, IssueButton y) {
                            return y.fragment.Documentation.Effort.CompareTo(x.fragment.Documentation.Effort);
                        });
                        else bttns.Sort(delegate (IssueButton y, IssueButton x) {
                            return y.fragment.Documentation.Effort.CompareTo(x.fragment.Documentation.Effort);
                        });
                        break;
                    case upvotes:
                        if (!reverse) bttns.Sort(delegate (IssueButton x, IssueButton y) {
                            return y.fragment.Documentation.ClientsUpvotes.Count.CompareTo(x.fragment.Documentation.ClientsUpvotes.Count);
                        });
                        else bttns.Sort(delegate (IssueButton y, IssueButton x) {
                            return y.fragment.Documentation.ClientsUpvotes.Count.CompareTo(x.fragment.Documentation.ClientsUpvotes.Count);
                        });
                        break;
                    case filename:
                        if (!reverse) bttns.Sort(delegate (IssueButton y, IssueButton x) {
                            return y.filename.CompareTo(x.filename);
                        });
                        else bttns.Sort(delegate (IssueButton x, IssueButton y) {
                            return y.filename.CompareTo(x.filename);
                        });
                        break;
                    case title:
                        if (!reverse) bttns.Sort(delegate (IssueButton y, IssueButton x) {
                            return y.fragment.Documentation.Title.CompareTo(x.fragment.Documentation.Title);
                        });
                        else bttns.Sort(delegate (IssueButton x, IssueButton y) {
                            return y.fragment.Documentation.Title.CompareTo(x.fragment.Documentation.Title);
                        });
                        break;
                }

                int row = 1;
                foreach (IssueButton bttn in bttns)
                {
                    mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25)});

                    Grid.SetRow(bttn, row);
                    Grid.SetColumn(bttn, 0);
                    Grid.SetColumnSpan(bttn, 6);
                    mainGrid.Children.Add(bttn);
                    row++;
                }
               
            }
        }


        private List<IssueButton> recursiveGetallbttns(string directoryPath)
        {
            List<IssueButton> resbttn = new List<IssueButton>();

            string[] direct = Directory.GetDirectories(directoryPath);
            if (direct.Length > 0)
            {
                foreach (string dir in direct)
                {
                    var bb = recursiveGetallbttns(dir);
                    foreach (IssueButton b in bb)
                        resbttn.Add(b);
                }
            }

            string[] files = Directory.GetFiles(directoryPath, "*.cdoc");
            foreach (string file in files)
            {
                var documentation = Services.DocumentationFileSerializer.Deserialize(file);
                foreach (DocumentationFragment fragment in documentation.Fragments)
                {
                    IssueButton butt = new IssueButton(fragment, file, serviceProvider);
                    resbttn.Add(butt);
                }
            }
            return resbttn;
        }


        private void Datebutt_Click(object sender, RoutedEventArgs e)
        {
            if (filterVal == date)
            {
                if (reverse == true)
                {
                    reverse = false;
                    datebutt.Content = "Date ᐯ";
                }
                else
                {
                    datebutt.Content = "Date ᐱ";
                    reverse = true;
                }
            }
            else
            {
                clearbuttonstext();
                datebutt.Content = "Date ᐯ";
                filterVal = date;
            }
            UpdateBttn_Click(sender, e);
        }

        private void Priorbutt_Click(object sender, RoutedEventArgs e)
        {
            if (filterVal == priority)
            {
                if (reverse == true)
                {
                    reverse = false;
                    priorbutt.Content = "Priority ᐯ";
                }
                else
                {
                    priorbutt.Content = "Priority ᐱ";
                    reverse = true;
                }
            }
            else
            {
                clearbuttonstext();
                priorbutt.Content = "Priority ᐯ";
                filterVal = priority;
            }
            UpdateBttn_Click(sender, e);
        }

        private void Effortbutt_Click(object sender, RoutedEventArgs e)
        {
            if (filterVal == effort)
            {
                if (reverse == true)
                {
                    reverse = false;
                    effortbutt.Content = "Effort ᐯ";
                }
                else
                {
                    effortbutt.Content = "Effort ᐱ";
                    reverse = true;
                }
            }
            else
            {
                clearbuttonstext();
                effortbutt.Content = "Effort ᐯ";
                filterVal = effort;
            }
            UpdateBttn_Click(sender, e);
        }

        private void Upbutt_Click(object sender, RoutedEventArgs e)
        {
            if (filterVal == upvotes)
            {
                if (reverse == true)
                {
                    reverse = false;
                    upbutt.Content = "👍ᐯ";
                }
                else
                {
                    upbutt.Content = "👍ᐱ";
                    reverse = true;
                }
            }
            else
            {
                clearbuttonstext();
                upbutt.Content = "👍ᐯ";
                filterVal = upvotes;
            }
            UpdateBttn_Click(sender, e);
        }

        private void Filebutt_Click(object sender, RoutedEventArgs e)
        {
            if (filterVal == filename)
            {
                if (reverse == true)
                {
                    reverse = false;
                    filebutt.Content = "Filename ᐯ";
                }
                else
                {
                    filebutt.Content = "Filename ᐱ";
                    reverse = true;
                }
            }
            else
            {
                clearbuttonstext();
                filebutt.Content = "Filename ᐯ";
                filterVal = filename;
            }
            UpdateBttn_Click(sender, e);
        }

        private void Titlebutt_Click(object sender, RoutedEventArgs e)
        {
            if (filterVal == title)
            {
                if (reverse == true)
                {
                    reverse = false;
                    titlebutt.Content = "Title ᐯ";
                }
                else
                {
                    titlebutt.Content = "Title ᐱ";
                    reverse = true;
                }
            }
            else
            {
                clearbuttonstext();
                titlebutt.Content = "Title ᐯ";
                filterVal = title;
            }
            UpdateBttn_Click(sender, e);
        }

        private void clearbuttonstext()
        {
            datebutt.Content = "Date";
            priorbutt.Content = "Priority";
            effortbutt.Content = "Effort";
            upbutt.Content = "👍";
            filebutt.Content = "Filename";
            titlebutt.Content = "Title";
            reverse = false;
        }
    }
}