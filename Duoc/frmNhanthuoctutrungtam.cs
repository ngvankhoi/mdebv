using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	public class frmNhanthuoctutrungtam : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private string s_mmyy, s_ngay, sql, s_loai, s_makho, s_manhom, user, xxx;
        private int i_nhom, i_userid, i_khudt = 0, ichinhanh = 0;
		private decimal l_id;
        private int i_IDChiNhanh = 0;
        private bool bNew, bAdmin;
		private AccessData d;
        private LibMedi.AccessData m;
		
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
        DataTable dtphieu;
        private DataRow r;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
        private DialogResult result;
        private ToolTip toolTip1;
        private Button btNhantucenter;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dtgvDatacenter;
        private DateTimePicker dtTungay;
        private Label label2;
        private Label label1;
        private TextBox txtTimkiem;
        private DateTimePicker dtDenngay;
        private Panel panel1;
        private CheckBox chkxml;
        private Label lsokhoan;
        private CheckBox chkIn;
        private Button butKetthuc;
        private Button butIn;
        private Button butBoqua;
        private Button butLuu;
        private Button butMoi;
        private ComboBox khon;
        private Label label9;
        private ComboBox cboSophieu;
        private Label label3;
        private DateTimePicker txtNgay;
        private Label label4;
        private Button butHuy;
        private DataGridViewCheckBoxColumn cl_chon;
        private DataGridViewTextBoxColumn cl_id;
        private DataGridViewTextBoxColumn cl_nhom;
        private DataGridViewTextBoxColumn cl_sophieu;
        private DataGridViewTextBoxColumn cl_ngay;
        private DataGridViewTextBoxColumn cl_loai;
        private DataGridViewTextBoxColumn cl_done;
        private DataGridViewTextBoxColumn cl_cnchuyen;
        private DataGridView dtgvDatacenterct;
        private Label label6;
        private Label lblsomathang;
        private Label lblsoluonghang;
        private Label label7;
        private DataGridViewTextBoxColumn cl_stt;
        private DataGridViewTextBoxColumn cl_id2;
        private DataGridViewTextBoxColumn cl_mabd;
        private DataGridViewTextBoxColumn cl_vat;
        private DataGridViewTextBoxColumn ma;
        private DataGridViewTextBoxColumn cl_tenbd;
        private DataGridViewTextBoxColumn cl_handung;
        private DataGridViewTextBoxColumn cl_losx;
        private DataGridViewTextBoxColumn cl_sl;
        private DataGridViewTextBoxColumn cl_dongia;
        private DataGridViewTextBoxColumn cl_sotien;
        private DataGridViewTextBoxColumn cl_giaban;
        private DataGridViewTextBoxColumn cl_giamua;
        private DataGridViewTextBoxColumn cl_tennguon;
        private DataGridViewTextBoxColumn cl_tennhacc;
        private IContainer components;
        #endregion

        ///Dong 13/07/2011
        public frmNhanthuoctutrungtam(AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool admin, string _manhom, int _khudt, int _ichinhanh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            d = acc;
            i_nhom = nhom; s_manhom = _manhom;
            s_makho = kho; i_userid = userid;
            s_mmyy = mmyy; s_ngay = ngay;
            s_loai = loai; 
            bAdmin = admin; this.Text = title;
            i_khudt = _khudt;
            ichinhanh = _ichinhanh;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        /// End Dong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanthuoctutrungtam));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btNhantucenter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblsomathang = new System.Windows.Forms.Label();
            this.lblsoluonghang = new System.Windows.Forms.Label();
            this.dtgvDatacenterct = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSophieu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.dtDenngay = new System.Windows.Forms.DateTimePicker();
            this.dtTungay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvDatacenter = new System.Windows.Forms.DataGridView();
            this.cl_chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_nhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_sophieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_done = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_cnchuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.lsokhoan = new System.Windows.Forms.Label();
            this.khon = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.cl_stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_mabd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_tenbd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_handung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_losx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_sotien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_giaban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_giamua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_tennguon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_tennhacc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatacenterct)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatacenter)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btNhantucenter
            // 
            this.btNhantucenter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btNhantucenter.ForeColor = System.Drawing.Color.Blue;
            this.btNhantucenter.Location = new System.Drawing.Point(683, 17);
            this.btNhantucenter.Name = "btNhantucenter";
            this.btNhantucenter.Size = new System.Drawing.Size(88, 21);
            this.btNhantucenter.TabIndex = 131;
            this.btNhantucenter.Text = "Lấy dữ liệu";
            this.btNhantucenter.UseVisualStyleBackColor = true;
            this.btNhantucenter.Click += new System.EventHandler(this.btNhantucenter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblsomathang);
            this.groupBox1.Controls.Add(this.lblsoluonghang);
            this.groupBox1.Controls.Add(this.dtgvDatacenterct);
            this.groupBox1.Location = new System.Drawing.Point(6, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(935, 284);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết được chọn";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(704, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 23);
            this.label7.TabIndex = 143;
            this.label7.Text = "Tổng số lượng : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(464, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 141;
            this.label6.Text = "Tổng số mặt hàng : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblsomathang
            // 
            this.lblsomathang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsomathang.Location = new System.Drawing.Point(568, 10);
            this.lblsomathang.Name = "lblsomathang";
            this.lblsomathang.Size = new System.Drawing.Size(131, 19);
            this.lblsomathang.TabIndex = 142;
            this.lblsomathang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsoluonghang
            // 
            this.lblsoluonghang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsoluonghang.Location = new System.Drawing.Point(792, 10);
            this.lblsoluonghang.Name = "lblsoluonghang";
            this.lblsoluonghang.Size = new System.Drawing.Size(131, 19);
            this.lblsoluonghang.TabIndex = 141;
            this.lblsoluonghang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgvDatacenterct
            // 
            this.dtgvDatacenterct.AllowUserToAddRows = false;
            this.dtgvDatacenterct.AllowUserToDeleteRows = false;
            this.dtgvDatacenterct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDatacenterct.BackgroundColor = System.Drawing.Color.MintCream;
            this.dtgvDatacenterct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDatacenterct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_stt,
            this.cl_id2,
            this.cl_mabd,
            this.cl_vat,
            this.ma,
            this.cl_tenbd,
            this.cl_handung,
            this.cl_losx,
            this.cl_sl,
            this.cl_dongia,
            this.cl_sotien,
            this.cl_giaban,
            this.cl_giamua,
            this.cl_tennguon,
            this.cl_tennhacc});
            this.dtgvDatacenterct.GridColor = System.Drawing.Color.Silver;
            this.dtgvDatacenterct.Location = new System.Drawing.Point(1, 32);
            this.dtgvDatacenterct.Name = "dtgvDatacenterct";
            this.dtgvDatacenterct.ReadOnly = true;
            this.dtgvDatacenterct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDatacenterct.Size = new System.Drawing.Size(923, 251);
            this.dtgvDatacenterct.TabIndex = 132;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtNgay);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboSophieu);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTimkiem);
            this.groupBox2.Controls.Add(this.dtDenngay);
            this.groupBox2.Controls.Add(this.dtTungay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtgvDatacenter);
            this.groupBox2.Controls.Add(this.btNhantucenter);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(929, 237);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn thông tin lấy dữ liệu từ trung tâm";
            // 
            // txtNgay
            // 
            this.txtNgay.CustomFormat = "dd/MM/yyyy";
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgay.Location = new System.Drawing.Point(80, 19);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(81, 20);
            this.txtNgay.TabIndex = 141;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 140;
            this.label4.Text = "Ngày làm việc :";
            // 
            // cboSophieu
            // 
            this.cboSophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSophieu.Location = new System.Drawing.Point(214, 18);
            this.cboSophieu.Name = "cboSophieu";
            this.cboSophieu.Size = new System.Drawing.Size(165, 21);
            this.cboSophieu.TabIndex = 138;
            this.cboSophieu.SelectedIndexChanged += new System.EventHandler(this.cboSophieu_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(159, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 139;
            this.label3.Text = "Số phiếu : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimkiem.ForeColor = System.Drawing.Color.Blue;
            this.txtTimkiem.Location = new System.Drawing.Point(777, 16);
            this.txtTimkiem.Multiline = true;
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(146, 21);
            this.txtTimkiem.TabIndex = 135;
            this.txtTimkiem.Text = "Tìm kiếm";
            this.txtTimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // dtDenngay
            // 
            this.dtDenngay.CustomFormat = "dd/MM/yyyy";
            this.dtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenngay.Location = new System.Drawing.Point(591, 17);
            this.dtDenngay.Name = "dtDenngay";
            this.dtDenngay.Size = new System.Drawing.Size(88, 20);
            this.dtDenngay.TabIndex = 134;
            // 
            // dtTungay
            // 
            this.dtTungay.CustomFormat = "dd/MM/yyyy";
            this.dtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTungay.Location = new System.Drawing.Point(441, 18);
            this.dtTungay.Name = "dtTungay";
            this.dtTungay.Size = new System.Drawing.Size(86, 20);
            this.dtTungay.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Đến ngày :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Từ ngày :";
            // 
            // dtgvDatacenter
            // 
            this.dtgvDatacenter.AllowUserToAddRows = false;
            this.dtgvDatacenter.AllowUserToDeleteRows = false;
            this.dtgvDatacenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDatacenter.BackgroundColor = System.Drawing.Color.MintCream;
            this.dtgvDatacenter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDatacenter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_chon,
            this.cl_id,
            this.cl_nhom,
            this.cl_sophieu,
            this.cl_ngay,
            this.cl_loai,
            this.cl_done,
            this.cl_cnchuyen});
            this.dtgvDatacenter.GridColor = System.Drawing.Color.Silver;
            this.dtgvDatacenter.Location = new System.Drawing.Point(0, 45);
            this.dtgvDatacenter.Name = "dtgvDatacenter";
            this.dtgvDatacenter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgvDatacenter.Size = new System.Drawing.Size(924, 192);
            this.dtgvDatacenter.TabIndex = 132;
            this.dtgvDatacenter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDatacenter_CellClick);
            // 
            // cl_chon
            // 
            this.cl_chon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cl_chon.DataPropertyName = "chon";
            this.cl_chon.FalseValue = "0";
            this.cl_chon.Frozen = true;
            this.cl_chon.HeaderText = "Chọn";
            this.cl_chon.Name = "cl_chon";
            this.cl_chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cl_chon.TrueValue = "1";
            this.cl_chon.Width = 57;
            // 
            // cl_id
            // 
            this.cl_id.DataPropertyName = "id";
            this.cl_id.HeaderText = "Id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ToolTipText = "Id";
            this.cl_id.Visible = false;
            this.cl_id.Width = 120;
            // 
            // cl_nhom
            // 
            this.cl_nhom.DataPropertyName = "nhom";
            this.cl_nhom.HeaderText = "Nhóm";
            this.cl_nhom.Name = "cl_nhom";
            this.cl_nhom.ToolTipText = "Nhóm";
            // 
            // cl_sophieu
            // 
            this.cl_sophieu.DataPropertyName = "sophieu";
            this.cl_sophieu.HeaderText = "Số phiếu";
            this.cl_sophieu.Name = "cl_sophieu";
            this.cl_sophieu.ToolTipText = "Số phiếu";
            // 
            // cl_ngay
            // 
            this.cl_ngay.DataPropertyName = "ngay";
            this.cl_ngay.HeaderText = "Ngày";
            this.cl_ngay.Name = "cl_ngay";
            this.cl_ngay.ToolTipText = "Ngày";
            this.cl_ngay.Width = 120;
            // 
            // cl_loai
            // 
            this.cl_loai.DataPropertyName = "loai";
            this.cl_loai.HeaderText = "Loại";
            this.cl_loai.Name = "cl_loai";
            this.cl_loai.ToolTipText = "Loại";
            // 
            // cl_done
            // 
            this.cl_done.DataPropertyName = "done";
            this.cl_done.HeaderText = "Done";
            this.cl_done.Name = "cl_done";
            this.cl_done.ToolTipText = "Done";
            this.cl_done.Visible = false;
            // 
            // cl_cnchuyen
            // 
            this.cl_cnchuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cl_cnchuyen.DataPropertyName = "cnchuyen";
            this.cl_cnchuyen.HeaderText = "CN Chuyển";
            this.cl_cnchuyen.Name = "cl_cnchuyen";
            this.cl_cnchuyen.ToolTipText = "CN Chuyển";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkIn);
            this.panel1.Controls.Add(this.chkxml);
            this.panel1.Controls.Add(this.lsokhoan);
            this.panel1.Controls.Add(this.khon);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.butKetthuc);
            this.panel1.Controls.Add(this.butIn);
            this.panel1.Controls.Add(this.butBoqua);
            this.panel1.Controls.Add(this.butHuy);
            this.panel1.Controls.Add(this.butLuu);
            this.panel1.Controls.Add(this.butMoi);
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 34);
            this.panel1.TabIndex = 136;
            // 
            // chkIn
            // 
            this.chkIn.Location = new System.Drawing.Point(198, 8);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(112, 16);
            this.chkIn.TabIndex = 138;
            this.chkIn.Text = "Xem trước khi in";
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.Location = new System.Drawing.Point(144, 8);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(48, 17);
            this.chkxml.TabIndex = 140;
            this.chkxml.Text = "XML";
            this.chkxml.UseVisualStyleBackColor = true;
            // 
            // lsokhoan
            // 
            this.lsokhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsokhoan.Location = new System.Drawing.Point(3, 5);
            this.lsokhoan.Name = "lsokhoan";
            this.lsokhoan.Size = new System.Drawing.Size(131, 24);
            this.lsokhoan.TabIndex = 139;
            this.lsokhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // khon
            // 
            this.khon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khon.Location = new System.Drawing.Point(371, 6);
            this.khon.Name = "khon";
            this.khon.Size = new System.Drawing.Size(134, 21);
            this.khon.TabIndex = 136;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(316, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 137;
            this.label9.Text = "Kho nhập : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(860, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 137;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(791, 4);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 136;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(722, 4);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 133;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Enabled = false;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(653, 4);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 131;
            this.butHuy.Text = "&Huỷ";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(584, 4);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 132;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(515, 4);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 134;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // cl_stt
            // 
            this.cl_stt.DataPropertyName = "stt";
            this.cl_stt.HeaderText = "STT";
            this.cl_stt.Name = "cl_stt";
            this.cl_stt.ReadOnly = true;
            this.cl_stt.Width = 50;
            // 
            // cl_id2
            // 
            this.cl_id2.DataPropertyName = "id";
            this.cl_id2.HeaderText = "id";
            this.cl_id2.Name = "cl_id2";
            this.cl_id2.ReadOnly = true;
            this.cl_id2.Visible = false;
            // 
            // cl_mabd
            // 
            this.cl_mabd.DataPropertyName = "mabd";
            this.cl_mabd.HeaderText = "Ma bd";
            this.cl_mabd.Name = "cl_mabd";
            this.cl_mabd.ReadOnly = true;
            this.cl_mabd.Visible = false;
            // 
            // cl_vat
            // 
            this.cl_vat.DataPropertyName = "vat";
            this.cl_vat.HeaderText = "Vat";
            this.cl_vat.Name = "cl_vat";
            this.cl_vat.ReadOnly = true;
            this.cl_vat.Visible = false;
            // 
            // ma
            // 
            this.ma.DataPropertyName = "ma";
            this.ma.HeaderText = "Mã";
            this.ma.Name = "ma";
            this.ma.ReadOnly = true;
            this.ma.Width = 65;
            // 
            // cl_tenbd
            // 
            this.cl_tenbd.DataPropertyName = "tenbd";
            this.cl_tenbd.HeaderText = "Tên BD";
            this.cl_tenbd.Name = "cl_tenbd";
            this.cl_tenbd.ReadOnly = true;
            this.cl_tenbd.Width = 200;
            // 
            // cl_handung
            // 
            this.cl_handung.DataPropertyName = "handung";
            this.cl_handung.HeaderText = "Hạng dùng";
            this.cl_handung.Name = "cl_handung";
            this.cl_handung.ReadOnly = true;
            // 
            // cl_losx
            // 
            this.cl_losx.DataPropertyName = "losx";
            this.cl_losx.HeaderText = "Lô SX";
            this.cl_losx.Name = "cl_losx";
            this.cl_losx.ReadOnly = true;
            // 
            // cl_sl
            // 
            this.cl_sl.DataPropertyName = "soluong";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.cl_sl.DefaultCellStyle = dataGridViewCellStyle1;
            this.cl_sl.HeaderText = "Số lượng";
            this.cl_sl.Name = "cl_sl";
            this.cl_sl.ReadOnly = true;
            // 
            // cl_dongia
            // 
            this.cl_dongia.DataPropertyName = "dongia";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.cl_dongia.DefaultCellStyle = dataGridViewCellStyle2;
            this.cl_dongia.HeaderText = "Đơn giá";
            this.cl_dongia.Name = "cl_dongia";
            this.cl_dongia.ReadOnly = true;
            // 
            // cl_sotien
            // 
            this.cl_sotien.DataPropertyName = "sotien";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.cl_sotien.DefaultCellStyle = dataGridViewCellStyle3;
            this.cl_sotien.HeaderText = "Số tiền";
            this.cl_sotien.Name = "cl_sotien";
            this.cl_sotien.ReadOnly = true;
            // 
            // cl_giaban
            // 
            this.cl_giaban.DataPropertyName = "giaban";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.cl_giaban.DefaultCellStyle = dataGridViewCellStyle4;
            this.cl_giaban.HeaderText = "Giá bán";
            this.cl_giaban.Name = "cl_giaban";
            this.cl_giaban.ReadOnly = true;
            // 
            // cl_giamua
            // 
            this.cl_giamua.DataPropertyName = "giamua";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.cl_giamua.DefaultCellStyle = dataGridViewCellStyle5;
            this.cl_giamua.HeaderText = "Gia mua";
            this.cl_giamua.Name = "cl_giamua";
            this.cl_giamua.ReadOnly = true;
            // 
            // cl_tennguon
            // 
            this.cl_tennguon.DataPropertyName = "tennguon";
            this.cl_tennguon.HeaderText = "Nguồn";
            this.cl_tennguon.Name = "cl_tennguon";
            this.cl_tennguon.ReadOnly = true;
            this.cl_tennguon.Width = 120;
            // 
            // cl_tennhacc
            // 
            this.cl_tennhacc.DataPropertyName = "mavach";
            this.cl_tennhacc.HeaderText = "Mã vạch";
            this.cl_tennhacc.Name = "cl_tennhacc";
            this.cl_tennhacc.ReadOnly = true;
            this.cl_tennhacc.Width = 120;
            // 
            // frmNhanthuoctutrungtam
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(937, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNhanthuoctutrungtam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhanthuoctutrungtam_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatacenterct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatacenter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmNhanthuoctutrungtam_Load(object sender, System.EventArgs e)
		{
            dtgvDatacenter.AutoGenerateColumns = false;
            dtgvDatacenterct.AutoGenerateColumns = false;
            user = d.user; xxx = user + s_mmyy;
            dtTungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtDenngay.Value = dtTungay.Value;
            i_IDChiNhanh = d.i_Chinhanh_hientai;
            ena_object(false);
            ena_object1(false);
            sql = "select id,ten from " + user + ".d_dmkho where 1=1 ";
            if (i_IDChiNhanh > 0) sql += " and chinhanh=" + i_IDChiNhanh;// d.i_Chinhanh_hientai;
            if (s_makho.Trim().Trim(',') != "") sql += " and id in(" + s_makho.Trim().Trim(',') + ")";
            sql += " order by ten";
            khon.DataSource = d.get_data(sql).Tables[0];
            khon.DisplayMember = "TEN";
            khon.ValueMember = "ID";
            load_sophieu();
            if (cboSophieu.Items.Count > 0 && cboSophieu.SelectedIndex >= 0)
            {
                cboSophieu_SelectedIndexChanged(null, null);
            }
            txtNgay.Value = d.StringToDate(s_ngay);
            ichinhanh = d.i_Chinhanh_hientai;
		}
        void load_sophieu()
        {
            sql = "select a.id,a.sophieu,b.ten as tenkho,a.khon as makho,c.ten as chinhanh  from " + xxx + ".d_xuatll a," + user + ".d_dmkho b," + user + ".dmchinhanh c where a.khon= b.id(+) and c.id=a.idchinhanh and a.loai ='" + s_loai + "' ";
            if (i_IDChiNhanh > 0) sql += " and chinhanh=" + i_IDChiNhanh;

            dtphieu = d.get_data(sql).Tables[0];
            cboSophieu.DataSource = dtphieu;
            cboSophieu.DisplayMember = "SOPHIEU";
            cboSophieu.ValueMember = "ID";
        }
		private void load_grid()
		{
            sql = "select 0 as chon,a.id,a.nhom,a.sophieu,to_char(a.ngaysp,'dd/mm/yyyy') ngay,a.loai,a.done,b.ten cnchuyen,a.idchinhanhchuyen ";
            sql += " from " + user + ".d_chonhapll a inner join " + user + ".dmchinhanh b on a.idchinhanhchuyen=b.id";
            sql += " where a.done=0 and a.ngaysp between to_date('" + dtTungay.Text.Trim() + "','dd/mm/yyyy') and to_date('" + dtDenngay.Text.Trim() + "','dd/mm/yyyy')";
            sql += " and a.loai not in('CK','BS','CN')";
            dtll = d.get_data(sql).Tables[0];
            dtgvDatacenter.DataSource = dtll;
            lsokhoan.Text = "TỔNG SỐ KHOẢN :" + dtll.Rows.Count.ToString();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();
            this.Close();
		}

        private void f_search(string s_chuoi)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dtgvDatacenter.DataSource];
                DataView dv = (DataView)cm.List;
                sql = "sophieu like '" + s_chuoi.Trim() + "%'" + " or loai like '" + s_chuoi.Trim() + "%'" + " or cnchuyen like '" + s_chuoi.Trim() + "%'";
                dv.RowFilter = sql;
            }
            catch { }
        }
        private void ena_object1(bool ena)
        {
            //dtTungay.Enabled = ena;
            //dtDenngay.Enabled = ena;
            //btNhantucenter.Enabled = ena;
            //txtTimkiem.Enabled = ena;
        }
		private void ena_object(bool ena)
		{
			butMoi.Enabled=!ena;
			butHuy.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            cboSophieu.Enabled = !ena;
            dtgvDatacenter.Enabled = ena;
            dtTungay.Enabled = ena;
            dtDenngay.Enabled=ena;
            khon.Enabled = ena;
            btNhantucenter.Enabled = ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
        }

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            bNew = true;
            ena_object(true);
            ena_object1(true);
            btNhantucenter_Click(sender,e);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            string s_sophieu = cboSophieu.Text;
            DataTable dttmpll = new DataTable();
            DataTable dttmpct = new DataTable();
            int cnt = 0;
            Cursor = Cursors.WaitCursor;
            CurrencyManager cm = (CurrencyManager)BindingContext[dtgvDatacenter.DataSource, dtgvDatacenter.DataMember];
            DataView v = (DataView)cm.List;
            cnt = v.Table.Select("chon=1").Length;
            if (cnt > 0)
            {
                foreach (DataRow row in v.Table.Select("chon=1"))
                {
                    if (bNew)
                    {                        
                        //l_id = d.getidyymmddhhmiss_stt_computer;//get_id_xuat
                        //s_sophieu = d.i_Chinhanh_hientai.ToString() + row["sophieu"].ToString() +d.get_capid((int)LibMedi.IDThongSo.ID_SophieuNhap).ToString();
                        for (; ; )
                        {
                            l_id = d.getidyymmddhhmiss_stt_computer;
                            sql = "select id from " + xxx + ".d_xuatll where id=" + l_id;
                            if (d.get_data(sql).Tables[0].Rows.Count <= 0) break;
                        }
                        s_sophieu = row["sophieu"].ToString();
                    }
                    decimal d_idxuat = decimal.Parse(row["id"].ToString());
                    int i_id_chinhanhchuyen = int.Parse(row["idchinhanhchuyen"].ToString());
                    string s_dblink = d.getDBLink(i_id_chinhanhchuyen);
                    string s_makhonhap = khon.SelectedValue.ToString();
                    // cap nhat 
                    CurrencyManager cm1 = (CurrencyManager)BindingContext[dtgvDatacenterct.DataSource, dtgvDatacenter.DataMember];
                    DataView dtct = (DataView)cm1.List;
                    if (dtct.Table.Rows.Count > 0)
                    {
                        if (row["loai"].ToString().Trim() == "CK")
                        {
                            d.execute_data("update " + user + ".d_chonhapll set done=1 where id=" + d_idxuat.ToString());
                            d.execute_data("update " + xxx + ".d_xuatll set idduyet=" + d_idxuat.ToString() + " where id=" + l_id.ToString());
                            d.execute_data("update " + xxx + ".d_xuatll" + "@" + s_dblink.Trim('@') + " set idduyet=" + l_id.ToString() + " where id=" + d_idxuat.ToString());
                        }
                        else
                        {
                            if (d.upd_xuatll(s_mmyy, l_id, i_nhom, s_sophieu, s_ngay, s_loai, 0, int.Parse(s_makhonhap), "LC", i_userid, i_id_chinhanhchuyen))
                            {
                                d.execute_data("update " + user + ".d_chonhapll set done=1 where id=" + d_idxuat.ToString());
                                d.execute_data("update " + xxx + ".d_xuatll set idduyet=" + d_idxuat.ToString() + " where id=" + l_id.ToString());
                                d.execute_data("update " + xxx + ".d_xuatll" + "@" + s_dblink.Trim('@') + " set idduyet=" + l_id.ToString() + " where id=" + d_idxuat.ToString());
                                int stt = 1;
                                foreach (DataRow row1 in dtct.Table.Rows)
                                {
                                    decimal l_id_tonkho = 0;//d.getidyymmddhhmiss_stt_computer;//get_id_tonkho
                                    if (l_id_tonkho == 0)
                                    {
                                        for (; ; )
                                        {
                                            l_id_tonkho = d.getidyymmddhhmiss_stt_computer;
                                            sql = "select id from " + xxx + ".d_theodoi where id=" + l_id_tonkho;
                                            if (d.get_data(sql).Tables[0].Rows.Count <= 0) break;
                                        }
                                    }
                                    int i_mabd = int.Parse(row1["mabd"].ToString());
                                    decimal d_soluong = decimal.Parse(row1["soluong"].ToString());
                                    // cap nhat theo doi
                                    d.upd_theodoi(s_mmyy, l_id_tonkho, i_mabd, int.Parse(row1["manguon"].ToString()), int.Parse(row1["nhomcc"].ToString()), row1["handung"].ToString(),
                                        row1["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(row1["giamua"].ToString()), decimal.Parse(row1["giaban"].ToString()),//dongia
                                        decimal.Parse(row1["gianovat"].ToString() == "" ? "0" : row1["gianovat"].ToString()), 0, 0);//, row1["mavach"].ToString());
                                    d.execute_data("update " + xxx + ".d_theodoi set ngay=to_date('" + s_ngay + "','dd/mm/yyyy'),sohd='" + s_sophieu + "' where id=" + l_id_tonkho + "");
                                    // cap nhat ton kho ct
                                    if (!d.upd_tonkhoct(s_mmyy, int.Parse(s_makhonhap), l_id_tonkho, i_mabd, d_soluong, "slnhap"))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tồn kho !"), d.Msg);
                                        Cursor = Cursors.Default;
                                        return;
                                    }
                                    // update ton kho th
                                    d.upd_tonkhoth(s_mmyy, int.Parse(s_makhonhap), 0, i_mabd, d_soluong, "slnhap");
                                    // cap nhat xuat ct
                                    if (!d.upd_xuatct(s_mmyy, l_id, stt++, l_id_tonkho, i_mabd, d_soluong, "", "", decimal.Parse(row1["giaban"].ToString())))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập được thông tin chi tiết") + " \n", d.Msg);
                                        Cursor = Cursors.Default;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    #region Dong
                    //dttmpll = d.get_data(" select * from " + xxx + ".d_xuatll where id=" + d_idxuat.ToString()).Tables[0];
                    //foreach (DataRow r in dttmpll.Rows)
                    //{
                    //    if (d.upd_xuatll(s_mmyy, l_id, int.Parse(r["nhom"].ToString()), r["sophieu"].ToString(), txtNgay.Text, s_loai, int.Parse(r["khox"].ToString()), int.Parse(khon.SelectedValue.ToString()), r["lydo"].ToString(), i_userid, ichinhanh))
                    //    {
                    //        dttmpct = d.get_data("select * from " + xxx + ".d_xuatct where id=" + d_idxuat.ToString()).Tables[0];
                    //        foreach (DataRow r1 in dttmpct.Rows)
                    //        {
                    //            if (!d.upd_xuatct(s_mmyy, l_id, decimal.Parse(r1["stt"].ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), "", "", decimal.Parse(r1["giaban"].ToString())))
                    //            {
                    //                MessageBox.Show(lan.Change_language_MessageText("Không cập được thông tin chi tiết") + " \n", d.Msg);
                    //                return;
                    //            }
                    //        }
                    //        d.execute_data("update " + user + ".d_chonhapll set done=1 where id=" + d_idxuat.ToString());
                    //        d.execute_data("update " + xxx + ".d_xuatll set idduyet=" + d_idxuat.ToString() + ",idchinhanh=" + i_id_chinhanhchuyen.ToString() + " where id=" + l_id.ToString());
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(lan.Change_language_MessageText("Không cập được thông tin xuống tables d_xuatll") + " \n", d.Msg);
                    //        return;
                    //    }
                    //    d.execute_data("update " + xxx + ".d_xuatll" + "@" + s_dblink.Trim('@') + " set idduyet=" + l_id.ToString() + " where id=" + d_idxuat.ToString());
                    //}
                    #endregion
                }
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn phiếu chờ nhập."));
                Cursor = Cursors.Default;
                return;
            }
            decimal tmp_id = l_id;
            load_sophieu();
            cboSophieu.SelectedValue = tmp_id;
            cboSophieu_SelectedIndexChanged(null, null);
            //load_grid();
            //f_loaichitiett("0");
            ena_object(false);
            Cursor = Cursors.Default;
		}

        private void butBoqua_Click(object sender, System.EventArgs e)
        {
            ena_object(false);
            if (cboSophieu.Items.Count > 0 && cboSophieu.SelectedIndex >= 0) cboSophieu_SelectedIndexChanged(null, null);
        }

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

        private void btNhantucenter_Click(object sender, EventArgs e)
        {
            if (dtTungay.Value > dtDenngay.Value)
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày nhập không hợp lệ !"), d.Msg);
                dtTungay.Focus();
                return;
            }
            else
                load_grid();
        }
        private void f_loaichitiett(string s_id)
        {
            sql = "select a.id,a.stt,a.mabd,b.ten||' '||b.dang as tenbd,a.handung,a.losx,a.vat,a.soluong,a.dongia,a.sotien,a.giaban,a.giamua,c.ten tennguon,d.ten tennhacc, a.sttt ";
            sql += " from " + xxx + ".d_chonhapct a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".d_dmnguon c on a.manguon=c.id inner join " + user + ".d_dmnx d on a.nhomcc=d.id";
            sql += " where a.id in(" + s_id + ")";
            sql += " order by a.id,a.stt";
            dtct = d.get_data(sql).Tables[0];
            dtgvDatacenterct.DataSource = dtct;
            decimal d_soluong = 0;
            string s_ma = "";
            int tt = 0;
            foreach (DataRow row in dtct.Rows)
            {
                if (s_ma != row["mabd"].ToString())
                {
                    s_ma = row["mabd"].ToString();
                    tt++;
                }
                d_soluong += decimal.Parse(row["soluong"].ToString());
            }
            lblsomathang.Text = tt.ToString("###,###,###,###,##0");
            lblsoluonghang.Text = d_soluong.ToString("###,###,###,###,##0");
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboSophieu.Items.Count == 0) return;
                if (d.bKhoaso(i_nhom,s_mmyy))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " + lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " + lan.Change_language_MessageText("đã khóa !") + "\n" + lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                    return;
                }
                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    l_id = decimal.Parse(cboSophieu.SelectedValue.ToString());
                    int itable = d.tableid(s_mmyy, "d_xuatct");
                    DataTable dt_xoa = d.get_data("select sophieudutru from " + xxx + ".d_xuatll where id=" + l_id + "").Tables[0];
                    if (dt_xoa.Rows.Count > 0 && decimal.Parse(dt_xoa.Rows[0][0].ToString()) != 0)
                    {
                        MessageBox.Show("Dữ liệu đã phát sinh không thể hủy được !");
                        return;
                    }
                    // lay dtct
                    CurrencyManager cm1 = (CurrencyManager)BindingContext[dtgvDatacenterct.DataSource, dtgvDatacenter.DataMember];
                    DataView dv = (DataView)cm1.List;
                    foreach (DataRow r1 in dv.Table.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuatct(d.delete, s_mmyy, s_loai, -1, int.Parse(khon.SelectedValue.ToString()), decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                    }
                    itable = d.tableid(s_mmyy, "d_xuatll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatll", "id=" + l_id));
                    string s_sql = "select * from " + xxx + ".d_xuatll where id=" + l_id.ToString();
                    string s_dblink = "";
                    decimal d_idduyet = 0;
                    foreach (DataRow rd in d.get_data(s_sql).Tables[0].Rows)
                    {
                        s_dblink = d.getDBLink(int.Parse(rd["idchinhanh"].ToString()));
                        d_idduyet = decimal.Parse(rd["idduyet"].ToString());
                        break;
                    }
                    s_dblink = s_dblink == "" ? "" : "@" + s_dblink.Trim('@');
                    d.execute_data("update " + xxx + ".d_xuatll" + s_dblink + " set idduyet=0 where id=" + d_idduyet.ToString() + " and loai='" + s_loai + "'");
                    d.execute_data("update " + user + ".d_chonhapll set done=0 where id=" + d_idduyet.ToString());
                    d.execute_data("delete from " + xxx + ".d_xuatct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_xuatll where id=" + l_id);
                    //d.delrec(dtll, "id=" + l_id);
                    load_sophieu();
                    cboSophieu.Refresh();
                    if (cboSophieu.Items.Count > 0 && cboSophieu.SelectedIndex>=0)
                    {
                        cboSophieu_SelectedIndexChanged(null, null);
                        l_id = decimal.Parse(cboSophieu.SelectedValue.ToString());
                    }
                    else l_id = 0;
                    //load_head();
                }
            }
            catch { }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            if (cboSophieu.SelectedIndex != -1)
            {
                sql = "select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten_hamluong,trim(b.ten) tenbd,b.hamluong,nullif(b.tenhc,' ') as tenhc,b.dang,c.ten as tennguon,";
                sql += "d.ten as tennhomcc,t.handung,t.losx,a.soluong ";
                sql += " ,t.giamua as dongia,a.soluong*t.giamua as sotien";
                sql += " ,t.giaban,t.giamua,t.manguon,t.nhomcc,b.vtyt,";
                sql += " e.ten as tennuoc,t.sothe,a.mabs,'' as tenbs,a.hotenbn,t.gianovat,g.ten tencn,idchinhanh,to_char(f.ngay,'dd/mm/yyyy') ngayxuat,f.sophieu,l.id idnhom,l.ten tennhom,l.nhomin idnhomin,f.lydo ghichu,m.id idlydo,m.ten lydo";
                sql += " from " + xxx + ".d_xuatct a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".d_dmnuoc e on b.manuoc=e.id";
                sql += " inner join " + xxx + ".d_theodoi t on a.sttt=t.id inner join " + xxx + ".d_xuatll f on a.id=f.id left join " + user + ".dmchinhanh g on f.idchinhanh=g.id";
                sql += " left join " + user + ".d_dmnguon c on t.manguon=c.id left join " + user + ".d_dmnx d on t.nhomcc=d.id left join " + user + ".d_dmnhom l on b.manhom=l.id left join " + user + ".d_dmkhac m on f.khon=m.id";
                sql += " where a.id= " + cboSophieu.SelectedValue.ToString();
                sql += " order by a.stt";
                DataSet dstmp = d.get_data(sql);
                string s_tenkho = "";
                string s_tenchinhanh = "";
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[cboSophieu.DataSource];
                    DataView dv = (DataView)cm.List;
                    DataRow[] dtr = dv.Table.Select("id=" + cboSophieu.SelectedValue.ToString());
                    if (dtr.Length > 0)
                    {
                        s_tenkho = dtr[0]["tenkho"].ToString();
                        s_tenchinhanh = dtr[0]["chinhanh"].ToString();
                    }
                }
                catch { }
                string s_title = "";
                if (d.i_Chinhanh_hientai_Trungtam > 0)
                {
                    s_title = "PHIẾU XUẤT  " + s_tenkho + " KIÊM PHIẾU NHẬP KHO " + s_tenchinhanh;
                }
                else
                {
                    s_title = "PHIẾU XUẤT  " + s_tenkho + " " + d.f_getten_chinhanh(d.i_Chinhanh_hientai).ToUpper() + " TRẢ HÀNG VỀ CÔNG TY ";
                }
                if (chkxml.Checked)
                {
                    if (!System.IO.Directory.Exists("..//..//dataxml")) System.IO.Directory.CreateDirectory("..//..//dataxml");
                    dstmp.WriteXml("..//..//dataxml//xkhac.xml", XmlWriteMode.WriteSchema);
                }
                string tenfile = "d_phieunhapkho.rpt";
                frmReport f = new frmReport(d, dstmp.Tables[0],i_userid , tenfile, cboSophieu.Text, txtNgay.Text, s_title, "", "", (int.Parse(khon.SelectedValue.ToString()) > 3) ? khon.Text : "", "Kho Trung Tâm", "", khon.Text, "");
                f.ShowDialog();
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTimkiem)
                RefreshChildren(txtTimkiem.Text);
        }
        private void RefreshChildren(string text)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dtgvDatacenter.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "sophieu like '%" + text.Trim() + "%'";
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message); }
        }

        private void cboSophieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cboSophieu || sender == null) 
            {
                try
                {
                    DataRow r = d.getrowbyid(dtphieu,"id="+cboSophieu.SelectedValue.ToString());
                    if (r != null)
                    {
                        khon.SelectedValue = r["makho"].ToString();
                    }
                    sql = "select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten_hamluong,trim(b.ten) tenbd,b.hamluong,nullif(b.tenhc,' ') as tenhc,b.dang,c.ten as tennguon,";
                    sql += "d.ten as tennhomcc,t.handung,t.losx,round(a.soluong,0) as soluong ";
                    sql += " ,(case when b.vtyt=1 then t.giamua else t.gianovat end) as dongia,(case when b.vtyt=1 then a.soluong*t.giamua else a.soluong*t.gianovat end) as sotien";
                    sql += " ,t.giaban as giaban,t.giamua as giamua,t.manguon,t.nhomcc,";
                    sql += " e.ten as tennuoc,t.sothe,a.mabs,'' as tenbs,a.hotenbn,t.gianovat,g.ten tencn,idchinhanh,to_char(f.ngay,'dd/mm/yyyy') ngayxuat,f.sophieu,l.id idnhom,l.ten tennhom,l.nhomin idnhomin,f.lydo ghichu,m.id idlydo,m.ten lydo";
                    sql += " from " + xxx + ".d_xuatct a inner join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmnuoc e on b.manuoc=e.id";
                    sql += " left join " + xxx + ".d_theodoi t on a.sttt=t.id inner join " + xxx + ".d_xuatll f on a.id=f.id left join " + user + ".dmchinhanh g on f.idchinhanh=g.id";
                    sql += " left join " + user + ".d_dmnguon c on t.manguon=c.id left join " + user + ".d_dmnx d on t.nhomcc=d.id left join " + user + ".d_dmnhom l on b.manhom=l.id left join " + user + ".d_dmkhac m on f.khon=m.id";
                    sql += " where a.id= " + cboSophieu.SelectedValue.ToString();
                    sql += " order by a.stt";
                    DataSet dstmp = d.get_data(sql);
                    dtgvDatacenterct.DataSource = dstmp.Tables[0];                    
                    decimal d_soluong = 0;
                    string s_ma = "";
                    int tt = 0;
                    foreach (DataRow row in dstmp.Tables[0].Rows)
                    {
                        if (s_ma != row["mabd"].ToString())
                        {
                            s_ma = row["mabd"].ToString();
                            tt++;
                        }
                        d_soluong += decimal.Parse(row["soluong"].ToString());
                    }
                    lblsomathang.Text = tt.ToString("###,###,###,###,##0");
                    lblsoluonghang.Text = d_soluong.ToString("###,###,###,###,##0");
                }
                catch { }
            }
        }

        private void dtgvDatacenter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ActiveControl == dtgvDatacenter && dtgvDatacenter.DataSource!=null)
            {
                decimal d_id = decimal.Parse(dtgvDatacenter["cl_id", dtgvDatacenter.CurrentRow.Index].Value.ToString());
                load_grid(d_id);
            }
        }
        void load_grid(decimal _id)
        {
            string s_sql = "select a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten_hamluong,trim(b.ten) tenbd,b.hamluong," +
                "nullif(b.tenhc,' ') as tenhc,b.dang,c.ten as tennguon,d.ten as tennhomcc,a.handung,a.losx,"+
                "a.soluong as soluong  ,a.dongia as dongia,a.sotien as sotien" +
                " ,a.giaban as giaban,a.giamua as giamua,a.manguon,a.nhomcc, e.ten as tennuoc,"+
                "'' as sothe,'' as mabs,'' as tenbs,'' as hotenbn,round(a.giamua*100/(100+b.vat),5) as gianovat"+
                ",round(a.soluong*(a.giamua*100/(100+b.vat)),5) as tiennovat,g.ten tencn,idchinhanhchuyen as "+
                "idchinhanh,to_char(f.ngaysp,'dd/mm/yyyy') ngayxuat, f.sophieu,l.id idnhom,l.ten tennhom," +
                "l.nhomin idnhomin,'' as ghichu,0 as idlydo,'' as lydo,a.mavach ";
            s_sql+=" from " + user + ".d_chonhapct a inner join " + user + ".d_dmbd b on a.mabd=b.id left " +
                " join " + user + ".d_dmnuoc e on b.manuoc=e.id inner join " + user + ".d_chonhapll f on a.id=f.id left join " +
                 " " + user + ".dmchinhanh g  on f.idchinhanhchuyen=g.id left join " + user + ".d_nhomcc d on a.nhomcc=d.id left join " + user + ".d_dmnguon c on " +
                 " a.manguon=c.id left join " + user + ".d_dmnhom l on b.manhom=l.id  where a.id= " + _id + " order by a.stt";
            DataSet dstmp = d.get_data(s_sql);
            dtgvDatacenterct.DataSource = dstmp.Tables[0];
            decimal d_soluong = 0;
            string s_ma = "";
            int tt = 0;
            foreach (DataRow row in dstmp.Tables[0].Rows)
            {
                if (s_ma != row["mabd"].ToString())
                {
                    s_ma = row["mabd"].ToString();
                    tt++;
                }
                d_soluong += decimal.Parse(row["soluong"].ToString());
            }
            lblsomathang.Text = tt.ToString("###,###,###,###,##0");
            lblsoluonghang.Text = d_soluong.ToString("###,###,###,###,##0");
        }

        private void dtgvDatacenter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ActiveControl == dtgvDatacenter && dtgvDatacenter.DataSource != null)
            {
                decimal d_id = decimal.Parse(dtgvDatacenter["cl_id", dtgvDatacenter.CurrentRow.Index].Value.ToString());
                load_grid(d_id);
                for (int i = 0; i < dtgvDatacenter.RowCount; i++)
                {
                    dtgvDatacenter["cl_chon", i].Value = 0;
                }
                dtgvDatacenter["cl_chon", dtgvDatacenter.CurrentRow.Index].Value = 1;
            }
        }
	}
}
