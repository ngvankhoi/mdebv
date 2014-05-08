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
	/// Summary description for rptDspttt.
	/// </summary>
	public class rptDspttt : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox loaipt;
		private string sql,title,s_makp,s_mapm,user;
		private DataSet ds=new DataSet();
		private DataTable dtkp=new DataTable();
		private DataTable dtpm=new DataTable();
		private bool bClear=true;
		private AccessData m;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckedListBox mapm;
        private CheckBox chkmonoisoi;
        private CheckBox chkmolai;
        private CheckBox chkXML;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptDspttt(AccessData acc)
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
        public rptDspttt()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
            m = new AccessData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptDspttt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.mapm = new System.Windows.Forms.CheckedListBox();
            this.chkmonoisoi = new System.Windows.Forms.CheckBox();
            this.chkmolai = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(124, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(160, 177);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(232, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Kết thúc";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(53, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(165, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // loaipt
            // 
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Items.AddRange(new object[] {
            "Phẫu thuật",
            "Thủ thuật"});
            this.loaipt.Location = new System.Drawing.Point(53, 31);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(192, 21);
            this.loaipt.TabIndex = 2;
            this.loaipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(248, 7);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(205, 164);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mapm
            // 
            this.mapm.CheckOnClick = true;
            this.mapm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapm.Location = new System.Drawing.Point(53, 54);
            this.mapm.Name = "mapm";
            this.mapm.Size = new System.Drawing.Size(192, 116);
            this.mapm.TabIndex = 3;
            this.mapm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkmonoisoi
            // 
            this.chkmonoisoi.AutoSize = true;
            this.chkmonoisoi.Location = new System.Drawing.Point(53, 176);
            this.chkmonoisoi.Name = "chkmonoisoi";
            this.chkmonoisoi.Size = new System.Drawing.Size(74, 17);
            this.chkmonoisoi.TabIndex = 7;
            this.chkmonoisoi.Text = "Mổ nội soi";
            this.chkmonoisoi.UseVisualStyleBackColor = true;
            // 
            // chkmolai
            // 
            this.chkmolai.AutoSize = true;
            this.chkmolai.Location = new System.Drawing.Point(53, 194);
            this.chkmolai.Name = "chkmolai";
            this.chkmolai.Size = new System.Drawing.Size(98, 17);
            this.chkmolai.TabIndex = 8;
            this.chkmolai.Text = "Mổ lại miễn phí";
            this.chkmolai.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(366, 176);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 9;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // rptDspttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(463, 217);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkmolai);
            this.Controls.Add(this.chkmonoisoi);
            this.Controls.Add(this.mapm);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.den);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rptDspttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phẫu thuật,thủ thuật";
            this.Load += new System.EventHandler(this.rptDspttt_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptDspttt_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptDspttt_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dtkp=m.get_data("select * from "+user+".btdkp_bv order by loai,makp").Tables[0];
            makp.DataSource = dtkp;
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";
			dtpm=m.get_data("select * from "+user+".btdpmo order by ma").Tables[0];
            mapm.DataSource = dtpm;
            mapm.DisplayMember = "TEN";
			mapm.ValueMember="MA";
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void rptDspttt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				loaipt.SelectedIndex=-1;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			title="";
			s_makp="";
			s_mapm="";
			string s_tenkp="",s_tenpm="";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) 
				{
					s_makp+=dtkp.Rows[i]["makp"].ToString()+",";
					s_tenkp+=dtkp.Rows[i]["tenkp"].ToString()+",";
				}
			for(int i=0;i<mapm.Items.Count;i++)
				if (mapm.GetItemChecked(i)) 
				{
					s_mapm+=dtpm.Rows[i]["ma"].ToString()+",";
					s_tenpm+=dtpm.Rows[i]["ten"].ToString()+",";
				}
			title=(tu.Text==den.Text)?
lan.Change_language_MessageText("Ngày")+" "+tu.Text:
lan.Change_language_MessageText("Từ ngày")+" "+tu.Text+" "+
lan.Change_language_MessageText("đến")+" "+den.Text;
			if (s_tenkp!="") title=title+" "+
lan.Change_language_MessageText("KHOA")+" "+s_tenkp;
			if (s_tenpm!="") title=title+" "+
lan.Change_language_MessageText("PHÒNG MỖ")+" "+s_tenpm;
			if (loaipt.SelectedIndex!=-1) title=title+" "+loaipt.Text;
            sql = " select p.id,b.hoten,b.mabn,b.phai,b.namsinh,to_char(p.ngay,'dd/mm/yyyy hh24:mi') as ngay,tenpt,pp.ten,pt.dacbiet,pt.loai1,pt.loai2,pt.loai3,pt.loaipt,lpt.ten as tenloaipt, ";
            sql += " mc.hoten as hoten1,mc.hoten as hotenfull1,p1.hoten as hoten2,p1.hoten as hotenfull2,p2.hoten as hoten22,p2.hoten as hotenfull22,bsgm.hoten as hoten3,"+
                "bsgm.hoten as hotenfull3,ktvgm.hoten as hoten4,ktvgm.hoten as hotenfull4,hs.hoten as hoten5,hs.hoten as hotenfull5,dcu.hoten as hoten6,dcu.hoten as hotenfull6,p.somat,p.molaimien,";
            sql += "vp.gia_th,vp.gia_cs,vp.gia_bh,vp.gia_dv,vp.gia_nn";
            sql += ", p.chandoant, p.maicdt, p.chandoans, p.maicds, case when bh1.sothe is null then bh2.sothe else bh1.sothe end sothe ";
            sql += ",b.cholam, b.thon, b.sonha, tt.tentt, qu.tenquan, px.tenpxa ";
            sql += " from  "+user+".btdbn b inner join xxx.pttt p on b.mabn=p.mabn inner join "+user+".dmpttt pt on p.mapt=pt.mapt ";
            sql += " inner join " + user + ".dmbs mc on p.ptv=mc.ma left join " + user + ".dmbs p1 on p.phu1=p1.ma ";
            sql+=" left join "+user+".dmbs p2 on p.phu2=p2.ma left join "+user+".dmbs bsgm on p.bsgayme=bsgm.ma ";
            sql+=" left join "+user+".dmbs ktvgm on p.ktvgayme=ktvgm.ma left join "+user+".dmbs hs on p.hoisuc=hs.ma ";
            sql += " left join " + user + ".dmbs dcu on p.dungcu=dcu.ma inner join " + user + ".dmmete pp on p.phuongphap=pp.ma ";
            sql += " inner join " + user + ".loaipttt lpt on pt.loaipt=lpt.ma ";
            sql += " left join " + user + ".v_giavp vp on pt.mavp=vp.id";
            sql += " left join " + user + ".bhyt bh1 on p.maql=bh1.maql and (bh1.sudung is null or bh1.sudung=1)";
            sql += " left join xxx.bhyt bh2 on p.maql=bh2.maql";
            sql += " inner join " + user + ".btdtt tt on b.matt=tt.matt ";
            sql += " inner join " + user + ".btdquan qu on b.maqu=qu.maqu ";
            sql += " inner join " + user + ".btdpxa px on b.maphuongxa=px.maphuongxa ";

			sql+=" where  ";
			sql+=m.for_ngay("p.ngay","'dd/mm/yyyy'") +" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy') ";
            string s;
            if (s_makp != "")
            {
                s = s_makp.Replace(",", "','");
                sql += " and p.makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (s_mapm != "")
            {
                s = s_mapm.Replace(",", "','");
                sql += " and p.mapmo in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			if (loaipt.SelectedIndex!=-1) sql+=" and substr(p.mapt,1,1)='"+loaipt.Text.Substring(0,1)+"'";
            if (chkmonoisoi.Checked) sql += " and p.noisoi = 1";
            if (chkmolai.Checked) sql += " and p.molaimien = 1";
			sql+=" order by p.makp,p.mapmo,p.ngay";
            ds=m.get_data_mmyy(sql,tu.Text,den.Text,false);
            //
            //binh 280308
            string sql1 = "select a.id, a.mabn, a.maql, b.loai, b.mabs, c.ten, d.hoten ";
            sql1 += " from xxx.pttt a, medibv.pttt_bs b, medibv.pttt_loai c, medibv.dmbs d ";
            sql1 += " where a.id=b.id and b.loai=c.id and b.mabs=d.ma";
            if (chkmonoisoi.Checked) sql1 += " and a.noisoi = 1";
            if (chkmolai.Checked) sql1 += " and a.molaimien = 1";
            sql1 += " and to_date(to_char(a.ngay, 'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy') ";
            DataSet ds1 = m.get_data_mmyy(sql1, tu.Text, den.Text, false);
            //
            sql = " select a.hoten,b.ten from " + user + ".dmbs a," + user + ".dmchucdanh b where a.chucdanh=b.id order by ma";
            DataTable dtchucdanh = new DataTable();
            dtchucdanh=m.get_data(sql).Tables[0];
            ds.Tables[0].Columns.Add("chucdanh1");
            ds.Tables[0].Columns.Add("chucdanh2");
            ds.Tables[0].Columns.Add("chucdanh22");
            ds.Tables[0].Columns.Add("chucdanh3");
            ds.Tables[0].Columns.Add("chucdanh4");
            ds.Tables[0].Columns.Add("chucdanh5");
            ds.Tables[0].Columns.Add("chucdanh6");

			foreach(DataRow r in ds.Tables[0].Rows)
			{
                foreach (DataRow r0 in dtchucdanh.Rows)
                {
                    if (r["hoten1"].ToString() == r0["hoten"].ToString())
                    {
                        r["chucdanh1"] = r0["ten"].ToString();
                    }
                    if (r["hoten2"].ToString() == r0["hoten"].ToString())
                    {
                        r["chucdanh2"] = r0["ten"].ToString();
                    }
                    if (r["hoten22"].ToString()==r0["hoten"].ToString())
                    {
                        r["chucdanh22"] = r0["ten"].ToString();
                    }
                    if (r["hoten3"].ToString()== r0["hoten"].ToString())
                    {
                        r["chucdanh3"] = r0["ten"].ToString();
                    }
                    if (r["hoten4"].ToString()==r0["hoten"].ToString())
                    {
                        r["chucdanh4"] = r0["ten"].ToString();
                    }
                    if (r["hoten5"].ToString()== r0["hoten"].ToString())
                    {
                        r["chucdanh5"] = r0["ten"].ToString();
                    }
                    if (r["hoten6"].ToString()==r0["hoten"].ToString())
                    {
                        r["chucdanh6"] = r0["ten"].ToString();
                    }
                }
				r["hoten1"]=m.holot_ten(r["hoten1"].ToString());
				r["hoten2"]=m.holot_ten(r["hoten2"].ToString());
				r["hoten22"]=m.holot_ten(r["hoten22"].ToString());
				r["hoten3"]=m.holot_ten(r["hoten3"].ToString());
				r["hoten4"]=m.holot_ten(r["hoten4"].ToString());
				r["hoten5"]=m.holot_ten(r["hoten5"].ToString());
				r["hoten6"]=m.holot_ten(r["hoten6"].ToString());
                //binh280308
                foreach (DataRow r1 in ds1.Tables[0].Select("id=" + r["id"].ToString()))
                {
                    switch (r1["loai"].ToString())
                    {
                        case "1":
                            r["hoten1"] += ", " + m.holot_ten(r1["hoten"].ToString());//mo chinh
                            break;
                        case "2":
                            r["hoten2"] += ", " + m.holot_ten(r1["hoten"].ToString());//phu vt
                            break;
                        case "3":
                            r["hoten22"] += ", " + m.holot_ten(r1["hoten"].ToString());//phu vn
                            break;
                        case "4":
                            r["hoten3"] += ", " + m.holot_ten(r1["hoten"].ToString());//BS GM
                            break;
                        case "5":
                            r["hoten4"] += ", " + m.holot_ten(r1["hoten"].ToString());//KTV GM
                            break;
                        case "6":
                            r["hoten5"] += ", " + m.holot_ten(r1["hoten"].ToString());//hoi suc
                            break;
                        case "7":
                            r["hoten6"] += ", " + m.holot_ten(r1["hoten"].ToString());//dung cu
                            break;
                        default:
                            break;

                    }
                }
                //end binh280308
			}
            ds.Dispose();
			string tenfile=(m.Mabv_so==701424)?"rptDspttt_mat.rpt":"rptDspttt.rpt";
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                ds.WriteXml("..\\xml\\dspttt.xml", XmlWriteMode.WriteSchema);
            }
			if (ds.Tables[0].Rows.Count!=0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title,tenfile,false);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
		}
	}
}
