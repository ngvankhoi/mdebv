using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmChonkhong.
	/// </summary>
	public class frmChonkhong : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown mm;
		public System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private string s_makho,user;
        public int i_makho = 0, i_manguon = -1, i_lanthu = 1, i_manhom = -1, i_loaiphieu = -1;
		public string mmyy,tenkho,tennguon;
        private ComboBox manguon;
        private Label label3;
        private ComboBox cbnhom;
        private Label label6;
        public ComboBox cmbQui;
        public DateTimePicker den;
        public DateTimePicker tu;
        private Label label7;
        private Label label8;
        private ComboBox loaibc;
        private Label label9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonkhong(AccessData acc,int nhom,string kho,string mmyy)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;			
			
            mm.Enabled = mmyy.Substring(0, 2) != "20";
            if (mm.Enabled) mm.Value = decimal.Parse(mmyy.Substring(0, 2));
            else mm.Value = 12;
            yyyy.Value = decimal.Parse("20" + mmyy.Substring(2, 2));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonkhong));
            this.label1 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbnhom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbQui = new System.Windows.Forms.ComboBox();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.loaibc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(85, 31);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(35, 22);
            this.mm.TabIndex = 0;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.ValueChanged += new System.EventHandler(this.mm_ValueChanged);
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(186, 31);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(57, 22);
            this.yyyy.TabIndex = 1;
            this.yyyy.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.yyyy.ValueChanged += new System.EventHandler(this.yyyy_ValueChanged);
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(150, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(85, 79);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(258, 21);
            this.makho.TabIndex = 3;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(113, 153);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 6;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(182, 153);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(85, 102);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(258, 21);
            this.manguon.TabIndex = 4;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(33, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nguồn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbnhom
            // 
            this.cbnhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnhom.Location = new System.Drawing.Point(85, 124);
            this.cbnhom.Name = "cbnhom";
            this.cbnhom.Size = new System.Drawing.Size(258, 21);
            this.cbnhom.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(33, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nhóm :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbQui
            // 
            this.cmbQui.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbQui.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQui.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQui.Items.AddRange(new object[] {
            "Quí 1",
            "Quí 2",
            "Quí 3",
            "Quí 4"});
            this.cmbQui.Location = new System.Drawing.Point(185, 7);
            this.cmbQui.Name = "cmbQui";
            this.cmbQui.Size = new System.Drawing.Size(58, 22);
            this.cmbQui.TabIndex = 16;
            this.cmbQui.SelectedIndexChanged += new System.EventHandler(this.cmbQui_SelectedIndexChanged);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(247, 55);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(96, 22);
            this.den.TabIndex = 20;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(85, 55);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(96, 22);
            this.tu.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(183, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "đến ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Từ ngày :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaibc
            // 
            this.loaibc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibc.Items.AddRange(new object[] {
            "Năm",
            "Quí",
            "Tháng",
            "Từ ngày...đến ngày"});
            this.loaibc.Location = new System.Drawing.Point(85, 7);
            this.loaibc.Name = "loaibc";
            this.loaibc.Size = new System.Drawing.Size(96, 22);
            this.loaibc.TabIndex = 15;
            this.loaibc.SelectedIndexChanged += new System.EventHandler(this.loaibc_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Dự trù theo :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChonkhong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(365, 185);
            this.Controls.Add(this.cmbQui);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.loaibc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbnhom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonkhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn kho";
            this.Load += new System.EventHandler(this.frmChonkhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmChonkhong_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
            if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
            else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            manguon.SelectedIndex = -1;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			string sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			makho.SelectedIndex=0;

            cbnhom.DisplayMember = "TEN";
            cbnhom.ValueMember = "ID";
            sql = "select id, ten from " + user + ".d_dmnhom where nhom=" + i_nhom;
            cbnhom.DataSource = d.get_data (sql).Tables[0];
            cbnhom.SelectedIndex = -1;

            loaibc.SelectedIndex = 0;
		}

		private void mm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}");
		}

		private void yyyy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}{F4}");
		}

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makho.SelectedIndex==-1) makho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			i_makho=int.Parse(makho.SelectedValue.ToString());
            i_manguon = (manguon.SelectedIndex!=-1)?int.Parse(manguon.SelectedValue.ToString()):-1;
            tennguon = (manguon.SelectedIndex != -1) ? manguon.Text : "";
            i_loaiphieu = loaibc.SelectedIndex;
            i_manhom = (cbnhom.SelectedIndex < 0) ? -1 : int.Parse(cbnhom.SelectedValue.ToString());
			tenkho=makho.Text;
			if (!d.bMmyy(mmyy) && mm.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm 20")+mmyy.Substring(2)+" "+lan.Change_language_MessageText("chưa tạo !"),d.Msg);
				mm.Focus();
				return;
			}
			d.close();this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			mmyy="";
			d.close();this.Close();
		}

        private void loaibc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQui.Enabled = loaibc.SelectedIndex == 0;
            yyyy.Enabled = cmbQui.Enabled;
            tu.Enabled = !cmbQui.Enabled;
            den.Enabled = tu.Enabled;
            if (loaibc.SelectedIndex == 0)
            {
                mm.Enabled = false;
                cmbQui.SelectedIndex = -1;
                yyyy.Enabled = true;
                tu.Enabled = den.Enabled = false;
                yyyy_ValueChanged(null, null);
            }
            else if (loaibc.SelectedIndex == 1)
            {
                mm.Enabled = false;
                cmbQui.SelectedIndex = 0;
                cmbQui.Enabled = true;
                tu.Enabled = den.Enabled = false;
            }
            else if (loaibc.SelectedIndex == 2)
            {
                yyyy.Enabled = cmbQui.Enabled = tu.Enabled = den.Enabled = false;
                mm.Enabled = true;
                mm_ValueChanged(null, null);
            }
            else 
            {
                if (cmbQui.SelectedIndex == -1) cmbQui.SelectedIndex = 0;
                mm.Enabled = false;
            }
        }

        private void cmbQui_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQui.SelectedIndex == 0)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()),1,1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 3, 31);
            }
            else if (cmbQui.SelectedIndex == 1)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 4, 1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 6, 30);
            }
            else if (cmbQui.SelectedIndex == 2)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 7, 1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 9, 30);
            }
            else if (cmbQui.SelectedIndex == 3)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 10, 1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 12, 31);
            }
        }

        private void yyyy_ValueChanged(object sender, EventArgs e)
        {
            if (loaibc.SelectedIndex == 0)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 1, 1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), 12, 31);
            }
            if (loaibc.SelectedIndex == 2)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()), int.Parse(mm.Value.ToString()), 1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), int.Parse(mm.Value.ToString()), 31);
            }

        }

        private void mm_ValueChanged(object sender, EventArgs e)
        {
            if (loaibc.SelectedIndex == 2)
            {
                tu.Value = new DateTime(int.Parse(yyyy.Value.ToString()), int.Parse(mm.Value.ToString()), 1);
                den.Value = new DateTime(int.Parse(yyyy.Value.ToString()), int.Parse(mm.Value.ToString()), DateTime.DaysInMonth(int.Parse(yyyy.Value.ToString()),int.Parse(mm.Value.ToString())));
            }
        }
	}
}
