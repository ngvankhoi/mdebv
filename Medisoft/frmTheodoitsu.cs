using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public class frmTheodoitsu : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.CheckedListBox noidung;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataTable dt=new DataTable();
        private DataTable dticd = new DataTable();
		private string s_noidung,user,s_ngay="";
		private bool bTiensu,bbadt;
		private AccessData m;
		private System.Windows.Forms.TextBox ten;
        private DataGridView dataGridView1;
        private Label label5;
        private System.Windows.Forms.MaskedTextBox txtngay;
        private Label label6;
        private TextBox icd_chinh;
        private TextBox cd_chinh;
        protected LibList.List listICD;
        private DataGridViewTextBoxColumn ngay;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn tiensu;
        private DataGridViewTextBoxColumn maicd;
        private Button butxoa;
        private Button butmoi;
		private System.ComponentModel.Container components = null;

		public frmTheodoitsu(AccessData acc,string _mabn,string _hoten,string _namsinh,string _phai)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

            m=acc;mabn.Text=_mabn;hoten.Text=_hoten;namsinh.Text=_namsinh;phai.Text=_phai;
            if (m.bBogo) tv.GanBogo(this, textBox111);
		}
        //TU:25/05/2011
        public frmTheodoitsu(AccessData acc, string _mabn, string _hoten, string _namsinh, string _phai,bool _badt,string _s_ngay)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; mabn.Text = _mabn; hoten.Text = _hoten; namsinh.Text = _namsinh; phai.Text = _phai;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            bbadt = _badt; s_ngay = _s_ngay;
        }
        //end Tu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheodoitsu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.noidung = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.ten = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiensu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maicd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtngay = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.icd_chinh = new System.Windows.Forms.TextBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.listICD = new LibList.List();
            this.butxoa = new System.Windows.Forms.Button();
            this.butmoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // noidung
            // 
            this.noidung.CheckOnClick = true;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(52, 32);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(463, 276);
            this.noidung.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(112, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(299, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(395, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(52, 8);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(64, 21);
            this.mabn.TabIndex = 5;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(164, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(140, 21);
            this.hoten.TabIndex = 6;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(363, 8);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 7;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(451, 8);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(64, 21);
            this.phai.TabIndex = 8;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(299, 379);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "     &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(445, 379);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(52, 32);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ten.Size = new System.Drawing.Size(463, 279);
            this.ten.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ngay,
            this.stt,
            this.tiensu,
            this.maicd});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(52, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(463, 279);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // ngay
            // 
            this.ngay.DataPropertyName = "ngay";
            this.ngay.FillWeight = 65.10722F;
            this.ngay.HeaderText = "Ngày";
            this.ngay.Name = "ngay";
            this.ngay.ReadOnly = true;
            // 
            // stt
            // 
            this.stt.DataPropertyName = "sott";
            this.stt.FillWeight = 45.68528F;
            this.stt.HeaderText = "Số TT";
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // tiensu
            // 
            this.tiensu.DataPropertyName = "tiensu";
            this.tiensu.FillWeight = 189.2075F;
            this.tiensu.HeaderText = "Tiền sử";
            this.tiensu.Name = "tiensu";
            this.tiensu.ReadOnly = true;
            // 
            // maicd
            // 
            this.maicd.DataPropertyName = "maicd";
            this.maicd.HeaderText = "CICD10";
            this.maicd.Name = "maicd";
            this.maicd.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ngày :";
            // 
            // txtngay
            // 
            this.txtngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtngay.Location = new System.Drawing.Point(45, 327);
            this.txtngay.Mask = "00/00/0000";
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(71, 20);
            this.txtngay.TabIndex = 11;
            this.txtngay.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Bệnh :";
            // 
            // icd_chinh
            // 
            this.icd_chinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.icd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(164, 326);
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(39, 21);
            this.icd_chinh.TabIndex = 0;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_chinh_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            this.icd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icd_chinh_KeyDown);
            // 
            // cd_chinh
            // 
            this.cd_chinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(205, 326);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(310, 21);
            this.cd_chinh.TabIndex = 1;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_chinh_KeyDown);
            // 
            // listICD
            // 
            this.listICD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(440, 387);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 217;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // butxoa
            // 
            this.butxoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butxoa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butxoa.Image = ((System.Drawing.Image)(resources.GetObject("butxoa.Image")));
            this.butxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butxoa.Location = new System.Drawing.Point(372, 379);
            this.butxoa.Name = "butxoa";
            this.butxoa.Size = new System.Drawing.Size(70, 25);
            this.butxoa.TabIndex = 218;
            this.butxoa.Text = "&Xóa";
            this.butxoa.Click += new System.EventHandler(this.butxoa_Click);
            // 
            // butmoi
            // 
            this.butmoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butmoi.Image = ((System.Drawing.Image)(resources.GetObject("butmoi.Image")));
            this.butmoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butmoi.Location = new System.Drawing.Point(226, 379);
            this.butmoi.Name = "butmoi";
            this.butmoi.Size = new System.Drawing.Size(70, 25);
            this.butmoi.TabIndex = 219;
            this.butmoi.Text = "&Mới";
            this.butmoi.Click += new System.EventHandler(this.butmoi_Click);
            // 
            // frmTheodoitsu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(520, 416);
            this.Controls.Add(this.butmoi);
            this.Controls.Add(this.butxoa);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtngay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noidung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTheodoitsu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theo dõi tiểu sử bệnh tật";
            this.Load += new System.EventHandler(this.frmTheodoitsu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void frmTheodoitsu_Load(object sender, System.EventArgs e)
        {
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
            if (s_ngay == "")//Khuong 07/11/2011
                s_ngay = m.Ngaygio_hienhanh.Substring(0,10);
            txtngay.Text = s_ngay.Substring(0,10);
            user = m.user;
            bTiensu = m.bTiensu;
            noidung.Visible = !bTiensu;
            if (bTiensu)
            {
                noidung.Visible = false;
                foreach (DataRow r in m.get_data("select * from " + user + ".theodoitsu where mabn='" + mabn.Text + "'").Tables[0].Rows)
                {
                    ten.Text = r["noidung"].ToString();
                    break;
                }
            }
            else
            {
                this.AcceptButton = this.butOk;
                ten.Visible = false;
                dt = m.get_data("select * from " + user + ".dmtheodoi order by stt").Tables[0];
                noidung.DataSource = dt;
                noidung.ValueMember = "TEN";
                noidung.ValueMember = "ID";
                s_noidung = "";
                foreach (DataRow r in m.get_data("select * from " + user + ".theodoitsu where mabn='" + mabn.Text + "'").Tables[0].Rows)
                {
                    s_noidung = r["noidung"].ToString();
                    break;
                }
                if (s_noidung != "")
                    for (int i = 0; i < noidung.Items.Count; i++)
                        if (s_noidung.IndexOf(dt.Rows[i]["id"].ToString().PadLeft(3, '0') + "+") != -1) noidung.SetItemCheckState(i, CheckState.Checked);
                        else noidung.SetItemCheckState(i, CheckState.Unchecked);
            }

            dticd = m.get_data("select cicd10,vviet from " + m.user + ".icd10 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;

            Load_grid();
        }

        private void Load_grid()
        {
            dataGridView1.DataSource = m.get_data("select to_char(ngay,'dd/mm/yyyy') as ngay,stt as sott,noidung as tiensu,maicd from " + user + ".theodoitsu where mabn='" + mabn.Text.Trim() + "' order by ngay desc").Tables[0];
        }

		private void butOk_Click(object sender, System.EventArgs e)
		{
            int i_stt = 1;
            try { i_stt = int.Parse(m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='"+mabn.Text.Trim()+"'").Tables[0].Rows[0][0].ToString()); }
            catch { i_stt = 1; }
			if (bTiensu) m.upd_theodoitsu(mabn.Text,cd_chinh.Text,s_ngay,icd_chinh.Text,i_stt);
			else
			{
                //s_noidung="";
                //for(int i=0;i<noidung.Items.Count;i++)
                //    if (noidung.GetItemChecked(i)) s_noidung+=dt.Rows[i]["id"].ToString().PadLeft(3,'0')+"+";
                //if (s_noidung=="") m.execute_data("delete from "+user+".theodoitsu where mabn='"+mabn.Text+"'");
                //else m.upd_theodoitsu(mabn.Text,s_noidung,s_ngay,"",i_stt);
                m.upd_theodoitsu(mabn.Text, cd_chinh.Text, s_ngay, icd_chinh.Text, i_stt);
			}
            Load_grid();
			//m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void cd_chinh_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cd_chinh)
            {
                if (icd_chinh.Text == "")
                {
                    Filt_ICD(cd_chinh.Text);
                    listICD.BrowseToICD10(cd_chinh, icd_chinh, icd_chinh, icd_chinh.Location.X, icd_chinh.Location.Y + icd_chinh.Height, icd_chinh.Width + cd_chinh.Width + 2, icd_chinh.Height);
                }
            }
        }

        private void Filt_ICD(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listICD.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "vviet like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void icd_chinh_Validated(object sender, EventArgs e)
        {
            if (icd_chinh.Text == "" && !cd_chinh.Enabled)
            {
                cd_chinh.Text = "";
                butOk.Focus();
                return;
            }
            else if (icd_chinh.Text != "")//s_icd_chinh
            {
                cd_chinh.Text = m.get_vviet(icd_chinh.Text);
                if (cd_chinh.Text == "" && icd_chinh.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        cd_chinh.Text = f.mTen;
                        icd_chinh.Text = f.mICD;
                    }
                }
            }
        }

        private void icd_chinh_TextChanged(object sender, EventArgs e)
        {
            listICD.Hide();
        }

        private void icd_chinh_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    icd_kemtheo.Focus();
        }

        private void cd_chinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }		
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int current = dataGridView1.CurrentRow.Index;
                txtngay.Text = dataGridView1["ngay", current].Value.ToString();
                icd_chinh.Text = dataGridView1["maicd", current].Value.ToString();
                cd_chinh.Text = dataGridView1["tiensu", current].Value.ToString();
            }
            catch { }
        }

        private void butxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này không?", "Medisoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                m.execute_data("delete from " + user + ".theodoitsu where mabn='" + mabn.Text + "' and maicd='" + dataGridView1["maicd", dataGridView1.CurrentRow.Index].Value.ToString().Trim() + "'");
            Load_grid();
        }

        private void butmoi_Click(object sender, EventArgs e)
        {
            icd_chinh.Text = "";
            cd_chinh.Text = "";
            icd_chinh.Focus();
        }
        
	}
}
