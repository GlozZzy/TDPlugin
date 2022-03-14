﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDPlugin.Models;
using TDPlugin.Services;

namespace TDPlugin
{
    /// <summary>
    /// Логика взаимодействия для AddDocumentationWindow.xaml
    /// </summary>
    public partial class AddDocumentationWindow
    {
        public AddDocumentationWindow(string documentPath, TextViewSelection selection)
        {
            InitializeComponent();
            this._documentPath = documentPath;
            this._selectionText = selection;
            this.Loaded += (s, e) => this.SelectionTextBox.Text = selection.Text;
            InitializeComponent();
            SelectionTextBox.Text = selection.Text;
        }

        private string _documentPath;
        private TextViewSelection _selectionText;

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            if (this.DocumentationTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Documentation can't be empty.");
                return;
            }

            var newDocFragment = new DocumentationFragment()
            {
                Documentation = this.DocumentationTextBox.Text,
                Selection = this._selectionText
            };
            try
            {
                DocumentationFileHandler.AddDocumentationFragment(newDocFragment, this._documentPath + ".doc");
                MessageBox.Show("Documentation added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Documentation add failed. Exception: " + ex.ToString());
            }

        }
    }
}
