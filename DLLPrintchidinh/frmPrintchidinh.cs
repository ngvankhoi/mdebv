using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;
using LibMedi;

namespace DLLPrintchidinh
{
	public class frmPrintchidinh : System.Windows.Forms.Form
	{
		private LibMedi.AccessData m_m;
		string m_sql="";
		//linh 11/09/2006
		string s_ngay="",s_mmyy="",s_id="",s_ngaycd="";
		private DataSet m_ds=new DataSet();
        private DataRow nr;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMabn;
		private System.Windows.Forms.TextBox txtHoten;
		private System.Windows.Forms.TextBox txtNgaysinh;
		private System.Windows.Forms.TextBox txtGioitinh;
		private System.Windows.Forms.ComboBox cbNgayvv;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.ComboBox cbPhieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem;
        private Button butIn;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem writeXMLToolStripMenuItem;
        private Button butInAll;
        private IContainer components;

		
		public frmPrintchidinh()
		{
			InitializeComponent();
			m_m =  new LibMedi.AccessData();
			if(s_ngay.Trim()=="")s_ngay=DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString();
			s_mmyy=s_ngay.Substring(3,2)+s_ngay.Substring(8,2);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v_userid">dlogin.id.ToString()</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintchidinh));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butInAll = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.writeXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.butXem = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPhieu = new System.Windows.Forms.ComboBox();
            this.cbNgayvv = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGioitinh = new System.Windows.Forms.TextBox();
            this.txtNgaysinh = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtMabn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 50);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(792, 523);
            this.crystalReportViewer1.TabIndex = 85;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butInAll);
            this.panel1.Controls.Add(this.rd3);
            this.panel1.Controls.Add(this.rd2);
            this.panel1.Controls.Add(this.rd1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.butXem);
            this.panel1.Controls.Add(this.butIn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbPhieu);
            this.panel1.Controls.Add(this.cbNgayvv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtGioitinh);
            this.panel1.Controls.Add(this.txtNgaysinh);
            this.panel1.Controls.Add(this.txtHoten);
            this.panel1.Controls.Add(this.txtMabn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 50);
            this.panel1.TabIndex = 86;
            // 
            // butInAll
            // 
            this.butInAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butInAll.ContextMenuStrip = this.contextMenuStrip2;
            this.butInAll.Image = ((System.Drawing.Image)(resources.GetObject("butInAll.Image")));
            this.butInAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInAll.Location = new System.Drawing.Point(538, 25);
            this.butInAll.Name = "butInAll";
            this.butInAll.Size = new System.Drawing.Size(52, 24);
            this.butInAll.TabIndex = 19;
            this.butInAll.Text = "&In all";
            this.butInAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butInAll.UseVisualStyleBackColor = true;
            this.butInAll.Click += new System.EventHandler(this.butInAll_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeXMLToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(131, 26);
            // 
            // writeXMLToolStripMenuItem
            // 
            this.writeXMLToolStripMenuItem.Name = "writeXMLToolStripMenuItem";
            this.writeXMLToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.writeXMLToolStripMenuItem.Text = "WriteXML";
            this.writeXMLToolStripMenuItem.Click += new System.EventHandler(this.writeXMLToolStripMenuItem_Click);
            // 
            // rd3
            // 
            this.rd3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd3.Checked = true;
            this.rd3.Location = new System.Drawing.Point(716, 31);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(72, 15);
            this.rd3.TabIndex = 8;
            this.rd3.TabStop = true;
            this.rd3.Text = "Tất cả";
            this.rd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // rd2
            // 
            this.rd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd2.Location = new System.Drawing.Point(716, 15);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(72, 15);
            this.rd2.TabIndex = 7;
            this.rd2.Text = "Chưa làm";
            this.rd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // rd1
            // 
            this.rd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rd1.Location = new System.Drawing.Point(716, -1);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(64, 16);
            this.rd1.TabIndex = 6;
            this.rd1.Text = "Đã làm";
            this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(642, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "   &Kết thúc";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butXem.ForeColor = System.Drawing.Color.Black;
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(590, 25);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(52, 24);
            this.butXem.TabIndex = 9;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.ContextMenuStrip = this.contextMenuStrip2;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(486, 25);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(52, 24);
            this.butIn.TabIndex = 18;
            this.butIn.Text = "  &In";
            this.butIn.UseVisualStyleBackColor = true;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(184, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "Phiếu:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPhieu
            // 
            this.cbPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPhieu.BackColor = System.Drawing.Color.White;
            this.cbPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhieu.Location = new System.Drawing.Point(248, 24);
            this.cbPhieu.Name = "cbPhieu";
            this.cbPhieu.Size = new System.Drawing.Size(234, 21);
            this.cbPhieu.TabIndex = 5;
            this.cbPhieu.SelectionChangeCommitted += new System.EventHandler(this.cbPhieu_SelectionChangeCommitted);
            this.cbPhieu.SelectedIndexChanged += new System.EventHandler(this.cbPhieu_SelectedIndexChanged);
            this.cbPhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // cbNgayvv
            // 
            this.cbNgayvv.BackColor = System.Drawing.Color.White;
            this.cbNgayvv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNgayvv.Location = new System.Drawing.Point(58, 25);
            this.cbNgayvv.Name = "cbNgayvv";
            this.cbNgayvv.Size = new System.Drawing.Size(110, 21);
            this.cbNgayvv.TabIndex = 4;
            this.cbNgayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-11, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày VV:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGioitinh
            // 
            this.txtGioitinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGioitinh.BackColor = System.Drawing.Color.White;
            this.txtGioitinh.Enabled = false;
            this.txtGioitinh.Location = new System.Drawing.Point(653, 4);
            this.txtGioitinh.Name = "txtGioitinh";
            this.txtGioitinh.Size = new System.Drawing.Size(53, 20);
            this.txtGioitinh.TabIndex = 3;
            this.txtGioitinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // txtNgaysinh
            // 
            this.txtNgaysinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgaysinh.BackColor = System.Drawing.Color.White;
            this.txtNgaysinh.Enabled = false;
            this.txtNgaysinh.Location = new System.Drawing.Point(538, 4);
            this.txtNgaysinh.Name = "txtNgaysinh";
            this.txtNgaysinh.Size = new System.Drawing.Size(63, 20);
            this.txtNgaysinh.TabIndex = 2;
            this.txtNgaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // txtHoten
            // 
            this.txtHoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoten.BackColor = System.Drawing.Color.White;
            this.txtHoten.Enabled = false;
            this.txtHoten.Location = new System.Drawing.Point(248, 4);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(234, 20);
            this.txtHoten.TabIndex = 1;
            this.txtHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // txtMabn
            // 
            this.txtMabn.BackColor = System.Drawing.Color.White;
            this.txtMabn.Enabled = false;
            this.txtMabn.Location = new System.Drawing.Point(58, 4);
            this.txtMabn.MaxLength = 8;
            this.txtMabn.Name = "txtMabn";
            this.txtMabn.Size = new System.Drawing.Size(110, 20);
            this.txtMabn.TabIndex = 0;
            this.txtMabn.Validated += new System.EventHandler(this.txtMabn_Validated);
            this.txtMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(596, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giới tính:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(478, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày sinh:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(184, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ và tên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(240, 26);
            // 
            // khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem
            // 
            this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem.Name = "khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem";
            this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem.Text = "Khai báo thông số phiếu chỉ định";
            this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem.Click += new System.EventHandler(this.khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem_Click);
            // 
            // frmPrintchidinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrintchidinh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintchidinh_KeyDown);
            this.Load += new System.EventHandler(this.frmPrintchidinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private string f_GetNgay(string v_ngay)
		{
			try
			{
				return "Ngày " + v_ngay.Substring(0,2) + " tháng " + v_ngay.Substring(3,2) + " năm " + v_ngay.Substring(6);
			}
			catch
			{
				return "";
			}
		}
        //private void f_Load_HC()
        //{
        //    try
        //    {
        //        string amabn="";
        //        amabn=txtMabn.Text.Trim();
        //        if(amabn.Length<8)
        //        {
        //            if(amabn.Length>=3)
        //            {
        //                amabn=amabn.Substring(0,2)+amabn.Substring(2).PadLeft(6,'0');
        //            }
        //            else
        //            if(amabn.Length>=1)
        //            {
        //                amabn=DateTime.Now.Year.ToString().Substring(2)+amabn.PadLeft(6,'0');
        //            }
        //        }
        //        txtMabn.Text="";
        //        txtHoten.Text="";
        //        txtNgaysinh.Text="";
        //        txtGioitinh.Text="";

        //        foreach(DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from medibv.btdbn a, medibv.btdtt b, medibv.btdquan c, medibv.btdpxa d, medibv.dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and mabn='"+amabn+"'").Tables[0].Rows)
        //        {
        //            txtMabn.Text=r["mabn"].ToString();
        //            txtHoten.Text=r["hoten"].ToString();
        //            txtNgaysinh.Text=r["ngaysinh"].ToString();
        //            txtGioitinh.Text=r["phai"].ToString();
        //            break;
        //        }
        //        cbNgayvv.DisplayMember="NGAY";
        //        cbNgayvv.ValueMember="MAQL";
        //        //linh 11/09/2006
        //        //cbNgayvv.DataSource=m_m.get_data("select to_char(max(ngay),'dd/mm/yyyy hh24:mi') ngay, maql from (select mabn, maql, ngay from benhandt where mabn='"+amabn+"' union select mabn,maql,ngay from tiepdon where mabn='"+amabn+"') group by maql order by to_date(ngay,'dd/mm/yyyy hh24:mi') desc").Tables[0];
        //        //cbNgayvv.DataSource=m_m.get_data("select to_char(max(ngay),'dd/mm/yyyy hh24:mi') ngay, maql from (select mabn, maql, ngay from (select mabn, maql, ngay from benhandt union all select mabn, maql, ngay from "+m_m.user+s_mmyy+".benhandt union all select mabn, maql, ngay from "+m_m.user+m_m.Mmyy_truoc(s_mmyy)+".benhandt) where mabn='"+amabn+"' union select mabn,maql,ngay from "+m_m.user+s_mmyy+".tiepdon where mabn='"+amabn+"') group by maql order by to_date(ngay,'dd/mm/yyyy hh24:mi') desc").Tables[0];
        //        string sql = "select to_char(max(a.ngay),'dd/mm/yyyy')||' '||a.loai ngay, a.maql from (";
        //        sql += "select 'nt' loai,mabn, maql, ngay from medibv.benhandt where mabn='" + amabn + "' ";
        //        sql += " union all ";
        //        sql += "select 'ngtr' loai,mabn, maql, ngay from medibv.benhanngtr where mabn='" + amabn + "' ";
        //        sql += " union all ";
        //        sql += "select 'pk' loai,mabn, maql, ngay from " + m_m.user + s_mmyy + ".benhanpk where mabn='" + amabn + "' ";
        //        sql += " union all ";
        //        sql += "select 'cc' loai,mabn, maql, ngay from " + m_m.user + s_mmyy + ".benhancc where mabn='" + amabn + "' ";
        //        sql += " union all ";
        //        sql += "select 'td' loai,mabn,maql,ngay from " + m_m.user + s_mmyy + ".tiepdon where mabn='" + amabn + "') a ";
        //        sql += " group by a.maql,to_char(a.ngay,'yyyy/mm/dd'),a.loai order by to_char(a.ngay,'yyyy/mm/dd') desc";
        //        cbNgayvv.DataSource=m_m.get_data(sql).Tables[0];
        //        //end linh
        //    }
        //    catch
        //    {
        //    }
        //}
		private void f_Load_HC(string _mmyy)
		{
			try
			{
				string amabn="";
				amabn=txtMabn.Text.Trim();
				if(amabn.Length<8)
				{
					if(amabn.Length>=3)
					{
						amabn=amabn.Substring(0,2)+amabn.Substring(2).PadLeft(6,'0');
					}
					else
						if(amabn.Length>=1)
					{
						amabn=DateTime.Now.Year.ToString().Substring(2)+amabn.PadLeft(6,'0');
					}
				}
				txtMabn.Text="";
				txtHoten.Text="";
				txtNgaysinh.Text="";
				txtGioitinh.Text="";

                foreach (DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from medibv.btdbn a, medibv.btdtt b, medibv.btdquan c, medibv.btdpxa d, medibv.dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and mabn='" + amabn + "'").Tables[0].Rows)
                {
                    txtMabn.Text = r["mabn"].ToString();
                    txtHoten.Text = r["hoten"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    txtGioitinh.Text = r["phai"].ToString();
                    break;
                }
                  
				cbNgayvv.DisplayMember="NGAY";
				cbNgayvv.ValueMember="MAQL";
                string sql = "select to_char(max(a.ngay),'dd/mm/yyyy')||' '||a.loai ngay, a.maql from (";
                sql += "select 'nt' loai,mabn, maql, ngay from medibv.benhandt where mabn='" + amabn + "' ";
                sql += " union all ";
                sql += "select 'ngtr' loai,mabn, maql, ngay from medibv.benhanngtr where mabn='" + amabn + "' ";
                sql += " union all ";
                sql += "select 'pk' loai,mabn, maql, ngay from " + m_m.user + s_mmyy + ".benhanpk where mabn='" + amabn + "' ";
                sql += " union all ";
                sql += "select 'cc' loai,mabn, maql, ngay from " + m_m.user + s_mmyy + ".benhancc where mabn='" + amabn + "' ";
                sql += " union all ";
                sql += "select 'td' loai,mabn,maql,ngay from " + m_m.user + s_mmyy + ".tiepdon where mabn='" + amabn + "') a ";
                sql += " group by a.maql,to_char(a.ngay,'yyyy/mm/dd'),a.loai order by to_char(a.ngay,'yyyy/mm/dd') desc";
                cbNgayvv.DataSource = m_m.get_data(sql).Tables[0];
				
			}
			catch
			{
			}
		}
        //public void f_Print_Chidinh(bool v_dir, string v_mabn, string v_maql, string v_done)
        //{
        //    //			if(!v_dir)
        //    //			{
        //    //				this.TopMost=true;
        //    //				this.Show();
        //    //			}
        //    try
        //    {
        //        this.Text = "In phiếu chỉ định dịch vụ";
        //        txtMabn.Text = v_mabn;
        //        f_Load_HC();
        //        try
        //        {
        //            cbNgayvv.SelectedValue = v_maql;
        //        }
        //        catch
        //        {
        //        }
        //        f_Load_Chidinh(v_dir);
        //        if (v_dir)
        //        {
        //            for (int i = 0; i < cbPhieu.Items.Count; i++)
        //            {
        //                cbPhieu.SelectedIndex = i;
        //                f_Preview_Chidinh(v_dir, s_mmyy);
        //            }
        //        }
        //        else
        //        {
        //            f_Preview_Chidinh(v_dir, s_mmyy);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, "Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
		public void f_Print_Chidinh(bool v_dir, string v_mabn, string v_maql, string v_done,string v_ngay,string v_id)
		{
			string _mmyy="";
            if (v_ngay == "") _mmyy = s_mmyy;
            else _mmyy = v_ngay.Substring(3, 2).PadLeft(2, '0') + v_ngay.Substring(8, 2);
            s_ngaycd = v_ngay.Substring(0, 10);
            s_id = v_id;
            string s_err = "";
			try
			{
                this.Text = "In phiếu chỉ định dịch vụ - maql: " + v_maql + " - id: " + v_id;
				txtMabn.Text=v_mabn;
                s_err = "f_Load_HC";
				f_Load_HC(_mmyy);
				try
				{
					cbNgayvv.SelectedValue=v_maql;
				}
				catch
				{
				}
                s_err = "f_Load_Chidinh";
				f_Load_Chidinh(v_dir,_mmyy);
                s_err = "f_Preview_Chidinh";
				if(v_dir)
				{
					for(int i=0;i<cbPhieu.Items.Count;i++)
					{
						cbPhieu.SelectedIndex=i;
						f_Preview_Chidinh(v_dir,_mmyy);
					}
				}
				else
				{
					f_Preview_Chidinh(v_dir,_mmyy);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString()+"--"+s_err,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void f_Load_Chidinh(bool v_dir)
		{
			try
			{
				string amaql="",auser="";
				auser=m_m.user;
				try
				{
					amaql=cbNgayvv.SelectedValue.ToString();
				}
				catch
				{
				}
				this.Text="In phiếu chỉ định dịch vụ";
				m_ds.Dispose();
				m_ds=new DataSet();
				//m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,
				m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,"+
                    "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay, to_char(a.tinhtrang) tinhtrang, "+
                    "to_char(a.mavp) mavp, b.ten tenvp,trim(c.id) id,lower(c.report) report,trim(b.ten) val,"+
                    "a.mabs, a.stt from "+auser+s_mmyy+".v_chidinh a, "+auser.Trim()+".v_giavp b,"+auser.Trim()+
                    ".cd_thongsophieucd c where a.mavp=b.id and a.mavp=c.mavp(+)";
				m_sql+=" and a.mabn='"+txtMabn.Text.Trim()+"'";
				m_sql+=" and to_char(a.maql)='"+amaql+"' and soluong>0";
				if(rd1.Checked)
				{
					m_sql+=" and to_char(a.done)='1'";
				}
				else
				if(rd2.Checked)
				{
					m_sql+=" and to_char(a.done)<>'1'";
				}
                m_sql += " order by lower(c.report)";
				m_ds = m_m.get_data(m_sql);
				DataSet ads1 = new DataSet();
				ads1.Tables.Add("Table");
				ads1.Tables[0].Columns.Add("report");
				ads1.Tables[0].Columns.Add("ngay");
				foreach(DataRow r in m_ds.Tables[0].Rows)
				{
					if(ads1.Tables[0].Select("report='"+r["report"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString()+"'").Length<=0)
					{
						ads1.Tables[0].Rows.Add(new string[] {r["report"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString(),r["report"].ToString()});
					}
				}
				if(ads1.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(this,"Không tìm thấy thông tin chỉ định <maql:"+cbNgayvv.SelectedValue.ToString()+">","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    m_m.upd_error(m_sql, "xxxxx", "xxxxx");
				}
				cbPhieu.DisplayMember="ngay";
				cbPhieu.ValueMember="report";
				cbPhieu.DataSource=ads1.Tables[0];
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			if(m_ds.Tables[0].Rows.Count==0) butIn.Visible=false;
		}
		private void f_Load_Chidinh(bool v_dir,string _mmyy)
		{
			if(_mmyy=="")_mmyy=s_mmyy;
			try
			{
				string amaql="",auser="";
				auser=m_m.user;
				try
				{
					amaql=cbNgayvv.SelectedValue.ToString();
				}
				catch
				{
				}
                //this.Text="In phiếu chỉ định dịch vụ";
				m_ds.Dispose();
				m_ds=new DataSet();
				//m_sql="select distinct a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,
                m_sql = "";
                m_sql = "select distinct a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay, to_char(a.tinhtrang) tinhtrang, to_char(a.mavp) mavp, b.ten tenvp,trim(c.id) id,lower(c.report) report,trim(b.ten) val,a.mabs, a.stt from " + auser + _mmyy + ".v_chidinh a inner join " + auser.Trim() + ".v_giavp b on a.mavp=b.id left join " + auser.Trim() + ".cd_thongsophieucd c on a.mavp=to_number(c.mavp) where 1=1 ";
				m_sql+=" and a.mabn='"+txtMabn.Text.Trim()+"'";
				m_sql+=" and to_char(a.maql)='"+amaql+"' and soluong>0";
				if(rd1.Checked)
				{
					m_sql+=" and to_char(a.done)='1'";
				}
				else
					if(rd2.Checked)
				{
					m_sql+=" and to_char(a.done)<>'1'";
                }
                if (s_ngaycd != "") m_sql += " and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngaycd+"' ";
                if (s_id != "") m_sql += "and a.id in ("+s_id .Trim().Trim(',')+") ";
                m_sql += " order by lower(c.report)";
				m_ds = m_m.get_data(m_sql);
				DataSet ads1 = new DataSet();
				ads1.Tables.Add("Table");
				ads1.Tables[0].Columns.Add("report");
				ads1.Tables[0].Columns.Add("ngay");
				foreach(DataRow r in m_ds.Tables[0].Rows)
				{
                    //if (ads1.Tables[0].Select("report='" + r["report"].ToString() + "?" + r["ngay"].ToString() + "?" + r["tinhtrang"].ToString() + "?" + r["maql"].ToString() + "?" + r["idkhoa"].ToString() + "'").Length <= 0)
					if(ads1.Tables[0].Select("report='"+r["report"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString()+"'").Length<=0)
					{
						//ads1.Tables[0].Rows.Add(new string[] {r["report"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString(),r["ngay"].ToString()+" : "+r["report"].ToString()});
                        ads1.Tables[0].Rows.Add(new string[] {r["report"].ToString()+"?" +r["tinhtrang"].ToString() + "?" + r["maql"].ToString() + "?" + r["idkhoa"].ToString(), r["report"].ToString() });
					}
				}
				if(ads1.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(this,"Không tìm thấy thông tin chỉ định <maql:"+cbNgayvv.SelectedValue.ToString()+">\n","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    m_m.upd_error(m_sql, "xxxxx", "xxxxx");
				}
				cbPhieu.DisplayMember="ngay";
				cbPhieu.ValueMember="report";
				cbPhieu.DataSource=ads1.Tables[0];
			}
			catch
			{
			}
			if(m_ds.Tables[0].Rows.Count==0)butIn.Visible=false;
		}
		private void f_Preview_Chidinh(bool v_dir,string _mmyy)
		{
			if(_mmyy=="")_mmyy=s_mmyy;
			try
			{
                //this.Text="In phiếu chỉ định dịch vụ";
				string asyt="",abv="",angayin="",anguoiin="",areport="";
                string s_chandoan = "", s_maicd = "";
				string amabn="",ahoten="",angaysinh="",aphai="",adiachi="",akhoa="",achandoan="",aicd="",atinhtrang="",aphonggiuong="",athekcb="",abacsi="",aghichu="",atrieuchung="",a_idkhoa="";
				asyt = m_m.Syte;
				abv = m_m.Tenbv;
				
				angayin="";
				anguoiin="";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
                a_idkhoa = m_ds.Tables[0].Rows[0]["idkhoa"].ToString();
                foreach (DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from medibv.btdbn a, medibv.btdtt b, medibv.btdquan c, medibv.btdpxa d, medibv.dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and a.mabn='" + amabn + "'").Tables[0].Rows)
				{
					amabn=r["mabn"].ToString();
					ahoten=r["hoten"].ToString();
					angaysinh=r["ngaysinh"].ToString();
					aphai=r["phai"].ToString();
					adiachi=r["sonha"].ToString().Trim();
					adiachi+=" "+r["thon"].ToString().Trim();
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenpxa"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenquan"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tentt"].ToString().Trim().Replace("Không xác định","");
					break;
				}
				
				areport=cbPhieu.SelectedValue.ToString();
				string ang="",att="",amaql="",aidkhoa="";
                //ang=areport.Split('?')[1];
				att=areport.Split('?')[1];
				amaql=areport.Split('?')[2];
				aidkhoa=areport.Split('?')[3];
				areport=areport.Split('?')[0];
				areport=areport.ToLower();
				string m_mabs="";
				try
				{
                    string sql = " select a.sothe from " + m_m.user + _mmyy + ".bhyt a where to_char(a.maql)='" + amaql + "' and a.mabn='" + amabn + "' and sudung=1";
                    sql += "union all ";
                    sql += " select a.sothe from " + m_m.user + ".bhyt a where to_char(a.maql)='" + amaql + "' and a.mabn='" + amabn + "' and sudung=1";
                    foreach(DataRow r in m_m.get_data(sql).Tables[0].Rows)
					{
						athekcb+=r["sothe"].ToString();
						break;
					}
				}
				catch{}
				//khoa
				try
				{
                    string sql = "select nvl(d.giuong,a.giuong) giuong, a.maicd,a.chandoan, b.tenkp, c.hoten from medibv.nhapkhoa a, medibv.btdkp_bv b, medibv.dmbs c,(select idkhoa,giuong,mabs from " + m_m.user + _mmyy + ".d_dausinhton where id=(select max(id) from " + m_m.user + _mmyy + ".d_dausinhton where idkhoa=" + aidkhoa + ")) d where a.makp=b.makp(+) and a.id=d.idkhoa(+)and d.mabs=c.ma(+) and to_char(a.maql)='" + amaql + "' and to_char(a.id)='" + aidkhoa + "' and a.mabn='" + amabn + "'";
                    foreach (DataRow r in m_m.get_data(sql).Tables[0].Rows)
					{
						akhoa=r["tenkp"].ToString();
						abacsi=r["hoten"].ToString();
						aphonggiuong=r["giuong"].ToString();
						aicd=r["maicd"].ToString();                        
						achandoan=r["chandoan"].ToString();
                        s_chandoan = (s_chandoan.IndexOf(achandoan) < 0) ? r["chandoan"].ToString() : "";
                        s_maicd = (s_maicd.IndexOf(aicd) < 0) ? r["maicd"].ToString() : "";
						break;
					}
				}
				catch{}

				if(akhoa=="")
				{
					try
					{
                        string sql = "select b.tenkp, c.hoten, a.maicd,a.chandoan,d.ten trieuchung,e.lydo from (";
                        sql += " select mabn,maql,makp,mabs,maicd,chandoan from medibv.nhapkhoa where to_char(maql)='" + amaql + "' and mabn='" + amabn + "' and id="+a_idkhoa;
                        sql += "union all ";
                        sql += " select mabn,maql,makp,mabs,maicd,chandoan from medibv.benhanngtr where to_char(maql)='" + amaql + "' and mabn='" + amabn + "' ";
                        sql += "union all ";
                        sql += "select mabn,maql,makp,mabs,maicd,chandoan from " + m_m.user + _mmyy + ".benhanpk where to_char(maql)='" + amaql + "' and mabn='" + amabn + "'";
                        sql += "union all ";
                        sql += "select mabn,maql,makp,mabs,maicd,chandoan from " + m_m.user + _mmyy + ".benhancc where to_char(maql)='" + amaql + "' and mabn='" + amabn + "'";
                        sql += ") a, medibv.btdkp_bv b, medibv.dmbs c," + m_m.user + _mmyy + ".trieuchung d," + m_m.user + _mmyy + ".lydokham e where a.makp=b.makp(+) and a.mabs=c.ma(+) and a.maql=d.maql(+) and a.maql=e.maql(+) ";
						foreach(DataRow r in m_m.get_data(sql).Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							abacsi=r["hoten"].ToString();
							aicd=r["maicd"].ToString();
							achandoan=r["chandoan"].ToString();
                            atrieuchung = r["trieuchung"].ToString();
                            aghichu = r["lydo"].ToString();
                            s_chandoan = (s_chandoan.IndexOf(achandoan) < 0) ? r["chandoan"].ToString() : "";
                            s_maicd = (s_maicd.IndexOf(aicd) < 0) ? r["maicd"].ToString() : "";
							break;
						}
					}
					catch{}
				}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp from "+m_m.user+_mmyy+".tiepdon a, medibv.btdkp_bv b where a.makp=b.makp(+) and to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							break;
						}
					}
					catch
					{
					}
				}
				try
				{
                    string sql = "select distinct a.chandoan,a.ghichu,a.mabs, a.makp, b.tenkp from " + m_m.user + _mmyy + ".v_chidinh a," + m_m.user + ".btdkp_bv b where a.makp=b.makp and to_char(a.maql)='" + amaql + "' and a.mabn='" + amabn + "' and (a.mabs is not null or a.chandoan is not null)";
                    if(s_id!="") sql += " and id in ("+s_id.Trim().Trim(',')+") ";
                    string tmp_khoa = "", tmp_makp = "";
                    foreach(DataRow r in m_m.get_data(sql).Tables[0].Rows)
					{
						if(r["mabs"].ToString().Trim()!="")m_mabs=r["mabs"].ToString().Trim();
						if(r["chandoan"].ToString().Trim()!="")achandoan=r["chandoan"].ToString();
                        s_chandoan += (s_chandoan.IndexOf(achandoan) < 0) ? r["chandoan"].ToString() : "";
                        aghichu += "," + r["ghichu"].ToString();
                        if (tmp_khoa.IndexOf(r["tenkp"].ToString()) < 0) tmp_khoa += r["tenkp"].ToString() + ", ";
                        if (tmp_makp.IndexOf(r["makp"].ToString()) < 0) tmp_makp += r["makp"].ToString() + ", ";
						if(m_mabs!="" && achandoan!="")break;
					}
                    if (tmp_khoa == "") tmp_khoa = akhoa;
                    else
                    {
                        tmp_khoa = tmp_khoa.Trim().Trim(',');
                        tmp_makp = tmp_makp.Trim().Trim(',');
                    }
                    akhoa = tmp_khoa;
				}
				catch
                { }
                string s_cdkemtheo = m_m.f_get_cdkemtheo(s_ngay, decimal.Parse(amaql), 4);
                //if (s_cdkemtheo.Trim().Trim(',') != "")
                //{
                //    foreach (DataRow dr in dstmp.Tables[0].Rows)
                //    {
                //        dr["chandoan"] += ((dr["chandoan"].ToString().Trim() == "") ? "" : ", ") + s_cdkemtheo;
                //    }
                //}
				bool chuky=false;
				DataRow r2=null;
				DataSet ads = new DataSet();
				ads=m_m.get_data("select null id,null report,null mavp,null val,null image,null as trieuchung,null as benhkemtheo, to_number('0') as stt from dual").Clone();
                ads.Clear();
                //foreach (DataRow r in m_ds.Tables[0].Select("report='" + areport + "' and ngay='" + ang + "' and tinhtrang='" + att + "' and idkhoa='" + aidkhoa + "' and maql=" + amaql))                
				foreach(DataRow r in m_ds.Tables[0].Select("tinhtrang='"+att+"' and idkhoa='"+aidkhoa+"' and maql="+amaql+" and report='"+areport+"'"))                
				{
					DataRow nr=ads.Tables[0].NewRow();
					nr["id"]=r["id"];
					nr["report"]=r["report"];
					nr["mavp"]=r["mavp"];
					nr["val"]=r["val"];
                    nr["stt"] = r["stt"].ToString() == "" ? "0" : r["stt"].ToString();
					try
					{
						if(m_mabs!="")
						{
							if(!chuky)
							{
								r2= m_m.get_data("select null image,hoten from medibv.dmbs where ma='"+m_mabs+"'").Tables[0].Rows[0];
								abacsi=r2["hoten"].ToString();
								chuky=true;
							}
							nr["image"]=r2["image"];
						}
					}
					catch
                    { }
                    nr["trieuchung"] = atrieuchung;
                    nr["benhkemtheo"] = s_cdkemtheo;
					ads.Tables[0].Rows.Add(nr);
					ads.AcceptChanges();
				}
                if (areport.Trim().Replace(".rpt", "") == "") areport = "cd_clschung.rpt";
                if (!System.IO.File.Exists("..\\..\\..\\report\\" + areport.Replace(".rpt", "") + ".rpt"))
				{
                    if (areport == "") MessageBox.Show("Chưa khai báo các thông số report với các CLS này " + areport);
                    else MessageBox.Show("Không tìm thấy file: "+areport);
				}
                string s_err = "", s_err1 = "";
				try
				{
                    if (System.IO.Directory.Exists("..\\..\\xml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                    ads.WriteXml("..\\..\\dataxml\\rpt_chidinh_mau.xml", XmlWriteMode.WriteSchema);
					ReportDocument cMain=new ReportDocument();
                    s_err1 = "Không tìm thấy file " + areport.Replace(".rpt", "") + ".rpt";
                    cMain.Load("..\\..\\..\\report\\" + areport.Replace(".rpt", "") + ".rpt");//, OpenReportMethod.OpenReportByDefault .OpenReportByTempCopy);
					cMain.SetDataSource(ads);
                    s_err = "v_syt"; s_err1 = "";
                    cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'"; s_err = "v_bv";
                    cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'"; s_err = "v_ngayin";
                    cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'"; s_err = "v_nguoiin";
                    cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'"; s_err = "v_mabn";
                    cMain.DataDefinition.FormulaFields["v_mabn"].Text = "'" + amabn + "'"; s_err = "v_hoten";
                    cMain.DataDefinition.FormulaFields["v_hoten"].Text = "'" + ahoten + "'"; s_err = "v_ngaysinh";
                    cMain.DataDefinition.FormulaFields["v_ngaysinh"].Text = "'" + angaysinh + "'"; s_err = "v_phai";
                    cMain.DataDefinition.FormulaFields["v_phai"].Text = "'" + aphai + "'"; s_err = "v_diachi";
                    cMain.DataDefinition.FormulaFields["v_diachi"].Text = "'" + adiachi + "'"; s_err = "v_khoa";
                    cMain.DataDefinition.FormulaFields["v_khoa"].Text = "'" + akhoa + "'"; s_err = "v_chandoan";
                    cMain.DataDefinition.FormulaFields["v_chandoan"].Text = "'" + s_chandoan + "'"; s_err = "v_ghichu";
                    cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + atrieuchung + "^" + aghichu + "'"; s_err = "v_icd";
                    cMain.DataDefinition.FormulaFields["v_icd"].Text = "'" + s_maicd + "'"; s_err = "v_thekcb";
                    cMain.DataDefinition.FormulaFields["v_thekcb"].Text = "'" + athekcb + "'"; s_err = "v_phonggiuong";
                    cMain.DataDefinition.FormulaFields["v_phonggiuong"].Text = "'" + aphonggiuong + "'"; s_err = "v_tinhtrang";
                    cMain.DataDefinition.FormulaFields["v_tinhtrang"].Text = "'" + atinhtrang + "'"; s_err = "v_bacsi";
                    cMain.DataDefinition.FormulaFields["v_bacsi"].Text = "'" + abacsi + "'"; s_err = "";
                    try
                    {
                        cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    }
                    catch { }
					this.Text+="("+areport.Replace(".rpt","")+".rpt"+")";
					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
						this.ShowDialog();
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
				}
				catch(Exception ex)
				{
					//MessageBox.Show("Chưa khai báo thông số chỉ định cho những CLS này \n"+ex.ToString());
                    if (areport == "") MessageBox.Show("Chưa khai báo các thông số report với các CLS này " + areport);
                    else if (s_err1 != "")
                        MessageBox.Show("Không tìm thấy file: " + areport);
                    else if (s_err != "")
                        MessageBox.Show("Chưa khai báo fomular: " + s_err);
                    else
                        MessageBox.Show(ex.ToString());
                    if (!v_dir) this.Show();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
        //public void f_Print_VPKhoa(bool v_dir, string v_mabn, string v_maql, string v_done)
        //{
        //    if(!v_dir)
        //    {
        //        this.TopMost=true;
        //        this.Show();
        //    }
        //    try
        //    {
        //        this.Text="In phiếu chỉ định dịch vụ";
        //        txtMabn.Text=v_mabn;
        //        f_Load_HC();
        //        try
        //        {
        //            cbNgayvv.SelectedValue=v_maql;
        //        }
        //        catch
        //        {
        //        }
        //        f_Load_VPKhoa(v_dir);
        //        if(v_dir)
        //        {
        //            for(int i=0;i<cbPhieu.Items.Count;i++)
        //            {
        //                cbPhieu.SelectedIndex=i;
        //                f_Preview_VPKhoa(v_dir);
        //            }
        //        }
        //        else
        //        {
        //            f_Preview_VPKhoa(v_dir);
        //        }
        //    }
        //    catch//(Exception ex)
        //    {
        //        //MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //    }
        //}
        //private void f_Load_VPKhoa(bool v_dir)
        //{
        //    try
        //    {
        //        string amaql="",auser="";
        //        auser=m_m.user;
        //        try
        //        {
        //            amaql=cbNgayvv.SelectedValue.ToString();
        //        }
        //        catch
        //        {
        //        }
        //        this.Text="In phiếu chỉ định dịch vụ";
        //        m_sql="select a.mabn, to_char(a.maql) maql, to_char(a.idkhoa) idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay, 0 tinhtrang, to_char(a.mavp) mavp, sum(nvl(a.soluong,0)) soluong, b.ten tenvp from v_vpkhoa a, "+auser.Trim()+".v_giavp b where a.mavp=b.id";
        //        m_sql+=" and a.mabn='"+txtMabn.Text.Trim()+"'";
        //        m_sql+=" and to_char(a.maql)='"+amaql+"'";
				
        //        if(rd1.Checked)
        //        {
        //            m_sql+=" and to_char(a.done)='1'";
        //        }
        //        else
        //            if(rd2.Checked)
        //        {
        //            m_sql+=" and to_char(a.done)<>'1'";
        //        }

        //        m_sql+=" group by a.mabn,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy'), to_char(a.mavp), b.ten order by to_date(ngay,'dd/mm/yyyy') desc";

        //        //m_ds = m_m.get_data_v(cbNgayvv.Text.Substring(8,2),m_sql);

        //        DataSet ads = new DataSet();
        //        try
        //        {
        //            ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd order by report");
        //        }
        //        catch
        //        {
        //            m_m.execute_data("create table medibv.cd_phieucd(reportname varchar2(100), constraint pk_cd_phieucd primary key(reportname))");
        //            ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd order by report");
        //        }
				
        //        foreach(DataRow r in ads.Tables[0].Rows)
        //        {
        //            r["val"]="";
        //            try
        //            {
        //                r["val"]=m_ds.Tables[0].Select("mavp='"+r["mavp"].ToString()+"'")[0]["tenvp"].ToString().Trim();
        //            }
        //            catch
        //            {
        //                r["val"]="";
        //            }
        //        }
				
        //        DataSet ads1 = new DataSet();
        //        ads1.Tables.Add("Table");
        //        ads1.Tables[0].Columns.Add("report");
        //        ads1.Tables[0].Columns.Add("ngay");
        //        foreach(DataRow r in m_ds.Tables[0].Rows)
        //        {
        //            foreach(DataRow r1 in ads.Tables[0].Select("mavp='"+r["mavp"].ToString()+"'"))
        //            {
        //                if(ads1.Tables[0].Select("report='"+r1["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString()+"'").Length<=0)
        //                {
        //                    ads1.Tables[0].Rows.Add(new string[] {r1["report"].ToString()+"?"+r["ngay"].ToString()+"?"+r["tinhtrang"].ToString()+"?"+r["maql"].ToString()+"?"+r["idkhoa"].ToString(),r["ngay"].ToString()+" : "+r1["report"].ToString()});
        //                }
        //            }
        //        }
        //        if(ads1.Tables[0].Rows.Count<=0)
        //        {
        //            MessageBox.Show(this,"Không tìm thấy thông tin chỉ định <maql:"+cbNgayvv.SelectedValue.ToString()+">","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //        }
        //        cbPhieu.DisplayMember="ngay";
        //        cbPhieu.ValueMember="report";
        //        cbPhieu.DataSource=ads1.Tables[0];
        //    }
        //    catch(Exception ex)
        //    {
        //        //MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //    }
        //}
		private void f_Preview_VPKhoa(bool v_dir)
		{
			try
			{
                //this.Text="In phiếu chỉ định dịch vụ";
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",areport="";
				string amabn="",ahoten="",angaysinh="",aphai="",adiachi="",akhoa="",achandoan="",aicd="",atinhtrang="",aphonggiuong="",athekcb="",abacsi="";
				asyt = m_m.Syte;
				abv = m_m.Tenbv;
				
				angayin="";
				anguoiin="";
				aghichu = "";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				foreach(DataRow r in m_m.get_data("select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) ngaysinh, e.ten phai, a.sonha, a.thon,a.cholam, b.tentt, c.tenquan, d.tenpxa from btdbn a, btdtt b, btdquan c, btdpxa d, dmphai e where a.phai=e.ma(+) and a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+) and a.mabn='"+amabn+"'").Tables[0].Rows)
				{
					amabn=r["mabn"].ToString();
					ahoten=r["hoten"].ToString();
					angaysinh=r["ngaysinh"].ToString();
					aphai=r["phai"].ToString();
					adiachi=r["sonha"].ToString().Trim();
					adiachi+=" "+r["thon"].ToString().Trim();
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenpxa"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tenquan"].ToString().Trim().Replace("Không xác định","");
					adiachi=adiachi.Trim().Trim(',');
					adiachi+=", "+r["tentt"].ToString().Trim().Replace("Không xác định","");
					break;
				}
				
				areport=cbPhieu.SelectedValue.ToString();
				string ang="",att="",amaql="",aidkhoa="";
				ang=areport.Split('?')[1];
				att=areport.Split('?')[2];
				amaql=areport.Split('?')[3];
				aidkhoa=areport.Split('?')[4];
				areport=areport.Split('?')[0];
				areport=areport.ToLower();

				DataSet ads = new DataSet();
				try
				{
					ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd where lower(trim(report))=trim('"+areport+"') order by report");
				}
				catch
				{
					m_m.execute_data("create table cd_phieucd(reportname varchar2(100), constraint pk_cd_phieucd primary key(reportname))");
					ads=m_m.get_data("select trim(id) id,lower(trim(report)) report,trim(mavp) mavp,'' val from cd_thongsophieucd where lower(trim(report))=trim('"+areport+"') order by report");
				}
				
				foreach(DataRow r in ads.Tables[0].Rows)
				{
					r["val"]="";
					if(r["report"].ToString()==areport)
					{
						try
						{
							r["val"]=m_ds.Tables[0].Select("mavp='"+r["mavp"].ToString()+"' and ngay='"+ang+"' and tinhtrang='"+att+"' and idkhoa='"+aidkhoa+"' and soluong>0")[0]["tenvp"].ToString().Trim();
						}
						catch
						{
							r["val"]="";
						}
					}
				}
				while(ads.Tables[0].Select("report<>'"+areport+"' or val=''").Length>0)
				{
					DataRow r=ads.Tables[0].Select("report<>'"+areport+"' or val=''")[0];
					ads.Tables[0].Rows.Remove(r);
				}

				try
				{
					foreach(DataRow r in m_m.get_data("select a.sothe from bhyt a where to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
					{
						athekcb=r["sothe"].ToString();
						break;
					}
				}
				catch
				{
				}

				//khoa
				try
				{
					foreach(DataRow r in m_m.get_data("select nvl(d.giuong,a.giuong) giuong, a.maicd,a.chandoan, b.tenkp, c.hoten from nhapkhoa a, btdkp_bv b, dmbs c,(select idkhoa,giuong,mabs from d_dausinhton where id=(select max(id) from d_dausinhton where idkhoa="+aidkhoa+")) d where a.makp=b.makp(+) and a.id=d.idkhoa(+) and d.mabs=c.ma(+) and to_char(a.maql)='"+amaql+"' and to_char(a.id)='"+aidkhoa+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
					{
						akhoa=r["tenkp"].ToString();
						abacsi=r["hoten"].ToString();
						aphonggiuong=r["giuong"].ToString();
						aicd=r["maicd"].ToString();
						achandoan=r["chandoan"].ToString();
						break;
					}
				}
				catch
				{
				}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp, c.hoten, a.maicd,a.chandoan from benhandt a, btdkp_bv b, dmbs c where a.makp=b.makp(+) and a.mabs=c.ma(+) and to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							abacsi=r["hoten"].ToString();
							aicd=r["maicd"].ToString();
							achandoan=r["chandoan"].ToString();
							break;
						}
					}
					catch
					{
					}
				}

				if(akhoa=="")
				{
					try
					{
						foreach(DataRow r in m_m.get_data("select b.tenkp from tiepdon a, btdkp_bv b where a.makp=b.makp(+) and to_char(a.maql)='"+amaql+"' and a.mabn='"+amabn+"'").Tables[0].Rows)
						{
							akhoa=r["tenkp"].ToString();
							break;
						}
					}
					catch
					{
					}
				}

				if(!System.IO.File.Exists("..\\..\\..\\report\\"+areport))
				{
					MessageBox.Show("Không tìm thấy file: "+areport);
				}
				try
				{
					ReportDocument cMain=new ReportDocument();                    
                    
					cMain.Load("..\\..\\..\\report\\"+areport.Replace(".rpt","")+".rpt", OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
					cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
					cMain.DataDefinition.FormulaFields["v_mabn"].Text="'"+amabn+"'";
					cMain.DataDefinition.FormulaFields["v_hoten"].Text="'"+ahoten+"'";
					cMain.DataDefinition.FormulaFields["v_ngaysinh"].Text="'"+angaysinh+"'";
					cMain.DataDefinition.FormulaFields["v_phai"].Text="'"+aphai+"'";
					cMain.DataDefinition.FormulaFields["v_diachi"].Text="'"+adiachi+"'";
					cMain.DataDefinition.FormulaFields["v_khoa"].Text="'"+akhoa+"'";
					cMain.DataDefinition.FormulaFields["v_chandoan"].Text="'"+achandoan+"'";
					cMain.DataDefinition.FormulaFields["v_icd"].Text="'"+aicd+"'";
					cMain.DataDefinition.FormulaFields["v_thekcb"].Text="'"+athekcb+"'";
					cMain.DataDefinition.FormulaFields["v_phonggiuong"].Text="'"+aphonggiuong+"'";
					cMain.DataDefinition.FormulaFields["v_tinhtrang"].Text="'"+atinhtrang+"'";
					cMain.DataDefinition.FormulaFields["v_bacsi"].Text="'"+abacsi+"'";
					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

					this.Text+="("+areport+")";
					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
				}
				catch//(Exception ex)
				{
					//MessageBox.Show(ex.ToString());
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,"Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n" + ex.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void frmPrintchidinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Escape)butIn.Visible=false;
				else if((e.KeyCode==Keys.P&&e.Control) && butIn.Visible )butIn_Click(null,null);
			}
			catch
			{
			}
		}

		private void txtMabn_Validated(object sender, System.EventArgs e)
		{
			//f_Load_HC();
		}

		private void txtMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			f_Load_Chidinh(false);
			f_Preview_Chidinh(false,s_mmyy);
		}

		private void cbPhieu_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			f_Preview_Chidinh(false,s_mmyy);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			f_Preview_Chidinh(true,s_mmyy);
		}

        private void khaiBáoThôngSốPhiếuXétNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMThongsophieu af = new frmDMThongsophieu("", "");
            af.ShowDialog();
        }

        private void butin_Click(object sender, EventArgs e)
        {
            f_Preview_Chidinh(true, s_mmyy);
        }

        private void writeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writeXMLToolStripMenuItem.Checked =! writeXMLToolStripMenuItem.Checked;
        }

        private void butInAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbPhieu.Items.Count; i++)
            {
                cbPhieu.SelectedIndex = i;
                f_Preview_Chidinh(true, s_mmyy);
            }
            this.Close();
        }

        private void frmPrintchidinh_Load(object sender, EventArgs e)
        {

        }

        private void cbPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}
