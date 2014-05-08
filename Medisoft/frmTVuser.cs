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
	/// Summary description for frmTVuser.
	/// </summary>
	public class frmTVuser : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TextBox sql;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butOk;
		private DataSet ds=new DataSet();
		private AccessData m;
        private string asql = "";
		private System.Windows.Forms.DataGrid dataGrid1;
        private Button butclear;
        private Panel panel1;
        private SplitContainer splitContainer1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTVuser(AccessData acc)
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
        public frmTVuser(AccessData acc, string _sql)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            asql = _sql;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTVuser));
            this.sql = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butclear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sql
            // 
            this.sql.BackColor = System.Drawing.SystemColors.Info;
            this.sql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sql.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql.Location = new System.Drawing.Point(0, 0);
            this.sql.Multiline = true;
            this.sql.Name = "sql";
            this.sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sql.Size = new System.Drawing.Size(792, 159);
            this.sql.TabIndex = 1;
            this.sql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sql_KeyDown_1);
            // 
            // butOk
            // 
            this.butOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(368, 3);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "&Thực thi";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(439, 3);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 3;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(792, 379);
            this.dataGrid1.TabIndex = 4;
            // 
            // butclear
            // 
            this.butclear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butclear.Location = new System.Drawing.Point(295, 3);
            this.butclear.Name = "butclear";
            this.butclear.Size = new System.Drawing.Size(70, 25);
            this.butclear.TabIndex = 5;
            this.butclear.Text = "&Xóa lỗi";
            this.butclear.Click += new System.EventHandler(this.butclear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butKetthuc);
            this.panel1.Controls.Add(this.butclear);
            this.panel1.Controls.Add(this.butOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 31);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sql);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 542);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 7;
            // 
            // frmTVuser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTVuser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy vấn thông tin theo người dùng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTVuser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void sql_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmTVuser_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            if (asql == "")
            {
                butclear.Visible = false;
                ds.ReadXml("..//..//..//xml//thongso.xml");
                sql.Text = ds.Tables[0].Rows[0]["sql"].ToString();
                sql.ReadOnly = false;
            }
            else
            {
                butclear.Visible = true;
                sql.Text = asql;
                sql.ReadOnly = true;
                butOk_Click(null, null);
            }
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            string s_sql = sql.SelectedText;
            if (s_sql == "") s_sql = sql.Text;
            if (s_sql.ToLower().IndexOf("select") == -1 || s_sql.ToLower().IndexOf("update") != -1 || s_sql.ToLower().IndexOf("delete") != -1)
            {
                sql.Focus(); return;
            }
            try
            {
                if (s_sql == "")
                {
                    sql.Focus();
                    return;
                }
                dataGrid1.DataSource = m.get_data(s_sql).Tables[0];
            }
			catch(Exception ex)
			{
				dataGrid1.DataSource=null;
				MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            if (sql.Text != "" && asql == "")
			{
				ds.Tables[0].Rows[0]["sql"]=sql.Text.Trim();
				ds.WriteXml("..//..//..//xml//thongso.xml");
			}
			m.close();this.Close();
		}

        private void sql_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                butOk_Click(null, null);
            }
        }

        private void butclear_Click(object sender, EventArgs e)
        {
             string user = m.user;
            string mmyy=m.mmyy(m.ngayhienhanh_server.Substring(0,10));
            string xxx = user + mmyy;
            string _sql = "delete  from " + user + ".error ";
            m.execute_data(_sql);            
            _sql = "delete  from " + user + ".v_error ";
            m.execute_data(_sql);
            _sql = "delete  from " + user + ".d_error ";
            m.execute_data(_sql);
            _sql = "delete  from " + xxx + ".error ";
            m.execute_data(_sql);
            _sql = "delete  from " + xxx + ".v_error ";
            m.execute_data(_sql);
            _sql = "delete  from " + xxx + ".d_error ";
            m.execute_data(_sql);
            _sql = "delete  from " + xxx + ".xn_error ";
            m.execute_data(_sql);
            _sql = "delete  from " + xxx + ".cdha_error ";
            m.execute_data(_sql);
            butOk_Click(null, null);
        }
	}
}
