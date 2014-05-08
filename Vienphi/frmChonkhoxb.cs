using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Vienphi
{
	/// <summary>
	/// Summary description for frmChonkho.
	/// </summary>
	public class frmChonkhoxb : System.Windows.Forms.Form
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
		private bool bCaptoa=false;
		private AccessData d;
		private int i_nhom;
        private string user = "", s_makho = "", s_kho = "", s_loaint = "";
		public int i_makho=0;
		public int i_quaythu=0;
		public string mmyy,tenkho,s_ngay,tenquay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox quay;
		private System.Windows.Forms.Label label4;
		private MaskedBox.MaskedBox ngay;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonkhoxb(AccessData acc,int nhom,string makho,string kho,string mmyy,string ngay,string tit,bool captoa,string _loaint)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_makho=makho;s_kho=kho;s_ngay=ngay;
			mm.Value=decimal.Parse(mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
			label3.Text=tit;s_loaint=_loaint;
			bCaptoa=captoa;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonkhoxb));
            this.label1 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.quay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(112, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(160, 14);
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
            this.mm.Size = new System.Drawing.Size(35, 21);
            this.mm.TabIndex = 3;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(208, 14);
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
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 5;
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
            this.label5.Location = new System.Drawing.Point(192, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "/";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(56, 38);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(200, 21);
            this.makho.TabIndex = 7;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // butOk
            // 
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(65, 96);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 10;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Vienphi.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(134, 96);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // quay
            // 
            this.quay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quay.Location = new System.Drawing.Point(56, 62);
            this.quay.Name = "quay";
            this.quay.Size = new System.Drawing.Size(200, 21);
            this.quay.TabIndex = 9;
            this.quay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quầy :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(56, 14);
            this.ngay.Mask = "##/##/####";
            this.ngay.MaxLength = 10;
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(64, 21);
            this.ngay.TabIndex = 1;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // frmChonkhoxb
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(266, 143);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quay);
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
            this.Name = "frmChonkhoxb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn kho";
            this.Load += new System.EventHandler(this.frmChonkhoxb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChonkhoxb_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			ngay.Text=s_ngay;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			string sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
            if (s_kho.Trim().Trim(',') != "") sql += " and id in (" + s_kho.Trim().Trim(',') + ")";
            if (s_makho.Trim().Trim(',') != "") sql += " and id in (" + s_makho.Trim().Trim(',') + ")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			if (makho.Items.Count>0) makho.SelectedIndex=0;
			//
            sql = "select * from " + user + ".d_dmloaint where nhom=" + i_nhom;
			if (s_loaint!="") sql+=" and id in ("+s_loaint.Substring(0,s_loaint.Length-1)+")";
			sql+=" order by stt";
			quay.DisplayMember="TEN";
			quay.ValueMember="ID";
			quay.DataSource=d.get_data(sql).Tables[0];
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
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			i_makho=int.Parse(makho.SelectedValue.ToString());
			tenkho=makho.Text;
			tenquay=quay.Text;
			s_ngay=ngay.Text;
			if(quay.SelectedIndex<0) 
			{
				MessageBox.Show(
lan.Change_language_MessageText("Đề nghị chọn")+" "+label3.Text,d.Msg);
				quay.Focus();
				SendKeys.Send("{F4}");
				return;
			}
			i_quaythu=int.Parse(quay.SelectedValue.ToString());
			d.upd_tonkho(mmyy,i_nhom,0);
			if (bCaptoa) d.upd_capsotoa(mmyy,1,s_ngay,i_quaythu);
			d.close();this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			mmyy="";
			i_makho=0;
			i_quaythu=0;
			d.close();this.Close();
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngay.Text=="") return;
			ngay.Text=ngay.Text.Trim();
			if (!d.bNgay(ngay.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngay.Focus();
				return;
			}
			ngay.Text=d.Ktngaygio(ngay.Text,10);
			if (!d.ngay(d.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,d.Ngaylv_Ngayht))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+d.Ngaylv_Ngayht.ToString()+")!",d.Msg);
				ngay.Focus();
				return;
			}
		}
	}
}
