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
	public class frmDmloai : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private DataTable dt=new DataTable();
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
        private bool bKhoa_phanloai = true;
        private int iReadonly = 0;
        private Button butmap;
        private Button butdmchuan;
        private Button butImpExcel;
        private CheckBox chkCaptoa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmloai(AccessData acc,int nhom,int userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmloai));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.butImpExcel = new System.Windows.Forms.Button();
            this.butmap = new System.Windows.Forms.Button();
            this.butdmchuan = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkCaptoa = new System.Windows.Forms.CheckBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -15);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 515);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(84, 505);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nội dung :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(138, 505);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(352, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(1, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(40, 505);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 21);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(489, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(537, 505);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(161, 21);
            this.nhomcc.TabIndex = 2;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // butImpExcel
            // 
            this.butImpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butImpExcel.Image = ((System.Drawing.Image)(resources.GetObject("butImpExcel.Image")));
            this.butImpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImpExcel.Location = new System.Drawing.Point(673, 534);
            this.butImpExcel.Name = "butImpExcel";
            this.butImpExcel.Size = new System.Drawing.Size(88, 25);
            this.butImpExcel.TabIndex = 122;
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
            this.butmap.Location = new System.Drawing.Point(566, 534);
            this.butmap.Name = "butmap";
            this.butmap.Size = new System.Drawing.Size(106, 25);
            this.butmap.TabIndex = 39;
            this.butmap.Text = "    &Map danh mục";
            this.butmap.Click += new System.EventHandler(this.butmap_Click);
            // 
            // butdmchuan
            // 
            this.butdmchuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butdmchuan.Image = global::Duoc.Properties.Resources.ok;
            this.butdmchuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdmchuan.Location = new System.Drawing.Point(451, 534);
            this.butdmchuan.Name = "butdmchuan";
            this.butdmchuan.Size = new System.Drawing.Size(115, 25);
            this.butdmchuan.TabIndex = 38;
            this.butdmchuan.Text = "    &Danh mục chuẩn";
            this.butdmchuan.Click += new System.EventHandler(this.butdmchuan_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(311, 534);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 7;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(241, 534);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
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
            this.butLuu.Location = new System.Drawing.Point(171, 534);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(101, 534);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(31, 534);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 5;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(381, 534);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkCaptoa
            // 
            this.chkCaptoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCaptoa.AutoSize = true;
            this.chkCaptoa.Checked = true;
            this.chkCaptoa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaptoa.Enabled = false;
            this.chkCaptoa.Location = new System.Drawing.Point(702, 507);
            this.chkCaptoa.Name = "chkCaptoa";
            this.chkCaptoa.Size = new System.Drawing.Size(91, 17);
            this.chkCaptoa.TabIndex = 123;
            this.chkCaptoa.Text = "Được cấp toa";
            this.chkCaptoa.UseVisualStyleBackColor = true;
            // 
            // frmDmloai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkCaptoa);
            this.Controls.Add(this.butImpExcel);
            this.Controls.Add(this.butmap);
            this.Controls.Add(this.butdmchuan);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.nhomcc);
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
            this.Name = "frmDmloai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phân loại";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmloai_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmloai_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmloai_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bKhoa_phanloai = d.bKhoa_phanloai(i_nhom);
            user = d.user; itable = d.tableid("", "d_dmloai");
            bQuanlychinhanh = d.bQuanly_Theo_Chinhanh;
            f_capnhat_db();
			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			nhomcc.DataSource=d.get_data("select * from "+user+".d_nhomctd where nhom="+i_nhom+" order by stt").Tables[0];
			load_grid();
			AddGridTableStyle();
			ref_text();
		}

		private void load_grid()
		{
            dt = d.get_data("select a.*,b.ten as tennhom from " + user + ".d_dmloai a left join " + user + ".d_nhomctd b on a.loai=b.id where a.nhom=" + i_nhom + " order by a.stt").Tables[0];
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
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 435;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhom";
			TextCol.HeaderText = "Nhóm";
			TextCol.Width = 280;
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

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "readonly";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "captoa";
            TextCol.HeaderText = "Cấp toa";
            TextCol.Width = 60;
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
			nhomcc.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            chkCaptoa.Enabled = ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            if (bKhoa_phanloai)
            {
                MessageBox.Show(lan.Change_language_MessageText("Danh mục này không được thêm mới hay chỉnh sửa."));
                return;
            }
			try
			{
				stt.Value=decimal.Parse(d.get_data("select max(stt) from "+user+".d_dmloai where nhom="+i_nhom).Tables[0].Rows[0][0].ToString())+1;
			}
			catch{stt.Value=1;}
			l_id=0;
			ten.Text="";
            chkCaptoa.Checked = true;
			nhomcc.SelectedIndex=-1;
			ena_object(true);
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            if (bKhoa_phanloai)
            {
                MessageBox.Show(lan.Change_language_MessageText("Danh mục này không được thêm mới hay chỉnh sửa."));
                return;
            }
            if (iReadonly == 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Danh mục này không cho phép sửa, chỉ xem thôi!"));
                return;
            }
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,3].ToString());
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
                        l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_capid(101).ToString().PadLeft(4, '0'));
                    }
                    else
                    {
                        l_id = decimal.Parse(d.get_data("select max(id) from " + user + ".d_dmloai").Tables[0].Rows[0][0].ToString()) + 1;
                    }
                    //Thủy bỏ 06.03.2013
                    //l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_capid(101));// decimal.Parse(d.get_data("select max(id) from " + user + ".d_dmloai").Tables[0].Rows[0][0].ToString()) + 1;
                }
                catch { l_id = 1; }
                d.upd_eve_tables(itable, i_userid, "ins");
            }
            else
            {
                d.upd_eve_tables(itable, i_userid, "upd");
                d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmloai", "id=" + l_id));
            }
			if (!d.upd_dmloai(l_id,ten.Text,int.Parse(nhomcc.SelectedValue.ToString()),i_nhom,int.Parse(stt.Value.ToString())))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" "+this.Text.Trim()+" !",d.Msg);
				return;
			}
			if (!d.bDanhmuc) d.writeXml("d_thongso","c01","1");
            //
            string asql = "update " + user + ".d_dmloai set captoa=" + (chkCaptoa.Checked ? "1" : "0") + " where id=" + l_id;
            d.execute_data(asql);

            //
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
            if (bKhoa_phanloai)
            {
                MessageBox.Show(lan.Change_language_MessageText("Danh mục này không được thêm mới hay chỉnh sửa."));
                return;
            }
            if (iReadonly == 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Danh mục này không cho phép hủy, chỉ xem thôi!"));
                return;
            }
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy !"),d.Msg);
				return;
			}	
			try
			{
				if (d.get_data("select * from "+user+".d_dmbd where maloai="+decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,3].ToString())).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}
			}
			catch{}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                l_id = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString());                
                d.upd_eve_tables(itable, i_userid, "del");
                d.upd_eve_upd_del(itable, i_userid, "del", d.fields(user + ".d_dmloai", "id=" + l_id));
				d.execute_data("delete from "+user+".d_dmloai where id="+l_id);
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
				nhomcc.SelectedValue=dataGrid1[i,4].ToString();

                iReadonly = (dataGrid1[i, 5].ToString() == "") ? 0 : int.Parse(dataGrid1[i, 5].ToString());
                l_id = decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString());
                DataRow dr = d.getrowbyid(dt, "id=" + l_id);
                if (dr != null)
                {
                    chkCaptoa.Checked = dr["captoa"].ToString() == "1";
                }
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDmloai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

        private void f_capnhat_db()
        {
            string asql = "alter table " + user + ".d_dmloai add readonly numeric (1) default 0";
            d.execute_data(asql);

            asql = "alter table " + user + ".d_dmloai add captoa numeric (1) default 1";
            d.execute_data(asql);
        }

        private void butdmchuan_Click(object sender, EventArgs e)
        {
            MapDanhmuc.frmMap f = new MapDanhmuc.frmMap(1);
            f.Danhmucchuan();
        }

        private void butmap_Click(object sender, EventArgs e)
        {
            MapDanhmuc.frmMap f = new MapDanhmuc.frmMap(1);
            f.ShowDialog();
        }

        private void butImpExcel_Click(object sender, EventArgs e)
        {
            frmNhap_dmloai f = new frmNhap_dmloai();
            f.ShowDialog();
            load_grid();
        }
	}
}
