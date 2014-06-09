using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllvpkhoa_chidinh
{
	/// <summary> 
	/// Summary description for frmChonchidinh.
	/// </summary>
	public class frmChonchidinh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butCancel;
        public DataTable dt = new DataTable();
        private DataSet dsgia = new DataSet();
        
        private string s_mabn, s_loaivp, s_mucvp, sql, s_sothe, user, fie, sothe_jl;
        private string s_idnhom = "", s_idloai = "", s_gioitinh = "", s_thoigiantrakq, s_giongay = "";
		private DataColumn dc;
		private AccessData m;
		private CheckBox chkbox;
		private	TabPage tab;
		private ToolTip tooltip;
        private bool bDongia_lietke, bVpkhoa, bChidinh_thutienlien, bSortTen = false;
        private int i_madoituong, i_loai, v1, v2, vitri_jl, i_tuoi;
		private System.Windows.Forms.TabControl tabControl;
        private Panel panel1;
        private Panel panel2;
        private TreeView treeView1;
        private Splitter splitter1;
        private CheckBox chkcachcu;
        private TextBox timkiem;
        private TabControl tabControl1;
        private CheckBox chkdong;
        private DataGrid dataGrid1;
        private IContainer components;
        private decimal l_mavaovien, l_maql;
        private int i_xamlan;
        private string s_mavpicd10 = "", s_ngay = "";
        private bool bChidinh_lietke_kemgia = true;

        public frmChonchidinh(AccessData acc, string mabn, int madoituong, string loaivp, string mucvp, int loai, string sothe, int vt1, int vt2, bool vpkhoa,decimal lmavaovien)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_madoituong = madoituong; i_loai = loai; s_sothe = sothe; v1 = vt1; v2 = vt2;
            s_loaivp = loaivp; s_mucvp = mucvp; s_mabn = mabn; bVpkhoa = vpkhoa;
            l_mavaovien = lmavaovien;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        /// <summary>
        ///  Dong them
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="mabn"></param>
        /// <param name="madoituong"></param>
        /// <param name="loaivp"></param>
        /// <param name="mucvp"></param>
        /// <param name="loai"></param>
        /// <param name="sothe"></param>
        /// <param name="vt1"></param>
        /// <param name="vt2"></param>
        /// <param name="vpkhoa"></param>
        /// <param name="lmavaovien"></param>
        public frmChonchidinh(AccessData acc, string mabn, int madoituong, string loaivp, string mucvp, int loai, string sothe, int vt1, int vt2, bool vpkhoa, decimal lmavaovien, string s_vpicd10,decimal lmaql,string sngay)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_madoituong = madoituong; i_loai = loai; s_sothe = sothe; v1 = vt1; v2 = vt2;
            s_loaivp = loaivp; s_mucvp = mucvp; s_mabn = mabn; bVpkhoa = vpkhoa;
            l_mavaovien = lmavaovien;
            l_maql = lmaql;
            s_ngay = sngay;
            s_mavpicd10 = s_vpicd10;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonchidinh));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.chkcachcu = new System.Windows.Forms.CheckBox();
            this.chkdong = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(796, 504);
            this.tabControl.TabIndex = 0;
            this.tabControl.Visible = false;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(375, 505);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(72, 25);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "     Đồng ý";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(448, 505);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(72, 25);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 504);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.dataGrid1);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 504);
            this.panel2.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(252, 388);
            this.treeView1.TabIndex = 14;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(3, 373);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(249, 128);
            this.dataGrid1.TabIndex = 22;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(255, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(538, 504);
            this.tabControl1.TabIndex = 21;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 504);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // timkiem
            // 
            this.timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timkiem.Location = new System.Drawing.Point(542, 504);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(248, 20);
            this.timkiem.TabIndex = 22;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.Visible = false;
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            this.timkiem.Leave += new System.EventHandler(this.timkiem_Leave);
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged_1);
            // 
            // chkcachcu
            // 
            this.chkcachcu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkcachcu.AutoSize = true;
            this.chkcachcu.Location = new System.Drawing.Point(3, 507);
            this.chkcachcu.Name = "chkcachcu";
            this.chkcachcu.Size = new System.Drawing.Size(88, 17);
            this.chkcachcu.TabIndex = 5;
            this.chkcachcu.Text = "Liệt kê tất cả";
            this.chkcachcu.UseVisualStyleBackColor = true;
            this.chkcachcu.Click += new System.EventHandler(this.chkcachcu_Click);
            // 
            // chkdong
            // 
            this.chkdong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkdong.AutoSize = true;
            this.chkdong.Location = new System.Drawing.Point(117, 507);
            this.chkdong.Name = "chkdong";
            this.chkdong.Size = new System.Drawing.Size(118, 17);
            this.chkdong.TabIndex = 6;
            this.chkdong.Text = "Hiện thị nhiều dòng";
            this.chkdong.UseVisualStyleBackColor = true;
            this.chkdong.CheckedChanged += new System.EventHandler(this.chkdong_CheckedChanged);
            // 
            // frmChonchidinh
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(794, 536);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.chkdong);
            this.Controls.Add(this.chkcachcu);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonchidinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn dịch vụ";
            this.Load += new System.EventHandler(this.frmChonchidinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private void frmChonchidinh_Load(object sender, System.EventArgs e)
		{
            user = m.user; bDongia_lietke = m.bDongia_lietke;
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            bChidinh_lietke_kemgia = m.bChidinh_lietke_kemgia;

            fie = "gia_th"; sothe_jl = m.sSothe_jl.Trim(); vitri_jl = m.iSothe_jl_vitri;
            foreach (DataRow r in m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where madoituong=" + i_madoituong).Tables[0].Rows)
                fie = r["field_gia"].ToString().Trim();
            dsgia = m.get_data("select id,id_loai,stt,ma,ten,dvt,bhyt,gia_th,gia_bh,gia_cs,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_cs,vattu_dv,vattu_nn,loaibn,theobs,trongoi,chenhlech,loaitrongoi,locthe,thuong,readonly,ndm,tylekhuyenmai,hide,gia_ksk,vattu_ksk,kythuat,giavtth,vat,kcct,sothe,bhyt_tt,tuyentw,tuyentinh,tuyenhuyen,tuyenxa,maloai_bc,khudt,dichvu,hoichan,giaycamdoan,gioitinh,tutuoi,dentuoi,batbuocthutien,coso,cosothay,phongthuchiencls,substr(tgtrakq,1,2) thoigiantrakq,substr(tgtrakq,3,1) giongay,xamlan,ctscannercq from " + user + ".v_giavp");
			taotable();
            chkcachcu.Checked = m.Thongso("chidinhcachcu") == "1";
            chkdong.Checked = m.Thongso("chidinhdong") == "1";
            tabControl1.Multiline = chkdong.Checked;
            if (chkcachcu.Checked)
            {
                load();
                tabControl.Visible = true;
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                f_Load_Tree();
                panel1.Visible = false;
                panel2.Visible = true;
            }
            dataGrid1.DataSource = dt;
            AddGridTableStyle();
            ///Lay thong tin gioi tinh cua benh nhan. 0 nam, 1 nu
            sql = " select phai,namsinh from " + user + ".btdbn where mabn='" + s_mabn + "'";
            foreach(DataRow dr in m.get_data(sql).Tables[0].Rows)
            {
                s_gioitinh=dr["phai"].ToString();
                int i_namsinh = int.Parse(dr["namsinh"].ToString());
                i_tuoi = int.Parse(DateTime.Now.Year.ToString()) - i_namsinh;
            }
            /// End dong
		}
		private void taotable()
		{
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="mavp";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.String");
			dc.ColumnName="ten";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.String");
			dc.ColumnName="dvt";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="dongia";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="vattu";
			dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Decimal");
            dc.ColumnName = "soluong";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Decimal");
            dc.ColumnName = "hoichan";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Decimal");
            dc.ColumnName = "giaycamdoan";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Decimal");
            dc.ColumnName = "ctscannercq";
            dt.Columns.Add(dc);
		}

		private void butOK_Click(object sender, System.EventArgs e)
		{
            dt.AcceptChanges();
            m.writeXml("thongso", "chidinhdong", (chkdong.Checked) ? "1" : "0");
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
            m.writeXml("thongso", "chidinhdong", (chkdong.Checked) ? "1" : "0");
			dt.Clear();
			m.close();this.Close();
		}

		private void load()
		{
            sql = "select distinct a.* from " + user + ".v_loaivp a," + user + ".v_giavp b where a.id=b.id_loai and b.hide=0";
            if (s_loaivp != "") sql += " and  a.id in (" + s_loaivp + ")";
            //if (bChidinh_thutienlien && bVpkhoa) sql += " and b.chenhlech=0";
			sql+=" order by a.stt";
            bool b_bhyttra = false;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				tab=new TabPage();
				int t=0,l=0,j=0;
				tab.Text=r["ten"].ToString().Trim();
				tabControl.TabPages.Add(tab);
                sql = "select * from " + user + ".v_giavp where hide=0 and id_loai=" + int.Parse(r["id"].ToString());
                if (s_mucvp != "") sql += " and id not in (" + s_mucvp + ")";
                //if (bChidinh_thutienlien && bVpkhoa) sql += " and chenhlech=0";
				if (i_madoituong==1 && m.bLocdichvu_doituong)
				{
                    if (s_sothe.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (s_sothe.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (s_sothe.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Substring(v1, v2) + "%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (s_sothe.Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Substring(v1, v2) + "%')";
                    }
				}
				sql+=" and (loaibn=0 or loaibn="+i_loai+")";
				sql+=" order by stt";
                string s_ten = "";
				foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
				{
					if (j%14==0 && j!=0)
					{
						t=0;
						l+=275;
					}                    
                    s_ten = r1["ten"].ToString();
                    if (bChidinh_lietke_kemgia) s_ten += " [" + r1["gia_th"].ToString() + "]";
                    b_bhyttra = decimal.Parse(r1["bhyt"].ToString()) > 0;
                    Addchkbox(s_ten, r1["id"].ToString(), t, l, r1[fie].ToString(), r1[fie].ToString(), b_bhyttra, new EventHandler(chkEvent));
					t+=23;
					j++;
				}
				tab.AutoScroll=true;
			}
		}
		public void chkEvent(object sender, EventArgs e)
		{
            int i_tutuoi = 0, i_dentuoi = 0, i_ktraxungdot;
            string s_gtvp = "", s_mavpxungdot = "";
            DataSet ds_dichvusd=new DataSet();
			Control ctrl=(Control)sender;
            chk c = ctrl.Tag as chk;
            CheckBox check = (CheckBox)ctrl;
            DataRow r = m.getrowbyid(dsgia.Tables[0], "id=" + int.Parse(c.index.ToString()));
            bool b_bhyttra = false;
			if (r!=null)
			{
                s_mavpxungdot = m.mavpxungdot(int.Parse(c.index.ToString()));
                b_bhyttra = decimal.Parse(r["bhyt"].ToString()) > 0;
				decimal d_dongia,d_vattu;
				if (m.bNuocngoai(s_mabn))
				{
                    d_dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                    d_vattu = decimal.Parse(r["vattu_nn"].ToString()) * m.dTygia;
				}
				else
				{
                    string gia = m.field_gia(i_madoituong.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    d_dongia = decimal.Parse(r[gia].ToString());
                    d_vattu = decimal.Parse(r[giavt].ToString());
                    /// Dong them kiem tra tu tuoi ->den tuoi & gioi tinh khi cho chi dinh
                    i_tutuoi = int.Parse(r["tutuoi"].ToString());
                    i_dentuoi = int.Parse(r["dentuoi"].ToString());
                    s_gtvp = r["gioitinh"].ToString();
                    s_thoigiantrakq = r["thoigiantrakq"].ToString();
                    s_giongay = r["giongay"].ToString();
                    i_xamlan = int.Parse(r["xamlan"].ToString());
                    /// End dong
				}
                if (check.Checked)
                {
                    if (s_mavpxungdot != "")
                    {
                        string[] Arr = s_mavpxungdot.Split(',');
                        for (int i = 0; i < Arr.Length; i++)
                        {
                            i_ktraxungdot = int.Parse(Arr[i].ToString());
                            foreach (DataRow dr in m.get_data_mmyy(" select a.mavp,b.ten from xxx.v_chidinh a left join " + user + ".v_giavp b on a.mavp=b.id left join " + user + ".v_loaivp c on b.id_loai=c.id where c.id_nhom=2 and a.mavaovien=" + l_mavaovien + " and a.mabn=" + s_mabn, "", "", true).Tables[0].Rows)
                            {
                                int i_mavpxd = int.Parse(dr["mavp"].ToString());
                                string s_tenvpxungdot = dr["ten"].ToString();
                                if (i_ktraxungdot == i_mavpxd)
                                {
                                    DialogResult dl = MessageBox.Show(lan.Change_language_MessageText(" Kỹ Thuật Này Xung Đột Với " + s_tenvpxungdot), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                                    if (dl == DialogResult.No)
                                    {
                                        check.Checked = false;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    if (s_gtvp != "")
                    {
                        if (s_gtvp.IndexOf(s_gioitinh) == -1)
                        {
                            DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Giới tính không họp lệ so với danh mục giá viện phí đã khai báo."), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (dl == DialogResult.No)
                            {
                                check.Checked = false;
                                return;
                            }
                        }
                    }
                    if ((i_tutuoi != 0 && i_dentuoi != 0) && (i_tuoi < i_tutuoi || i_tuoi > i_dentuoi))
                    {
                        DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Tuổi không họp lệ so với danh mục giá viện phí đã khai báo."), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (dl == DialogResult.No)
                        {
                            check.Checked = false;
                            return;
                        }
                    }
                    if (s_thoigiantrakq != "00" && s_thoigiantrakq != "")
                    {
                        //0: gio , 1: ngay
                        if (s_giongay == "0")
                        {
                            DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bạn phải nhớ in giấy hẹn " + s_giongay + " giờ cho bệnh nhân."), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (dl == DialogResult.Yes)
                            {
                                ///update benhanpk set henlay ket qua khi chi dinh co thoi gian hen tra ket qua.                                
                                m.execute_data(" update " + user + m.mmyy(s_ngay) + ".xutrikbct set xutri=xutri||'03,' where maql=" + l_maql);
                            }
                        }
                        if (s_giongay == "1")
                        {
                            DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bạn phải nhớ in giấy hẹn " + s_giongay + " ngày cho bệnh nhân."), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (dl == DialogResult.Yes)
                            {
                                ///update benhanpk set henlay ket qua khi chi dinh co thoi gian hen tra ket qua.
                                m.execute_data(" update " + user + m.mmyy(s_ngay) + ".xutrikbct set xutri=xutri||'03,' where maql=" + l_maql);
                            }
                        }
                    }
                    if (i_xamlan == 1)
                    {
                        DialogResult dl = MessageBox.Show(lan.Change_language_MessageText(" Kỹ thuật này thuộc xâm lấn! Phải xuất hồ sơ bệnh nhân sang ngoại trú."), " Medisoft THIS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (dl == DialogResult.OK)
                        {
                            check.Checked = false;
                            return;
                        }
                    }
                    if (s_mavpicd10 != "")
                    {
                        if (s_mavpicd10.IndexOf(r["id"].ToString()) == -1)
                        {
                            DialogResult dl = MessageBox.Show(lan.Change_language_MessageText(" Chỉ định không phù hợp với chẩn đoán của ICD10. Bạn có đồng ý cho không. "), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (dl == DialogResult.No)
                            {
                                check.Checked = false;
                                return;
                            }
                        }
                        //m.reprec(dt, "mavp=" + int.Parse(r["id"].ToString()), int.Parse(r["id"].ToString()), r["ten"].ToString(), r["dvt"].ToString(), d_dongia, d_vattu, 1);
                    }
                }
                m.reprec(dt, "mavp=" + int.Parse(r["id"].ToString()), int.Parse(r["id"].ToString()), r["ten"].ToString(), r["dvt"].ToString(), d_dongia, d_vattu, 1, decimal.Parse(r["hoichan"].ToString()), decimal.Parse(r["giaycamdoan"].ToString()), decimal.Parse(r["ctscannercq"].ToString()));
			}
            r = m.getrowbyid(dt, "mavp=" + int.Parse(c.index.ToString()));
            ctrl.ForeColor = (r != null) ? Color.Red : (b_bhyttra ? Color.Blue : Color.Black);
		}
		public void Addchkbox(string text,string name,int t,int l,string gia_th,string gia_bh, bool b_bhyttra,EventHandler onClickEvent)
		{
			chk chkClick=new chk(name,onClickEvent);
			chkbox=new CheckBox();
			tooltip=new ToolTip();
			chkbox.Text=text;
			chkbox.Name=name;
			chkbox.Top=t;
			chkbox.Left=l;
            chkbox.Size = new System.Drawing.Size(270, 23);//32
            chkbox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chkbox.ForeColor = (b_bhyttra) ? System.Drawing.Color.Red : System.Drawing.Color.Blue;
			chkbox.Click+=onClickEvent;
			chkbox.Tag=chkClick;
            DataRow r = m.getrowbyid(dt, "mavp=" + int.Parse(name));
            chkbox.Checked = r != null;
            chkbox.ForeColor = (r != null) ? Color.Red : ((b_bhyttra) ? Color.Blue : Color.Black);
			tab.Controls.Add(chkbox);
            if (bDongia_lietke) 
                tooltip.SetToolTip(chkbox,text+"\n"+((gia_th == gia_bh) ? gia_th : gia_th + "\n" + gia_bh));
            else 
                tooltip.SetToolTip(chkbox,text);
		}

		public class chk : CheckBox
		{
			public string index;
			public string Index
			{
				get
				{
					return index;
				}
			}
			public chk(string index,EventHandler onClickEvent)
			{
                this.index = index;
                Click += onClickEvent;
			}
        }
        #region Chidinhdichvukieumoi
        private void f_Load_Tree()
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode anode, anode1;
                DataSet adsloai, adsnhom;
                string asort = "ten";
               
                anode = new TreeNode("Tất cả");
                anode.Tag = "?:?";
                //anode.ImageIndex = 2;
                //anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);
                sql = "select distinct a.* from " + m.user + ".v_nhomvp a, " + m.user + ".v_loaivp b, " + m.user + ".v_giavp c where a.ma=b.id_nhom and b.id=c.id_loai ";
                if (s_loaivp != "") sql += " and b.id in(" + s_loaivp.Trim().Trim(',') + ")";
                sql += "   order by a.stt";
                adsnhom = m.get_data(sql);// m_v.f_get_v_nhomvp_frmgiavp();
                sql = "select distinct a.* from " + m.user + ".v_loaivp a inner join " + m.user + ".v_giavp b on a.id=b.id_loai ";
                if (s_loaivp != "") sql += " where a.id in(" + s_loaivp.Trim().Trim(',') + ")";
                sql += "  order by a.id_nhom, a.stt";
                adsloai = m.get_data(sql);//m_v.f_get_v_loaivp_frmgiavp();                
                foreach (DataRow r in adsnhom.Tables[0].Select("", asort))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["ma"].ToString() + ":?";                    
                    treeView1.Nodes.Add(anode);
                    foreach (DataRow r1 in adsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(), asort))
                    {
                        anode1 = new TreeNode(r1["ten"].ToString());
                        anode1.Tag = r["ma"].ToString() + ":" + r1["id"].ToString();
                        
                        anode.Nodes.Add(anode1);
                    }
                }

                if (adsnhom.Tables[0].Select("ma=-1").Length < 0)
                {
                    DataRow ar = adsnhom.Tables[0].NewRow();
                    ar["ma"] = -1;
                    ar["ten"] = "...";
                    ar["idnhombhyt"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar, adsnhom.Tables[0].Rows.Count);
                }
                if (adsloai.Tables[0].Select("id=-1").Length < 0)
                {
                    DataRow ar1 = adsnhom.Tables[0].NewRow();
                    ar1["id"] = -1;
                    ar1["ten"] = "...";
                    ar1["id_nhom"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar1, adsloai.Tables[0].Rows.Count);
                }
                
            }
            catch
            {
            }
        }

        private void f_Filter()
        {
            try
            {
                s_idnhom = ""; s_idloai = "";
               
                try
                {
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {                       
                        s_idnhom = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {                       
                        s_idloai = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                catch
                {
                }
                load_new((s_idnhom.Trim()!="")?s_idnhom:"0", s_idloai);
            }
            catch
            {
            }
        }

        private void load_new(string nhomvp, string loaivp)
        {
            sql = "select distinct " + ((loaivp.Trim() == "") ? "aa.*" : "a.*") + " from " + user + ".v_nhomvp aa," + user + ".v_loaivp a," + user + ".v_giavp b where aa.ma=a.id_nhom and a.id=b.id_loai and b.hide=0";
            if (nhomvp.Trim() != "") sql += " and  a.id_nhom in (" + nhomvp + ")";
            if (s_loaivp != "") sql += " and  a.id in (" + s_loaivp + ")";
            if (loaivp != "") sql += " and  a.id in (" + loaivp + ")";
            //if (i_madoituong==1 && bChidinh_thutienlien && bVpkhoa) sql += " and b.chenhlech=0 ";
            if (bSortTen) sql += " order by  "+((loaivp.Trim() == "") ? "aa.ten" : "a.ten");// b.ten ";
            else sql += " order by "+((loaivp.Trim() == "") ? "aa.stt" : "a.stt");
            tabControl1.TabPages.Clear();
            string s_ten = "";
            bool b_bhyttra = false;
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                tab = new TabPage();
                int t = 0, l = 0, j = 0;
                tab.Text = r["ten"].ToString().Trim();
                tabControl1.TabPages.Add(tab);
                sql = "select a.* from " + user + ".v_giavp a, " + user + ".v_loaivp b where a.id_loai=b.id and a.hide=0 ";
                if (loaivp.Trim() == "") sql += " and b.id_nhom=" + int.Parse(r["ma"].ToString());
                else sql+=" and id_loai=" + int.Parse(r["id"].ToString());
                if (s_mucvp != "") sql += " and a.id not in (" + s_mucvp + ")";
                //if (i_madoituong == 1 && bChidinh_thutienlien && bVpkhoa) sql += " and chenhlech=0";
                if (i_madoituong == 1 && m.bLocdichvu_doituong)
                {
                    if (s_sothe.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (s_sothe.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (s_sothe.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Substring(v1, v2) + "%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (s_sothe.Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Substring(v1, v2) + "%')";
                    }
                }
                sql += " and (loaibn=0 or loaibn=" + i_loai + ")";
                if (bSortTen) sql += " order by a.ma ";
                else sql += " order by a.stt";
                
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                {
                    if (j % 20 == 0 && j != 0)
                    {
                        t = 0;
                        l += 275;
                    }
                    s_ten = r1["ten"].ToString();
                    if (bChidinh_lietke_kemgia) s_ten += " [" + r1["gia_th"].ToString() + "]";
                    b_bhyttra = decimal.Parse(r1["bhyt"].ToString()) > 0;
                    Addchkbox(s_ten, r1["id"].ToString(), t, l, r1[fie].ToString(), r1[fie].ToString(), b_bhyttra, new EventHandler(chkEvent));
                    t += 23;//32
                    j++;
                    if (loaivp.Trim() == "" && j > 100) break;
                }
                tab.AutoScroll = true;
            }
        }
        private void load_new(string nhomvp,string loaivp,string s_ten)
        {
            sql = "select distinct " + ((loaivp.Trim() == "") ? "aa.*" : "a.*") + " from " + user + ".v_nhomvp aa," + user + ".v_loaivp a," + user + ".v_giavp b where aa.ma=a.id_nhom and a.id=b.id_loai and b.hide=0";
            if (nhomvp.Trim() != "") sql += " and  a.id_nhom in (" + nhomvp + ")";
            if (s_loaivp != "") sql += " and  a.id in (" + s_loaivp + ")";
            if (loaivp != "") sql += " and  a.id in (" + loaivp + ")";
            //if (bChidinh_thutienlien && bVpkhoa) sql += " and b.chenhlech=0";
            sql += " order by "+((loaivp.Trim() == "")?"aa.stt":"a.stt");
            tabControl1.TabPages.Clear();
            string s_tenvp = "";
            bool b_bhyttra = false;
            
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                tab = new TabPage();
                int t = 0, l = 0, j = 0;
                tab.Text = r["ten"].ToString().Trim();
                tabControl1.TabPages.Add(tab);
                sql = "select a.* from " + user + ".v_giavp a, " + user + ".v_loaivp b where a.id_loai=b.id and a.hide=0 ";
                if (nhomvp.Trim() != "") sql += " and b.id_nhom=" + int.Parse(r["ma"].ToString());
                else if(loaivp.Trim()!="") sql+=" and a.id_loai=" + int.Parse(r["id"].ToString());
                if (s_mucvp != "") sql += " and a.id not in (" + s_mucvp + ")";
                //if (bChidinh_thutienlien && bVpkhoa) sql += " and a.chenhlech=0";
                if (i_madoituong == 1 && m.bLocdichvu_doituong)
                {
                    if (s_sothe.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (s_sothe.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (s_sothe.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Substring(v1, v2) + "%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (s_sothe.Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Substring(v1, v2) + "%')";
                    }
                }
                sql += " and (loaibn=0 or loaibn=" + i_loai + ")";
                if (bSortTen == false)
                {
                    sql += " order by a.stt";
                }
                else
                {
                    sql += " order by a.ten ";
                }
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Select("ten like '%"+s_ten+"%'"))
                {
                    if (j % 13 == 0 && j != 0)
                    {
                        t = 0;
                        l += 275;
                    }
                    s_tenvp = r1["ten"].ToString();
                    if (bChidinh_lietke_kemgia) s_tenvp += " [" + r1["gia_th"].ToString() + "]";
                    b_bhyttra = decimal.Parse(r1["bhyt"].ToString()) > 0;
                    Addchkbox(s_tenvp, r1["id"].ToString(), t, l, r1[fie].ToString(), r1[fie].ToString(),b_bhyttra, new EventHandler(chkEvent));
                    t += 23;//32
                    j++;
                    if (loaivp.Trim() == "" && j > 100) break;
                }
                tab.AutoScroll = true;
            }
            timkiem.Focus();
        }
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f_Filter();
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Red;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Red;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }

       
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Black;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Black;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }

        private void timkiem_TextChanged_1(object sender, EventArgs e)
        {
            if (timkiem.Text != "Tìm kiếm" && timkiem.Text!="")
            {                
                if(timkiem.Text.Trim().Length>=2) load_new(s_idnhom, s_idloai, timkiem.Text);
            }
        }

        private void timkiem_Enter(object sender, EventArgs e)
        {
            if (timkiem.Text == "Tìm kiếm") timkiem.Text = "";
        }

        private void timkiem_Leave(object sender, EventArgs e)
        {
            if (timkiem.Text == "") timkiem.Text = "Tìm kiếm";
        }

        private void chkcachcu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (chkcachcu.Checked)
            {
                load();
                tabControl.Visible = true;
                panel1.Visible = true;
                panel2.Visible = false;
                //panel1.Dock = System.ComponentModel.;
            }
            else
            {
                f_Load_Tree();
                panel1.Visible = false;
                panel2.Visible = true;
            }
            m.writeXml("thongso", "chidinhcachcu", (chkcachcu.Checked) ? "1" : "0");
            Cursor = Cursors.Default;
        }

        private void chkdong_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Multiline = chkdong.Checked;
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 5;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Dịch vụ";
            TextCol.Width = dataGrid1.Width -63;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "soluong";
            TextCol.HeaderText = "SL";
            TextCol.Width = 30;
            TextCol.Format = "###,###";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        public bool SapxepTenKT_TheoABC
        {
            set
            {
                bSortTen = value;
            }
        }
    }
}
