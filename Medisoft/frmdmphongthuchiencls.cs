using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public class frmdmphongthuchiencls : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butHuy;
		private bool bNew;
		private int i_id;
        private string user;
		private System.Windows.Forms.Button butSua;
        private TextBox txtid;
        private TextBox txtten;
        private Label label2;
        private TextBox txtMa;
        private Label label4;
        private CheckedListBox chkloaivp;
        private DataSet ds_loaivp = new DataSet();
        private Label label3;
        private Label label5;
        private ComboBox cbChinhanh;
		private System.ComponentModel.Container components = null;
        #endregion
        private Label label6;
        private ComboBox cbLoai;

        private DataSet dschinhanh = new DataSet();
        public frmdmphongthuchiencls(AccessData acc)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; 
            if (m.bBogo) tv.GanBogo(this, textBox111);
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdmphongthuchiencls));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkloaivp = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbChinhanh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLoai = new System.Windows.Forms.ComboBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -15);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(476, 307);
            this.dataGrid1.TabIndex = 9;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(416, 355);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(-7, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(66, 355);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 5;
            this.butMoi.Text = "   &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(206, 355);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(276, 355);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(346, 355);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 6;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(136, 355);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 7;
            this.butSua.Text = "   &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // txtid
            // 
            this.txtid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(25, 303);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(46, 20);
            this.txtid.TabIndex = 11;
            // 
            // txtten
            // 
            this.txtten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtten.Location = new System.Drawing.Point(217, 305);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(269, 20);
            this.txtten.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(184, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMa
            // 
            this.txtMa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa.Location = new System.Drawing.Point(119, 304);
            this.txtMa.MaxLength = 20;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(63, 20);
            this.txtMa.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(65, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Viết tắt :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkloaivp
            // 
            this.chkloaivp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkloaivp.FormattingEnabled = true;
            this.chkloaivp.Location = new System.Drawing.Point(491, 17);
            this.chkloaivp.Name = "chkloaivp";
            this.chkloaivp.Size = new System.Drawing.Size(202, 364);
            this.chkloaivp.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Loại viện phí";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(2, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Chi nhánh :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbChinhanh
            // 
            this.cbChinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbChinhanh.FormattingEnabled = true;
            this.cbChinhanh.Location = new System.Drawing.Point(69, 328);
            this.cbChinhanh.Name = "cbChinhanh";
            this.cbChinhanh.Size = new System.Drawing.Size(223, 21);
            this.cbChinhanh.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(298, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Loại :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbLoai
            // 
            this.cbLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "Siêu âm",
            "XQuang",
            "Nội soi",
            "Điện tim",
            "Điện não",
            "CT",
            "MRI",
            "XN",
            "Thuốc"});
            this.cbLoai.Location = new System.Drawing.Point(337, 328);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(150, 21);
            this.cbLoai.TabIndex = 22;
            // 
            // frmdmphongthuchiencls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(694, 385);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.cbChinhanh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkloaivp);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmdmphongthuchiencls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phòng thực hiện cận lâm sàng";
            this.Load += new System.EventHandler(this.frmdmphongthuchiencls_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmdmphongthuchiencls_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmdmphongthuchiencls_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
            ena_text(false);
            ds_loaivp = m.get_data("select id,ten from " + m.user + ".v_loaivp order by ten");
            chkloaivp.DataSource = ds_loaivp.Tables[0];
            chkloaivp.DisplayMember = "TEN";
            chkloaivp.ValueMember = "ID";

            dschinhanh = m.get_data(" select id,ten from " + m.user + ".dmchinhanh order by ten");
            cbChinhanh.DisplayMember = "ten";
            cbChinhanh.ValueMember = "id";
            cbChinhanh.DataSource = dschinhanh.Tables[0];
            
            //
		}

		private void load_grid()
		{
            dt = m.get_data(" select * from " + user + ".dmphongthuchiencls  order by id").Tables[0];
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "ID";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên phòng";
			TextCol.Width =150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id_loaivp";
            TextCol.HeaderText = "ID_Loaivp";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "idchinhanh";
            TextCol.HeaderText = "Chinhanh";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "Loại";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();
            this.Close();
		}

		private void ena_object(bool ena)
		{
            butMoi.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            butSua.Enabled = !ena;
            cbChinhanh.Enabled = ena;
            cbLoai.Enabled = ena;
		}
        private void ena_text(bool t)
        {
            txtMa.Enabled = t;
            txtten.Enabled = t;
            chkloaivp.Enabled = t;
        }
		private void butMoi_Click(object sender, System.EventArgs e)
		{
            bNew = true;
            txtid.Text = get_id().ToString();
            f_clearchecklist();
			ena_object(true);
            ena_text(true);
            txtten.Text = "";
            txtMa.Text = "";
            txtMa.Focus();
		}

        private int get_id()
        {
            i_id = 1;
            try
            {
                i_id = int.Parse(m.get_data("select max(id) from " + user + ".dmphongthuchiencls").Tables[0].Rows[0][0].ToString()) + 1;
            }
            catch { }
            return i_id;
        }

		private bool kiemtra()
		{
			if (txtid.Text=="")
			{
				txtid.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            string s_Phongthuchiencls = "";
			if (!kiemtra()) 
                return;
            for (int i = 0; i < chkloaivp.Items.Count; i++)
                if (chkloaivp.GetItemChecked(i))
                    s_Phongthuchiencls += ds_loaivp.Tables[0].Rows[i]["id"].ToString().Trim() + ",";
            if (s_Phongthuchiencls != "")
                s_Phongthuchiencls = s_Phongthuchiencls.Substring(0, s_Phongthuchiencls.Length - 1);
            if (!m.upd_dmphongthuchiencls(i_id, txtMa.Text.Trim(), txtten.Text.Trim(), s_Phongthuchiencls, int.Parse(cbChinhanh.SelectedValue.ToString()), cbLoai.SelectedIndex))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin !"));
                return;
            }
            ena_text(false);
			load_grid();
			ena_object(false);
		}
        private void f_clearchecklist()
        {
            for (int j = 0; j < chkloaivp.Items.Count; j++)
            {
                chkloaivp.SetItemChecked(j, false);
            }
        }
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            ena_text(false);
            butMoi.Focus();
		}
		private void butHuy_Click(object sender, System.EventArgs e)    
		{
			try
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					i_id=int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
                    m.execute_data("delete from " + user + ".dmphongthuchiencls where id=" + i_id);
					load_grid();
				}
			}
			catch{}
		}

		private void ref_text()
		{
            string s_phongcls = "";
			try
			{
                int i = dataGrid1.CurrentCell.RowNumber;
				txtid.Text=dataGrid1[i,0].ToString();
                txtMa.Text = dataGrid1[i, 1].ToString();
                txtten.Text = dataGrid1[i, 2].ToString();
                s_phongcls = "," + dataGrid1[i, 3].ToString().Trim(',') + ",";
                if (s_phongcls.Trim(',') != "")
                {
                    for (int j = 0; j < ds_loaivp.Tables[0].Rows.Count; j++)
                        if (s_phongcls.IndexOf("," + ds_loaivp.Tables[0].Rows[j]["id"].ToString().Trim() + ",") != -1) 
                            chkloaivp.SetItemCheckState(j, CheckState.Checked);
                        else
                            chkloaivp.SetItemCheckState(j, CheckState.Unchecked);
                }
                cbChinhanh.SelectedValue = (dataGrid1[i, 4].ToString() == "") ? "0" : dataGrid1[i, 4].ToString();
                cbLoai.SelectedIndex = (dataGrid1[i, 5].ToString() == "") ? 0 : int.Parse(dataGrid1[i, 5].ToString());
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmdmphongthuchiencls_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10)
                butKetthuc_Click(sender,e);
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}{F4}");
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			try
			{
                i_id = int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
                bNew = false;
				ena_object(true);
                ena_text(true);
				txtten.Focus();		
			}
			catch{}
		}
	}
}
