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
	public class frmIcd10 : System.Windows.Forms.Form
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
		private MaskedTextBox.MaskedTextBox cicd10;
		private System.Windows.Forms.Label label2;
		private MaskedTextBox.MaskedTextBox vviet;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox vanh;
		private DataSet ds=new DataSet();
		private AccessData m;
        private int itable, i_userid;
		private string sql,s_table,user;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox icd_chapter;
		private System.Windows.Forms.ComboBox icd_nhom;
		private System.Windows.Forms.Button butIn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIcd10(AccessData acc,string table,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_table = table; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIcd10));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cicd10 = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vviet = new MaskedTextBox.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vanh = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.icd_chapter = new System.Windows.Forms.ComboBox();
            this.icd_nhom = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 7);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(777, 498);
            this.dataGrid1.TabIndex = 4;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(481, 538);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 15;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(361, 538);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 12;
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
            this.butLuu.Location = new System.Drawing.Point(301, 538);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 11;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(241, 538);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 14;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(181, 538);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 13;
            this.butMoi.Text = "      &Thêm";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(541, 538);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(2, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã ICD :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cicd10
            // 
            this.cicd10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cicd10.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cicd10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cicd10.Enabled = false;
            this.cicd10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cicd10.Location = new System.Drawing.Point(59, 511);
            this.cicd10.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.cicd10.MaxLength = 9;
            this.cicd10.Name = "cicd10";
            this.cicd10.Size = new System.Drawing.Size(60, 21);
            this.cicd10.TabIndex = 6;
            this.cicd10.Validated += new System.EventHandler(this.cicd10_Validated);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(91, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên bệnh :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vviet
            // 
            this.vviet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vviet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vviet.Enabled = false;
            this.vviet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vviet.Location = new System.Drawing.Point(180, 511);
            this.vviet.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.vviet.Name = "vviet";
            this.vviet.Size = new System.Drawing.Size(290, 21);
            this.vviet.TabIndex = 8;
            this.vviet.Validated += new System.EventHandler(this.vviet_Validated);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(462, 511);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tiếng anh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vanh
            // 
            this.vanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vanh.Enabled = false;
            this.vanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vanh.Location = new System.Drawing.Point(527, 511);
            this.vanh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.vanh.Name = "vanh";
            this.vanh.Size = new System.Drawing.Size(256, 21);
            this.vanh.TabIndex = 10;
            this.vanh.Validated += new System.EventHandler(this.vanh_Validated);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chương :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(376, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nhóm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chapter
            // 
            this.icd_chapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icd_chapter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chapter.Location = new System.Drawing.Point(64, 3);
            this.icd_chapter.Name = "icd_chapter";
            this.icd_chapter.Size = new System.Drawing.Size(320, 21);
            this.icd_chapter.TabIndex = 1;
            this.icd_chapter.SelectedIndexChanged += new System.EventHandler(this.icd_chapter_SelectedIndexChanged);
            this.icd_chapter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icd_chapter_KeyDown);
            // 
            // icd_nhom
            // 
            this.icd_nhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.icd_nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icd_nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_nhom.Location = new System.Drawing.Point(432, 3);
            this.icd_nhom.Name = "icd_nhom";
            this.icd_nhom.Size = new System.Drawing.Size(352, 21);
            this.icd_nhom.TabIndex = 3;
            this.icd_nhom.SelectedIndexChanged += new System.EventHandler(this.icd_nhom_SelectedIndexChanged);
            this.icd_nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icd_nhom_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(421, 538);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 17;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // frmIcd10
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.vviet);
            this.Controls.Add(this.icd_nhom);
            this.Controls.Add(this.icd_chapter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vanh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cicd10);
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
            this.Name = "frmIcd10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân loại bệnh tật ICD-10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIcd10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmIcd10_Load(object sender, System.EventArgs e)
		{            
            user = m.user; itable = m.tableid("", "icd10");
			butMoi.Enabled=m.bHieuchinhICD10;
			butSua.Enabled=butMoi.Enabled;
			butHuy.Enabled=butMoi.Enabled;
			icd_chapter.DataSource=m.get_data("select * from "+user+".icd_chapter order by id_chapter").Tables[0];
            icd_chapter.DisplayMember = "chapter";
            icd_chapter.ValueMember = "id_chapter";
            if (icd_chapter.Items.Count > 0) icd_chapter.SelectedIndex = 0;
            load_nhom();
            load_grid();
            AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
		}

		private void load_nhom()
		{
            sql = "select * from " + user + ".icd_nhom ";
            if (icd_chapter.SelectedIndex != -1) sql += " where id_chapter=" + int.Parse(icd_chapter.SelectedValue.ToString());
            icd_nhom.DataSource = m.get_data(sql).Tables[0];
            icd_nhom.DisplayMember = "nhom";
            icd_nhom.ValueMember = "id_nhom";
		}

		private void load_grid()
		{
            sql = "select * from " + user + "." + s_table + " where id_chapter=" + int.Parse(icd_chapter.SelectedValue.ToString());
            if (icd_nhom.SelectedIndex != -1) sql += " and id_nhom=" + int.Parse(icd_nhom.SelectedValue.ToString());
            sql += " order by cicd10";
            ds = m.get_data(sql);
            dataGrid1.DataSource = ds.Tables[0];
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
			TextCol.MappingName = "cicd10";
			TextCol.HeaderText = "ICD10";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vviet";
			TextCol.HeaderText = "Tên bệnh tật";
            TextCol.Width = dataGrid1.Width - 10 - 50 - 300 - 25;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vanh";
			TextCol.HeaderText = "Tên tiếng anh";
			TextCol.Width = 300;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "readonly";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void vviet_Validated(object sender, System.EventArgs e)
		{
			vviet.Text=m.Caps(vviet.Text);
		}

		private void vanh_Validated(object sender, System.EventArgs e)
		{
			vanh.Text=m.Caps(vanh.Text);
		}

		private void ena_object(bool ena)
		{
			cicd10.Enabled=ena;
			vviet.Enabled=ena;
			vanh.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			icd_chapter.Enabled=!ena;
			icd_nhom.Enabled=!ena;
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			cicd10.Text="";
			vviet.Text="";
			vanh.Text="";
			ena_object(true);
			cicd10.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			cicd10.Enabled=false;
			vviet.Focus();
			SendKeys.Send("{Home}");
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (cicd10.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ICD-10 !"),LibMedi.AccessData.Msg);
				cicd10.Focus();
				return;
			}
			if (cicd10.Text.Length<3)
			{
				MessageBox.Show(lan.Change_language_MessageText("ICD-10 không hợp lệ !"),LibMedi.AccessData.Msg);
				cicd10.Focus();
				return;
			}
			if (vviet.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên bệnh tật !"),LibMedi.AccessData.Msg);
				vviet.Focus();
				return;
			}
			string m_anh="",m_stt="";
			int i_loai=0;
			if (cicd10.Text.Trim().Length==3) sql="substring(cicd10,1,2)='"+cicd10.Text.Substring(0,2)+"'";
			else sql="cicd10='"+cicd10.Text.Substring(0,3)+"'";
			DataRow r=m.getrowbyid(ds.Tables[0],sql);
			if (r!=null)
			{
				i_loai=int.Parse(r[5].ToString());
				m_anh=r[6].ToString();
				m_stt=r[7].ToString();
			}
			else
			{
				MessageBox.Show(lan.Change_language_MessageText("ICD-10 không hợp lệ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".icd10 where cicd10='" + cicd10.Text+"'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", cicd10.Text.ToUpper() + "^" + icd_chapter.SelectedValue.ToString() + "^" + vviet.Text + "^" + vanh.Text + "^" + icd_nhom.SelectedValue.ToString() + "^" + i_loai.ToString() + "^" + m_anh + "^" + m_stt);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
			m.upd_icd10(s_table,cicd10.Text.ToUpper(),int.Parse(icd_chapter.SelectedValue.ToString()),vviet.Text,vanh.Text,int.Parse(icd_nhom.SelectedValue.ToString()),i_loai,m_anh,m_stt);
			ena_object(false);
			load_grid();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dataGrid1[dataGrid1.CurrentCell.RowNumber,3].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cho phép hủy thông tin này !"),LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ICD-10 ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    m.upd_eve_tables(itable, i_userid, "del");
                    m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".icd10", "cicd10='" + cicd10.Text + "'"));
					m.execute_data("delete from "+m.user+"."+s_table+" where cicd10='"+cicd10.Text+"'");
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
				cicd10.Text=dataGrid1[i,0].ToString();
				vviet.Text=dataGrid1[i,1].ToString();
				vanh.Text=dataGrid1[i,2].ToString();
			}
			catch{}
		}

		private void icd_chapter_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==icd_chapter)
			{
				load_nhom();
				load_grid();
			}
		}

		private void icd_chapter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");			
		}

		private void icd_nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void icd_nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==icd_nhom) load_grid();
		}

		private void cicd10_Validated(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"cicd10='"+cicd10.Text+"'");
			if (r!=null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 đã tồn tại !"),LibMedi.AccessData.Msg);
				cicd10.Focus();
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmInICD10 f=new frmInICD10(s_table);
			f.ShowDialog();
		}
	}
}
