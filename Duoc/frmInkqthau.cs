using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.IO;
namespace Duoc
{
	/// <summary>
	/// Summary description for rptBbknhap.
	/// </summary>
	public class frmInkqthau : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private DataTable dtdmnx;
		private DataSet dsxml=new DataSet();
        private int i_nhom, i_madv, d_userid=0;
		private string s_mmyy;
		private DataSet ds=new DataSet();		
		private MaskedTextBox.MaskedTextBox c1;
		private MaskedTextBox.MaskedTextBox c2;
		private MaskedTextBox.MaskedTextBox c3;
		private MaskedTextBox.MaskedTextBox c4;
		private MaskedTextBox.MaskedTextBox c5;
		private MaskedTextBox.MaskedTextBox c6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private MaskedTextBox.MaskedTextBox c11;
		private MaskedTextBox.MaskedTextBox c16;
		private MaskedTextBox.MaskedTextBox c15;
		private MaskedTextBox.MaskedTextBox c14;
		private MaskedTextBox.MaskedTextBox c13;
		private MaskedTextBox.MaskedTextBox c12;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.TextBox madv;
		private LibList.List listNX;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox THANG;
		private System.Windows.Forms.TextBox QUY;
		private System.Windows.Forms.TextBox NAM;
		private System.Windows.Forms.Button butXem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInkqthau(AccessData acc,int nhom,string mmyy, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_mmyy=mmyy ;
            d_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInkqthau));
            this.label3 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tendv = new System.Windows.Forms.TextBox();
            this.c1 = new MaskedTextBox.MaskedTextBox();
            this.c2 = new MaskedTextBox.MaskedTextBox();
            this.c3 = new MaskedTextBox.MaskedTextBox();
            this.c4 = new MaskedTextBox.MaskedTextBox();
            this.c5 = new MaskedTextBox.MaskedTextBox();
            this.c6 = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.c16 = new MaskedTextBox.MaskedTextBox();
            this.c15 = new MaskedTextBox.MaskedTextBox();
            this.c14 = new MaskedTextBox.MaskedTextBox();
            this.c13 = new MaskedTextBox.MaskedTextBox();
            this.c12 = new MaskedTextBox.MaskedTextBox();
            this.c11 = new MaskedTextBox.MaskedTextBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.listNX = new LibList.List();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.THANG = new System.Windows.Forms.TextBox();
            this.QUY = new System.Windows.Forms.TextBox();
            this.NAM = new System.Windows.Forms.TextBox();
            this.butXem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đơn vị :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(210, 232);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 17;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(280, 232);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tendv
            // 
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(112, 16);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(368, 21);
            this.tendv.TabIndex = 1;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // c1
            // 
            this.c1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(52, 40);
            this.c1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(192, 21);
            this.c1.TabIndex = 2;
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(52, 64);
            this.c2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(192, 21);
            this.c2.TabIndex = 4;
            // 
            // c3
            // 
            this.c3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(52, 88);
            this.c3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(192, 21);
            this.c3.TabIndex = 6;
            // 
            // c4
            // 
            this.c4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.Location = new System.Drawing.Point(52, 112);
            this.c4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(192, 21);
            this.c4.TabIndex = 8;
            // 
            // c5
            // 
            this.c5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c5.Location = new System.Drawing.Point(52, 136);
            this.c5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(192, 21);
            this.c5.TabIndex = 10;
            // 
            // c6
            // 
            this.c6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c6.Location = new System.Drawing.Point(52, 160);
            this.c6.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(192, 21);
            this.c6.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "1. ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "2. ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-3, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "3. ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-3, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "4. ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-3, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "5. ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-3, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "6. ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c16
            // 
            this.c16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c16.Location = new System.Drawing.Point(246, 160);
            this.c16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c16.Name = "c16";
            this.c16.Size = new System.Drawing.Size(234, 21);
            this.c16.TabIndex = 13;
            this.c16.Text = "Kế toán - Ủy viên";
            // 
            // c15
            // 
            this.c15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c15.Location = new System.Drawing.Point(246, 136);
            this.c15.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(234, 21);
            this.c15.TabIndex = 11;
            this.c15.Text = "Phụ trách phỏng TCKT - Ủy viên";
            // 
            // c14
            // 
            this.c14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c14.Location = new System.Drawing.Point(246, 112);
            this.c14.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c14.Name = "c14";
            this.c14.Size = new System.Drawing.Size(234, 21);
            this.c14.TabIndex = 9;
            this.c14.Text = "Phụ trách khoa dược - Ủy viên";
            // 
            // c13
            // 
            this.c13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c13.Location = new System.Drawing.Point(246, 88);
            this.c13.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(234, 21);
            this.c13.TabIndex = 7;
            this.c13.Text = "Phó CN kho - Phụ trách kho - Ủy viên";
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(246, 64);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(234, 21);
            this.c12.TabIndex = 5;
            this.c12.Text = "Trưởng phòng KHTH - Ủy viên";
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(246, 40);
            this.c11.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(234, 21);
            this.c11.TabIndex = 3;
            this.c11.Text = "Chủ tịch hội đồng";
            // 
            // madv
            // 
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(52, 16);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(58, 21);
            this.madv.TabIndex = 0;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // listNX
            // 
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(400, 248);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "QUÝ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(368, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "NĂM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(53, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 24);
            this.label10.TabIndex = 29;
            this.label10.Text = "THÁNG";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // THANG
            // 
            this.THANG.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.THANG.Location = new System.Drawing.Point(112, 184);
            this.THANG.Name = "THANG";
            this.THANG.Size = new System.Drawing.Size(56, 22);
            this.THANG.TabIndex = 14;
            this.THANG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // QUY
            // 
            this.QUY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QUY.Location = new System.Drawing.Point(248, 184);
            this.QUY.Name = "QUY";
            this.QUY.Size = new System.Drawing.Size(56, 22);
            this.QUY.TabIndex = 15;
            this.QUY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // NAM
            // 
            this.NAM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NAM.Location = new System.Drawing.Point(408, 184);
            this.NAM.Name = "NAM";
            this.NAM.Size = new System.Drawing.Size(72, 22);
            this.NAM.TabIndex = 16;
            this.NAM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.Export;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(140, 232);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 85;
            this.butXem.Text = "     &Excel";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // frmInkqthau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(498, 287);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.NAM);
            this.Controls.Add(this.QUY);
            this.Controls.Add(this.THANG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.c16);
            this.Controls.Add(this.c15);
            this.Controls.Add(this.c14);
            this.Controls.Add(this.c13);
            this.Controls.Add(this.c12);
            this.Controls.Add(this.c11);
            this.Controls.Add(this.c6);
            this.Controls.Add(this.c5);
            this.Controls.Add(this.c4);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInkqthau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả thầu vật tư, sản phẩm, hàng hóa";
            this.Load += new System.EventHandler(this.rptBbknhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptBbknhap_Load(object sender, System.EventArgs e)
		{
			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";
			dtdmnx=d.get_data("select ma,ten,id,nhomcc from d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];
			listNX.DataSource=dtdmnx;	
			//
			THANG.Text=s_mmyy.Substring(0,2);
			int i_thang=int.Parse(s_mmyy.Substring(0,2));
			i_thang=(i_thang-1)/3+1;
			QUY.Text=i_thang.ToString().PadLeft(2,'0');
			NAM.Text="20"+s_mmyy.Substring(2,2);
			//
			dsxml.ReadXml("..\\..\\..\\xml\\d_xetthau.xml");
			c1.Text=dsxml.Tables[0].Rows[0]["c01"].ToString();
			c2.Text=dsxml.Tables[0].Rows[0]["c02"].ToString();
			c3.Text=dsxml.Tables[0].Rows[0]["c03"].ToString();
			c4.Text=dsxml.Tables[0].Rows[0]["c04"].ToString();
			c5.Text=dsxml.Tables[0].Rows[0]["c05"].ToString();
			c6.Text=dsxml.Tables[0].Rows[0]["c06"].ToString();			
			c11.Text=dsxml.Tables[0].Rows[0]["c11"].ToString();
			c12.Text=dsxml.Tables[0].Rows[0]["c12"].ToString();
			c13.Text=dsxml.Tables[0].Rows[0]["c13"].ToString();
			c14.Text=dsxml.Tables[0].Rows[0]["c14"].ToString();
			c15.Text=dsxml.Tables[0].Rows[0]["c15"].ToString();
			c16.Text=dsxml.Tables[0].Rows[0]["c16"].ToString();			
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				i_madv=0;
				DataRow r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
					madv.Focus();
					return;
				}
				i_madv=int.Parse(r["id"].ToString());
			}
			else
				i_madv=0;
			//
			Load_dmdutru(i_madv);										
			if(i_madv<=0)
			{
				frmReport f=new frmReport(d,ds.Tables[0],d_userid,"d_kqthau.rpt","Tháng "+THANG.Text+" năm "+NAM.Text,"",c1.Text.Trim()+"+"+c11.Text.Trim(),c2.Text.Trim()+"+"+c12.Text.Trim(),c3.Text.Trim()+"+"+c13.Text.Trim(),c4.Text.Trim()+"+"+c14.Text.Trim(),c5.Text.Trim()+"+"+c15.Text.Trim(),c6.Text.Trim()+"+"+c16.Text.Trim()," QUÝ "+QUY.Text+" NĂM "+NAM.Text,"");
				f.ShowDialog();
			}
			else
			{
				frmReport f=new frmReport(d,ds.Tables[0],d_userid ,"d_kqthau_dv.rpt","Tháng "+THANG.Text+" năm "+NAM.Text,tendv.Text,"","","","","",""," QUÝ "+QUY.Text+" NĂM "+NAM.Text,"");				
				f.ShowDialog();
			}
		}
		

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.writeXml("d_xetthau","c01",c1.Text);
			d.writeXml("d_xetthau","c02",c2.Text);
			d.writeXml("d_xetthau","c03",c3.Text);
			d.writeXml("d_xetthau","c04",c4.Text);
			d.writeXml("d_xetthau","c05",c5.Text);
			d.writeXml("d_xetthau","c06",c6.Text);			
			d.writeXml("d_xetthau","c11",c11.Text);
			d.writeXml("d_xetthau","c12",c12.Text);
			d.writeXml("d_xetthau","c13",c13.Text);
			d.writeXml("d_xetthau","c14",c14.Text);
			d.writeXml("d_xetthau","c15",c15.Text);
			d.writeXml("d_xetthau","c16",c16.Text);			
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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

		private void tendv_TextChanged(object sender, System.EventArgs e)
		{
			Filter_dmnx(tendv.Text);
			listNX.BrowseToDmnx(tendv,madv,c1);
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
		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				DataRow r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null) tendv.Text=r["ten"].ToString();
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

		private void Load_dmdutru(int i_manx)
		{
			ds=new DataSet();
			string sql="select a.mabd,b.ma,b.ten tenbd,(trim(b.tenhc)||' '||b.hamluong) tenhc,b.dang,a.tongton,a.soluong,a.dongia,";
			sql+=" a.SLDUKIEN*a.dongia sotien,a.congty, B.TEN, B.HAMLUONG, A.SLDUKIEN, A.NOISX, NVL(C.TEN,'') NUOCSX, A.QUICACH, C.loai CONGTY1, NVL(D.ma,'')NHACC,A.HANDUNG, A.MMYY, ";
			sql+=" F.nhombd MANHOM, E.TEN TENNHOM, a.nhomctd MALOAI, F.TEN TENLOAI, e.stt";
			sql+=" from d_dutrumua a,d_dmbd b, d_dmnuoc c, d_dmnx d, d_dmnhom e, d_nhomctd f";
			sql+=" where a.mabd=b.id and a.nhomctd=f.id and f.nhombd=e.id and a.noisx=c.id(+) and a.congty=d.id and a.congty>0";			
			if(i_manx>0) sql+=" and a.congty="+i_manx;
			sql+=" and a.mmyy='"+s_mmyy+"'"+" and a.nhom="+i_nhom+" order by b.ten";
			ds=d.get_data(sql);
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
