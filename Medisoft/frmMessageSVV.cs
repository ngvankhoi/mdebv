using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmMessageSVV : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private int i_userid;
        private Label lbMessageSVV;
        private Button button1;
        string t;
        public frmMessageSVV(AccessData acc, int userid, string _t)
        {
            InitializeComponent();
            t = _t;
            m = acc; i_userid = userid;
        }

        private void mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmTaouser_Load(object sender, EventArgs e)
        {
            lbMessageSVV.Text = t;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void InitializeComponent()
        {
            this.lbMessageSVV = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMessageSVV
            // 
            this.lbMessageSVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessageSVV.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbMessageSVV.Location = new System.Drawing.Point(0, 9);
            this.lbMessageSVV.Name = "lbMessageSVV";
            this.lbMessageSVV.Size = new System.Drawing.Size(370, 78);
            this.lbMessageSVV.TabIndex = 0;
            this.lbMessageSVV.Text = "label1";
            this.lbMessageSVV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMessageSVV.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMessageSVV
            // 
            this.ClientSize = new System.Drawing.Size(370, 125);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbMessageSVV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageSVV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMessageSLT_Load);
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessageSLT_Load(object sender, EventArgs e)
        {
            lbMessageSVV.Text = t;
        }
    }
}