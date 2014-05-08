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
	/// Summary description for frmBtdtt.
	/// </summary>
	public class frmDstt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private MaskedTextBox.MaskedTextBox ma;
		private MaskedTextBox.MaskedTextBox ten;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox diachi;
		private System.Windows.Forms.ComboBox mavung;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox matuyen;
		private MaskedTextBox.MaskedTextBox sodt;
		private System.Windows.Forms.Label label9;
		private string sql,s_table,user,maold;
        private int itable, i_userid;
		private System.Windows.Forms.Button butIn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDstt(AccessData acc,string table,string title,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_table = table; this.Text = title; i_userid = userid;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDstt));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ma = new MaskedTextBox.MaskedTextBox();
            this.ten = new MaskedTextBox.MaskedTextBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.matt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.diachi = new MaskedTextBox.MaskedTextBox();
            this.mavung = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.matuyen = new System.Windows.Forms.ComboBox();
            this.sodt = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
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
            this.dataGrid1.Location = new System.Drawing.Point(10, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(774, 408);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(40, 432);
            this.ma.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma.MaxLength = 8;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(56, 21);
            this.ma.TabIndex = 12;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(136, 432);
            this.ten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(224, 21);
            this.ten.TabIndex = 14;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            // 
            // butThem
            // 
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(181, 464);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 21;
            this.butThem.Text = "      &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(241, 464);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 22;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(301, 464);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 19;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(361, 464);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 20;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(481, 464);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 24;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(541, 464);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 25;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(264, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tỉnh/thành phố :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matt
            // 
            this.matt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(360, 8);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(184, 21);
            this.matt.TabIndex = 3;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(361, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(424, 432);
            this.diachi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(200, 21);
            this.diachi.TabIndex = 16;
            this.diachi.Validated += new System.EventHandler(this.diachi_Validated);
            // 
            // mavung
            // 
            this.mavung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mavung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavung.Location = new System.Drawing.Point(48, 8);
            this.mavung.Name = "mavung";
            this.mavung.Size = new System.Drawing.Size(224, 21);
            this.mavung.TabIndex = 1;
            this.mavung.SelectedIndexChanged += new System.EventHandler(this.mavung_SelectedIndexChanged);
            this.mavung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavung_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "&Vùng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(544, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tuyến :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matuyen
            // 
            this.matuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matuyen.Location = new System.Drawing.Point(592, 8);
            this.matuyen.Name = "matuyen";
            this.matuyen.Size = new System.Drawing.Size(192, 21);
            this.matuyen.TabIndex = 5;
            this.matuyen.SelectedIndexChanged += new System.EventHandler(this.matuyen_SelectedIndexChanged);
            this.matuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matuyen_KeyDown);
            // 
            // sodt
            // 
            this.sodt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sodt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sodt.Enabled = false;
            this.sodt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sodt.Location = new System.Drawing.Point(688, 432);
            this.sodt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sodt.Name = "sodt";
            this.sodt.Size = new System.Drawing.Size(96, 21);
            this.sodt.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(616, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Điện thoại :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(421, 464);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 23;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // frmDstt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.sodt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.matuyen);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mavung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDstt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục cơ quan y tế chuyển đến";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDstt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDstt_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; itable = m.tableid("",s_table);
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
			mavung.DisplayMember="TEN";
			mavung.ValueMember="MA";
            mavung.DataSource = m.get_data("select * from " + user + ".dmvungbv order by ma").Tables[0];

            sql = "select * from " + user + ".dmtuyenyte ";
			if (s_table!="dstt") sql+=" where ma<>'9'";
			sql+="order by ma";
			matuyen.DisplayMember="TEN";
			matuyen.ValueMember="MA";
			matuyen.DataSource=m.get_data(sql).Tables[0];

			try
			{
                mavung.SelectedValue = m.get_data("select mavung from " + user + ".btdtt where matt='" + m.Mabv.Substring(0, 3) + "'").Tables[0].Rows[0][0].ToString();
				matt.SelectedValue=m.Mabv.Substring(0,3);
			}
			catch{}
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void load_tinh()
		{
            matt.DataSource = m.get_data("select * from " + user + ".btdtt where mavung='" + mavung.SelectedValue.ToString() + "'").Tables[0];
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
			TextCol.MappingName = "mabv";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbv";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 300;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "diachi";
			TextCol.HeaderText = "Địa chỉ";
			TextCol.Width = 270;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sodt";
			TextCol.HeaderText = "Điện thoại";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

		}

		private void load_grid()
		{
			if (butThem.Enabled)
			{
                sql = "select * from " +user+"."+s_table + " where matinh='" + matt.SelectedValue.ToString() + "'";
				sql+=" and matuyen='"+matuyen.SelectedValue.ToString()+"'";
				sql+=" order by mabv";
				ds=m.get_data(sql);
				dataGrid1.DataSource=ds.Tables[0];
			}
		}

		private void ena_object(bool ena)
		{
            if (s_table == "dmnoicapbhyt" || s_table=="dstt") ma.Enabled = ena;
			ten.Enabled=ena;
			diachi.Enabled=ena;
			sodt.Enabled=ena;
			butThem.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			maold=ma.Text=ten.Text=diachi.Text=sodt.Text="";
			ena_object(true);
            if (ma.Enabled) ma.Focus();
            else ten.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            maold = ma.Text;
			ena_object(true);
            ma.Enabled = (s_table == "dmnoicapbhyt");
            if (ma.Enabled) ma.Focus();
            else ten.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return;
			}

            if (s_table == "dmnoicapbhyt")
            {
                if (ma.Text == "" && ma.Enabled)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mã số !"), LibMedi.AccessData.Msg);
                    ma.Focus();
                    return;
                }/*
                DataTable tmp = m.get_data("select * from " + user + ".dmnoicapbhyt where mabv='" + maold + "' and mabv<>'" + ma.Text + "'").Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    MessageBox.Show("Mã số đã tồn tại !", LibMedi.AccessData.Msg);
                    ma.Focus();
                    return;
                }*/
            }
			else if (ma.Text=="")
			{
				try
				{
                    int i = int.Parse(m.get_data("select max(substr(mabv,7,2)) from " + user + "." + s_table + " where matinh='" + matt.SelectedValue.ToString() + "'" + " and matuyen='" + matuyen.SelectedValue.ToString() + "'").Tables[0].Rows[0][0].ToString()) + 1;
					ma.Text=matt.SelectedValue.ToString()+"."+matuyen.SelectedValue.ToString()+"."+i.ToString().PadLeft(2,'0');
				}
				catch
				{
					ma.Text=matt.SelectedValue.ToString()+"."+matuyen.SelectedValue.ToString()+".01";
				}
			}
            if (m.get_data("select * from " + user + "."+s_table+" where mabv='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + diachi.Text + "^" + sodt.Text + "^" + matuyen.SelectedValue.ToString() + "^" + "" + "^" + "" + "^" + mavung.SelectedValue.ToString() + "^" + matt.SelectedValue.ToString());
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
			m.upd_tenvien(s_table,ma.Text,ten.Text,diachi.Text,sodt.Text,matuyen.SelectedValue.ToString(),"","",mavung.SelectedValue.ToString(),matt.SelectedValue.ToString());
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
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    m.upd_eve_tables(itable, i_userid, "del");
                    m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + "."+s_table, "mabv='" + ma.Text + "'"));
                    m.execute_data("delete from " + user + "." + s_table + " where mabv='" + ma.Text + "'");
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
				ma.Text=dataGrid1[i,0].ToString();
				ten.Text=dataGrid1[i,1].ToString();
				diachi.Text=dataGrid1[i,2].ToString();
				sodt.Text=dataGrid1[i,3].ToString();
			}
			catch{}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
                /*
				if (ma.Text.Length!=8)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chiều dài chưa đủ !"),LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
				if (ma.Text.Substring(0,3)!=matt.SelectedValue.ToString())
				{
					MessageBox.Show(lan.Change_language_MessageText("Ba ký tự đầu phải là (")+matt.SelectedValue.ToString()+")",LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}*/
				DataRow r=m.getrowbyid(ds.Tables[0],"mabv='"+ma.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"),LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (ten.Text!="") ten.Text=m.Caps(ten.Text);
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
			}
			catch{}
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void diachi_Validated(object sender, System.EventArgs e)
		{
			if (diachi.Text!="") diachi.Text=m.Caps(diachi.Text);	
		}

		private void mavung_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_tinh();
			}
			catch{}
		}

		private void mavung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matuyen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
			}
			catch{}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmIndstt f=new frmIndstt(m,s_table,this.Text);
			f.ShowDialog(this);
		}
	}
}
