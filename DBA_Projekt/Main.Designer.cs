namespace DBA_Projekt
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnUpdateDatabase = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnReadcsv = new System.Windows.Forms.Button();
            this.BtnDeleteDataFromDB = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnUpdateDatabase
            // 
            this.BtnUpdateDatabase.Location = new System.Drawing.Point(210, 50);
            this.BtnUpdateDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUpdateDatabase.Name = "BtnUpdateDatabase";
            this.BtnUpdateDatabase.Size = new System.Drawing.Size(180, 46);
            this.BtnUpdateDatabase.TabIndex = 5;
            this.BtnUpdateDatabase.Text = "UpdateDatabase";
            this.BtnUpdateDatabase.UseVisualStyleBackColor = true;
            this.BtnUpdateDatabase.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(22, 50);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(180, 46);
            this.BtnRefresh.TabIndex = 4;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 104);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1112, 304);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // BtnReadcsv
            // 
            this.BtnReadcsv.Location = new System.Drawing.Point(397, 50);
            this.BtnReadcsv.Name = "BtnReadcsv";
            this.BtnReadcsv.Size = new System.Drawing.Size(180, 46);
            this.BtnReadcsv.TabIndex = 6;
            this.BtnReadcsv.Text = "Load csvToDB";
            this.BtnReadcsv.UseVisualStyleBackColor = true;
            this.BtnReadcsv.Click += new System.EventHandler(this.BtnReadcsv_Click);
            // 
            // BtnDeleteDataFromDB
            // 
            this.BtnDeleteDataFromDB.Location = new System.Drawing.Point(584, 50);
            this.BtnDeleteDataFromDB.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDeleteDataFromDB.Name = "BtnDeleteDataFromDB";
            this.BtnDeleteDataFromDB.Size = new System.Drawing.Size(180, 46);
            this.BtnDeleteDataFromDB.TabIndex = 7;
            this.BtnDeleteDataFromDB.Text = "Delete DataFromDB";
            this.BtnDeleteDataFromDB.UseVisualStyleBackColor = true;
            this.BtnDeleteDataFromDB.Click += new System.EventHandler(this.BtnDeleteDataFromDB_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ID",
            "semesterNumber",
            "semesterName",
            "beginning",
            "ending",
            "type",
            "identifikation",
            "teacher",
            "room",
            "studyprogram"});
            this.comboBox1.Location = new System.Drawing.Point(993, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(990, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search for Data:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(993, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Open OR-Mapper Window";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(1147, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnDeleteDataFromDB);
            this.Controls.Add(this.BtnReadcsv);
            this.Controls.Add(this.BtnUpdateDatabase);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnUpdateDatabase;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnReadcsv;
        private System.Windows.Forms.Button BtnDeleteDataFromDB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button1;
    }
}

