using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using gpblib;
using Medisoft.Utilities;

namespace XN
{
	/// <summary>
	/// Summary description for frmTkgpb.
	/// </summary>
	public class frmTknhuom : System.Windows.Forms.Form
	{
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private AsYetUnnamed.MultiColumnListBox lstgpb;
		private MaskedTextBox.MaskedTextBox tengpb;
		private MaskedTextBox.MaskedTextBox magpb;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGrid pxn;
		private BaseFormat bf=new BaseFormat();
		private DataSet ds=new DataSet();
		private AccessData b=new AccessData();
		private DateUtil du=new DateUtil();
        private string user;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGrid gpb;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTknhuom(string tngay,string dngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.tu.Text=tngay;
			this.den.Text=dngay;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTknhuom));
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstgpb = new AsYetUnnamed.MultiColumnListBox();
            this.tengpb = new MaskedTextBox.MaskedTextBox();
            this.magpb = new MaskedTextBox.MaskedTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pxn = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gpb = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxn)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpb)).BeginInit();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(200, 8);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 4;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(64, 8);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 3;
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstgpb
            // 
            this.lstgpb.ColumnCount = 0;
            this.lstgpb.Location = new System.Drawing.Point(8, 80);
            this.lstgpb.MatchBufferTimeOut = 1000;
            this.lstgpb.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.lstgpb.Name = "lstgpb";
            this.lstgpb.Size = new System.Drawing.Size(330, 433);
            this.lstgpb.TabIndex = 6;
            this.lstgpb.TextIndex = -1;
            this.lstgpb.TextMember = null;
            this.lstgpb.ValueIndex = -1;
            this.lstgpb.SelectedIndexChanged += new System.EventHandler(this.lstgpb_SelectedIndexChanged);
            // 
            // tengpb
            // 
            this.tengpb.BackColor = System.Drawing.SystemColors.Info;
            this.tengpb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tengpb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tengpb.Location = new System.Drawing.Point(58, 40);
            this.tengpb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.tengpb.MaxLength = 255;
            this.tengpb.Name = "tengpb";
            this.tengpb.Size = new System.Drawing.Size(280, 21);
            this.tengpb.TabIndex = 8;
            // 
            // magpb
            // 
            this.magpb.BackColor = System.Drawing.SystemColors.Info;
            this.magpb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.magpb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magpb.Location = new System.Drawing.Point(8, 40);
            this.magpb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.magpb.MaxLength = 50;
            this.magpb.Name = "magpb";
            this.magpb.Size = new System.Drawing.Size(48, 21);
            this.magpb.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(344, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(440, 472);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pxn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(432, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Phiếu xét nghiệm";
            // 
            // pxn
            // 
            this.pxn.CaptionVisible = false;
            this.pxn.DataMember = "";
            this.pxn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.pxn.Location = new System.Drawing.Point(0, 0);
            this.pxn.Name = "pxn";
            this.pxn.Size = new System.Drawing.Size(432, 448);
            this.pxn.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gpb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(432, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GPB";
            // 
            // gpb
            // 
            this.gpb.CaptionVisible = false;
            this.gpb.DataMember = "";
            this.gpb.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gpb.Location = new System.Drawing.Point(0, 0);
            this.gpb.Name = "gpb";
            this.gpb.Size = new System.Drawing.Size(432, 448);
            this.gpb.TabIndex = 1;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(716, 520);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 24;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mã";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(56, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(272, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Số lượng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(8, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 16);
            this.label6.TabIndex = 28;
            // 
            // frmTknhuom
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.magpb);
            this.Controls.Add(this.tengpb);
            this.Controls.Add(this.lstgpb);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTknhuom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê phương pháp nhuộm";
            this.Load += new System.EventHandler(this.frmTknhuom_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pxn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTknhuom_Load(object sender, System.EventArgs e)
		{
            user = b.user;
			init();
		}
		private void init()
		{
			get_dmhmmd();
			get_pxn("");
			get_gpb("");
		}
		private void get_dmhmmd()
		{
            string sql = "select c.mahmmd,c.tenhmmd,count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_XNHMMD b," + user + ".GPB_HMMD c where a.sogpb=b.sogpb and b.mahmmd=c.mahmmd ";
			sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			sql+=" group by c.mahmmd,c.tenhmmd";
			ds=b.get_data(sql) ;//b.get_data(sql);
			lstgpb.ValueMember="TENHMMD";
			lstgpb.DisplayMember="MAHMMD";
			lstgpb.ColumnWidths[0]=50;
			lstgpb.ColumnWidths[1]=250;
			lstgpb.ColumnWidths[2]=30;
			lstgpb.DataSource=ds.Tables[0];
			get_pxn(lstgpb.Text);
			get_gpb(lstgpb.Text);
		}
		private void get_pxn(string mahmmd)
		{
			try
			{
                string sql = "select a.sogpb,to_char(ngaytra,'dd/mm/yyyy') as ngaytra_,b.hoten from " + user + ".GPB_PXN a," + user + ".DMBS b," + user + ".GPB_XNHMMD c where a.bacsidoc=b.ma and a.sogpb=c.sogpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and c.mahmmd="+(mahmmd==""?0:int.Parse(mahmmd));
				ds=b.get_data(sql) ;//b.get_data(sql);
				if(mahmmd=="")
				{
					bf.f_LoadDG(pxn,ds,new String[]{"Số gpb","Ngày trả","Bác sĩ đọc"});
					bf.f_ResizeDG(pxn);
				}
				pxn.DataSource=ds.Tables[0];
			}
			catch{}
		}
		private void get_gpb(string mahmmd)
		{
			try
			{
                string sql = "select b.magpb,c.tengpb,count(1) as slxn,count(decode(d.duongtinh,1,1)) as sldt,((count(decode(d.duongtinh,1,1))/count(1))*100)||'%' as tile from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_GPB c," + user + ".GPB_XNHMMD d where a.sogpb=b.sogpb and a.sogpb=d.sogpb and b.magpb=c.magpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and d.mahmmd="+(mahmmd==""?0:int.Parse(mahmmd));
				sql+=" group by b.magpb,c.tengpb ";
				ds=b.get_data(sql);
				if(mahmmd=="")
				{
					bf.f_LoadDG(gpb,ds,new String[]{"Mã gpb","Tên gpb","slxn","sldt","Tỉ lệ"});
					bf.f_ResizeDG(gpb,1);
				}
				gpb.DataSource=ds.Tables[0];
			}catch{}
		}
		private void lstgpb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			magpb.Text=lstgpb.Text.ToString();
			tengpb.Text=lstgpb.SelectedValue.ToString();
			//
			if(!lstgpb.Focused)return;
			get_pxn(lstgpb.Text.ToString());
			get_gpb(lstgpb.Text.ToString());
		}


		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if(!du.isValidDate(tu.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",b.Msg);
				tu.Focus();
			}		
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if(!du.isValidDate(den.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",b.Msg);
				den.Focus();
			}		
		}
	}
}
