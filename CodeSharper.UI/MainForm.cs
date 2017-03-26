using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using CodeSharper.UI.Analyzer;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Controls;
using CodeSharper.UI.ListViewExtensions;

//using EnvDTE;

namespace CodeSharper.UI
{
    public partial class MainForm : Form
    {
        private readonly ListViewColumnSorter _lvwColumnSorter;
        private readonly ICodeAnalyzer _codeAnalyser;
        private AnalysisFileType _selectedType;
        private AnalysisFile _selectedAnalysisFile;
        private List<IssueType> _issueTypes;
        private readonly Exclusions _exclusions;

        private int _excludedFileCount;
        private int _totalFileCount;
        private int _issueCount;
        private int _issueFileCount;

        /// <summary>
        /// Creates an instance of MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ListViewHelper.EnableDoubleBuffer(lvwReport);

            
            List<AnalysisFile> fileOptions = UiHelper.GetAnalysisFiles();
            cboType.DataSource = fileOptions;

            _selectedAnalysisFile = GetAnalysisFile();
            _selectedType = _selectedAnalysisFile.FileType;

            //This class should be loaded only once in the application. Singleton planned.
            _exclusions = new Exclusions();

            RenderControls(_selectedType);
            _codeAnalyser = CodeAnalyzerFactory.GetAnalyzer(_selectedType);

            _lvwColumnSorter = new ListViewColumnSorter();
            lvwReport.ListViewItemSorter = _lvwColumnSorter;
            lvwReport.Sorting = SortOrder.Ascending;
            lvwReport.AutoArrange = true;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Renders the check boxes required for analysis flags
        /// </summary>
        /// <param name="fileType">The corresponding file type</param>
        private void RenderControls(AnalysisFileType fileType)
        {
            IControlsBuilder controlsBuilder = ControlsBuilderFactory.GetControlsBuilder(fileType);
            List<ConditionCheckBox> checkBoxes = controlsBuilder.GetConditionControls();
            ControlHelper.RenderCheckBoxes(gpCSharp, checkBoxes);
        }

        /// <summary>
        /// Get the analysis file from the selected item in the dropdown
        /// </summary>
        /// <returns>The file type that needs to be analysed</returns>
        private AnalysisFile GetAnalysisFile()
        {
            var analysisFile = cboType.SelectedItem as AnalysisFile;
            return analysisFile;
        }

        /// <summary>
        /// Get all issue type flags selected from the rendered Check Boxes
        /// </summary>
        /// <returns>The list of issue type flags returned</returns>
        private List<IssueType> GetIssuesFromControls()
        {
            var issuesSelected = new List<IssueType>();

            foreach (var control in gpCSharp.Controls)
            {
                if (control is CheckBox)
                {
                    var checkBox = control as CheckBox;
                    if (checkBox.Checked)
                    {
                        //the "as" keyword will not work in the below conversion as IssueType is a value type.
                        issuesSelected.Add((IssueType)checkBox.Tag);
                    }
                }
            }
            return issuesSelected;
        }

        /// <summary>
        /// Method to reset all counter labels in the results area to "0"
        /// </summary>
        private void ResetCounterLabels()
        {
            lblTotalFiles.Text = ApplicationConstants.ZeroLabel;
            lblExcludedFiles.Text = ApplicationConstants.ZeroLabel;
            lblFilesWithIssues.Text = ApplicationConstants.ZeroLabel;
            lblIssuesFound.Text = ApplicationConstants.ZeroLabel;
            pgbProgress.Value = 0;
            lvwReport.Items.Clear();
        }

        /// <summary>
        /// Method to reset all counter values to "0";
        /// </summary>
        private void ResetCounterValues()
        {
            _totalFileCount = 0;
            _excludedFileCount = 0;
            _issueFileCount = 0;
            _issueCount = 0;
        }

        /// <summary>
        /// Method to refresh the counter labels
        /// </summary>
        private void RefreshCounterLabels()
        {
            lblTotalFiles.Refresh();
            lblExcludedFiles.Refresh();
            lblFilesWithIssues.Refresh();
            lblIssuesFound.Refresh();
        }

        private void BtnListClick(object sender, EventArgs e)
        {
            if (!IsLocationValid(txtLocation.Text))
            {
                UiHelper.ShowInformationMessageBox(ApplicationConstants.LocationNotSpecifiedMessage, ApplicationConstants.ApplicationTitle);
                return;
            }

            _issueTypes = GetIssuesFromControls();

            ResetCounterLabels();
            Application.DoEvents();
            RefreshCounterLabels();

            DoAnalysis();
        }

        private bool IsLocationValid(string location)
        {
            return location.Trim().Length > 0;
        }

        private void DoAnalysis()
        {
            ResetCounterValues();
            ResetCounterLabels();

            string extension = _selectedAnalysisFile.Extension;
            string location = txtLocation.Text;

            ICodeAnalyzer analyzer = CodeAnalyzerFactory.GetAnalyzer(_selectedType);
            analyzer.BuildConditions(_issueTypes);


            if (!analyzer.HasConditions())
            {
                UiHelper.ShowInformationMessageBox(ApplicationConstants.NoOptionSelectedMessage, ApplicationConstants.NoOptionSelectedTitle);
                return;
            }

            UpdateStatusLabel(ApplicationConstants.StatusLoadingFiles);
            
            List<string> files = GetAllMatchingFiles(location, extension);
            pgbProgress.Maximum = files.Count;
            GetIssuesFromAllFiles(analyzer, files);
        }

        /// <summary>
        /// Method that returns all issues from the list of files using the specified analyzer
        /// </summary>
        /// <param name="analyzer">The code analyzer used</param>
        /// <param name="files">The files on which code analysis needs to be performed</param>
        private void GetIssuesFromAllFiles(ICodeAnalyzer analyzer, IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                UpdateFileAnalysisStatus(file);
                if (!FileHelper.IsExcludedFile(file, _exclusions))
                {
                    string[] codeLines = FileHelper.GetCodeLinesFromFile(file);
                    List<Issue> fileIssues = analyzer.GetIssuesFromCode(file, codeLines);
                    
                    _totalFileCount++;

                    if (fileIssues != null && fileIssues.Count > 0)
                    {
                        AddIssuesToReport(fileIssues);
                        _issueFileCount++;
                        _issueCount += fileIssues.Count;
                    }
                }
                else
                {
                    _excludedFileCount++;
                }

                UpdateCounterLabels();
                UpdateProgressBar();
                lvwReport.Update();
            }
            UpdateStatusComplete();
        }

        /// <summary>
        /// Method that updates the counter labels with latest status values
        /// </summary>
        private void UpdateCounterLabels()
        {
            lblExcludedFiles.Text = _excludedFileCount.ToString(CultureInfo.InvariantCulture);
            lblExcludedFiles.Refresh();
            lblTotalFiles.Text = _totalFileCount.ToString(CultureInfo.InvariantCulture);
            lblTotalFiles.Refresh();
            lblFilesWithIssues.Text = _issueFileCount.ToString(CultureInfo.InvariantCulture);
            lblFilesWithIssues.Refresh();
            lblIssuesFound.Text = _issueCount.ToString(CultureInfo.InvariantCulture);
            lblIssuesFound.Refresh();
            Application.DoEvents();
        }

        /// <summary>
        /// Update the status label with the currently analysed file name
        /// </summary>
        /// <param name="fileName">Name of the file being analysed currently</param>
        private void UpdateFileAnalysisStatus(string fileName)
        {
            lblCurrentStatus.Text = String.Concat(ApplicationConstants.StatusAnalyzingFile, fileName);
            lblCurrentStatus.Refresh();
        }

        /// <summary>
        /// Update the status label with analysis complete status
        /// </summary>
        private void UpdateStatusComplete()
        {
            lblCurrentStatus.Text = ApplicationConstants.StatusComplete;
            lblCurrentStatus.Refresh();
        }

        /// <summary>
        /// Update the status label with latest message
        /// </summary>
        /// <param name="text">The text to be set to the label</param>
        private void UpdateStatusLabel(string text)
        {
            lblCurrentStatus.Text = text;
            lblCurrentStatus.Refresh();
        }

        /// <summary>
        /// Update the progress bar
        /// </summary>
        private void UpdateProgressBar()
        {
            pgbProgress.Value++;
            pgbProgress.Refresh();
        }

        /// <summary>
        /// Method to add the issues in a file to the Report ListView
        /// </summary>
        /// <param name="issues">Enumerable list containing issues from a specific file</param>
        private void AddIssuesToReport(IEnumerable<Issue> issues)
        {
            foreach (Issue issue in issues)
            {
                Application.DoEvents();
                var item = new ListViewItem((lvwReport.Items.Count + 1).ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(issue.FileName);
                item.SubItems.Add(issue.LineNumber.ToString(CultureInfo.InvariantCulture));
                item.Tag = issue;
                item.SubItems.Add(_codeAnalyser.GetIssueTypeString(issue.TypeOfIssue));
                item.SubItems.Add(issue.Contents);

                lvwReport.Items.Add(item);
            }
        }

        /// <summary>
        /// Method that gets all matching files from the given directory and subdirectories
        /// </summary>
        /// <param name="location">The fully qualified location given</param>
        /// <param name="extension">The extension of the file to be selected</param>
        /// <returns></returns>
        private List<string> GetAllMatchingFiles(string location, string extension)
        {
            var fileHelper = new FileHelper();
            List<string> files = fileHelper.GetMatchingFilesFromDirectory(location, extension);
            files.AddRange(fileHelper.GetMatchingFilesFromSubDirectories(location, extension));
            return files;
        }

        /// <summary>
        /// Event that is used to sort bsaed on the column that is clicked on the list view header
        /// </summary>
        /// <param name="sender">Defaut parameter of event</param>
        /// <param name="e">Default event arguments parameter</param>
        private void LvwReportColumnClick(object sender, ColumnClickEventArgs e)
        {
            var myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                _lvwColumnSorter.Order = _lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwColumnSorter.SortColumn = e.Column;
                _lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }

        private void BtnSelectClick(object sender, EventArgs e)
        {
            if (fbrLocation.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = fbrLocation.SelectedPath;
            }
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            lvwReport.Height = Height - pnlDetails.Height - 30;
            lvwReport.Refresh();
        }

        private void LvwReportSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnExportClick(object sender, EventArgs e)
        {
            if (lvwReport.Items.Count <= 0)
            {
                UiHelper.ShowExclamationMessageBox(ApplicationConstants.NoItemsFoundToExport, ApplicationConstants.ApplicationTitle);
                return;
            }

            sdlgExport.Filter = ApplicationConstants.FileExportFilter;
            sdlgExport.Title = ApplicationConstants.FileExportTitle;

            if (sdlgExport.ShowDialog() == DialogResult.OK)
            {
                ExportHelper.ExportListToCsv(lvwReport, sdlgExport.FileName);
            }
        }


        private void MnuOpenInVisualStudioClick(object sender, EventArgs e)
        {
            OpenSelectedItems();
        }


        private void LvwReportDoubleClick(object sender, EventArgs e)
        {
            OpenSelectedItems();
        }


        private void OpenSelectedItems()
        {
            ListView.SelectedListViewItemCollection selectedItems = lvwReport.SelectedItems;

            if (selectedItems.Count == 0)
            {
                UiHelper.ShowExclamationMessageBox(ApplicationConstants.NoItemSelectedMessage, ApplicationConstants.ApplicationTitle);
            }

            try
            {
                foreach (ListViewItem item in selectedItems)
                {
                    var issue = (Issue)item.Tag;

                    string fileName = issue.FileName;
                    int lineNumber = issue.LineNumber;
                    //VsHelper.ShowLineInVisualStudio( fileName, lineNumber );
                    VsHelper.LaunchSourceFile(this, fileName, lineNumber.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowErrorMessageBox(String.Concat(ApplicationConstants.ErrorOpeningItemMessage, ex.Message), ApplicationConstants.ErrorMessageTitle);
            }
        }

        private void LvwReportKeyPress(object sender, KeyPressEventArgs e)
        {
            int keyAscii = Convert.ToInt32(e.KeyChar);
            if (keyAscii == 13)
            {
                OpenSelectedItems();
            }
            
        }

        private void MnuShowDetailsClick(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void ShowDetails()
        {
            ListView.SelectedListViewItemCollection selectedItems = lvwReport.SelectedItems;

            if (selectedItems.Count == 0)
            {
                UiHelper.ShowExclamationMessageBox(ApplicationConstants.NoItemSelectedMessage, ApplicationConstants.ApplicationTitle);
            }

            ListViewItem detailItem = selectedItems[0];
            var details = new DetailsForm();

            var issue = (Issue)detailItem.Tag;

            details.FileName = issue.FileName;
            details.LineNumber = issue.LineNumber;
            details.Contents = issue.Contents;
            details.TypeOfIssue = issue.TypeOfIssue;
            details.Guidelines = _codeAnalyser.GetIssueGuidelines(issue.TypeOfIssue);
            details.IssueText = _codeAnalyser.GetIssueTypeString(issue.TypeOfIssue);
            details.ShowDialog(this);
        }

        private void LvwReportKeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && e.KeyCode == Keys.F2)
            {
                ShowDetails();
            }
            else if (e.Shift && e.Control && e.KeyCode == Keys.F11)
            {
                UiHelper.ShowInformationMessageBox(ApplicationConstants.AboutFriskerMessage, ApplicationConstants.AboutFriskerTitle);
            }
        }

        private void BtnAboutClick(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        private void CboTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAnalysisFile = GetAnalysisFile();
            _selectedType = _selectedAnalysisFile.FileType;
            RenderControls(_selectedType);
        }
    }
}
