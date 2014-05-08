using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmChonkhoa.
	/// </summary>
	public class frmChontutruc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d=new AccessData();
		private string s_makho,s_makp,s_nhomkho,user;
		private int i_loai;
		public int i_makho,i_makp,i_nhom;
		public string mmyy,tenkho,tenkp;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label3;
        private CheckBox chkTatcakho;
        private ComboBox cbnhomkho;
        private Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChontutruc(string makp,int nhom,int loai,string nhomkho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            s_makp=makp;i_nhom=nhom;i_loai=loai;s_nhomkho=nhomkho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChontutruc));
            this.label1 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTatcakho = new System.Windows.Forms.CheckBox();
            this.cbnhomkho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(64, 16);
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
            this.mm.TabIndex = 1;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(140, 16);
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
            this.yyyy.Size = new System.Drawing.Size(52, 22);
            this.yyyy.TabIndex = 3;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(104, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(64, 86);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(220, 21);
            this.makho.TabIndex = 5;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(79, 141);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 6;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(151, 141);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 63);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(220, 21);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTatcakho
            // 
            this.chkTatcakho.AutoSize = true;
            this.chkTatcakho.Location = new System.Drawing.Point(64, 113);
            this.chkTatcakho.Name = "chkTatcakho";
            this.chkTatcakho.Size = new System.Drawing.Size(98, 17);
            this.chkTatcakho.TabIndex = 18;
            this.chkTatcakho.Text = "Xem tất cả kho";
            this.chkTatcakho.UseVisualStyleBackColor = true;
            this.chkTatcakho.Click += new System.EventHandler(this.chkTatcakho_Click);
            // 
            // cbnhomkho
            // 
            this.cbnhomkho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbnhomkho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbnhomkho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnhomkho.Location = new System.Drawing.Point(64, 40);
            this.cbnhomkho.Name = "cbnhomkho";
            this.cbnhomkho.Size = new System.Drawing.Size(220, 21);
            this.cbnhomkho.TabIndex = 19;
            this.cbnhomkho.SelectedIndexChanged += new System.EventHandler(this.cbnhomkho_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nhóm kho :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChontutruc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 176);
            this.Controls.Add(this.cbnhomkho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkTatcakho);
            this.Controls.Add(this.makp);
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
            this.Name = "frmChontutruc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khoa";
            this.Load += new System.EventHandler(this.frmChontutruc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChontutruc_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			s_makho="";
            string asql = "select id,ten from " + user + ".d_dmnhomkho order by ten " ;
            cbnhomkho.DisplayMember = "TEN";
            cbnhomkho.ValueMember = "ID";
            cbnhomkho.DataSource = d.get_data(asql).Tables[0];

			foreach(DataRow r in d.get_data("select kho from "+user+".d_dmphieu where id=2").Tables[0].Rows)
				s_makho=r["kho"].ToString();
			mm.Value=DateTime.Now.Month;
			yyyy.Value=DateTime.Now.Year;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			string sql="select * from "+user+".d_dmkho where hide=0 and loai="+i_loai;
            //gam 23/08/2011
            //if (i_loai==1) 
            //{
            //    sql+=" and nhom="+i_nhom;
            //    if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            //}
            //else 
            //{
            //    sql+=" and nhom<>"+i_nhom;
            //    if (s_nhomkho!="") sql+=" and nhom in ("+s_nhomkho.Substring(0,s_nhomkho.Length-1)+")"; 
            //}
            if (i_loai == 1)
            {
                if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            }
            sql += " and nhom=" +( cbnhomkho.SelectedValue == "" ? -1 : cbnhomkho.SelectedValue);
            //end gam
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			if (makho.Items.Count>0) makho.SelectedIndex=0;

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

            sql = "select * from " + user + ".d_duockp where nhom like '%" +( cbnhomkho.SelectedValue.ToString() == "" ? "-1" : cbnhomkho.SelectedValue.ToString() )+ ",%'";//gam 23/08/2011
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by stt";
			makp.DataSource=d.get_data(sql).Tables[0];
			if (makp.Items.Count>0) makp.SelectedIndex=0;
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
            if (makho.SelectedIndex == -1)
            {
                makho.Focus();
                return;
            }
			mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
            i_makho = (makho.Enabled) ? int.Parse(makho.SelectedValue.ToString()) : 0;
			i_makp=int.Parse(makp.SelectedValue.ToString());
			tenkho=makp.Text.Trim()+" ("+makho.Text.Trim()+")";
			tenkp=makp.Text;
            i_nhom = int.Parse(cbnhomkho.SelectedValue.ToString());
			if (!d.bMmyy(mmyy))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm 20")+mmyy.Substring(2)+" "+lan.Change_language_MessageText("chưa tạo !"),d.Msg);
				mm.Focus();
				return;
			}
			this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			mmyy="";
			this.Close();
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}

        private void chkTatcakho_Click(object sender, EventArgs e)
        {
            makho.Enabled = !chkTatcakho.Checked;
        }
        //gam 23/08/2011
        private void cbnhomkho_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow r in d.get_data("select kho from " + user + ".d_dmphieu where id=2").Tables[0].Rows)
                s_makho = r["kho"].ToString();
            mm.Value = DateTime.Now.Month;
            yyyy.Value = DateTime.Now.Year;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
            string sql = "select * from " + user + ".d_dmkho where hide=0 and loai=" + i_loai;
            
            if (i_loai == 1)
            {
                if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            }
            sql += " and nhom=" +( cbnhomkho.SelectedValue == "" ? -1 : cbnhomkho.SelectedValue);
            sql += " order by stt";
            makho.DataSource = d.get_data(sql).Tables[0];
            if (makho.Items.Count > 0) makho.SelectedIndex = 0;

            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";

            sql = "select * from " + user + ".d_duockp where nhom like '%" + ( cbnhomkho.SelectedValue.ToString() == "" ? "-1" : cbnhomkho.SelectedValue.ToString() )+ ",%'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by stt";
            makp.DataSource = d.get_data(sql).Tables[0];
            if (makp.Items.Count > 0) makp.SelectedIndex = 0;
        }
        //end gam
	}
}
