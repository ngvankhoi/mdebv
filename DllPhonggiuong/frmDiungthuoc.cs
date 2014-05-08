using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace DllPhonggiuong
{
	public class frmDiungthuoc : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox mucdo;
		private LibList.List list;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private string sql;
		private int i_row;
		private DataSet ds=new DataSet();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDiungthuoc(LibMedi.AccessData acc,string s_mabn,string s_hoten,string s_tuoi,string s_diachi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			d=new LibDuoc.AccessData();
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			tuoi.Text=s_tuoi;
			diachi.Text=s_diachi;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDiungthuoc));
			this.hoten = new System.Windows.Forms.TextBox();
			this.tuoi = new System.Windows.Forms.TextBox();
			this.mabn = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.ten = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.diachi = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.mucdo = new System.Windows.Forms.ComboBox();
			this.list = new LibList.List();
			this.ma = new System.Windows.Forms.TextBox();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butMoi = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(153, 4);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(152, 21);
			this.hoten.TabIndex = 11;
			this.hoten.Text = "";
			// 
			// tuoi
			// 
			this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tuoi.Enabled = false;
			this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tuoi.Location = new System.Drawing.Point(337, 4);
			this.tuoi.Name = "tuoi";
			this.tuoi.Size = new System.Drawing.Size(55, 21);
			this.tuoi.TabIndex = 13;
			this.tuoi.Text = "";
			// 
			// mabn
			// 
			this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn.Enabled = false;
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(53, 4);
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(56, 21);
			this.mabn.TabIndex = 9;
			this.mabn.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(303, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 23);
			this.label3.TabIndex = 12;
			this.label3.Text = "Tuổi :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(105, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "Họ tên :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(6, 12);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(642, 212);
			this.dataGrid1.TabIndex = 14;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// ten
			// 
			this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ten.Enabled = false;
			this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ten.Location = new System.Drawing.Point(88, 232);
			this.ten.Name = "ten";
			this.ten.Size = new System.Drawing.Size(368, 21);
			this.ten.TabIndex = 15;
			this.ten.Text = "";
			this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
			this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(-4, 232);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 23);
			this.label5.TabIndex = 16;
			this.label5.Text = "Hoạt chất :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(392, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 23);
			this.label4.TabIndex = 17;
			this.label4.Text = "Địa chỉ :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// diachi
			// 
			this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diachi.Enabled = false;
			this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diachi.Location = new System.Drawing.Point(445, 4);
			this.diachi.Name = "diachi";
			this.diachi.Size = new System.Drawing.Size(203, 21);
			this.diachi.TabIndex = 18;
			this.diachi.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(444, 232);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 19;
			this.label6.Text = "Mức độ :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mucdo
			// 
			this.mucdo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mucdo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mucdo.Enabled = false;
			this.mucdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mucdo.Location = new System.Drawing.Point(512, 232);
			this.mucdo.Name = "mucdo";
			this.mucdo.Size = new System.Drawing.Size(136, 21);
			this.mucdo.TabIndex = 20;
			this.mucdo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mucdo_KeyDown);
			// 
			// list
			// 
			this.list.BackColor = System.Drawing.SystemColors.Info;
			this.list.ColumnCount = 0;
			this.list.Location = new System.Drawing.Point(527, 320);
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
			// ma
			// 
			this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ma.Enabled = false;
			this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ma.Location = new System.Drawing.Point(240, 176);
			this.ma.Name = "ma";
			this.ma.Size = new System.Drawing.Size(40, 21);
			this.ma.TabIndex = 22;
			this.ma.Text = "";
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(482, 264);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(74, 28);
			this.butKetthuc.TabIndex = 28;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(406, 264);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(74, 28);
			this.butHuy.TabIndex = 27;
			this.butHuy.Text = "    &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(330, 264);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(74, 28);
			this.butBoqua.TabIndex = 24;
			this.butBoqua.Text = "     &Bỏ qua";
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(254, 264);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(74, 28);
			this.butLuu.TabIndex = 23;
			this.butLuu.Text = "     &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(178, 264);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(74, 28);
			this.butSua.TabIndex = 26;
			this.butSua.Text = "     &Sửa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(102, 264);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(74, 28);
			this.butMoi.TabIndex = 25;
			this.butMoi.Text = "     &Mới";
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// frmDiungthuoc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(658, 351);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butKetthuc,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.list,
																		  this.mucdo,
																		  this.ten,
																		  this.label6,
																		  this.diachi,
																		  this.label4,
																		  this.label5,
																		  this.hoten,
																		  this.tuoi,
																		  this.mabn,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1,
																		  this.ma});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDiungthuoc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dị ứng thuốc";
			this.Load += new System.EventHandler(this.frmDiungthuoc_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDiungthuoc_Load(object sender, System.EventArgs e)
		{
			list.DisplayMember="MA";
			list.ValueMember="TEN";
			list.DataSource=d.get_data("select a.ma,a.ten from d_dmhoatchat a,d_dmnhomkho b where a.nhom=b.id and b.loai=1 order by a.ten").Tables[0];

			mucdo.DisplayMember="TEN";
			mucdo.ValueMember="ID";
			mucdo.DataSource=d.get_data("select * from mucdodiung order by stt").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
		}

		private void load_grid()
		{
			sql="select distinct a.mahc,b.ten,a.mucdo,c.ten tenmucdo from diungthuoc a,d_dmhoatchat b,mucdodiung c";
			sql+=" where a.mahc=b.ma and a.mucdo=c.id and a.mabn='"+mabn.Text+"'";
			ds=d.get_data(sql);
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
			TextCol.MappingName = "mahc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên hoạt chất";
			TextCol.Width = 500;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mucdo";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenmucdo";
			TextCol.HeaderText = "Mức độ";
			TextCol.Width = 110;
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
				list.BrowseToDanhmuc(ten,ma,mucdo,0);
			}
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				mucdo.SelectedValue=dataGrid1[i_row,2].ToString();
				ma.Text=dataGrid1[i_row,0].ToString();
				ten.Text=dataGrid1[i_row,1].ToString();
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
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			mucdo.Enabled=ena;
			ten.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (!ena) butMoi.Focus();
		}

		private void mucdo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mucdo.SelectedIndex==-1 && mucdo.Items.Count>0) mucdo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ten.Text="";
			ten.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			ten.Enabled=false;
			mucdo.Focus();
		}

		private bool kiemtra()
		{
			if (ten.Text=="" || ma.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (mucdo.SelectedIndex==-1 && mucdo.Items.Count>0)
			{
				mucdo.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (!d.upd_diungthuoc(mabn.Text,ma.Text,int.Parse(mucdo.SelectedValue.ToString())))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin dị ứng thuốc !"),LibMedi.AccessData.Msg);
				return;
			}
			m.updrec_diung(ds.Tables[0],ma.Text,ten.Text,int.Parse(mucdo.SelectedValue.ToString()),mucdo.Text);	
			ena_object(false);
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
				d.execute_data("delete from diungthuoc where mabn='"+mabn.Text+"'"+" and mahc='"+ma.Text+"'");
                m.delrec(ds.Tables[0],"mahc='"+ma.Text+"'");
				ref_text();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
