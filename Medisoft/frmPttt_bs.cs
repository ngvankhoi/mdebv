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
	/// Summary description for frmDiungthuoc.
	/// </summary>
	public class frmPttt_bs : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private LibList.List list;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private DataTable dtbs=new DataTable();
		private string sql,user;
		private decimal l_id;
		private int i_row;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.TextBox mabs;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPttt_bs(LibMedi.AccessData acc,decimal id)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; l_id = id; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPttt_bs));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ten = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.list = new LibList.List();
            this.mabs = new System.Windows.Forms.TextBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(546, 238);
            this.dataGrid1.TabIndex = 14;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(281, 232);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(271, 21);
            this.ten.TabIndex = 4;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(176, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y Bác sỹ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Loại :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(40, 232);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(136, 21);
            this.loai.TabIndex = 1;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(264, 328);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 21;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(232, 232);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(48, 21);
            this.mabs.TabIndex = 3;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(444, 264);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(374, 264);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 9;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(304, 264);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(234, 264);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(164, 264);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 8;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(94, 264);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 7;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // frmPttt_bs
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(562, 351);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.list);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPttt_bs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phẫu thủ thuật";
            this.Load += new System.EventHandler(this.frmDiungthuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDiungthuoc_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dtbs=m.get_data("select * from "+user+".dmbs where nhom not in ("+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];
			list.DisplayMember="MA";
			list.ValueMember="HOTEN";
			list.DataSource=dtbs;

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=m.get_data("select * from "+user+".pttt_loai order by id").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
			sql="select a.*,b.ten as tenloai,c.hoten as tenbs from "+user+".pttt_bs a,"+user+".pttt_loai b,"+user+".dmbs c ";
			sql+=" where a.loai=b.id and a.mabs=c.ma and a.id="+l_id;
			sql+=" order by a.loai,a.mabs";
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
			TextCol.MappingName = "tenloai";
			TextCol.HeaderText = "Loại";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabs";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Y Bác sỹ";
			TextCol.Width = 360;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter(ten.Text);
				list.BrowseToICD10(ten,mabs,butLuu,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+ten.Width+2,mabs.Height);
			}		
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				loai.SelectedValue=dataGrid1[i_row,3].ToString();
				mabs.Text=dataGrid1[i_row,1].ToString();
				ten.Text=dataGrid1[i_row,2].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			loai.Enabled=ena;
			mabs.Enabled=ena;
			ten.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (!ena) butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			mabs.Text="";
			ten.Text="";
			loai.Focus();
			SendKeys.Send("{F4}");
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			loai.Focus();
		}

		private bool kiemtra()
		{
			if (ten.Text=="" || mabs.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (loai.SelectedIndex==-1 && loai.Items.Count>0)
			{
				loai.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (!m.upd_pttt_bs(l_id,int.Parse(loai.SelectedValue.ToString()),mabs.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),LibMedi.AccessData.Msg);
				return;
			}
			updrec();
			ena_object(false);
		}

		private void updrec()
		{
			DataRow r1=m.getrowbyid(ds.Tables[0],"mabs='"+mabs.Text+"'");
			if (r1==null)
			{
				DataRow r2=ds.Tables[0].NewRow();
				r2["mabs"]=mabs.Text;
				r2["tenbs"]=ten.Text;
				r2["loai"]=loai.SelectedValue.ToString();
				r2["tenloai"]=loai.Text;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("mabs='"+mabs.Text+"'");
				if (dr.Length>0)
				{
					dr[0]["loai"]=loai.SelectedValue.ToString();
					dr[0]["tenloai"]=loai.Text;
					dr[0]["tenbs"]=ten.Text;
				}
		}
		}
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+user+".pttt_bs where mabs='"+mabs.Text+"' and id="+l_id);
                m.delrec(ds.Tables[0],"mabs='"+mabs.Text+"'");
				ref_text();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1 && loai.Items.Count>0) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
			if (r!=null) ten.Text=r["hoten"].ToString();
			else ten.Text="";
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
