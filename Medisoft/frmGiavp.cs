using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibVienphi;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmGiavp : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
        private LibMedi.AccessData m;
		private DataTable dt=new DataTable();
		private DataSet dsxml=new DataSet();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
		private int i_userid,itable;
		private decimal l_id;
		private string user,sql;
		private decimal d1,d2;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox gia_nv;
        private MaskedTextBox.MaskedTextBox gia_ngv;
        private Label label7;
        private TextBox ghichu;
        private Label label8;
        private ComboBox makp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGiavp(LibMedi.AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m=acc;i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiavp));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
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
            this.nhom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gia_nv = new MaskedTextBox.MaskedTextBox();
            this.gia_ngv = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 432);
            this.dataGrid1.TabIndex = 40;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(569, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(79, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(61, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(108, 445);
            this.ma.MaxLength = 30;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(68, 21);
            this.ma.TabIndex = 3;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nội dung :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(231, 445);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(275, 21);
            this.ten.TabIndex = 4;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(174, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(79, 25);
            this.butMoi.TabIndex = 11;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(253, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(79, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(332, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(79, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(411, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(79, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(490, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(79, 25);
            this.butHuy.TabIndex = 13;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-10, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(33, 445);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(48, 21);
            this.stt.TabIndex = 2;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(40, 2);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(744, 21);
            this.nhom.TabIndex = 1;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(506, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Nội viện :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(634, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ngoại viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gia_nv
            // 
            this.gia_nv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_nv.Enabled = false;
            this.gia_nv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_nv.Location = new System.Drawing.Point(562, 445);
            this.gia_nv.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.gia_nv.Name = "gia_nv";
            this.gia_nv.Size = new System.Drawing.Size(71, 21);
            this.gia_nv.TabIndex = 5;
            this.gia_nv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_nv.Validated += new System.EventHandler(this.gia_nv_Validated);
            // 
            // gia_ngv
            // 
            this.gia_ngv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gia_ngv.Enabled = false;
            this.gia_ngv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gia_ngv.Location = new System.Drawing.Point(701, 445);
            this.gia_ngv.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.gia_ngv.Name = "gia_ngv";
            this.gia_ngv.Size = new System.Drawing.Size(83, 21);
            this.gia_ngv.TabIndex = 6;
            this.gia_ngv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gia_ngv.Validated += new System.EventHandler(this.gia_ngv_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-6, 469);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "Ghi chú :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(52, 469);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(454, 21);
            this.ghichu.TabIndex = 7;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(506, 468);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 42;
            this.label8.Text = "Phòng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.FormattingEnabled = true;
            this.makp.Location = new System.Drawing.Point(562, 468);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(222, 21);
            this.makp.TabIndex = 8;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // frmGiavp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.gia_ngv);
            this.Controls.Add(this.gia_nv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmGiavp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo giá viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGiavp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGiavp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiavp_Load(object sender, System.EventArgs e)
		{
            user = m.user;itable = m.tableid("", "ct_giavp");
            sql = "select b.* from " + user + ".ct_nhomvp a," + user + ".ct_loaivp b where a.ma=b.id_nhom ";
			sql+=" order by b.stt";
			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			nhom.DataSource=m.get_data(sql).Tables[0];
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";
            makp.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
			load_grid();
			AddGridTableStyle();
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
            sql = "select a.*,b.tenkp from " + user + ".ct_giavp a left join "+user+".btdkp_bv b on a.makp=b.makp ";
            sql+=" where a.id_loai=" + int.Parse(nhom.SelectedValue.ToString());
			sql+=" order by a.stt";
			dt=m.get_data(sql).Tables[0];
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
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 250;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dvt";
			TextCol.HeaderText = "Đơn vị";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_nv";
            TextCol.HeaderText = "Nội viện";
			TextCol.Width = 80;
			TextCol.Format="###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_ngv";
            TextCol.HeaderText = "Ngoại viện";
			TextCol.Width = 80;
			TextCol.Format="###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ghichu";
            TextCol.HeaderText = "Ghi chú";
            TextCol.Width = 130;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Phòng";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "makp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
            dataGrid1.Enabled = !ena;
			stt.Enabled=ena;
			ma.Enabled=ena;
            makp.Enabled = ena;
			ten.Enabled=ena;
			nhom.Enabled=!ena;
			gia_nv.Enabled=ena;
			gia_ngv.Enabled=ena;
            ghichu.Enabled = ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
                stt.Value = decimal.Parse(v.get_data("select max(stt) from " + user + ".ct_giavp where id_loai=" + decimal.Parse(nhom.SelectedValue.ToString())).Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{stt.Value=1;}
			l_id=0;
            ma.Text = ""; ten.Text = ""; ghichu.Text = ""; makp.SelectedIndex = -1;
            gia_nv.Text = "0"; gia_ngv.Text = "0";
			ena_object(true);
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,6].ToString());
			ena_object(true);
			stt.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (gia_nv.Text=="")
			{
				gia_nv.Focus();
				return false;
			}
			if (gia_ngv.Text=="")
			{
				gia_ngv.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			d1=(gia_nv.Text!="")?decimal.Parse(gia_nv.Text):0;
			d2=(gia_ngv.Text!="")?decimal.Parse(gia_ngv.Text):0;
            if (l_id == 0)
            {
                l_id = v.get_id_giavp;
                m.upd_eve_tables(itable, i_userid, "ins");
            }
            else
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", l_id.ToString() + "^" + nhom.SelectedValue.ToString() + "^" + stt.Value.ToString() + "^" + ma.Text + "^" + ten.Text + "^" + "lần" + "^" + d1.ToString() + "^" + d2.ToString() + "^" + ghichu.Text+"^"+i_userid.ToString());
            }
            if (!m.upd_ct_giavp(l_id,decimal.Parse(nhom.SelectedValue.ToString()),int.Parse(stt.Value.ToString()),ma.Text,ten.Text,"lần",(makp.SelectedIndex!=-1)?makp.SelectedValue.ToString():"",d1,d2,ghichu.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin giá viện phí !"),LibVienphi.AccessData.Msg);
				return;
			}
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy !"),LibVienphi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".ct_mucct where mavp=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString())).Tables[0].Rows.Count != 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Viện phí đang sử dụng không cho phép hủy !"), LibVienphi.AccessData.Msg);
                return;
            }
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                l_id = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 6].ToString());
                m.upd_eve_tables(itable, i_userid, "del");
                m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".ct_giavp","id="+l_id));
                m.execute_data("delete from " + user + ".ct_giavp where id=" + l_id);
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (l_id!=0) return;
				DataRow r=v.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Viết tắt này đã có !"),LibVienphi.AccessData.Msg);
					ma.Focus();
					return;
				}
				if (ten.Text=="") ten.Text=ma.Text;
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid1[i,0].ToString());
				ma.Text=dataGrid1[i,1].ToString();
				ten.Text=dataGrid1[i,2].ToString();
				d1=decimal.Parse(dataGrid1[i,4].ToString());
				d2=decimal.Parse(dataGrid1[i,5].ToString());
				gia_nv.Text=d1.ToString("###,###,##0");
				gia_ngv.Text=d2.ToString("###,###,##0");
                ghichu.Text = dataGrid1[i, 7].ToString();
                makp.SelectedValue = dataGrid1[i,9].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmGiavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void stt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
				ref_text();
			}
			catch{}
		}

		private void gia_nv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal d=decimal.Parse(gia_nv.Text);
				gia_nv.Text=d.ToString("###,###,##0");
				if (gia_ngv.Text=="" || gia_ngv.Text=="0") gia_ngv.Text=gia_nv.Text;
			}
			catch{gia_nv.Text="0";}
		}

		private void gia_ngv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal d=decimal.Parse(gia_ngv.Text);
				gia_ngv.Text=d.ToString("###,###,##0");
			}
			catch{gia_ngv.Text="0";}
		}

        private void makp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
	}
}
