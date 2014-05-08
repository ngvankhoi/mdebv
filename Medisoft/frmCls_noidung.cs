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
	public class frmCls_noidung : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ten;
		private decimal id;
        private bool bAdmin;
		private string s_loai,sql,user,xxx,mmyy;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox noidung;
        private Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCls_noidung(AccessData acc,string loai,bool admin)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCls_noidung));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.noidung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(722, 296);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(533, 342);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nội dung :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(160, 312);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(232, 21);
            this.ten.TabIndex = 2;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(183, 342);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 6;
            this.butMoi.Text = "&Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(253, 342);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 7;
            this.butSua.Text = "&Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(323, 342);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(393, 342);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(463, 342);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 8;
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
            this.loai.Size = new System.Drawing.Size(690, 21);
            this.loai.TabIndex = 0;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mã số :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(40, 312);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(64, 21);
            this.ma.TabIndex = 1;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidung.Enabled = false;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(459, 312);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(271, 21);
            this.noidung.TabIndex = 3;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(398, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tiếng Anh :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCls_noidung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 389);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCls_noidung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nội dung";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCls_noidung_KeyDown);
            this.Load += new System.EventHandler(this.frmCls_noidung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCls_noidung_Load(object sender, System.EventArgs e)
		{
            user = m.user; mmyy = m.mmyy(m.ngayhienhanh_server.Substring(0, 10)); xxx = user + mmyy;
			sql="select * from "+user+".cls_loai";
			if (s_loai!="") sql+=" where id in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			sql+=" order by id";
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=m.get_data(sql).Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            if (!bAdmin)
            {
                butHuy.Enabled = false;
                butSua.Enabled = false;
            }
		}

		private void load_grid()
		{
            sql = "select a.*,b.noidung from " + user + ".cls_noidung a left join " + user + ".cls_mota b on a.id=b.id";
			if (loai.SelectedIndex!=-1) sql+=" where a.loai="+int.Parse(loai.SelectedValue.ToString());
			sql+=" order by a.id";
			dt=m.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
            if (dt.Rows.Count > 0)
            {
                id = int.Parse(dt.Rows[0]["id"].ToString());
                ma.Text = dt.Rows[0]["ma"].ToString();
                ten.Text = dt.Rows[0]["ten"].ToString();
                noidung.Text = dt.Rows[0]["noidung"].ToString();
            }
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width =100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 295;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "noidung";
            TextCol.HeaderText = "Tiếng Anh";
			TextCol.Width = 295;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			ma.Enabled=ena;
			ten.Enabled=ena;
			noidung.Enabled=ena;
			butMoi.Enabled=!ena;
            dataGrid1.Enabled = !ena;
            if (bAdmin) butSua.Enabled = !ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (bAdmin) butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			id=0;
			ma.Text="";
			ten.Text="";
			noidung.Text="";
			ena_object(true);
			ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
			ena_object(true);
			ma.Focus();
		}

		private bool kiemtra()
		{
			if (ma.Text=="")
			{
				ma.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
            DataRow r = m.getrowbyid(dt, "ten='" + ten.Text + "' and id<>" + id);
            if (r!=null)
            {
                MessageBox.Show(
lan.Change_language_MessageText(
"Nội dung đã nhập !"), LibMedi.AccessData.Msg);
                ten.Focus();
                return false;
            }
            r = m.getrowbyid(dt, "ma='" + ma.Text + "' and id<>" + id);
            if (r != null)
            {
                MessageBox.Show(
lan.Change_language_MessageText(
"Mã số đã nhập !"), LibMedi.AccessData.Msg);
                ten.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (id==0) id=m.get_capid(-2);
			if (!m.upd_cls_noidung(id,int.Parse(loai.SelectedValue.ToString()),ma.Text,ten.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin nội dung !"));
				return;
			}
			if (noidung.Text!="") m.upd_cls_mota(id,noidung.Text);
            else m.execute_data("delete from " + user + ".cls_mota where id=" + id);
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (id==0) return;
            if (m.bMmyy(mmyy))
            {
                if (m.get_data("select * from " + xxx + ".cls_ketqua where idvung=" + id).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(ten.Text + "\n"+
lan.Change_language_MessageText(
"Đã sử dụng không cho phép hủy ?"), LibMedi.AccessData.Msg);
                    return;
                }
            }
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.execute_data("delete from " + user + ".cls_noidung where id=" + id);
                m.execute_data("delete from " + user + ".cls_mota where id=" + id);
				load_grid();
			}
		}

		private void ref_text()
		{
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                id = int.Parse(dataGrid1[i, 0].ToString());
                ma.Text = dataGrid1[i, 1].ToString();
                ten.Text = dataGrid1[i, 2].ToString();
                noidung.Text = dataGrid1[i, 3].ToString();
            }
            catch { }
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmCls_noidung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai) load_grid();
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (id==0 && ma.Text!="")
			{
				DataRow r=m.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(
lan.Change_language_MessageText(
"Mã số đã nhập !"),LibMedi.AccessData.Msg);
					return;
				}
			}
		}
	}
}
