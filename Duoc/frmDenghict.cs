using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using doiso;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDenghi.
	/// </summary>
	public class frmDenghict : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox kinhgui;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox bophan;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox denghi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox noidung;
		private System.Windows.Forms.TextBox ketoan;
		private System.Windows.Forms.TextBox giamdoc;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataSet ds=new DataSet();
		private DataSet dsdn=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataTable dtsohd;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.TextBox madv;
		private System.Windows.Forms.Label label10;
		private LibList.List listNX;
		private System.Windows.Forms.CheckedListBox sohd;
		private System.Windows.Forms.Button butLoc;
		private AccessData d;
        private int i_nhom, i_soct, i_thanhtien_le, i_userid=0;
		private decimal d_cothue;
        private string user,f_ngay,s_madv,s_tendv,s_ngayhd;
		private Doisototext doiso=new Doisototext();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDenghict(AccessData acc,int nhom,string _madv,string _tendv,string _ngayhd, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; s_madv = _madv; s_tendv = _tendv; s_ngayhd = _ngayhd;
            i_userid = _userid;    
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDenghict));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.kinhgui = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bophan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.denghi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.noidung = new System.Windows.Forms.TextBox();
            this.ketoan = new System.Windows.Forms.TextBox();
            this.giamdoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tendv = new System.Windows.Forms.TextBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.listNX = new LibList.List();
            this.sohd = new System.Windows.Forms.CheckedListBox();
            this.butLoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(80, 8);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 1;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kính gửi :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kinhgui
            // 
            this.kinhgui.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kinhgui.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kinhgui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kinhgui.Location = new System.Drawing.Point(212, 8);
            this.kinhgui.Name = "kinhgui";
            this.kinhgui.Size = new System.Drawing.Size(356, 21);
            this.kinhgui.TabIndex = 3;
            this.kinhgui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(366, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bộ phận :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bophan
            // 
            this.bophan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bophan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bophan.Location = new System.Drawing.Point(416, 31);
            this.bophan.Name = "bophan";
            this.bophan.Size = new System.Drawing.Size(152, 21);
            this.bophan.TabIndex = 7;
            this.bophan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nội dung :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denghi
            // 
            this.denghi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denghi.Location = new System.Drawing.Point(135, 31);
            this.denghi.Name = "denghi";
            this.denghi.Size = new System.Drawing.Size(185, 21);
            this.denghi.TabIndex = 5;
            this.denghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Người đề nghị thanh toán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // noidung
            // 
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(80, 54);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(240, 21);
            this.noidung.TabIndex = 9;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // ketoan
            // 
            this.ketoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ketoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketoan.Location = new System.Drawing.Point(416, 54);
            this.ketoan.Name = "ketoan";
            this.ketoan.Size = new System.Drawing.Size(152, 21);
            this.ketoan.TabIndex = 11;
            this.ketoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // giamdoc
            // 
            this.giamdoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giamdoc.Location = new System.Drawing.Point(80, 77);
            this.giamdoc.Name = "giamdoc";
            this.giamdoc.Size = new System.Drawing.Size(240, 21);
            this.giamdoc.TabIndex = 13;
            this.giamdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(304, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Phụ trách kế toán :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-23, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Người duyệt :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(263, 341);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 22;
            this.butOk.Text = "     In";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(333, 341);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 23;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(312, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Từ ngày :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(448, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "đến :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(368, 77);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 15;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // den
            // 
            this.den.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(488, 77);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 17;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // tendv
            // 
            this.tendv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(146, 101);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(422, 21);
            this.tendv.TabIndex = 20;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // madv
            // 
            this.madv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(80, 101);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(64, 21);
            this.madv.TabIndex = 19;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-20, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Nhà cung cấp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(496, 359);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 26;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            // 
            // sohd
            // 
            this.sohd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sohd.BackColor = System.Drawing.SystemColors.Info;
            this.sohd.CheckOnClick = true;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(80, 124);
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(488, 212);
            this.sohd.TabIndex = 25;
            this.sohd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // butLoc
            // 
            this.butLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLoc.Image = ((System.Drawing.Image)(resources.GetObject("butLoc.Image")));
            this.butLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLoc.Location = new System.Drawing.Point(193, 341);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(70, 25);
            this.butLoc.TabIndex = 21;
            this.butLoc.Text = "    &Tìm";
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // frmDenghict
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(578, 381);
            this.Controls.Add(this.butLoc);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.giamdoc);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.ketoan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.denghi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bophan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kinhgui);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDenghict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đề nghị thanh toán";
            this.Load += new System.EventHandler(this.frmDenghict_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDenghict_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            f_ngay = d.f_ngay;
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			dsdn.ReadXml("..\\..\\..\\xml\\d_denghict.xml");
			ds.ReadXml("..\\..\\..\\xml\\d_denghi.xml");
			kinhgui.Text=ds.Tables[0].Rows[0]["KINHGUI"].ToString();
			denghi.Text=ds.Tables[0].Rows[0]["DENGHI"].ToString();
			bophan.Text=ds.Tables[0].Rows[0]["BOPHAN"].ToString();
			noidung.Text=ds.Tables[0].Rows[0]["NOIDUNG"].ToString();
			ketoan.Text=ds.Tables[0].Rows[0]["KETOAN"].ToString();
			giamdoc.Text=ds.Tables[0].Rows[0]["GIAMDOC"].ToString();

			dtdmnx=d.get_data("select ma,ten,id,nhomcc,diachi,masothue from "+user+".d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];
			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";
			listNX.DataSource=dtdmnx;
            if (s_madv != "")
            {
                madv.Text = s_madv;
                tendv.Text = s_tendv;
                tu.Value = new DateTime(int.Parse(s_ngayhd.Substring(6, 4)), int.Parse(s_ngayhd.Substring(3, 2)), int.Parse(s_ngayhd.Substring(0, 2)), 0, 0, 0);
                den.Value = tu.Value;
                butLoc_Click(sender, e);
            }
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void upd_xml()
		{
			ds.Tables[0].Rows[0]["NGAY"]=ngay.Text.ToString();
			ds.Tables[0].Rows[0]["KINHGUI"]=kinhgui.Text.ToString();
			ds.Tables[0].Rows[0]["DENGHI"]=denghi.Text.ToString();
			ds.Tables[0].Rows[0]["BOPHAN"]=bophan.Text.ToString();
			ds.Tables[0].Rows[0]["NOIDUNG"]=noidung.Text.ToString();
			ds.Tables[0].Rows[0]["KETOAN"]=ketoan.Text.ToString();
			ds.Tables[0].Rows[0]["GIAMDOC"]=giamdoc.Text.ToString();
			ds.WriteXml("..\\..\\..\\xml\\d_denghi.xml",XmlWriteMode.WriteSchema);
		}

		private void get_data()
		{
			dsdn.Clear();
			d_cothue=0;i_soct=0;
			string so="'";
			if (sohd.SelectedItems.Count>0)
			{
				if (sohd.CheckedItems.Count==0) for(int i=0;i<sohd.Items.Count;i++) sohd.SetItemCheckState(i,CheckState.Checked);
				for(int i=0;i<sohd.Items.Count;i++) 
					if (sohd.GetItemChecked(i)) 
					{
						so+=dtsohd.Rows[i]["sohd"].ToString().Trim()+"','";
						i_soct++;
					}
			}
			string sql="select a.sohd,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhd,a.sophieu,to_char(a.ngaysp,'dd/mm/yyyy') as ngaysp,";
            sql += "sum(round(b.soluong*b.giamua+b.cuocvc+b.chaythu," + i_thanhtien_le + ")) as sotien from xxx.d_nhapll a,xxx.d_nhapct b," + user + ".d_dmnx c where a.id=b.id and a.madv=c.id";
			sql+=" and a.ngayhd between to_date('"+tu.Text+"','"+f_ngay+"') and to_date('"+den.Text+"','"+f_ngay+"')";
			sql+=" and a.nhom="+i_nhom+" and trim(c.ma)='"+madv.Text+"'";
			if (so.Length>1) sql+=" and trim(a.sohd) in ("+so.Substring(0,so.Length-2)+")";
			sql+=" group by a.sohd,to_char(a.ngayhd,'dd/mm/yyyy'),a.sophieu,to_char(a.ngaysp,'dd/mm/yyyy')";
			DateTime dt1=d.StringToDate(tu.Text.Substring(0,10)).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text.Substring(0,10)).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			DataRow r1,r2;
			DataRow [] dr;
			string mmyy="",sql1;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        sql1 = sql.Replace("xxx", user + mmyy);
						foreach(DataRow r in d.get_data(sql1).Tables[0].Rows)
						{
							r1=d.getrowbyid(dsdn.Tables[0],"sohd='"+r["sohd"].ToString()+"' and ngayhd='"+r["ngayhd"].ToString()+"'");
							if (r1==null)
							{
								r2=dsdn.Tables[0].NewRow();
								r2["sohd"]=r["sohd"].ToString();
								r2["ngayhd"]=r["ngayhd"].ToString();
								r2["sophieu"]=i_soct.ToString();//r["sophieu"].ToString();
								r2["ngaysp"]=r["ngaysp"].ToString();
								r2["sotien"]=decimal.Parse(r["sotien"].ToString());
								dsdn.Tables[0].Rows.Add(r2);
							}
							else
							{
								dr=dsdn.Tables[0].Select("sohd='"+r["sohd"].ToString()+"' and ngayhd='"+r["ngayhd"].ToString()+"'");
								if (dr.Length>0)
									dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
							}
							d_cothue+=decimal.Parse(r["sotien"].ToString());
						}
					}
				}
			}

		}
		private void butOk_Click(object sender, System.EventArgs e)
		{
			upd_xml();
			if (sohd.Items.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			get_data();
			DataRow r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			string _dc=r["diachi"].ToString().Trim(),_maso=r["masothue"].ToString().Trim();
			if (dsdn.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
			frmReport f=new frmReport(d,dsdn.Tables[0], i_userid,"d_denghi.rpt",kinhgui.Text,ngay.Text,denghi.Text,bophan.Text,noidung.Text.Trim()+" "+r["ten"].ToString().Trim().ToUpper(),ketoan.Text,giamdoc.Text,"","",doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()),_dc,_maso);
			f.ShowDialog();
		}

		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				DataRow r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null) tendv.Text=r["ten"].ToString();
			}
		}

		private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNX.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNX.Visible)	listNX.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void Filter_dmnx(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNX.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tendv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendv)
			{
				Filter_dmnx(tendv.Text);
				listNX.BrowseToDmnx(tendv,madv,butLoc);
			}
		}

		private void tendv_Validated(object sender, System.EventArgs e)
		{
			if(!listNX.Focused) listNX.Hide();
			if (tendv.Text!="" && madv.Text=="")
			{
				DataRow r=d.getrowbyid(dtdmnx,"ten='"+tendv.Text+"'");
				if (r!=null) madv.Text=r["ma"].ToString();
			}
		}

		private void butLoc_Click(object sender, System.EventArgs e)
		{
			if (madv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
				madv.Focus();
				return;
			}
			dtsohd=new DataTable();
			DateTime dt1=d.StringToDate(tu.Text.Substring(0,10)).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text.Substring(0,10)).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			bool be=true;
			string mmyy="",sql,sql1;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						sql="select distinct to_char(a.ngayhd,'dd/mm/yyyy')||'     '||a.sohd as songay,a.sohd from xxx.d_nhapll a,"+user+".d_dmnx b where a.madv=b.id";
						sql+=" and a.ngayhd between to_date('"+tu.Text+"','"+f_ngay+"') and to_date('"+den.Text+"','"+f_ngay+"')";
						if (madv.Text!="") sql+=" and trim(b.ma)='"+madv.Text+"'";
						sql+=" and a.nhom="+i_nhom;
                        sql1 = sql.Replace("xxx", user + mmyy);
						if (be) dtsohd=d.get_data(sql1).Tables[0];
                        else dtsohd.Merge(d.get_data(sql1).Tables[0]); // dtsohd = d.get_data(sql1).Tables[0].Copy();
						be=false;
					}
				}
			}
			sohd.DataSource=dtsohd;
            sohd.DisplayMember = "SONGAY";
            sohd.ValueMember = "SOHD";
		}
	}
}
