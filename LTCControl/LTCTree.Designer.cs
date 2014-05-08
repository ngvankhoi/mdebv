namespace LTCControl
{
    partial class LTCTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.splFilter = new System.Windows.Forms.Splitter();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.treeData = new System.Windows.Forms.TreeView();
            this.pTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTitle
            // 
            this.pTitle.BackColor = System.Drawing.SystemColors.Control;
            this.pTitle.Controls.Add(this.lbTitle);
            this.pTitle.Controls.Add(this.splFilter);
            this.pTitle.Controls.Add(this.txtFilter);
            this.pTitle.Controls.Add(this.chkAll);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pTitle.Size = new System.Drawing.Size(481, 24);
            this.pTitle.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(19, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(378, 22);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "lbTitle";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splFilter
            // 
            this.splFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splFilter.Location = new System.Drawing.Point(397, 1);
            this.splFilter.Name = "splFilter";
            this.splFilter.Size = new System.Drawing.Size(3, 22);
            this.splFilter.TabIndex = 2;
            this.splFilter.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(400, 1);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(81, 21);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Text = "Tìm nhanh";
            this.txtFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFilter.Visible = false;
            // 
            // chkAll
            // 
            this.chkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAll.Location = new System.Drawing.Point(0, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(19, 22);
            this.chkAll.TabIndex = 3;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // treeData
            // 
            this.treeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeData.Location = new System.Drawing.Point(0, 24);
            this.treeData.Name = "treeData";
            this.treeData.Size = new System.Drawing.Size(481, 354);
            this.treeData.TabIndex = 3;
            this.treeData.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeData_AfterCheck);
            // 
            // LTCTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeData);
            this.Controls.Add(this.pTitle);
            this.Name = "LTCTree";
            this.Size = new System.Drawing.Size(481, 378);
            this.Load += new System.EventHandler(this.LTCTree_Load);
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTitle;
        public System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Splitter splFilter;
        private System.Windows.Forms.TextBox txtFilter;
        public System.Windows.Forms.TreeView treeData;
        private System.Windows.Forms.CheckBox chkAll;
    }
}
