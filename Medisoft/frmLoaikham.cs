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
	/// Summary description for frmDm.
	/// </summary>
	public class frmLoaikham : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private int i_userid,itable;
		private long l_id;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox loai;
        private string user;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLoaikham(AccessData acc,string filexml,string title,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;i_userid=userid;this.Text=title;
			ds.ReadXml("..//..//..//xml//"+filexml+".xml");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLoaikham));
			this.butKetthuc = new System.Windows.Forms.Button();
			this.ten = new System.Windows.Forms.TextBox();
			this.butMoi = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.loai = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(421, 342);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(70, 25);
			this.butKetthuc.TabIndex = 9;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// ten
			// 
			this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ten.Enabled = false;
			this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ten.Location = new System.Drawing.Point(45, 28);
			this.ten.Multiline = true;
			this.ten.Name = "ten";
			this.ten.Size = new System.Drawing.Size(552, 308);
			this.ten.TabIndex = 3;
			this.ten.Text = "";
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(111, 342);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(60, 25);
			this.butMoi.TabIndex = 6;
			this.butMoi.Text = "      &Mới";
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(173, 342);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(60, 25);
			this.butSua.TabIndex = 7;
			this.butSua.Text = "      &Sửa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(235, 342);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(60, 25);
			this.butLuu.TabIndex = 4;
			this.butLuu.Text = "      &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(297, 342);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(60, 25);
			this.butBoqua.TabIndex = 5;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(359, 342);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(60, 25);
			this.butHuy.TabIndex = 8;
			this.butHuy.Text = "      &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(-5, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Khám :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loai
			// 
			this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loai.Location = new System.Drawing.Point(45, 4);
			this.loai.Name = "loai";
			this.loai.Size = new System.Drawing.Size(552, 21);
			this.loai.TabIndex = 1;
			this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
			this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
			// 
			// frmLoaikham
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(602, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.loai,
																		  this.label3,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.ten,
																		  this.butKetthuc});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLoaikham";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Giá trị mặc nhiên khám bệnh";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLoaikham_KeyDown);
			this.Load += new System.EventHandler(this.frmLoaikham_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmLoaikham_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=ds.Tables[0];
			loai.SelectedIndex=0;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			loai.Enabled=!ena;
			ten.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (m.get_data("select * from "+user+".ba_danhmuc where loai="+int.Parse(loai.SelectedValue.ToString())).Tables[0].Rows.Count>0)
			{
				MessageBox.Show("Khám "+loai.Text.Trim()+" mặc nhiên đã nhập !",LibMedi.AccessData.Msg);
				loai.Focus();
				return;
			}
			ten.Text="";
			l_id=0;
			ena_object(true);
			ten.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			try
			{
				ena_object(true);
				ten.Focus();
			}
			catch{}
		}

		private bool kiemtra()
		{
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			itable=m.tableid("","ba_danhmuc");
			if (l_id==0)
			{
				l_id=m.get_capid(-50);
				m.upd_eve_tables(itable,i_userid,"ins");
			}
			else
			{
				m.upd_eve_tables(itable,i_userid,"upd");
				m.upd_eve_upd_del(itable,i_userid,"upd",m.fields(user+".ba_danhmuc","id="+l_id));
			}
			if (!m.upd_ba_danhmuc(l_id,int.Parse(loai.SelectedValue.ToString()),0,ten.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được số liệu !"));
				return;
			}
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				itable=m.tableid("","ba_danhmuc");
				m.upd_eve_tables(itable,i_userid,"del");
				m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".ba_danhmuc","id="+l_id));
                m.execute_data("delete from " + user + ".ba_danhmuc where id=" + l_id);
			}
		}

		private void frmLoaikham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai)
			{
				ten.Text="";l_id=0;
                foreach (DataRow r in m.get_data("select * from " + user + ".ba_danhmuc where loai=" + int.Parse(loai.SelectedValue.ToString())).Tables[0].Rows)
				{
					l_id=long.Parse(r["id"].ToString());
					ten.Text=r["ten"].ToString();
					break;
				}
			}
		}

	}
}
