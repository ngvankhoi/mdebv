using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public partial class frmKhuyettat : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button butketthuc;
		private System.Windows.Forms.Button butLuu;
		private AccessData m;
		private decimal l_maql,l_id;
		private int songay,i_userid;
		private string user,ngay_lv,s_ngaytt,s_bskham,s_gio="";
        private bool bAdmin;
        private Label label14;
        private Label label15;
        private TextBox chandoan;
        private TextBox dieutri;
        private Button butTainangt;
        private ComboBox cbo_dangkt;
        private ComboBox cbo_mucdokt;
        private Label label5;
        private Label label6;
        private Button butIn;
        private Label label7;
        private System.Windows.Forms.MaskedTextBox ngay;
        private DataGridView dgkhuyettat;
        private Button butmoi;
        private Button butsua;
        private Button butxoa;
        private Button butboqua;
        private DataGridViewTextBoxColumn dangkt;
        private DataGridViewTextBoxColumn mucdokt;
        private DataGridViewTextBoxColumn gvchandoan;
        private DataGridViewTextBoxColumn gvghichu;
        //private System.ComponentModel.Container components = null;
        private bool bbadt = false;
        #endregion

        public frmKhuyettat(AccessData acc,decimal maql,string s_mabn,string s_ngay,string s_hoten,string s_namsinh,string s_mann,string s_diachi,int userid,string s_bs)
		{
            m = new AccessData();
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			namsinh.Text=s_namsinh;
			mann.Text=s_mann;
			diachi.Text=s_diachi;
			l_maql=maql;
			ngay_lv=s_ngay;
            s_bskham = s_bs;
            ngay.Text = s_ngay.Substring(0, 10);
            //gio.Text = s_ngay.Substring(11);
			i_userid=userid;
		}
        public frmKhuyettat(AccessData acc, decimal maql, string s_mabn, string s_ngay, string s_hoten, string s_namsinh, string s_mann, string s_diachi, int userid, string s_bs,string _s_chandoan,bool _badt)
        {
            m = new AccessData();
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            namsinh.Text = s_namsinh;
            mann.Text = s_mann;
            diachi.Text = s_diachi;
            chandoan.Text = _s_chandoan;
            l_maql = maql;
            ngay_lv = s_ngay;
            s_bskham = s_bs;
            ngay.Text = s_ngay.Substring(0, 10);
            //gio.Text = s_ngay.Substring(11);
            i_userid = userid;
            bbadt = _badt;
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhuyettat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butketthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.butTainangt = new System.Windows.Forms.Button();
            this.cbo_dangkt = new System.Windows.Forms.ComboBox();
            this.cbo_mucdokt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.MaskedTextBox();
            this.dgkhuyettat = new System.Windows.Forms.DataGridView();
            this.butmoi = new System.Windows.Forms.Button();
            this.butsua = new System.Windows.Forms.Button();
            this.butxoa = new System.Windows.Forms.Button();
            this.butboqua = new System.Windows.Forms.Button();
            this.dangkt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mucdokt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvchandoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgkhuyettat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(130, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(55, 30);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(43, 21);
            this.namsinh.TabIndex = 3;
            this.namsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // hoten
            // 
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(316, 7);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(370, 21);
            this.hoten.TabIndex = 2;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(176, 7);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(83, 21);
            this.mabn.TabIndex = 1;
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(268, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 32;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(103, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Nghề nghiệp :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(176, 30);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(510, 21);
            this.mann.TabIndex = 4;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(55, 53);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(631, 21);
            this.diachi.TabIndex = 5;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Địa chỉ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(526, 466);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(68, 25);
            this.butketthuc.TabIndex = 11;
            this.butketthuc.Text = "&Kết thúc";
            this.butketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butketthuc.Click += new System.EventHandler(this.butketthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(171, 466);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(68, 25);
            this.butLuu.TabIndex = 10;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(31, 382);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 23);
            this.label14.TabIndex = 49;
            this.label14.Text = "Chẩn đoán :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(6, 419);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 23);
            this.label15.TabIndex = 50;
            this.label15.Text = "Ghi chú :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(97, 374);
            this.chandoan.Multiline = true;
            this.chandoan.Name = "chandoan";
            this.chandoan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chandoan.Size = new System.Drawing.Size(588, 42);
            this.chandoan.TabIndex = 8;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // dieutri
            // 
            this.dieutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(97, 418);
            this.dieutri.Multiline = true;
            this.dieutri.Name = "dieutri";
            this.dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dieutri.Size = new System.Drawing.Size(588, 42);
            this.dieutri.TabIndex = 9;
            this.dieutri.TextChanged += new System.EventHandler(this.dieutri_TextChanged);
            this.dieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // butTainangt
            // 
            this.butTainangt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTainangt.Location = new System.Drawing.Point(603, 466);
            this.butTainangt.Name = "butTainangt";
            this.butTainangt.Size = new System.Drawing.Size(83, 25);
            this.butTainangt.TabIndex = 53;
            this.butTainangt.Text = "Giao thông";
            this.butTainangt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTainangt.Visible = false;
            this.butTainangt.Click += new System.EventHandler(this.butTainangt_Click);
            // 
            // cbo_dangkt
            // 
            this.cbo_dangkt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbo_dangkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_dangkt.FormattingEnabled = true;
            this.cbo_dangkt.Location = new System.Drawing.Point(97, 351);
            this.cbo_dangkt.Name = "cbo_dangkt";
            this.cbo_dangkt.Size = new System.Drawing.Size(272, 21);
            this.cbo_dangkt.TabIndex = 6;
            this.cbo_dangkt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // cbo_mucdokt
            // 
            this.cbo_mucdokt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_mucdokt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mucdokt.FormattingEnabled = true;
            this.cbo_mucdokt.Location = new System.Drawing.Point(473, 351);
            this.cbo_mucdokt.Name = "cbo_mucdokt";
            this.cbo_mucdokt.Size = new System.Drawing.Size(211, 21);
            this.cbo_mucdokt.TabIndex = 7;
            this.cbo_mucdokt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(1, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 23);
            this.label5.TabIndex = 56;
            this.label5.Text = "Dạng khuyết tật :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(370, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 23);
            this.label6.TabIndex = 57;
            this.label6.Text = "Mức độ khuyết tật :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(455, 466);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(68, 25);
            this.butIn.TabIndex = 58;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 23);
            this.label7.TabIndex = 59;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.Location = new System.Drawing.Point(55, 8);
            this.ngay.Mask = "00/00/0000";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(78, 20);
            this.ngay.TabIndex = 0;
            this.ngay.ValidatingType = typeof(System.DateTime);
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // dgkhuyettat
            // 
            this.dgkhuyettat.AllowDrop = true;
            this.dgkhuyettat.AllowUserToAddRows = false;
            this.dgkhuyettat.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgkhuyettat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgkhuyettat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgkhuyettat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgkhuyettat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgkhuyettat.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgkhuyettat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgkhuyettat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgkhuyettat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dangkt,
            this.mucdokt,
            this.gvchandoan,
            this.gvghichu});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgkhuyettat.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgkhuyettat.GridColor = System.Drawing.Color.Gainsboro;
            this.dgkhuyettat.Location = new System.Drawing.Point(4, 79);
            this.dgkhuyettat.MultiSelect = false;
            this.dgkhuyettat.Name = "dgkhuyettat";
            this.dgkhuyettat.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgkhuyettat.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgkhuyettat.RowHeadersVisible = false;
            this.dgkhuyettat.RowHeadersWidth = 20;
            this.dgkhuyettat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgkhuyettat.Size = new System.Drawing.Size(682, 266);
            this.dgkhuyettat.StandardTab = true;
            this.dgkhuyettat.TabIndex = 61;
            this.dgkhuyettat.CurrentCellChanged += new System.EventHandler(this.dgkhuyettat_CurrentCellChanged);
            // 
            // butmoi
            // 
            this.butmoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butmoi.Image = ((System.Drawing.Image)(resources.GetObject("butmoi.Image")));
            this.butmoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butmoi.Location = new System.Drawing.Point(100, 466);
            this.butmoi.Name = "butmoi";
            this.butmoi.Size = new System.Drawing.Size(68, 25);
            this.butmoi.TabIndex = 62;
            this.butmoi.Text = "      &Mới";
            this.butmoi.Click += new System.EventHandler(this.butmoi_Click);
            // 
            // butsua
            // 
            this.butsua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butsua.Image = ((System.Drawing.Image)(resources.GetObject("butsua.Image")));
            this.butsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butsua.Location = new System.Drawing.Point(242, 466);
            this.butsua.Name = "butsua";
            this.butsua.Size = new System.Drawing.Size(68, 25);
            this.butsua.TabIndex = 63;
            this.butsua.Text = "      &Sửa";
            this.butsua.Click += new System.EventHandler(this.butsua_Click);
            // 
            // butxoa
            // 
            this.butxoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butxoa.Image = ((System.Drawing.Image)(resources.GetObject("butxoa.Image")));
            this.butxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butxoa.Location = new System.Drawing.Point(313, 466);
            this.butxoa.Name = "butxoa";
            this.butxoa.Size = new System.Drawing.Size(68, 25);
            this.butxoa.TabIndex = 64;
            this.butxoa.Text = "      &Xóa";
            this.butxoa.Click += new System.EventHandler(this.butxoa_Click);
            // 
            // butboqua
            // 
            this.butboqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butboqua.Image = ((System.Drawing.Image)(resources.GetObject("butboqua.Image")));
            this.butboqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butboqua.Location = new System.Drawing.Point(384, 466);
            this.butboqua.Name = "butboqua";
            this.butboqua.Size = new System.Drawing.Size(68, 25);
            this.butboqua.TabIndex = 65;
            this.butboqua.Text = "      &Bỏ qua";
            this.butboqua.Click += new System.EventHandler(this.butboqua_Click);
            // 
            // dangkt
            // 
            this.dangkt.DataPropertyName = "dangkt";
            this.dangkt.HeaderText = "Dạng khuyết tật";
            this.dangkt.Name = "dangkt";
            this.dangkt.ReadOnly = true;
            // 
            // mucdokt
            // 
            this.mucdokt.DataPropertyName = "mucdokt";
            this.mucdokt.HeaderText = "Mức độ khuyết tật";
            this.mucdokt.Name = "mucdokt";
            this.mucdokt.ReadOnly = true;
            // 
            // gvchandoan
            // 
            this.gvchandoan.DataPropertyName = "gvchandoan";
            this.gvchandoan.HeaderText = "Chẩn đoán";
            this.gvchandoan.Name = "gvchandoan";
            this.gvchandoan.ReadOnly = true;
            // 
            // gvghichu
            // 
            this.gvghichu.DataPropertyName = "gvghichu";
            this.gvghichu.HeaderText = "Ghi chú";
            this.gvghichu.Name = "gvghichu";
            this.gvghichu.ReadOnly = true;
            // 
            // frmKhuyettat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 500);
            this.Controls.Add(this.butboqua);
            this.Controls.Add(this.butxoa);
            this.Controls.Add(this.butsua);
            this.Controls.Add(this.butmoi);
            this.Controls.Add(this.dgkhuyettat);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbo_mucdokt);
            this.Controls.Add(this.cbo_dangkt);
            this.Controls.Add(this.butTainangt);
            this.Controls.Add(this.dieutri);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKhuyettat";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin khuyết tật";
            this.Load += new System.EventHandler(this.frmKhuyettat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgkhuyettat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

		private void frmKhuyettat_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
            user = m.user;
			bAdmin=m.bAdmin(i_userid);
			songay=m.Ngaylv_Ngayht;
            string ng = m.ngayhienhanh_server;
            //this.ngay.CustomFormat = "dd/MM/yyyy HH:mm";
            //this.ngay.Size = new System.Drawing.Size(123, 21);
            //this.ngay.Value = new DateTime(int.Parse(ng.Substring(6, 4)), int.Parse(ng.Substring(3, 2)), int.Parse(ng.Substring(0, 2)), int.Parse(ng.Substring(11, 2)), int.Parse(ng.Substring(14, 2)), 0, 0);
            load_grid();
			load_dm();
            string s = "";
            foreach (DataRow r in m.get_data("select maql,mabn,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,id_dang,id_mucdo,chandoan,ghichu from " + user + ".khuyettat where maql=" + l_maql).Tables[0].Rows)
			{
				//s=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                //this.ngay.Value = new DateTime(int.Parse(s.Substring(6, 4)), int.Parse(s.Substring(3, 2)), int.Parse(s.Substring(0, 2)), int.Parse(s.Substring(11, 2)), int.Parse(s.Substring(14, 2)), 0, 0);
                ngay.Text = r["ngay"].ToString().Substring(0,10);
                s_gio = r["ngay"].ToString().Substring(11);
                cbo_dangkt.SelectedValue = r["id_dang"].ToString();
                cbo_mucdokt.SelectedValue = r["id_mucdo"].ToString();
                chandoan.Text = r["chandoan"].ToString();
                dieutri.Text = r["ghichu"].ToString();
                //lucvao.Text = r["lucvao"].ToString();
                //lucra.Text = r["lucra"].ToString();
				break;
			}
            if (s_gio == "") s_gio = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            //s_ngaytt = ngay.Text + " " + gio.Text;
			SendKeys.Send("{HOME}");
            ena_object(true);
		}

        private void load_grid()
        {
            string sql = "";
            sql = "select b.ten as dangkt,c.ten as mucdokt,a.chandoan gvchandoan,a.ghichu as gvghichu,a.id from "+user+".khuyettat a,"+user+".dmdangkt b,"+user+".dmmucdokt c ";
            sql += " where a.id_dang=b.id and a.id_mucdo=c.id ";
            dgkhuyettat.DataSource = m.get_data(sql).Tables[0];
            dgkhuyettat.Columns["id"].Visible = false;
        }

		private void load_dm()
		{
            DataTable dtdangkt = m.get_data("select * from "+user+".dmdangkt").Tables[0];
            cbo_dangkt.DisplayMember = "TEN";
            cbo_dangkt.ValueMember = "ID";
            cbo_dangkt.DataSource = dtdangkt;

            DataTable dtmucdokt = m.get_data("select * from " + user + ".dmmucdokt").Tables[0];
            cbo_mucdokt.DisplayMember = "TEN";
            cbo_mucdokt.ValueMember = "ID";
            cbo_mucdokt.DataSource = dtmucdokt;
            foreach (DataRow r in m.get_data("select trim(sonha)||' '||trim(thon) as diachi,b.tentt,c.tenquan,d.tenpxa from " + user + ".btdbn a," + user + ".btdtt b," + user + ".btdquan c," + user + ".btdpxa d where a.matt=b.matt and a.maqu=c.maqu and a.maphuongxa=d.maphuongxa and a.mabn='" + mabn.Text + "'").Tables[0].Rows)
            {
                diachi.Text = r["diachi"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString().Trim();
                break;
            }
		}

		private bool kiemtra()
		{

            string sql = "select * from " + user + ".khuyettat where mabn='" + mabn.Text + "' and maql<>" + l_maql;//and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "'
            if (m.get_data(sql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh") + " " + hoten.Text + " tai nạn ngày \nĐã nhập !", LibMedi.AccessData.Msg);//" + ngay.Text + " " + gio.Text + "
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (!bAdmin)
			{
				if (m.get_data("select * from "+user+".khuyettat where maql="+l_maql).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
            if (l_id == 0) l_id = m.getidyymmddhhmiss_stt_computer;
            m.upd_khuyettat(l_id,l_maql,mabn.Text,ngay.Text+" "+s_gio,int.Parse(cbo_dangkt.SelectedValue.ToString()),
                int.Parse(cbo_mucdokt.SelectedValue.ToString()),chandoan.Text,dieutri.Text);
            load_grid();
            ena_object(false);
		}

		private void butketthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void ena_object(bool ena)
        {
            butmoi.Enabled = !ena;
            butsua.Enabled = !ena;
            butLuu.Enabled = ena;
            butboqua.Enabled = ena;
            butxoa.Enabled = !ena;
            butketthuc.Enabled = !ena;
        }

		private void Filter(string ten)
		{
            //try
            //{
            //    CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
            //    DataView dv=(DataView)cm.List;
            //    dv.RowFilter="thon like '%"+ten.Trim()+"%'";
            //}
            //catch{}
		}

        private void lydo_TextChanged(object sender, EventArgs e)
        {
            //if (lydo.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void chandoan_TextChanged(object sender, EventArgs e)
        {
            if (chandoan.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void dieutri_TextChanged(object sender, EventArgs e)
        {
            if (dieutri.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void lucvao_TextChanged(object sender, EventArgs e)
        {
            //if (lucvao.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void lucra_TextChanged(object sender, EventArgs e)
        {
            //if (lucra.Text == "\r\n") SendKeys.Send("{Tab}");
        }

        private void butTainangt_Click(object sender, EventArgs e)
        {
            //string xxx = user + m.mmyy(ngay.Text);
            //if (nguyennhan.SelectedIndex == 0 && m.get_data("select * from "+xxx+".khuyettat where maql=" + l_maql).Tables[0].Rows.Count == 1)
            //{
            //    frmTainangt f = new frmTainangt(m, l_maql, mabn.Text, ngay_lv, hoten.Text, namsinh.Text, mann.Text, diachi.Text, i_userid, diadiem.SelectedIndex, ngay.Text+" "+gio.Text);
            //    f.ShowDialog();
            //}
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "select a.ngay,a.mabn,b.hoten,b.sonha||'-'||b.thon||'-'||e.tenpxa||'-'||d.tenquan||'-'||c.tentt ";
            sql += "as diachi,f.ten as dangkt,g.ten as mucdokt,";
            sql += "a.chandoan,a.ghichu,b.phai,(case when b.phai=0 then (to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) else 0 end) as tuoinam ";
            sql += ",(case when b.phai=1 then (to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) else 0 end) as tuoinu ";
            sql += "from " + user + ".khuyettat a, " + user + ".btdbn b," + user + ".btdtt c,";
            sql += "" + user + ".btdquan d," + user + ".btdpxa e," + user + ".dmdangkt f," + user + ".dmmucdokt g ";
            sql += "where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa ";
            sql += "and a.id_dang=f.id and a.id_mucdo=g.id and a.mabn='"+mabn.Text.Trim()+"'";
            DataSet ds = m.get_data(sql);
            ds.WriteXml("khuyettat.xml",XmlWriteMode.WriteSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds.Tables[0], "rptKhuyettat.rpt", s_bskham, "", "", "", "", "", "", "", "", "");
                f.ShowDialog();
            }
        }

        private void butmoi_Click(object sender, EventArgs e)
        {
            ena_object(true);
            l_id = 0;
            chandoan.Text = "";
            dieutri.Text = "";
        }

        private void butsua_Click(object sender, EventArgs e)
        {
            ena_object(true);
        }

        private void butxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có đồng ý xóa dòng này không?", "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                m.execute_data("delete from " + user + ".khuyettat where id=" + l_id + "");
            load_grid();
        }

        private void butboqua_Click(object sender, EventArgs e)
        {
            ena_object(false);
        }

        private void ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void dgkhuyettat_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int current = dgkhuyettat.CurrentRow.Index;
                cbo_dangkt.Text = dgkhuyettat[0, current].Value.ToString();
                cbo_mucdokt.Text = dgkhuyettat[1, current].Value.ToString();
                chandoan.Text = dgkhuyettat[2, current].Value.ToString();
                dieutri.Text = dgkhuyettat[3, current].Value.ToString();
                l_id = decimal.Parse(dgkhuyettat["id", current].Value.ToString());
            }
            catch { }
        }
	}
}
