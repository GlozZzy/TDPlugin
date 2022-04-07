﻿using TDPlugin.Events;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace TDPlugin.Services
{
    public static class DocumentLifetimeManager
    {
        private static EnvDTE.Events _events;
        private static DocumentEvents _documentEvents;
        private static Lazy<IEventAggregator> EventAggregator = 
            new Lazy<IEventAggregator>(()=>VisualStudioServices.ComponentModel.GetService<IEventAggregator>());

        private static EnvDTE80.DTE2 applicationObject = null;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            applicationObject = serviceProvider.GetService(typeof(SDTE)) as EnvDTE80.DTE2;//EnvDTE80.DTE2;

            //Need to keep strong reference to _events and _documentEvents otherwise they will be garbage collected
            _events = applicationObject.Events;
            _documentEvents = _events.DocumentEvents;

            _documentEvents.DocumentSaved += OnDocumentSaved;
            _documentEvents.DocumentClosing += OnDocumentClosing;
        }

        private static void OnDocumentClosing(Document document)
        {
            if (document != null)
                EventAggregator.Value.SendMessage<DocumentClosedEvent>(new DocumentClosedEvent(document.FullName));
        }

        private static void OnDocumentSaved(Document document)
        {
            EventAggregator.Value.SendMessage<DocumentSavedEvent>(new DocumentSavedEvent(document.FullName));
        }

        public static Document GetDocument(string forPath)
        {
            foreach (var item in applicationObject.Documents)
            {
                var doc = item as Document;
                if (doc.FullName.Equals(forPath, StringComparison.CurrentCultureIgnoreCase))
                {
                    return doc;
                }
            }
            return null;
        }
    }
}
