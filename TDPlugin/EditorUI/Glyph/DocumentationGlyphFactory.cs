﻿using TDPlugin.EditorUI.DocumentedCodeHighlighter;
using TDPlugin.Events;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TDPlugin.EditorUI.Glyph
{
    /// <summary>
    /// This class implements IGlyphFactory, which provides the visual
    /// element that will appear in the glyph margin.
    /// </summary>
    internal class DocumentationGlyphFactory : IGlyphFactory
    {
        public IEventAggregator EventAggregator { get; }

        public DocumentationGlyphFactory(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public UIElement GenerateGlyph(IWpfTextViewLine line, IGlyphTag tag)
        {
            var docTag = tag as DocumentationTag;
            var documentedText = (docTag.TrackingSpan.GetText(docTag.TextBuffer.CurrentSnapshot));
            var numOfLines = documentedText.Split('\n').Count();

            var lineHeight = line.Height;
            var grid = new System.Windows.Controls.Grid()
            {
                Width = lineHeight,
                Height = lineHeight * numOfLines
            };
            var rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromRgb(240,222, 2)),
                Stroke = Brushes.Gray,
                Width = lineHeight / 3,
                Height = lineHeight * numOfLines,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            grid.Children.Add(rectangle);

            return grid;
        }

    }
}
