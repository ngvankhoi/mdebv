using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
namespace DllPhonggiuong
{
	public class frmChonkham : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private string sql,mmyy;
		private int i_userid;
		public string s_makp,s_ngay,s_tenkp;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.ComponentModel.Container components = null;
		public frmChonkham(LibMedi.AccessData acc,string makp,int userid)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_makp=makp;i_userid=userid;
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChonkham));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.makp = new System.Windows.Forms.ComboBox();
			this.butOk = new System.Windows.Forms.Button();
			this.butCancel = new System.Windows.Forms.Button();
			this.ngay = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ngày :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Khoa :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makp
			// 
			this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(45, 35);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(171, 21);
			this.makp.TabIndex = 2;
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
			// 
			// butOk
			// 
			this.butOk.Image = ((System.Drawing.Bitmap)(resources.GetObject("butOk.Image")));
			this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butOk.Location = new System.Drawing.Point(38, 67);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(74, 28);
			this.butOk.TabIndex = 3;
			this.butOk.Text = "      Đồng ý";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// butCancel
			// 
			this.butCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("butCancel.Image")));
			this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCancel.Location = new System.Drawing.Point(115, 67);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(74, 28);
			this.butCancel.TabIndex = 4;
			this.butCancel.Text = "&Kết thúc";
			this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// ngay
			// 
			this.ngay.CustomFormat = "dd/MM/yyyy";
			this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.ngay.Location = new System.Drawing.Point(45, 12);
			this.ngay.Name = "ngay";
			this.ngay.Size = new System.Drawing.Size(83, 21);
			this.ngay.TabIndex = 0;
			this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
			this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
			// 
			// frmChonkham
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 111);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ngay,
																		  this.butCancel,
																		  this.butOk,
																		  this.makp,
																		  this.label2,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChonkham";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chọn khoa";
			this.Load += new System.EventHandler(this.frmChonkham_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private bool kiemtra()
		{
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
//			if (!m.bTiepdon(LibMedi.AccessData.Khoa))
//			{
//				MessageBox.Show("Bệnh nhân phải qua đăng ký khám bệnh !",LibMedi.AccessData.Msg);
//				return false;
//			}
			return true;
		}
		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			s_makp=makp.SelectedValue.ToString();
			s_ngay=ngay.Text;
			s_tenkp=makp.Text;
			mmyy=m.mmyy(s_ngay);
			if (!m.bMmyy(mmyy)) d.tao_user_mmyy(mmyy,i_userid);
			this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			s_makp="";
			this.Close();
		}

		private void frmChonkham_Load(object sender, System.EventArgs e)
		{
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			sql="select * from btdkp_bv where loai=0 and makp<>'01'";
			if (s_makp!="" )
			{
				if (s_makp.IndexOf(",")==-1) s_makp=s_makp+",";
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai,makp";
			makp.DataSource=m.get_data(sql).Tables[0];
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,m.Ngaylv_Ngayht))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+m.Ngaylv_Ngayht.ToString()+")!",LibMedi.AccessData.Msg);
				ngay.Focus();
				return;
			}
		}
	}
}
