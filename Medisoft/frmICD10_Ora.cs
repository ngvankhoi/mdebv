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
	/// Summary description for frmAcc_Ora.
	/// </summary>
	public class frmICD10_Ora : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox thumuc;
		private System.Windows.Forms.Button butPath;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private System.ComponentModel.IContainer components;
        private string user;
		private AccessData m;

		public frmICD10_Ora(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m=acc;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICD10_Ora));
            this.label1 = new System.Windows.Forms.Label();
            this.thumuc = new System.Windows.Forms.TextBox();
            this.butPath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thư mục :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumuc
            // 
            this.thumuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thumuc.Enabled = false;
            this.thumuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thumuc.Location = new System.Drawing.Point(56, 16);
            this.thumuc.Name = "thumuc";
            this.thumuc.Size = new System.Drawing.Size(240, 21);
            this.thumuc.TabIndex = 1;
            // 
            // butPath
            // 
            this.butPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPath.Location = new System.Drawing.Point(298, 15);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(24, 23);
            this.butPath.TabIndex = 2;
            this.butPath.Text = "...";
            this.toolTip1.SetToolTip(this.butPath, "Thư mục chứa cơ sở dữ liệu Access");
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(76, 64);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(87, 25);
            this.butOk.TabIndex = 0;
            this.butOk.Text = "Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Medisoft.Properties.Resources.exit1;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(165, 64);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(90, 25);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmICD10_Ora
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(328, 117);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.thumuc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmICD10_Ora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật danh mục ICD10";
            this.Load += new System.EventHandler(this.frmICD10_Ora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butPath_Click(object sender, System.EventArgs e)
		{
			string sDir=System.Environment.CurrentDirectory.ToString();
			OpenFileDialog of=new OpenFileDialog();
			of.Filter="*.MDB|*.*";
			of.ShowDialog();
			thumuc.Text=of.FileName.ToString();
			System.Environment.CurrentDirectory=sDir;
		}

		private void frmICD10_Ora_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			thumuc.Text=m.get_data("select ten from "+user+".thongso where id=20").Tables[0].Rows[0][0].ToString();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (thumuc.Text=="")
			{
				butPath_Click(null,null);
				return;
			}
			if (!System.IO.File.Exists(thumuc.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không tìm thấy File !"),LibMedi.AccessData.Msg);
				return;
			}
            DataTable ora = m.get_data("select * from " + user + ".icd10  where length(trim(stt)) is null").Tables[0];
			DataTable acc=m.get_data_acc("select * from icd10",thumuc.Text).Tables[0];
			DataRow r1;
			foreach(DataRow r in ora.Rows)
			{
				r1=m.getrowbyid(acc,"cicd10='"+r["cicd10"].ToString()+"'");
				if (r1!=null)
                    m.execute_data("update " + user + ".icd10 set stt='" + r1["stt"].ToString() + "' where cicd10='" + r1["cicd10"].ToString().Trim() + "'");
			}
			MessageBox.Show(
lan.Change_language_MessageText("Đã cập nhật ICD10 xong !"),LibMedi.AccessData.Msg);
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}
	}
}
