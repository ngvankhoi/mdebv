using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmCdkemtheo.
	/// </summary>
	public class frmCdkemtheo : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox cd_chinh;
		private MaskedTextBox.MaskedTextBox icd_chinh;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private decimal l_id;
		private int i_loai;
		private string user,mmyy,icd,sql;
		private LibList.List listICD;
		public DataTable dt=new DataTable();
		private DataTable dticd=new DataTable();
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox stt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCdkemtheo(decimal id,int loai,string my,DataTable tmp,string icd10)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			l_id=id;i_loai=loai;mmyy=my;icd=icd10;
			dt=tmp;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCdkemtheo));
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
            this.cd_chinh.Location = new System.Drawing.Point(65, 228);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(599, 21);
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
            this.icd_chinh.Location = new System.Drawing.Point(5, 228);
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
            this.listICD.Location = new System.Drawing.Point(400, 328);
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
            this.butThem.Image = global::Duoc.Properties.Resources.add;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(141, 264);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 4;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(211, 264);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 5;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(281, 264);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(351, 264);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 3;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(421, 264);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 6;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(491, 264);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
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
            // frmCdkemtheo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 349);
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
            this.Name = "frmCdkemtheo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh kèm theo";
            this.Load += new System.EventHandler(this.frmCdkemtheo_Load);
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
					frmDMICD10 f=new frmDMICD10(m,icd_chinh.Text,cd_chinh.Text,true);
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
				listICD.BrowseToICD10(cd_chinh,icd_chinh,butLuu,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
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

		private void frmCdkemtheo_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			sql="select cicd10,vviet from "+user+".icd10 ";
			if (icd!="") sql+=" where trim(cicd10)<>'"+icd.Trim()+"'";
			sql+="order by cicd10";
			dticd=m.get_data(sql).Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;
			load_grid();
			AddGridTableStyle();
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
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "Mã ICD";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 580;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void load_grid()
		{
			if (dt==null || dt.Rows.Count==0)
				dt=d.get_data("select * from "+user+mmyy+".d_chandoan where id="+l_id+" and loai="+i_loai).Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				icd_chinh.Text=dataGrid1[i,0].ToString();
				cd_chinh.Text=dataGrid1[i,1].ToString();
			}
			catch{}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			icd_chinh.Text="";cd_chinh.Text="";
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
			d.updrec_chandoan(dt,icd_chinh.Text,cd_chinh.Text);
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
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					d.delrec(dt,"maicd='"+icd_chinh.Text+"'");
					ref_text();
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ena_object(bool ena)
		{
			icd_chinh.Enabled=ena;
			cd_chinh.Enabled=ena;
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
				MessageBox.Show(
lan.Change_language_MessageText("Nhập mã ICD bệnh  !"),d.Msg);
				icd_chinh.Focus();
				return false;
			}
			else if (icd_chinh.Text=="" && cd_chinh.Text!="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập mã ICD bệnh  !"),d.Msg);
				icd_chinh.Focus();
				return false;
			}
			else if (cd_chinh.Text=="" && icd_chinh.Text!="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập chẩn đoán bệnh  !"),d.Msg);
				if (cd_chinh.Enabled) cd_chinh.Focus();
				else icd_chinh.Focus();
				return false;
			}
			if (icd!="" && icd_chinh.Text.Trim()==icd.Trim())
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập chẩn đoán bệnh đã nhập !"),d.Msg);
				icd_chinh.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,icd_chinh.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Mã ICD không hợp lệ !"),d.Msg);
				icd_chinh.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,cd_chinh.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),d.Msg);
				cd_chinh.Focus();
				return false;
			}
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}
	}
}
