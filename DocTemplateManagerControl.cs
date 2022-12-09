using Futurez.Entities;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Futurez.Xrm.Tools
{
    internal enum BulkAction
    {
        Activate = 1,
        Deactivate,
        Delete
    };

    public partial class DocTemplateManagerControl : PluginControlBase, IStatusBarMessenger
    {
        private EditTemplateControl _editControl = null;
        private UploadMultipleSummary _uploadSummary = null;

        public DocTemplateManagerControl()
        {
            InitializeComponent();
        }

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        /// <summary>
        /// This event occurs when the connection has been updated in <see cref="XrmToolBox"/>
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);

            // load the document templates again now that the connection has changed
            LoadDocumentTemplates();
        }

        private void EditControl_OnComplete(bool userCanceled, EventArgs e)
        {
            _editControl.Dispose();
            _editControl = null;

            if (!userCanceled)
            {
                ExecuteMethod(LoadDocumentTemplates);
            }
            ToggleMainControlsEnabled(true);
        }

        private void LoadDocumentTemplates()
        {
            LoadDocumentTemplates(null);
        }

        /// <summary>
        /// Load all of the system document templates from the current connection
        /// </summary>
        private void LoadDocumentTemplates(Action onCompleteCallback)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving the list of Document Templates",
                Work = (w, e) =>
                {
                    try
                    {
                        w.ReportProgress(0, "Loading Templates from CRM");
                        e.Result = DocumentTemplateEdit.GetDocumentTemplates(Service);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                },
                ProgressChanged = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
                },
                PostWorkCallBack = e =>
                {
                    var templates = e.Result as List<DocumentTemplateEdit>;

                    // load the templates
                    LoadTemplatesComplete(templates);

                    // now update the UI with the new selection
                    UpdateControlsForSelection();

                    // invoke the callback if passed
                    onCompleteCallback?.Invoke();
                },
                AsyncArgument = null,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void LoadTemplatesComplete(List<DocumentTemplateEdit> templates)
        {
            listViewDocumentTemplates.Items.Clear();
            listViewDocumentTemplates.Refresh();
            listViewDocumentTemplates.SuspendLayout();

            var listViewItemsColl = new List<ListViewItem>();

            int progress = 0;
            int counter = 0;
            foreach (var template in templates)
            {
                progress = counter / templates.Count * 100;

                // we don't want the content!
                var docType = template.Type;
                var lvItem = new ListViewItem()
                {
                    Name = "Name",
                    Text = template.Name,
                    Tag = template,  // stash the template here so we can view details later
                    Group = listViewDocumentTemplates.Groups[docType]
                };

                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, template.Status) { Tag = "Status", Name = "Status" });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, template.CreatedOn.ToString()) { Tag = "CreatedOn", Name = "CreatedOn" });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, template.ModifiedOn.ToString()) { Tag = "ModifiedOn", Name = "ModifiedOn" });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, template.AssociatedEntity) { Tag = "Associated Entity", Name = "Associated Entity" });

                listViewItemsColl.Add(lvItem);
            }

            // NOW add the items to avoid flicker
            listViewDocumentTemplates.Items.AddRange(listViewItemsColl.ToArray<ListViewItem>());
            listViewDocumentTemplates.ResumeLayout();
        }

        #region Document Template related methods

        private void PerformActivateTemplates()
        {
            var confirmMessage = "Would you like to activate the selected templates in CRM?";
            if (MessageBox.Show(confirmMessage, "Confrim Activate Template(s)", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // get the file up there!
                ExecuteMethod(PerformBulkActionTemplates, BulkAction.Activate);
            }
        }

        /// <summary>
        /// Shared method that will perform bulk actions for Delete, Activate/Deactivate
        /// </summary>
        /// <param name="action"></param>
        private void PerformBulkActionTemplates(BulkAction action)
        {
            var message = "";
            var progressMessage = "";
            switch (action)
            {
                case BulkAction.Activate:
                    message = "Activating selected Document Templates";
                    progressMessage = "activating Document Templates in CRM";
                    break;

                case BulkAction.Deactivate:
                    message = "Deactivating selected Document Templates";
                    progressMessage = "deactivating Document Templates in CRM";
                    break;

                case BulkAction.Delete:
                    message = "Deleting selected Document Templates";
                    progressMessage = "deleting Document Templates from CRM";
                    break;
            }

            var selItemArray = new ListViewItem[listViewDocumentTemplates.SelectedItems.Count];
            listViewDocumentTemplates.SelectedItems.CopyTo(selItemArray, 0);
            // build the bach list for delete
            WorkAsync(new WorkAsyncInfo
            {
                Message = message,
                AsyncArgument = selItemArray.ToList<ListViewItem>(),
                Work = (w, e) =>
                {
                    try
                    {
                        w.ReportProgress(0, "Begin " + progressMessage);
                        var selItems = e.Argument as List<ListViewItem>;
                        int templateCount = selItems.Count;
                        int counter = 0;

                        // grab the list of selected template Ids
                        foreach (ListViewItem item in selItems)
                        {
                            counter++;
                            var template = item.Tag as DocumentTemplateEdit;
                            var entityTarget = new Entity(template.EntityLogicalName, template.Id)
                            {
                                EntityState = EntityState.Changed
                            };

                            w.ReportProgress(Convert.ToInt32(counter / templateCount) * 100, "Template: " + template.Name);

                            switch (action)
                            {
                                case BulkAction.Activate:
                                case BulkAction.Deactivate:
                                    if (action == BulkAction.Activate)
                                    {
                                        entityTarget["status"] = false;
                                    }
                                    else
                                    {
                                        entityTarget["status"] = true;
                                    }
                                    var updateRequest = new UpdateRequest()
                                    {
                                        Target = entityTarget
                                    };
                                    Service.Execute(updateRequest);
                                    break;

                                case BulkAction.Delete:
                                    var deleteRequest = new DeleteRequest()
                                    {
                                        Target = entityTarget.ToEntityReference()
                                    };
                                    Service.Execute(deleteRequest);
                                    break;
                            }
                        }

                        w.ReportProgress(0, "Done " + progressMessage);
                        w.ReportProgress(0, "");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured with one or more templates:\n" + ex.Message);
                    }
                },
                ProgressChanged = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
                },
                PostWorkCallBack = e =>
                {
                    // reload the list of templates
                    LoadDocumentTemplates();
                },
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void PerformDeactivateTemplates()
        {
            var confirmMessage = "Would you like to deactivate the selected templates in CRM?";
            if (MessageBox.Show(confirmMessage, "Confrim Deactivate Template(s)", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // get the file up there!
                ExecuteMethod(PerformBulkActionTemplates, BulkAction.Deactivate);
            }
        }

        /// <summary>
        /// Delete the templates selected in the list
        /// </summary>
        private void PerformDeleteTemplates()
        {
            var confirmMessage = "Would you like to delete the selected templates from CRM?\nNOTE: THIS ACTION CANNOT BE UNDONE.";
            if (MessageBox.Show(confirmMessage, "Confrim Delete Template(s)", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // get the file up there!
                ExecuteMethod(PerformBulkActionTemplates, BulkAction.Delete);
            }
        }

        /// <summary>
        /// Download the document templates selected in the list
        /// </summary>
        private void PerformDownloadTemplates()
        {
            // choose a folder for the save...
            var folderDlg = new FolderBrowserDialog()
            {
                Description = "Select a destination folder for your download",
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = true
            };

            if ((folderDlg.ShowDialog() == DialogResult.OK) && (folderDlg.SelectedPath != null))
            {
                ExecuteMethod(DownloadDocumentTemplates, folderDlg.SelectedPath);
            }
        }

        /// <summary>
        /// Allow the user to edit some of the template attriutes
        /// Show the edit control, allow user to update attributes on a single item
        /// </summary>
        private void PerformEditTemplate()
        {
            ListViewItem item = listViewDocumentTemplates.SelectedItems[0];
            var template = item.Tag as DocumentTemplateEdit;

            // new instance of the edit control
            _editControl = new EditTemplateControl(Service, template)
            {
                // center me
                Top = Convert.ToInt32(Parent.Height / 2) - 110,
                Left = Convert.ToInt32(Parent.Width / 2) - 160,
                Parent = this
            };

            // disable the main UI so they don't monkey with stuff
            ToggleMainControlsEnabled(false);

            // handle the on complete event so we can reload and clean up control
            _editControl.OnComplete += EditControl_OnComplete;
            _editControl.BringToFront();
            _editControl.Show();
        }

        #endregion Document Template related methods

        #region Common UI methods

        /// <summary>
        /// Toggle the main area enabled or disabled
        /// </summary>
        /// <param name="enabled"></param>
        private void ToggleMainControlsEnabled(bool enabled)
        {
            Enabled = enabled;
            toolStripMain.Enabled = enabled;
            panelSplitter.Enabled = enabled;
            labelInstructions.Enabled = enabled;
        }

        /// <summary>
        /// Based on the list selection, update the controls, toolbar and properties
        /// </summary>
        private void UpdateControlsForSelection()
        {
            var count = 0;

            if (listViewDocumentTemplates.SelectedItems != null)
            {
                count = listViewDocumentTemplates.SelectedItems.Count;
            }

            // now that items have been loaded, enable upload multiple
            toolStripMenuItemUploadMultiple.Enabled = true;

            bool singleSelect = (count == 1);
            bool multiSelect = (count > 0);

            // toolButtonUpload.Enabled = singleSelect;
            toolStripMenuItemEditTemplate.Enabled = singleSelect;
            toolStripMenuItemUploadSingle.Enabled = singleSelect;

            refreshAvailableColumnsToolStripMenuItem.Enabled = singleSelect && ((DocumentTemplateEdit)listViewDocumentTemplates.SelectedItems[0].Tag).TypeValue == 2;
            selectRelationshipsToolStripMenuItem.Enabled = singleSelect && ((DocumentTemplateEdit)listViewDocumentTemplates.SelectedItems[0].Tag).TypeValue == 2;

            toolButtonDownload.Enabled = multiSelect;
            toolStripMenuItemDeleteTemplates.Enabled = multiSelect;
            toolStripMenuItemDeactivateTemplates.Enabled = multiSelect;
            toolStripMenuItemActivateTemplates.Enabled = multiSelect;

            propertyGridDetails.SelectedObject = null;

            if (count == 1)
            {
                var item = listViewDocumentTemplates.SelectedItems[0];
                var template = item.Tag as DocumentTemplateEdit;
                propertyGridDetails.SelectedObject = template;
            }
        }

        #endregion Common UI methods

        #region ListView Event Handlers

        private void listViewDocumentTemplates_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.ListViewItemSorter is ListViewItemComparer lvic)
            {
                if (lvic.Column != e.Column)
                {
                    lvic.Column = e.Column;
                    lvic.Order = SortOrder.Ascending;
                }
                else
                {
                    lvic.Order = lvic.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
            }
            else
            {
                lv.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }

            lv.Sort();
        }

        private void listViewDocumentTemplates_DoubleClick(object sender, EventArgs e)
        {
            UpdateControlsForSelection();
            PerformEditTemplate();
        }

        private void listViewDocumentTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                listViewDocumentTemplates.SuspendLayout();
                foreach (ListViewItem item in this.listViewDocumentTemplates.Items)
                {
                    item.Selected = true;
                }
                listViewDocumentTemplates.ResumeLayout();
            }
        }

        private void listViewDocumentTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlsForSelection();
        }

        #endregion ListView Event Handlers

        #region Toolbar Button Event Handlers

        private void toolButtonCloseTab_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void toolButtonDownload_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more templates to download.");
            }
            else
            {
                PerformDownloadTemplates();
            }
        }

        private void toolButtonLoadTemplates_Click(object sender, EventArgs e)
        {
            // make sure they want to reload
            if (listViewDocumentTemplates.Items.Count > 0)
            {
                if (MessageBox.Show("Clear the current list of Document Templates and reload from the server?", "Load Templates", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            // otherwise load
            ExecuteMethod(LoadDocumentTemplates);
        }

        private void toolButtonUpload_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItemActivateTemplates_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more templates to activate.");
            }
            else
            {
                PerformActivateTemplates();
            }
        }

        private void toolStripMenuItemDeactivateTemplates_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more templates to deactivate.");
            }
            else
            {
                PerformDeactivateTemplates();
            }
        }

        private void toolStripMenuItemDeleteTemplates_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more templates to delete.");
            }
            else
            {
                PerformDeleteTemplates();
            }
        }

        private void toolStripMenuItemEditTemplate_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select only one template to edit.");
            }
            else
            {
                PerformEditTemplate();
            }
        }

        #endregion Toolbar Button Event Handlers

        #region File Access methods

        /// <summary>
        /// Download the selected templates
        /// </summary>
        /// <param name="saveFolder"></param>
        private void DownloadDocumentTemplates(string saveFolder)
        {
            var templateIds = new List<Guid>();
            // grab the list of selected template Ids
            foreach (ListViewItem item in this.listViewDocumentTemplates.SelectedItems)
            {
                var template = item.Tag as DocumentTemplateEdit;
                templateIds.Add(template.Id);
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving the Document Template Content...",
                Work = (w, e) =>
                {
                    try
                    {
                        var renameCount = 1;

                        var templateIdList = e.Argument as List<Guid>;

                        // retrieve the doc template contents
                        var templates = DocumentTemplateEdit.GetDocumentTemplates(Service, templateIdList, true);

                        byte[] bytesToSave;
                        var downloadFileName = "";
                        Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();
                        var fileCount = templates.Count;

                        foreach (var template in templates)
                        {
                            var folder = template.Status + "\\" + template.Type + "\\";

                            var fileName = template.FileName;
                            var ext = Path.GetExtension(template.FileName);

                            // if we have more than one file, add a folder for the status
                            if (fileCount > 1)
                            {
                                fileName = folder + fileName;
                            }

                            renameCount = 1;
                            while (files.ContainsKey(fileName))
                            {
                                if (fileCount > 1)
                                {
                                    fileName = folder + template.Name + " (" + (renameCount++).ToString() + ")" + ext;
                                }
                                else
                                {
                                    fileName = template.Name + " (" + (renameCount++).ToString() + ")" + ext;
                                }
                            }

                            // add the file to the list for download.
                            files.Add(fileName, template.Content);
                        }

                        // if only one file was selected, save just that... otherwise, package things up in a zip!
                        if (files.Count > 1)
                        {
                            var zipper = new ZipBuilder();
                            downloadFileName = string.Format("Document Templates - {0:M-d-yyyy HH-mm}.zip", DateTime.Now);
                            bytesToSave = zipper.zipBytes(files);
                        }
                        else
                        {
                            var file = files.First();
                            bytesToSave = file.Value;
                            downloadFileName = file.Key;
                        }
                        // append the selected folder...
                        downloadFileName = Path.Combine(saveFolder, downloadFileName);

                        renameCount = 1;
                        // delete file if it exists
                        while (File.Exists(downloadFileName))
                        {
                            downloadFileName = Path.GetFileNameWithoutExtension(downloadFileName) + " (" + (renameCount++).ToString() + ")" + Path.GetExtension(downloadFileName);
                            downloadFileName = Path.Combine(saveFolder, downloadFileName);
                        }
                        // write
                        using (var saveMe = new FileStream(downloadFileName, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            saveMe.Write(bytesToSave, 0, bytesToSave.Length);
                            saveMe.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred attempting to download your templates.\n" + ex.Message);
                    }
                },
                ProgressChanged = e =>
                {
                    // If progress has to be notified to user, use the following method:
                    // SetWorkingMessage("Downloading your templates now...");
                },
                PostWorkCallBack = e => { },
                AsyncArgument = templateIds,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void ParentForm_Resize(object sender, EventArgs e)
        {
            ResizeSummaryScreen();
        }

        /// <summary>
        /// Upload multiple document template files
        /// </summary>
        private void PerformUploadMultiple()
        {
            // allow user to select one or more files
            using (var openDlg = new OpenFileDialog()
            {
                InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory),
                Filter = Constants.GetFileOpenFilter(),
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect = true
            })
            {
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    var templateNameList = new List<string>();
                    var templateList = new List<DocumentTemplateEdit>();

                    // grab the list of existing documents from the list view.
                    foreach (ListViewItem listItem in listViewDocumentTemplates.Items)
                    {
                        var template = (DocumentTemplateEdit)listItem.Tag;
                        templateNameList.Add(template.Name.ToLower() + "_" + template.Type);
                        templateList.Add(template);
                    }

                    var createTemplate = new List<FileUpload>();
                    var updateTemplate = new List<FileUpload>();
                    var ignoreTemplate = new List<FileUpload>();

                    // iterate on the list of files.  match each file name and extension to the template name and type
                    foreach (var file in openDlg.FileNames)
                    {
                        var fileUpload = new FileUpload(file, Service);

                        // if the file extension is not .docx nor .xlsx, ignore
                        if (fileUpload.IsIgnored)
                        {
                            ignoreTemplate.Add(fileUpload);
                        }
                        else
                        {
                            var key = fileUpload.TemplateName.ToLower() + "_" + fileUpload.TemplateType;

                            var foundItems = templateNameList.FindAll(s => s == key);

                            // match on the file name and type
                            if (foundItems.Count == 0)
                            {
                                // if the template is not found, then create
                                createTemplate.Add(fileUpload);
                            }
                            else
                            {
                                // only one instance
                                if (foundItems.Count == 1)
                                {
                                    var template = templateList.Find(t => t.Name.ToLower() == fileUpload.TemplateName.ToLower());
                                    fileUpload.TemplateId = template.Id;
                                    fileUpload.Note = "Update Template with id: " + template.Id.ToString("b");
                                    updateTemplate.Add(fileUpload);
                                }
                                else
                                {
                                    fileUpload.IsIgnored = true;
                                    fileUpload.Note = "Duplicate template name found";
                                    ignoreTemplate.Add(fileUpload);
                                }
                            }
                        }
                    }

                    // present a summary, allow user to confirm/cancel
                    _uploadSummary = new UploadMultipleSummary(Service, createTemplate, updateTemplate, ignoreTemplate)
                    {
                        Parent = this
                    };
                    ResizeSummaryScreen();
                    ParentForm.Resize += ParentForm_Resize;

                    // handle the on complete event so we can reload and clean up control
                    _uploadSummary.OnComplete += UploadSummary_OnComplete;
                    _uploadSummary.BringToFront();
                    _uploadSummary.Show();
                }
            }
        }

        private void PerformUploadSingle()
        {
            // assuming only a single selection
            ListViewItem item = listViewDocumentTemplates.SelectedItems[0];
            var template = item.Tag as DocumentTemplateEdit;

            // grab the list of files to be uploaded
            using (var openDlg = new OpenFileDialog()
            {
                InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory),
                Filter = Constants.GetFileOpenFilter(),
                FilterIndex = 1,
                RestoreDirectory = true
            })
            {
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fileUpload = new FileUpload(openDlg.FileName, Service);
                        if (template.Type != fileUpload.TemplateType)
                        {
                            MessageBox.Show("The extension of the file selected does not match the template selected.", "Incorrect File Type", MessageBoxButtons.OK);
                            return;
                        }
                        else if (fileUpload.IsIgnored)
                        {
                            MessageBox.Show($"Unable to upload the selected file: {fileUpload.Note}", "Unable to upload", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            var confirmMessage = $"NOTE: This will overwrite the Content of the Document Template '{template.Name}'. Please be sure that the Document Type and Associated Entity are correct.\n Would you like to continue?";
                            if (MessageBox.Show(confirmMessage, "Confrim Upload", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                // get the file up there!
                                ExecuteMethod(UploadFile, fileUpload);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening file : " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Helper method to resize the upload summary screen
        /// </summary>
        private void ResizeSummaryScreen()
        {
            var width = ParentForm.Width - 500;
            var height = ParentForm.Height - 300;

            if (_uploadSummary != null)
            {
                _uploadSummary.Top = Convert.ToInt32(ParentForm.Height / 2) - Convert.ToInt32(height / 2);
                _uploadSummary.Left = Convert.ToInt32(ParentForm.Width / 2) - Convert.ToInt32(width / 2);
                _uploadSummary.Height = height;
                _uploadSummary.Width = width;
            }
        }

        /// <summary>
        /// Upload a single document template
        /// </summary>
        /// <param name="fileName"></param>
        private void UploadFile(FileUpload fileUpload)
        {
            ListViewItem item = listViewDocumentTemplates.SelectedItems[0];
            var template = item.Tag as DocumentTemplateEdit;

            var templateId = template.Id;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Uploading your template",
                Work = (w, e) =>
                {
                    var fileToUpload = e.Argument as FileUpload;

                    var request = new UpdateRequest()
                    {
                        Target = new Entity()
                        {
                            Id = templateId,
                            LogicalName = "documenttemplate",
                            EntityState = EntityState.Changed
                        }
                    };
                    request.Target.Attributes["content"] = Convert.ToBase64String(fileToUpload.FileContents);

                    var response = Service.Execute(request);
                },
                ProgressChanged = e =>
                {
                },
                PostWorkCallBack = e =>
                {
                    LoadDocumentTemplates();
                },
                AsyncArgument = fileUpload,
                IsCancelable = true,
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        /// <summary>
        /// User elected to continue, upload the Create and Update list of files
        /// </summary>
        /// <param name="userCanceled"></param>
        /// <param name="createTemplate"></param>
        /// <param name="updateTemplate"></param>
        /// <param name="args"></param>
        private void UploadSummary_OnComplete(bool userCanceled, List<FileUpload> createTemplate, List<FileUpload> updateTemplate, EventArgs args)
        {
            _uploadSummary.Dispose();
            _uploadSummary = null;

            ParentForm.Resize -= ParentForm_Resize;

            var templateCount = updateTemplate.Count + createTemplate.Count;

            if (templateCount == 0)
            {
                MessageBox.Show(this, "No valid document template to upload", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // disable the main UI so they don't monkey with stuff
            ToggleMainControlsEnabled(false);

            if (!userCanceled)
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Uploading selected Documents",
                    Work = (w, e) =>
                    {
                        // read the file from disk

                        var errorMessages = new StringBuilder();
                        var counter = 1;

                        // make the content updates
                        // don't use bulk update to trap errors and not overload the request
                        foreach (var file in updateTemplate)
                        {
                            var request = new UpdateRequest()
                            {
                                Target = new Entity()
                                {
                                    Id = file.TemplateId,
                                    LogicalName = "documenttemplate",
                                    EntityState = EntityState.Changed
                                }
                            };
                            request.Target.Attributes["content"] = Convert.ToBase64String(file.FileContents);

                            w.ReportProgress(Convert.ToInt32(counter++ / templateCount) * 100, "Updating template: " + file.TemplateName);
                            // gather up error messages and continue
                            try
                            {
                                Service.Execute(request);
                            }
                            catch (Exception ex)
                            {
                                errorMessages.AppendFormat("Error updating template: {0}, Error Message: {1}\n", file.FileName, ex.Message);
                            }
                        }

                        foreach (var file in createTemplate)
                        {
                            var request = new CreateRequest()
                            {
                                Target = new Entity()
                                {
                                    LogicalName = "documenttemplate",
                                    EntityState = EntityState.Created
                                }
                            };

                            var desc = "New " + file.TemplateType + " template. Source file: " + file.FileName;
                            if (desc.Length > 100)
                            {
                                desc = desc.Substring(0, 100);
                            }

                            request.Target.Attributes["name"] = file.TemplateName;
                            request.Target.Attributes["documenttype"] = new OptionSetValue(file.TemplateTypeValue);
                            request.Target.Attributes["description"] = desc;
                            request.Target.Attributes["content"] = Convert.ToBase64String(file.FileContents);

                            w.ReportProgress(Convert.ToInt32(counter++ / templateCount) * 100, "Creating template: " + file.TemplateName);

                            // gather up error messages and continue
                            try
                            {
                                Service.Execute(request);
                            }
                            catch (Exception ex)
                            {
                                errorMessages.AppendFormat("Error creating template: {0}, Error Message: {1}\n", file.FileName, ex.Message);
                            }
                        }

                        // if we have error messages, show them the error of their ways
                        if (errorMessages.Length > 0)
                        {
                            throw new Exception(errorMessages.ToString());
                        }
                    },
                    ProgressChanged = e =>
                    {
                        // If progress has to be notified to user, use the following method:
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
                    },
                    PostWorkCallBack = e =>
                    {
                        ToggleMainControlsEnabled(true);

                        if (e.Error != null)
                        {
                            MessageBox.Show(this, $"The following errors occured attempting to upload the files:\n\n:{e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LoadDocumentTemplates();
                    },
                    AsyncArgument = null,
                    IsCancelable = true,
                    MessageWidth = 340,
                    MessageHeight = 150
                });
            }
        }

        #endregion File Access methods

        private void refreshAvailableColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select only one template to refresh the columns.");
            }
            else
            {
                RefreshColumns();
            }
        }

        private void RefreshColumns()
        {
            var item = (DocumentTemplateEdit)listViewDocumentTemplates.SelectedItems[0].Tag;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Refreshing columns...",
                Work = (bw, evt) =>
                {
                    item.RefreshXmlMappingContent(Service, bw);
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $"An error occured when updating Word template: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }

        private void selectRelationshipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select only one template to update the relationships.");
            }
            else
            {
                UpdateRelationships();
            }
        }

        private void toolStripMenuItemUploadMultiple_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "We will refresh the list of existing templates from the server to ensure we have the most up to date list.  Once complete, you will be prompted to select one or more files to upload.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // first load the templates again
            LoadDocumentTemplates(PerformUploadMultiple);
        }

        private void toolStripMenuItemUploadSingle_Click(object sender, EventArgs e)
        {
            if (listViewDocumentTemplates.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select only one template to update.");
            }
            else
            {
                PerformUploadSingle();
            }
        }

        private void tsbUpdateLocalWordTemplate_Click(object sender, EventArgs e)
        {
            ExecuteMethod(UpdateLocalWordTemplate);
        }

        private void UpdateLocalWordTemplate()
        {
            var dialog = new LocalTemplateUpdaterDialog(Service);
            dialog.ShowDialog(this);
        }

        private void UpdateRelationships()
        {
            var item = (DocumentTemplateEdit)listViewDocumentTemplates.SelectedItems[0].Tag;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading table metadata...",
                Work = (bw, evt) =>
                {
                    var emd = ((RetrieveEntityResponse)Service.Execute(new RetrieveEntityRequest
                    {
                        LogicalName = item.AssociatedEntityLogicalName,
                        EntityFilters = EntityFilters.Relationships
                    })).EntityMetadata;

                    var selectedRelationships = item.GetRelationships(Service);

                    evt.Result = new Tuple<EntityMetadata, List<string>>(emd, selectedRelationships);
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $"An error occured when updating Word template: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var result = (Tuple<EntityMetadata, List<string>>)evt.Result;

                    var dialog = new RelationshipSelectionDialog(Service, result.Item1, result.Item2);
                    dialog.ShowDialog(this);
                    if (dialog.DialogResult != DialogResult.OK)
                    {
                        return;
                    }

                    WorkAsync(new WorkAsyncInfo
                    {
                        Message = "Updating relationships...",
                        Work = (bw, evt2) =>
                        {
                            item.RefreshXmlMappingContent(dialog.SelectedRelationships, Service, bw);
                        },
                        ProgressChanged = evt2 =>
                        {
                            SetWorkingMessage(evt2.UserState.ToString());
                        },
                        PostWorkCallBack = evt2 =>
                        {
                            if (evt2.Error != null)
                            {
                                MessageBox.Show(this, $"An error occured when updating Word template: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    });
                }
            });
        }
    }
}