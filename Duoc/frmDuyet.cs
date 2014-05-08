
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmDuyet : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.Button butLay;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bSkip = false, bBuhaophi, bThua, bPhattron, bBucstt_nguon, bCongdon, bSlthuc_yeucau, bKiemtra, bBucstt_tronso, bKiemtra_duyet, b1kho, bIntheocstt, bGiaban, bTreole_duyetrieng;
		private int checkCol=0,i_userid,i_row=0,i_thuoc;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private int i_nhom,i_loai,i_mabd,i_makho,o_makp,o_phieu,i_manguon,o_makhoa,itable,soluong_le,i_khudt=0;
		private decimal d_soluongcu,d_soluongton,d_soluong;
		private string user,xxx,f_ngay,s_makp,sql,s_mmyy,s_kho,s_ngay,o_tu,o_den,file1,file2,s_min,s_max,s_tenkp,s_phieu,s_ravien,s_noidung,s_sttduyet,s_userid,format_soluong;
		private DataTable dtct=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtphieu=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtcstt=new DataTable();
		private DataTable dthoten=new DataTable();
        private DataTable dtbd = new DataTable();
		private DataSet ds=new DataSet();
		public DataTable dtll=new DataTable();
        public bool bOk = false;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.CheckBox phatsau;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox kp;
        private CheckBox chkAll;
        private bool bTinnhan, bTinnhan_sound;
        private CheckBox chkTreole;
        private bool bCont, bTreole, bKhoasau_hoantra;
        private Button butTreoduyet;
        private CheckBox chkluuin;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDuyet(LibDuoc.AccessData acc,DataTable dt,int nhom,int loai,string makp,string mmyy,string kho,string title,string ngay,int userid,bool buhaophi,bool thua,int thuoc,bool congdon,string _userid, int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;dtll=dt;i_nhom=nhom;i_loai=loai;i_userid=userid;i_thuoc=thuoc;
            s_makp = makp; s_mmyy = mmyy; s_kho = kho; s_ngay = ngay; bCongdon = congdon; s_userid = _userid;
			bBuhaophi=buhaophi;bThua=thua;this.Text=title;            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_khudt = _khudt;
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
					if(disabledBackBrush != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyet));
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.phatsau = new System.Windows.Forms.CheckBox();
            this.kp = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkTreole = new System.Windows.Forms.CheckBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butTreoduyet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butLay = new System.Windows.Forms.Button();
            this.chkluuin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(95, 4);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(161, 21);
            this.makp.TabIndex = 1;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(254, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phiếu ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(292, 4);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(224, 21);
            this.phieu.TabIndex = 2;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 9);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(783, 470);
            this.dataGrid1.TabIndex = 24;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(520, 4);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(136, 21);
            this.tim.TabIndex = 4;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // phatsau
            // 
            this.phatsau.Checked = true;
            this.phatsau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.phatsau.Location = new System.Drawing.Point(661, 4);
            this.phatsau.Name = "phatsau";
            this.phatsau.Size = new System.Drawing.Size(136, 24);
            this.phatsau.TabIndex = 26;
            this.phatsau.Text = "Không duyệt lĩnh dồn";
            this.phatsau.CheckedChanged += new System.EventHandler(this.phatsau_CheckedChanged);
            this.phatsau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // kp
            // 
            this.kp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kp.Location = new System.Drawing.Point(66, 4);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(26, 21);
            this.kp.TabIndex = 0;
            this.kp.Validated += new System.EventHandler(this.kp_Validated);
            this.kp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kp_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 31);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(30, 23);
            this.chkAll.TabIndex = 27;
            this.chkAll.Text = "Bỏ";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkTreole
            // 
            this.chkTreole.AutoSize = true;
            this.chkTreole.Location = new System.Drawing.Point(709, 485);
            this.chkTreole.Name = "chkTreole";
            this.chkTreole.Size = new System.Drawing.Size(86, 17);
            this.chkTreole.TabIndex = 28;
            this.chkTreole.Text = "Duyệt treo lẻ";
            this.chkTreole.UseVisualStyleBackColor = true;
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(594, 484);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butTreoduyet
            // 
            this.butTreoduyet.BackColor = System.Drawing.Color.Transparent;
            this.butTreoduyet.Image = ((System.Drawing.Image)(resources.GetObject("butTreoduyet.Image")));
            this.butTreoduyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTreoduyet.Location = new System.Drawing.Point(509, 484);
            this.butTreoduyet.Name = "butTreoduyet";
            this.butTreoduyet.Size = new System.Drawing.Size(84, 25);
            this.butTreoduyet.TabIndex = 29;
            this.butTreoduyet.Text = "&Treo duyệt";
            this.butTreoduyet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTreoduyet.UseVisualStyleBackColor = false;
            this.butTreoduyet.Click += new System.EventHandler(this.butTreoduyet_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(217, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "Y lệnh";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(404, 484);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(104, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&DS dự trù-duyệt";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(343, 484);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 8;
            this.butIn.Text = "     &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(282, 484);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butLay
            // 
            this.butLay.BackColor = System.Drawing.Color.Transparent;
            this.butLay.Image = ((System.Drawing.Image)(resources.GetObject("butLay.Image")));
            this.butLay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLay.Location = new System.Drawing.Point(131, 484);
            this.butLay.Name = "butLay";
            this.butLay.Size = new System.Drawing.Size(85, 25);
            this.butLay.TabIndex = 5;
            this.butLay.Text = "      Lấy &số liệu";
            this.butLay.UseVisualStyleBackColor = false;
            this.butLay.Click += new System.EventHandler(this.butLay_Click);
            // 
            // chkluuin
            // 
            this.chkluuin.AutoSize = true;
            this.chkluuin.Location = new System.Drawing.Point(12, 485);
            this.chkluuin.Name = "chkluuin";
            this.chkluuin.Size = new System.Drawing.Size(55, 17);
            this.chkluuin.TabIndex = 30;
            this.chkluuin.Text = "Lưu in";
            this.chkluuin.UseVisualStyleBackColor = true;
            this.chkluuin.CheckedChanged += new System.EventHandler(this.chkluuin_CheckedChanged);
            // 
            // frmDuyet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butBoqua;
            this.ClientSize = new System.Drawing.Size(794, 519);
            this.Controls.Add(this.chkluuin);
            this.Controls.Add(this.butTreoduyet);
            this.Controls.Add(this.chkTreole);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.phatsau);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butLay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 38);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDuyet";
            this.Load += new System.EventHandler(this.frmDuyet_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDuyet_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDuyet_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDuyet_Load(object sender, System.EventArgs e)
		{
            this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            bTinnhan = d.bTinnhan(i_nhom); bKhoasau_hoantra = m.bKhoasau_hoantra_F28;
            bTinnhan_sound = d.bTinnhan_sound(i_nhom);
            user = d.user; xxx = user + s_mmyy; f_ngay = d.f_ngay;
            soluong_le = d.d_soluong_le(i_nhom);
            if (!d.bGiaban_theodot(i_nhom))
                bGiaban = d.get_data("select * from " + user + ".d_doituong where loai=1").Tables[0].Rows.Count > 0;
            bIntheocstt = d.bIntheocstt(i_nhom);
            if (bIntheocstt && i_loai==2) label1.Text = "Tủ trực :";
            bKiemtra_duyet = d.bKiemtra_duyet(i_nhom);
            itable = d.tableid(s_mmyy, "d_xuatsdll");
			ds.ReadXml("..\\..\\..\\xml\\d_cstt_ts.xml");
			bKiemtra=d.bKiemtra_phat_thuhoi(i_nhom);
            format_soluong = d.format_soluong(i_nhom);
            phatsau.Checked = false;            
            chkluuin.Checked = d.Thongso("duyet_luuin") == "1";
			if (bBuhaophi)
			{
				file1=xxx+".d_haophill";file2=xxx+".d_haophict";
				s_noidung="PHIEU HAO PHI";
			}
			else
			{
				switch (i_loai)
				{
                    case 1: file1 = "xxx.d_dutrull"; file2 = "xxx.d_dutruct"; s_noidung = "PHIEU LINH";
                        break;
                    case 2: file1 = "xxx.d_xtutrucll"; file2 = "xxx.d_xtutrucct"; s_noidung = "PHIEU TU TRUC";
                        break;
                    case 3: file1 = "xxx.d_hoantrall"; file2 = "xxx.d_hoantract"; s_noidung = "PHIEU HOAN TRA";
                        break;
                    default: file1 = "xxx.d_haophill"; file2 =  "xxx.d_haophict"; s_noidung = "PHIEU HAO PHI";
                        break;
				}
			}
            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
            if (s_makp != "") sql += " and id in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            if (i_khudt != 0) sql += " and (khu=0 or khu =" + i_khudt + ")";
            sql += " order by stt";
            dtkp = d.get_data(sql).Tables[0];
            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";
            makp.DataSource = dtkp;
            if (makp.Items.Count > 0) kp.Text = dtkp.Rows[makp.SelectedIndex]["ma"].ToString();

			bSlthuc_yeucau=d.bSLDuyet_nho_yeucau(i_nhom);
			bPhattron=d.bPhattron(i_nhom);
			bBucstt_tronso=d.bBucstt_tronso(i_nhom);
			bBucstt_nguon=d.bBucstt_nguon(i_nhom);            
			if (i_loai==2 || bBuhaophi) dtcstt=d.get_data("select * from "+user+".d_cosotutruc where nhom="+i_nhom+" and mmyy='"+s_mmyy+"'").Tables[0];
            /*
            if (bThua) sql = "select * from " + user + ".d_loaiphieu where id=0";
			else
			{
                string s_phieu = (makp.SelectedIndex != -1) ? dtkp.Rows[makp.SelectedIndex]["phieu"].ToString() : "";
                string s_loai = (makp.SelectedIndex != -1) ? dtkp.Rows[makp.SelectedIndex]["loaiphieu"].ToString() : "";
                sql = "select * from " + user + ".d_loaiphieu where nhom=" + i_nhom;
                sql+=" and loai="+i_loai;
                if (s_phieu.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
				sql+=" and id<>0 order by stt";
			}
            */
            string s_phieuk = "", s_loai = "";
            if (bThua) sql = "select * from " + user + ".d_loaiphieu where id=0";
            else
            {
                string s_phieu = "";
                sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
                if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (i_khudt != 0) sql += " and (khu=0 or khu =" + i_khudt + ")";//binh 210411
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_phieuk += r["phieu"].ToString();
                    s_loai = r["loaiphieu"].ToString();
                }
                string tenfile = (i_loai == 2) ? "d_bucstt" : "d_xuatsdct";
                sql = "select distinct a.phieu from " + xxx + ".d_xuatsdll a," + xxx + "." + tenfile + " b where a.id=b.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (makp.SelectedIndex != -1 && i_loai!=2) sql += " and a.makp=" + int.Parse(makp.SelectedValue.ToString());
                else if (makp.SelectedIndex != -1 && i_loai == 2) sql += " and a.makhoa=" + int.Parse(makp.SelectedValue.ToString());
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    s_phieu += r["phieu"].ToString() + ",";

                sql = "select * from " + user + ".d_loaiphieu where nhom=" + i_nhom;
                sql += " and loai=" + i_loai;
                if (s_phieu != "") sql += " and id not in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                if (s_phieuk.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                sql += " and id<>0 order by stt";
            }
            dtphieu = d.get_data(sql).Tables[0];
            phieu.DataSource = dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
            dtbd = d.get_data("select * from " + user + ".d_dmbd where nhom=" + i_nhom).Tables[0];

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
            b1kho = d.b1kho(s_kho);
            chkAll.Visible = !bBucstt_tronso;
            bTreole_duyetrieng = (i_loai == 2 && bBucstt_tronso) ? d.bTreole_duyetrieng(i_nhom) : false;
            chkTreole.Visible = bTreole_duyetrieng;
            bTreole_duyetrieng = (i_loai == 2 && bBucstt_tronso) ? d.bTreole_duyetrieng(i_nhom) : false;
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{	
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phieu.SelectedIndex==-1) phieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Bỏ";
            discontinuedCol.Width = (bBucstt_tronso && i_loai==2) ? 0 : 20;
			discontinuedCol.ReadOnly=bBucstt_tronso && i_loai==2;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = (bCongdon)?"":(i_loai==4 || bBuhaophi || bThua || i_thuoc==2)?"Số phiếu":"Mã BN";
			TextCol.Width =(bCongdon)?0:60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = (bCongdon)?"":"Họ tên";
			TextCol.Width = (bCongdon || i_loai==4 || bBuhaophi || bThua || i_thuoc==2)?0:150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = (bCongdon || i_loai==4 || bBuhaophi || bThua || i_thuoc==2)?0:60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (bThua || i_thuoc==2)?90:60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = (i_loai==3)?"Kho nhập":(i_loai==2 || bBuhaophi)?"Kho bù":"Kho xuất";
			TextCol.Width = (bCongdon || bThua || i_thuoc==2)?90:50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bCongdon)?360:(bBuhaophi || i_thuoc==2)?310:(i_loai==4)?380:(i_loai==2)?135:170;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "soluongyc";
			TextCol.HeaderText = "Yêu cầu";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
            TextCol.Format = format_soluong;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = (i_loai==2 || bBuhaophi)?"Thực bù":(i_loai==3)?"Thực trả":"Thực xuất";
			TextCol.Width = 55;
            if (file1 == "xxx.d_haophill" && i_loai == 4) TextCol.ReadOnly = !d.bSLDuyet(i_nhom);
            else TextCol.ReadOnly = true;
            /*
			if (i_loai==3 && i_thuoc==1) TextCol.ReadOnly=true;
			else TextCol.ReadOnly=!d.bSLDuyet(i_nhom);
             * */
            TextCol.Format = format_soluong;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "mabd";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			if (i_loai==2 || bBuhaophi)
			{
				TextCol=new FormattableTextBoxColumn();
				TextCol.MappingName = "coso";
				TextCol.HeaderText = "Cơ số";
				TextCol.Width = 35;
				TextCol.ReadOnly=true;
                TextCol.Format = format_soluong;
				TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);
			}
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ton";
			TextCol.HeaderText = (i_loai==3 && i_thuoc==1)?"":"Tồn";
			TextCol.Width = (i_loai==3 && i_thuoc==1)?0:35;
			TextCol.ReadOnly=true;
            TextCol.Format = format_soluong;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			if (bThua)
			{
				TextCol=new FormattableTextBoxColumn();
				TextCol.MappingName = "handung";
				TextCol.HeaderText = "Date";
				TextCol.Width = 50;
				TextCol.ReadOnly=false;
				TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new FormattableTextBoxColumn();
				TextCol.MappingName = "losx";
				TextCol.HeaderText = "Lô SX";
				TextCol.Width = 80;
				TextCol.ReadOnly=false;
				TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new FormattableTextBoxColumn();
				TextCol.MappingName = "giamua";
				TextCol.HeaderText = "Đơn giá";
				TextCol.Width = 80;
				TextCol.ReadOnly=false;
                TextCol.Format = d.format_dongia(i_nhom);
				TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new FormattableTextBoxColumn();
				TextCol.MappingName = "giaban";
				TextCol.HeaderText = "Giá bán";
				TextCol.Width = 80;
				TextCol.ReadOnly=false;
                TextCol.Format = d.format_giaban(i_nhom);
				TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);
			}
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
                if (decimal.Parse(dataGrid1[e.Row, 9].ToString()) == 0) e.ForeBrush = new SolidBrush(Color.Red);
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			try
			{
				if (i_loai==3 && i_thuoc==1) return;
				if (dataGrid1.CurrentCell.ColumnNumber==9 && d.bSLDuyet(i_nhom))
				{
					i_mabd=int.Parse(dataGrid1[i_row,10].ToString());
					i_makho=int.Parse(dataGrid1[i_row,11].ToString());
					i_manguon=int.Parse(dataGrid1[i_row,12].ToString());
					d_soluongcu=decimal.Parse(dt.Rows[i_row]["soluongcu"].ToString());
					d_soluong=decimal.Parse(dataGrid1[i_row,9].ToString());
					if (bSlthuc_yeucau)
					{
						if (d_soluong>decimal.Parse(dt.Rows[i_row]["soluongyc"].ToString()))
						{
							MessageBox.Show(lan.Change_language_MessageText("Số lượng phát không được lớn hơn số lượng yêu cầu !(")+dt.Rows[i_row]["soluongyc"].ToString()+")",d.Msg);
							dataGrid1[i_row,9]=decimal.Parse(dt.Rows[i_row]["soluongyc"].ToString());
						}
					}
					d_soluongton=d.get_slton_nguon(dtton,i_makho,i_mabd,i_manguon,d_soluongcu);
					if (d_soluong>d_soluongton)
					{
						MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",d.Msg);
						dataGrid1[i_row,9]=d_soluongcu;
					}
					else
					{
						d.updrec_tonkho_nguon(dtton,i_makho,i_mabd,i_manguon,d_soluong-d_soluongcu,"-");
						dt.Rows[i_row]["soluongcu"]=d_soluong.ToString();
						dtton.AcceptChanges();
						dt.AcceptChanges();
					}
					DataRow r=d.getrowbyid(dtton,"makho="+i_makho+" and manguon="+i_manguon+" and id="+i_mabd);
					if (r!=null) dt.Rows[i_row]["ton"]=r["soluong"].ToString();
					if (d_soluong==0) dt.Rows[i_row]["chon"]=true;
					i_row=dataGrid1.CurrentRowIndex;
				}
			}
			catch{}
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void load_grid(string tu,string den,int iMakp)
		{
            bCont=bTreole=false;
			if (i_loai==4 || bBuhaophi) //hao phi
			{
				sql="select a.id,a.sophieu as mabn,'"+s_tenkp+"' as hoten,0 as mavaovien,0 as maql,0 as idkhoa,f.doituong,g.ten as tenkho,d.ma,";
				sql+="trim(d.ten)||' '||d.hamluong||' ['||d.ma||']' as ten,d.tenhc,d.dang,trunc(b.slyeucau-b.slthuc,"+soluong_le+") as soluong,trunc(b.slyeucau-b.slthuc,"+soluong_le+") as soluongcu,trunc(b.slyeucau-b.slthuc,"+soluong_le+") as soluongyc,0001.00 as sltd,";
				sql+="b.madoituong,b.makho,b.mabd,c.makp,c.makhoa,c.phieu,b.stt,a.idduyet,b.manguon,h.ten as tennguon,b.tutruc,'xx/xx/xxxx' as ngay,0000000.00 as coso,0000000.00 as ton,d.phatsau,d.hamluong";
				sql+=",d.dongia as giamua,d.giaban,'0000' as handung,' ' as losx,0 as tt,to_char(c.ngay,'dd/mm/yyyy') as ngayylenh,0 as treo,0 as choduyet, 0 as traituyen ";
                sql += ", d.gia_bh,c.loaipttt";//gam 09/08/2011
                sql += ",'' as mabs";//gam 27/02/2012
                sql += " from " + file1 + " a," + file2 + " b,xxx.d_duyet c," + user + ".d_dmbd d," + user + ".d_doituong f," + user + ".d_dmkho g," + user + ".d_dmnguon h";
				sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and b.madoituong=f.madoituong and b.makho=g.id and b.manguon=h.id";
                if (i_khudt != 0) sql += " and (g.khu=0 or g.khu =" + i_khudt + ")";//binh 210411
				sql+=" and c.done<>0 and b.slyeucau>b.slthuc and c.nhom="+i_nhom+" and c.loai in (2,4) and c.makhoa="+iMakp;
				sql+=" and c.ngay between to_date('"+tu+"','"+f_ngay+"') and to_date('"+den+"','"+f_ngay+"')";
				if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (bBuhaophi) sql+=" and b.tutruc=1";
				else sql+=" and b.tutruc=0";
				if (s_phieu.Trim().Trim(',')!="") sql+=" and c.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
				sql+=" order by c.makp,a.id,b.stt";
			}
			else
			{
                sql = "";
                bCont = (bTreole_duyetrieng) ? chkTreole.Checked : (i_loai == 2 && bBucstt_tronso);
                bTreole = (bTreole_duyetrieng) ? chkTreole.Checked : false;
                if (bCont)
				{
					sql=" select a.id,a.mabn,e.hoten,a.mavaovien,a.maql,a.idkhoa,f.doituong,g.ten as tenkho,d.ma,";
                    sql += " trim(d.ten)||' '||d.hamluong||' ['||d.ma||']' as ten,d.tenhc,d.dang,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluong,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongcu,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongyc,0001.00 sltd,";
					sql+=" b.madoituong,b.makho,b.mabd,c.makp,c.makhoa,c.phieu,b.stt,a.idduyet,b.manguon,h.ten as tennguon,0 as tutruc,'xx/xx/xxxx' as ngay,0000000.00 as coso,0000000.00 as ton,d.phatsau,d.hamluong";
                    sql += ",d.dongia as giamua,d.giaban,'0000' as handung,' ' as losx,0 as tt,to_char(c.ngay,'dd/mm/yyyy') as ngayylenh,1 as treo,0 as choduyet,  case when a.traituyen is null then 0 else a.traituyen end as traituyen ";
                    sql += ", d.gia_bh,c.loaipttt";//gam 09/08/2011
                    sql += ",'' as mabs";//gam 27/02/2012
                    sql += " from xxx.d_xtutrucll a," + user + ".d_treoduyet b,xxx.d_duyet c," + user + ".d_dmbd d," + user + ".btdbn e," + user + ".d_doituong f," + user + ".d_dmkho g," + user + ".d_dmnguon h";
					sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and a.mabn=e.mabn and b.madoituong=f.madoituong and b.makho=g.id and b.manguon=h.id";
                    sql += " and c.done<>0 and b.slyeucau>b.slthuc and c.nhom=" + i_nhom;
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu =" + i_khudt + ")";//binh 210411
                    if (bIntheocstt) sql += " and c.makp=" + iMakp;
                    else sql+=" and c.makhoa=" + iMakp;
                    if (bTreole)
                    {
                        sql += " and c.ngay between to_date('" + tu + "','" + f_ngay + "') and to_date('" + den + "','" + f_ngay + "')";
                        if (s_phieu != "") sql += " and c.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                    }
					sql+=" union all ";
                    sql += " select a.id,a.sophieu as mabn,f.doituong as hoten,0 as mavaovien,0 as maql,0 as idkhoa,f.doituong,g.ten as tenkho,d.ma,";
                    sql += " trim(d.ten)||' '||d.hamluong||' ['||d.ma||']'  as ten,d.tenhc,d.dang,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluong,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongcu,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongyc,0001.00 sltd,";
                    sql += " b.madoituong,b.makho,b.mabd,c.makp,c.makhoa,c.phieu,b.stt,a.idduyet,b.manguon,h.ten as tennguon,0 as tutruc,'xx/xx/xxxx' as ngay,0000000.00 as coso,0000000.00 as ton,d.phatsau,d.hamluong";
                    sql += ",d.dongia as giamua,d.giaban,'0000' as handung,' ' as losx,0 as tt,to_char(c.ngay,'dd/mm/yyyy') as ngayylenh,1 as treo,0 as choduyet, 0 as traituyen ";
                    sql += ", d.gia_bh,c.loaipttt";//gam 09/08/2011
                    sql += ",'' as mabs";//gam 27/02/2012
                    sql += " from xxx.d_haophill a," + user + ".d_treoduyet b,xxx.d_duyet c," + user + ".d_dmbd d," + user + ".d_doituong f," + user + ".d_dmkho g," + user + ".d_dmnguon h";
                    sql += " where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and b.madoituong=f.madoituong and b.makho=g.id and b.manguon=h.id";
                    sql += " and c.done<>0 and b.slyeucau>b.slthuc and c.nhom=" + i_nhom;
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu =" + i_khudt + ")";//binh 210411
                    if (bIntheocstt) sql += " and c.makp=" + iMakp;
                    else sql += " and c.makhoa=" + iMakp;
                    if (bTreole)
                    {
                        sql += " and c.ngay between to_date('" + tu + "','" + f_ngay + "') and to_date('" + den + "','" + f_ngay + "')";
                        if (s_phieu != "") sql += " and c.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                    }
				}
                if (!bTreole)
                {
                    if (sql != "") sql += " union all ";
                    sql += " select a.id,";
                    if (bThua || i_thuoc == 2) sql += " a.mabn,'" + s_tenkp + "' as hoten,";
                    else sql += " a.mabn,e.hoten,";
                    sql += "a.mavaovien,a.maql,a.idkhoa,f.doituong,g.ten as tenkho,d.ma,";
                    sql += "trim(d.ten)||' '||d.hamluong||' ['||d.ma||']'  as ten,d.tenhc,d.dang,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluong,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongcu,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongyc,0001.00 as sltd,";
                    sql += "b.madoituong,b.makho,b.mabd,c.makp,c.makhoa,c.phieu,b.stt,a.idduyet,b.manguon,h.ten as tennguon,0 as tutruc,";
                    if (i_loai == 3) sql += "to_char(b.ngay,'dd/mm/yyyy') as ngay ";
                    else sql += "'xx/xx/xxxx' as ngay ";
                    sql += ",0000000.00 as coso,0000000.00 as ton,d.phatsau,d.hamluong";
                    sql += ",d.dongia as giamua,d.giaban,'0000' as handung,' ' as losx,0 as tt,";
                    if (i_loai == 3) sql += "to_char(b.ngay,'dd/mm/yyyy') as ngayylenh,";
                    else sql += "to_char(c.ngay,'dd/mm/yyyy') as ngayylenh,";
                    sql += "0 as treo,";
                    if (i_loai == 1) sql += "b.choduyet";
                    else sql+="0 as choduyet";
                    sql += ", case when a.traituyen is null then 0 else a.traituyen end as traituyen ";
                    sql += ", d.gia_bh,c.loaipttt ";//gam 09/08/2011
                    sql += ",k.mabs ";//gam 27/02/2012
                    sql += " from " + file1 + " a inner join " + file2 + " b on a.id=b.id ";
                    //sql+=" inner join " + xxx + ".d_duyet c on a.idduyet=c.id ";
                    sql += " inner join xxx.d_duyet c on a.idduyet=c.id ";
                    sql += " inner join " + user + ".d_dmbd d on b.mabd=d.id ";
                    sql += " left join  " + user + ".btdbn e on a.mabn=e.mabn ";
                    sql += " inner join " + user + ".d_doituong f on b.madoituong=f.madoituong ";
                    sql += " inner join " + user + ".d_dmkho g on b.makho=g.id ";
                    sql += " inner join " + user + ".d_dmnguon h on b.manguon=h.id ";
                    sql += " left join xxx.d_dausinhton k on a.id=k.id ";//gam 27/02/2012
                    sql += " where c.done<>0 and b.slyeucau>b.slthuc ";
                    if (bThua || i_thuoc == 2) sql += " and a.maql=0";
                    else sql += " and a.maql!=0";
                    sql += " and c.nhom=" + i_nhom + " and c.loai=" + i_loai;
                    if (i_loai == 2)
                    {
                        if (bIntheocstt) sql += " and c.makp=" + iMakp;
                        else sql += " and c.makhoa=" + iMakp;
                    }
                    else sql += " and c.makhoa=" + iMakp;
                    if (i_khudt != 0) sql += " and (g.khu=0 or g.khu =" + i_khudt + ")";//binh 210411
                    sql += " and c.ngay between to_date('" + tu + "','" + f_ngay + "') and to_date('" + den + "','" + f_ngay + "')";
                    if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                    if (i_loai == 1) sql += " and b.tutruc=0";
                    if (s_phieu != "") sql += " and c.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                    if (i_loai != 2) sql += " order by a.mabn,a.id,b.stt";
                    if (i_loai == 2) //lay tutruc -> du tru
                    {
                        sql += " and b.idvpkhoa=0";
                        sql += " union all select a.id,a.mabn,e.hoten,a.mavaovien,a.maql,a.idkhoa,f.doituong,g.ten as tenkho,d.ma,";
                        sql += " trim(d.ten)||' '||d.hamluong||' ['||d.ma||']'  as ten,d.tenhc,d.dang,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluong,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongcu,trunc(b.slyeucau-b.slthuc," + soluong_le + ") as soluongyc,0001.00 as sltd,";
                        sql += " b.madoituong,b.makho,b.mabd,c.makp,c.makhoa,c.phieu,b.stt,a.idduyet,b.manguon,h.ten as tennguon,b.tutruc,'xx/xx/xxxx' as ngay,0000000.00 as coso,0000000.00 as ton,d.phatsau,d.hamluong";
                        sql += ",d.dongia as giamua,d.giaban,'0000' as handung,' ' as losx,0 as tt,to_char(c.ngay,'dd/mm/yyyy') as ngayylenh,0 as treo,b.choduyet";
                        //sql+=" from " + xxx + ".d_dutrull a," + xxx + ".d_dutruct b," + xxx + ".d_duyet c," + user + ".d_dmbd d," + user + ".btdbn e," + user + ".d_doituong f," + user + ".d_dmkho g," + user + ".d_dmnguon h";
                        sql += ", case when a.traituyen is null then 0 else a.traituyen end as traituyen ";
                        sql += ", d.gia_bh,c.loaipttt";//gam 09/08/2011
                        sql += ",k.mabs ";//ThanhCuong 15/03/2012
                        sql += " from xxx.d_dutrull a,xxx.d_dutruct b,xxx.d_duyet c," + user + ".d_dmbd d," + 
                            user + ".btdbn e," + user + ".d_doituong f," + user + ".d_dmkho g," + user +".d_dmnguon h";
                        sql += " , xxx.d_dausinhton k";
                        sql += " where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and a.mabn=e.mabn and b.madoituong=f.madoituong and b.makho=g.id and b.manguon=h.id";
                        sql += " and a.id=k.id(+) ";
                        sql += " and c.done<>0 and b.slyeucau>b.slthuc and b.tutruc=1 and c.nhom=" + i_nhom + " and c.loai=1 ";
                        if (bIntheocstt) sql += " and c.makp=" + iMakp;
                        else sql += " and c.makhoa=" + iMakp;
                        sql += " and c.ngay between to_date('" + tu + "','" + f_ngay + "') and to_date('" + den + "','" + f_ngay + "')";
                        if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                        if (s_phieu != "") sql += " and c.phieu in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                        if (i_khudt != 0) sql += " and (g.khu=0 or g.khu =" + i_khudt + ")";//binh 210411
                    }
                }
			}
			//dt=d.get_data(sql).Tables[0];
            dt = m.get_data_mmyy(sql,tu,den,true).Tables[0];
			if (bCongdon)
			{
				dtct=dt.Copy();
				dt.Clear();
				DataRow r2,r3;
				DataRow [] dr;
				foreach(DataRow r4 in dtct.Rows)
				{
					sql="makho="+int.Parse(r4["makho"].ToString())+" and mabd="+int.Parse(r4["mabd"].ToString());
					if (bBucstt_nguon) sql+=" and manguon="+int.Parse(r4["manguon"].ToString());
					if (!d.bPhattron_congdondoituong(i_nhom)) sql+=" and madoituong="+int.Parse(r4["madoituong"].ToString());
					r2=d.getrowbyid(dt,sql);
					if (r2==null)
					{
						r3=dt.NewRow();
						r3["makho"]=r4["makho"].ToString();
						r3["tenkho"]=r4["tenkho"].ToString();
						r3["makp"]=r4["makp"].ToString();
						r3["makhoa"]=r4["makhoa"].ToString();
						r3["manguon"]=r4["manguon"].ToString();
						r3["tennguon"]=r4["tennguon"].ToString();
						r3["mabd"]=r4["mabd"].ToString();
						r3["ma"]=r4["ma"].ToString();
						r3["ten"]=r4["ten"].ToString();
						r3["tenhc"]=r4["tenhc"].ToString();
						r3["dang"]=r4["dang"].ToString();
						r3["madoituong"]=r4["madoituong"].ToString();
						r3["tutruc"]=r4["tutruc"].ToString();
						r3["coso"]=r4["coso"].ToString();
						r3["ton"]=r4["ton"].ToString();
						r3["phatsau"]=r4["phatsau"].ToString();
						r3["soluong"]=r4["soluong"].ToString();
						r3["ngay"]=r4["ngay"].ToString();
						r3["sltd"]=r4["sltd"].ToString();
						r3["soluongcu"]=r4["soluongcu"].ToString();
						r3["soluongyc"]=r4["soluongyc"].ToString();
						r3["giamua"]=r4["giamua"].ToString();
						r3["giaban"]=r4["giaban"].ToString();
						r3["handung"]=r4["handung"].ToString();
						r3["losx"]=r4["losx"].ToString();
                        r3["choduyet"] = r4["choduyet"].ToString();
                        r3["traituyen"] = (r4["traituyen"].ToString() == "") ? "0" : r4["traituyen"].ToString();
						dt.Rows.Add(r3);
					}
					else
					{
						dr=dt.Select(sql);
						if (dr.Length>0)
						{
							dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r4["soluong"].ToString());
							dr[0]["soluongcu"]=decimal.Parse(dr[0]["soluongcu"].ToString())+decimal.Parse(r4["soluongcu"].ToString());
							dr[0]["soluongyc"]=decimal.Parse(dr[0]["soluongyc"].ToString())+decimal.Parse(r4["soluongyc"].ToString());
						}
					}
				}
			}
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
			DataRow r,r1;
			int tt=1;
			foreach (DataRow row in dt.Rows)
			{
				if (row["phatsau"].ToString()=="1") row["chon"]=true;
				else row["chon"]=false;
				row["tt"]=tt++;
				if (i_loai==2 || bBuhaophi)
				{
					r=d.getrowbyid(dtcstt,"makp="+iMakp+" and mabd="+int.Parse(row["mabd"].ToString()));
					if (r!=null) row["coso"]=r["soluong"].ToString();
				}
				#region kiem tra ton kho
				if ((i_loai==3 && i_thuoc==1)==false)
				{
					d_soluong=decimal.Parse(row["soluong"].ToString());
					i_mabd=int.Parse(row["mabd"].ToString());
					i_makho=int.Parse(row["makho"].ToString());
					i_manguon=int.Parse(row["manguon"].ToString());
					if (i_loai==1 || i_loai==2 || bBuhaophi)
					{
						//sql="soluong>0 and makho="+i_makho+" and id="+i_mabd;
                        sql = "soluong>="+d_soluong+" and makho=" + i_makho + " and id=" + i_mabd;
						sql+=" and manguon="+i_manguon;
						r=d.getrowbyid(dtton,sql);
						if (r==null)
						{
							sql="soluong>="+d_soluong+" and makho="+i_makho+" and ten='"+row["ten"].ToString()+"' and dang='"+row["dang"].ToString()+"' and hamluong='"+row["hamluong"].ToString()+"'";
							if (bBucstt_nguon) sql+=" and manguon="+i_manguon;
							r1=d.getrowbyid(dtton,sql);
							if (r1!=null)
							{
								row["mabd"]=r1["id"].ToString();
								row["ten"]=r1["ten"].ToString();
								row["dang"]=r1["dang"].ToString();
								row["manguon"]=r1["manguon"].ToString();
								i_mabd=int.Parse(row["mabd"].ToString());
								i_manguon=int.Parse(row["manguon"].ToString());
							}
							else //tuong duong
							{
								bool bFound=false;
								foreach(DataRow r2 in d.get_data("select mabd,soluong from "+user+".d_dmbdtd where id="+int.Parse(row["mabd"].ToString())).Tables[0].Rows)
								{
									d_soluong=decimal.Parse(row["soluong"].ToString())*decimal.Parse(r2["soluong"].ToString());
									sql="makho="+i_makho+" and id="+int.Parse(r2["mabd"].ToString())+" and soluong>="+d_soluong;
									if (bBucstt_nguon) sql+=" and manguon="+i_manguon;
									r1=d.getrowbyid(dtton,sql);
									if (r1!=null)
									{
										row["mabd"]=r1["id"].ToString();
										row["ten"]=r1["ten"].ToString();
										row["dang"]=r1["dang"].ToString();
										row["manguon"]=r1["manguon"].ToString();
										row["soluong"]=d_soluong;
										row["sltd"]=r2["soluong"].ToString();
										i_mabd=int.Parse(row["mabd"].ToString());
										i_manguon=int.Parse(row["manguon"].ToString());
										bFound=true;
										break;
									}
								}
								//hoatchat - hamluong - dvt 
								if (!bFound && row["tenhc"].ToString()!="")
								{
									d_soluong=decimal.Parse(row["soluong"].ToString());
									sql="soluong>="+d_soluong+" and makho="+i_makho+" and tenhc='"+row["tenhc"].ToString()+"'"+" and dang='"+row["dang"].ToString()+"' and hamluong='"+row["hamluong"].ToString()+"'";
									if (bBucstt_nguon) sql+=" and manguon="+i_manguon;
									r1=d.getrowbyid(dtton,sql);
									if (r1!=null)
									{
										row["mabd"]=r1["id"].ToString();
										row["ten"]=r1["ten"].ToString();
										row["dang"]=r1["dang"].ToString();
										row["manguon"]=r1["manguon"].ToString();
										i_mabd=int.Parse(row["mabd"].ToString());
										i_manguon=int.Parse(row["manguon"].ToString());
									}
								}
							}
						}
					}
					d_soluongcu=0;//decimal.Parse(row["soluongcu"].ToString());
					d_soluongton=d.get_slton_nguon(dtton,i_makho,i_mabd,i_manguon,d_soluongcu);
					if (d_soluong>d_soluongton) row["soluong"]=Math.Max(d_soluongton,0);
						d.updrec_tonkho_nguon(dtton,i_makho,i_mabd,i_manguon,d_soluong-d_soluongcu,"-");
					dtton.AcceptChanges();
					if (row["soluong"].ToString().Trim() =="" || decimal.Parse(row["soluong"].ToString().Trim())==0) row["chon"]=true;
					r=d.getrowbyid(dtton,"makho="+i_makho+" and manguon="+i_manguon+" and id="+i_mabd);
					if (r!=null) row["ton"]=r["soluong"].ToString();
				}
				#endregion
			}
            if (i_loai == 2 && bBucstt_tronso && !bCongdon)
            {
                ds.Clear();
                DataRow r5, r6, r7;
                DataRow[] dr;

                #region sum
                foreach (DataRow r4 in dt.Rows)
                {
                    r4["chon"] = true;
                    sql = "id=" + int.Parse(r4["mabd"].ToString()) + " and makho=" + int.Parse(r4["makho"].ToString());
                    if (bBucstt_nguon) sql += " and manguon=" + int.Parse(r4["manguon"].ToString());
                    r5 = d.getrowbyid(dtton, sql);
                    if (r5 != null)
                    {
                        r6 = d.getrowbyid(ds.Tables[0], sql);
                        if (r6 == null)
                        {
                            r7 = ds.Tables[0].NewRow();
                            r7["makho"] = r4["makho"].ToString();
                            r7["manguon"] = r4["manguon"].ToString();
                            r7["id"] = r4["mabd"].ToString();
                            r7["slyeucau"] = r4["soluong"].ToString();
                            r7["slphat"] = r5["slphat"].ToString();
                            r7["min"] = r4["soluong"].ToString();
                            ds.Tables[0].Rows.Add(r7);
                        }
                        else
                        {
                            dr = ds.Tables[0].Select(sql);
                            if (dr.Length > 0)
                            {
                                dr[0]["min"] = Math.Min(decimal.Parse(dr[0]["min"].ToString()), decimal.Parse(r4["soluong"].ToString()));
                                dr[0]["slyeucau"] = decimal.Parse(dr[0]["slyeucau"].ToString()) + decimal.Parse(r4["soluong"].ToString());
                            }
                        }
                    }
                }
                #endregion

                double sl = 1;
                foreach (DataRow r4 in ds.Tables[0].Rows)
                {
                    r5 = d.getrowbyid(dtbd, "id=" + decimal.Parse(r4["id"].ToString()));
                    sl = (r5 != null) ? double.Parse(r5["soluong"].ToString()) : 1;
                    r4["slyeucau"] = sl * Math.Floor(double.Parse(r4["slyeucau"].ToString()) / double.Parse(r4["slphat"].ToString()));
                    r4["min"] = r4["slyeucau"].ToString();
                }
                string sort = "makho,mabd";
                if (bBucstt_nguon) sql += ",manguon=";
                decimal sum = 0;
                foreach (DataRow r4 in dt.Select("chon=true", sort))
                {
                    sql = "makho=" + int.Parse(r4["makho"].ToString()) + " and id=" + int.Parse(r4["mabd"].ToString());
                    if (bBucstt_nguon) sql += " and manguon=" + int.Parse(r4["manguon"].ToString());
                    dr = ds.Tables[0].Select(sql);
                    if (dr.Length > 0)
                    {
                        sum = Math.Min(decimal.Parse(r4["soluong"].ToString()), decimal.Parse(dr[0]["min"].ToString()));
                        dr[0]["min"] = decimal.Parse(dr[0]["min"].ToString()) - sum;
                        r4["soluong"] = sum;
                        r4["chon"] = false;
                    }
                }
            }
			butLuu.Enabled=dt.Rows.Count!=0;
			dataGrid1.Focus();
			i_row=dataGrid1.CurrentRowIndex;
		}

		private void butLay_Click(object sender, System.EventArgs e)
		{
            frmTuden f=new frmTuden(d,dtkp,dtphieu,i_nhom,int.Parse(makp.SelectedValue.ToString()),i_loai,int.Parse(phieu.SelectedValue.ToString()),s_ngay,bCongdon,bThua,s_kho,s_mmyy,i_userid);
			f.ShowDialog(this);
			if (f.s_tu!="")
			{
				Cursor=Cursors.WaitCursor;
				if (i_loai!=3 && bKiemtra_duyet) d.upd_tonkho(s_mmyy,i_nhom,0);
				o_tu=f.s_tu;o_den=f.s_den;o_makp=f.i_makp;o_phieu=f.i_phieu;s_tenkp=f.s_tenkp;s_phieu=f.s_phieu;o_makhoa=o_makp;
				if (i_loai==3 && i_thuoc==2) dtton=d.get_tutructh_duyet(s_mmyy,s_kho,o_makp);
				else if (i_loai!=3)	dtton=d.get_tonkhoth_duyet(s_mmyy,s_kho);
				if (i_loai==2 && !bBuhaophi)
				{
                    sql = "select distinct makp from xxx.d_duyet ";
					sql+=" where done<>0 and nhom="+i_nhom+" and loai="+i_loai+" and makhoa="+o_makp;
					sql+=" and ngay between to_date('"+o_tu+"','"+f_ngay+"') and to_date('"+o_den+"','"+f_ngay+"')";
					if (s_phieu!="") sql+=" and phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
                    string _makp = "";
                    foreach(DataRow r in m.get_data_mmyy(sql, o_tu, o_den, true).Tables[0].Rows)
                        if (_makp.IndexOf(r["makp"].ToString().PadLeft(3, '0') + ",") != -1) _makp += r["makp"].ToString().PadLeft(3, '0')+",";
                    if (_makp.Trim().Length>4)
					{
						Cursor=Cursors.Default;
						MessageBox.Show(lan.Change_language_MessageText("Không duyệt được vì có nhiều khoa !"),d.Msg);
						return;
					}
				}
				load_grid(o_tu,o_den,o_makp);
				makp.SelectedValue=o_makp;
				phieu.SelectedValue=o_phieu;
                if (dt.Rows.Count == 0)//gam 07/01/2012 nếu chọn phiếu mà không có số liệu thì reset lại table d_danglaysolieu
                {
                    d.del_danglaysolieu(o_makp,o_phieu,s_ngay);
                }
                if (phieu.SelectedIndex == -1) phieu.SelectedIndex = 0;
				Cursor=Cursors.Default;
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (phieu.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn phiếu cần duyệt !"), d.Msg);
                phieu.Focus();
                return;
            }
			if (d.get_duyet(s_mmyy,int.Parse(makp.SelectedValue.ToString()),i_nhom,i_loai,int.Parse(phieu.SelectedValue.ToString()),s_ngay,s_kho))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+"\n"+lan.Change_language_MessageText("Khoa")+" "+makp.Text+"\n"+lan.Change_language_MessageText("Phiếu")+" "+phieu.Text+"\n"+lan.Change_language_MessageText("Đã duyệt !"),d.Msg);
				return;
			}
            if (dt.Select("chon=false and soluong>0", "id,stt").Length == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
                return;
            }
            
            if (i_loai == 1)
            {
                string schoduyet = "", ten = "";
                foreach (DataRow r in dt.Select("chon=false and soluong>0 and choduyet=1", "mabn,ten"))
                {
                    ten = r["ten"].ToString().Trim().PadRight(30, ' ') + " " + r["soluong"].ToString().PadRight(5, ' ') + " " + r["dang"].ToString().Trim();
                    schoduyet += r["mabn"].ToString() + " " + r["hoten"].ToString().PadRight(25, ' ') + " " + ten + "\n";
                }
                if (schoduyet != "")
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Những thuốc sau chờ lãnh đạo duyệt")+"\n\n" + ((schoduyet.Trim().Length > 200) ? schoduyet.Trim().Substring(0, 200) + "..." : schoduyet.Trim()) + "\n"+lan.Change_language_MessageText("Bạn có đồng ý duyệt ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
            }
            DataSet dstmp = d.get_dangduyet(i_nhom, o_tu, i_loai,o_makp);
            if (dstmp.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Máy")+" " + dstmp.Tables[0].Rows[0]["computer"].ToString() + "\n"+lan.Change_language_MessageText("Đang duyệt - vui lòng chờ !"), d.Msg);
                return;
            }
            int _makp = o_makp;
            d.upd_dangduyet(i_nhom, o_tu, o_den, i_loai,_makp);
			Cursor=Cursors.WaitCursor;
            sql = "delete from " + user+s_mmyy + ".d_ngayduyet where nhom=" + i_nhom + " and loai=" + i_loai + " and phieu=" + int.Parse(phieu.SelectedValue.ToString()) + " and makp=" + int.Parse(makp.SelectedValue.ToString()) + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            //if (s_kho != "") sql += " and makho='" + s_kho + "'";
            m.execute_data(sql);
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";s_ravien="";
			if (bBuhaophi) phieu_butruc();
			else
			{
				switch (i_loai)
				{
					case 1: phieu_dutru();
						break;
					case 2: phieu_butruc();
						break;
					case 3: phieu_hoantra();
						break;
					default: phieu_dutru();
						break;
				}
			}
            if (bPhattron) 
            {
                bool bLamTron = (i_loai != 2) || bBucstt_tronso;
                if (bLamTron) f_LamTron(i_loai);
            }
            ////if (bPhattron) //if (bPhattron || bBucstt_tronso)
            ////{            
            ////    //binh 05.03.2014: comment khong dung cach lam tron nay
            ////    if (i_loai == 2 || bBuhaophi)
            ////    {
            ////        d.upd_thucbucstt(s_ngay, i_nhom, i_loai, o_phieu, o_makp, o_makhoa, s_mmyy, (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0);
            ////    }
            ////    else
            ////    {
            ////        if (i_loai != 3)
            ////        {
            ////            sql = "select b.*,c.handung,c.losx,c.manguon,c.nhomcc,c.giamua, b.gia_bh ";
            ////            sql += " from " + user + s_mmyy + ".d_xuatsdll a," + user + s_mmyy + ".d_xuatsdct b," + user + s_mmyy + ".d_theodoi c ";
            ////            sql += " where a.id=b.id and b.sttt=c.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai;
            ////            sql += " and a.phieu=" + o_phieu + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "' and a.makp=" + o_makp;
            ////            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            ////            {
            ////                if (i_loai == 2)
            ////                    d.upd_tonkhoct_thucbucstt(d.delete, s_mmyy, o_makp, decimal.Parse(r["sttt"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), int.Parse(r["mabd"].ToString()), r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()));
            ////                else
            ////                    d.upd_tonkhoct_thucxuat(d.delete, s_mmyy, o_makp, i_loai, 1, decimal.Parse(r["sttt"].ToString()), int.Parse(r["makho"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["mabd"].ToString()), decimal.Parse(r["soluong"].ToString()));
            ////            }
            ////        }
            ////        d.upd_thucxuat(s_ngay, i_nhom, i_loai, o_phieu, o_makp, o_makhoa, s_mmyy, i_thuoc, (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0);
            ////    }
            ////}
			if (i_loai==3 && i_thuoc==2) dtton=d.get_tutructh_duyet(s_mmyy,s_kho,o_makp);
			else if (i_loai!=3)	dtton=d.get_tonkhoth_duyet(s_mmyy,s_kho);
			d.upd_theodoiduyet(s_mmyy,s_ngay,i_nhom,i_loai,o_makp,2);
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
            if (i_khudt != 0) sql += " and (g.khu=0 or g.khu =" + i_khudt + ")";//binh 210411
            DataRow r1;
            string _khoa = "";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                r1 = d.getrowbyid(dt, "makho=" + int.Parse(r["id"].ToString()));
                if (r1 != null)
                {
                    d.upd_daduyet(s_mmyy, i_nhom, s_ngay, o_makhoa, i_loai, o_phieu, int.Parse(r["id"].ToString()),(bTreole)?1:0);
                    if (i_loai == 2)
                    {
                        if (_khoa.IndexOf(o_makhoa.ToString().Trim() + ",") == -1) _khoa += o_makhoa.ToString().Trim() + ",";
                        foreach (DataRow r2 in dt.Select("makhoa not in (" + _khoa.Substring(0, _khoa.Length - 1) + ")"))//makp not in
                            if (_khoa.IndexOf(r2["makp"].ToString().Trim() + ",") == -1)
                            {
                                _khoa += r2["makp"].ToString().Trim() + ",";
                                d.upd_daduyet(s_mmyy, i_nhom, s_ngay, int.Parse(r2["makp"].ToString()), i_loai, o_phieu, int.Parse(r["id"].ToString()), (bTreole) ? 1 : 0);
                            }
                    }
                }
            }
            d.del_dangduyet(i_nhom, o_tu, o_den, i_loai,_makp);
            d.del_danglaysolieu(o_makp, o_phieu, s_ngay);//gam 07/01/2012
			load_grid(o_tu,o_den,o_makp);
			bOk=true;
            itable = d.tableid(s_mmyy, "d_ngayduyet");
            d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
            d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", i_nhom.ToString() + "^" + i_loai.ToString() + "^" + o_makhoa.ToString() + "^" + s_ngay + "^0^" + o_phieu.ToString() + "^" + s_kho + "^0");
			Cursor=Cursors.Default;
			butLuu.Enabled=false;
			if (s_ravien!="")
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện")+"\n"+s_ravien+"\n"+lan.Change_language_MessageText("không thực hiện được !"),d.Msg);
			if (bTinnhan)
			{
				DataRow r=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null)
				{
					if (r["computer"].ToString()!="")
						d.netsend(d.sDomain(i_nhom),r["computer"].ToString().Trim(),s_noidung+" KHOA "+m.khongdau(makp.Text)+" PHIEU "+m.khongdau(phieu.Text)+" DA DUYET XONG !");
				}
			}
            if (bTinnhan_sound)
            {
                DataRow r = d.getrowbyid(dtkp, "id=" + int.Parse(makp.SelectedValue.ToString()));
                if (r != null)
                {
                    if (r["computer"].ToString() != "")
                        m.upd_tinnhan(r["computer"].ToString().Trim(),"medisoft",1);
                }
            }
            if (chkluuin.Checked) butIn_Click(null, null);
		}

		private void phieu_dutru()
		{
			DataRow r2;
			bool bFound=false,bRavien=false;
			if (i_loai==1 && bKiemtra)
			{
				r2=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r2!=null)
				{
					sql="select maql from "+user+".xuatvien where makp='"+r2["makp"].ToString()+"'";
					dthoten=d.get_data(sql).Tables[0];
					bFound=true;
				}
			}
			decimal id=0,idduyet=0;           
			DataRow [] dr=dt.Select("chon=false and soluong>0","id,stt");
			for(int i=0;i<dr.Length;i++)
			{
				if (idduyet!=decimal.Parse(dr[i]["id"].ToString()))
				{
					if (bFound)
					{
						r2=d.getrowbyid(dthoten,"maql='"+decimal.Parse(dr[i]["maql"].ToString())+"'");
						if (r2!=null)
						{
							if (s_ravien.IndexOf(dr[i]["mabn"].ToString())==-1) s_ravien+=dr[i]["mabn"].ToString()+";";
							bRavien=true;
						}
						else bRavien=false;
					}
					if (!bRavien)
					{
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
						idduyet=decimal.Parse(dr[i]["id"].ToString());
						id=d.get_id_xuatsd;
                        d.upd_xuatsdll(s_mmyy, id, i_nhom, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, i_loai, o_phieu, int.Parse(dr[i]["makp"].ToString()), i_userid, idduyet, i_thuoc, int.Parse(dr[i]["makhoa"].ToString()), (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0, (bPhattron) ? 1 : 0, "", dr[i]["ngayylenh"].ToString(), int.Parse(dr[i]["loaipttt"].ToString() == "" ? "0" : dr[i]["loaipttt"].ToString()),"");//gam 09/09/2011
                        //
                        d.execute_data("update " + user + s_mmyy + ".d_xuatsdll set traituyen=" + dr[i]["traituyen"].ToString() + " where id=" + id);
                        //
                        sql = "select a.*,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,t.gianovat,";
                        sql += "d.phattron,";//Thuy 27.12.2011
                        if (bGiaban) sql += "d.giaban,";
                        else sql += "t.giaban,";
                        sql+="t.tyle_ggia,t.st_ggia,b.ten as tennguon,c.ten as tennhomcc ";
                        //binh 290611
                        if (m.bGia_bh_quydinh)
                        {
                            if (m.bLaygiamua_khi_giabh_0_giabh_nho_giamua)//gia_bh > gia mua --> lay gia_mua lam gia bh
                            {
                                sql += ",case when d.gia_bh > 0 and t.giamua>d.gia_bh then d.gia_bh else t.giamua end as gia_bh ";
                            }
                            else
                            {
                                //luon lay gia_bh tu d_dmbd
                                sql += ",case when d.gia_bh > 0 then d.gia_bh else t.giamua end as gia_bh ";
                            }
                        }
                        else sql += ", t.giamua as gia_bh ";
                        sql+=" from "+xxx+".d_tonkhoct a,"+xxx+".d_theodoi t,"+user+".d_dmnguon b,"+user+".d_dmnx c,"+user+".d_dmbd d ";
                        sql+=" where a.stt=t.id and t.manguon=b.id and t.nhomcc=c.id and a.mabd=d.id";
                        dtct = d.get_xuatsdct(s_mmyy, dt.Select("chon=false and id='" + idduyet+"'", "stt"), sql, id, idduyet, bPhattron, i_thuoc, i_loai, file2, int.Parse(dr[i]["makp"].ToString()), int.Parse(dr[i]["makhoa"].ToString()), dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, decimal.Parse(dr[i]["sltd"].ToString()), bBuhaophi, dr[i]["ngayylenh"].ToString(),false,int.Parse(dr[i]["traituyen"].ToString()),"");
						s_sttduyet="";
						foreach(DataRow r4 in dtct.Rows) s_sttduyet+=r4["sttduyet"].ToString().Trim()+",";
						d.updrec_xuatsdll(dtll,id,dr[i]["mabn"].ToString(),dr[i]["hoten"].ToString(),s_ngay,o_phieu,int.Parse(dr[i]["makp"].ToString()),idduyet,int.Parse(dr[i]["makhoa"].ToString()));
						d.upd_ngayduyet(s_mmyy,i_nhom,i_loai,o_phieu,int.Parse(dr[i]["makhoa"].ToString()),s_ngay,idduyet,s_kho,s_sttduyet);
                        m.execute_data_mmyy("update xxx.d_duyet set done=2 where id=" + decimal.Parse(dr[i]["idduyet"].ToString()),o_tu,o_den,true);
                        if (s_kho == "") m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()), o_tu, o_den, true);
                        else
                        {
                            foreach (DataRow r4 in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")").Tables[0].Rows)
                                m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()) + " and makho=" + int.Parse(r4["id"].ToString()), o_tu, o_den, true);
                        }
					}
				}
			}
		}

		private void butruc_congdon()
		{
			DataRow [] dr1,dr=dt.Select("chon=false and soluong>0","makho,manguon,madoituong,mabd");
			dt=dtct.Copy();
			dt.Columns.Add("Chon",typeof(bool));
			foreach(DataRow r in dt.Rows) r["chon"]=true;
			bool congdondoituong=d.bPhattron_congdondoituong(i_nhom);
			foreach(DataRow r in dr)
			{
				sql="makho="+int.Parse(r["makho"].ToString())+" and mabd="+int.Parse(r["mabd"].ToString());
				if (bBucstt_nguon) sql+=" and manguon="+int.Parse(r["manguon"].ToString());
				if (!congdondoituong) sql+=" and madoituong="+int.Parse(r["madoituong"].ToString());
				d_soluong=decimal.Parse(r["soluong"].ToString());
				foreach(DataRow r1 in dt.Select(sql,"id"))
				{
					d_soluongcu=Math.Min(decimal.Parse(r1["soluong"].ToString()),d_soluong);
					if (d_soluongcu>0)
					{
						r1["soluong"]=d_soluongcu.ToString();
						r1["chon"]=false;
						d_soluong-=d_soluongcu; 
					}
				}
				if (d_soluong>0)
				{
					sql+=" and chon=false";
					dr1=dt.Select(sql,"id");
					if (dr1.Length>0) dr1[0]["soluong"]=decimal.Parse(dr1[0]["soluong"].ToString())+d_soluong;
				}
			}
			dt.AcceptChanges();
		}

		private void phieu_butruc()
		{
			if (bCongdon) butruc_congdon();
			decimal id=0,idduyet=0;
			DataRow [] dr=dt.Select("chon=false and soluong>0","id,stt");
			for(int i=0;i<dr.Length;i++)
			{
				if (idduyet!=decimal.Parse(dr[i]["id"].ToString()))
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
					idduyet=decimal.Parse(dr[i]["id"].ToString());
					id=d.get_id_xuatsd;
                    d.upd_xuatsdll(s_mmyy, id, i_nhom, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, i_loai, o_phieu, int.Parse(dr[i]["makp"].ToString()), i_userid, idduyet, i_thuoc, int.Parse(dr[i]["makhoa"].ToString()), (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0, (bPhattron) ? 1 : 0, (chkTreole.Checked) ? "treophanle" : "", dr[i]["ngayylenh"].ToString(),0,"");
                    //
                    d.execute_data("update " + user + s_mmyy + ".d_xuatsdll set traituyen=" + dr[i]["traituyen"].ToString() + " where id=" + id);
                    //
                    sql = "select a.*,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,"; 
                    sql += "d.phattron,";//Thuy 27.12.2011
                    if (bGiaban) sql += "d.giaban,";
                    else sql += "t.giaban,";
                    sql += "t.tyle_ggia,t.st_ggia,b.ten as tennguon,c.ten as tennhomcc ";
                    //binh 290611
                    if (m.bGia_bh_quydinh) sql += ",case when d.gia_bh > 0 and t.giamua>d.gia_bh then d.gia_bh else t.giamua end as gia_bh ";
                    else sql += ", t.giamua as gia_bh ";
                    sql+=" from "+xxx+".d_tonkhoct a,"+xxx+".d_theodoi t,"+user+".d_dmnguon b,"+user+".d_dmnx c,"+user+".d_dmbd d";
                    sql+=" where a.stt=t.id and t.manguon=b.id and t.nhomcc=c.id and a.mabd=d.id";                    
                    dtct = d.get_xuatsdct(s_mmyy, dt.Select("chon=false and id='" + idduyet+"'", "stt"), sql, id, idduyet, bPhattron, i_thuoc, i_loai, file2, int.Parse(dr[i]["makp"].ToString()), int.Parse(dr[i]["makhoa"].ToString()), dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, decimal.Parse(dr[i]["sltd"].ToString()), bBuhaophi, dr[i]["ngayylenh"].ToString(),bTreole,int.Parse(dr[i]["traituyen"].ToString()),"");
                    s_sttduyet = ""; sql = (chkTreole.Checked) ? "true" : "treo=0";
                    foreach (DataRow r4 in dtct.Select(sql)) s_sttduyet += r4["sttduyet"].ToString().Trim() + ",";
					d.updrec_xuatsdll(dtll,id,dr[i]["mabn"].ToString(),dr[i]["hoten"].ToString(),s_ngay,o_phieu,int.Parse(dr[i]["makp"].ToString()),idduyet,int.Parse(dr[i]["makhoa"].ToString()));
					d.upd_ngayduyet(s_mmyy,i_nhom,i_loai,o_phieu,(bIntheocstt)?int.Parse(dr[i]["makp"].ToString()):int.Parse(dr[i]["makhoa"].ToString()),s_ngay,(s_sttduyet!="")?idduyet:0,s_kho,s_sttduyet);
                    m.execute_data_mmyy("update xxx.d_duyet set done=2 where id=" + decimal.Parse(dr[i]["idduyet"].ToString()),o_tu,o_den,true);
                    if (s_kho == "") m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()), o_tu, o_den, true);
                    else
                    {
                        foreach (DataRow r4 in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")").Tables[0].Rows)
                            m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()) + " and makho=" + int.Parse(r4["id"].ToString()), o_tu, o_den, true);
                    }
					o_makhoa=int.Parse(dr[i]["makhoa"].ToString());
					o_makp=int.Parse(dr[i]["makp"].ToString());
				}
			}
            if (bBucstt_tronso)
            {
                foreach (DataRow r4 in dt.Select("treo=1"))
                    d.execute_data("update " + user + ".d_treoduyet set slthuc=slthuc+" + decimal.Parse(r4["soluong"].ToString()) + " where id=" + decimal.Parse(r4["id"].ToString()) + " and stt=" + int.Parse(r4["stt"].ToString()));// + " and slthuc=0");
                if (!bTreole)
                {
                    foreach (DataRow r4 in dt.Select("chon=true or soluongyc<>soluong"))
                    {
                        //d.execute_data("update " + user + ".d_treoduyet set slthuc=0 where id=" + decimal.Parse(r4["id"].ToString()) + " and stt=" + int.Parse(r4["stt"].ToString()));// + " and slthuc<>0");
                        d.upd_treoduyet(decimal.Parse(r4["id"].ToString()), int.Parse(r4["stt"].ToString()), int.Parse(r4["madoituong"].ToString()), int.Parse(r4["makho"].ToString()), int.Parse(r4["mabd"].ToString()), decimal.Parse(r4["soluongyc"].ToString()), (decimal.Parse(r4["soluongyc"].ToString()) == decimal.Parse(r4["soluong"].ToString())) ? 0 : decimal.Parse(r4["soluong"].ToString()), int.Parse(r4["manguon"].ToString()));
                        d.execute_data_mmyy("update xxx.d_xtutrucct set slthuc=" + decimal.Parse(r4["soluongyc"].ToString()) + " where id=" + decimal.Parse(r4["id"].ToString()) + " and stt=" + int.Parse(r4["stt"].ToString()), o_tu, o_den, true);
                    }
                }
            }
		}

		private void phieu_hoantra()
		{
            if (i_thuoc==2) phieu_hoantrataisan();
			else if (bThua) phieu_hoantrathua();
			else
			{
				DataRow r2;
				bool bFound=false,bRavien=false;
				if (bKiemtra)
				{
					r2=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
					if (r2!=null)
					{
						sql="select maql from "+user+".xuatvien where makp='"+r2["makp"].ToString()+"'";
						dthoten=d.get_data(sql).Tables[0];
						bFound=true;
					}
				}
				DataSet dstonct=new DataSet();
				s_min="";s_max="";
				foreach(DataRow r in dt.Rows)
				{
					s_min=(s_min=="")?r["ngay"].ToString():d.MinNgay(s_min,r["ngay"].ToString());
					s_max=(s_max=="")?r["ngay"].ToString():d.MaxNgay(s_max,r["ngay"].ToString());
				}
				DateTime dt1=d.StringToDate(s_min).AddDays(-d.iNgaykiemke);
				DateTime dt2=d.StringToDate(s_max).AddDays(d.iNgaykiemke);
				int y1=dt1.Year,m1=dt1.Month;
				int y2=dt2.Year,m2=dt2.Month;
				int tu,den,be=0;
				string mmyy="";
				for(int i=y1;i<=y2;i++)
				{
					tu=(i==y1)?m1:1;
					den=(i==y2)?m2:12;
					for(int j=tu;j<=den;j++)
					{
						mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
						if (d.bMmyy(mmyy))
						{
                            sql="select a.mabn,a.mavaovien,a.maql,to_char(a.ngayylenh,'dd/mm/yyyy') as ngay,b.*,t.manguon,";
                            sql+=" t.nhomcc,t.handung,t.losx,t.giamua,t.gianovat,t.giaban,t.tyle_ggia,t.st_ggia,c.ten as tennguon,";
                            sql+=" d.ten as tennhomcc,' ' as doituong, t.gianovat, b.makho ";
                            sql += ", b.gia_bh, e.phattron  ";
                            sql+=" from "+user+mmyy+".d_xuatsdll a,"+user+mmyy+".d_xuatsdct b,"+user+".d_dmbd e,"+user+".d_dmnguon c,"+user+".d_dmnx d,"+user+mmyy+".d_theodoi t ";
                            sql += " where a.id=b.id and b.mabd = e.id and b.sttt=t.id and a.loai in (1,2) and t.manguon=c.id and t.nhomcc=d.id ";
                            if (!bKhoasau_hoantra) sql += " and a.makp=" + o_makp;
                            sql+=" and a.ngayylenh between to_date('" + s_min + "','" + f_ngay + "') and to_date('" + s_max + "','" + f_ngay + "')";
							if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
							sql+=" order by b.sttt";
							if (be==0) dstonct=d.get_data(sql);
							else dstonct.Merge(d.get_data(sql));
							be++;
						}
					}
				}
				DataTable tonct=dstonct.Tables[0];
				decimal id=0,idduyet=0;
				DataRow [] dr=dt.Select("chon=false and soluong>0","id,stt");
				for(int i=0;i<dr.Length;i++)
				{
					if (idduyet!=decimal.Parse(dr[i]["id"].ToString()))
					{
						if (bFound)
						{
							r2=d.getrowbyid(dthoten,"maql='"+decimal.Parse(dr[i]["maql"].ToString())+"'");
							if (r2!=null)
							{
								if (s_ravien.IndexOf(dr[i]["mabn"].ToString())==-1) s_ravien+=dr[i]["mabn"].ToString()+";";
								bRavien=true;
							}
							else bRavien=false;
						}
						if (!bRavien)
						{
                            d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
							idduyet=decimal.Parse(dr[i]["id"].ToString());
							id=d.get_id_xuatsd;
                            d.upd_xuatsdll(s_mmyy, id, i_nhom, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, i_loai, o_phieu, int.Parse(dr[i]["makp"].ToString()), i_userid, idduyet, i_thuoc, int.Parse(dr[i]["makhoa"].ToString()), (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0, (bPhattron) ? 1 : 0, "", dr[i]["ngayylenh"].ToString(),0,"");
                            //
                            d.execute_data("update " + user + s_mmyy + ".d_xuatsdll set traituyen=" + dr[i]["traituyen"].ToString() + " where id=" + id);
                            //
							s_sttduyet="";
							foreach(DataRow r1 in d.get_xuatsdctht(dt.Select("chon=false and id='"+idduyet+"'","stt"),tonct,id,i_nhom,s_ngay).Rows)
							{
                                if (d.get_data("select * from " + user + s_mmyy + ".d_theodoi where id=" + decimal.Parse(r1["sttt"].ToString())).Tables[0].Rows.Count == 0)
                                    d.upd_theodoi(s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["mabd"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()),0,0);
                                d.upd_xuatsdct(s_mmyy, id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), int.Parse(r1["sttduyet"].ToString()), decimal.Parse(r1["giaban"].ToString()), r1["ngay"].ToString(), decimal.Parse(r1["gia_bh"].ToString()), false);//binh 290611: them giabh, them moi=false
                                //if (!bPhattron)
                                //{
                                    d.upd_thucxuat_stt(s_mmyy, id, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), int.Parse(r1["stt"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["gia_bh"].ToString()));
									d.upd_tonkhoct_thucxuat(d.insert,s_mmyy,int.Parse(dr[i]["makp"].ToString()),i_loai,i_thuoc,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
                                //}
								if (i_thuoc==1)
								{
                                    d.upd_tienthuoc(d.insert, s_mmyy, id, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), r1["ngay"].ToString(), int.Parse(dr[i]["makhoa"].ToString()), i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), (r1["gianovat"].ToString() == "") ? 0 : decimal.Parse(r1["gianovat"].ToString()), int.Parse(dr[i]["traituyen"].ToString()), (r1["gia_bh"].ToString() == "") ? 0 : decimal.Parse(r1["gia_bh"].ToString()),"");//thay s_ngay: thanh r1["ngay"]
									d.upd_theodoicongno(d.delete,dr[i]["mabn"].ToString(),decimal.Parse(dr[i]["mavaovien"].ToString()),decimal.Parse(dr[i]["maql"].ToString()),decimal.Parse(dr[i]["idkhoa"].ToString()),int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
								}
								//d.execute_data("update "+file2+" set slthuc=slthuc+"+decimal.Parse(r1["soluong"].ToString())+" where id="+idduyet+" and stt="+int.Parse(r1["sttduyet"].ToString()));
                                m.execute_data_mmyy("update " + file2 + " set slthuc=slthuc+" + decimal.Parse(r1["soluong"].ToString()) + " where id=" + idduyet + " and stt=" + int.Parse(r1["sttduyet"].ToString()),o_tu,o_den,true);
								s_sttduyet+=r1["sttduyet"].ToString().Trim()+",";
							}
							d.updrec_xuatsdll(dtll,id,dr[i]["mabn"].ToString(),dr[i]["hoten"].ToString(),s_ngay,o_phieu,int.Parse(dr[i]["makp"].ToString()),idduyet,int.Parse(dr[i]["makhoa"].ToString()));
							d.upd_ngayduyet(s_mmyy,i_nhom,i_loai,o_phieu,int.Parse(dr[i]["makp"].ToString()),s_ngay,idduyet,s_kho,s_sttduyet);
							//d.execute_data("update "+xxx+".d_duyet set done=2 where id="+decimal.Parse(dr[i]["idduyet"].ToString()));
                            m.execute_data_mmyy("update xxx.d_duyet set done=2 where id=" + decimal.Parse(dr[i]["idduyet"].ToString()),o_tu,o_den,true);
                            if (s_kho == "") m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()), o_tu, o_den, true);
                            else
                            {
                                foreach (DataRow r4 in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")").Tables[0].Rows)
                                    m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()) + " and makho=" + int.Parse(r4["id"].ToString()), o_tu, o_den, true);
                            }
						}
					}
				}
			}
		}

		private void phieu_hoantrathua()
		{
			DataTable tmp;
			int i_nhomcc=0;
			if (d.bQuanlynhomcc(i_nhom))
			{
				tmp=d.get_data("select * from "+user+".d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];
				i_nhomcc=(tmp.Rows.Count>0)?int.Parse(tmp.Rows[0]["id"].ToString()):0;
			}
			decimal id=0,idduyet=0,sttt;
			decimal d_sotien;
			DataRow [] dr1,dr=dt.Select("chon=false and soluong>0","id,stt");
			for(int i=0;i<dr.Length;i++)
			{
				if (idduyet!=decimal.Parse(dr[i]["id"].ToString()))
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
					idduyet=decimal.Parse(dr[i]["id"].ToString());
					id=d.get_id_xuatsd;
                    d.upd_xuatsdll(s_mmyy, id, i_nhom, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, i_loai, o_phieu, int.Parse(dr[i]["makp"].ToString()), i_userid, idduyet, i_thuoc, int.Parse(dr[i]["makhoa"].ToString()), (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0, (bPhattron) ? 1 : 0, "", dr[i]["ngayylenh"].ToString(),0,"");
					dr1=dt.Select("chon=false and soluong>0 and id="+idduyet,"stt");
					s_sttduyet="";
					for(int j=0;j<dr1.Length;j++)
					{
						d_sotien=decimal.Parse(dr1[j]["soluong"].ToString())*decimal.Parse(dr1[j]["giamua"].ToString());
                        //gam 31/10/2011 them ham get_id_tonkho() --> lấy lại id d_theodoi
                        sttt = get_id_tonkho(s_mmyy,int.Parse(dr1[j]["stt"].ToString()),idduyet);
						if(sttt == 0) sttt=d.get_id_tonkho;
                        d.upd_theodoi(s_mmyy, sttt, int.Parse(dr1[j]["mabd"].ToString()), int.Parse(dr1[j]["manguon"].ToString()), i_nhomcc, dr1[j]["handung"].ToString(), dr1[j]["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(dr1[j]["giamua"].ToString()), decimal.Parse(dr1[j]["giaban"].ToString()), decimal.Parse(dr1[j]["giamua"].ToString()), 0, 0);
                        d.upd_xuatsdct(s_mmyy, id, int.Parse(dr1[j]["stt"].ToString()), sttt, int.Parse(dr1[j]["madoituong"].ToString()), int.Parse(dr1[j]["makho"].ToString()), int.Parse(dr1[j]["mabd"].ToString()), decimal.Parse(dr1[j]["soluong"].ToString()), int.Parse(dr1[j]["stt"].ToString()), decimal.Parse(dr1[j]["giaban"].ToString()), dr[i]["ngayylenh"].ToString(), decimal.Parse(dr1[j]["gia_bh"].ToString()),false);//binh 290611
						if (!bPhattron)
						{
                            d.upd_thucxuat_stt(s_mmyy, id, sttt, int.Parse(dr1[j]["madoituong"].ToString()), int.Parse(dr1[j]["makho"].ToString()), int.Parse(dr1[j]["mabd"].ToString()), decimal.Parse(dr1[j]["soluong"].ToString()), int.Parse(dr1[j]["stt"].ToString()), decimal.Parse(dr1[j]["giaban"].ToString()), decimal.Parse(dr1[j]["gia_bh"].ToString()));
							d.upd_tonkhoct_thucxuat(d.insert,s_mmyy,int.Parse(dr[i]["makp"].ToString()),i_loai,i_thuoc,sttt,int.Parse(dr1[j]["makho"].ToString()),int.Parse(dr1[j]["manguon"].ToString()),int.Parse(dr1[j]["mabd"].ToString()),decimal.Parse(dr1[j]["soluong"].ToString()));
						}
						s_sttduyet+=dr1[j]["stt"].ToString().Trim()+",";
						//d.execute_data("update "+file2+" set slthuc=slthuc+"+decimal.Parse(dr1[j]["soluong"].ToString())+" where id="+idduyet+" and stt="+int.Parse(dr1[j]["stt"].ToString()));
                        m.execute_data_mmyy("update " + file2 + " set slthuc=slthuc+" + decimal.Parse(dr1[j]["soluong"].ToString()) + " where id=" + idduyet + " and stt=" + int.Parse(dr1[j]["stt"].ToString()),o_tu,o_den,true);
					}
					d.updrec_xuatsdll(dtll,id,dr[i]["mabn"].ToString(),dr[i]["hoten"].ToString(),s_ngay,o_phieu,int.Parse(dr[i]["makp"].ToString()),idduyet,int.Parse(dr[i]["makhoa"].ToString()));
					d.upd_ngayduyet(s_mmyy,i_nhom,i_loai,o_phieu,int.Parse(dr[i]["makp"].ToString()),s_ngay,idduyet,s_kho,s_sttduyet);
					//d.execute_data("update "+xxx+".d_duyet set done=2 where id="+decimal.Parse(dr[i]["idduyet"].ToString()));
                    m.execute_data_mmyy("update xxx.d_duyet set done=2 where id=" + decimal.Parse(dr[i]["idduyet"].ToString()),o_tu,o_den,true);
                    if (s_kho == "") m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()), o_tu, o_den, true);
                    else
                    {
                        foreach (DataRow r4 in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")").Tables[0].Rows)
                            m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()) + " and makho=" + int.Parse(r4["id"].ToString()), o_tu, o_den, true);
                    }
				}
			}
		}

        private decimal get_id_tonkho( string d_mmyy,int i_stt,decimal l_idduyet)
        {
            DataTable dtidduyet = new DataTable();
            decimal l_id = 0;
            string asql = "select d.id from " + user + d_mmyy + ".d_hoantrall a inner join " + user + d_mmyy + ".d_hoantract b on a.id=b.id ";
            asql += "inner join xxx.d_xuatsdct c on b.idx=c.id and c.stt=b.sttx inner join xxx.d_theodoi d on c.sttt=d.id ";
            asql += "where b.stt="+i_stt+" and a.idduyet="+l_idduyet;
            try
            {
               
                dtidduyet = d.get_data_mmyy(asql,s_ngay,s_ngay,true).Tables[0];
                if( dtidduyet.Rows.Count > 0)
                {
                    l_id = decimal.Parse(dtidduyet.Rows[0][0].ToString() == "" ? "0" : dtidduyet.Rows[0][0].ToString());
                }
                else l_id = 0;
            }
            catch { l_id = 0; }
            return l_id;
        }
		private void phieu_hoantrataisan()
		{
			decimal id=0,idduyet=0;
			DataRow [] dr=dt.Select("chon=false and soluong>0","id,stt");
			for(int i=0;i<dr.Length;i++)
			{
				if (idduyet!=decimal.Parse(dr[i]["id"].ToString()))
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
					idduyet=decimal.Parse(dr[i]["id"].ToString());
					id=d.get_id_xuatsd;
                    d.upd_xuatsdll(s_mmyy, id, i_nhom, dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, i_loai, o_phieu, int.Parse(dr[i]["makp"].ToString()), i_userid, idduyet, i_thuoc, int.Parse(dr[i]["makhoa"].ToString()), (b1kho) ? int.Parse(s_kho.Substring(0, s_kho.Length - 1)) : 0, (bPhattron) ? 1 : 0, "", dr[i]["ngayylenh"].ToString(),0,"");
					sql="select a.*,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,d.phattron,t.giaban,t.tyle_ggia,t.st_ggia,b.ten as tennguon,c.ten as tennhomcc, t.giamua as gia_bh from "+xxx+".d_tutrucct a,"+user+".d_dmbd d,"+xxx+".d_theodoi t,"+user+".d_dmnguon b,"+user+".d_dmnx c where a.mabd = d.id and a.stt=t.id and t.manguon=b.id and t.nhomcc=c.id and a.makp="+o_makp;
                    dtct = d.get_xuatsdct(s_mmyy, dt.Select("chon=false and id=" + idduyet, "stt"), sql, id, idduyet, bPhattron, i_thuoc, i_loai, file2, int.Parse(dr[i]["makp"].ToString()), int.Parse(dr[i]["makhoa"].ToString()), dr[i]["mabn"].ToString(), decimal.Parse(dr[i]["mavaovien"].ToString()), decimal.Parse(dr[i]["maql"].ToString()), decimal.Parse(dr[i]["idkhoa"].ToString()), s_ngay, decimal.Parse(dr[i]["sltd"].ToString()), bBuhaophi, dr[i]["ngayylenh"].ToString(),false,0,"");
					s_sttduyet="";
					foreach(DataRow r4 in dtct.Rows) s_sttduyet+=r4["sttduyet"].ToString().Trim()+",";
					d.updrec_xuatsdll(dtll,id,dr[i]["mabn"].ToString(),dr[i]["hoten"].ToString(),s_ngay,o_phieu,int.Parse(dr[i]["makp"].ToString()),idduyet,int.Parse(dr[i]["makhoa"].ToString()));
					d.upd_ngayduyet(s_mmyy,i_nhom,i_loai,o_phieu,int.Parse(dr[i]["makp"].ToString()),s_ngay,idduyet,s_kho,s_sttduyet);
					//d.execute_data("update "+xxx+".d_duyet set done=2 where id="+decimal.Parse(dr[i]["idduyet"].ToString()));
                    m.execute_data_mmyy("update xxx.d_duyet set done=2 where id=" + decimal.Parse(dr[i]["idduyet"].ToString()),o_tu,o_den,true);
                    if (s_kho == "") m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()), o_tu, o_den, true);
                    else
                    {
                        foreach (DataRow r4 in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")").Tables[0].Rows)
                            m.execute_data_mmyy("update xxx.d_duyetkho set done=2 where idduyet=" + decimal.Parse(dr[i]["idduyet"].ToString()) + " and makho=" + int.Parse(r4["id"].ToString()), o_tu, o_den, true);
                    }
				}
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    if (tim.Text != "")
                        dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or ten like '%" + tim.Text.Trim() + "%'";
                    else
                        dv.RowFilter = "";
                }
                catch { }
			}
		}

		private void phatsau_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==phatsau && dt.Rows.Count>0)
			{
				if (dt.Select("phatsau=1").Length>0)
				{
					DataRow [] dr=dt.Select("phatsau=1 and soluong>0");
					for(int i=0;i<dr.Length;i++) dr[i]["chon"]=phatsau.Checked;
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(d.bYlenh_cachdung(i_nhom))
			{
				frmYlenh_cd frm=new frmYlenh_cd((makp.SelectedIndex==-1)?-1:int.Parse(makp.SelectedValue.ToString()),i_nhom,i_loai,int.Parse(phieu.SelectedValue.ToString()),s_kho);
				frm.ShowDialog(this);
			}
			else
			{
                frmYlenh frm = new frmYlenh(i_nhom);
				frm.ShowDialog(this);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_title="";
			s_title=(i_loai==2)?"PHIẾU BÙ":((i_loai==3)?"PHIẾU HOÀN TRẢ":(i_loai==4)?"PHIẾU LĨNH HAO PHÍ":"PHIẾU LĨNH");
			frmInphieu f=new frmInphieu(d,dtkp,dtphieu,(makp.SelectedIndex==-1)?-1:int.Parse(makp.SelectedValue.ToString()),(phieu.SelectedIndex==-1)?-1:int.Parse(phieu.SelectedValue.ToString()),s_ngay,s_mmyy,i_nhom,i_loai,s_kho,s_title,false,s_userid,bThua,i_khudt, i_userid );
			f.ShowDialog(this);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			frmDSdutru_duyet f=new frmDSdutru_duyet(d,"",i_nhom,s_mmyy,s_kho);
			f.ShowDialog();
		}

		private void kp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void kp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r=d.getrowbyid(dtkp,"ma='"+kp.Text+"'");
				if (r!=null) makp.SelectedValue=r["id"].ToString();
			}
			catch{}
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == makp && makp.Items.Count > 0)
            {
                string s_loai = "", s_phieu = "";
                kp.Text = dtkp.Rows[makp.SelectedIndex]["ma"].ToString();
                s_loai = dtkp.Rows[makp.SelectedIndex]["loaiphieu"].ToString();
                s_phieu = dtkp.Rows[makp.SelectedIndex]["phieu"].ToString();
                if (bThua) sql = "select * from " + user + ".d_loaiphieu where id=0";
                else
                {
                    sql = "select * from " + user + ".d_loaiphieu where nhom=" + i_nhom;
                    sql += " and loai=" + i_loai;
                    if (s_phieu.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
                    sql += " and id<>0 order by stt";
                }
                dtphieu = d.get_data(sql).Tables[0];
                phieu.DataSource = dtphieu;
            }
		}

		private void frmDuyet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					butLay_Click(sender,e);
					break;
				case Keys.F5:
					butLuu_Click(sender,e);
					break;
				case Keys.F9:
					butIn_Click(sender,e);
					break;
				case Keys.F10:
					butBoqua_Click(sender,e);
					break;
			}
		}

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAll)
            {
                foreach (DataRow r in dt.Rows) r["chon"] = (chkAll.Checked) ? true : false;
                dt.AcceptChanges();
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void butTreoduyet_Click(object sender, EventArgs e)
        {
            if (makp.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"), LibMedi.AccessData.Msg);
                makp.Focus();
                return;
            }
            frmTreoduyet f = new frmTreoduyet(d, dtkp, i_nhom, int.Parse(makp.SelectedValue.ToString()), i_loai, int.Parse(phieu.SelectedValue.ToString()), s_ngay, bCongdon, bThua, s_kho, bIntheocstt, s_mmyy);
            f.ShowDialog(this);
        }

        private void chkluuin_CheckedChanged(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "duyet_luuin", chkluuin.Checked ? "1" : "0");
        }

        private void frmDuyet_FormClosed(object sender, FormClosedEventArgs e)
        {
            d.del_danglaysolieu(System.Environment.MachineName);//o_makp, o_phieu, s_ngay);//gam 07/01/2012
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmHuydanglaysolieu f = new frmHuydanglaysolieu(true);            
            f.ShowDialog();
        }
        //ha
        /// <summary>
        /// Lam tron tu d_xuatsdct--> d_thucxuat (lam tron len: 1.2 -->2) , d_bucstt--> d_thucbucstt (lam tron xuong: 1.85 --> 1)...
        /// </summary>
        /// <param name="aLoaiphieu">1: Linh, 2: Bu, 3: Tra, 4: hao phi</param>
        private void f_LamTron(int aLoaiphieu)
        {
            //Lay thuoc bi lech
            sql = "select b.sttt, b.makho, b.mabd, sum(b.soluong) as soluong  ";
            if (aLoaiphieu == 2)//bu truc
            {
                sql += ", trunc(sum(b.soluong),0) as sllamtron";
                sql += " from " + user + s_mmyy + ".d_xuatsdll a," + user + s_mmyy + ".d_bucstt b," + user + s_mmyy + ".d_theodoi c ";
            }
            else
            {
                sql += ", ceil(sum(b.soluong)) as sllamtron";
                sql += " from " + user + s_mmyy + ".d_xuatsdll a," + user + s_mmyy + ".d_xuatsdct b," + user + s_mmyy + ".d_theodoi c ";
            }
            sql += " where a.id=b.id and b.sttt=c.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai;
            sql += " and a.phieu=" + o_phieu + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "' and a.makp=" + o_makp;
            sql += " group by b.sttt, b.mabd, b.makho";
            DataSet dsThuocle = d.get_data(sql);
            if (dsThuocle != null && dsThuocle.Tables.Count > 0 && dsThuocle.Tables[0].Rows.Count > 0)
            {
                decimal d_slchenhlechle = 0;
                foreach (DataRow drLe in dsThuocle.Tables[0].Select("sllamtron>soluong", "mabd,sttt"))
                {
                    if (aLoaiphieu != 2)
                    {
                        d_slchenhlechle = decimal.Parse(drLe["sllamtron"].ToString()) - decimal.Parse(drLe["soluong"].ToString());
                    }
                    else
                    {
                        d_slchenhlechle = decimal.Parse(drLe["soluong"].ToString()) - decimal.Parse(drLe["sllamtron"].ToString());
                    }
                    if (d_slchenhlechle == 0) continue;
                    //
                    sql = " select b.*,c.handung,c.losx,c.manguon,c.nhomcc,c.giamua, b.gia_bh ";
                    if (aLoaiphieu == 2)//bu truc
                    {
                        sql += " from " + user + s_mmyy + ".d_xuatsdll a," + user + s_mmyy + ".d_bucstt b," + user + s_mmyy + ".d_theodoi c ";
                    }
                    else
                    {
                        sql += " from " + user + s_mmyy + ".d_xuatsdll a," + user + s_mmyy + ".d_xuatsdct b," + user + s_mmyy + ".d_theodoi c ";
                    }
                    sql += " where a.id=b.id and b.sttt=c.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai;
                    sql += " and a.phieu=" + o_phieu + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "' and a.makp=" + o_makp;
                    sql += " and b.sttt=" + drLe["sttt"].ToString() + " and makho=" + drLe["makho"].ToString();
                    sql += " and b.soluong> trunc(b.soluong,0) ";
                    sql += " order by b.soluong ";
                    decimal tmp_slle = 0;
                    foreach (DataRow r0 in d.get_data(sql).Tables[0].Rows)
                    {
                        tmp_slle = Math.Ceiling(decimal.Parse(r0["soluong"].ToString())) - decimal.Parse(r0["soluong"].ToString());
                        tmp_slle = Math.Min(tmp_slle, d_slchenhlechle);                        
                        //tang ton kho
                        if (aLoaiphieu != 3 && aLoaiphieu !=2)
                        {
                            d.upd_tonkhoct_thucxuat(d.insert, s_mmyy, o_makp, i_loai, 1, decimal.Parse(r0["sttt"].ToString()), int.Parse(r0["makho"].ToString()), int.Parse(r0["manguon"].ToString()), int.Parse(r0["mabd"].ToString()), tmp_slle);
                        }
                        else if (aLoaiphieu == 2 && bBucstt_tronso)
                        {
                            d.upd_tonkhoct_thucxuat(d.delete, s_mmyy, o_makp, i_loai, 1, decimal.Parse(r0["sttt"].ToString()), int.Parse(r0["makho"].ToString()), int.Parse(r0["manguon"].ToString()), int.Parse(r0["mabd"].ToString()), tmp_slle);
                        }
                        else
                        {
                            d.upd_tonkhoct_thucxuat(d.delete, s_mmyy, o_makp, i_loai, 1, decimal.Parse(r0["sttt"].ToString()), int.Parse(r0["makho"].ToString()), int.Parse(r0["manguon"].ToString()), int.Parse(r0["mabd"].ToString()), tmp_slle);
                        }
                        if (aLoaiphieu == 2)
                        {
                            sql = " update " + user + s_mmyy + ".d_thucbucstt set soluong=soluong+(" + tmp_slle + ") where id=" + r0["id"].ToString() + " and stt=" + r0["stt"].ToString() + " and mabd=" + r0["mabd"].ToString() + " and sttt=" + r0["sttt"].ToString();
                        }
                        else
                        {
                            sql = " update " + user + s_mmyy + ".d_thucxuat set soluong=soluong+(" + tmp_slle + ") where id=" + r0["id"].ToString() + " and stt=" + r0["stt"].ToString() + " and mabd=" + r0["mabd"].ToString() + " and sttt=" + r0["sttt"].ToString();
                        }
                        d.execute_data(sql);
                        d_slchenhlechle = d_slchenhlechle - tmp_slle;
                        if (d_slchenhlechle <= 0) break;
                    }
                }
            }
        }
	}
}
