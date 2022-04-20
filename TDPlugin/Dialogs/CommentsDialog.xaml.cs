using TDPlugin.Dialogs;
using TDPlugin.Events;
using TDPlugin.Models;
using TDPlugin.Services;
using TDPlugin.Utils;
using System;
using System.Windows;
using static TDPlugin.Dialogs.EditDocumentationViewModel;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace TDPlugin
{
    /// <summary>
    /// Interaction logic for AddDocumentationControl.xaml
    /// </summary>
    public partial class CommentsDialog
    {
        public List<Comment> issueComments;
        public CommentsDialog(List<Comment> comm)
        {
            issueComments = comm;
            InitializeComponent();
            
            if (issueComments.Count == 0)
            {
                TextBlock txt = new TextBlock();
                txt.TextWrapping = TextWrapping.Wrap;
                txt.Text = "There are no comments";
                txt.Padding = new Thickness(7, 0, 7, 0);
                CommentStackPanel.Children.Add(txt);
            }
            else foreach (Comment c in issueComments)
            {
                StackPanel authorPanel = new StackPanel();
                authorPanel.Orientation = Orientation.Horizontal;


                TextBlock txt1 = new TextBlock();
                txt1.Text = "The ";
                txt1.Padding = new Thickness(7,7,0,7);

                TextBlock txt2 = new TextBlock();
                txt2.Text = c.author;
                txt2.Padding = new Thickness(0,7,0,7);
                txt2.FontWeight = FontWeights.Bold;

                TextBlock txt3 = new TextBlock();
                txt3.Text = " says";
                txt3.Padding = new Thickness(0,7,7,7);

                authorPanel.Children.Add(txt1);
                authorPanel.Children.Add(txt2);
                authorPanel.Children.Add(txt3);

                TextBlock txt = new TextBlock();
                txt.TextWrapping = TextWrapping.Wrap;
                txt.Text = c.text;
                txt.Padding = new Thickness(7,0,7,0);

                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Vertical;
                panel.Background = new SolidColorBrush(Colors.LightYellow);
                panel.Height = 92;
                panel.Margin = new Thickness(0, 0, 0, 5);

                
                panel.Children.Add(authorPanel);
                panel.Children.Add(txt);

                CommentStackPanel.Children.Add(panel);
            }
        }
    }
}
