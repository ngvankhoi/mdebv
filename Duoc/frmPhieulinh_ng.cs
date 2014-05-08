using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;
using LibDuoc;
using dichso;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBcngay.
	/// </summary>
	public class frmPhieulinh_ng : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private int i_nhom, i_dongiale, i_userid=0;
		private string sql,s_makho,s_makp,s_loaint,s_tenloai,stime,user,xxx,s_mabn,s_userid,s_mmyy;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdmkho=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtloai=new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtkho = new DataTable();
		private System.Windows.Forms.DateTimePicker tu;
        private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox loai;
        private dichso.numbertotext doiso = new dichso.numbertotext();
        private TextBox tim;
        private DataGrid dataGrid1;
        private Button butList;
        private GroupBox groupBox1;
        private RadioButton rb2;
        private RadioButton rb1;
        private bool bChuky;
        private DataSet dsmabn = new DataSet();
        private DataSet dstt = new DataSet();
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bLinh_losx;
        private int checkCol = 0;
        private ComboBox makp;
        private ComboBox kho;
        private Label label3;
        private Label label4;
        private byte[] image_duoc = new byte[0];
        private byte[] image_dieutri = new byte[0];
        private byte[] image;
        private System.IO.MemoryStream memo;
        private FileStream fstr;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPhieulinh_ng(AccessData acc,int nhom,string kho,string kp,string loaint,string suserid,string mmyy, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_loaint=loaint;
            s_makho = kho; s_makp = kp; s_userid = suserid; s_mmyy = mmyy;
            i_userid = _userid;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		//s_mmyy
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
                    if (disabledBackBrush != null)
                    {
                        disabledBackBrush.Dispose();
                        disabledTextBrush.Dispose();
                        alertBackBrush.Dispose();
                        alertFont.Dispose();
                        alertTextBrush.Dispose();
                        currentRowFont.Dispose();
                        currentRowBackBrush.Dispose();
                    }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieulinh_ng));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.makp = new System.Windows.Forms.ComboBox();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(236, 249);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(306, 249);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(59, 6);
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
            this.den.Location = new System.Drawing.Point(171, 6);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // loai
            // 
            this.loai.CheckOnClick = true;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(59, 75);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 116);
            this.loai.TabIndex = 6;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(254, 1);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(260, 21);
            this.tim.TabIndex = 25;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(256, 4);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(258, 233);
            this.dataGrid1.TabIndex = 26;
            // 
            // butList
            // 
            this.butList.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(152, 249);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(84, 25);
            this.butList.TabIndex = 9;
            this.butList.Text = "&Danh sách";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(59, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 54);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(6, 29);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(94, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Phiếu hoàn trả";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(6, 10);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(75, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Phiếu xuất";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.FormattingEnabled = true;
            this.makp.Location = new System.Drawing.Point(59, 29);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kho
            // 
            this.kho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.FormattingEnabled = true;
            this.kho.Location = new System.Drawing.Point(59, 52);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 21);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Khoa :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Kho :";
            // 
            // frmPhieulinh_ng
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(519, 289);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieulinh_ng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In phiếu lĩnh";
            this.Load += new System.EventHandler(this.frmPhieulinh_ng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPhieulinh_ng_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
            i_dongiale = d.d_dongia_le(i_nhom); bChuky = m.bChuky; bLinh_losx = d.bPhieulinh_dongia_losx_date(i_nhom);
			sql="select * from "+user+".d_duockp ";
			sql+=" where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="")  sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtkp=d.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

            dstt.ReadXml("..\\..\\..\\xml\\d_sttphieulinh.xml");

            sql = "select * from " + user + ".d_dmloaint where nhom=" + i_nhom;
			if (s_loaint!="") sql+=" and id in ("+s_loaint.Substring(0,s_loaint.Length-1)+")";
			sql+=" order by stt";
			dtloai=d.get_data(sql).Tables[0];
            loai.DataSource = dtloai;
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";

            sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,c.ten as tennhom,c.stt as manhom,c.stt,d.ten as tenhang from " + user + ".d_dmbd a," + user + ".d_dmnhom b," + user + ".d_nhomin c," + user + ".d_dmhang d";
            sql += " where a.manhom=b.id ";
            if (d.bNhomin_mabd(i_nhom)) sql += " and a.nhomin=c.id ";
            else sql += " and b.nhomin=c.id ";
            sql += " and a.mahang=d.id and a.nhom=" + i_nhom;
            dt = d.get_data(sql).Tables[0];

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
            kho.DataSource = dtdmkho;
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";

            ds.ReadXml("..\\..\\..\\xml\\d_inphieu.xml");
            dsxml.ReadXml("..\\..\\..\\xml\\d_inphieu.xml");
            if (bChuky)
            {
                dtbs = d.get_data("select * from " + user + ".dmbs where nhom=" + LibMedi.AccessData.truongkhoa).Tables[0];
                DataColumn dc = new DataColumn("image_duoc", typeof(byte[]));
                dsxml.Tables[0].Columns.Add(dc);
                dc = new DataColumn("image_dieutri", typeof(byte[]));
                dsxml.Tables[0].Columns.Add(dc);
            }
            dtkho = d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom).Tables[0];

            dsmabn.ReadXml("..\\..\\..\\xml\\d_mabn.xml");
            dsmabn.Tables[0].Columns.Add("Chon", typeof(bool));
            dataGrid1.DataSource = dsmabn.Tables[0];
            AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            this.disabledBackBrush = new SolidBrush(Color.FromArgb(255, 255, 192));
            this.disabledTextBrush = new SolidBrush(Color.FromArgb(255, 0, 0));

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
		}

		private void get_xuat(string s_mmyy,bool list)
		{
            xxx = user + s_mmyy;
            if (list)
            {
                if (rb1.Checked)
                {
                    sql = "select distinct a.mabn,a.hoten ";
                    sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b ";
                    sql += " where a.id=b.id and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                    if (kho.SelectedIndex != -1) sql += " and b.makho="+int.Parse(kho.SelectedValue.ToString());
                    if (makp.SelectedIndex != -1) sql += " and a.makp =" + int.Parse(makp.SelectedValue.ToString());
                    if (s_loaint != "") sql += " and a.loai in (" + s_loaint.Substring(0, s_loaint.Length - 1) + ")";
                }
                else
                {
                    sql = "select distinct a.sophieu as mabn,a.nguoigiao as hoten ";
                    sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b ";
                    sql += " where a.id=b.id and a.nhom=" + i_nhom + " and a.ngaysp between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                    if (kho.SelectedIndex != -1) sql += " and a.makho=" + int.Parse(kho.SelectedValue.ToString());
                    if (makp.SelectedIndex != -1) sql += " and a.chietkhau=" + int.Parse(makp.SelectedValue.ToString());
                    if (s_loaint != "") sql += " and a.lydo in (" + s_loaint.Substring(0, s_loaint.Length - 1) + ")";
                    sql += " and a.loai='N'";
                }
                ins_mabn();
            }
            else
            {
                if (rb1.Checked)
                {
                    sql = "select ";
                    if (bLinh_losx) sql += "t.losx,t.handung,";
                    else sql += "'' as losx,'' as handung,";
                    sql += "b.makho,b.mabd,sum(b.soluong) as soluong,t.giamua as dongia  ";
                    sql += "from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t ";
                    sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                    if (kho.SelectedIndex != -1) sql += " and b.makho=" + int.Parse(kho.SelectedValue.ToString());
                    if (makp.SelectedIndex != -1) sql += " and a.makp =" + int.Parse(makp.SelectedValue.ToString());
                    if (s_loaint != "") sql += " and a.loai in (" + s_loaint.Substring(0, s_loaint.Length - 1) + ")";
                    if (s_mabn != "") sql += " and a.mabn in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                    sql += " group by ";
                    if (bLinh_losx) sql += "t.losx,t.handung,";
                    sql += "b.makho,b.mabd,t.giamua ";
                }
                else
                {
                    sql = "select ";
                    if (bLinh_losx) sql += "b.losx,b.handung,";
                    else sql += "'' as losx,'' as handung,";
                    sql += "a.makho,b.mabd,sum(b.soluong) as soluong,b.giamua as dongia  ";
                    sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c ";
                    sql += " where a.id=b.id and b.mabd=c.id and a.nhom=" + i_nhom + " and a.ngaysp between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                    if (kho.SelectedIndex != -1) sql += " and a.makho=" + int.Parse(kho.SelectedValue.ToString());
                    if (makp.SelectedIndex != -1) sql += " and a.chietkhau=" + int.Parse(makp.SelectedValue.ToString());
                    if (s_loaint != "") sql += " and a.lydo in (" + s_loaint.Substring(0, s_loaint.Length - 1) + ")";
                    if (s_mabn != "") sql += " and a.sophieu in (" + s_mabn.Substring(0, s_mabn.Length - 1) + ")";
                    sql += " group by ";
                    if (bLinh_losx) sql += "b.losx,b.handung,";
                    sql += "a.makho,b.mabd,b.giamua ";
                }
                ins_items();
            }
		}
        private void ins_mabn()
        {
            DataRow r1, r2;
            foreach (DataRow r in d.get_data(sql).Tables[0].Select("true", "mabn"))
            {
                r1 = m.getrowbyid(dsmabn.Tables[0], "mabn='" + r["mabn"].ToString() + "'");
                if (r1 == null)
                {
                    r2 = dsmabn.Tables[0].NewRow();
                    r2["mabn"] = r["mabn"].ToString();
                    r2["hoten"] = r["hoten"].ToString();
                    r2["chon"] = false;
                    dsmabn.Tables[0].Rows.Add(r2);
                }
            }
        }

		private void ins_items()
		{
            DataRow[] dr;
            DataRow r4;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
                r1 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                if (r1 != null)
                {
                    sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and (dongia=0 or dongia=" + decimal.Parse(r["dongia"].ToString()) + ")";
                    sql += " and makho=" + int.Parse(r["makho"].ToString());
                    if (bLinh_losx)
                        sql += " and (losx='" + r["losx"].ToString() + "' or losx is null) and (handung='" + r["handung"].ToString() + "' or handung is null)";
                    r4 = d.getrowbyid(ds.Tables[0], sql);
                    if (r4 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["makho"] = r["makho"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r1["ma"].ToString();
                        r2["ten"] = r1["ten"].ToString();
                        r2["dang"] = r1["dang"].ToString();
                        r2["tenhc"] = r1["tenhc"].ToString();
                        r2["stt"] = r1["stt"].ToString();
                        r2["manhom"] = r1["manhom"].ToString();
                        r2["tennhom"] = r1["tennhom"].ToString();
                        r2["tenhang"] = r1["tenhang"].ToString();
                        r2["soluong"] = r["soluong"].ToString();
                        r2["slyeucau"] = 0;
                        r2["losx"] = r["losx"].ToString();
                        r2["handung"] = r["handung"].ToString();
                        r2["dongia"] = r["dongia"].ToString();
                        r3 = d.getrowbyid(dtkho, "id=" + int.Parse(r["makho"].ToString()));
                        if (r3 != null) r2["tenkho"] = r3["ten"].ToString();
                        r2["dichso"] = doiso.doithapphan(r["soluong"].ToString()).Trim();
                        ds.Tables[0].Rows.Add(r2);
                    }
                    else
                    {
                        dr = ds.Tables[0].Select(sql);
                        if (dr.Length > 0)
                        {
                            dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r["soluong"].ToString());
                            dr[0]["dichso"] = doiso.doithapphan(dr[0]["soluong"].ToString()).Trim();
                            dr[0]["dongia"] = r["dongia"].ToString();
                            dr[0]["losx"] = r["losx"].ToString();
                            dr[0]["handung"] = r["handung"].ToString();
                        }
                    }
                }
			}
			ds.AcceptChanges();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}


		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra(false)) return;
			dsxml.Clear();            
            string stt = "tenkho,stt,";
            foreach (DataRow r1 in dstt.Tables[0].Select("stt<>0", "stt")) stt += r1["ma"].ToString().Trim() + ",";
            stt = stt.Substring(0, stt.Length - 1);
			dsxml.Merge(ds.Tables[0].Select("true",stt));
            bool bDuoc = false, bDieutri = false;
            if (bChuky)
            {
                DataRow r1 = m.getrowbyid(dtbs, "makp='" + makp.SelectedValue.ToString() + "'");
                if (r1 != null)
                {
                    string truongkhoa = r1["ma"].ToString().Trim();
                    if (File.Exists("..\\..\\..\\chuky\\" + truongkhoa + ".bmp"))
                    {
                        fstr = new FileStream("..\\..\\..\\chuky\\" + truongkhoa + ".bmp", FileMode.Open, FileAccess.Read);
                        image_dieutri = new byte[fstr.Length];
                        fstr.Read(image_dieutri, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();
                        bDieutri = true;
                    }
                }
                string truongkho = "kho" + i_nhom.ToString();
                if (File.Exists("..\\..\\..\\chuky\\" + truongkho + ".bmp"))
                {
                    fstr = new FileStream("..\\..\\..\\chuky\\" + truongkho + ".bmp", FileMode.Open, FileAccess.Read);
                    image_duoc = new byte[fstr.Length];
                    fstr.Read(image_duoc, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Close();
                    bDuoc = true;
                }
                foreach (DataRow r in dsxml.Tables[0].Rows)
                {
                    if (bDuoc) r["Image_duoc"] = image_duoc;
                    if (bDieutri) r["Image_dieutri"] = image_dieutri;
                }
            }
			string title=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text;
            frmReport f = new frmReport(d, dsxml.Tables[0], i_userid, "d_phieulanh_dg.rpt", makp.Text, (rb1.Checked)?"PHIẾU LĨNH":"PHIẾU HOÀN TRẢ", title, s_tenloai, "", kho.Text,"", s_mmyy,"", s_userid);
			f.ShowDialog(this);
		}

		private bool kiemtra(bool list)
		{
			s_loaint="";s_tenloai="";
			for(int i=0;i<loai.Items.Count;i++) 
				if (loai.GetItemChecked(i)) 
				{
					s_loaint+=dtloai.Rows[i]["id"].ToString()+",";
					s_tenloai+=dtloai.Rows[i]["ten"].ToString().Trim()+",";
				}
            s_mabn = "";
            foreach (DataRow r in dsmabn.Tables[0].Select("chon=true", "mabn")) s_mabn += "'" + r["mabn"].ToString().Trim() + "',";
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";		
			ds.Clear();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy)) get_xuat(mmyy,list);
				}
			}
            if (!list)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
                    return false;
                }
            }
			return true;
		}

        private void tim_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
            }
        }

        private void tim_Enter(object sender, System.EventArgs e)
        {
            tim.Text = "";
        }

        private void butList_Click(object sender, EventArgs e)
        {
            dsmabn.Clear();
            kiemtra(true);
            dataGrid1.DataSource = dsmabn.Tables[0];
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false; 
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dsmabn.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 5;

            FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "chon";
            discontinuedCol.HeaderText = "...";
            discontinuedCol.Width = 20;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "mabn";
            TextCol.HeaderText = "Mã BN";
            TextCol.Width = 60;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Họ tên";
            TextCol.Width = 145;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
                {
                    //				e.BackBrush = this.disabledBackBrush;
                    e.ForeBrush = this.disabledTextBrush;
                }
                else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
            }
            catch { }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            RefreshRow(e.Row);
            this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }
        private void RefreshRow(int row)
        {
            Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
            rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
            this.dataGrid1.Invalidate(rect);
        }

        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
                this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
            afterCurrentCellChanged = true;
        }

        private void dataGrid1_Click(object sender, System.EventArgs e)
        {
            Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
            BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
            if (afterCurrentCellChanged && hti.Row < bmb.Count
                && hti.Type == DataGrid.HitTestType.Cell
                && hti.Column == checkCol)
            {
                this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
                RefreshRow(hti.Row);
            }
            afterCurrentCellChanged = false;
        }
	}
}
