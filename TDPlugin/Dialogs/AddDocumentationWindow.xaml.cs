using TDPlugin.Dialogs;
using TDPlugin.Events;
using TDPlugin.Models;
using TDPlugin.Services;
using TDPlugin.Utils;
using System;
using System.Windows;
using static TDPlugin.Dialogs.EditDocumentationViewModel;

namespace TDPlugin
{
    /// <summary>
    /// Interaction logic for AddDocumentationControl.xaml
    /// </summary>
    public partial class AddDocumentationWindow
    {
        public AddDocumentationResult Result => (DataContext as EditDocumentationViewModel).Result;

        public AddDocumentationWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DocumentationTextBox.Focus();
            RegisterToViewModelEvents();
        }

        private void RegisterToViewModelEvents()
        {
            var vm = (DataContext as EditDocumentationViewModel);
            vm.CloseRequest += () =>
            {
                this.Close();
            };
        }
        
        

    }
}
