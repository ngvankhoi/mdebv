using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using gpblib;
using Medisoft.Utilities;
using WebTel.Drawing.Chart;

namespace XN
{
	
	public class frmTkgpb : System.Windows.Forms.Form
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
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.DataGrid pxn;
		private System.Windows.Forms.DataGrid vtst;
		private System.Windows.Forms.DataGrid tuoi;
		private System.Windows.Forms.DataGrid ppn;
		private BaseFormat bf=new BaseFormat();
		private DataSet ds=new DataSet();
		private AccessData b=new AccessData();
		private DateUtil du=new DateUtil();
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private WebTel.Drawing.Chart.ucChart ucChart1;
        private string user;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTkgpb(string tngay,string dngay)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkgpb));
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
            this.vtst = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucChart1 = new WebTel.Drawing.Chart.ucChart();
            this.tuoi = new System.Windows.Forms.DataGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ppn = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxn)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vtst)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tuoi)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ppn)).BeginInit();
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
            this.tengpb.Location = new System.Drawing.Point(56, 40);
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
            this.magpb.Location = new System.Drawing.Point(6, 40);
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
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
            this.pxn.Location = new System.Drawing.Point(0, 8);
            this.pxn.Name = "pxn";
            this.pxn.Size = new System.Drawing.Size(432, 440);
            this.pxn.TabIndex = 0;
            this.pxn.CurrentCellChanged += new System.EventHandler(this.pxn_CurrentCellChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.vtst);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(432, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vị trí sinh thiết";
            // 
            // vtst
            // 
            this.vtst.DataMember = "";
            this.vtst.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.vtst.Location = new System.Drawing.Point(0, 7);
            this.vtst.Name = "vtst";
            this.vtst.Size = new System.Drawing.Size(432, 441);
            this.vtst.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucChart1);
            this.tabPage3.Controls.Add(this.tuoi);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(432, 446);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tuổi";
            // 
            // ucChart1
            // 
            // Layout is suspended for performance reasons.
            this.ucChart1.Chart.SuspendLayout();
            this.ucChart1.Chart.CategoryX.Font = null;
            this.ucChart1.Chart.CategoryX.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.CategoryY.Font = null;
            this.ucChart1.Chart.CategoryY.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.ChartBackColor = System.Drawing.Color.LightGray;
            this.ucChart1.Chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart1.Chart.MarginBackColor = System.Drawing.Color.White;
            this.ucChart1.Chart.ResumeLayout();
            this.ucChart1.Location = new System.Drawing.Point(0, 104);
            this.ucChart1.Name = "ucChart1";
            this.ucChart1.Size = new System.Drawing.Size(432, 344);
            this.ucChart1.TabIndex = 2;
            // 
            // tuoi
            // 
            this.tuoi.CaptionVisible = false;
            this.tuoi.DataMember = "";
            this.tuoi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.tuoi.Location = new System.Drawing.Point(0, 0);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(440, 104);
            this.tuoi.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ppn);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(432, 446);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Phương pháp nhuộm";
            // 
            // ppn
            // 
            this.ppn.CaptionVisible = false;
            this.ppn.DataMember = "";
            this.ppn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.ppn.Location = new System.Drawing.Point(0, 7);
            this.ppn.Name = "ppn";
            this.ppn.Size = new System.Drawing.Size(432, 441);
            this.ppn.TabIndex = 1;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(720, 520);
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
            // frmTkgpb
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
            this.Name = "frmTkgpb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê chẩn đoán giải phẫu bệnh";
            this.Load += new System.EventHandler(this.frmTkgpb_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pxn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vtst)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tuoi)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ppn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkgpb_Load(object sender, System.EventArgs e)
		{
            user = b.user;
			init();
		}
		private void init()
		{
			get_dmgpb();
			get_gpb("");
			get_vtst("");
			get_tuoi("");
			get_ppn("");
			
		}
		private void get_dmgpb()
		{
            string sql = "select b.magpb,c.tengpb,count(*) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_GPB c where a.sogpb=b.sogpb and b.magpb=c.magpb ";
			sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy') ";
			sql+=" group by b.magpb,c.tengpb";
			ds=b.get_data(sql);
			lstgpb.ValueMember="TENGPB";
			lstgpb.DisplayMember="MAGPB";
			lstgpb.ColumnWidths[0]=50;
			lstgpb.ColumnWidths[1]=250;
			lstgpb.ColumnWidths[2]=30;
			lstgpb.DataSource=ds.Tables[0];
			get_gpb(lstgpb.Text);
			get_tuoi(lstgpb.Text);
			get_ppn(lstgpb.Text);
		}
		private void get_gpb(string magpb)
		{
			try
			{
                string sql = "select a.sogpb,to_char(ngaytra,'dd/mm/yyyy') as ngaytra,b.hoten from " + user + ".GPB_PXN a," + user + ".DMBS b," + user + ".GPB_VTSTXN c where a.bacsidoc=b.ma and a.sogpb=c.sogpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and c.magpb='"+magpb+"'";
				ds=b.get_data(sql);
				
				if(magpb=="")
				{
					bf.f_LoadDG(pxn,ds,new String[]{"Số gpb","Ngày trả","Bác sĩ đọc"});
					bf.f_ResizeDG(pxn);
				}
				pxn.DataSource=ds.Tables[0];
				get_vtst(pxn[pxn.CurrentRowIndex,0].ToString());
			}
			catch//(Exception  ex )
			{
				
			}
		}
		private void get_vtst(string sogpb)
		{
			try
			{
                string sql = "select d.manhomvtst,d.tennhomvtst,count(1) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_VTST c," + user + ".GPB_NHOMVTST d where a.sogpb=b.sogpb and b.mavtst=c.mavtst and c.manhomvtst=d.manhomvtst ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and a.sogpb='"+sogpb+"' ";
				sql+=" group by d.manhomvtst,d.tennhomvtst ";
				ds=b.get_data(sql);
				if(sogpb=="")
				{
					bf.f_LoadDG(vtst,ds,new String[]{"Mã","Nhóm vtst","Số lượng"});
					bf.f_ResizeDG(vtst,1);
				}
				vtst.DataSource=ds.Tables[0];
				vtst.CaptionText="Số gpb:"+pxn[pxn.CurrentRowIndex,0].ToString()+" Ngày trả:"+pxn[pxn.CurrentRowIndex,1].ToString();
			}catch{}
		}
		private void get_tuoi(string magpb)
		{
			try
			{
                string sql = "select to_number(to_char(now(),'yyyy'),'9999')-to_number(c.namsinh,'9999')  ,count(1) as soluong from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_BTDBN c where a.sogpb=b.sogpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and b.magpb='"+magpb+"' ";
				sql+=" and a.Sohs=c.mabn";
                sql += " group by to_number(to_char(now(),'yyyy'),'9999')-to_number(c.namsinh,'9999') ";
				ds=b.get_data(sql); //b.get_data(sql);
				if(magpb=="")
				{
					bf.f_LoadDG(tuoi,ds,new String[]{"Tuổi","Số lượng"});
					bf.f_ResizeDG(tuoi);
				}
				tuoi.DataSource=ds.Tables[0];

				get_bieudo_tuoi(magpb);
			}
			catch{}			
		}
		private void get_ppn(string magpb)
		{
			try
			{
                string sql = "select c.mahmmd,d.tenhmmd,count(1) as slxn,count(case when c.duongtinh=1 then 1 end ) as sldt,trunc((count(case when c.duongtinh=1 then 1 end )/count(1))*100,2)||'%' as tile from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b," + user + ".GPB_XNHMMD c," + user + ".GPB_HMMD d where a.sogpb=b.sogpb and b.sogpb=c.sogpb and b.mavtst=c.mavtst and c.mahmmd=d.mahmmd ";
				sql+=" and a.ngaynhan  between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				
				sql+=" and b.magpb='"+magpb+"' ";
				sql+=" group by c.mahmmd,d.tenhmmd ";
				ds=b.get_data(sql); //b.get_data(sql);
				if(magpb=="")
				{
					bf.f_LoadDG(ppn,ds,new String[]{"Mã","Phương pháp nhuộm","SLXN","SLDT","Tỉ lệ"});
					bf.f_ResizeDG(ppn,1);
				}
				ppn.DataSource=ds.Tables[0];
			}
			catch{}			
		}
		private void get_bieudo_tuoi(string magpb)
		{
			try
			{
                string sql = "select a.tuoibn from " + user + ".GPB_PXN a," + user + ".GPB_VTSTXN b where a.sogpb=b.sogpb ";
				sql+=" and a.ngaynhan between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				sql+=" and b.magpb='"+magpb+"' order by a.tuoibn";
				ds= b.get_data(sql) ;//b.get_data(sql);
				float []f=new float[ds.Tables[0].Rows.Count];
				ChartCategory[]c=new ChartCategory[ds.Tables[0].Rows.Count];
				int i=0;
				ucChart1.Chart.ChartType=ChartTypes.Bar;
				ucChart1.Chart.Series.Items.Clear();
				foreach(DataRow r in ds.Tables[0].Rows)
				{
					f[i++]=float.Parse(r[0].ToString());
					ChartCategory chart=new  ChartCategory(i.ToString());
					ucChart1.Chart.CategoryX.Items.Add(chart);
				}
	            ucChart1.Chart.Series.Items.Add(new ChartSerie(b.getColor(0),Color.Black,f));
				ucChart1.Refresh();		
			}
			catch{}			
		}
	    private void lstgpb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			magpb.Text=lstgpb.Text.ToString();
			tengpb.Text=lstgpb.SelectedValue.ToString();
			//
			if(!lstgpb.Focused)return;
			get_gpb(lstgpb.Text.ToString());
			get_tuoi(lstgpb.Text.ToString());
			get_ppn(lstgpb.Text.ToString());
		}

		private void pxn_CurrentCellChanged(object sender, System.EventArgs e)
		{
			get_vtst(pxn[pxn.CurrentRowIndex,0].ToString());
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
