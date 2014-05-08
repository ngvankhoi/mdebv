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
	/// Summary description for frmDm.
	/// </summary>
	public class frmCoso : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private DataTable dt1=new DataTable();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.ComboBox makp;
        private string user;
		private bool bNew;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCoso(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoso));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(617, 320);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(431, 342);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(40, 312);
            this.ma.MaxLength = 2;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(24, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(61, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(104, 312);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(384, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(488, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tuyến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(536, 312);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(88, 21);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(131, 342);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 7;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(191, 342);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 8;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(251, 342);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(311, 342);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(371, 342);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 9;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // frmCoso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 389);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCoso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục cơ sở y tế,  trạm y tế xã";
            this.Load += new System.EventHandler(this.frmCoso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCoso_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCoso_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			makp.DisplayMember="TEN";
			makp.ValueMember="MA";
            makp.DataSource = m.get_data("select * from " + user + ".dmtuyen where ma>0 order by ma").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
            dt = m.get_data("select a.ma,a.ten,a.tuyen,b.ten as tentuyen from " + user + ".dmcoso a," + user + ".dmtuyen b where a.tuyen=b.ma order by a.ma").Tables[0];
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
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Cơ sở y tế, trạm y tế xã";
			TextCol.Width = 400;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tentuyen";
			TextCol.HeaderText = "Tuyến cơ sở";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tuyen";
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
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ena_object(bool ena)
		{
			//ma.Enabled=ena;
			ten.Enabled=ena;
			makp.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			bNew=true;
			ma.Text="";
			ten.Text="";
			ena_object(true);
			ten.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			bNew=false;
			ena_object(true);
			ma.Enabled=false;
			makp.Enabled=false;
			ten.Focus();
		}

		private bool kiemtra()
		{
//			if (ma.Text=="")
//			{
//				ma.Focus();
//				return false;
//			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}

			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			if (bNew)
			{
				int i=1;
				try
				{
                    i = int.Parse(m.get_data("select max(ma) from " + user + ".dmcoso where tuyen=" + int.Parse(makp.SelectedValue.ToString())).Tables[0].Rows[0][0].ToString()) + 1;
				}
				catch{}
				ma.Text=i.ToString();
				if (makp.SelectedValue.ToString()=="2")
					ma.Text=(i==1)?"51":i.ToString();		
			}
			if (!m.upd_dmcoso(int.Parse(ma.Text),ten.Text,int.Parse(makp.SelectedValue.ToString())))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin cơ sở y tế !"));
				return;
			}
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_03");
			m.sort_danhmuc("kh_dm_03");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_05");
			m.sort_stt("kh_dm_05");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_09");
			m.sort_stt("kh_dm_09");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_10");
			m.sort_stt("kh_dm_10");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_11");
			m.sort_stt("kh_dm_11");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_121");
			m.sort_stt("kh_dm_121");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_122");
			m.sort_stt("kh_dm_122");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_123");
			m.sort_stt("kh_dm_123");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_124");
			m.sort_danhmuc("kh_dm_124");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_131");
			m.sort_stt("kh_dm_131");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_132");
			m.sort_stt("kh_dm_132");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_133");
			m.sort_stt("kh_dm_133");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_141");
			m.sort_stt("kh_dm_141");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_142");
			m.sort_stt("kh_dm_142");
//			m.upd_danhmuc(int.Parse(ma.Text),"",ten.Text,"kh_dm_143");
//			m.sort_stt("kh_dm_143");
			m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_144");
			m.sort_stt("kh_dm_144");
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            if (m.get_data("select * from " + user + ".kh_bieu_03 where ma=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Cơ sở y tế đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".dmcoso where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_03 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_05 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_09 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_10 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_11 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_121 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_122 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_123 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_124 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_131 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_132 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_133 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_141 where ma=" + int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_142 where ma=" + int.Parse(ma.Text));
				//m.execute_data("delete from kh_dm_143 where ma="+int.Parse(ma.Text));
                m.execute_data("delete from " + user + ".kh_dm_144 where ma=" + int.Parse(ma.Text));
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (m.get_data("select * from " + user + ".dmcoso where ma=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
					ma.Focus();
					return;
				}
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString();
				ten.Text=dataGrid1[i,1].ToString();
				makp.SelectedValue=dataGrid1[i,3].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			ten.Text=m.Caps(ten.Text);
		}

		private void frmCoso_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}
	}
}
