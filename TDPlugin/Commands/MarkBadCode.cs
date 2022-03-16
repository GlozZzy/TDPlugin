using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using System.Diagnostics;
using System.Windows.Forms;
using TDPlugin.Forms;
using Microsoft.VisualStudio.TextManager.Interop;
using TDPlugin.Models;
using EnvDTE;

namespace TDPlugin
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class MarkBadCode
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("d5d8efc6-dc17-4229-9088-dddf76ac0ae4");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkBadCode"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private MarkBadCode(Package package)
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
                var menuItem = new MenuCommand(this.Execute, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }


        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static MarkBadCode Instance
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
        public static async Task InitializeAsync(AsyncPackage package)
        {
            Instance = new MarkBadCode(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        /// 

        private TextViewSelection GetSelection(IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService(typeof(SVsTextManager));
            var textManager = service as IVsTextManager2;
            IVsTextView view;
            int result = textManager.GetActiveView2(1, null, (uint)_VIEWFRAMETYPE.vftCodeWindow, out view);

            view.GetSelection(out int startLine, out int startColumn, out int endLine, out int endColumn);//end could be before beginning

            int ok = view.GetNearestPosition(startLine, startColumn, out int position1, out int piVirtualSpaces);
            ok = view.GetNearestPosition(endLine, endColumn, out int position2, out piVirtualSpaces);

            var startPosition = Math.Min(position1, position2);
            var endPosition = Math.Max(position1, position2);

            view.GetSelectedText(out string selectedText);

            TextViewSelection selection = new TextViewSelection(startPosition, endPosition, selectedText);
            return selection;
        }


        private string GetActiveDocumentFilePath(IServiceProvider serviceProvider)
        {
            EnvDTE80.DTE2 applicationObject = serviceProvider.GetService(typeof(DTE)) as EnvDTE80.DTE2;
            return applicationObject.ActiveDocument.FullName;
        }

        private void ShowAddDocumentationWindow(string activeDocumentPath, TextViewSelection selection)
        {
            var documentationControl = new AddDocumentationWindow(activeDocumentPath, selection);
            documentationControl.ShowDialog();
        }

        private void Execute(object sender, EventArgs e)
        {
            TextViewSelection selection = GetSelection((IServiceProvider)ServiceProvider);
            string activeDocumentPath = GetActiveDocumentFilePath((IServiceProvider)ServiceProvider);
            ShowAddDocumentationWindow(activeDocumentPath, selection);
            //System.Threading.Thread myThread = new System.Threading.Thread(new ThreadStart(run));
            //myThread.Start();
        }

        private void run() 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Mark());
        }
    }
}
