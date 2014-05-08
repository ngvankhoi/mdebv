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
	public class frmNhomnv : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private DataTable dt1=new DataTable();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox ten;
		private string s_table,user;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.ComboBox sql;
        private ComboBox cmbDoiTuong;
        private Label label4;
        private Label label3;
        private ComboBox cmbLoaiDonVi;
        private Label label5;
        private TextBox txtMa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNhomnv(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomnv));
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
            this.sql = new System.Windows.Forms.ComboBox();
            this.cmbDoiTuong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoaiDonVi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(617, 268);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(466, 387);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 341);
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
            this.ma.Location = new System.Drawing.Point(39, 341);
            this.ma.MaxLength = 2;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(45, 21);
            this.ma.TabIndex = 2;
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(116, 341);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(508, 21);
            this.ten.TabIndex = 3;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(116, 387);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 7;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(186, 387);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 8;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(256, 387);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(326, 387);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(396, 387);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 9;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // sql
            // 
            this.sql.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sql.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql.Location = new System.Drawing.Point(8, 2);
            this.sql.Name = "sql";
            this.sql.Size = new System.Drawing.Size(616, 21);
            this.sql.TabIndex = 0;
            this.sql.SelectedIndexChanged += new System.EventHandler(this.sql_SelectedIndexChanged);
            this.sql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // cmbDoiTuong
            // 
            this.cmbDoiTuong.Enabled = false;
            this.cmbDoiTuong.FormattingEnabled = true;
            this.cmbDoiTuong.Location = new System.Drawing.Point(116, 364);
            this.cmbDoiTuong.Name = "cmbDoiTuong";
            this.cmbDoiTuong.Size = new System.Drawing.Size(131, 21);
            this.cmbDoiTuong.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(50, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Loại đơn vị :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLoaiDonVi
            // 
            this.cmbLoaiDonVi.Enabled = false;
            this.cmbLoaiDonVi.FormattingEnabled = true;
            this.cmbLoaiDonVi.Location = new System.Drawing.Point(116, 295);
            this.cmbLoaiDonVi.Name = "cmbLoaiDonVi";
            this.cmbLoaiDonVi.Size = new System.Drawing.Size(508, 21);
            this.cmbLoaiDonVi.TabIndex = 0;
            this.cmbLoaiDonVi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLoaiDonVi_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(41, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Viết tắt :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMa
            // 
            this.txtMa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(116, 318);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(131, 21);
            this.txtMa.TabIndex = 1;
            this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
            // 
            // frmNhomnv
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 423);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLoaiDonVi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDoiTuong);
            this.Controls.Add(this.sql);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhomnv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhóm nhân viên";
            this.Load += new System.EventHandler(this.frmNhomnv_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhomnv_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNhomnv_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			ds.ReadXml("..//..//..//xml//m_danhmuc.xml");
			sql.DisplayMember="TEN";
			sql.ValueMember="SQL";
			sql.DataSource=ds.Tables[0];
			s_table=ds.Tables[0].Rows[0]["sql"].ToString();
			this.Text=sql.Text;
            cmbDoiTuong.DisplayMember = "DOITUONG";
            cmbDoiTuong.ValueMember = "MADOITUONG";
            cmbDoiTuong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            cmbDoiTuong.SelectedIndex = 0;
            cmbDoiTuong.Visible = false;
            label4.Visible = false;
            cmbLoaiDonVi.DisplayMember = "ten";
            cmbLoaiDonVi.ValueMember = "id";
            // 12/02/2014cmbLoaiDonVi.DataSource = m.get_data("select id,ten,ma from " + user + ".qn_dmloaidv order by id").Tables[0];
            cmbLoaiDonVi.DataSource = m.get_data("select id,ten,ma from " + user + ".qn_dmdonvi_cap1 order by id").Tables[0];//khuyen 12/02/14 thay table qn_dmloaidv=qn_dmdonvi_cap1
            //cmbLoaiDonVi.SelectedIndex = 0;
            cmbLoaiDonVi.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            txtMa.Visible = false;
            load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());			
		}

		private void load_grid()
		{
            try
            {
                dt = m.get_data("select *,'' as ma from " + user + "." + s_table + " order by id").Tables[0];
                dataGrid1.DataSource = dt;
                ref_text();
            }
            catch { }
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Viết tắt";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 560;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            //if (s_table == "dmvungsale")
            //{
            //    TextCol = new DataGridTextBoxColumn();
            //    TextCol.MappingName = "doituong";
            //    TextCol.HeaderText = "";
            //    TextCol.Width = 0;
            //    ts.GridColumnStyles.Add(TextCol);
            //    dataGrid1.TableStyles.Add(ts);
            //}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
            cmbLoaiDonVi.Enabled = ena;
            txtMa.Enabled = ena;
            ma.Enabled = ena;
            ten.Enabled = ena;
            sql.Enabled = !ena;
            dataGrid1.Enabled = !ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            cmbDoiTuong.Enabled = ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			int i=1;
			try
			{
				i=int.Parse(m.get_data("select max(id) from "+user+"."+s_table).Tables[0].Rows[0][0].ToString())+1;
			}
			catch{}
			ma.Text=i.ToString();
			ten.Text="";
            txtMa.Text = "";
			ena_object(true);
           //khuyen 12/02/2014 if (s_table == "qn_dmdonvi" || s_table == "qn_dmloaidv" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")
            if (s_table == "qn_dmdonvi_cap2" || s_table == "qn_dmdonvi_cap1" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")//khuyen 12/02/14 thay qn_dmdonvi=qn_dmdonvi_cap2,qn_dmloaidv=qn_dmdonvi_cap1

            {
                //khuyen 12/02/2014 if (s_table == "qn_dmdonvi")
                if (s_table == "qn_dmdonvi_cap2")//khuyen 12/02/14 thay qn_dmdonvi=qn_dmdonvi_cap2
                {
                    cmbDoiTuong.Focus();
                }
                else
                {
                    txtMa.Focus();
                }
            }
            else
            {
                ten.Focus();
            }
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (s_table=="nhomnhanvien" && ma.Text==LibMedi.AccessData.nghiviec.ToString()) return;
				ena_object(true);
               //khuyen 12/02/14  if (s_table == "qn_dmdonvi" || s_table == "qn_dmloaidv" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")
                if (s_table == "qn_dmdonvi_cap2" || s_table == "qn_dmdonvi_cap1" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")//khuyen 12/02/2014 thay qn_dmdonvi=qn_dmdonvi_cap2,qn_dmloaidv=qn_dmdonvi_cap1

                {
                    txtMa.Focus();
                }
                else
                {
                    ten.Focus();
                }
			}
			catch{}
		}

		private bool kiemtra()
		{
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            // khuyen 12/02/14 if (s_table == "qn_dmloaidv" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")
            if (s_table == "qn_dmdonvi_cap1" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")//khuyen 12/02/2014 thay qn_dmloaidv=qn_dmdonvi_cap1,
            {
                if (!m.upd_danhmuc_quannhan(int.Parse(ma.Text),txtMa.Text,ten.Text,s_table))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được số liệu !"));
                    return;
                }
            }
            //khuyen 12/02/2014 if (s_table == "qn_dmdonvi")
            if (s_table == "qn_dmdonvi_cap2")//khuyen 12/02/2014 thay qn_dmdonvi=qn_dmdonvi_cap2
            {
                if (!m.upd_danhmuc_quannhan(int.Parse(ma.Text), txtMa.Text, ten.Text, int.Parse(cmbLoaiDonVi.SelectedValue.ToString()), s_table))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được số liệu !"));
                    return;
                }
            }
			if (!m.upd_danhmuc(s_table,int.Parse(ma.Text),ten.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được số liệu !"));
				return;
			}
            if(s_table=="dmvungsale")
            {
                if (cmbDoiTuong.SelectedIndex != -1)
                {
                    m.execute("update " + user + ".dmvungsale set doituong=" + cmbDoiTuong.SelectedValue+" where id="+int.Parse(ma.Text));
                }
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
			if (int.Parse(ma.Text)>0 && int.Parse(ma.Text)<10 && s_table=="nhomnhanvien")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có phép huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+user+"."+s_table+" where id="+int.Parse(ma.Text));
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;

               //khuyen 12/02/14 if (s_table == "qn_dmdonvi" || s_table == "qn_dmloaidv" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")
                if (s_table == "qn_dmdonvi_cap2" || s_table == "qn_dmdonvi_cap1" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")//khuyen 12/02/14 thay qn_dmdonvi=qn_dmdonvi_cap2,qn_dmloaidv=qn_dmdonvi_cap1

                {
                    ma.Text = dataGrid1[i, 0].ToString();
                    txtMa.Text = dataGrid1[i, 1].ToString();
                    ten.Text = dataGrid1[i, 2].ToString();
                   //khuyen 12/02/14 if (s_table == "qn_dmdonvi")
                    if (s_table == "qn_dmdonvi_cap2")//khuyen 12/02/14 thay qn_dmdonvi==qn_dmdonvi_cap2
                    {
                        cmbLoaiDonVi.SelectedValue = dt.Select("id=" + ma.Text)[0]["idloaidv"].ToString();
                    }
                }
                else
                {
                    ma.Text = dataGrid1[i, 0].ToString();
                    ten.Text = dataGrid1[i, 2].ToString();
                }
                if (s_table == "dmvungsale")
                {
                    cmbDoiTuong.SelectedValue = dt.Select("id="+ma.Text)[0]["doituong"].ToString();
                }
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
            
			ref_text();
		}

		private void frmNhomnv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void sql_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==sql)
			{
                this.Text=sql.Text;
				s_table=sql.SelectedValue.ToString();
                if (s_table == "dmvungsale")
                {
                    label4.Visible = true;
                    cmbDoiTuong.Visible = true;
                }
                else
                {
                    label4.Visible = false;
                    cmbDoiTuong.Visible = false;
                }
              //khuyen 12/02/14  if (s_table == "qn_dmdonvi")
                if (s_table == "qn_dmdonvi_cap2")//khuyen 12/02/14 thay qn_dmdonvi=qn_dmdonvi_cap2
                {
                    label3.Visible = true;
                    cmbLoaiDonVi.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                    cmbLoaiDonVi.Visible = false;
                }
               //khuyen 12/02/14 if (s_table == "qn_dmdonvi"||s_table == "qn_dmloaidv" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")
                if (s_table == "qn_dmdonvi_cap2" || s_table == "qn_dmdonvi_cap1" || s_table == "qn_dmcapbac" || s_table == "qn_dmchucvu")//khuyen thay qn_dmdonvi=qn_dmdonvi_cap2,qn_dmloaidv=qn_dmdonvi_cap1

                {
                    label5.Visible = true;
                    txtMa.Visible = true;
                }
                else
                {
                    label5.Visible = false;
                    txtMa.Visible = false;
                }
				load_grid();
			}
		}

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void cmbLoaiDonVi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

	}
}
