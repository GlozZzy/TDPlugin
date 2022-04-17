using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowMarkControl"/> class.
        /// </summary>
        public ToolWindowStatControl()
        {
            this.InitializeComponent();
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

            issues_textblock.Text = "";
            if (directoryPath != null)
            {
                string[] files = Directory.GetFiles(directoryPath, "*.cdoc");
                var row = 0;
                foreach (string file in files)
                {
                    var documentation = Services.DocumentationFileSerializer.Deserialize(file);
                    foreach (DocumentationFragment fragment in documentation.Fragments)
                    {
                        Button butt = new MyButton(fragment, file, serviceProvider);
                        issues_grid.RowDefinitions.Add(new RowDefinition());
                        Grid.SetRow(butt, row);
                        issues_grid.Children.Add(butt);
                        row++;
                    }
                }
            }
        }
        
    }
}