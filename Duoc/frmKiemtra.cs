using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmKiemtra.
	/// </summary>
	public class frmKiemtra : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private int i_nhom;
		private string s_mmyy;
		private DataTable tmp=new DataTable();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d;
		private System.Windows.Forms.CheckBox all;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKiemtra(LibDuoc.AccessData acc,int nhom,string mmyy)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;s_mmyy=mmyy;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemtra));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.all = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Năm :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yyyy
            // 
            this.yyyy.Location = new System.Drawing.Point(152, 16);
            this.yyyy.Maximum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 20);
            this.yyyy.TabIndex = 3;
            this.yyyy.Value = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // mm
            // 
            this.mm.Location = new System.Drawing.Point(72, 16);
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
            this.mm.Size = new System.Drawing.Size(40, 20);
            this.mm.TabIndex = 1;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(44, 51);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Duoc.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(113, 51);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // all
            // 
            this.all.Location = new System.Drawing.Point(8, 104);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(104, 24);
            this.all.TabIndex = 6;
            this.all.Text = "Kiểm tra tất cả";
            this.all.Visible = false;
            this.all.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // frmKiemtra
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(224, 93);
            this.Controls.Add(this.all);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKiemtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra số liệu tồn kho";
            this.Load += new System.EventHandler(this.frmKiemtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmKiemtra_Load(object sender, System.EventArgs e)
		{
			mm.Value=decimal.Parse(s_mmyy.Substring(0,2));
			yyyy.Minimum=2000+int.Parse(s_mmyy.Substring(2,2))-10;
			yyyy.Maximum=2000+int.Parse(s_mmyy.Substring(2,2))+10;
			yyyy.Value=decimal.Parse("20"+s_mmyy.Substring(2,2));
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void mm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			string mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().Substring(2,2);
			if (!d.bMmyy(mmyy))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("chưa tạo !"),d.Msg);
				mm.Focus();
				return;
			}
			if (d.bKhoaso(i_nhom,mmyy))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý kiểm tra !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				Cursor=Cursors.WaitCursor;
				d.upd_tonkho(i_nhom,mmyy);
				Cursor=Cursors.Default;
				MessageBox.Show(lan.Change_language_MessageText("Đã kiểm tra số liệu tồn kho !"),d.Msg);
			}
		}
	}
}
