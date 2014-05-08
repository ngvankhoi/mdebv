namespace SMSAsync
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbTimeClock = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTimeCounter = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.gbTimeSheet = new System.Windows.Forms.GroupBox();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.MaskedTextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.gbTimeClock.SuspendLayout();
            this.gbTimeSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTimeClock
            // 
            this.gbTimeClock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTimeClock.Controls.Add(this.btnStop);
            this.gbTimeClock.Controls.Add(this.btnStart);
            this.gbTimeClock.Controls.Add(this.lblTimeCounter);
            this.gbTimeClock.Controls.Add(this.lblTime);
            this.gbTimeClock.Location = new System.Drawing.Point(5, 9);
            this.gbTimeClock.Name = "gbTimeClock";
            this.gbTimeClock.Size = new System.Drawing.Size(623, 65);
            this.gbTimeClock.TabIndex = 1;
            this.gbTimeClock.TabStop = false;
            this.gbTimeClock.Text = "Khoảng thời gian thực hiện";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(265, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Kết thúc";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(185, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTimeCounter
            // 
            this.lblTimeCounter.AutoSize = true;
            this.lblTimeCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimeCounter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeCounter.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTimeCounter.Location = new System.Drawing.Point(61, 24);
            this.lblTimeCounter.Name = "lblTimeCounter";
            this.lblTimeCounter.Size = new System.Drawing.Size(118, 21);
            this.lblTimeCounter.TabIndex = 1;
            this.lblTimeCounter.Text = "000 00:00:00";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(4, 29);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(51, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Thời gian";
            // 
            // gbTimeSheet
            // 
            this.gbTimeSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTimeSheet.Controls.Add(this.dgvReport);
            this.gbTimeSheet.Controls.Add(this.btnPrintReport);
            this.gbTimeSheet.Controls.Add(this.btnReport);
            this.gbTimeSheet.Controls.Add(this.txtEndDate);
            this.gbTimeSheet.Controls.Add(this.lblEndDate);
            this.gbTimeSheet.Controls.Add(this.txtStartDate);
            this.gbTimeSheet.Controls.Add(this.lblStartDate);
            this.gbTimeSheet.Location = new System.Drawing.Point(5, 82);
            this.gbTimeSheet.Name = "gbTimeSheet";
            this.gbTimeSheet.Size = new System.Drawing.Size(623, 240);
            this.gbTimeSheet.TabIndex = 2;
            this.gbTimeSheet.TabStop = false;
            this.gbTimeSheet.Text = "Thống kê thời gian thực hiện";
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(7, 56);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(609, 178);
            this.dgvReport.TabIndex = 6;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(460, 20);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(75, 23);
            this.btnPrintReport.TabIndex = 5;
            this.btnPrintReport.Text = "In thống kê";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(380, 20);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Thống kê";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(274, 21);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 20);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(194, 25);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(74, 13);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "Ngày kết thúc";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(85, 21);
            this.txtStartDate.Mask = "00/00/0000";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 20);
            this.txtStartDate.TabIndex = 1;
            this.txtStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(7, 25);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(72, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.gbTimeSheet);
            this.Controls.Add(this.gbTimeClock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "SMS Async";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.gbTimeClock.ResumeLayout(false);
            this.gbTimeClock.PerformLayout();
            this.gbTimeSheet.ResumeLayout(false);
            this.gbTimeSheet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTimeClock;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTimeCounter;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox gbTimeSheet;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.MaskedTextBox txtStartDate;
        private System.Windows.Forms.Label lblStartDate;
    }
}

