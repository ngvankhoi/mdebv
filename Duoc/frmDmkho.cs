using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDmkho : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
        private bool b_New = false;
        private AccessData d;
        private bool bQuanlychinhanh = false;
		private DataTable dt=new DataTable();
        private DataTable dtphieu = new DataTable();
        private DataTable dtloai = new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
		private decimal l_id;
        private int i_nhom, itable, i_userid, i_khu=0;
        private string s_mmyy, user, sql, s_phieu, s_loai, s_khudt = "";
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.CheckBox khott;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox computer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox matat;
		private System.Windows.Forms.CheckBox ketoan;
		private System.Windows.Forms.CheckBox thua;
        private CheckBox dutru;
        private CheckedListBox phieu;
        private CheckedListBox loaiphieu;
        private CheckBox dongy;
        private CheckBox chklocngoaigio;
        private ComboBox khudt;
        private Label label6;
        private int i_chinhanh = 0;
        private ComboBox cbcoso;
        private Label label7;
        private CheckBox chkhaohut;
        private CheckBox chkhide;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmkho(AccessData acc,int nhom,string mmyy,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; s_mmyy = mmyy; i_userid = userid;            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            s_khudt = d.f_get_khudt(i_userid);
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmDmkho(AccessData acc, int nhom, string mmyy, int userid, int _chinhanh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            d = acc; i_nhom = nhom; s_mmyy = mmyy; i_userid = userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            s_khudt = d.f_get_khudt(i_userid);
            i_chinhanh = _chinhanh;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmkho));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.khott = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.computer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.matat = new System.Windows.Forms.TextBox();
            this.ketoan = new System.Windows.Forms.CheckBox();
            this.thua = new System.Windows.Forms.CheckBox();
            this.dutru = new System.Windows.Forms.CheckBox();
            this.phieu = new System.Windows.Forms.CheckedListBox();
            this.loaiphieu = new System.Windows.Forms.CheckedListBox();
            this.dongy = new System.Windows.Forms.CheckBox();
            this.chklocngoaigio = new System.Windows.Forms.CheckBox();
            this.khudt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbcoso = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkhaohut = new System.Windows.Forms.CheckBox();
            this.chkhide = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(466, 450);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(557, 528);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(160, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(190, 446);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(282, 21);
            this.ten.TabIndex = 2;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(207, 528);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 15;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(277, 528);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 16;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(347, 528);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(417, 528);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(487, 528);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(-13, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(32, 446);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 21);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(464, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(512, 446);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(272, 21);
            this.nhomcc.TabIndex = 3;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // khott
            // 
            this.khott.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.khott.Enabled = false;
            this.khott.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khott.Location = new System.Drawing.Point(252, 470);
            this.khott.Name = "khott";
            this.khott.Size = new System.Drawing.Size(96, 22);
            this.khott.TabIndex = 5;
            this.khott.Text = "Kho trung tâm";
            this.khott.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(-7, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Máy :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // computer
            // 
            this.computer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.computer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.computer.Enabled = false;
            this.computer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.computer.Location = new System.Drawing.Point(32, 469);
            this.computer.Name = "computer";
            this.computer.Size = new System.Drawing.Size(218, 21);
            this.computer.TabIndex = 4;
            this.computer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(59, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Mã số :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matat
            // 
            this.matat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.matat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.matat.Enabled = false;
            this.matat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matat.Location = new System.Drawing.Point(112, 446);
            this.matat.Name = "matat";
            this.matat.Size = new System.Drawing.Size(48, 21);
            this.matat.TabIndex = 1;
            this.matat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // ketoan
            // 
            this.ketoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ketoan.Enabled = false;
            this.ketoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketoan.Location = new System.Drawing.Point(32, 493);
            this.ketoan.Name = "ketoan";
            this.ketoan.Size = new System.Drawing.Size(160, 22);
            this.ketoan.TabIndex = 9;
            this.ketoan.Text = "Kế toán không theo dõi";
            this.ketoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // thua
            // 
            this.thua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thua.Enabled = false;
            this.thua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thua.Location = new System.Drawing.Point(354, 470);
            this.thua.Name = "thua";
            this.thua.Size = new System.Drawing.Size(118, 22);
            this.thua.TabIndex = 6;
            this.thua.Text = "Kho hoàn trả thừa";
            this.thua.CheckedChanged += new System.EventHandler(this.thua_CheckedChanged);
            this.thua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // dutru
            // 
            this.dutru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dutru.Enabled = false;
            this.dutru.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dutru.Location = new System.Drawing.Point(169, 493);
            this.dutru.Name = "dutru";
            this.dutru.Size = new System.Drawing.Size(160, 22);
            this.dutru.TabIndex = 10;
            this.dutru.Text = "Hiện thị trong dự trù mua";
            // 
            // phieu
            // 
            this.phieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phieu.CheckOnClick = true;
            this.phieu.Enabled = false;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(479, 3);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(305, 132);
            this.phieu.TabIndex = 30;
            this.phieu.SelectedIndexChanged += new System.EventHandler(this.phieu_SelectedIndexChanged);
            // 
            // loaiphieu
            // 
            this.loaiphieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaiphieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaiphieu.CheckOnClick = true;
            this.loaiphieu.Enabled = false;
            this.loaiphieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaiphieu.Location = new System.Drawing.Point(479, 136);
            this.loaiphieu.Name = "loaiphieu";
            this.loaiphieu.Size = new System.Drawing.Size(305, 308);
            this.loaiphieu.TabIndex = 31;
            // 
            // dongy
            // 
            this.dongy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongy.Enabled = false;
            this.dongy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongy.Location = new System.Drawing.Point(441, 493);
            this.dongy.Name = "dongy";
            this.dongy.Size = new System.Drawing.Size(116, 22);
            this.dongy.TabIndex = 12;
            this.dongy.Text = "Kho thuốc đông y";
            this.dongy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // chklocngoaigio
            // 
            this.chklocngoaigio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chklocngoaigio.Enabled = false;
            this.chklocngoaigio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklocngoaigio.Location = new System.Drawing.Point(354, 493);
            this.chklocngoaigio.Name = "chklocngoaigio";
            this.chklocngoaigio.Size = new System.Drawing.Size(86, 22);
            this.chklocngoaigio.TabIndex = 11;
            this.chklocngoaigio.Text = "Lọc theo giờ";
            // 
            // khudt
            // 
            this.khudt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.khudt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khudt.Enabled = false;
            this.khudt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khudt.Location = new System.Drawing.Point(661, 469);
            this.khudt.Name = "khudt";
            this.khudt.Size = new System.Drawing.Size(123, 21);
            this.khudt.TabIndex = 8;
            this.khudt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(629, 467);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Khu :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbcoso
            // 
            this.cbcoso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbcoso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcoso.DropDownWidth = 200;
            this.cbcoso.Enabled = false;
            this.cbcoso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcoso.Location = new System.Drawing.Point(512, 469);
            this.cbcoso.Name = "cbcoso";
            this.cbcoso.Size = new System.Drawing.Size(123, 21);
            this.cbcoso.TabIndex = 7;
            this.cbcoso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(467, 467);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 23);
            this.label7.TabIndex = 37;
            this.label7.Text = "Cơ sở :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkhaohut
            // 
            this.chkhaohut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkhaohut.Enabled = false;
            this.chkhaohut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkhaohut.Location = new System.Drawing.Point(563, 493);
            this.chkhaohut.Name = "chkhaohut";
            this.chkhaohut.Size = new System.Drawing.Size(84, 22);
            this.chkhaohut.TabIndex = 38;
            this.chkhaohut.Text = "Kho hao hụt";
            this.chkhaohut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkhaohut_KeyDown);
            // 
            // chkhide
            // 
            this.chkhide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkhide.Enabled = false;
            this.chkhide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkhide.Location = new System.Drawing.Point(698, 493);
            this.chkhide.Name = "chkhide";
            this.chkhide.Size = new System.Drawing.Size(86, 22);
            this.chkhide.TabIndex = 39;
            this.chkhide.Text = "Không dùng";
            // 
            // frmDmkho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkhide);
            this.Controls.Add(this.chkhaohut);
            this.Controls.Add(this.cbcoso);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dongy);
            this.Controls.Add(this.khudt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chklocngoaigio);
            this.Controls.Add(this.loaiphieu);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.dutru);
            this.Controls.Add(this.thua);
            this.Controls.Add(this.ketoan);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.matat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.computer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.khott);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmkho_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmkho_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmkho_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            

            user = d.user; itable = d.tableid("", "d_dmkho");
            //
            upd_cautruc_dmkho();
            //
			computer.DisplayMember="COMPUTER";
			computer.ValueMember="COMPUTER";
			computer.DataSource=d.get_data("select distinct computer from "+user+".dmcomputer").Tables[0];
			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			nhomcc.DataSource=d.get_data("select * from "+user+".d_loaikho order by id").Tables[0];

            dtphieu = d.get_data("select * from " + user + ".d_dmphieu where id<5 order by stt").Tables[0];
            phieu.DataSource = dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
            
            loaiphieu.DisplayMember = "TEN";
            loaiphieu.ValueMember = "ID";

            sql = "select * from " + user + ".dmkhudt ";
            if (s_khudt.Trim().Trim(',') != "") sql += " where  id in(" + s_khudt.Trim().Trim(',') + ")";
            khudt.DataSource = d.get_data(sql).Tables[0];
            khudt.DisplayMember = "TEN";
            khudt.ValueMember = "ID";

            sql = "select * from " + user + ".dmchinhanh where id>0 ";
            if (i_chinhanh > 0) sql += " and  id in(" + i_chinhanh + ")";
            cbcoso.DataSource = d.get_data(sql).Tables[0];
            cbcoso.DisplayMember = "TEN";
            cbcoso.ValueMember = "ID";

			load_grid();
			AddGridTableStyle();
            ref_text();
            bQuanlychinhanh = d.bQuanly_Theo_Chinhanh;
		}

		private void load_grid()
		{
            sql = "select a.*,b.ten as tennhom, a.khu from " + user + ".d_dmkho a left join " + user + ".d_loaikho b on a.loai=b.id where a.nhom=" + i_nhom;
            if (s_khudt.Trim().Trim(',') != "") sql += " and (a.khu=0 or a.khu in(" + s_khudt.Trim().Trim(',') + "))";
            sql += " order by a.stt";
            dt = d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
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
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();            
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

   			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "matat";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhom";
			TextCol.HeaderText = "Nhóm";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "computer";
			TextCol.HeaderText = "Tên máy";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "khu";
            TextCol.HeaderText = "CS";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "hide";
            TextCol.HeaderText = "Không dùng";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			stt.Enabled=ena;
			ten.Enabled=ena;
			matat.Enabled=ena;
			nhomcc.Enabled=ena;
			computer.Enabled=ena;
			khott.Enabled=ena;
			thua.Enabled=ena;
            chklocngoaigio.Enabled = ena;
            khudt.Enabled = (khudt.Items.Count > 0) ? ena : false;
            dongy.Enabled=phieu.Enabled=loaiphieu.Enabled=dutru.Enabled=chkhaohut.Enabled= ena;
			ketoan.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;

            cbcoso.Enabled = ena;

            chkhide.Enabled = ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
				stt.Value=decimal.Parse(d.get_data("select max(stt) from "+user+".d_dmkho where nhom="+i_nhom).Tables[0].Rows[0][0].ToString())+1;
			}
			catch{stt.Value=1;}
            b_New = true;
			l_id=0;
			ten.Text="";
			matat.Text="";
			thua.Checked=false;
            dutru.Checked = true;
			dongy.Checked=ketoan.Checked=false;
            chkhide.Checked = false;
            chkhaohut.Checked = false;
			nhomcc.SelectedIndex=-1;
            for (int k = 0; k < phieu.Items.Count; k++) phieu.SetItemCheckState(k, CheckState.Unchecked);
            for (int k = 0; k < loaiphieu.Items.Count; k++) loaiphieu.SetItemCheckState(k, CheckState.Unchecked);
            khudt.SelectedIndex = -1;
			ena_object(true);
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
            b_New = false;
			ena_object(true);
			stt.Focus();
		}

		private bool kiemtra()
		{
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (nhomcc.SelectedIndex==-1)
			{
				nhomcc.Focus();
				return false;
			}
			if (computer.SelectedIndex==-1)
			{
				computer.Focus();
				return false;
			}
			if (matat.Text=="")
			{
				matat.Focus();
				return false;
			}
            s_phieu="";
			for(int i=0;i<phieu.Items.Count;i++)
				if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
            s_loai="";
			for(int i=0;i<loaiphieu.Items.Count;i++)
				if (loaiphieu.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim().PadLeft(3,'0')+",";

            if (khudt.Items.Count > 0 && khudt.SelectedIndex < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn cơ sở!"), LibMedi.AccessData.Msg);
                khudt.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            if (l_id == 0)
            {
                try
                {
                    if (bQuanlychinhanh)
                    {
                        l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_capid(106).ToString().PadLeft(2, '0'));
                    }
                    else
                    {
                        l_id = decimal.Parse(d.get_data("select max(id) from " + user + ".d_dmkho").Tables[0].Rows[0][0].ToString()) + 1;
                    }
                    //l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_capid(105).ToString().PadLeft(2,'0'));//decimal.Parse(d.get_data("select max(id) from " + user + ".d_dmnhomkho").Tables[0].Rows[0][0].ToString()) + 1;
                }
                catch { l_id = 1; }
                d.upd_eve_tables(itable, i_userid, "ins");
            }
            else
            {
                d.upd_eve_tables(itable, i_userid, "upd");
                d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmkho", "id=" + l_id));
            }
            i_khu = (khudt.Items.Count == 0 || khudt.SelectedIndex < 0) ? 0 : int.Parse(khudt.SelectedValue.ToString());
            if (!d.upd_dmkho(l_id, ten.Text, i_nhom, 1, int.Parse(stt.Value.ToString()), (khott.Checked) ? 1 : 0, computer.SelectedValue.ToString(), "", 0, 0, i_khu, i_chinhanh, b_New,(chkhaohut.Checked)?1:0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" "+this.Text.Trim()+" !",d.Msg);
				return;
			}
            d.execute_data("update " + user + ".d_dmkho set matat='" + matat.Text + "',ketoan=" + ((ketoan.Checked) ? 1 : 0) + ",thua=" + ((thua.Checked) ? 1 : 0) + ",dutru=" + ((dutru.Checked) ? 1 : 0) + ",phieu='" + s_phieu + "',loaiphieu='" + s_loai + "',dongy=" + ((dongy.Checked) ? 1 : 0) + ", ngoaigio=" + (chklocngoaigio.Checked ? "1" : "0") + ", hide=" + (chkhide.Checked ? "1" : "0") + "  where id=" + l_id);
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ref_text();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy !"),d.Msg);
				return;
			}	
			try
			{
				if (d.get_data("select * from "+user+s_mmyy+".d_tonkhoth where makho="+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,4].ToString())).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}
			}
			catch{}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                l_id = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
                d.upd_eve_tables(itable, i_userid, "del");
                d.upd_eve_upd_del(itable, i_userid, "del", d.fields(user + ".d_dmkho", "id=" + l_id));
				d.execute_data("delete from "+user+".d_dmkho where id="+l_id);
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
                l_id=decimal.Parse(dataGrid1[i,0].ToString());
                DataRow r=d.getrowbyid(dt,"id="+l_id);
                if (r!=null)
                {
				    stt.Value=decimal.Parse(r["stt"].ToString());
				    matat.Text=r["matat"].ToString();
				    ten.Text=r["ten"].ToString();
				    nhomcc.SelectedValue=r["loai"].ToString();
				    khott.Checked=r["khott"].ToString().Trim()=="1";
				    computer.SelectedValue=r["computer"].ToString();
				    ketoan.Checked=r["ketoan"].ToString().Trim()=="1";
				    thua.Checked=r["thua"].ToString().Trim()=="1";
                    dutru.Checked = r["dutru"].ToString().Trim() == "1";
                    chklocngoaigio.Checked = r["ngoaigio"].ToString().Trim() == "1";
                    s_phieu=r["phieu"].ToString();s_loai=r["loaiphieu"].ToString();
                    for (int k = 0; k < phieu.Items.Count; k++) phieu.SetItemCheckState(k, CheckState.Unchecked);
                    for (int k = 0; k < loaiphieu.Items.Count; k++) loaiphieu.SetItemCheckState(k, CheckState.Unchecked);
       				for(int j=0;j<dtphieu.Rows.Count;j++)
    					if (s_phieu.IndexOf(dtphieu.Rows[j]["id"].ToString().Trim()+",")!=-1) phieu.SetItemCheckState(j,CheckState.Checked);
	    				else phieu.SetItemCheckState(j,CheckState.Unchecked);
                    load_loai();
       				for(int j=0;j<dtloai.Rows.Count;j++)
    					if (s_loai.IndexOf(dtloai.Rows[j]["id"].ToString().Trim().PadLeft(3,'0')+",")!=-1) loaiphieu.SetItemCheckState(j,CheckState.Checked);
	    				else loaiphieu.SetItemCheckState(j,CheckState.Unchecked);
                    dongy.Checked = r["dongy"].ToString().Trim() == "1";
                    chkhaohut.Checked = r["haohut"].ToString().Trim() == "1";
                    i_khu  = (r["khu"].ToString() == "") ? 0 : int.Parse(r["khu"].ToString());
                    khudt.SelectedValue = i_khu;

                    chkhide.Checked = r["hide"].ToString() == "1";
                }
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDmkho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void stt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void nhomcc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhomcc.SelectedIndex==-1) nhomcc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (l_id==0 && ten.Text!="")
			{
				DataRow r1=d.getrowbyid(dt,"ten='"+ten.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đã nhập !"),d.Msg);
					ten.Focus();
				}
			}
		}

		private void thua_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thua && !ketoan.Checked) ketoan.Checked=true;
		}

        private void phieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == phieu) load_loai();
        }

        private void load_loai()
        {
            s_phieu = "";
            for (int i = 0; i < phieu.Items.Count; i++) if (phieu.GetItemChecked(i)) s_phieu += dtphieu.Rows[i]["id"].ToString().Trim() + ",";
            sql = "select a.id,trim(a.ten) as ten from " + user + ".d_loaiphieu a,"+user+".d_dmphieu b where a.loai=b.id and a.nhom="+i_nhom;
            if (s_phieu != "") sql += " and a.loai in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
            else sql += " and a.loai=-1";
            sql += " order by a.loai,a.stt";
            dtloai = d.get_data(sql).Tables[0];
            loaiphieu.DataSource = dtloai;
            loaiphieu.DisplayMember = "TEN";
            loaiphieu.ValueMember = "ID";
     
        }

        private void upd_cautruc_dmkho()
        {
            sql = "alter table " + user + ".d_dmkho add ngoaigio numeric(1) default (0)";
            d.execute_data(sql);
            sql = "alter table " + user + ".d_dmkho add chinhanh numeric(1) default (0)";
            d.execute_data(sql);
        }

        private void chkhaohut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
	}
}
