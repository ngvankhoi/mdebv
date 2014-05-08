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
	/// Summary description for frmTVuser.
	/// </summary>
	public class frmTVuser : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TextBox sql;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butOk;
		private DataSet ds=new DataSet();
		private AccessData d;
		private System.Windows.Forms.DataGrid dataGrid1;
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
			d=acc;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTVuser));
            this.sql = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // sql
            // 
            this.sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sql.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sql.Location = new System.Drawing.Point(8, 4);
            this.sql.Multiline = true;
            this.sql.Name = "sql";
            this.sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sql.Size = new System.Drawing.Size(776, 100);
            this.sql.TabIndex = 1;
            this.sql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sql_KeyDown_1);
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(327, 529);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(73, 25);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "&Thực thi";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(400, 529);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 25);
            this.butKetthuc.TabIndex = 3;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 88);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(776, 435);
            this.dataGrid1.TabIndex = 4;
            // 
            // frmTVuser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.sql);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butKetthuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTVuser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy vấn theo câu lệnh SQL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTVuser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void sql_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmTVuser_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			ds.ReadXml("..\\..\\..\\xml\\d_thongso.xml");
			sql.Text=ds.Tables[0].Rows[0]["sql"].ToString();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            string s_sql=sql.SelectedText;
			if(s_sql=="")s_sql=sql.Text;
			if (s_sql.ToLower().IndexOf("select") == -1 || s_sql.ToLower().IndexOf("update") != -1 || s_sql.ToLower().IndexOf("delete") != -1)
			{
				sql.Focus();return;
			}
			try
			{
				if (s_sql=="")
				{
					sql.Focus();
					return;
				}
				dataGrid1.DataSource=d.get_data(s_sql).Tables[0];
			}
			catch(Exception ex)
			{
				dataGrid1.DataSource=null;
				MessageBox.Show(ex.Message,d.Msg);
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			if (sql.Text!="")
			{
				ds.Tables[0].Rows[0]["sql"]=sql.Text.Trim();
				ds.WriteXml("..\\..\\..\\xml\\d_thongso.xml");
			}
			d.close();this.Close();
		}

        private void sql_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
        {        
			if(e.KeyCode==Keys.F5)
			{
				butOk_Click(null,null);
			}
        }
	}
}
