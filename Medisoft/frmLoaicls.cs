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
	/// Summary description for frmLoaicls.
	/// </summary>
	public class frmLoaicls : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butExit;
		private AccessData m;
		private string s_cls;
		public int i_loai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLoaicls(AccessData acc,string cls)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m=acc;s_cls=cls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaicls));
            this.label1 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(48, 8);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(176, 21);
            this.loai.TabIndex = 1;
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(42, 40);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(74, 28);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "     Đồng ý";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Image = global::Medisoft.Properties.Resources.exit1;
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(118, 40);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(74, 28);
            this.butExit.TabIndex = 3;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // frmLoaicls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(234, 86);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoaicls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cận làm sàng";
            this.Load += new System.EventHandler(this.frmLoaicls_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmLoaicls_Load(object sender, System.EventArgs e)
		{
			string sql="select * from cls_loai";
			if (s_cls!="") sql+=" where id in ("+s_cls.Substring(0,s_cls.Length-1)+")";
			sql+=" order by id";
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=m.get_data(sql).Tables[0];
		}

		private void butOK_Click(object sender, System.EventArgs e)
		{
			if (loai.SelectedIndex!=-1) i_loai=int.Parse(loai.SelectedValue.ToString());
			m.close();this.Close();
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			i_loai=0;
			m.close();this.Close();
		}
	}
}
