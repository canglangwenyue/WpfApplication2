namespace StuSystem
{
    partial class Score
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Score));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.combSelect = new System.Windows.Forms.ToolStripComboBox();
            this.txtSelect = new System.Windows.Forms.ToolStripTextBox();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.gvwScoretList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwScoretList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.combSelect,
            this.txtSelect,
            this.btnSelect,
            this.toolStripSeparator3,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(832, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "查询条件：";
            // 
            // combSelect
            // 
            this.combSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSelect.Items.AddRange(new object[] {
            "学号",
            "班级"});
            this.combSelect.Name = "combSelect";
            this.combSelect.Size = new System.Drawing.Size(100, 25);
            // 
            // txtSelect
            // 
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(100, 25);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(49, 22);
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 22);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gvwScoretList
            // 
            this.gvwScoretList.AllowUserToAddRows = false;
            this.gvwScoretList.AllowUserToDeleteRows = false;
            this.gvwScoretList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwScoretList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.gvwScoretList.Location = new System.Drawing.Point(12, 38);
            this.gvwScoretList.Name = "gvwScoretList";
            this.gvwScoretList.RowHeadersVisible = false;
            this.gvwScoretList.RowTemplate.Height = 23;
            this.gvwScoretList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwScoretList.Size = new System.Drawing.Size(808, 193);
            this.gvwScoretList.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "学号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 100;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "班级";
            this.Column2.Name = "Column2";
            this.Column2.Width = 100;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "C#.NET";
            this.Column3.Name = "Column3";
            this.Column3.Width = 100;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "英语";
            this.Column4.Name = "Column4";
            this.Column4.Width = 100;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Java专业";
            this.Column5.Name = "Column5";
            this.Column5.Width = 100;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "XML拓展语言";
            this.Column6.Name = "Column6";
            this.Column6.Width = 100;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "数学";
            this.Column7.Name = "Column7";
            this.Column7.Width = 100;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "语文";
            this.Column8.Name = "Column8";
            this.Column8.Width = 100;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "网络组建";
            this.Column9.Name = "Column9";
            this.Column9.Width = 100;
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 280);
            this.Controls.Add(this.gvwScoretList);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Score";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "成绩查询";
            this.Load += new System.EventHandler(this.Score_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwScoretList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox combSelect;
        private System.Windows.Forms.ToolStripTextBox txtSelect;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.DataGridView gvwScoretList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}