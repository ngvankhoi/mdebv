using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmThkcb.
	/// </summary>
	public class frmThkcb : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //lan.Read_MainMenu_to_Xml(this.Name.ToString() + "mainMenu1", this.mainMenu1);
        //lan.Change_mainmenu_to_English(this.Name.ToString() + "mainMenu1", this.mainMenu1);
		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown vitri;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private string user,sql,s_makp,s_thetrongtinh,s_thetunguyen,s_tunguyen;
		private DataRow r1,r2;
		private int v1=5,v2=2;
		private DataRow [] dr;
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		private System.Data.DataTable dtnhom=new System.Data.DataTable();
		private DataSet dsts=new DataSet();
		private DataSet ds;
		private DataSet dsxml;
		private DataColumn dc;
		private System.Windows.Forms.ComboBox loaidt;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThkcb(LibMedi.AccessData acc,string _makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m=acc;s_makp=_makp;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmThkcb( string _makp)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m = new AccessData(); s_makp = _makp;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThkcb));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.vitri = new System.Windows.Forms.NumericUpDown();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.loaidt = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.vitri)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(64, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(184, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đối tượng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 80);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(200, 148);
            this.makp.TabIndex = 11;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(64, 32);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(96, 21);
            this.madoituong.TabIndex = 5;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(176, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Vị trí :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(64, 56);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(120, 21);
            this.sothe.TabIndex = 8;
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Lọc thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vitri
            // 
            this.vitri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vitri.Location = new System.Drawing.Point(224, 56);
            this.vitri.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.vitri.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vitri.Name = "vitri";
            this.vitri.Size = new System.Drawing.Size(40, 21);
            this.vitri.TabIndex = 10;
            this.vitri.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.vitri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(138, 271);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(98, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(49, 271);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(86, 25);
            this.butIn.TabIndex = 12;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // loaidt
            // 
            this.loaidt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaidt.Items.AddRange(new object[] {
            "Bắt buộc + tự nguyện",
            "Bắt buộc",
            "Tự nguyện"});
            this.loaidt.Location = new System.Drawing.Point(160, 32);
            this.loaidt.Name = "loaidt";
            this.loaidt.Size = new System.Drawing.Size(104, 21);
            this.loaidt.TabIndex = 6;
            this.loaidt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(64, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 32);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Số liệu";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(111, 11);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(72, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Viện phí";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(55, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Khoa";
            // 
            // frmThkcb
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(272, 309);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loaidt);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.vitri);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThkcb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng tổng hợp chi phí điều trị nội trú";
            this.Load += new System.EventHandler(this.frmThkcb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vitri)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmThkcb_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			s_thetrongtinh=d.thetrongtinh(m.nhom_duoc);
			s_thetunguyen=d.thetunguyen(m.nhom_duoc);
			if (s_thetunguyen!="" ) s_tunguyen=s_thetunguyen.Replace(",","','");
			string vitri=d.thetunguyen_vitri_ora(m.nhom_duoc);
			if (vitri!="")
			{
				v1=int.Parse(vitri.Substring(0,1));v2=int.Parse(vitri.Substring(2,1));
			}
			dtnhom=d.get_data("select distinct stt from "+user+".v_nhombhyt order by stt").Tables[0];
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where sothe<>0 order by madoituong").Tables[0];
            madoituong.DisplayMember = "DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			sql="select * from "+user+".btdkp_bv";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";
			taotable();
			loaidt.SelectedIndex=0;
			dsts.ReadXml("..//..//..//xml//d_kcbbhyt.xml");
		}

		private void taotable()
		{
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//d_kcbbhyt.xml");
			foreach(DataRow r in dtnhom.Select("true","stt"))
			{
				dc=new DataColumn();
				dc.ColumnName="c"+r["stt"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="tc";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			ds.Clear();
			s_makp="'";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+"','";
			if (rb1.Checked)
			{
				sql="select a.id,a.mabn,g.hoten,c.sothe,h.tenkp,a.chandoan,a.maicd,";
				sql+="to_char(a.ngayra,'dd/mm/yy') as ngayra,to_char(a.ngayvao,'dd/mm/yy') as ngayvao,";
				sql+=""+m.for_num_ngay("a.ngayra")+"-"+m.for_num_ngay("a.ngayvao")+"+1 as songay,";
				sql+="i.stt,b.sotien";
				sql+=" from xxx.v_thvpll a,xxx.v_thvpct b,xxx.v_thvpbhyt c,"+user+".d_dmbd d,"+user+".d_dmnhom e,"+user+".v_nhomvp f,"+user+".btdbn g,"+user +".btdkp_bv h,"+user +".v_nhombhyt i";
				sql+=" where a.id=b.id and a.mabn=g.mabn and a.id=c.id and b.mavp=d.id and d.manhom=e.id and e.nhomvp=f.ma and a.makp=h.makp and f.idnhombhyt=i.id";
				sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				sql+=" and "+m.for_ngay("a.ngayra","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				if (sothe.Text!="") sql+=" and substr(c.sothe,"+Convert.ToInt16(vitri.Value)+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
				if (s_makp.Length>1) sql+=" and b.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" and c.sothe is not null";
				if (s_tunguyen!="" && loaidt.SelectedIndex!=0)
				{
					if (loaidt.SelectedIndex==1) sql+=" and substr(c.sothe,"+v1+","+v2+") not in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
					else if (loaidt.SelectedIndex==2) sql+=" and substr(c.sothe,"+v1+","+v2+") in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
				}
				sql+=" union all ";
				sql+="select a.id,a.mabn,g.hoten,c.sothe,h.tenkp,a.chandoan,a.maicd,";
				sql+="to_char(a.ngayra,'dd/mm/yy') as ngayra,to_char(a.ngayvao,'dd/mm/yy') as ngayvao,";
				sql+=""+m.for_num_ngay("a.ngayra")+"-"+m.for_num_ngay("a.ngayvao")+"+1 as songay,";
				sql+="i.stt,b.sotien";
				sql+=" from xxx.v_thvpll a,xxx.v_thvpct b,xxx.v_thvpbhyt c,"+user+".v_giavp d,"+user+".v_loaivp e,"+user+".v_nhomvp f,"+user+".btdbn g,"+user +".btdkp_bv h,"+user +".v_nhombhyt i";
				sql+=" where a.id=b.id and a.mabn=g.mabn and a.id=c.id and b.mavp=d.id and d.id_loai=e.id and e.id_nhom=f.ma and a.makp=h.makp and f.idnhombhyt=i.id";
				sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				sql+=" and "+m.for_ngay("a.ngayra","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				if (sothe.Text!="") sql+=" and substr(c.sothe,"+Convert.ToInt16(vitri.Value)+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
				if (s_makp.Length>1) sql+=" and b.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" and c.sothe is not null";
				if (s_tunguyen!="" && loaidt.SelectedIndex!=0)
				{
					if (loaidt.SelectedIndex==1) sql+=" and substr(c.sothe,"+v1+","+v2+") not in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
					else if (loaidt.SelectedIndex==2) sql+=" and substr(c.sothe,"+v1+","+v2+") in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
				}
			}
			else
			{
				sql="select a.id,j.mabn,g.hoten,c.sothe,h.tenkp,j.chandoan,j.maicd,";
				sql+="to_char(j.ngayra,'dd/mm/yy') as ngayra,to_char(j.ngayvao,'dd/mm/yy') as ngayvao,";
				sql+=""+m.for_num_ngay("j.ngayra")+"-"+m.for_num_ngay("j.ngayvao")+"+1 as songay,";
				sql+="i.stt,b.sotien";
				sql+=" from xxx.v_ttrvll a,xxx.v_ttrvct b,xxx.v_ttrvbhyt c,xxx.v_ttrvds j,"+user+".d_dmbd d,"+user+".d_dmnhom e,"+user+".v_nhomvp f,"+user+".btdbn g,"+user +".btdkp_bv h,"+user +".v_nhombhyt i";
				sql+=" where a.id=b.id and a.id=j.id and j.mabn=g.mabn and a.id=c.id and b.mavp=d.id and d.manhom=e.id and e.nhomvp=f.ma and a.makp=h.makp and f.idnhombhyt=i.id";
				sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				if (sothe.Text!="") sql+=" and substr(c.sothe,"+Convert.ToInt16(vitri.Value)+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
				if (s_makp.Length>1) sql+=" and b.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" and c.sothe is not null";
				if (s_tunguyen!="" && loaidt.SelectedIndex!=0)
				{
					if (loaidt.SelectedIndex==1) sql+=" and substr(c.sothe,"+v1+","+v2+") not in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
					else if (loaidt.SelectedIndex==2) sql+=" and substr(c.sothe,"+v1+","+v2+") in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
				}
				sql+=" union all ";
				sql+="select a.id,j.mabn,g.hoten,c.sothe,h.tenkp,j.chandoan,j.maicd,";
				sql+="to_char(j.ngayra,'dd/mm/yy') as ngayra,to_char(j.ngayvao,'dd/mm/yy') as ngayvao,";
				sql+=""+m.for_num_ngay("j.ngayra")+"-"+m.for_num_ngay("j.ngayvao")+"+1 as songay,";
				sql+="i.stt,b.sotien";
				sql+=" from xxx.v_ttrvll a,xxx.v_ttrvct b,xxx.v_ttrvbhyt c,xxx.v_ttrvds j,"+user+".v_giavp d,"+user+".v_loaivp e,"+user+".v_nhomvp f,"+user+".btdbn g,"+user +".btdkp_bv h,"+user +".v_nhombhyt i";
				sql+=" where a.id=b.id and a.id=j.id and j.mabn=g.mabn and a.id=c.id and b.mavp=d.id and d.id_loai=e.id and e.id_nhom=f.ma and a.makp=h.makp and f.idnhombhyt=i.id";
				sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
				if (sothe.Text!="") sql+=" and substr(c.sothe,"+Convert.ToInt16(vitri.Value)+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
				if (s_makp.Length>1) sql+=" and b.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" and c.sothe is not null";
				if (s_tunguyen!="" && loaidt.SelectedIndex!=0)
				{
					if (loaidt.SelectedIndex==1) sql+=" and substr(c.sothe,"+v1+","+v2+") not in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
					else if (loaidt.SelectedIndex==2) sql+=" and substr(c.sothe,"+v1+","+v2+") in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"')";
				}
			}
			System.Data.DataTable tmp=v.get_vienphi(tu.Text,den.Text,sql).Tables[0];
			foreach(DataRow r in tmp.Rows)
			{
				sql="sothe='"+r["sothe"].ToString()+"' and mabn='"+r["mabn"].ToString()+"' and ngayvao='"+r["ngayvao"].ToString()+"'";
				r1=m.getrowbyid(dsts.Tables[0],sql);
				if (r1==null)
				{
					r2=dsts.Tables[0].NewRow();
					r2["sothe"]=r["sothe"].ToString();
					r2["mabn"]=r["mabn"].ToString();
					r2["ngayvao"]=r["ngayvao"].ToString();
					r2["soluot"]=1;
					r2["songay"]=r["songay"].ToString();
					dsts.Tables[0].Rows.Add(r2);
				}
				sql="sothe='"+r["sothe"].ToString().Trim()+"'";
				r1=m.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["id"]=r["id"].ToString();
					if (r["sothe"].ToString().Trim().Length>6)
					{
						r2["stt"]=(r["sothe"].ToString().Substring(2,2)==s_thetrongtinh)?0:1;
						r2["tinh"]=(r["sothe"].ToString().Substring(2,2)==s_thetrongtinh)?"TỈNH":"KHÁC TỈNH";
						r2["sothe1"]=(s_thetunguyen.IndexOf(r["sothe"].ToString().Substring(4,2))==-1)?"0":"1";
						r2["doituong"]=(s_thetunguyen.IndexOf(r["sothe"].ToString().Substring(4,2))==-1)?"BẮT BUỘC":"TỰ NGUYỆN";
						r2["sothe2"]=r["sothe"].ToString().Substring(2,2);
						r2["sothe3"]=r["sothe"].ToString().Substring(4,2);
					}
					r2["sothe"]=r["sothe"].ToString().Trim();
					r2["mabn"]=r["mabn"].ToString();
					r2["hoten"]=r["hoten"].ToString();
					r2["tenkp"]=r["tenkp"].ToString();
					r2["chandoan"]=r["chandoan"].ToString();
					r2["maicd"]=r["maicd"].ToString();
					r2["ngayvao"]=r["ngayvao"].ToString();
					r2["ngayra"]=r["ngayra"].ToString();
					r2["songay"]=r["songay"].ToString();
					foreach(DataRow r3 in dtnhom.Select("true","stt")) r2["c"+r3["stt"].ToString().Trim()]=0;
					r2["c"+r["stt"].ToString().Trim()]=r["sotien"].ToString();
					r2["tc"]=r["sotien"].ToString();
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0)
					{
						dr[0]["c"+r["stt"].ToString().Trim()]=decimal.Parse(dr[0]["c"+r["stt"].ToString().Trim()].ToString())+decimal.Parse(r["sotien"].ToString());
						dr[0]["tc"]=decimal.Parse(dr[0]["tc"].ToString())+decimal.Parse(r["sotien"].ToString());
					}
				}
			}
			decimal so;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				r["soluot"]=dsts.Tables[0].Select("sothe='"+r["sothe"].ToString()+"'").Length;
				so=0;
				foreach(DataRow r3 in dsts.Tables[0].Select("sothe='"+r["sothe"].ToString()+"'")) so+=decimal.Parse(r3["songay"].ToString());
				r["songay"]=so;
			}
			dsxml=new DataSet();
			dsxml=ds.Copy();
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("true","stt,sothe1,sothe3,sothe2,sothe,ngayvao,mabn"));
			dsxml.WriteXml("..//..//..//xml//t_thkcbbhyt.xml",XmlWriteMode.WriteSchema);
			Cursor=Cursors.Default;
			if (dsxml.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml.Tables[0],"rptthkcbbhyt.rpt",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,madoituong.Text,loaidt.Text,"","","","","","","");
				f.ShowDialog();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}
	}
}
