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
	public class frmDmnhom : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private DataTable dt=new DataTable();
        private DataTable dtloaivp = new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
        private decimal l_id;
        private bool bQuanlychinhanh = false;
		private int i_nhom,i_userid,itable;
        private string user;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.ComboBox nhomin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox nhomvp;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkTheodoi;
        private ComboBox cboKhotra;
        private Label label6;
        private int iReadonly = 0;
        private ComboBox cbloai;
        private Label label7;
        private Button butdmchuan;
        private Button butmap;
        private Button butImpExcel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmnhom(AccessData acc,int nhom,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; i_userid = userid;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmnhom));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.nhomin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nhomvp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkTheodoi = new System.Windows.Forms.CheckBox();
            this.cboKhotra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbloai = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butImpExcel = new System.Windows.Forms.Button();
            this.butmap = new System.Windows.Forms.Button();
            this.butdmchuan = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -13);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 472);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(56, 462);
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
            this.ten.Location = new System.Drawing.Point(88, 462);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(212, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(-6, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(24, 462);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(36, 21);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(296, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Báo cáo :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(352, 462);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(192, 21);
            this.nhomcc.TabIndex = 2;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // nhomin
            // 
            this.nhomin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhomin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomin.Enabled = false;
            this.nhomin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomin.Location = new System.Drawing.Point(566, 462);
            this.nhomin.Name = "nhomin";
            this.nhomin.Size = new System.Drawing.Size(214, 21);
            this.nhomin.TabIndex = 3;
            this.nhomin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomin_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(541, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "In :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomvp
            // 
            this.nhomvp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomvp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomvp.Enabled = false;
            this.nhomvp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomvp.Location = new System.Drawing.Point(88, 484);
            this.nhomvp.Name = "nhomvp";
            this.nhomvp.Size = new System.Drawing.Size(212, 21);
            this.nhomvp.TabIndex = 4;
            this.nhomvp.SelectedIndexChanged += new System.EventHandler(this.nhomvp_SelectedIndexChanged);
            this.nhomvp.Validated += new System.EventHandler(this.nhomvp_Validated);
            this.nhomvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomvp_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(-3, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Nhóm Viện phí :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTheodoi
            // 
            this.chkTheodoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTheodoi.Enabled = false;
            this.chkTheodoi.Location = new System.Drawing.Point(712, 488);
            this.chkTheodoi.Name = "chkTheodoi";
            this.chkTheodoi.Size = new System.Drawing.Size(72, 16);
            this.chkTheodoi.TabIndex = 6;
            this.chkTheodoi.Text = "Theo dõi";
            this.chkTheodoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // cboKhotra
            // 
            this.cboKhotra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhotra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhotra.Enabled = false;
            this.cboKhotra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhotra.Location = new System.Drawing.Point(176, 507);
            this.cboKhotra.Name = "cboKhotra";
            this.cboKhotra.Size = new System.Drawing.Size(368, 21);
            this.cboKhotra.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(8, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 22);
            this.label6.TabIndex = 33;
            this.label6.Text = "Kho nhận trả theo khoa phòng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbloai
            // 
            this.cbloai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbloai.Enabled = false;
            this.cbloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbloai.Location = new System.Drawing.Point(393, 485);
            this.cbloai.Name = "cbloai";
            this.cbloai.Size = new System.Drawing.Size(313, 21);
            this.cbloai.TabIndex = 5;
            this.cbloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(302, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "Loại Viện phí :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butImpExcel
            // 
            this.butImpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butImpExcel.Image = ((System.Drawing.Image)(resources.GetObject("butImpExcel.Image")));
            this.butImpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImpExcel.Location = new System.Drawing.Point(673, 536);
            this.butImpExcel.Name = "butImpExcel";
            this.butImpExcel.Size = new System.Drawing.Size(88, 25);
            this.butImpExcel.TabIndex = 123;
            this.butImpExcel.Text = "Imp_Excel";
            this.butImpExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImpExcel.UseVisualStyleBackColor = true;
            this.butImpExcel.Click += new System.EventHandler(this.butImpExcel_Click);
            // 
            // butmap
            // 
            this.butmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butmap.Image = global::Duoc.Properties.Resources.Export;
            this.butmap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butmap.Location = new System.Drawing.Point(567, 536);
            this.butmap.Name = "butmap";
            this.butmap.Size = new System.Drawing.Size(106, 25);
            this.butmap.TabIndex = 37;
            this.butmap.Text = "    &Map danh mục";
            this.butmap.Click += new System.EventHandler(this.butmap_Click);
            // 
            // butdmchuan
            // 
            this.butdmchuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butdmchuan.Image = global::Duoc.Properties.Resources.ok;
            this.butdmchuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdmchuan.Location = new System.Drawing.Point(452, 536);
            this.butdmchuan.Name = "butdmchuan";
            this.butdmchuan.Size = new System.Drawing.Size(115, 25);
            this.butdmchuan.TabIndex = 36;
            this.butdmchuan.Text = "    &Danh mục chuẩn";
            this.butdmchuan.Click += new System.EventHandler(this.butdmchuan_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(312, 536);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 12;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(242, 536);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 9;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(172, 536);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 8;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(102, 536);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 11;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(32, 536);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 10;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(382, 536);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmDmnhom
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butImpExcel);
            this.Controls.Add(this.butmap);
            this.Controls.Add(this.butdmchuan);
            this.Controls.Add(this.cbloai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nhomvp);
            this.Controls.Add(this.cboKhotra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkTheodoi);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.nhomin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stt);
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
            this.Name = "frmDmnhom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhóm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmnhom_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmnhom_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmnhom_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; itable = d.tableid("", "d_dmnhom");
            bQuanlychinhanh = d.bQuanly_Theo_Chinhanh;
            f_capnhat_db();
			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			nhomcc.DataSource=d.get_data("select * from "+user+".d_nhombc where nhom="+i_nhom+" order by stt").Tables[0];
			nhomin.DisplayMember="TEN";
			nhomin.ValueMember="ID";
            nhomin.DataSource = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];
			nhomvp.DisplayMember="TEN";
			nhomvp.ValueMember="MA";
            nhomvp.DataSource = d.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];
            cboKhotra.DisplayMember = "TEN";
            cboKhotra.ValueMember = "ID";
            cboKhotra.DataSource = d.get_data("select * from " + user + ".d_dmkho where thua=1 and nhom=" + i_nhom + " order by stt").Tables[0];

            
            cbloai.DisplayMember = "TEN";
            cbloai.ValueMember = "ID";
            f_load_loaivp(0);

			load_grid();
			AddGridTableStyle();
			ref_text();
		}

		private void load_grid()
		{
            try
            {
                dt = d.get_data("select a.*,b.ten as tennhom,c.ten as tennhomin,d.ten as tennhomvp, e.ten tenkho, f.ten as tenloaivp from " + user + ".d_dmnhom a left join " + user + ".d_nhombc b on a.loai=b.id left join " + user + ".d_nhomin c on a.nhomin=c.id left join " + user + ".v_nhomvp d on a.nhomvp=d.ma left join " + user + ".d_dmkho e on a.khonhantra=e.id left join " + user + ".v_loaivp f on a.loaivp=f.id  where a.nhom=" + i_nhom + " order by a.stt").Tables[0];
            }
            catch
            {
                string sql = "alter table " + user + ".d_dmnhom (add khonhantra numeric(5) default 0, add loaivp numeric(7) default 0)";
                d.execute_data(sql);
                dt = d.get_data("select a.*,b.ten as tennhom,c.ten as tennhomin,d.ten as tennhomvp, e.ten tenkho, f.ten as tenloaivp from " + user + ".d_dmnhom a left join " + user + ".d_nhombc b on a.loai=b.id left join " + user + ".d_nhomin c on a.nhomin=c.id left join " + user + ".v_nhomvp d on a.nhomvp=d.ma left join " + user + ".d_dmkho e on a.khonhantra=e.id left join " + user + ".v_loaivp f on a.loaivp=f.id  where a.nhom=" + i_nhom + " order by a.stt").Tables[0];
            }
			dataGrid1.DataSource=dt;
            ref_text();
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
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 240;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhom";
			TextCol.HeaderText = "Nhóm báo cáo";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomin";
			TextCol.HeaderText = "Nhóm in";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhomin";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhomvp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomvp";
			TextCol.HeaderText = "Nhóm viện phí";
			TextCol.Width = 115;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "theodoi";
			TextCol.HeaderText = "Theo dõi";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "khonhantra";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkho";
            TextCol.HeaderText = "Kho nhận trả";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "readonly";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenloaivp";
            TextCol.HeaderText = "Loại VP";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
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

		private void ena_object_readonly(bool ena)
		{
			dataGrid1.Enabled=!ena;
			chkTheodoi.Enabled=ena;
			stt.Enabled=ena;
			ten.Enabled=false;
            nhomcc.Enabled = false;
            nhomin.Enabled = false;
			nhomvp.Enabled=ena;
            cbloai.Enabled = ena;
            cboKhotra.Enabled = ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}
        private void ena_object(bool ena)
        {
            dataGrid1.Enabled = !ena;
            chkTheodoi.Enabled = ena;
            stt.Enabled = ena;
            ten.Enabled = ena;
            nhomcc.Enabled = ena;
            nhomin.Enabled = ena;
            nhomvp.Enabled = ena;
            cbloai.Enabled = ena;
            cboKhotra.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
        }

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
                stt.Value = decimal.Parse(d.get_data("select max(stt) from " + user + ".d_dmnhom where nhom=" + i_nhom).Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{stt.Value=1;}
			l_id=0;
			ten.Text="";
			chkTheodoi.Checked=false;
			nhomcc.SelectedIndex=-1;
			nhomin.SelectedIndex=-1;
			nhomvp.SelectedIndex=-1;
            cbloai.SelectedIndex = -1;
			ena_object(true);
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            //if (iReadonly == 1)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Danh mục này không cho phép sửa, chỉ xem thôi!"));
            //    return;
            //}
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,4].ToString());
            if (iReadonly != 1) ena_object(true);
            else ena_object_readonly(true);
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
			if (nhomin.SelectedIndex==-1)
			{
				nhomin.Focus();
				return false;
			}
			if (nhomvp.SelectedIndex==-1)
			{
				nhomvp.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
        {
            if (!kiemtra()) return;
            if (l_id == 0)
            {
                try
                {
                    if (bQuanlychinhanh)
                    {
                        l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_capid(100).ToString().PadLeft(4, '0'));
                    }
                    else
                    {
                        l_id = decimal.Parse(d.get_data("select max(id) from " + user + ".d_dmnhom").Tables[0].Rows[0][0].ToString()) + 1;
                    }
                }
                catch { l_id = 1; }
                d.upd_eve_tables(itable, i_userid, "ins");
            }
            else
            {
                d.upd_eve_tables(itable, i_userid, "upd");
                d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmnhom", "id=" + l_id));
            }
            if (!d.upd_dmnhom(l_id, ten.Text, int.Parse(nhomcc.SelectedValue.ToString()), i_nhom, int.Parse(nhomin.SelectedValue.ToString()), int.Parse(nhomvp.SelectedValue.ToString()), int.Parse(stt.Value.ToString())))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" " + this.Text.Trim() + " !", d.Msg);
                return;
            }
            d.execute_data("update " + user + ".d_dmnhom set theodoi=" + ((chkTheodoi.Checked) ? 1 : 0) + ", khonhantra=" + ((cboKhotra.SelectedIndex < 0) ? "0" : cboKhotra.SelectedValue.ToString()) + ", loaivp=" + ((cbloai.SelectedIndex < 0) ? "0" : cbloai.SelectedValue.ToString()) + " where id=" + l_id);
            if (nhomin.SelectedIndex >= 0)
            {
                string asql = "update " + user + ".d_dmbd set nhomin=" + nhomin.SelectedValue.ToString() + " where nhomin=0 and manhom=" + l_id;
                d.execute_data(asql);
            }
            if (!d.bDanhmuc) d.writeXml("d_thongso", "c01", "1");
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

            if (iReadonly == 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Danh mục này không cho phép hủy, chỉ xem thôi!"));
                return;
            }
			try
			{
				if (d.get_data("select * from "+user+".d_dmbd where manhom="+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,4].ToString())).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}
			}
			catch{}
			if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                l_id = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 4].ToString());
                d.upd_eve_tables(itable, i_userid, "del");
                d.upd_eve_upd_del(itable, i_userid, "del", d.fields(user + ".d_dmnhom", "id=" + l_id));
				d.execute_data("delete from "+user+".d_dmnhom where id="+l_id);
				if (!d.bDanhmuc) d.writeXml("d_thongso","c01","1");
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid1[i,0].ToString());
				ten.Text=dataGrid1[i,1].ToString();
				nhomcc.SelectedValue=dataGrid1[i,5].ToString();
				nhomin.SelectedValue=dataGrid1[i,6].ToString();
				nhomvp.SelectedValue=dataGrid1[i,7].ToString();
				chkTheodoi.Checked=dataGrid1[i,9].ToString()=="1";
                cboKhotra.SelectedValue = dataGrid1[i, 10].ToString();
                iReadonly = (dataGrid1[i, 12].ToString() == "") ? 0 : int.Parse(dataGrid1[i, 12].ToString());
                cbloai.SelectedValue = dataGrid1[i, 13].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDmnhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
				SendKeys.Send("{Tab}{F4}");
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

		private void nhomin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhomin.SelectedIndex==-1) nhomin.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nhomvp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhomvp.SelectedIndex==-1) nhomvp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

        private void f_capnhat_db()
        {
            string asql = "alter table " + user + ".d_dmnhom add readonly numeric (1) default 0";
            d.execute_data(asql);
        }

        private void nhomvp_Validated(object sender, EventArgs e)
        {
            if(nhomvp.SelectedIndex>=0) f_load_loaivp(int.Parse(nhomvp.SelectedValue.ToString()));
        }

        private void f_load_loaivp(int d_nhomvp)
        {
            string sql = "select ID, TEN, ID_NHOM from " + user + ".v_loaivp ";
            if (d_nhomvp > 0) sql += " where id_nhom =" + d_nhomvp;
            dtloaivp =d.get_data(sql).Tables[0];
            cbloai.DataSource = dtloaivp;
           
        }

        private void nhomvp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(nhomvp.SelectedIndex>=0) f_load_loaivp(int.Parse(nhomvp.SelectedValue.ToString()));
        }

        private void butdmchuan_Click(object sender, EventArgs e)
        {
            MapDanhmuc.frmMap f = new MapDanhmuc.frmMap(0);
            f.Danhmucchuan();
        }

        private void butmap_Click(object sender, EventArgs e)
        {
            MapDanhmuc.frmMap f = new MapDanhmuc.frmMap(0);
            f.ShowDialog();
        }

        private void butImpExcel_Click(object sender, EventArgs e)
        {
            frmNhap_dmnhom f = new frmNhap_dmnhom();
            f.ShowDialog();
            load_grid();
        }
	}
}
