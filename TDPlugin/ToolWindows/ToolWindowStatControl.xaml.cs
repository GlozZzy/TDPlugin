using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using TDPlugin.Models;

namespace TDPlugin.ToolWindows
{
    /// <summary>
    /// Interaction logic for ToolWindowMarkControl.
    /// </summary>
    public partial class ToolWindowStatControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowMarkControl"/> class.
        /// </summary>
        public ToolWindowStatControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ald1.Text = "123";
        }
    }
}