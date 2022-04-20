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
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowMarkControl"/> class.
        /// </summary>
        public ToolWindowStatControl()
        {
            this.InitializeComponent();
            filterVal = 0;
            this.UpdateFunc();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            this.Update(sender, e);
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            issues_textblock.Text = "filter";
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            UpdateFunc();
        }

        private void UpdateFunc()
        {
            if (serviceProvider == null) { issues_textblock.Text = "Open the project to tracking issues"; return; };
            EnvDTE80.DTE2 applicationObject = serviceProvider.GetService(typeof(DTE)) as EnvDTE80.DTE2;
            var solutionName = applicationObject.Solution.FullName;
            if (solutionName == "") { issues_textblock.Text = "Open the project to tracking issues"; return; };
            var directoryPath = solutionName.Substring(0, solutionName.LastIndexOf("\\"));
            var directoryName = solutionName.Substring(solutionName.LastIndexOf("\\"));
            directoryName = directoryName.Substring(0, directoryName.LastIndexOf("."));
            directoryPath += directoryName;

            if (directoryPath != null)
            {
                issues_textblock.Text = "To add an issue, highlight and right-click on the bad code";
                issues_info_grid.Children.Clear();
                List<MyButton> bttns = new List<MyButton>();

                string[] files = Directory.GetFiles(directoryPath, "*.cdoc");
                foreach (string file in files)
                {
                    var documentation = Services.DocumentationFileSerializer.Deserialize(file);
                    foreach (DocumentationFragment fragment in documentation.Fragments)
                    {
                        MyButton butt = new MyButton(fragment, file, serviceProvider);
                        bttns.Add(butt);
                    }
                }

                switch (filterVal)
                {
                    case 0:
                        bttns.Sort(delegate (MyButton x, MyButton y) {
                            return y.fragment.Documentation.CreationDateTime.CompareTo(x.fragment.Documentation.CreationDateTime);
                        });
                        break;
                    case 1:
                        bttns.Sort(delegate (MyButton x, MyButton y) {
                            return y.fragment.Documentation.Priority.CompareTo(x.fragment.Documentation.Priority);
                        });
                        break;
                    case 2:
                        bttns.Sort(delegate (MyButton x, MyButton y) {
                            return y.fragment.Documentation.Effort.CompareTo(x.fragment.Documentation.Effort);
                        });
                        break;
                    case 3:
                        bttns.Sort(delegate (MyButton x, MyButton y) {
                            return y.fragment.Documentation.ClietsUpvotes.Count.CompareTo(x.fragment.Documentation.ClietsUpvotes.Count);
                        });
                        break;
                }

                int row = 0;
                foreach (MyButton bttn in bttns)
                {
                    TextBlock txt = new TextBlock();
                    txt.VerticalAlignment = VerticalAlignment.Center;
                    txt.FontSize = 14;
                    txt.Height = 25;
                    txt.Padding = new Thickness(0, 2.25, 0, 0);
                    txt.Text = get_filterval(bttn);

                    issues_info_grid.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(txt, row);
                    issues_info_grid.Children.Add(txt);

                    issues_grid.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(bttn, row);
                    issues_grid.Children.Add(bttn);
                    row++;
                }
            }
        }

        private string get_filterval(MyButton bttn)
        {
            switch (filterVal)
            {
                case 0:
                    var shortyear = "" + bttn.fragment.Documentation.CreationDateTime.Year;
                    shortyear = shortyear.Remove(0, 2);
                    return "" + bttn.fragment.Documentation.CreationDateTime.Day +
                        "." + bttn.fragment.Documentation.CreationDateTime.Month +
                        "." + shortyear;
                case 1:
                    return "val: " + bttn.fragment.Documentation.Priority;
                case 2:
                    return "val: " + bttn.fragment.Documentation.Effort;
                case 3:
                    return "val: " + bttn.fragment.Documentation.ClietsUpvotes.Count;
            }
            return "";
        }

        private void issues_filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterVal = issues_filter.SelectedIndex;
        }
    }
}