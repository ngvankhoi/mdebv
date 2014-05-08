using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace libxTutruc
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private LibMedi.AccessData m=new LibMedi.AccessData();
		//
		private string s_userid="";
		private string s_right="";
		private string s_makp="";
		private int i_userid=0;
		private int i_mabv=0;
		private string s_madoituong="";
		private string s_nhomkho="";
		private string s_cls="";
		private string s_mabs="";
		//
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private Button butkham;
        private Button butxuatkhoa;
        private Button button3;
        private Button button4;
        private Label lblten;
        private Label lblma;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
				if (components != null) 
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butkham = new System.Windows.Forms.Button();
            this.butxuatkhoa = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblten = new System.Windows.Forms.Label();
            this.lblma = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xuất tủ trực";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(0, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(292, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Kết thúc";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // butkham
            // 
            this.butkham.Dock = System.Windows.Forms.DockStyle.Top;
            this.butkham.Enabled = false;
            this.butkham.Location = new System.Drawing.Point(0, 32);
            this.butkham.Name = "butkham";
            this.butkham.Size = new System.Drawing.Size(292, 32);
            this.butkham.TabIndex = 2;
            this.butkham.Text = "Khám bệnh";
            this.butkham.Visible = false;
            this.butkham.Click += new System.EventHandler(this.butkham_Click);
            // 
            // butxuatkhoa
            // 
            this.butxuatkhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.butxuatkhoa.Enabled = false;
            this.butxuatkhoa.Location = new System.Drawing.Point(0, 64);
            this.butxuatkhoa.Name = "butxuatkhoa";
            this.butxuatkhoa.Size = new System.Drawing.Size(292, 32);
            this.butxuatkhoa.TabIndex = 3;
            this.butxuatkhoa.Text = "Xuất khoa";
            this.butxuatkhoa.Visible = false;
            this.butxuatkhoa.Click += new System.EventHandler(this.butxuatkhoa_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(0, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(292, 32);
            this.button3.TabIndex = 4;
            this.button3.Text = "Công khai thuốc";
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(0, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(292, 32);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cập nhật mã thuốc";
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblten
            // 
            this.lblten.AutoSize = true;
            this.lblten.Location = new System.Drawing.Point(12, 216);
            this.lblten.Name = "lblten";
            this.lblten.Size = new System.Drawing.Size(35, 13);
            this.lblten.TabIndex = 6;
            this.lblten.Text = "label1";
            this.lblten.Visible = false;
            // 
            // lblma
            // 
            this.lblma.AutoSize = true;
            this.lblma.Location = new System.Drawing.Point(12, 190);
            this.lblma.Name = "lblma";
            this.lblma.Size = new System.Drawing.Size(35, 13);
            this.lblma.TabIndex = 7;
            this.lblma.Text = "label1";
            this.lblma.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.lblma);
            this.Controls.Add(this.lblten);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.butxuatkhoa);
            this.Controls.Add(this.butkham);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int loai=2;
			frmChonthongso f=new frmChonthongso(m,1,loai,0,s_makp,false,s_nhomkho);
			f.ShowDialog(this);
			if (f.s_makp!="")
			{
				frmXtutruc f1=new frmXtutruc(f.s_ngay,f.s_makho,f.s_makp,f.i_nhom,loai,f.i_phieu,f.i_macstt,f.i_makp,i_userid,f.s_mmyy,f.l_duyet,"Phiếu xuất tủ trực "+f.s_tennhom.Trim()+" theo người bệnh ("+f.s_ngay.Trim()+", "+f.s_tenkp.Trim()+", "+f.s_phieu.Trim()+", "+s_userid.Trim()+")",LibMedi.AccessData.Msg,m.bDausinhton,m.iSudungthuoc,f.s_manguon,"",f.i_buoi,f.s_tenkp,f.s_phieu,f.i_somay,"");				
				f1.ShowDialog();
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{			
			frmLogin f=new frmLogin(m);
			f.ShowDialog();
			if (f.mUserid!="")
			{
				s_userid=f.mUserid;
				s_right=f.mRight;
				s_makp=f.mMakp;
				i_userid=f.iUserid;
				i_mabv=f.iMabv;
				s_madoituong=f.mMadoituong;
				s_nhomkho=f.mNhomkho;
				s_cls=f.mCls;
				s_mabs=f.mMabs;
			}
			else Application.Exit();				
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

        private void butkham_Click(object sender, EventArgs e)
        {
            bool b_sovaovien=false,b_soluutru=false,b_admin=false;
            //frmKhambenh f = new frmKhambenh(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, "", s_nhomkho, true);
            //f.Show();
        }

        private void butxuatkhoa_Click(object sender, EventArgs e)
        {
            frmChonkhoa f1 = new frmChonkhoa(m, s_makp);
            f1.ShowDialog();
            string makp = f1.m_makp;
            if (makp == "") return;
            frmXuatkhoa f = new frmXuatkhoa(m, makp, s_userid, i_userid, i_mabv, false, false);            
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDonthuoc f = new frmDonthuoc(m, s_makp);
            //f.MdiParent = this;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //f_caplai_mabd(2);
        }
        private void f_caplai_mabd(int i_nhom)
        {
            string user = m.user;
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            string sql = "update " + user + ".d_dmbd set ma='000000' where nhom=" + i_nhom;// +" and ma='BAN001'";
            d.execute_data(sql);
            sql = "select id, ma, ten from " + user + ".d_dmbd where nhom=" + i_nhom + " order by ten, id ";//+" and ma='000000' 
            DataSet lds = m.get_data(sql);
            string s_ma = "";
            int i1 = lds.Tables[0].Rows.Count;
            int i2 = 0;
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                s_ma = d.getMabd("d_dmbd", r["ten"].ToString(), i_nhom);
                sql = "update " + user + ".d_dmbd set ma='" + s_ma + "' where id=" + r["id"].ToString();
                d.execute_data(sql);
                i2 += 1;
                lblma.Text = s_ma;
                lblma.Refresh();
                lblten.Text = r["ten"].ToString() + " - " + i2.ToString() + "/" + i1.ToString();
                lblten.Refresh();
            }

        }
	}
}
