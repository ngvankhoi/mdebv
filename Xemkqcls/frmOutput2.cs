using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public class frmOutput2 : System.Windows.Forms.Form
	{
		private AccessData m;
		private Timer Clock;
		private System.Windows.Forms.Panel panel1;
		private Label lbl;
		private string sql,s_mabn="";
		private bool bStt,bAuto,bHolotten;
		private Font font;
		private DataTable dt=new DataTable();
		private DataTable tmp=new DataTable();
		private System.Windows.Forms.Panel panel2;
		private System.ComponentModel.IContainer components=null;
		private string s_makp="",ngay,user,xxx,_makp="";
		private DataSet ds=new DataSet();
		private int i_len,i_w,i_h,r1,g1,b1,r2,g2,b2,i_s=36;
		private System.Windows.Forms.Label lblTenkp;
        private Label lblHoten;
        private Label lblStt;
        private Label label2;
        private Label label1;
		private System.Windows.Forms.Panel panel3;

		public frmOutput2(AccessData acc,string makp)
		{
			InitializeComponent();
			m=acc;s_makp=makp;
		}
        public frmOutput2(AccessData acc, string makp,string _s_mabn)
        {
            InitializeComponent();
            m = acc; s_makp = makp; s_mabn = _s_mabn;
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
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutput2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHoten = new System.Windows.Forms.Label();
            this.lblStt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTenkp = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 276);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Controls.Add(this.lblHoten);
            this.panel3.Controls.Add(this.lblStt);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblTenkp);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 168);
            this.panel3.TabIndex = 3;
            // 
            // lblHoten
            // 
            this.lblHoten.AutoSize = true;
            this.lblHoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoten.ForeColor = System.Drawing.Color.White;
            this.lblHoten.Location = new System.Drawing.Point(309, 94);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(343, 69);
            this.lblHoten.TabIndex = 4;
            this.lblHoten.Text = "Đang khám";
            this.lblHoten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStt
            // 
            this.lblStt.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStt.ForeColor = System.Drawing.Color.White;
            this.lblStt.Location = new System.Drawing.Point(-3, 89);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(325, 76);
            this.lblStt.TabIndex = 3;
            this.lblStt.Text = "Đang khám:";
            this.lblStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(269, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(510, 69);
            this.label2.TabIndex = 2;
            this.label2.Text = "HỌ VÀ TÊN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "STT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenkp
            // 
            this.lblTenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenkp.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblTenkp.Font = new System.Drawing.Font("Microsoft Sans Serif", 51F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenkp.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTenkp.Location = new System.Drawing.Point(0, -8);
            this.lblTenkp.Name = "lblTenkp";
            this.lblTenkp.Size = new System.Drawing.Size(800, 176);
            this.lblTenkp.TabIndex = 0;
            this.lblTenkp.Text = "Mời BN có tên sau vào phòng khám";
            this.lblTenkp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOutput2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(800, 0);
            this.Name = "frmOutput2";
            this.ShowInTaskbar = false;
            this.Text = "Danh sách khám bệnh";
            this.Closed += new System.EventHandler(this.frmOutput2_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOutput2_KeyDown);
            this.Load += new System.EventHandler(this.frmOutput2_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public string setSQL
		{
			set
			{
				sql=value;
				dt=m.get_data(sql).Tables[0];
				load_data();
			}
		}
		private void butExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmOutput2_Load(object sender, System.EventArgs e)
		{
			ngay=m.ngayhienhanh_server.Substring(0,10);
			user=m.user;xxx=user+m.mmyy(ngay);
			ds.ReadXml("..\\..\\..\\xml\\mau.xml");
			//bStt=m.bStt_kham;
            bStt=bAuto = m.bStt_tudong;
			//bHolotten=m.bHien_holotten; //(chỗ này làm sau)
			r1=int.Parse(ds.Tables[0].Rows[0]["r1"].ToString());
			g1=int.Parse(ds.Tables[0].Rows[0]["g1"].ToString());
			b1=int.Parse(ds.Tables[0].Rows[0]["b1"].ToString());
			r2=int.Parse(ds.Tables[0].Rows[0]["r2"].ToString());
			g2=int.Parse(ds.Tables[0].Rows[0]["g2"].ToString());
			b2=int.Parse(ds.Tables[0].Rows[0]["b2"].ToString());
			this.BackColor=Color.FromArgb(r1,g1,b1);
			i_w=m.width;i_h=m.height;i_s=m.size;

			this.Location = new System.Drawing.Point(m.LocationX,m.LocationY);
			this.ClientSize = new System.Drawing.Size(i_w,i_h);
			this.panel1.Size = new System.Drawing.Size(i_w, 100);
			this.panel2.Size = new System.Drawing.Size(i_w, 100);
			this.panel3.Size = new System.Drawing.Size(i_w, 168);
            panel1.Font.Size = int.Parse(ds.Tables[0].Rows[0]["s2"].ToString());
            panel2.Font.Size = int.Parse(ds.Tables[0].Rows[0]["s2"].ToString());
			this.lblTenkp.Size = new System.Drawing.Size(i_w,176);
            
			if (s_makp!="")
			{
				foreach(DataRow r in m.get_data("select tenkp from "+user+".btdkp_bv where makp='"+s_makp.Trim(',')+"'").Tables[0].Rows)
					lblTenkp.Text="Mời BN có tên sau vào "+r["tenkp"].ToString().Trim();
			}
			lblTenkp.Text=lblTenkp.Text.ToUpper();
            lblTenkp.Text = "";
            lblStt.Text = "Đang khám";
            if (s_mabn != "")
                lblHoten.Text = m.get_data("select hoten from " + user + ".btdbn where mabn='" + s_mabn.Trim() + "'").Tables[0].Rows[0]["hoten"].ToString();

			sql="select a.sovaovien,a.mabn,b.hoten||'('||b.namsinh||')' as hoten,a.done,a.oid as stt,";
			sql+=" case when a.noitiepdon=16 then 'x' else 'y' end as tk, ";
            sql += " b.hoten as ten,to_char(sysdate,'yyyy')-b.namsinh as tuoi ";//,a.kham
			sql+=" from "+xxx+".tiepdon a,"+user+".btdbn b ";
			sql+=" where a.mabn=b.mabn and a.mabn not in ('"+s_mabn+"') ";
			sql+=" and (a.done is null ";
            if (!m.bThuphi_kham)
                sql += "or done='c' ";
            sql += ") ";
			//sql+=" and (a.done is null or a.done in ('?','d')) ";
			sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+ngay+"'";
			sql+=" and a.noitiepdon in (0,1,5,16)";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
                if (s.Length > 3) s = s.Substring(0, s.Length - 3);
				sql+=" and a.makp in ('"+s+"')";
			}
			if (bStt) 
			{
				sql+=" and a.sovaovien is not null";
				sql+=" order by to_number(a.sovaovien,'0000000000'),a.ngay,a.makp";
			}
			else sql+=" order by a.ngay,a.makp";
			dt=m.get_data(sql).Tables[0];
			font=new System.Drawing.Font("Microsoft Sans Serif",i_s, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			lblTenkp.ForeColor=Color.FromArgb(r2,g2,b2);
			load_data();
			Clock=new Timer();
			Clock.Interval=m.delay;
			Clock.Start();
			Clock.Tick+=new EventHandler(Timer_Tick);

            lblStt.Width = i_w;
            int i_len = lblStt.Text.Trim().Length;
            lblStt.Height = Convert.ToInt16(60 * (Math.Round(Convert.ToDecimal(i_len / 36), 0) + 1));

            lblHoten.Width = i_w;
            i_len = lblHoten.Text.Trim().Length;
            lblHoten.Height = Convert.ToInt16(60 * (Math.Round(Convert.ToDecimal(i_len / 36), 0) + 1));
		}

		public void Timer_Tick(object sender,EventArgs eArgs)
		{
			if(sender==Clock)
			{
				try
				{
					refresh(2);
				}
				catch{}
			}
		}

		private void refresh(int vRadian)
		{
			try
			{
				if(panel1.Top< panel2.Top)
				{
					panel1.Top=panel1.Top - vRadian;
					panel2.Top=panel1.Bottom;
				}
				else
				{
					panel2.Top=panel2.Top - vRadian;
					panel1.Top=panel2.Bottom;
				}
				if(panel1.Bottom<=panel3.Bottom)//0
				{
					//if (bKiemtra()) load_data();
					panel1.Top=panel2.Bottom;
				}
				else if(panel2.Bottom<=panel3.Bottom)//0
				{
					//if (bKiemtra()) load_data();
					panel2.Top=panel1.Bottom;
				}
			}
			catch{}
		}

		private bool bKiemtra()
		{
			bool ret=false;
			string sql1="select * from "+user+".btdkp_bv where remark=1 ";
			if (_makp!="") sql1+=" and makp in ('"+_makp.Substring(0,_makp.Length-3)+"')";
			if (m.get_data(sql1).Tables[0].Rows.Count>0)
			{
				tmp=m.get_data(sql).Tables[0];
				if (tmp.Rows.Count!=dt.Rows.Count)
				{
					dt=tmp;
					ret=true;
				}
				else
				{
					DataRow r;
					for(int i=0;i<tmp.Rows.Count;i++)
					{
						r=m.getrowbyid(dt,"mabn ='"+tmp.Rows[i]["mabn"].ToString()+"'");// and kham="+int.Parse(tmp.Rows[i]["kham"].ToString()));
						ret=(r==null);
						if (ret)
						{
							dt=tmp;
							break;
						}
					}
				}
			}
			if (ret)
			{
				sql1="update "+user+".btdkp_bv set remark=0 ";
				if (_makp!="") sql1+=" where makp in ('"+_makp.Substring(0,_makp.Length-3)+"')";
				m.execute_data(sql1);
			}
			return ret;
		}


		private void load_data()
		{
			try
			{
				panel1.Controls.Clear();
				panel1.Width=i_w;//Screen.PrimaryScreen.WorkingArea.Width;
				panel1.Height=i_h;//Screen.PrimaryScreen.WorkingArea.Height;//-panel3.Height;

				panel2.Controls.Clear();
				panel2.Width=i_w;//Screen.PrimaryScreen.WorkingArea.Width;
				panel2.Height=i_h;//Screen.PrimaryScreen.WorkingArea.Height;//-panel3.Height;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					lable(i,0,0);
					lable(i,1,0);
				}
				move(getPanel(0));
				move(getPanel(1));
			}
			catch{}
		}

		private void lable(int i,int j,int k)
		{
			lbl=new Label();
			lbl.Text=ten(i);
			lbl.Font=font;
			lbl.ForeColor=color(i);
			lbl.AutoSize=k==0;
			if (k==1)
			{
				lbl.Width=i_w;
				i_len=lbl.Text.Trim().Length;
				lbl.Height=Convert.ToInt16(50*(Math.Round(Convert.ToDecimal(i_len/36),0)+1));
			}
			getPanel(j).Controls.Add(lbl);
		}

		private void move(Panel p)
		{
			try
			{
				int t=0;
				int h=0;
				foreach(System.Windows.Forms.Control c in p.Controls)
				{
					c.Top=t;
					c.Left=0;
					h=h+c.Height;
					t=c.Bottom;
					c.Font = new Font(font.FontFamily.Name,c.Font.Size);
				}
				p.Height = h;
				p.Width=i_w;//Screen.PrimaryScreen.WorkingArea.Width;
				p.Left=0;
				if(p.Height < i_h)//.PrimaryScreen.WorkingArea.Height)//-panel3.Height)
				{
					p.Height=i_h;//.PrimaryScreen.WorkingArea.Height;//-panel3.Height;
				}
			}
			catch{}
		}

		private string ten(int p)
		{
			int i=p+1;
			string hoten=(bHolotten)?m.holot_ten(dt.Rows[p]["ten"].ToString().Trim()):dt.Rows[p]["ten"].ToString().Trim();
			//return i.ToString().PadLeft(2,'0')+"."+hoten+"("+dt.Rows[p]["tuoi"].ToString().Trim()+"T)"+((bStt)?"-"+dt.Rows[p]["sovaovien"].ToString().Trim():"");
            return ((bStt) ? dt.Rows[p]["sovaovien"].ToString().Trim().PadLeft(3,'0'): i.ToString().PadLeft(2,'0')) +"." + hoten + "(" + dt.Rows[p]["tuoi"].ToString().Trim() + "T)";
		}
		
		private Color color(int p)
		{
			//return (dt.Rows[p]["kham"].ToString()=="0")?Color.FromArgb(r2,g2,b2):Color.Red;
			return (p+1>5)?Color.FromArgb(r2,g2,b2):Color.Red;
		}

		private Panel getPanel(int i)
		{
			Panel [] map={panel1,panel2};
			return map[i];
		}

		private void frmOutput2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F4:
					this.FormBorderStyle=FormBorderStyle.None;
					break;
				case Keys.F5:
					this.FormBorderStyle=FormBorderStyle.FixedSingle;
					break;
			}
		}

		private bool check_exits_frm(string b_formname)
		{
			bool blnactive=false;
			Form[] charr= this.MdiChildren;  
			foreach (Form chform in charr) 
			{
				if(chform.Name.ToString().ToUpper()==b_formname.ToUpper())
				{
					chform.Activate();
					blnactive=true;
					break;
				}
			}
			return blnactive;
		}

		private void frmOutput2_Closed(object sender, System.EventArgs e)
		{
			Clock.Stop();
		}
	}
}
