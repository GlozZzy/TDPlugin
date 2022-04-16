using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace TDPlugin.ToolWindows
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("69c0b337-59d8-4591-8cbd-a59603459d56")]
    public class ToolWindowStat : ToolWindowPane
    {
        public ToolWindowStatControl toolWin;
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolWindowStat"/> class.
        /// </summary>
        public ToolWindowStat() : base(null)
        {
            this.Caption = "ToolWindowStat123";
            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.toolWin = new ToolWindowStatControl();
            this.Content = toolWin;
        }
    }
}
