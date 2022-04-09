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
    public partial class ChangeUsernameWindow
    {
        public ChangeUsernameWindow()
        {
            InitializeComponent();
            TextBox.Text = ClientSettings.Default.username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientSettings.Default.username = TextBox.Text;
            ClientSettings.Default.Save();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
