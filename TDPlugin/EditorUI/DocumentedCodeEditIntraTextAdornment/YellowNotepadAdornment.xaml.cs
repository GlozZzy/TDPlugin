﻿using TDPlugin.Dialogs;
using TDPlugin.EditorUI.DocumentedCodeHighlighter;
using TDPlugin.Events;
using TDPlugin.Services;
using TDPlugin.Utils.WPFUtils;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TDPlugin.EditorUI.DocumentedCodeEditIntraTextAdornment
{
    /// <summary>
    /// Interaction logic for YellowNotepadAdornment.xaml
    /// </summary>
    public partial class YellowNotepadAdornment : UserControl
    {
        public IEventAggregator EventAggregator { get; }



        public DocumentationTag DocumentationTag
        {
            get { return (DocumentationTag)GetValue(DocumentationTagProperty); }
            set { SetValue(DocumentationTagProperty, value); }
        }
        public static readonly DependencyProperty DocumentationTagProperty =
            DependencyProperty.Register("DocumentationTag", typeof(DocumentationTag), typeof(YellowNotepadAdornment), new PropertyMetadata(null));


        public ITextBuffer Buffer
        {
            get { return (ITextBuffer)GetValue(BufferProperty); }
            set { SetValue(BufferProperty, value); }
        }
        public static readonly DependencyProperty BufferProperty =
            DependencyProperty.Register("Buffer", typeof(ITextBuffer), typeof(YellowNotepadAdornment), new PropertyMetadata(null));



        //public string DocumentationText
        //{
        //    get { return (string)GetValue(DocumentationTextProperty); }
        //    set { SetValue(DocumentationTextProperty, value); }
        //}
        //public static readonly DependencyProperty DocumentationTextProperty =
        //    DependencyProperty.Register("DocumentationText", typeof(string), typeof(YellowNotepadAdornment), new PropertyMetadata(string.Empty));



        public YellowNotepadAdornment()
        {
            InitializeComponent();
            SetPopupPlacementCallbacks();
            EventAggregator = VisualStudioServices.ComponentModel.GetService<IEventAggregator>();
        }

        private void SetPopupPlacementCallbacks()
        {
            HoverPopup.CustomPopupPlacementCallback +=
                    (popupSize, targetSize, offset) => PopupPlacement.PlacePopup(popupSize, targetSize, offset,
                        VerticalPlacement.Bottom,
                        HorizontalPlacement.Center);
        }

        private void OnMouseEnterImage(object sender, MouseEventArgs e)
        {
            HoverPopup.IsOpen = true;
            EventAggregator.SendMessage<MouseHoverOnDocumentationEvent>
                    (new MouseHoverOnDocumentationEvent(DocumentationTag, MouseHoverOnDocumentationEvent.HoverMode.Started));
        }

        private void OnMouseLeaveImage(object sender, MouseEventArgs e)
        {
            ClosePopupIfNecessary();
            EventAggregator.SendMessage<MouseHoverOnDocumentationEvent>
                        (new MouseHoverOnDocumentationEvent(DocumentationTag, MouseHoverOnDocumentationEvent.HoverMode.Ended));
        }

        private void ClosePopupIfNecessary()
        {
            HoverPopup.IsOpen = AdornmentImage.IsMouseOver || HoverPopup.IsMouseOver;
        }

        private void OnMouseLeavePopup(object sender, MouseEventArgs e)
        {
            ClosePopupIfNecessary();
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            var documentationControl = new AddDocumentationWindow();
            var vm = new EditDocumentationViewModel(DocumentationTag.TrackingSpan.GetText(Buffer.CurrentSnapshot), DocumentationTag.DocumentationFragmentText);
            documentationControl.DataContext = vm;
            documentationControl.ShowDialog();
            if (documentationControl.Result == EditDocumentationViewModel.AddDocumentationResult.Save)
            {
                var newDocumentation = vm.DocumentationText;
                EventAggregator.SendMessage<DocumentationUpdatedEvent>(new DocumentationUpdatedEvent(DocumentationTag.TrackingSpan, newDocumentation));
            }
            else if (documentationControl.Result == EditDocumentationViewModel.AddDocumentationResult.Delete)
            {
                EventAggregator.SendMessage<DocumentationDeletedEvent>(new DocumentationDeletedEvent(DocumentationTag));
            }
        }
    }
}
