using danaosDocuments.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using danaosDocuments.Dto;
using OfficeOpenXml;

namespace danaosDocuments
{
    public partial class frmJournalStatus : Form
    {
        private static DataTable myTableUsers = new DataTable("Users");
        DataTable myTableEmployees = new DataTable("Employees");
        DataTable myTableCompanies = new DataTable("Companies");
        DataTable myTableJournalStatus = new DataTable("JournalStatus");
        string username = "";
        int journalTypeCounter = 0;
        CheckBox headerCheckBox = new CheckBox();


        public frmJournalStatus()
        {
            InitializeComponent();
        }

        private void frmJournalStatus_Load(object sender, EventArgs e)
        {

            chkAllUsers.Checked = true;
            chkAllCompanies.Checked = true;

            // Get username from desktop
            username = Environment.UserName;
            string orclCmdUser = "SELECT DISTINCT * FROM EMPLOYEES inner join TRD_EMPLOYEES ON employees.user_login=trd_employees.user_login WHERE employees.user_domain_name='" + username + "'";
            string status = "";

            // Change Date Format
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = "dd/MM/yyyy";

            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = "dd/MM/yyyy";

            // Clear DataTable and Reset then retreive the username of user logged in
            myTableUsers.Clear();
            myTableUsers.Reset();
            myTableUsers = dbData.retreiveDataDanaos(orclCmdUser);

            // Check Status
            try
            {
                status = myTableUsers.Rows[0].Field<string>("ACCESS_TO_VB_APP");
            }
            catch
            {
                status = "N";
            }

            // If username is not below then do not open else load data
            if ((username != "antonia.t") && (username != "michalis.s") && (username != "theodoros.h") && (username != "aristos.a") && (username != "gregoris.s"))
            {
                MessageBox.Show("You have no access to the application.", "Important Message.", MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                loadData();
            }
        }

        private void loadData()
        {
            string orclCmdEmployees = "SELECT USER_ID, EMP_SURNAME || ' ' || EMP_NAME AS EMP_FULLNAME FROM EMPLOYEES WHERE USER_ID IS NOT NULL AND USER_LOGIN IS NOT NULL ORDER BY EMP_FULLNAME ASC";
            string orclCmdCompanies = "SELECT COMPANY, SHORT_NAME FROM COMPANIES_MAIN";
            string orclCmdJournalStatus = "SELECT DISTINCT JOURNAL_SERIES, 'All Entries' As ALL_ENTRIES FROM DOCUMENTS WHERE JOURNAL_SERIES <> '.'";

            myTableEmployees.Clear();
            myTableEmployees.Reset();
            myTableEmployees = dbData.retreiveDataDanaos(orclCmdEmployees);

            cmbUser.DataSource = myTableEmployees;
            cmbUser.DisplayMember = "EMP_FULLNAME";
            cmbUser.ValueMember = "USER_ID";

            myTableCompanies.Clear();
            myTableCompanies.Reset();
            myTableCompanies = dbData.retreiveDataDanaos(orclCmdCompanies);

            cmbCompany.DataSource = myTableCompanies;
            cmbCompany.DisplayMember = "SHORT_NAME";
            cmbCompany.ValueMember = "COMPANY";

            myTableJournalStatus.Clear();
            myTableJournalStatus.Reset();
            myTableJournalStatus = dbData.retreiveDataDanaos(orclCmdJournalStatus);

            int i = 0;

            foreach (DataRow item in myTableJournalStatus.Rows)
            {
                dataGridViewJournalTypes.Rows.Add();
                dataGridViewJournalTypes.Rows[i].Cells["journalType"].Value = item["JOURNAL_SERIES"].ToString();
                dataGridViewJournalTypes.Rows[i].Cells["showEntries"].Value = item["ALL_ENTRIES"].ToString();
                i += 1;
            }
        }

        private void btnResetParams_Click(object sender, EventArgs e)
        {
            // Reset Values to default 
            dateTimePickerFrom.Value = DateTime.Now;
            dateTimePickerTo.Value = DateTime.Now;

            cmbUser.SelectedIndex = 0;
            cmbCompany.SelectedIndex = 0;

            for (int i = 0; i < dataGridViewJournalTypes.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell chk = dataGridViewJournalTypes.Rows[i].Cells["journalTypeChecked"] as DataGridViewCheckBoxCell;
                dataGridViewJournalTypes.Rows[i].Cells["journalTypeChecked"].Value = chk.FalseValue;
            }
        }

        private async void btnExportDocs_Click(object sender, EventArgs e)
        {
            //MAIN TABLE is DOCUMENTS (columns: FILED_TO (equals ATTACHMENT_CODE), JOURNAL_COMPANY, JOURNAL_STATUS, JOURNAL NUMBER, ISSUE_DATE, CREATED_BY_USERS)
            //JOIN TABLE is ACC_ATTACHED_DOCS (columns: FULLPATH)
            if (chkAllUsers.Checked == true)
            {
                if (journalTypeCounter == 0)
                {
                    progBarExport.Visible = false;
                    MessageBox.Show("Please select atleast one Journal Type to proceed with exporting the documents.", "Important message.", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    progBarExport.Visible = true;

                    btnExportDocs.Enabled = false;
                    btnResetParams.Enabled = false;

                    await Task.Run(() => exportDocs());
                }
            }
            else
            {
                progBarExport.Visible = false;
                MessageBox.Show("This version of the program does not support exporting documents per user and will be available in the next patch. Thank you for your understanding.", "Important message.", MessageBoxButtons.OK);
                chkAllUsers.Checked = true;
            }
        }

        private void dataGridViewJournalTypes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (Convert.ToBoolean(dataGridViewJournalTypes.Rows[e.RowIndex].Cells["journalTypeChecked"].Value) == true)
                {
                    journalTypeCounter += 1;
                }
                else
                {
                    journalTypeCounter -= 1;
                }
            }
        }

        private async void exportDocs()
        {
            DataTable dtDocuments = generateOracleQuery();

            await Task.Run(() => copyAndRenameDocuments(dtDocuments));     
        }

        public DataTable generateOracleQuery()
        {

            string orclCmd = "SELECT DISTINCT DOCUMENTS.JOURNAL_COMPANY || '/' || DOCUMENTS.JOURNAL_SERIES || '/' || DOCUMENTS.JOURNAL_NUMBER AS JOURNAL_ENTRY, DOCUMENTS.JOURNAL_COMPANY, DOCUMENTS.JOURNAL_SERIES, DOCUMENTS.JOURNAL_NUMBER, DOCUMENTS.FILED_TO, DOCUMENTS.JOURNAL_DATE, ACC_ATTACHED_DOCS.ATTACHMENT_CODE AS ACC_ATTACHMENT_CODE, ACC_ATTACHED_DOCS.ATTACHMENT_NO AS ACC_ATTACHMENT_NO, ACC_ATTACHED_DOCS.FULLPATH AS ACC_FULLPATH, CMT_ATTACHED_DOCS.ATTACHMENT_CODE AS CMT_ATTACHMENT_CODE, CMT_ATTACHED_DOCS.ATTACHMENT_NO AS CMT_ATTACHMENT_NO, CMT_ATTACHED_DOCS.FULLPATH AS CMT_FULLPATH FROM DOCUMENTS LEFT JOIN ACC_ATTACHED_DOCS ON DOCUMENTS.FILED_TO = ACC_ATTACHED_DOCS.ATTACHMENT_CODE LEFT JOIN CMT_DOCUMENTS_ENTRY ON DOCUMENTS.JOURNAL_COMPANY || '/' || DOCUMENTS.JOURNAL_SERIES || '/' || DOCUMENTS.JOURNAL_NUMBER = CMT_DOCUMENTS_ENTRY.JOURNAL_COMPANY || '/' || CMT_DOCUMENTS_ENTRY.JOURNAL_SERIES || '/' || CMT_DOCUMENTS_ENTRY.JOURNAL_NUMBER LEFT JOIN CMT_ATTACHED_DOCS ON CMT_DOCUMENTS_ENTRY.FILED_TO = CMT_ATTACHED_DOCS.ATTACHMENT_CODE WHERE ";

            //Convert dates to Danaos Format
            string fromDate = dateTimePickerFrom.Value.ToString("dd-MMM-yy");
            fromDate = fromDate.ToUpper();

            //Convert dates to Danaos Format
            string toDate = dateTimePickerTo.Value.ToString("dd-MMM-yy");
            toDate = toDate.ToUpper();

            bool compBool = true;

            if (chkAllCompanies.InvokeRequired)
            {
                chkAllCompanies.Invoke(new MethodInvoker(delegate { compBool = chkAllCompanies.Checked; }));
            }
            else
            {
                compBool = chkAllCompanies.Checked;
            }

            string compIndex = "";

            if (compBool != true)
            {
                if (cmbCompany.InvokeRequired)
                {
                    cmbCompany.Invoke(new MethodInvoker(delegate { compIndex = cmbCompany.SelectedValue.ToString(); }));
                }
                else
                {
                    compIndex = cmbCompany.SelectedValue.ToString();
                }
                orclCmd = orclCmd + "DOCUMENTS.JOURNAL_COMPANY = '" + compIndex + "' AND ";
            }

            int typeCounter = 0;

            foreach (DataGridViewRow row in dataGridViewJournalTypes.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["journalTypeChecked"].Value);
                if (isSelected)
                {
                    typeCounter += 1;
                    string journalType = row.Cells["journalType"].Value.ToString();
                    if (journalTypeCounter == 1)
                    {
                        orclCmd = orclCmd + "DOCUMENTS.JOURNAL_SERIES IN ('" + journalType + "') AND";
                    }
                    else if (typeCounter == 1)
                    {
                        orclCmd = orclCmd + "DOCUMENTS.JOURNAL_SERIES IN ('" + journalType + "',";
                    }
                    else if (typeCounter == journalTypeCounter)
                    {
                        orclCmd = orclCmd + " '" + journalType + "') AND ";
                    }
                    else
                    {
                        orclCmd = orclCmd + " '" + journalType + "',";
                    }
                }
            }

            orclCmd = orclCmd + " DOCUMENTS.JOURNAL_DATE BETWEEN '" + fromDate + "' AND '" + toDate + "' ORDER BY DOCUMENTS.JOURNAL_DATE, JOURNAL_ENTRY ASC";

            DataTable dtDocuments = dbData.retreiveDataDanaos(orclCmd);

            return dtDocuments;
        }

        private async void copyAndRenameDocuments(DataTable dtDocuments)
        {
            try
            {
                string userPath = @"C:\Temp\exportedDocumentsDanaos\";

                if (Directory.Exists(userPath))
                {
                    try
                    {
                        Directory.Delete(userPath, true);
                        Directory.CreateDirectory(userPath);
                    }
                    catch
                    {
                        MessageBox.Show("Directory Cannot be deleted because a file is open by the User. Please close all Documents before running the software.", "Important Message.", MessageBoxButtons.OK);
                    
                        progBarExport.Visible = false;

                        btnExportDocs.Enabled = true;
                        btnResetParams.Enabled = true;
                    
                        return;
                    }
                }
                else
                {
                    Directory.CreateDirectory(userPath);
                }

                string filePath = "";
                string journalEntry = "";
                string documentNo = "";
                string extension = "";
                string filename = "";
                string journalCOmpany = "";
                string journalSeries = "";
                string journalNum = "";
                string documentPath = "";

                if (dtDocuments.Rows.Count == 0)
                {
                    MessageBox.Show("There are no documents to export please try choosing different dates.", "Important Message.", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    if (progBarExport.InvokeRequired)
                    {
                        progBarExport.Invoke(new MethodInvoker(delegate {
                            progBarExport.Minimum = 1;
                            progBarExport.Maximum = dtDocuments.Rows.Count;
                            progBarExport.Value = 1;
                            progBarExport.Step = 1;
                        }));
                    }
                    else
                    {
                        progBarExport.Minimum = 1;
                        progBarExport.Maximum = dtDocuments.Rows.Count;
                        progBarExport.Value = 1;
                        progBarExport.Step = 1;
                    }
                }


                foreach (DataRow row in dtDocuments.Rows)
                {
                    bool ifExistsNewP = false;
                    bool ifExistsOldP = false;

                    journalEntry = row["JOURNAL_ENTRY"].ToString();
                    journalCOmpany = row["JOURNAL_COMPANY"].ToString();
                    journalSeries = row["JOURNAL_SERIES"].ToString();
                    journalNum = row["JOURNAL_NUMBER"].ToString();

                    filePath = row["ACC_FULLPATH"].ToString();
                    documentNo = row["ACC_ATTACHMENT_NO"].ToString();

                    FileInfo fi;

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        fi = new FileInfo(filePath);
                        extension = fi.Extension;
                        filename = fi.Name;

                        if (extension == ".mflink")
                        {
                            string mfilesURL = File.ReadAllText(filePath);

                            string[] words = mfilesURL.Split('/');
                            string text = words[4];

                            words = text.Split('?');
                            text = words[0];
                            words = text.Split('-');

                            string objectType = words[0];
                            string objectID = words[1];

                            var MFAuthentication = await Task.Run(() => mfilesAPIFunctions.authentication());
                            var details = await Task.Run(() => mfilesAPIFunctions.getDocuments(MFAuthentication, objectType, objectID));

                            string documentID = "";
                            string documentName = "";

                            for (int i = 0; i < details.Count - 1; i++)
                            {
                                documentID = details[i].ID.ToString();
                                extension = details[i].Extension.ToString();
                                documentName = details[i].EscapedName.ToString();

                                documentPath = userPath + journalCOmpany + "." + journalSeries + "." + journalNum + ".SUP-" + i + 1 + "-From_M-Files." + extension;

                                var response = await Task.Run(() => mfilesAPIFunctions.downloadDocuments(MFAuthentication, objectType, objectID, documentID));

                                File.WriteAllBytes(documentPath, response);
                            }
                        }
                        else
                        {
                            documentPath = userPath + journalCOmpany + "." + journalSeries + "." + journalNum + ".SUP-" + documentNo + extension;

                            ifExistsNewP = File.Exists(documentPath);
                            ifExistsOldP = File.Exists(filePath);

                            if (ifExistsOldP == true)
                            {
                                if (ifExistsNewP != true)
                                {
                                    File.Copy(filePath, documentPath);
                                }
                                else
                                {
                                    File.Delete(documentPath);
                                    File.Copy(filePath, documentPath);
                                }
                            }
                        }
                    }

                    filePath = row["CMT_FULLPATH"].ToString();
                    documentNo = row["CMT_ATTACHMENT_NO"].ToString();

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        fi = new FileInfo(filePath);
                        extension = fi.Extension;
                        filename = fi.Name;

                        if (extension == ".mflink")
                        {
                            string mfilesURL = File.ReadAllText(filePath);

                            string[] words = mfilesURL.Split('/');
                            string text = words[4];

                            words = text.Split('?');
                            text = words[0];
                            words = text.Split('-');

                            string objectType = words[0];
                            string objectID = words[1];

                            var MFAuthentication = await Task.Run(() => mfilesAPIFunctions.authentication());
                            var details = await Task.Run(() => mfilesAPIFunctions.getDocuments(MFAuthentication, objectType, objectID));

                            string documentID = "";
                            string documentName = "";

                            for (int i = 0; i < details.Count; i++)
                            {
                                documentID = details[i].ID.ToString();
                                extension = details[i].Extension.ToString();
                                documentName = details[i].EscapedName.ToString();

                                documentPath = userPath + journalCOmpany + "." + journalSeries + "." + journalNum + ".CMT-" + i + 1 + "-From_M-Files." + extension;

                                var response = await Task.Run(() => mfilesAPIFunctions.downloadDocuments(MFAuthentication, objectType, objectID, documentID));   
                                
                                File.WriteAllBytes(documentPath,response);
                            }
                        }
                        else
                        {
                            documentPath = userPath + journalCOmpany + "." + journalSeries + "." + journalNum + ".CMT-" + documentNo + extension;

                            ifExistsNewP = File.Exists(documentPath);
                            ifExistsOldP = File.Exists(filePath);

                            if (ifExistsOldP == true)
                            {
                                if (ifExistsNewP != true)
                                {
                                    File.Copy(filePath, documentPath);
                                }
                                else
                                {
                                    File.Delete(documentPath);
                                    File.Copy(filePath, documentPath);
                                }
                            }
                        }
                    }

                    if (progBarExport.InvokeRequired)
                    {
                        progBarExport.Invoke(new MethodInvoker(delegate {
                            progBarExport.PerformStep();
                        }));
                    }
                    else
                    {
                        progBarExport.PerformStep();
                    }
                }

                if (progBarExport.InvokeRequired)
                {
                    progBarExport.Invoke(new MethodInvoker(delegate {
                        progBarExport.Visible = false;
                    }));
                }
                else
                {
                    progBarExport.Visible = false;
                }

                if (btnExportDocs.InvokeRequired)
                {
                    btnExportDocs.Invoke(new MethodInvoker(delegate {
                        btnExportDocs.Enabled = true;
                    }));
                }
                else
                {
                    btnExportDocs.Enabled = true;
                }


                if (btnResetParams.InvokeRequired)
                {
                    btnResetParams.Invoke(new MethodInvoker(delegate {
                        btnResetParams.Enabled = true;
                    }));
                }
                else
                {
                    btnResetParams.Enabled = true;
                }

                MessageBox.Show("Documents copied and renamed successfully!", "Important message.", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {              
                MessageBox.Show("Program run into an error while exporting documents. Please contact your system Administrator.", "Important Message.", MessageBoxButtons.OK);
                return;
            }
        }          

        private void dataGridViewJournalTypes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewJournalTypes.IsCurrentCellDirty)
            {
                dataGridViewJournalTypes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewJournalTypes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                for (int r = 0; r < dataGridViewJournalTypes.Rows.Count - 1; r++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewJournalTypes.Rows[r].Cells["journalTypeChecked"];
                    chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                }
            }
        }
    }
}
