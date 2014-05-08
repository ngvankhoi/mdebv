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
	/// Summary description for frmChiphiDT.
	/// </summary>
	public class frmChiphiDT : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown vitri;
		private System.Windows.Forms.DataGrid dataGrid1;
		private string sql,s_makp,s_madoituong,user;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibMedi.AccessData m;
		private System.Windows.Forms.Button butExit;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private DataSet dstmp=new DataSet();
		private DataSet ds=new DataSet();
		private bool bClear=true;
		private System.Windows.Forms.Label lbl3;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.Label lbl1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChiphiDT(LibMedi.AccessData acc,string _makp,string _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = _makp; s_madoituong = _madoituong; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmChiphiDT( string _makp, string _madoituong)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData(); s_makp = _makp; s_madoituong = _madoituong;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiphiDT));
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vitri = new System.Windows.Forms.NumericUpDown();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butExit = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vitri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(160, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(48, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(277, 5);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(144, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(237, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(416, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(481, 5);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(124, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(602, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số thẻ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(648, 5);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(64, 21);
            this.sothe.TabIndex = 9;
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(707, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Vị trí :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vitri
            // 
            this.vitri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vitri.Location = new System.Drawing.Point(744, 5);
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
            this.vitri.Size = new System.Drawing.Size(36, 21);
            this.vitri.TabIndex = 11;
            this.vitri.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.vitri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
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
            this.dataGrid1.Location = new System.Drawing.Point(12, 11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(768, 445);
            this.dataGrid1.TabIndex = 14;
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Image = global::Medisoft.Properties.Resources.exit1;
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(397, 496);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(98, 25);
            this.butExit.TabIndex = 13;
            this.butExit.Text = "&Kết thúc";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(291, 496);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(104, 25);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "&Tổng hợp";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(283, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 34);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(163, 12);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(62, 16);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Ra viện";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(70, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(91, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Đang điều trị";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(8, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Cả hai";
            // 
            // lbl3
            // 
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.Red;
            this.lbl3.Location = new System.Drawing.Point(11, 490);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(213, 16);
            this.lbl3.TabIndex = 21;
            this.lbl3.Text = "Trung bình :";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Red;
            this.lbl2.Location = new System.Drawing.Point(11, 474);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(213, 16);
            this.lbl2.TabIndex = 20;
            this.lbl2.Text = "Tổng chi phí :";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Location = new System.Drawing.Point(11, 458);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(213, 16);
            this.lbl1.TabIndex = 19;
            this.lbl1.Text = "Số ca :";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmChiphiDT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(792, 572);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.vitri);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChiphiDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi phí điều trị theo người bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiphiDT_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmChiphiDT_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.vitri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChiphiDT_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			sql="select * from "+user+".doituong";
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
            madoituong.DataSource = m.get_data(sql).Tables[0];
            madoituong.DisplayMember = "DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            sql = "select * from " + user + ".btdkp_bv";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            //if (s_makp!="") sql+=" where makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
            sql += " order by loai,makp";
            makp.DataSource = m.get_data(sql).Tables[0];
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";
			dstmp.ReadXml("..//..//..//xml//m_chiphidt.xml");
			ds.ReadXml("..//..//..//xml//m_chiphidt.xml");
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void load_grid()
		{
			if (makp.SelectedIndex!=-1)
			{
                /*
                 * user+".btdbn a,"+user+".benhandt b,"+user+".bhyt c,"+user+".nhapkhoa d,"+user+".xuatkhoa e
                 * 
                 * a.mabn=b.mabn and b.maql=c.maql(+) and b.maql=d.maql and d.id=e.id(+)
                 * */
                sql ="select a.mabn,a.hoten,b.maql,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
				sql+=" case when e.ngay is null then ' ' else to_char(e.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
				sql+=" to_char(now(),'dd/mm/yyyy') as den,c.sothe,";
				sql+=" 00000000000.00 as thuoc,00000000000.00 as vienphi,00000000000.00 as sotien";
				sql+=" from "+user+".btdbn a inner join "+user+".benhandt b on a.mabn=b.mabn left join "+user+".bhyt c on b.maql=c.maql inner join "+user+".nhapkhoa d on b.maql=d.maql left join "+user+".xuatkhoa e on d.id=e.id ";
				sql+=" where ";
				sql+=" b.loaiba=1 and d.makp='"+makp.SelectedValue.ToString()+"'";
				if (madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				if (sothe.Text!="") sql+=" and substr(c.sothe,"+Convert.ToInt16(vitri.Value)+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
				sql+=" and "+m.for_ngay("d.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			}
			else
			{
                /*
                 * user+".btdbn a,"+user+".benhandt b,"+user+".bhyt c,"+user+".xuatvien d
                 * 
                 * a.mabn=b.mabn and b.maql=c.maql(+) and b.maql=d.maql(+)
                 * */
                sql ="select a.mabn,a.hoten,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
				sql+=" case when d.ngay is null then ' ' else to_char(d.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
				sql+=" to_char(now(),'dd/mm/yyyy') as den,c.sothe,";
				sql+=" 00000000000.00 as thuoc,00000000000.00 as vienphi,00000000000.00 as sotien";
				sql+=" from "+user+".btdbn a inner join "+user+".benhandt b on a.mabn=b.mabn left join "+user+".bhyt c on b.maql=c.maql left join "+user+".xuatvien d on b.maql=d.maql ";
				sql+=" where true ";
				if (madoituong.SelectedIndex!=-1) sql+=" and b.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				if (sothe.Text!="") sql+=" and substr(c.sothe,"+Convert.ToInt16(vitri.Value)+","+sothe.Text.Trim().Length+")='"+sothe.Text.Trim()+"'";
				sql+=" and b.loaiba=1 and "+m.for_ngay("b.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			}
			dstmp=m.get_data(sql);
			ds.Clear();
			if (rb2.Checked) ds.Merge(dstmp.Tables[0].Select("ngayra=' '","ngayvao"));
			else if (rb3.Checked) ds.Merge(dstmp.Tables[0].Select("ngayra<>' '","ngayvao"));
			else ds.Merge(dstmp.Tables[0].Select("true","ngayvao"));
			get_data();
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void get_data()
		{
			decimal d1=0,d2=0,d3=0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				r["thuoc"]=d.get_thuoc(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString().Substring(0,10),(r["ngayra"].ToString().Trim()!="")?r["ngayra"].ToString().Substring(0,10):r["den"].ToString(),(makp.SelectedIndex!=-1)?makp.SelectedValue.ToString():"",(madoituong.SelectedIndex!=-1)?int.Parse(madoituong.SelectedValue.ToString()):0,false);
				r["vienphi"]=m.get_vienphi(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString().Substring(0,10),(r["ngayra"].ToString().Trim()!="")?r["ngayra"].ToString().Substring(0,10):r["den"].ToString(),(makp.SelectedIndex!=-1)?makp.SelectedValue.ToString():"",(madoituong.SelectedIndex!=-1)?int.Parse(madoituong.SelectedValue.ToString()):0,false);
				r["sotien"]=decimal.Parse(r["thuoc"].ToString())+decimal.Parse(r["vienphi"].ToString());
				d2+=decimal.Parse(r["sotien"].ToString());
			}
			d1=ds.Tables[0].Rows.Count;
			d3=(d1==0)?0:d2/d1;
			lbl1.Text=lan.Change_language_MessageText("Số ca :")+d1.ToString();
			lbl2.Text=lan.Change_language_MessageText("Tổng chi phí :")+d2.ToString("###,###,###,###.##");
			lbl3.Text=lan.Change_language_MessageText("Trung bình :")+d3.ToString("###,###,###,###.##");
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts1=new DataGridTableStyle();
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			ts1.MappingName = ds.Tables[0].TableName;
			ts1.AlternatingBackColor = Color.Beige;
			ts1.BackColor = Color.GhostWhite;
			ts1.ForeColor = Color.MidnightBlue;
			ts1.GridLineColor = Color.RoyalBlue;
			ts1.HeaderBackColor = Color.MidnightBlue;
			ts1.HeaderForeColor = Color.Lavender;
			ts1.SelectionBackColor = Color.Teal;
			ts1.SelectionForeColor = Color.PaleGreen;
			ts1.ReadOnly=false;
			ts1.RowHeaderWidth=5;

			
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 55;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ và tên";
			TextCol.Width = 140;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,5);
			TextCol.MappingName = "thuoc";
			TextCol.HeaderText = "Thuốc";
			TextCol.Width = 80;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,6);
			TextCol.MappingName = "vienphi";
			TextCol.HeaderText = "Viện phí";
			TextCol.Width = 80;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,7);
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Chi phí";
			TextCol.Width = 80;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			load_grid();
			Cursor=Cursors.Default;
		}

		private void frmChiphiDT_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
	}
}