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
	/// Summary description for frmTkchuyenden.
	/// </summary>
	public class frmTkchuyenvien : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox matuyen;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private LibList.List listdstt;
		private MaskedTextBox.MaskedTextBox madstt;
		private System.Windows.Forms.TextBox tendstt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private bool bClear=true;
		private string sql="",user="";
		private DataSet ds=new DataSet();
		private AccessData m;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.Label label4;
        private CheckBox chkXML;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTkchuyenvien(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkchuyenvien));
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.matuyen = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listdstt = new LibList.List();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.solieu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(240, 7);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 3;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(88, 7);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 1;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matuyen
            // 
            this.matuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matuyen.Location = new System.Drawing.Point(88, 51);
            this.matuyen.Name = "matuyen";
            this.matuyen.Size = new System.Drawing.Size(216, 21);
            this.matuyen.TabIndex = 7;
            this.matuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matuyen_KeyDown);
            // 
            // matt
            // 
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(88, 29);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(216, 21);
            this.matt.TabIndex = 5;
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tuyến :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tỉnh/thành phố :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(232, 145);
            this.listdstt.MatchBufferTimeOut = 1000;
            this.listdstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdstt.Name = "listdstt";
            this.listdstt.Size = new System.Drawing.Size(75, 17);
            this.listdstt.TabIndex = 13;
            this.listdstt.TextIndex = -1;
            this.listdstt.TextMember = null;
            this.listdstt.ValueIndex = -1;
            this.listdstt.Visible = false;
            this.listdstt.Validated += new System.EventHandler(this.listdstt_Validated);
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(88, 73);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(55, 21);
            this.madstt.TabIndex = 9;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendstt
            // 
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(144, 73);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(160, 21);
            this.tendstt.TabIndex = 10;
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(2, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Chuyển viện :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(85, 143);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 13;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(157, 143);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // solieu
            // 
            this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú",
            "Phòng lưu",
            "Phòng khám"});
            this.solieu.Location = new System.Drawing.Point(88, 95);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(216, 21);
            this.solieu.TabIndex = 12;
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(18, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số liệu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(88, 121);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 15;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // frmTkchuyenvien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(312, 182);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.listdstt);
            this.Controls.Add(this.madstt);
            this.Controls.Add(this.tendstt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.matuyen);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkchuyenvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển viện";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkchuyenden_MouseMove);
            this.Load += new System.EventHandler(this.frmTkchuyenvien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkchuyenvien_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            listdstt.DisplayMember="TENBV";
			listdstt.ValueMember="MABV";
			listdstt.DataSource=m.get_data("select MABV,TENBV,DIACHI from "+user+".tenvien where mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];

			matuyen.DisplayMember="TEN";
			matuyen.ValueMember="MA";
            matuyen.DataSource = m.get_data("select * from " + user + ".dmtuyenbv order by ma").Tables[0];
			solieu.SelectedIndex=0;
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
		}

		private void Filt_dstt(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[listdstt.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
		}

		private void madstt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (madstt.Text==m.Mabv)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"),AccessData.Msg);
					madstt.Text="";
					return;
				}
                tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
			}
			catch{}
		}

		private void tendstt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listdstt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listdstt.Visible)
				{
					listdstt.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tendstt_TextChanged(object sender, System.EventArgs e)
		{
			if (tendstt.Text!="")
			{
				Filt_dstt(tendstt.Text);
				listdstt.BrowseToText(tendstt,madstt,butIn,madstt.Location.X,madstt.Location.Y+madstt.Height,madstt.Width+tendstt.Width+2,madstt.Height);
			}
		}

		private void listdstt_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (madstt.Text != "") tendstt.Text = m.get_data("select tenbv from " + user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
			}
			catch{}
		}

		private void tendstt_Validated(object sender, System.EventArgs e)
		{
			madstt.Text=m.get_madstt(tendstt.Text);
			if(!listdstt.Focused) listdstt.Hide();
		}

		private void frmTkchuyenden_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				matt.SelectedIndex=-1;
				matuyen.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (tu.Text=="") 
			{
				den.Text="";
				return;
			}
			tu.Text=tu.Text.Trim();
			if (!m.bNgay(tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tu.Focus();
				return;
			}
			tu.Text=m.Ktngaygio(tu.Text,10);
            if (den.Text == "") den.Text = tu.Text;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="") 
			{
				tu.Text="";
				return;
			}
			den.Text=den.Text.Trim();
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,10);
			if (tu.Text=="")
			{
				tu.Focus();
				return;
			}
			if (!m.bNgay(den.Text,tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
				den.Focus();
                
				return;
			}
		}
        /// <summary>
        /// nhan nut click de dong form
        /// </summary>
        /// <param name="sender">doi tuong truyen vao</param>
        /// <param name="e">event</param>
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            string t1 = "", t2 = solieu.Text, sql_exp = "";
            if (tu.Text != "" && den.Text != "")
            {
                if (solieu.SelectedIndex == 0)// || solieu.SelectedIndex == 1)
                    sql_exp += " and " + m.for_ngay("e.ngay", "'dd/mm/yyyy'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";                    
                else
                    sql_exp += " and " + m.for_ngay("a.ngay", "'dd/mm/yyyy'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
                t1 = "Từ ngày " + tu.Text + " Đến ngày " + den.Text;
                if (tu.Text == den.Text) t1 = "Ngày " + tu.Text;
            }
            if (matt.SelectedIndex != -1)
            {
                sql_exp += " and substr(b.mabv,1,3)='" + matt.SelectedValue.ToString() + "'";
                t2 += "," + matt.Text;
            }
            if (matuyen.SelectedIndex != -1)
            {
                sql_exp += " and h.matuyen='" + matuyen.SelectedValue.ToString() + "'";
                t2 += "," + matuyen.Text;
            }
            if (madstt.Text != "")
            {
                sql_exp += " and b.mabv='" + madstt.Text + "'";
                t2 += "," + tendstt.Text;
            }
            sql_exp += " order by mabv,ngay";

            if (solieu.SelectedIndex == 0)
            {
                sql = "select a.mabn,nullif(e.soluutru,' ') soluutru,c.hoten,substr(g.tuoivao,1,3)||decode(substr(g.tuoivao,4,1),'0','TU',decode(substr(g.tuoivao,4,1),'1','TH',decode(substr(g.tuoivao,4,1),'2','NG','GI'))) as tuoivao,";
                sql += "nullif(c.sonha,' ') sonha,nullif(c.thon,' ') thon,i.tenpxa,j.tenquan,k.tentt,";
                sql += "nullif(d.quanhe,' ')||' '||nullif(d.hoten,' ') as quanhe,b.chandoan,e.maicd,";                
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(e.ngay,'dd/mm/yyyy hh24:mi') ngayra,h.tenbv,h.mabv,a.ngay";
                sql += ", e.makp, l.tenkp, a.madoituong, dt.doituong, bh.sothe, bh.tungay, bh.denngay ";//binh101208
                sql += ", e.mabs, bs.hoten as tenbs, b.lydo, b.vanchuyen, b.tinhtrang, b.yeucau ";
                sql += " from " + user + ".benhandt a inner join " + user + ".chuyenvien b on a.maql=b.maql inner join " + user + ".btdbn c on a.mabn=c.mabn left join " + user + ".quanhe d on a.maql=d.maql inner join " + user + ".xuatvien e on a.maql=e.maql inner join " + user + ".lienhe g on a.maql=g.maql inner join " + user + ".tenvien h on b.mabv=h.mabv inner join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa inner join " + user + ".btdquan j on c.maqu=j.maqu inner join " + user + ".btdtt k on c.matt=k.matt inner join " + user + ".dmbs bs on e.mabs=bs.ma ";
                sql += " inner join " + user + ".btdkp_bv l on e.makp=l.makp";//binh1008
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong left join " + user + ".bhyt bh on a.maql=bh.maql ";
                sql += " where ";
                sql += " e.ttlucrv=6 and b.mabv<>'" + m.Mabv + "'";
                ds = m.get_data(sql + sql_exp);
            }
            else if (solieu.SelectedIndex == 1)
            {
                sql = "select a.mabn,nullif(a.soluutru,' ') soluutru,c.hoten,substr(g.tuoivao,1,3)||decode(substr(g.tuoivao,4,1),'0','TU',decode(substr(g.tuoivao,4,1),'1','TH',decode(substr(g.tuoivao,4,1),'2','NG','GI'))) as tuoivao,";
                sql += "nullif(c.sonha,' ') sonha,nullif(c.thon,' ') thon,i.tenpxa,j.tenquan,k.tentt,";
                sql += "nullif(d.quanhe,' ')||' '||nullif(d.hoten,' ') as quanhe,a.chandoan,a.maicd,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayra,h.tenbv,h.mabv,a.ngay";
                sql += ", a.makp, l.tenkp, a.madoituong, dt.doituong, bh.sothe, bh.tungay, bh.denngay ";//binh101208
                sql += ", a.mabs, bs.hoten as tenbs, b.lydo, b.vanchuyen, b.tinhtrang, b.yeucau ";
                sql += " from " + user + ".benhanngtr a inner join " + user + ".chuyenvien b on a.maql=b.maql inner join " + user + ".btdbn c on a.mabn=c.mabn left join " + user + ".quanhe d on a.maql=d.maql inner join " + user + ".lienhe g on a.maql=g.maql inner join " + user + ".tenvien h on b.mabv=h.mabv inner join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa inner join " + user + ".btdquan j on c.maqu=j.maqu inner join " + user + ".btdtt k on c.matt=k.matt inner join " + user + ".dmbs bs on a.mabs=bs.ma";//inner join " + user + ".xuatvien e on a.maql=e.maql
                sql += " inner join " + user + ".btdkp_bv l on a.makp=l.makp";//binh1008
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong left join " + user + ".bhyt bh on a.maql=bh.maql ";
                sql += " where ";
                sql += " a.ttlucrv=6 and b.mabv<>'" + m.Mabv + "'";
                ds = m.get_data(sql + sql_exp);
            }
            else if (solieu.SelectedIndex == 2)
            {
                sql = "select a.mabn,nullif(a.soluutru,' ') soluutru,c.hoten,substr(g.tuoivao,1,3)||decode(substr(g.tuoivao,4,1),'0','TU',decode(substr(g.tuoivao,4,1),'1','TH',decode(substr(g.tuoivao,4,1),'2','NG','GI'))) as tuoivao,";
                sql += "nullif(c.sonha,' ') sonha,nullif(c.thon,' ') thon,i.tenpxa,j.tenquan,k.tentt,";
                sql += "nullif(d.quanhe,' ')||' '||nullif(d.hoten,' ') as quanhe,a.chandoan,a.maicd,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayra,h.tenbv,h.mabv,a.ngay";
                sql += ", a.makp, l.tenkp , a.madoituong, dt.doituong, bh.sothe, bh.tungay, bh.denngay ";//binh101208
                sql += ", a.mabs, bs.hoten as tenbs, b.lydo, b.vanchuyen, b.tinhtrang, b.yeucau ";
                sql += " from xxx.benhancc a inner join " + user + ".chuyenvien b on a.maql=b.maql inner join " + user + ".btdbn c on a.mabn=c.mabn left join " + user + ".quanhe d on a.maql=d.maql inner join xxx.lienhe g on a.maql=g.maql inner join " + user + ".tenvien h on b.mabv=h.mabv inner join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa inner join " + user + ".btdquan j on c.maqu=j.maqu inner join " + user + ".btdtt k on c.matt=k.matt inner join " + user + ".dmbs bs on a.mabs=bs.ma ";
                sql += " inner join " + user + ".btdkp_bv l on a.makp=l.makp";//binh1008
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong left join " + user + ".bhyt bh on a.maql=bh.maql ";
                sql += " where ";
                sql += " a.ttlucrv=6 and b.mabv<>'" + m.Mabv + "'";
                ds=m.get_data_mmyy(sql + sql_exp, tu.Text, den.Text, false);
            }
            else
            {
                sql = "select a.mabn,nullif(g.soluutru,' ') soluutru,c.hoten,substr(g.tuoivao,1,3)||decode(substr(g.tuoivao,4,1),'0','TU',decode(substr(g.tuoivao,4,1),'1','TH',decode(substr(g.tuoivao,4,1),'2','NG','GI'))) as tuoivao,";
                sql += "nullif(c.sonha,' ') sonha,nullif(c.thon,' ') thon,i.tenpxa,j.tenquan,k.tentt,";
                sql += "nullif(d.quanhe,' ')||' '||nullif(d.hoten,' ') as quanhe,a.chandoan,a.maicd,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayra,h.tenbv,h.mabv,a.ngay";
                sql += ", a.makp, l.tenkp , a.madoituong, dt.doituong, bh.sothe, bh.tungay, bh.denngay ";//binh101208
                sql += ", a.mabs, bs.hoten as tenbs, b.lydo, b.vanchuyen, b.tinhtrang, b.yeucau ";
                sql += " from xxx.benhanpk a inner join " + user + ".chuyenvien b on a.maql=b.maql inner join " + user + ".btdbn c on a.mabn=c.mabn left join " + user + ".quanhe d on a.maql=d.maql inner join xxx.lienhe g on a.maql=g.maql inner join " + user + ".tenvien h on b.mabv=h.mabv inner join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa inner join " + user + ".btdquan j on c.maqu=j.maqu inner join " + user + ".btdtt k on c.matt=k.matt inner join "+user+".dmbs bs on a.mabs=bs.ma ";
                sql += " inner join " + user + ".btdkp_bv l on a.makp=l.makp";//binh1008
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong left join xxx.bhyt bh on a.maql=bh.maql "; //Khuong 04/11
                sql += " where ";
                sql += " a.ttlucrv=6 and b.mabv<>'" + m.Mabv + "'";
                ds=m.get_data_mmyy(sql + sql_exp, tu.Text, den.Text, false);
            }                            
            if (ds.Tables[0].Rows.Count==0)	MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
			else
			{
                DataTable dticd10 = new DataTable();
                DataRow r1;
                dticd10 = m.get_data("select cicd10,vviet from " + user + ".icd10").Tables[0];
                string[] s_chandoan;
                string s_maicd = "";
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    s_chandoan = r["chandoan"].ToString().Split(';');
                    for (int i = 0; i < s_chandoan.Length-1; i++)
                    {
                        r1 = m.getrowbyid(dticd10,"vviet='"+s_chandoan[i]+"'");
                        s_maicd += r1!=null?r1["cicd10"].ToString()+";":"";
                    }
                    r["maicd"] = s_maicd;
                }
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    ds.WriteXml("..\\xml\\tkchuyenvien.xml", XmlWriteMode.WriteSchema);
                }
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,t1+" "+t2,"rptTKchuyenvien.rpt");
				f.ShowDialog();
			}
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
