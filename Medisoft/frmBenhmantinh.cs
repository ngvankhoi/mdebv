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
	/// Summary description for frmBenhmantinh.
	/// </summary>
	public class frmBenhmantinh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox cd_chinh;
		private MaskedTextBox.MaskedTextBox icd_chinh;
		private AccessData m;
		private LibList.List listICD;
        private int i_userid;
        private string s_mabn,user;
		private DataTable dt=new DataTable();
		private DataTable dticd=new DataTable();
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox stt;
        private Label label1;
        private Label label2;
        private TextBox ghichu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBenhmantinh(AccessData acc,string _mabn,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_mabn = _mabn; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBenhmantinh));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.listICD = new LibList.List();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.stt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -15);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(656, 236);
            this.dataGrid1.TabIndex = 20;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // cd_chinh
            // 
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Enabled = false;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(129, 228);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(535, 21);
            this.cd_chinh.TabIndex = 1;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_chinh_KeyDown);
            // 
            // icd_chinh
            // 
            this.icd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Enabled = false;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(68, 228);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(59, 21);
            this.icd_chinh.TabIndex = 0;
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(561, 352);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 8;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // butThem
            // 
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(129, 352);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 5;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(199, 352);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(269, 352);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(339, 352);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(409, 352);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 7;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(479, 352);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(32, 160);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tên bệnh :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ghi chú :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(68, 250);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ghichu.Size = new System.Drawing.Size(596, 96);
            this.ghichu.TabIndex = 2;
            this.ghichu.TextChanged += new System.EventHandler(this.ghichu_TextChanged);
            // 
            // frmBenhmantinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 391);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.stt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBenhmantinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh mãn tính";
            this.Load += new System.EventHandler(this.frmBenhmantinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void icd_chinh_Validated(object sender, System.EventArgs e)
		{
			if (icd_chinh.Text!="")
			{
				cd_chinh.Text=m.get_vviet(icd_chinh.Text);
				if (cd_chinh.Text=="" && icd_chinh.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_chinh.Text=f.mTen;
						icd_chinh.Text=f.mICD;
					}
				}
			}
		}

		private void cd_chinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void cd_chinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_chinh)
			{
				Filt_ICD(cd_chinh.Text);
				listICD.BrowseToICD10(cd_chinh,icd_chinh,ghichu,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
			}
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void frmBenhmantinh_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dticd=m.get_data("select cicd10,vviet from "+user+".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

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
            TextCol.MappingName = "chandoan";
            TextCol.HeaderText = "Tên bệnh";
            TextCol.Width = 280;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "Mã ICD";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ghichu";
            TextCol.HeaderText = "Ghi chú";
            TextCol.Width = 300;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void load_grid()
		{
			dt=m.get_data("select * from "+user+".benhmantinh where mabn='"+s_mabn+"'").Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ghichu.Text=dataGrid1[i,2].ToString();
				icd_chinh.Text=dataGrid1[i,1].ToString();
				cd_chinh.Text=dataGrid1[i,0].ToString();
			}
			catch{}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			icd_chinh.Text=cd_chinh.Text=ghichu.Text="";
			icd_chinh.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			icd_chinh.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			m.upd_benhmantinh(s_mabn,cd_chinh.Text,icd_chinh.Text,ghichu.Text,i_userid);
			load_grid();
			ena_object(false);
			butThem.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count>0)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					m.execute_data("delete from "+user+".benhmantinh where mabn='"+s_mabn+"' and maicd='"+icd_chinh.Text+"'");
					load_grid();
					ref_text();
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ena_object(bool ena)
		{
			ghichu.Enabled=icd_chinh.Enabled=cd_chinh.Enabled=ena;
			butThem.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private bool kiemtra()
		{
			if (icd_chinh.Text=="" && cd_chinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh mãn tính !"),LibMedi.AccessData.Msg);
				icd_chinh.Focus();
				return false;
			}
			else if (icd_chinh.Text=="" && cd_chinh.Text!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD bệnh mãn tính !"),LibMedi.AccessData.Msg);
				icd_chinh.Focus();
				return false;
			}
			else if (cd_chinh.Text=="" && icd_chinh.Text!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập tên bệnh mãn tính !"),LibMedi.AccessData.Msg);
				if (cd_chinh.Enabled) cd_chinh.Focus();
				else icd_chinh.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,icd_chinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				icd_chinh.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,cd_chinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
				cd_chinh.Focus();
				return false;
			}
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

        private void ghichu_TextChanged(object sender, EventArgs e)
        {
            if (ghichu.Text == "\r\n") SendKeys.Send("{Tab}");
        }
	}
}
