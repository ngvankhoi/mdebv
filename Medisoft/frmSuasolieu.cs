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
	/// Summary description for frmSuasolieu.
	/// </summary>
	public class frmSuasolieu : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox macu;
		private System.Windows.Forms.TextBox mamoi;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butSua;
		private AccessData m;
		private DataRow r;
        private string user;
		private DataSet ds=new DataSet();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSuasolieu(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuasolieu));
            this.label1 = new System.Windows.Forms.Label();
            this.solieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.macu = new System.Windows.Forms.TextBox();
            this.mamoi = new System.Windows.Forms.TextBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sửa số liệu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solieu
            // 
            this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Location = new System.Drawing.Point(72, 12);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(208, 21);
            this.solieu.TabIndex = 1;
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã củ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(143, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã mới :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // macu
            // 
            this.macu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.macu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macu.Location = new System.Drawing.Point(72, 36);
            this.macu.Name = "macu";
            this.macu.Size = new System.Drawing.Size(64, 21);
            this.macu.TabIndex = 3;
            this.macu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            this.macu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.macu_KeyPress);
            // 
            // mamoi
            // 
            this.mamoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mamoi.Location = new System.Drawing.Point(208, 36);
            this.mamoi.Name = "mamoi";
            this.mamoi.Size = new System.Drawing.Size(64, 21);
            this.mamoi.TabIndex = 5;
            this.mamoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            this.mamoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.macu_KeyPress);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(145, 81);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(73, 81);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // frmSuasolieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 141);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.mamoi);
            this.Controls.Add(this.macu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSuasolieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa số liệu";
            this.Load += new System.EventHandler(this.frmSuasolieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSuasolieu_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			ds.ReadXml("..//..//..//xml//doima.xml");
			solieu.DisplayMember="NOIDUNG";
			solieu.ValueMember="STT";
			solieu.DataSource=ds.Tables[0];
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void macu_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//m.MaskDecimal(e);
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (macu.Text=="")
			{
				macu.Focus();return;
			}
			if (mamoi.Text=="")
			{
				mamoi.Focus();return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý sửa ")+solieu.Text.Trim()+" ?",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				r=m.getrowbyid(ds.Tables[0],"stt='"+solieu.SelectedValue.ToString()+"'");
				if (r!=null)
				{
					if (m.get_data("select * from "+user+"."+r["k1"].ToString()+" where "+r["k2"].ToString()+"='"+macu.Text+"'").Tables[0].Rows.Count==0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã ")+macu.Text+lan.Change_language_MessageText(" trong danh mục !"),LibMedi.AccessData.Msg);
						macu.Focus();
						return;
					}
					if (m.get_data("select * from "+user+"."+r["k1"].ToString()+" where "+r["k2"].ToString()+"='"+mamoi.Text+"'").Tables[0].Rows.Count==0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã ")+mamoi.Text+lan.Change_language_MessageText(" trong danh mục !"),LibMedi.AccessData.Msg);
						mamoi.Focus();
						return;
					}
					Cursor=Cursors.WaitCursor;
					string s,tab,fie;
					int phay;
					for(int i=1;i<=int.Parse(r["so"].ToString());i++)
					{
						s=r["t"+i.ToString()].ToString();
						phay=s.IndexOf(",");
						tab=s.Substring(0,phay);
						fie=s.Substring(phay+1);
						if (r["stt"].ToString()=="0")
						{
							m.execute_data("update "+user+"."+tab+" set maqu='"+mamoi.Text+"'||substr(maqu,4,2) where "+fie+"='"+macu.Text+"'");						
							m.execute_data("update "+user+"."+tab+" set maphuongxa=maqu||substr(maphuongxa,6,2) where "+fie+"='"+macu.Text+"'");
						}
						if (r["stt"].ToString()=="1")
							m.execute_data("update "+user+"."+tab+" set maphuongxa='"+mamoi.Text+"'||substr(maphuongxa,6,2) where "+fie+"='"+macu.Text+"'");
						m.execute_data("update "+user+"."+tab+" set "+fie+"='"+mamoi.Text+"' where "+fie+"='"+macu.Text+"'");
					  }
					Cursor=Cursors.Default;
					solieu.Focus();
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}
	}
}
