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
	/// Summary description for frmChonkp.
	/// </summary>
	public class frmChonkp : System.Windows.Forms.Form
	{
        Language lan;// = new Language(); 
        Bogotiengviet tv;// = new Bogotiengviet(); 
        protected System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        protected ComboBox makp;
        protected Label label2;
        protected Label label1;
        protected ComboBox phong;
        protected Label label5;
        protected TextBox tenbs;
        protected TextBox mabs;
        protected DataTable dtbs;// = new DataTable();
        protected LibList.List listBS;
		public string s_makp="",s_mabs="",s_tenkp="";
		public int i_phong=0,i_maba,i_chinhanh=0;
        protected string sql;
        protected bool bPhonggiuong;
        protected AccessData m;//=new AccessData();
        protected Button butCancel;
        protected Button butOk;
        protected ComboBox tenba;
        protected Label label3;
        protected string s_pk = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmChonkp()
        {
            InitializeComponent();
            init();
            //Language lan = new Language();
            //lan.Read_Language_to_Xml(this.Name.ToString(), this);
            //lan.Changelanguage_to_English(this.Name.ToString(), this);
            //m = acc; s_makp = _makp; s_mabs = _mabs;
        }
		public frmChonkp(AccessData acc,string _makp,string _mabs)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            init();
            //Language lan = new Language();
            //lan.Read_Language_to_Xml(this.Name.ToString(), this);
            //lan.Changelanguage_to_English(this.Name.ToString(), this);
            m=acc;s_makp=_makp;s_mabs=_mabs;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //TU:07/04/2011
        public frmChonkp(AccessData acc, string _makp, string _mabs,string _pk,int _chinhanh)
        {
            InitializeComponent();
            init();
            //Language lan = new Language();
            //lan.Read_Language_to_Xml(this.Name.ToString(), this);
            //lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_makp = _makp; s_mabs = _mabs; s_pk = _pk; i_chinhanh = _chinhanh;
        }
        //end TU

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonkp));
            this.makp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.phong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.tenba = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(48, 8);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(200, 21);
            this.makp.TabIndex = 0;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Khoa :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Phòng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(48, 55);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(200, 21);
            this.phong.TabIndex = 2;
            this.phong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-9, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 33;
            this.label5.Text = "Y Bác sĩ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(88, 79);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(160, 21);
            this.tenbs.TabIndex = 4;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(48, 79);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 3;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(168, 156);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 227;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = global::Medisoft.Properties.Resources.exit1;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(130, 108);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(74, 28);
            this.butCancel.TabIndex = 6;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(54, 108);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(72, 28);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "&Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(48, 32);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(200, 21);
            this.tenba.TabIndex = 1;
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(-1, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 229;
            this.label3.Text = "Bệnh án :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChonkp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 191);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonkp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thông tin";
            this.Load += new System.EventHandler(this.frmChonkp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChonkp_Load(object sender, System.EventArgs e)
		{
            LoadData();
		}
        public void LoadData()
        {
            if (s_pk != "")
            {
                tenba.Enabled = false;
                phong.Enabled = false;
                mabs.Enabled = false;
                tenbs.Enabled = false;
            }
            bPhonggiuong = m.bPhonggiuong;
            phong.Enabled = bPhonggiuong;
            dtbs = m.get_data("select * from " + m.user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

            tenba.DisplayMember = "TENVT";
            tenba.ValueMember = "MABA";

            phong.DisplayMember = "TEN";
            phong.ValueMember = "ID";

            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";
            if (s_pk == "")
                sql = "select * from " + m.user + ".btdkp_bv  where makp<>'01'";
            else //TU:07/04/2011
                sql = "select * from " + m.user + ".btdkp_bv  where loai=1 ";
            //end TU
            if (s_makp != "")
            {
                if (s_makp.IndexOf(",") == -1) s_makp = s_makp + ",";
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_chinhanh != 0) sql += " and (chinhanh="+i_chinhanh+" or chinhanh=0) ";
            sql += " order by loai,makp";
            makp.DataSource = m.get_data(sql).Tables[0];
            if (makp.SelectedIndex != -1)
            {
                phong.DataSource = m.get_data("select * from " + m.user + ".dmphong where makp='" + makp.SelectedValue.ToString() + "' order by stt").Tables[0];
                phong.SelectedIndex = -1;
                load_maba();
            }
            if (s_mabs != "")
            {
                mabs.Text = s_mabs;
                DataRow r = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r != null) tenbs.Text = r["hoten"].ToString();
                else tenbs.Text = "";
                if (mabs.Text != "" && tenbs.Text != "")
                {
                    mabs.Enabled = false; tenbs.Enabled = false;
                }
            }
        }
        private void load_maba()
        {
            string s_maba = m.get_data("select maba from " + m.user + ".btdkp_bv where makp='" + makp.SelectedValue.ToString() + "'").Tables[0].Rows[0][0].ToString();
            sql = "select * from " + m.user + ".dmbenhan_bv where loaiba=2 ";
            if (s_maba != "") sql += " and maba in (" + s_maba + ")";
            sql += " order by maba";
            tenba.DataSource = m.get_data(sql).Tables[0];
        }

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,butOk,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}	
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r["hoten"].ToString();
				else tenbs.Text="";
			}
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp && makp.SelectedIndex!=-1)
			{
                phong.DataSource = m.get_data("select * from " + m.user + ".dmphong where makp='" + makp.SelectedValue.ToString() + "' order by stt").Tables[0];
				phong.SelectedIndex=-1;
				load_maba();
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (makp.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn khoa !"),LibMedi.AccessData.Msg);
				makp.Focus();
				return;
			}
            if (s_pk == "")
            {
                if (tenba.SelectedIndex == -1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chọn bệnh án !"), LibMedi.AccessData.Msg);
                    tenba.Focus();
                    return;
                }
            }
			s_tenkp=makp.Text;
			s_makp=makp.SelectedValue.ToString();
			s_mabs=mabs.Text;
			if (phong.SelectedIndex!=-1) i_phong=int.Parse(phong.SelectedValue.ToString());
            try { i_maba = int.Parse(tenba.SelectedValue.ToString()); }
            catch { }
			this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			s_makp="";
			this.Close();
		}
        public void init()
        {
            lan = new Language();
            m = new AccessData();
            tv = new Bogotiengviet();
            listBS = new LibList.List();
            dtbs = new DataTable();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        public string strmakp { get { return s_makp; } set { s_makp = value; } }
        public string strmabs { get { return s_mabs; } set { s_mabs = value; } }
        public string strpk { get { return s_pk; } set { s_pk = value; } }
	}
}
