using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmDmbhyt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.DataGrid dataGrid1;
		private LibMedi.AccessData m;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ma;
		private MaskedBox.MaskedBox tungay;
		private System.Windows.Forms.Label label35;
		private MaskedBox.MaskedBox denngay;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tenbv;
		private MaskedTextBox.MaskedTextBox mabv;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox sothe;
		private LibList.List list;
		private string user,sql;
        private Button butKetthuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmbhyt(LibMedi.AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbhyt));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.tungay = new MaskedBox.MaskedBox();
            this.label35 = new System.Windows.Forms.Label();
            this.denngay = new MaskedBox.MaskedBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.list = new LibList.List();
            this.butKetthuc = new System.Windows.Forms.Button();
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
            this.dataGrid1.Size = new System.Drawing.Size(568, 414);
            this.dataGrid1.TabIndex = 12;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã tắt :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(75, 406);
            this.ma.MaxLength = 10;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(86, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(156, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Số thẻ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(203, 406);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(145, 21);
            this.sothe.TabIndex = 1;
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(91, 457);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 8;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(161, 457);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 9;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(231, 457);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(301, 457);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(371, 457);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 10;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Enabled = false;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(409, 405);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(72, 21);
            this.tungay.TabIndex = 2;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(343, 405);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 23);
            this.label35.TabIndex = 253;
            this.label35.Text = "Từ :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Enabled = false;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(513, 405);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(72, 21);
            this.denngay.TabIndex = 3;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            this.denngay.TextChanged += new System.EventHandler(this.denngay_TextChanged);
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(449, 405);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 252;
            this.label25.Text = "Đến :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Enabled = false;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(133, 430);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(452, 21);
            this.tenbv.TabIndex = 5;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(75, 430);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(57, 21);
            this.mabv.TabIndex = 4;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(-6, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 256;
            this.label8.Text = "ĐKKCB :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(8, 496);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 257;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(441, 457);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 258;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmDmbhyt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(588, 509);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.list);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDmbhyt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục số thẻ bảo hiểm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmbhyt_KeyDown);
            this.Load += new System.EventHandler(this.frmDmbhyt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmbhyt_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			list.DisplayMember="MABV";
			list.ValueMember="TENBV";
            list.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + user + ".dmnoicapbhyt order by mabv").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
            dt = m.get_data("select a.mabn,a.ma,a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay,a.mabv,nullif(b.tenbv,'') as tenbv from " + user + ".dmbhyt a left join " + user + ".dmnoicapbhyt b on a.mabv=b.mabv order by a.sothe").Tables[0];
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
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tungay";
			TextCol.HeaderText = "Từ ngày";
			TextCol.Width = 65;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "denngay";
			TextCol.HeaderText = "Đến ngày";
			TextCol.Width = 65;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbv";
			TextCol.HeaderText = "ĐKKCB";
			TextCol.Width = 170;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabv";
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

		private void ena_object(bool ena)
		{
			ma.Enabled=ena;
            sothe.Enabled=ena;
			tungay.Enabled=ena;
			denngay.Enabled=ena;
			mabv.Enabled=ena;
			tenbv.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ma.Text="";sothe.Text="";tungay.Text="";denngay.Text="";mabv.Text="";tenbv.Text="";
			ena_object(true);
			ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ma.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (sothe.Text=="")
			{
				sothe.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			if (!m.upd_dmbhyt("",ma.Text,sothe.Text,tungay.Text,denngay.Text,mabv.Text,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"));
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
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".dmbhyt where sothe='" + sothe.Text + "'");
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
                sql = "select * from " + user + ".dmbhyt where ma='" + ma.Text + "'";
				if (sothe.Text!="") sql+=" and sothe<>'"+sothe.Text+"'";
				if (m.get_data(sql).Tables[0].Rows.Count>0)
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
				sothe.Text=dataGrid1[i,1].ToString();
				tungay.Text=dataGrid1[i,2].ToString();
				denngay.Text=dataGrid1[i,3].ToString();
				tenbv.Text=dataGrid1[i,4].ToString();
				mabv.Text=dataGrid1[i,5].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmDmbhyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void tungay_Validated(object sender, System.EventArgs e)
		{
			tungay.Text=tungay.Text.Trim();
			if (tungay.Text.Length==6) tungay.Text=tungay.Text+DateTime.Now.Year.ToString();
			if (tungay.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),LibMedi.AccessData.Msg);
				tungay.Focus();
				return;
			}
			if (!m.bNgay(tungay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tungay.Focus();
				return;
			}
		}

		private void denngay_Validated(object sender, System.EventArgs e)
		{
			denngay.Text=denngay.Text.Trim();
			if (denngay.Text.Length==6) denngay.Text=denngay.Text+DateTime.Now.Year.ToString();
			if (denngay.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),LibMedi.AccessData.Msg);
				denngay.Focus();
				return;
			}
			if (!m.bNgay(denngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				denngay.Focus();
				return;
			}
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			try
			{
                tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
			}
			catch{}
		}

		private void Filt_noicap(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
		}

		private void tenbv_TextChanged(object sender, System.EventArgs e)
		{
			Filt_noicap(tenbv.Text);
			list.BrowseToText(tenbv,mabv,butLuu,mabv.Location.X,mabv.Location.Y+mabv.Height,mabv.Width+tenbv.Width+2,mabv.Height);
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible)
				{
					list.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

        private void denngay_TextChanged(object sender, EventArgs e)
        {

        }
	}
}
