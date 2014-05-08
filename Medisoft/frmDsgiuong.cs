using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDsgiuong : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
        private bool bChophep_BNKhoaA_namgiuong_khoaB = false;
		private DataTable dt=new DataTable();
        private DataTable dtkp = new DataTable();
		private DataTable dtp=new DataTable();
		private DataTable dtdt=new DataTable();
		private int _index,i_madoituong;
		private string sql,s_makp,fie,user;
		private bool b1guong=false,bChenhlech;
		private Button but;
		public long id=0;
		public string ma="";
		private ToolTip tooltip;
		private System.Windows.Forms.ComboBox phong;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel p;
		private System.Windows.Forms.Button butCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private Label label4;
        private ComboBox cbkhoa;
        private NumericUpDown Giuongtoida;
		private System.ComponentModel.IContainer components;

		public frmDsgiuong(LibMedi.AccessData acc,string _makp,int _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; s_makp = _makp; i_madoituong = _madoituong; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //--linh
        public frmDsgiuong(LibMedi.AccessData acc, string _makp, int _madoituong, bool badmin)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            m = acc; s_makp = _makp; i_madoituong = _madoituong;
        }//--end

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsgiuong));
            this.phong = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Panel();
            this.butCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbkhoa = new System.Windows.Forms.ComboBox();
            this.Giuongtoida = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Giuongtoida)).BeginInit();
            this.SuspendLayout();
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phong.DropDownWidth = 320;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(256, 3);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(177, 21);
            this.phong.TabIndex = 0;
            this.phong.SelectedIndexChanged += new System.EventHandler(this.phong_SelectedIndexChanged);
            this.phong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phong_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "&Phòng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // p
            // 
            this.p.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p.AutoScroll = true;
            this.p.Location = new System.Drawing.Point(4, 26);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(743, 429);
            this.p.TabIndex = 1;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.Location = new System.Drawing.Point(676, 2);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "&Bỏ qua";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(481, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Trống";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(545, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đặt trước";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(609, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Có người";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-8, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "&Khoa :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbkhoa
            // 
            this.cbkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbkhoa.Location = new System.Drawing.Point(37, 3);
            this.cbkhoa.Name = "cbkhoa";
            this.cbkhoa.Size = new System.Drawing.Size(185, 21);
            this.cbkhoa.TabIndex = 2;
            this.cbkhoa.SelectedIndexChanged += new System.EventHandler(this.cbkhoa_SelectedIndexChanged);
            this.cbkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phong_KeyDown);
            // 
            // Giuongtoida
            // 
            this.Giuongtoida.Location = new System.Drawing.Point(435, 4);
            this.Giuongtoida.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Giuongtoida.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Giuongtoida.Name = "Giuongtoida";
            this.Giuongtoida.Size = new System.Drawing.Size(44, 20);
            this.Giuongtoida.TabIndex = 8;
            this.Giuongtoida.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // frmDsgiuong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(749, 458);
            this.Controls.Add(this.Giuongtoida);
            this.Controls.Add(this.cbkhoa);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.p);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDsgiuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục giường";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDsgiuong_KeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDsgiuong_KeyDown);
            this.Load += new System.EventHandler(this.frmDsgiuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Giuongtoida)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDsgiuong_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            bChophep_BNKhoaA_namgiuong_khoaB = m.bChophep_BNKhoaA_namgiuong_khoaB;
            //
            cbkhoa.DisplayMember = "TENKP";
            cbkhoa.ValueMember = "MAKP";
            //
            sql = "select makp, tenkp from " + user + ".btdkp_bv where loai<>1 ";
            if (bChophep_BNKhoaA_namgiuong_khoaB == false) sql += " and makp='" + s_makp + "'";
            dtkp = m.get_data(sql).Tables[0];
            cbkhoa.DataSource = dtkp;
            cbkhoa.Enabled = cbkhoa.Items.Count != 1;
            cbkhoa.SelectedValue = s_makp;
            this.Text = "Khoa :" + cbkhoa.Text;//dtkp.Select("makp='" + s_makp + "'")[0][0].ToString();
			b1guong=m.b1giuong;
            bChenhlech = m.bChenhlech;
			fie="gia_th";
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a").Tables[0];
			DataRow r1=m.getrowbyid(dtdt,"madoituong="+i_madoituong);
			if (r1!=null) fie=r1["field_gia"].ToString().Trim();
            dtp = m.get_data("select '" + s_makp + "' as makp,0 as id,0 as stt,'' as ma,'Tất cả' as ten from medibv.btdkp where makp='01' union all " +
                                "select makp,id,stt,ma,to_char(ten) as ten from medibv.dmphong where makp='" + s_makp + "'").Tables[0];
            //r1=dtp.NewRow();
            //r1["makp"]=s_makp;
            //r1["id"]=0;
            //r1["stt"]=0;
            //r1["ma"].ToString();
            //r1["ten"]="Tất cả";
            //dtp.Rows.Add(r1);
            //sql = "select * from " + user + ".dmphong where makp='" + s_makp + "' order by stt";
            //foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            //{
            //    r1=dtp.NewRow();
            //    r1["makp"]=s_makp;
            //    r1["id"]=r["id"].ToString();
            //    r1["stt"]=r["stt"].ToString();
            //    r1["ma"]=r["ma"].ToString();
            //    r1["ten"]=r["ten"].ToString();
            //    dtp.Rows.Add(r1);
            //}
			phong.DisplayMember="TEN";
			phong.ValueMember="ID";
			phong.DataSource=dtp;
			load_grid();
		}

        private void load_phong(string m_makp)
        {
            sql = "select * from " + user + ".dmphong where id=-1";
            dtp = new DataTable();
            dtp = m.get_data(sql).Tables[0];            
            DataRow r1;
            r1 = dtp.NewRow();
            r1["makp"] = m_makp;
            r1["id"] = 0;
            r1["stt"] = 0;
            r1["ma"].ToString();
            r1["ten"] = "Tất cả";
            dtp.Rows.Add(r1);
            sql = "select * from " + user + ".dmphong where makp='" + m_makp + "' order by stt";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                r1 = dtp.NewRow();
                r1["makp"] = m_makp;
                r1["id"] = r["id"].ToString();
                r1["stt"] = r["stt"].ToString();
                r1["ma"] = r["ma"].ToString();
                r1["ten"] = r["ten"].ToString();
                dtp.Rows.Add(r1);
            }
            phong.DataSource = dtp;
        }

		private void load_grid()
		{
            string tmp_makp = s_makp;
            if (cbkhoa.SelectedIndex >= 0) tmp_makp = cbkhoa.SelectedValue.ToString();
			if (phong.SelectedValue.ToString()=="0")
                sql = "select a.id,a.stt,a.ma,trim(b.ten)||'/'||trim(a.ten) as ten,a.tinhtrang,a.soluong,a.gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.bhyt,c.chenhlech from " + user + ".dmgiuong a," + user + ".dmphong b,"+user+".v_giavp c where a.idphong=b.id and a.id=c.id and b.makp='" + tmp_makp + "' and a.khongdung=0 order by b.stt,a.stt"; //Khuong 13/12/2011
			else
                sql = "select a.id,a.stt,a.ma,trim(a.ten) as ten,a.tinhtrang,a.soluong,a.gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.bhyt,c.chenhlech from " + user + ".dmgiuong a," + user + ".dmphong b," + user + ".v_giavp c where a.idphong=b.id and a.id=c.id and a.idphong=" + int.Parse(phong.SelectedValue.ToString()) + " and a.khongdung=0 order by b.stt,a.stt";
			dt=m.get_data(sql).Tables[0];
			load();
		}

		private void phong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==phong && phong.SelectedIndex!=-1) load_grid();		
		}

		private void load()
		{
			p.Controls.Clear();
			_index=0;
			int t=5,l=5,j=0;
			foreach(DataRow r in dt.Rows)
			{
				if (j%15==0 && j!=0)
				{
					t=5;
					l+=185;
				}
				Addchkbox(r["ten"].ToString(),r["id"].ToString(),int.Parse(r["tinhtrang"].ToString()),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r[fie].ToString()),decimal.Parse(r["bhyt"].ToString()),int.Parse(r["chenhlech"].ToString()),t,l,new EventHandler(chkEvent));
				t+=27;
				j++;
                if (j > decimal.Parse(Giuongtoida.Value.ToString())) break;
			}
		}

		public void chkEvent(object sender, EventArgs e)
		{
			Control ctrl=(Control)sender;
			button c=ctrl.Tag as button;
			id=long.Parse(c.index.ToString());
			DataRow r=m.getrowbyid(dt,"id="+id);
			ma=(r!=null)?r["ma"].ToString():"";
			m.close();this.Close();
		}

		public void Addchkbox(string text,string name,int tt,decimal sl,decimal dg,decimal bhyt,decimal chenhlech,int t,int l,EventHandler onClickEvent)
		{
			button butClick=new button(name,onClickEvent);
			but=new Button();
			tooltip=new ToolTip();
			but.TabIndex=_index;
			but.Text=text;
			but.Name=name;
            tooltip.SetToolTip(but, dg.ToString("### ### ###") + " - " + but.Text);
			but.Top=t;
			but.Left=l;
			if ((b1guong && sl>0) || (i_madoituong==1 && bhyt==0)) but.Enabled=false;
			but.ForeColor=(tt==0)?Color.Blue:(tt==1)?SystemColors.Info:Color.Red;
			but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			but.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			but.Cursor = System.Windows.Forms.Cursors.Hand;
			but.Size = new System.Drawing.Size(180, 25);
			but.Click+=onClickEvent;
			but.Tag=butClick;
			but.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.p.Controls.Add(but);
			_index++;
		}

		public class button : Button
		{
			public string index;
			public string Index
			{
				get
				{
					return index;
				}
			}
			public button(string index,EventHandler onClickEvent)
			{
				this.index=index;
				Click+=onClickEvent;
			}
		}

		private void frmDsgiuong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int index=this.ActiveControl.TabIndex;
			int n=index+15-index-1;
			if (e.KeyCode==Keys.Left) for(int i=0;i<n;i++) SendKeys.Send("{Up}");
			else if (e.KeyCode==Keys.Right)	for(int i=0;i<n;i++) SendKeys.Send("{Tab}");
		}

		private void phong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private void cbkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbkhoa)
            {
                load_phong(cbkhoa.SelectedIndex == -1 ? s_makp : cbkhoa.SelectedValue.ToString());
                load_grid();
            }
        }
	}
}
