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
	public class frmTkvtst : System.Windows.Forms.Form
	{
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private AsYetUnnamed.MultiColumnListBox lstgpb;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private BaseFormat bf=new BaseFormat();
		private DataSet ds=new DataSet();
		private AccessData b=new AccessData();
		private DateUtil du=new DateUtil();
        private string user;
		private System.Windows.Forms.Button butKetthuc;
		private MaskedTextBox.MaskedTextBox tenvtst;
		private MaskedTextBox.MaskedTextBox mavtst;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid vtst;
		private System.Windows.Forms.DataGrid gpb;
		private System.Windows.Forms.DataGrid sogpb;
		private System.Windows.Forms.Button btntk;
		private System.Windows.Forms.Button btnvtstpxn;
		
		private System.ComponentModel.Container components = null;

		public frmTkvtst(string tngay,string dngay)
		{
			
			InitializeComponent();
			this.tu.Text=tngay;
			this.den.Text=dngay;
		}

		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkvtst));
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstgpb = new AsYetUnnamed.MultiColumnListBox();
            this.tenvtst = new MaskedTextBox.MaskedTextBox();
            this.mavtst = new MaskedTextBox.MaskedTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sogpb = new System.Windows.Forms.DataGrid();
            this.vtst = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gpb = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btntk = new System.Windows.Forms.Button();
            this.btnvtstpxn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sogpb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vtst)).BeginInit();
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
            // tenvtst
            // 
            this.tenvtst.BackColor = System.Drawing.SystemColors.Info;
            this.tenvtst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tenvtst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenvtst.Location = new System.Drawing.Point(58, 40);
            this.tenvtst.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.tenvtst.MaxLength = 255;
            this.tenvtst.Name = "tenvtst";
            this.tenvtst.Size = new System.Drawing.Size(278, 21);
            this.tenvtst.TabIndex = 8;
            // 
            // mavtst
            // 
            this.mavtst.BackColor = System.Drawing.SystemColors.Info;
            this.mavtst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mavtst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavtst.Location = new System.Drawing.Point(8, 40);
            this.mavtst.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mavtst.MaxLength = 50;
            this.mavtst.Name = "mavtst";
            this.mavtst.Size = new System.Drawing.Size(48, 21);
            this.mavtst.TabIndex = 9;
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
            this.tabPage1.Controls.Add(this.sogpb);
            this.tabPage1.Controls.Add(this.vtst);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(432, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vị trí sinh thiết";
            // 
            // sogpb
            // 
            this.sogpb.CaptionVisible = false;
            this.sogpb.DataMember = "";
            this.sogpb.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.sogpb.Location = new System.Drawing.Point(0, 232);
            this.sogpb.Name = "sogpb";
            this.sogpb.Size = new System.Drawing.Size(432, 216);
            this.sogpb.TabIndex = 1;
            // 
            // vtst
            // 
            this.vtst.CaptionVisible = false;
            this.vtst.DataMember = "";
            this.vtst.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.vtst.Location = new System.Drawing.Point(0, 8);
            this.vtst.Name = "vtst";
            this.vtst.Size = new System.Drawing.Size(432, 216);
            this.vtst.TabIndex = 0;
            this.vtst.CurrentCellChanged += new System.EventHandler(this.vtst_CurrentCellChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gpb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(432, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nhóm GPB";
            // 
            // gpb
            // 
            this.gpb.CaptionVisible = false;
            this.gpb.DataMember = "";
            this.gpb.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gpb.Location = new System.Drawing.Point(0, 7);
            this.gpb.Name = "gpb";
            this.gpb.Size = new System.Drawing.Size(432, 441);
            this.gpb.TabIndex = 1;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(617, 525);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 24;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(280, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Số lượng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(64, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mã";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btntk
            // 
            this.btntk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btntk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntk.Location = new System.Drawing.Point(350, 525);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(264, 25);
            this.btntk.TabIndex = 35;
            this.btntk.Text = "&In thống kê vị trí sinh thiết-gpb-phiếu xét nghiệm";
            this.btntk.Click += new System.EventHandler(this.btntk_Click);
            // 
            // btnvtstpxn
            // 
            this.btnvtstpxn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvtstpxn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnvtstpxn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnvtstpxn.Location = new System.Drawing.Point(107, 525);
            this.btnvtstpxn.Name = "btnvtstpxn";
            this.btnvtstpxn.Size = new System.Drawing.Size(240, 25);
            this.btnvtstpxn.TabIndex = 36;
            this.btnvtstpxn.Text = "&In thống kê vị trí sinh thiết-phiếu xét nghiệm";
            this.btnvtstpxn.Click += new System.EventHandler(this.btnvtstpxn_Click);
            // 
            // frmTkvtst
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btnvtstpxn);
            this.Controls.Add(this.btntk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.mavtst);
            this.Controls.Add(this.tenvtst);
            this.Controls.Add(this.lstgpb);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkvtst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê vị trí sinh thiết";
            this.Load += new System.EventHandler(this.frmTkvtst_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sogpb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vtst)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkvtst_Load(object sender, System.EventArgs e)
		{
            user = b.user;
			init();
		}
		private void init()
		{
			get_dmvtst();
			get_vtst("");
			get_sogpb("");
			get_gpb("");
		}
		private void get_dmvtst()
		{
            string sql = "select d.manhomvtst,d.tennhomvtst,count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_VTST c," + user + ".GPB_NHOMVTST d where a.sogpb=b.sogpb and b.mavtst=c.mavtst and c.manhomvtst=d.manhomvtst ";
			sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			sql+=" group by d.manhomvtst,d.tennhomvtst";
			ds=b.get_data(sql);
			lstgpb.ValueMember="TENNHOMVTST";
			lstgpb.DisplayMember="MANHOMVTST";
			lstgpb.ColumnWidths[0]=50;
			lstgpb.ColumnWidths[1]=250;
			lstgpb.ColumnWidths[2]=30;
			lstgpb.DataSource=ds.Tables[0];
			get_vtst(lstgpb.Text);
			get_gpb(lstgpb.Text);
		}
		private void get_vtst(string manhomvtst)
		{
			try
			{
                string sql = "select c.mavtst,c.tenvtst,count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_VTST c where a.sogpb=b.sogpb and b.mavtst=c.mavtst ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and b.mavtst like '"+manhomvtst+"%'";
				sql+=" group by c.mavtst,c.tenvtst";
				ds=b.get_data(sql);
				if(manhomvtst=="")
				{
					bf.f_LoadDG(vtst,ds,new String[]{"Mã vtst","Tên vtst","Số lượng"});
					bf.f_ResizeDG(vtst,1);
				}
				vtst.DataSource=ds.Tables[0];
				get_sogpb(vtst[vtst.CurrentRowIndex,0].ToString());
			}
			catch{}
		}
		private void get_sogpb(string mavtst)
		{
			try
			{
                string sql = "select a.sogpb,to_char(ngaytra,'dd/mm/yyyy') as ngaytra,c.hoten from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".DMBS c where a.sogpb=b.sogpb and a.bacsidoc=c.ma ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and b.mavtst='"+mavtst+"' ";
				ds=b.get_data(sql);
				if(mavtst=="")
				{
					bf.f_LoadDG(sogpb,ds,new String[]{"Số gpb","Ngày trả","Bác sĩ đọc"});
					bf.f_ResizeDG(sogpb);
				}
				sogpb.DataSource=ds.Tables[0];
			}catch{}
		}
		private void get_gpb(string manhomvtst)
		{
			try
			{
                string sql = "select b.magpb,c.tengpb,count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_GPB c where a.sogpb=b.sogpb and b.magpb=c.magpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and substr(b.mavtst,1,3)='"+manhomvtst+"' ";
				sql+=" group by b.magpb,c.tengpb ";
				ds=b.get_data(sql);
				if(manhomvtst=="")
				{
					bf.f_LoadDG(gpb,ds,new String[]{"Mã gpb","Tên gpb","Số lượng"});
					bf.f_ResizeDG(gpb,1);
				}
				gpb.DataSource=ds.Tables[0];
			}
			catch{}			
		}
		private void lstgpb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mavtst.Text=lstgpb.Text.ToString();
			tenvtst.Text=lstgpb.SelectedValue.ToString();
			//
			if(!lstgpb.Focused)return;
			get_vtst(lstgpb.Text.ToString());
			get_gpb(lstgpb.Text.ToString());
		}

		private void vtst_CurrentCellChanged(object sender, System.EventArgs e)
		{
			get_sogpb(vtst[vtst.CurrentRowIndex,0].ToString());
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

		private void btntk_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			try
			{
				//string sql="select e.manhomvtst,e.tennhomvtst,c.magpb,c.tengpb,a.sogpb,to_date(ngaynhan,'dd/mm/yyyy') as ngaynhan,hotenbn,tenbs from GPB_PXN a,GPB_VTSTXN b,gpb c,GPB_VTST d,GPB_NHOMVTST e,bacsi f where a.sogpb=b.sogpb and b.magpb=c.magpb and b.mavtst=d.mavtst and d.manhomvtst=e.manhomvtst and a.bacsidoc=f.mabs ";
				//sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				string sql =" select e.manhomvtst,e.tennhomvtst,c.magpb,c.tengpb,a.sogpb,to_char(ngaynhan,'dd/mm/yyyy') as ngaynhan,hotenbn,hoten tenbs ";
                sql += " from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_GPB  c," + user + ".GPB_VTST d," + user + ".GPB_NHOMVTST e, " + user + ".dmbs  f, " + user + ".GPB_BTDBN g  where a.sogpb=b.sogpb ";
				sql+= " and b.magpb=c.magpb and b.mavtst=d.mavtst and d.manhomvtst=e.manhomvtst and a.bacsidoc=f.ma and a.sohs = g.mabn  and ";
				sql+= " a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";

				ds=b.get_data(sql);
				frmPrintAll f=new frmPrintAll();
				f.Vtst(false,ds,b.Syte,b.Tenbv,b.Diachi,"vtst_gpb_pxn.rpt");
				f.ShowDialog();
			}
			catch{}			
			this.Cursor=Cursors.Default;
		}

		private void btnvtstpxn_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			try
			{
//				string sql="select e.manhomvtst,e.tennhomvtst,c.magpb,c.tengpb,a.sogpb,to_date(ngaynhan,'dd/mm/yyyy') as ngaynhan,hotenbn,tenbs from GPB_PXN a,GPB_VTSTXN b,gpb c,GPB_VTST d,GPB_NHOMVTST e,bacsi f where a.sogpb=b.sogpb and b.magpb=c.magpb and b.mavtst=d.mavtst and d.manhomvtst=e.manhomvtst and a.bacsidoc=f.mabs ";
//				sql+ =" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				string sql  = "select e.manhomvtst,e.tennhomvtst,c.magpb,c.tengpb,a.sogpb,to_char(ngaynhan,'dd/mm/yyyy') as ngaynhan,hotenbn,hoten  tenbs ";
                sql += " from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_GPB c," + user + ".GPB_VTST d," + user + ".GPB_NHOMVTST e, " + user + ".dmbs f  , " + user + ".gpb_btdbn g where a.sogpb=b.sogpb ";
				sql  = sql+   " and b.magpb=c.magpb and b.mavtst=d.mavtst and d.manhomvtst=e.manhomvtst and a.bacsidoc=f.ma  and  a.sohs = g.mabn  and ";
				sql+= " a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy') ";
				
				ds=b.get_data(sql);
				frmPrintAll f=new frmPrintAll();
				f.Vtst(false,ds,b.Syte,b.Tenbv,b.Diachi,"vtst_pxn.rpt");
				f.ShowDialog();
			}
			catch{}					
			this.Cursor=Cursors.Default;
		}
	}
}
