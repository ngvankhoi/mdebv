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
	/// Summary description for frmIcd10.
	/// </summary>
	public class frmKbpttt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private DataSet ds=new DataSet();
		private AccessData m;
        private int itable, i_userid;
		private string sql,mapttt,mapt,user;
		private DataTable dtmuc=new DataTable();
		private DataTable dtloai=new DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox ma;
		private MaskedTextBox.MaskedTextBox ten;
		private System.Windows.Forms.ComboBox loaipt;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.ComboBox muc;
		private System.Windows.Forms.Button butIn;
        private ComboBox mavp;
        private ComboBox loaivp;
        private TextBox sotien;
        private Label label6;
        private bool bPttt_vp;
        private DataTable dtvp = new DataTable();
        private DataTable dtmavp = new DataTable();
        private TextBox tim;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKbpttt(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKbpttt));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.muc = new System.Windows.Forms.ComboBox();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            this.mavp = new System.Windows.Forms.ComboBox();
            this.loaivp = new System.Windows.Forms.ComboBox();
            this.sotien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(778, 469);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(481, 527);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(361, 527);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(301, 527);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(241, 527);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "      &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(181, 527);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "      &Thêm";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(541, 527);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(14, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(53, 480);
            this.ma.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma.MaxLength = 3;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(40, 21);
            this.ma.TabIndex = 5;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(89, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(122, 480);
            this.ten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(562, 21);
            this.ten.TabIndex = 7;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "PTTT :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(167, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Phân loại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(48, 5);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(136, 21);
            this.loai.TabIndex = 1;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // muc
            // 
            this.muc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.muc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.muc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muc.Location = new System.Drawing.Point(243, 4);
            this.muc.Name = "muc";
            this.muc.Size = new System.Drawing.Size(421, 21);
            this.muc.TabIndex = 3;
            this.muc.SelectedIndexChanged += new System.EventHandler(this.muc_SelectedIndexChanged);
            this.muc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.muc_KeyDown);
            // 
            // loaipt
            // 
            this.loaipt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaipt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaipt.Enabled = false;
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Location = new System.Drawing.Point(687, 480);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(97, 21);
            this.loaipt.TabIndex = 8;
            this.loaipt.SelectedIndexChanged += new System.EventHandler(this.loaipt_SelectedIndexChanged);
            this.loaipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaipt_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(421, 527);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 16;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // mavp
            // 
            this.mavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(247, 503);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(438, 21);
            this.mavp.TabIndex = 10;
            this.mavp.SelectedIndexChanged += new System.EventHandler(this.mavp_SelectedIndexChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // loaivp
            // 
            this.loaivp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loaivp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaivp.Enabled = false;
            this.loaivp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaivp.Location = new System.Drawing.Point(53, 503);
            this.loaivp.Name = "loaivp";
            this.loaivp.Size = new System.Drawing.Size(192, 21);
            this.loaivp.TabIndex = 9;
            this.loaivp.SelectedIndexChanged += new System.EventHandler(this.loaivp_SelectedIndexChanged);
            this.loaivp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(687, 503);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(98, 21);
            this.sotien.TabIndex = 11;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(-50, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 49;
            this.label6.Text = "Viện phí :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(667, 5);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(118, 20);
            this.tim.TabIndex = 50;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.Leave += new System.EventHandler(this.tim_Leave);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // frmKbpttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.loaivp);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.muc);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKbpttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phẫu thuật - thủ thuật";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKbpttt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKbpttt_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; itable = m.tableid("", "dmpttt");
			loai.DisplayMember="TEN";
			loai.ValueMember="MA";
			loai.DataSource=m.get_data("select * from "+user+".phanloaipttt order by ma").Tables[0];

            dtloai = m.get_data("select * from " + user + ".loaipttt order by ma").Tables[0];
            loaipt.DisplayMember = "TEN";
            loaipt.ValueMember = "MA";
            loaipt.DataSource = dtloai;

            dtmavp = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id and b.id_nhom=" + m.iNhompttt).Tables[0];
            loaivp.DisplayMember = "TEN";
            loaivp.ValueMember = "ID";
            loaivp.DataSource = m.get_data("select * from " + user + ".v_loaivp where id_nhom=" + m.iNhompttt + " order by stt").Tables[0];

            mavp.DisplayMember = "TEN";
            mavp.ValueMember = "ID";

			muc.DisplayMember="TEN";
			muc.ValueMember="MA";
			load_muc();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void load_muc()
		{
            dtmuc = m.get_data("select * from " + user + ".muc where id_pttt=" + loai.SelectedIndex + " order by id_muc").Tables[0];
            DataRow r = dtmuc.NewRow();
            r["ma"]="";
            r["ten"] = "TẤT CẢ";
            dtmuc.Rows.Add(r);
			muc.DataSource=dtmuc;                     
            load_grid();
		}

		private void load_grid()
		{
            sql = "select mapt,mapttt,noi_dung,coalesce(dacbiet,' ') as dacbiet,coalesce(loai1,' ') as loai1,coalesce(loai2,' ') as loai2,coalesce(loai3,' ') as loai3,loaipt,id_pttt,id_muc,mavp from " + user + ".dmpttt where 1=1 ";
            if (muc.SelectedValue.ToString().Trim() != "") sql += " and substr(mapt,1,3)='" + muc.SelectedValue.ToString() + "'";
            else sql += " and id_pttt=" + loai.SelectedIndex;
			sql+=" order by mapt";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
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
			TextCol.MappingName = "mapt";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "noi_dung";
			TextCol.HeaderText = "Tên phẫu thuật - thủ thuật";
			TextCol.Width = 575;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dacbiet";
			TextCol.HeaderText = "DB";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai1";
			TextCol.HeaderText = "I";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai2";
			TextCol.HeaderText = "II";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai3";
			TextCol.HeaderText = "III";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loaipt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mavp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void ena_object(bool ena)
		{
            loaivp.Enabled = ena;
            mavp.Enabled = ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			loaipt.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			loai.Enabled=!ena;
			muc.Enabled=!ena;
            tim.Enabled = !ena;
            dataGrid1.Enabled = !ena;
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
            if (muc.SelectedValue.ToString() == "") { MessageBox.Show("Đề nghị chọn mục trước khi thêm.", "PTTT"); muc.Focus(); return; }
			ten.Text="";
            loaivp.SelectedIndex = -1; mavp.SelectedIndex = -1;
			loaipt.SelectedIndex=0;
			int i=0;
			try
			{
                i = int.Parse(m.get_data("select max(substr(mapt,4,3)) from " + user + ".dmpttt where substr(mapt,1,3)='" + muc.SelectedValue.ToString() + "'").Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{}
			ma.Text=i.ToString().PadLeft(3,'0');
			ena_object(true);
			ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
			SendKeys.Send("{Home}");
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (ma.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mã !"),LibMedi.AccessData.Msg);
				ma.Focus();
				return;
			}
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên phẫu thuật - thủ thuật !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return;
			}
			try
			{
				DataRow r=m.getrowbyid(dtmuc,"ma='"+muc.SelectedValue.ToString()+"'");
				DataRow r1=m.getrowbyid(dtloai,"ma='"+loaipt.SelectedValue.ToString()+"'");
				if (r!=null && r1!=null)
				{
					mapttt=ma.Text+".";
					mapttt+=(loai.SelectedIndex==0)?"TT":"PT";
					mapttt+="."+r[3].ToString();
                    if (m.get_data("select * from " + user + ".dmpttt where mapt='" + muc.SelectedValue.ToString() + ma.Text + "'").Tables[0].Rows.Count != 0)
                    {
                        m.upd_eve_tables(itable, i_userid, "upd");
                        m.upd_eve_upd_del(itable, i_userid, "upd", muc.SelectedValue.ToString() + ma.Text + "^" + mapttt + "^" + ten.Text + "^" + r1[2].ToString() + "^" + r1[3].ToString() + "^" + r1[4].ToString() + "^" + r1[5].ToString()+"^"+loaipt.SelectedValue.ToString()+"^"+r[2].ToString()+"^"+r[3].ToString());
                    }
                    else m.upd_eve_tables(itable, i_userid, "ins");
					m.upd_dmpttt(muc.SelectedValue.ToString()+ma.Text,mapttt,ten.Text,r1[2].ToString(),r1[3].ToString(),r1[4].ToString(),r1[5].ToString(),int.Parse(loaipt.SelectedValue.ToString()),int.Parse(r[2].ToString()),int.Parse(r[3].ToString()),(mavp.SelectedIndex!=-1)?int.Parse(mavp.SelectedValue.ToString()):0);
				}
				ena_object(false);
				load_grid();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				mapt=dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString();
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy mã phẫu thuật - thủ thuật ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    m.upd_eve_tables(itable, i_userid, "del");
                    m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".dmpttt", "mapt='" + muc.SelectedValue.ToString()+ma.Text + "'"));
                    m.execute_data("delete from " + user + ".dmpttt where mapt='" + mapt + "'");
					load_grid();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();		
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString().Substring(3,3);
                try
                {
                    if (muc.SelectedValue.ToString() == "")
                    {
                        muc.SelectedValue = dataGrid1[i, 0].ToString().Substring(0, 3);
                    }
                }
                catch { }
				ten.Text=dataGrid1[i,1].ToString();
				loaipt.SelectedValue=dataGrid1[i,6].ToString();
                DataRow r = m.getrowbyid(dtmavp, "id=" + int.Parse(dataGrid1[i,7].ToString()));
                if (r != null)
                {
                    loaivp.SelectedValue = r["id_loai"].ToString();
                    mavp.SelectedValue = dataGrid1[i, 7].ToString();
                    decimal st = decimal.Parse(r["gia_th"].ToString()) + decimal.Parse(r["vattu_th"].ToString());
                    sotien.Text = st.ToString("###,###,###,###");
                }
                else
                {
                    loaivp.SelectedIndex = -1;
                    mavp.SelectedIndex = -1;
                }
			}
			catch{}
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl==loai) load_muc();
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");			
		}

		private void muc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void muc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl==muc) load_grid();
		}

		private void loaipt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void loaipt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (loaipt.SelectedIndex==-1) loaipt.SelectedIndex=0;
			}
			catch{}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
            if (ma.Enabled)
            {
                ma.Text = ma.Text.PadLeft(3, '0');
                DataRow r = m.getrowbyid(ds.Tables[0], "mapt='" + muc.SelectedValue.ToString() + ma.Text + "'");
                if (r != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"), LibMedi.AccessData.Msg);
                    ma.Focus();
                }
            }
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			//ten.Text=m.Caps(ten.Text);
			SendKeys.Send("{F4}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmIndmpttt f=new frmIndmpttt(m);
			f.ShowDialog(this);
		}

        private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void mavp_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (mavp.SelectedIndex != -1)
            {
                decimal st = decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["gia_th"].ToString()) + decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["vattu_th"].ToString());
                sotien.Text = st.ToString("###,###,###,###");
            }
        }

        private void loaivp_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (loaivp.SelectedIndex != -1) load_mavp();
        }

        private void load_mavp()
        {
            dtvp = m.get_data("select * from " + user + ".v_giavp where id_loai=" + int.Parse(loaivp.SelectedValue.ToString()) + " order by stt").Tables[0];
            mavp.DataSource = dtvp;
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_Leave(object sender, EventArgs e)
        {
            if (tim.Text.Trim() == "") tim.Text = "Tìm kiếm";
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                try
                {
                    CurrencyManager mc = (CurrencyManager)(BindingContext[dataGrid1.DataSource, dataGrid1.DataMember]);
                    DataView dv = (DataView)mc.List;
                    dv.RowFilter = "noi_dung like '%" + tim.Text.Trim() + "%' or mapt like '%" + tim.Text.Trim() + "%'";
                }
                catch
                {
                }
            }
        }
	}
}
