using System;
using System.ComponentModel.Design;
using System.Globalization;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using TDPlugin.ToolWindows;

namespace TDPlugin
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ShowProjectStatistics
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("69c0b337-59d8-4591-8cbd-a59603459d56");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnableDisableTDPluginCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private ShowProjectStatistics(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var command = new MenuCommand(this.ShowToolWindow, menuCommandID);
                commandService.AddCommand(command);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ShowProjectStatistics Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new ShowProjectStatistics(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void ShowToolWindow(object sender, EventArgs e)
        {
            var window = (ToolWindowStat)this.package.FindToolWindow(typeof(ToolWindowStat), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("Cannot create tool window");
            }

            //EnvDTE80.DTE2 applicationObject = ServiceProvider.GetService(typeof(DTE)) as EnvDTE80.DTE2;
            //var solutionName = applicationObject.Solution.FullName;
            //var directoryPath = solutionName.Substring(0, solutionName.LastIndexOf("\\"));
            //var directoryName = solutionName.Substring(solutionName.LastIndexOf("\\"));
            //directoryName = directoryName.Substring(0, directoryName.LastIndexOf("."));
            //directoryPath += directoryName;

            window.toolWin.serviceProvider = ServiceProvider;


            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }
    }
}
