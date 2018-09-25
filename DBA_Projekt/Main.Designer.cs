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
            this.btnUpdateDatabase = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReadcsv = new System.Windows.Forms.Button();
            this.BtnDeleteDataFromDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateDatabase
            // 
            this.btnUpdateDatabase.Location = new System.Drawing.Point(210, 50);
            this.btnUpdateDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateDatabase.Name = "btnUpdateDatabase";
            this.btnUpdateDatabase.Size = new System.Drawing.Size(188, 46);
            this.btnUpdateDatabase.TabIndex = 5;
            this.btnUpdateDatabase.Text = "UpdateDatabase";
            this.btnUpdateDatabase.UseVisualStyleBackColor = true;
            this.btnUpdateDatabase.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(22, 50);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 46);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 104);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1112, 304);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnReadcsv
            // 
            this.btnReadcsv.Location = new System.Drawing.Point(405, 51);
            this.btnReadcsv.Name = "btnReadcsv";
            this.btnReadcsv.Size = new System.Drawing.Size(163, 46);
            this.btnReadcsv.TabIndex = 6;
            this.btnReadcsv.Text = "Load csvToDB";
            this.btnReadcsv.UseVisualStyleBackColor = true;
            this.btnReadcsv.Click += new System.EventHandler(this.btnReadcsv_Click);
            // 
            // BtnDeleteDataFromDB
            // 
            this.BtnDeleteDataFromDB.Location = new System.Drawing.Point(575, 51);
            this.BtnDeleteDataFromDB.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDeleteDataFromDB.Name = "BtnDeleteDataFromDB";
            this.BtnDeleteDataFromDB.Size = new System.Drawing.Size(180, 46);
            this.BtnDeleteDataFromDB.TabIndex = 7;
            this.BtnDeleteDataFromDB.Text = "Delete DataFromDB";
            this.BtnDeleteDataFromDB.UseVisualStyleBackColor = true;
            this.BtnDeleteDataFromDB.Click += new System.EventHandler(this.BtnDeleteDataFromDB_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(1147, 459);
            this.Controls.Add(this.BtnDeleteDataFromDB);
            this.Controls.Add(this.btnReadcsv);
            this.Controls.Add(this.btnUpdateDatabase);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateDatabase;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReadcsv;
        private System.Windows.Forms.Button BtnDeleteDataFromDB;
    }
}

