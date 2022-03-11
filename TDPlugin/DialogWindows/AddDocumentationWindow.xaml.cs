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

namespace TDPlugin
{
    /// <summary>
    /// Логика взаимодействия для AddDocumentationWindow.xaml
    /// </summary>
    public partial class AddDocumentationWindow
    {
        public AddDocumentationWindow(string filename, TextViewSelection selection)
        {
            InitializeComponent();
            SelectionTextBox.Text = selection.Text;
        }
    }
}