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
	public class frmCls_mau : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
        private DataTable dt = new DataTable();
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ten;
		private decimal id;
        private int ichandoan = 0;
        private bool bAdmin;
		private string s_loai,sql,user;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox loai;
        private System.Windows.Forms.TextBox ghichu;
        private Label label5;
        private Label label6;
        private ComboBox vung;
        private ComboBox mabs;
        private Label label7;
        private ComboBox chandoan;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCls_mau(AccessData acc,string loai,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_loai = loai; bAdmin = admin; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCls_mau));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.vung = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(533, 516);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(40, 26);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.ReadOnly = true;
            this.ten.Size = new System.Drawing.Size(747, 484);
            this.ten.TabIndex = 5;
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(183, 516);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 8;
            this.butMoi.Text = "&Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(253, 516);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 9;
            this.butSua.Text = "&Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(323, 516);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(393, 516);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(463, 516);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 10;
            this.butHuy.Text = "&Hủy";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Loại :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(40, 3);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(75, 21);
            this.loai.TabIndex = 0;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(548, 4);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(239, 21);
            this.ghichu.TabIndex = 4;
            this.ghichu.Visible = false;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(328, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Vùng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(117, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Bác sĩ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vung
            // 
            this.vung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vung.Location = new System.Drawing.Point(376, 2);
            this.vung.Name = "vung";
            this.vung.Size = new System.Drawing.Size(112, 21);
            this.vung.TabIndex = 2;
            this.vung.SelectedIndexChanged += new System.EventHandler(this.vung_SelectedIndexChanged);
            this.vung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(161, 3);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(164, 21);
            this.mabs.TabIndex = 1;
            this.mabs.SelectedIndexChanged += new System.EventHandler(this.mabs_SelectedIndexChanged);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(490, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 31;
            this.label7.Text = "Ghi chú :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(548, 4);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(239, 21);
            this.chandoan.TabIndex = 3;
            this.chandoan.SelectedIndexChanged += new System.EventHandler(this.chandoan_SelectedIndexChanged);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // frmCls_mau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.vung);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.butKetthuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCls_mau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả mẫu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCls_mau_KeyDown);
            this.Load += new System.EventHandler(this.frmCls_mau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCls_mau_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			sql="select * from "+user+".cls_loai";
			if (s_loai!="") sql+=" where id in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			sql+=" order by id";
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=m.get_data(sql).Tables[0];

            vung.DisplayMember = "ten";
            vung.ValueMember = "id";
            load_vung();

            mabs.DataSource = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            mabs.DisplayMember = "hoten";
            mabs.ValueMember = "ma";

            chandoan.DisplayMember = "chandoan";
            chandoan.ValueMember = "id";

            //if (!bAdmin)
            //{
            //    butHuy.Enabled = false;
            //    butSua.Enabled = false;
            //}
		}

        private void load_vung()
        {
            if (loai.SelectedIndex != -1)
                vung.DataSource = m.get_data("select * from " + user + ".cls_noidung where loai=" + int.Parse(loai.SelectedValue.ToString()) + " order by ma").Tables[0];
        }

        private void load_chandoan()
        {
            if (loai.SelectedIndex != -1)
            {
                sql = "select * from " + user + ".cls_mau where loai=" + int.Parse(loai.SelectedValue.ToString());
                if (vung.SelectedIndex != -1) sql += " and vung=" + int.Parse(vung.SelectedValue.ToString());
                if (mabs.SelectedIndex != -1) sql += " and mabs='" + mabs.SelectedValue.ToString() + "'";
                sql += " order by id";
                dt = m.get_data(sql).Tables[0];
                chandoan.DataSource = dt;
                ten.Text = (dt.Rows.Count > 0) ? dt.Rows[0]["ten"].ToString() : "";
                id = (dt.Rows.Count > 0) ? decimal.Parse(dt.Rows[0]["id"].ToString()) : 0;
            }
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
            chandoan.Visible = !ena;
            ghichu.Visible = ena;
			ghichu.Enabled=ena;
			butMoi.Enabled=!ena;
            ten.ReadOnly = !ena;
            //if (bAdmin) butSua.Enabled = !ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			//if (bAdmin) butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            loai.Enabled = true;
            mabs.Enabled = true;
            vung.Enabled = true;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            ichandoan = chandoan.SelectedIndex;
			id=0;
			ten.Text="";
			ghichu.Text="";
			ena_object(true);
			loai.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            if (chandoan.SelectedIndex == -1) return;
            ichandoan = chandoan.SelectedIndex;
            id = decimal.Parse(dt.Rows[chandoan.SelectedIndex]["id"].ToString());
            loai.Enabled = false;
            mabs.Enabled = false;
            vung.Enabled = false;
            ghichu.Text = chandoan.Text;
			ena_object(true);
			ten.Focus();
            SendKeys.Send("{Home}");
		}

		private bool kiemtra()
		{
			if (ghichu.Text=="")
			{
				ghichu.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
            if (loai.SelectedIndex == -1)
            {
                loai.Focus();
                return false;
            }
            if (vung.SelectedIndex == -1)
            {
                vung.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            bool bNew=id==0;
			if (id==0) id=m.get_capid(-100);
			if (!m.upd_cls_mau(id,int.Parse(loai.SelectedValue.ToString()),mabs.SelectedValue.ToString(),decimal.Parse(vung.SelectedValue.ToString()),ghichu.Text,ten.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin kết qủa mẫu !"));
				return;
			}
			ena_object(false);
            if (bNew) load_chandoan();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            if (ichandoan != -1 && id!=0) ten.Text = dt.Rows[ichandoan]["ten"].ToString();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".cls_mau where id=" + id);
				load_chandoan();
			}
		}


		private void frmCls_mau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai) load_vung();
		}

        private void vung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == vung && butMoi.Enabled) load_chandoan();
        }

        private void mabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == mabs && butMoi.Enabled) load_chandoan();
        }

        private void chandoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chandoan)
            {
                if (chandoan.SelectedIndex != -1) ten.Text = dt.Rows[chandoan.SelectedIndex]["ten"].ToString();
                else ten.Text = "";
            }
        }
	}
}
