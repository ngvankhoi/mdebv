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
	/// Summary description for frmSuamabn.
	/// </summary>
	public class frmXoaba : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn1;
		private System.Windows.Forms.TextBox mabn2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private int i_userid;
		private string ma,sql,user,nam,xxx;
		private System.Windows.Forms.TextBox tqx;
		private DataSet dsxml=new DataSet();
		private DataSet ds=new DataSet();
        private bool bPhonggiuong;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.DataGrid dataGrid1;
        private int i_maxlength_mabn = 8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXoaba(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXoaba));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn1 = new System.Windows.Forms.TextBox();
            this.mabn2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tqx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butSua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn1
            // 
            this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn1.Location = new System.Drawing.Point(96, 6);
            this.mabn1.MaxLength = 2;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(24, 21);
            this.mabn1.TabIndex = 1;
            this.mabn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn1_KeyPress);
            this.mabn1.Validated += new System.EventHandler(this.mabn1_Validated);
            this.mabn1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn1_KeyDown);
            // 
            // mabn2
            // 
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(121, 6);
            this.mabn2.MaxLength = 6;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(60, 21);
            this.mabn2.TabIndex = 2;
            this.mabn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn2_KeyPress);
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(224, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(327, 21);
            this.hoten.TabIndex = 4;
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(609, 6);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(545, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(320, 30);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(330, 21);
            this.diachi.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(272, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqx
            // 
            this.tqx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.Enabled = false;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(96, 54);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(554, 21);
            this.tqx.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tỉnh,Quận,P.Xã :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Enabled = false;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(96, 30);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(176, 21);
            this.mann.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nghề nghiệp :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(255, 331);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "     &Xóa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(327, 331);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "&Thông tin :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(96, 78);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(554, 21);
            this.loai.TabIndex = 4;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(5, 83);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(645, 242);
            this.dataGrid1.TabIndex = 5;
            // 
            // frmXoaba
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(653, 365);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXoaba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xoá thông tin nhập sai từ hồ sơ bệnh án";
            this.Load += new System.EventHandler(this.frmXoaba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void mabn1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn1_Validated(object sender, System.EventArgs e)
		{
			mabn1.Text=mabn1.Text.PadLeft(2,'0');
		}

		private void mabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void emp_text()
		{
			hoten.Text="";
			namsinh.Text="";
			diachi.Text="";
			mann.Text="";
			tqx.Text="";
            nam = "";
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			emp_text();
            mabn2.Text = mabn2.Text.PadLeft(6, '0');//linh 05062012 i_maxlength_mabn - 2
			ma=mabn1.Text+mabn2.Text;
			sql="select a.nam,a.hoten,a.namsinh,a.sonha||' '||a.thon as diachi,b.tennn,trim(c.tentt)||','||trim(d.tenquan)||','||e.tenpxa as tqx";
            sql += " from " + user + ".btdbn a," + user + ".btdnn_bv b," + user + ".btdtt c," + user + ".btdquan d," + user + ".btdpxa e";
			sql+=" where a.mann=b.mann and a.matt=c.matt and a.maqu=d.maqu and a.maphuongxa=e.maphuongxa";
			sql+=" and a.mabn='"+ma+"'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                nam = r["nam"].ToString().Trim();
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				diachi.Text=r["diachi"].ToString();
				mann.Text=r["tennn"].ToString();
				tqx.Text=r["tqx"].ToString();
				break;
			}
			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã Người bệnh ")+ma,LibMedi.AccessData.Msg);
				mabn1.Focus();
			}
			load_grid();
		}

		private bool kiemtra()
		{
			if (hoten.Text=="" || mabn1.Text=="" || mabn2.Text=="")
			{
				mabn1.Focus();
				return false;
			}
			return true;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
            if (!kiemtra()) return;
            ma = mabn1.Text + mabn2.Text;
            decimal idgiuong = 0;
            string s_idgiuong = "";
            try
            {

                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý xóa thông tin này !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    sql = "delete from "+user+".v_theodoicongno where thuoc+vienphi+tamung+mien<=0";
                    m.execute_data(sql);
                    //
                    DataRow r = m.getrowbyid(dsxml.Tables[0], "stt='" + loai.SelectedIndex.ToString() + "'");
                    if (r != null)
                    {
                        int i = dataGrid1.CurrentCell.RowNumber,itableid;
                        string s_ngay = dataGrid1[i, 3].ToString(),ngay=m.ngayhienhanh_server.Substring(0,10);
                        decimal l_maql = decimal.Parse(dataGrid1[i, 4].ToString());
                        decimal l_id = decimal.Parse(dataGrid1[i, 5].ToString());
                        xxx = user + m.mmyy(s_ngay);
                        if (loai.SelectedIndex == 13) //phong luu
                        {
                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                if (m.get_data("select * from " + xxx + ".v_chidinh where maql=" + l_maql).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã chỉ định dịch vụ không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                if (m.get_data("select * from " + xxx + ".d_thuocbhytll where maql=" + l_maql).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã cấp toa không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }

                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                string sql1 = "select a.* from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b where a.id=b.id and a.maql=" + l_maql;
                                sql1 += " union all select a.* from " + xxx + ".bhytkb a," + xxx + ".bhytcls b where a.id=b.id and a.maql=" + l_maql;
                                if (m.get_data(sql1).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã sử dụng thuốc không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            if (m.get_data("select * from " + user + ".v_theodoicongno where maql=" + l_maql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã sử dụng các dịch vụ không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }

                            decimal sl = 0;
                            if (bPhonggiuong)
                            {
                                s_idgiuong="";
                                foreach (DataRow r1 in m.get_data("select idgiuong,soluong, giuongthem from " + user + ".theodoigiuong where maql=" + l_maql + " and idgiuong<>0").Tables[0].Rows)
                                {
                                    if (r1["giuonghem"].ToString() == "0")  idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                    sl = decimal.Parse(r1["soluong"].ToString());
                                    s_idgiuong += r1["idgiuong"].ToString() + ",";
                                }
                            }

                            if (idgiuong != 0)
                            {
                                if (sl != 0)
                                {
                                    m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where (id=" + idgiuong + " or id in(" + s_idgiuong.Trim().Trim(',') + ")");
                                    sql = "select * from " + user + ".theodoigiuong where maql=" + l_maql + " and to_char(den,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
                                    if (s_idgiuong.Trim().Trim(',') != "") sql += " and idgiuong in (" + s_idgiuong.Trim().Trim(',') + ")";
                                    sql += " and idgiuong=" + idgiuong;

                                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                                    {
                                        m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                                        m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id=" + decimal.Parse(r1["id"].ToString()));
                                        m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString())); //Khuong 29/11/2011 
                                    }
                                }
                                try
                                {
                                    m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id in(" + s_idgiuong.Trim().Trim(',') + ")");//id=" + idgiuong);
                                }
                                catch (Exception exx)
                                {
                                    MessageBox.Show(exx.Message);
                                    m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id in(" + s_idgiuong.Trim().Trim(',') + ")");
                                }
                                m.execute_data("delete from " + user + ".theodoigiuong where maql=" + l_maql + " and idgiuong in(" + s_idgiuong.Trim().Trim(',') + ")");// idgiuong=" + idgiuong);
                            }

                            itableid = m.tableid(m.mmyy(ngay), "benhancc");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "del", m.fields(xxx + ".benhancc", "maql=" + l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid, "del");
                            m.execute_data("delete from " + xxx + ".benhancc where maql=" + l_maql);
                        }
                        else if (loai.SelectedIndex == 15) //ra phong luu
                        {
                            if (!(m.bThanhtoan_ndot || m.bThanhtoan_khoa))
                            {
                                if (m.get_thvpll(s_ngay, l_maql, ""))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            if (bPhonggiuong)
                            {
                                s_idgiuong = "";
                                foreach (DataRow r1 in m.get_data("select idgiuong, giuongthem from " + user + ".theodoigiuong where maql=" + l_maql + " and idgiuong<>0").Tables[0].Rows)
                                {
                                    if(r1["giuongthem"].ToString()=="0") idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                    s_idgiuong += r1["idgiuong"].ToString() + ",";
                                }
                            }

                            if (idgiuong != 0)
                            {
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + idgiuong);
                                sql = "select * from " + user + ".theodoigiuong where maql=" + l_maql + " and to_char(den,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
                                if (s_idgiuong.Trim().Trim(',') != "") sql += " and idgiuong in(" + s_idgiuong.Trim().Trim(',') + ")";
                                else sql += " and idgiuong=" + idgiuong;
                                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                                {
                                    m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id in(" + decimal.Parse(r1["id"].ToString()) + ",-" + decimal.Parse(r1["id"].ToString()) + ")");
                                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString())); //Khuong 29/11/2011 
                                }
                            }

                            itableid = m.tableid(m.mmyy(ngay), "benhancc");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "del", m.fields(xxx + ".benhancc", "maql=" + l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid, "del");
                            d.execute_data_mmyy("update xxx.benhancc set ngayrv=null,ttlucrv=0 where maql=" + l_maql,s_ngay,s_ngay,365);
                        }
                        else if (loai.SelectedIndex == 1) //kham benh
                        {
                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                if (m.get_data("select * from " + xxx + ".v_chidinh where maql=" + l_maql).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã chỉ định dịch vụ không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                if (m.get_data("select * from " + xxx + ".d_thuocbhytll where maql=" + l_maql).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã cấp toa không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }

                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                string sql1 = "select a.* from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b where a.id=b.id and a.maql=" + l_maql;
                                sql1 += " union all select a.* from " + xxx + ".bhytkb a," + xxx + ".bhytcls b where a.id=b.id and a.maql=" + l_maql;
                                if (m.get_data(sql1).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã sử dụng thuốc không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            foreach (DataRow r1 in m.get_data("select mavaovien from " + xxx + ".benhanpk where maql=" + l_maql).Tables[0].Rows)
                                m.execute_data("update " + xxx + ".tiepdon set done=null where maql=" + decimal.Parse(r1["mavaovien"].ToString()));
                            itableid = m.tableid(m.mmyy(ngay), "benhanpk");
                            m.upd_eve_upd_del(ngay,itableid,i_userid , "del",m.fields(xxx+".benhanpk","maql="+l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid,"del");
                            m.execute_data("delete from " + xxx + ".benhanpk where maql=" + l_maql);
                        }
                        else if (loai.SelectedIndex == 2) //ngoai tru
                        {
                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                if (m.get_data("select * from " + xxx + ".v_chidinh where maql=" + l_maql).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã chỉ định dịch vụ không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            if (m.bMmyy(m.mmyy(s_ngay)))
                            {
                                string sql1 = "select a.* from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b where a.id=b.id and a.maql=" + l_maql;
                                sql1 += " union all select a.* from " + xxx + ".bhytkb a," + xxx + ".bhytcls b where a.id=b.id and a.maql=" + l_maql;
                                if (m.get_data(sql1).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã sử dụng thuốc không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            if (m.get_data("select * from "+user+".v_theodoicongno where maql=" + l_maql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã sử dụng các dịch vụ không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            itableid = m.tableid("","benhanngtr");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".benhanngtr", "maql=" + l_maql));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".benhanngtr where maql=" + l_maql);
                        }
                        else if (loai.SelectedIndex == 14) //ra ngoai tru
                        {
                            itableid = m.tableid("", "benhanngtr");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".benhanngtr", "maql=" + l_maql));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("update " + user + ".benhanngtr set ngayrv=null,ttlucrv=0 where maql=" + l_maql);
                        }
                        else if (loai.SelectedIndex == 4)//nhapkhoa
                        {
                            if (m.get_data("select * from "+user+".xuatkhoa where id=" + l_id).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã xuất khoa không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            //BInh: kiem tra xem BN co dang hien dien o khoa khac khong?
                            if (m.get_data("select * from "+user+".hiendien where maql=" + l_maql + " and nhapkhoa=1 and xuatkhoa=0 and makp not in (select makp from "+user+".hiendien where id=" + l_id + ")").Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đang hiện diện khoa khác không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            //BInh kiem tra xem BN co nhap chi phi gi chua
                            if (m.get_data("select * from "+user+".v_theodoicongno where idkhoa=" + l_id).Tables[0].Rows.Count > 0)// || m.get_data("select * from v_vpkhoa where idkhoa="+l_id).Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã sử dụng các dịch vụ không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            //BInh kiem tra xem BN co chi dinh chua
                            string asql = "select * from xxx.v_chidinh where idkhoa=" + l_id + "and idkhoa>0";
                            if (m.get_data_mmyy(asql,s_ngay,s_ngay,true).Tables[0].Rows.Count > 0)// || m.get_data("select * from v_vpkhoa where idkhoa="+l_id).Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã sử dụng các dịch vụ không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            asql = "select * from xxx.v_vpkhoa where idkhoa=" + l_id + " and idkhoa>0";
                            if (m.get_data_mmyy(asql, s_ngay, s_ngay, true).Tables[0].Rows.Count > 0)// || m.get_data("select * from v_vpkhoa where idkhoa="+l_id).Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập viện phí khoa, nên không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            //
                            if (bPhonggiuong)
                            {
                                foreach (DataRow r1 in m.get_data("select idgiuong from " + user + ".hiendien where id=" + l_id + " and idgiuong<>0").Tables[0].Rows)
                                {
                                    idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                }
                                if (idgiuong != 0)
                                {
                                    //Khuong 02/11/2011
                                    try
                                    {
                                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id=" + idgiuong);
                                    }
                                    catch (Exception exx)
                                    {
                                        MessageBox.Show(exx.Message);
                                        m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id=" + idgiuong);
                                    }
                                    m.execute_data("update " + user + ".datgiuong set den=null where mabn='" + ma + "' and to_char(den,'dd/mm/yyyy hh24:mi')='" + s_ngay + "' and idgiuong=" + idgiuong);
                                    m.execute_data("delete from " + user + ".theodoigiuong where idkhoa=" + l_id + " and idgiuong=" + idgiuong);
                                }
                            }
                            itableid = m.tableid("","nhapkhoa");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".nhapkhoa", "id=" + l_id));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".nhapkhoa where id=" + l_id);
                            m.execute_data("update " + user + ".hiendien set nhapkhoa=0,xuatkhoa=0 where id=" + l_id);
                        }
                        else if (loai.SelectedIndex == 3)//nhan benh
                        {
                            if (m.get_data("select * from "+user+".v_theodoicongno where maql=" + l_maql).Tables[0].Rows.Count > 0)// || m.get_data("select * from v_vpkhoa where idkhoa="+l_id).Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã sử dụng các dịch vụ không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            if (m.get_data("select * from "+user+".nhapkhoa where maql=" + l_maql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập khoa không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            itableid = m.tableid("","benhandt");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".benhandt", "maql=" + l_maql));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".hiendien where maql=" + l_maql);
                            m.execute_data("delete from " + user + ".benhandt where maql=" + l_maql);
                        }
                        else if (loai.SelectedIndex == 6)//Xuat khoa
                        {
                            if (m.get_data("select * from "+user+".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã xuất viện không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            //BInh: kiem tra xem BN co dang hien dien o khoa khac khong?
                            if (m.get_data("select * from "+user+".hiendien where nhapkhoa=1 and xuatkhoa=0 and maql=" + l_maql + " and makp not in (select makp from "+user+".hiendien where id=" + l_id + ")").Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đang hiện diện khoa khác không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            if (bPhonggiuong)
                            {
                                s_idgiuong = "";
                                foreach (DataRow r1 in m.get_data("select idgiuong, giuongthem from " + user + ".theodoigiuong where idkhoa=" + l_id + " and idgiuong<>0").Tables[0].Rows)
                                {
                                    if(r1["giuongthem"].ToString()=="0") idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                    s_idgiuong += r1["idgiuong"].ToString() + ",";
                                }
                            }
                            foreach (DataRow r1 in m.get_data("select a.mabn,b.mavaovien,a.maql,a.makp,a.maicd,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.giuong,a.mabs,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.khoachuyen from "+user+".nhapkhoa a,"+user+".benhandt b where a.maql=b.maql and a.id=" + l_id).Tables[0].Rows)
                                m.upd_hiendien(l_id,r1["mabn"].ToString(),decimal.Parse(r1["mavaovien"].ToString()),decimal.Parse(r1["maql"].ToString()), r1["makp"].ToString(),r1["ngayvv"].ToString(),r1["ngay"].ToString(),r1["giuong"].ToString(),r1["mabs"].ToString(), r1["maicd"].ToString(),r1["khoachuyen"].ToString(), 1, 0);
                            
                            if (idgiuong != 0)
                            {
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id in(" + s_idgiuong.Trim().Trim(',') + ")");// id=" + idgiuong);
                                m.execute_data("update "+user+".hiendien set idgiuong=" + idgiuong + " where id in(" + s_idgiuong.Trim().Trim(',') + ")");//id=" + l_id);
                                sql = "select a.*, to_char(a.den,'dd/mm/yyyy hh24:mi') ngayra from " + user + ".theodoigiuong a where idkhoa=" + l_id + " and to_char(den,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
                                if (s_idgiuong.Trim().Trim(',') != "") sql += " and idgiuong in(" + s_idgiuong.Trim().Trim(',') + ")";
                                else sql += " and idgiuong=" + idgiuong;                                
                                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                                {                                    
                                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where (id=" + decimal.Parse(r1["id"].ToString()) + " or(mavp=" + idgiuong + " and idkhoa=" + r1["idkhoa"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngayra"].ToString() + "'))");
                                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString())); //Khuong 29/11/2011 
                                    m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                                }
                            }

                            itableid = m.tableid("","xuatkhoa");                           
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".xuatkhoa", "id=" + l_id));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".hiendien where nhapkhoa=0 and xuatkhoa=0 and mabn='" + ma + "' and maql=" + l_maql + " and id<>" + l_id);
                            m.execute_data("delete from " + user + ".xuatkhoa where id=" + l_id);
                        }
                        else if (loai.SelectedIndex == 8)//hiendien
                        {
                            //Binh them vao muc kiem tra khi xoa hien dien
                            if (m.get_data("select * from "+user+".hiendien where id=" + l_id + " and nhapkhoa=1").Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập khoa không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            itableid = m.tableid("","hiendien");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".hiendien", "id=" + l_id));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".hiendien where id=" + l_id);
                        }
                        else if (loai.SelectedIndex == 7)//xuat vien
                        {
                            if (!(m.bThanhtoan_ndot || m.bThanhtoan_khoa))
                            {
                                if (m.get_thvpll(s_ngay, l_maql, ""))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            itableid = m.tableid("","xuatvien");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".xuatvien", "maql=" + l_maql));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".xuatvien where maql=" + l_maql);
                            //
                            //xoa xuat khoa: khoa cuoi ch ra vien  
                            loai.SelectedIndex = 6;//
                            DataSet lds1 = m.get_data("select a.id, a.makp from " + user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id where b.ttlucrk not in(5,8) and a.maql=" + l_maql);
                            l_id=0;
                            foreach (DataRow dr in lds1.Tables[0].Rows)
                            {
                                l_id = decimal.Parse(dr["id"].ToString());
                                break;
                            }
                            if (l_id == 0) return;
                            //BInh: kiem tra xem BN co dang hien dien o khoa khac khong?
                            if (m.get_data("select * from " + user + ".hiendien where nhapkhoa=1 and xuatkhoa=0 and maql=" + l_maql + " and makp not in (select makp from " + user + ".hiendien where id=" + l_id + ")").Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đang hiện diện khoa khác không cho phép xóa !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            if (bPhonggiuong)
                            {
                                s_idgiuong = "";
                                foreach (DataRow r1 in m.get_data("select idgiuong, giuongthem from " + user + ".theodoigiuong where idkhoa=" + l_id + " and idgiuong<>0").Tables[0].Rows)
                                {
                                    if (r1["giuongthem"].ToString() == "0") idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                    s_idgiuong = r1["idgiuong"].ToString() + ",";
                                }
                            }
                            foreach (DataRow r1 in m.get_data("select a.mabn,b.mavaovien,a.maql,a.makp,a.maicd,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.giuong,a.mabs,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.khoachuyen from " + user + ".nhapkhoa a," + user + ".benhandt b where a.maql=b.maql and a.id=" + l_id).Tables[0].Rows)
                                m.upd_hiendien(l_id, r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), r1["makp"].ToString(), r1["ngayvv"].ToString(), r1["ngay"].ToString(), r1["giuong"].ToString(), r1["mabs"].ToString(), r1["maicd"].ToString(), r1["khoachuyen"].ToString(), 1, 0);

                            if (idgiuong != 0)
                            {
                                m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id in(" + s_idgiuong.Trim().Trim(',') + ")");//id=" + idgiuong);
                                m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_id);
                                sql = "select a.*, to_char(a.den,'dd/mm/yyyy hh24:mi') as ngayra from " + user + ".theodoigiuong a where idkhoa=" + l_id + " and to_char(den,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
                                if (s_idgiuong.Trim().Trim(',') != "") sql += " and idgiuong in(" + s_idgiuong.Trim().Trim(',') + ")";
                                else sql += " and idgiuong=" + idgiuong;
                                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                                {                                    
                                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id in(" + decimal.Parse(r1["id"].ToString()) + ",-" + decimal.Parse(r1["id"].ToString()) + ")");
                                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString())); //Khuong 29/11/2011 
                                    //m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where (id=" + decimal.Parse(r1["id"].ToString()) + " or(mavp=" + idgiuong + " and idkhoa=" + r1["idkhoa"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngayra"].ToString() + "'))");
                                    m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                                }
                            }

                            itableid = m.tableid("", "xuatkhoa");
                            m.upd_eve_upd_del(itableid, i_userid, "del", m.fields(user + ".xuatkhoa", "id=" + l_id));
                            m.upd_eve_tables(itableid, i_userid, "del");
                            m.execute_data("delete from " + user + ".xuatkhoa where id=" + l_id);
                            //
                        }
                        else if (loai.SelectedIndex == 0) //tiepdon
                        {
                            //
                            //decimal l_mavv = m.get_mavaovien(l_maql);
                            decimal l_mavv = m.get_mavaovien_tiepdon(l_maql, m.mmyy(s_ngay));


                            if (m.get_data("select * from " + xxx + ".v_chidinh where maql=" + l_maql + ((l_mavv > 0) ? (" or mavaovien = " + l_mavv) : "")).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Đã có công khám, hay dịch vụ khác nên không thể hủy !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            if (m.get_data("select * from " + xxx + ".v_tamung where maql=" + l_maql + ((l_mavv > 0) ? (" or mavaovien = " + l_mavv) : "")).Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Đợt này đã đóng tạm ứng, không thể hủy !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            if (l_mavv > 0)
                            {
                                if (m.get_data("select * from " + xxx + ".benhanpk where mavaovien=" + l_mavv).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã khám không thể hủy không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                                if (m.get_data("select * from " + user + ".benhandt a, " + user + ".sukien b where a.maql=b.macap and b.matiepdon=" + l_mavv).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Đã nhập viện không thể hủy !"), LibMedi.AccessData.Msg);
                                    return;
                                }
                            }
                            itableid = m.tableid(m.mmyy(ngay), "tiepdon");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "del", m.fields(xxx + ".tiepdon", "maql=" + l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid, "del");
                            m.execute_data("delete from " + xxx + ".tiepdon where maql=" + l_maql);
                        }
                        else if (loai.SelectedIndex == 5) // pttt
                        {
                            itableid = m.tableid(m.mmyy(ngay), "pttt");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "del", m.fields(xxx + ".pttt", "id=" + l_id));
                            m.upd_eve_tables(ngay, itableid, i_userid, "del");
                            m.execute_data("delete from " + xxx + ".pttt where id=" + l_id);
                        }
                        else
                        {
                            sql = r[3].ToString();
                            sql += (l_id != 0) ? l_id.ToString() : l_maql.ToString();
                            m.execute_data(sql.Replace("xxx", xxx).Replace("zzz", user));
                        }
                        MessageBox.Show(lan.Change_language_MessageText("Đã xóa thành công !"), LibMedi.AccessData.Msg);
                        load_grid();
                    }
                    mabn1.Focus();
                }
            }
            catch { }
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmXoaba_Load(object sender, System.EventArgs e)
		{
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            mabn2.MaxLength = i_maxlength_mabn - 2;
            bPhonggiuong = m.bPhonggiuong;
            user = m.user; nam = m.mmyy(m.ngayhienhanh_server);
			mabn1.Text=DateTime.Now.Year.ToString().Substring(2,2);
			dsxml.ReadXml("..//..//..//xml//dmxoaba.xml");
			loai.DisplayMember="NOIDUNG";
			loai.ValueMember="SQL";
			loai.DataSource=dsxml.Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_grid();
		}

		private void load_grid()
		{
            try
            {
                ma = mabn1.Text + mabn2.Text;
                sql = loai.SelectedValue.ToString() + " and a.mabn='" + ma + "'";
                sql = sql.Replace("zzz", user);
                if (sql.IndexOf("xxx") != -1) ds = m.get_data_nam(nam, sql);
                else ds = m.get_data(sql);
                dataGrid1.DataSource = ds.Tables[0];
            }
            catch { }
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
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
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 240;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "Năm sinh";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maql";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Khoa/Phòng";
            TextCol.Width = 140;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void mabn1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mabn2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}
	}
}
