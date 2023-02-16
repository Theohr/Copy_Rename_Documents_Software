
namespace danaosDocuments
{
    partial class frmJournalStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalStatus));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExportDocs = new System.Windows.Forms.Button();
            this.btnResetParams = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewJournalTypes = new System.Windows.Forms.DataGridView();
            this.journalType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showEntries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalTypeChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkAllUsers = new System.Windows.Forms.CheckBox();
            this.chkAllCompanies = new System.Windows.Forms.CheckBox();
            this.progBarExport = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournalTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(107, 42);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(149, 20);
            this.dateTimePickerFrom.TabIndex = 3;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(293, 42);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(150, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Additional Entry Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "User:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Company:";
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(129, 111);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(151, 21);
            this.cmbUser.TabIndex = 8;
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(129, 138);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(151, 21);
            this.cmbCompany.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(173, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Filter Entries by";
            // 
            // btnExportDocs
            // 
            this.btnExportDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDocs.Location = new System.Drawing.Point(96, 448);
            this.btnExportDocs.Name = "btnExportDocs";
            this.btnExportDocs.Size = new System.Drawing.Size(132, 23);
            this.btnExportDocs.TabIndex = 13;
            this.btnExportDocs.Text = "Export Documents";
            this.btnExportDocs.UseVisualStyleBackColor = true;
            this.btnExportDocs.Click += new System.EventHandler(this.btnExportDocs_Click);
            // 
            // btnResetParams
            // 
            this.btnResetParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetParams.Location = new System.Drawing.Point(255, 448);
            this.btnResetParams.Name = "btnResetParams";
            this.btnResetParams.Size = new System.Drawing.Size(132, 23);
            this.btnResetParams.TabIndex = 14;
            this.btnResetParams.Text = "Reset Parameters";
            this.btnResetParams.UseVisualStyleBackColor = true;
            this.btnResetParams.Click += new System.EventHandler(this.btnResetParams_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(199, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Journal Type:";
            // 
            // dataGridViewJournalTypes
            // 
            this.dataGridViewJournalTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJournalTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.journalType,
            this.showEntries,
            this.journalTypeChecked});
            this.dataGridViewJournalTypes.Location = new System.Drawing.Point(36, 221);
            this.dataGridViewJournalTypes.Name = "dataGridViewJournalTypes";
            this.dataGridViewJournalTypes.Size = new System.Drawing.Size(408, 192);
            this.dataGridViewJournalTypes.TabIndex = 16;
            this.dataGridViewJournalTypes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJournalTypes_CellValueChanged);
            this.dataGridViewJournalTypes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewJournalTypes_ColumnHeaderMouseClick);
            // 
            // journalType
            // 
            this.journalType.HeaderText = "Journal Type";
            this.journalType.Name = "journalType";
            this.journalType.ReadOnly = true;
            this.journalType.Width = 160;
            // 
            // showEntries
            // 
            this.showEntries.HeaderText = "Show Entries";
            this.showEntries.Name = "showEntries";
            this.showEntries.ReadOnly = true;
            this.showEntries.Width = 150;
            // 
            // journalTypeChecked
            // 
            this.journalTypeChecked.HeaderText = "";
            this.journalTypeChecked.Name = "journalTypeChecked";
            this.journalTypeChecked.Width = 25;
            // 
            // chkAllUsers
            // 
            this.chkAllUsers.AutoSize = true;
            this.chkAllUsers.Location = new System.Drawing.Point(296, 113);
            this.chkAllUsers.Name = "chkAllUsers";
            this.chkAllUsers.Size = new System.Drawing.Size(100, 17);
            this.chkAllUsers.TabIndex = 17;
            this.chkAllUsers.Text = "Select All Users";
            this.chkAllUsers.UseVisualStyleBackColor = true;
            // 
            // chkAllCompanies
            // 
            this.chkAllCompanies.AutoSize = true;
            this.chkAllCompanies.Location = new System.Drawing.Point(296, 140);
            this.chkAllCompanies.Name = "chkAllCompanies";
            this.chkAllCompanies.Size = new System.Drawing.Size(125, 17);
            this.chkAllCompanies.TabIndex = 18;
            this.chkAllCompanies.Text = "Select All Companies";
            this.chkAllCompanies.UseVisualStyleBackColor = true;
            // 
            // progBarExport
            // 
            this.progBarExport.Location = new System.Drawing.Point(153, 419);
            this.progBarExport.Name = "progBarExport";
            this.progBarExport.Size = new System.Drawing.Size(179, 23);
            this.progBarExport.TabIndex = 19;
            this.progBarExport.Visible = false;
            // 
            // frmJournalStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 478);
            this.Controls.Add(this.progBarExport);
            this.Controls.Add(this.chkAllCompanies);
            this.Controls.Add(this.chkAllUsers);
            this.Controls.Add(this.dataGridViewJournalTypes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnResetParams);
            this.Controls.Add(this.btnExportDocs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJournalStatus";
            this.Text = "frmJournalStatus";
            this.Load += new System.EventHandler(this.frmJournalStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournalTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExportDocs;
        private System.Windows.Forms.Button btnResetParams;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewJournalTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalType;
        private System.Windows.Forms.DataGridViewTextBoxColumn showEntries;
        private System.Windows.Forms.DataGridViewCheckBoxColumn journalTypeChecked;
        private System.Windows.Forms.CheckBox chkAllUsers;
        private System.Windows.Forms.CheckBox chkAllCompanies;
        private System.Windows.Forms.ProgressBar progBarExport;
    }
}

