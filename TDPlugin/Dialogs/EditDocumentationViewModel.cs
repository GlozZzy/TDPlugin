using TDPlugin.Events;
using TDPlugin.Models;
using TDPlugin.Services;
using TDPlugin.Utils;
using TDPlugin.Utils.WPFUtils;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TDPlugin.Dialogs
{
    public class EditDocumentationViewModel : INotifyPropertyChanged
    {
        public enum AddDocumentationResult { Cancel, Save, Delete }
        public AddDocumentationResult Result { get; set; }


        public IEventAggregator EventAggregator { get; set; }
        private string _documentPath;
        private TextViewSelection _selection;
        bool _existingDocumentation = false;
        private string _selectionText;
        public SelectionDocumentation Documentation;

        public event Action CloseRequest;

        private EditDocumentationViewModel()
        {
            EventAggregator = VisualStudioServices.ComponentModel.GetService<IEventAggregator>();
        }

        public EditDocumentationViewModel(string documentPath, TextViewSelection selection) : this()
        {
            this._documentPath = documentPath;
            this._selection= selection;
        }

        public EditDocumentationViewModel(string selectionText, SelectionDocumentation selectiondocumentation) : this()
        {
            _existingDocumentation = true;
            _selectionText = selectionText;
            Documentation = selectiondocumentation;

            DocumentationTitle = selectiondocumentation.Title;
            DocumentationDescription = selectiondocumentation.Description;
            DocumentationPriority = selectiondocumentation.Priority;
            DocumentationEffort = selectiondocumentation.Effort;
            DocumentationClientsUpvotes = selectiondocumentation.ClietsUpvotes;
            Documentationlikes = selectiondocumentation.ClietsUpvotes.Count - 1;
            AuthorName = selectiondocumentation.ClietsUpvotes[0];

        }

        public string SelectionText => _existingDocumentation ? _selectionText : _selection.Text;

        public string _documentationTitle = "";
        public string DocumentationTitle
        {
            get { return _documentationTitle; }
            set
            {
                if (value != _documentationTitle)
                {
                    _documentationTitle = value;
                    RaisePropertChange();
                }
            }
        }

        public string _documentationDescription = "";
        public string DocumentationDescription
        {
            get { return _documentationDescription; }
            set
            {
                if (value != _documentationDescription)
                {
                    _documentationDescription = value;
                    RaisePropertChange();
                }
            }
        }

        public int _documentationPriority = 0;
        public int DocumentationPriority
        {
            get { return _documentationPriority; }
            set
            {
                if (value != _documentationPriority)
                {
                    _documentationPriority = value;
                    RaisePropertChange();
                }
            }
        }

        public int _documentationEffort = 0;
        public int DocumentationEffort
        {
            get { return _documentationEffort; }
            set
            {
                if (value != _documentationEffort)
                {
                    _documentationEffort = value;
                    RaisePropertChange();
                }
            }
        }

        public List<string> DocumentationClientsUpvotes;

        public int _documentationlikes = 0;
        public int Documentationlikes
        {
            get { return _documentationlikes; }
            set
            {
                if (value != _documentationlikes)
                {
                    _documentationlikes = value;
                    RaisePropertChange();
                }
            }
        }

        public string _authorName = "";
        public string AuthorName
        {
            get { return _authorName; }
            set
            {
                if (value != _authorName)
                {
                    _authorName = value;
                    RaisePropertChange();
                }
            }
        }

        public bool IsExistingDocumentation => _existingDocumentation;

        public ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(_ =>
                    {
                        Result = AddDocumentationResult.Cancel;
                        CloseRequest?.Invoke();
                    });
                }
                return _cancelCommand;
            }
        }

        public ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(SaveDocumentation);
                }
                return _saveCommand;
            }
        }

        private void SaveDocumentation(object obj)
        {
            if (DocumentationTitle.Trim() == "")
            {
                MessageBox.Show("Title can't be empty.");
                return;
            }
            if (DocumentationDescription.Trim() == "")
            {
                MessageBox.Show("Documentation can't be empty.");
                return;
            }

            if (_existingDocumentation)
            {
                Result = AddDocumentationResult.Save;
                CloseRequest?.Invoke();
                return;
            }

            var newDocFragment = new DocumentationFragment()
            {
                Documentation = new SelectionDocumentation()
                {
                    Title = DocumentationTitle,
                    Description = DocumentationDescription,
                    Priority = DocumentationPriority,
                    Effort = DocumentationEffort,
                    ClietsUpvotes = new List<string>() { ClientSettings.Default.username }
                },
                Selection = this._selection,
            };
            try
            {
                string filepath = this._documentPath + Consts.CODY_DOCS_EXTENSION;
                DocumentationFileHandler.AddDocumentationFragment(newDocFragment, filepath);
                MessageBox.Show("Documentation added successfully.");
                EventAggregator.SendMessage<DocumentationAddedEvent>(
                    new DocumentationAddedEvent()
                    {
                        Filepath = filepath,
                        DocumentationFragment = newDocFragment
                    });
                Result = AddDocumentationResult.Save;
                CloseRequest?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Documentation add failed. Exception: " + ex.ToString());
            }
        }


        public ICommand _likeCommand;
        public ICommand LikeCommand
        {
            get
            {
                if (_likeCommand == null)
                {
                    _likeCommand = new RelayCommand(_ => 
                    {
                        if (Documentation.ClietsUpvotes.FindIndex(x => x == ClientSettings.Default.username) < 0)
                            Documentation.ClietsUpvotes.Add(ClientSettings.Default.username);
                        else if (Documentation.ClietsUpvotes.FindIndex(x => x == ClientSettings.Default.username) > 0)
                             Documentation.ClietsUpvotes.Remove(ClientSettings.Default.username);

                        Documentationlikes = Documentation.ClietsUpvotes.Count - 1;
                        Result = AddDocumentationResult.Save;
                    });
                }
                return _likeCommand;
            }
        }


        public ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(_ =>
                    {
                        Result = AddDocumentationResult.Delete;
                        CloseRequest?.Invoke();
                    });
                }
                return _deleteCommand;
            }
        }


        #region NOTIFY PROPERTY CHANGE
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertChange([CallerMemberName]string propertyName = null)
        {
            if (propertyName == null)
                return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion NOTIFY PROPERTY CHANGE
    }
}
