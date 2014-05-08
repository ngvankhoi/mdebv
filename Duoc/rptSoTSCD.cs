using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBbkiemke.
	/// </summary>
	public class rptSoTSCD : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_userid=0;
		private string sql,s_mmyy,s_kho,s_makp,s_nhom,s_tenkp,user,xxx;
		private DataRow r1,r2,r3,r4;
		private DataSet ds=new DataSet();
		private DataSet dsrpt=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtkho=new DataTable();
		private DataTable dtmakp=new DataTable();
		private DataTable dtnhom=new DataTable();
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckedListBox manhom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public rptSoTSCD(AccessData acc, int nhom, string _kho, string mmyy, string _makp, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
            i_userid = _userid;
			i_nhom=nhom;s_kho=_kho;s_makp=_makp;
			mm.Value=decimal.Parse(mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptSoTSCD));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(99, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(152, 200);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 12;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(222, 200);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(137, 11);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 1;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(52, 11);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(40, 21);
            this.mm.TabIndex = 0;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(192, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 32);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(136, 10);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(88, 20);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Khoa/phòng";
            this.rb3.CheckedChanged += new System.EventHandler(this.rb3_CheckedChanged);
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(87, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(50, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Kho";
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(8, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(74, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Toàn viện";
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kho
            // 
            this.kho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kho.CheckOnClick = true;
            this.kho.Enabled = false;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(52, 90);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(180, 100);
            this.kho.TabIndex = 4;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.CheckOnClick = true;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(236, 36);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(180, 148);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(52, 36);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(180, 52);
            this.manhom.TabIndex = 3;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptSoTSCD
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(426, 239);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptSoTSCD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ theo dõi tài sản cố định và dụng cụ";
            this.Load += new System.EventHandler(this.rptSoTSCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptSoTSCD_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			sql="select * from "+user+".d_duockp ";
			sql+=" where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="")  sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
            makp.DataSource = dtmakp;
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			

			sql="select * from "+user+".d_dmnhom where theodoi=1 and nhom="+i_nhom+" order by stt";
			dtnhom=d.get_data(sql).Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";
			

            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom + " and thua=0";
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
			//
            sql = "select a.*, b.stt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai,g.ten as tennuoc from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f," + user + ".d_dmnuoc g";
			sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.manuoc=g.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];
			//
			ds.ReadXml("..\\..\\..\\xml\\d_sotscd.xml");
			dsrpt.ReadXml("..\\..\\..\\xml\\d_sotscd.xml");
			//
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			ds.Clear();
			s_nhom="";
			for(int i=0;i<manhom.Items.Count;i++)
				if (manhom.GetItemChecked(i)) s_nhom+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
			s_kho="";
			for(int i=0;i<kho.Items.Count;i++)
				if (kho.GetItemChecked(i)) s_kho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
			s_makp="";s_tenkp="";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) 
				{
					s_makp+=dtmakp.Rows[i]["id"].ToString().Trim()+",";
					s_tenkp+=dtmakp.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_tenkp!="") s_tenkp=s_tenkp.Substring(0,s_tenkp.Length-1);
			get_data();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			string tenfile=(rb3.Checked)?"d_sotscdkhoa.rpt":"d_sotscd.rpt";
			frmReport f=new frmReport(d,dsrpt.Tables[0], i_userid,tenfile,s_tenkp,"Tháng "+mm.Value.ToString().PadLeft(2,'0')+" năm "+yyyy.Value.ToString(),yyyy.Value.ToString(),"","","","","","","");
			f.ShowDialog();
		}

		private void get_sort()
		{
			dsrpt.Clear();
			if (rb3.Checked) sql="tennhom,tenkp,ten";
			else sql="tennhom,ten,tenkp";
			dsrpt.Merge(ds.Tables[0].Select("soluong>0",sql));
			foreach(DataRow r in dsrpt.Tables[0].Rows)
			{
				r["sotien"]=decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["giamua"].ToString());
				if (decimal.Parse(r["namsd"].ToString())+1<=yyyy.Value && decimal.Parse(r["namsd"].ToString())>0)
				{
					r["sotienhm"]=(decimal.Parse(r["namsd"].ToString())+1==yyyy.Value)?0:decimal.Parse(r["sotien"].ToString())*decimal.Parse(r["tyle"].ToString())/100*(yyyy.Value-decimal.Parse(r["namsd"].ToString())-1);
					r["nam"]=(decimal.Parse(r["namsd"].ToString())==yyyy.Value)?0:decimal.Parse(r["sotien"].ToString())*decimal.Parse(r["tyle"].ToString())/100;
				}					
			}
		}

		private void ins_items()
		{
			DataRow [] dr;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{
					sql="namsd="+int.Parse(r["namsd"].ToString())+" and makp="+int.Parse(r["makp"].ToString())+" and mabd="+int.Parse(r["mabd"].ToString())+" and giamua="+decimal.Parse(r["giamua"].ToString());
					r2=d.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{
						r3=ds.Tables[0].NewRow();
						r3["tennhom"]=r1["tennhom"].ToString();
						r3["makp"]=r["makp"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r1["ma"].ToString();
						r3["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
						r3["dang"]=r1["dang"].ToString();
						r3["tennuoc"]=r1["tennuoc"].ToString();
						r3["namsd"]=r["namsd"].ToString();
						r3["tyle"]=r1["tyle"].ToString();
						r3["soluong"]=r["soluong"].ToString();
						r3["giamua"]=r["giamua"].ToString();
						r3["sotien"]=0;
						r3["sotienhm"]=0;
						r3["nam"]=0;
						r3["sl2"]=0;
						r3["ngay2"]="";
						if (r["makp"].ToString()=="0") r3["tenkp"]="";
						else
						{
							r4=d.getrowbyid(dtmakp,"id="+int.Parse(r["makp"].ToString()));
							if (r4!=null) r3["tenkp"]=r4["ten"].ToString();
							else r3["tenkp"]="";
						}
						ds.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
		}
		private void get_data()
		{
			string mmyy="";
            xxx = user + s_mmyy;
			if (rb1.Checked || rb2.Checked)
			{
				sql="select t.namsd,0 as makp,a.mabd,t.giamua,sum(a.tondau+a.slnhap-a.slxuat) as soluong ";
				sql+=" from "+xxx+".d_tonkhoct a, "+user+".d_dmbd b,"+user+".d_dmnhom c,"+xxx+".d_theodoi t,"+user+".d_dmkho e";
				sql+=" where a.mabd=b.id and b.manhom=c.id and c.theodoi=1 and b.nhom="+i_nhom;
				sql+=" and a.makho=e.id and a.stt=t.id and e.thua=0";
				if (s_nhom!="") sql+=" and b.manhom in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
				if (s_kho!="" && kho.Enabled) sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				sql+=" group by t.namsd,a.mabd,t.giamua";
				ins_items();
			}
			if (rb1.Checked || rb3.Checked)
			{
				sql="select t.namsd,";
				if (rb3.Checked) sql+="a.makp,";
				else sql+="0 as makp,";
				sql+="a.mabd,t.giamua,sum(a.tondau+a.slnhap-a.slxuat) as soluong ";
				sql+=" from "+xxx+".d_tutrucct a, "+user+".d_dmbd b,"+user+".d_dmnhom c,"+xxx+".d_theodoi t,"+user+".d_dmkho e";
				sql+=" where a.mabd=b.id and b.manhom=c.id and c.theodoi=1 and b.nhom="+i_nhom;
				sql+=" and a.makho=e.id and a.stt=t.id and e.thua=0";
				if (s_nhom!="") sql+=" and b.manhom in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
				if (s_kho!="" && kho.Enabled) sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_makp!="" && makp.Enabled) sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
				sql+=" group by t.namsd,";
				if (rb3.Checked) sql+="a.makp,";
				sql+="a.mabd,t.giamua";
				ins_items();
			}
			for(int i=1;i<=Convert.ToInt16(mm.Value);i++)
			{
				mmyy=i.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				if (d.bMmyy(mmyy))
				{
                    xxx = user + mmyy;
					if (rb3.Checked)
					{
						sql="select to_char(a.ngay,'dd/mm/yyyy') as ngay,a.ghichu,a.makp,b.mabd,b.soluong";
						sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+user+".d_dmnhom d,"+d.user+".d_dmkho e";
						sql+=" where a.id=b.id and b.mabd=c.id and c.manhom=d.id and b.makho=e.id and a.loai=3 and d.theodoi=1 and a.nhom="+i_nhom;
						if (s_nhom!="") sql+=" and c.manhom in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
						if (s_kho!="" && kho.Enabled) sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
						if (s_makp!="" && makp.Enabled) sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
					}
					else
					{
						sql="select to_char(a.ngay,'dd/mm/yyyy') as ngay,a.lydo as ghichu,0 as makp,b.mabd,b.soluong";
						sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+user+".d_dmnhom d,"+user+".d_dmkho e";
						sql+=" where a.id=b.id and b.mabd=c.id and c.manhom=d.id and a.khox=e.id and a.loai='XK' and a.khon<3 and d.theodoi=1 and a.nhom="+i_nhom;
						if (s_nhom!="") sql+=" and c.manhom in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
						if (s_kho!="" && kho.Enabled) sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
					}
					ins_items_ht();
				}
			}
		}

		private void ins_items_ht()
		{
			DataRow [] dr;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{
					sql="mabd="+int.Parse(r["mabd"].ToString());
					if (r["makp"].ToString()!="0") sql+=" and makp="+int.Parse(r["makp"].ToString());
					r2=d.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{
						r3=ds.Tables[0].NewRow();
						r3["tennhom"]=r1["tennhom"].ToString();
						r3["makp"]=r["makp"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r1["ma"].ToString();
						r3["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
						r3["dang"]=r1["dang"].ToString();
						r3["tennuoc"]=r1["tennuoc"].ToString();
						r3["namsd"]=0;
						r3["tyle"]=r1["tyle"].ToString();
						r3["soluong"]=r["soluong"].ToString();
						r3["giamua"]=0;
						r3["sotien"]=0;
						r3["sotienhm"]=0;
						r3["nam"]=0;
						r3["sl2"]=r["soluong"].ToString();
						r3["ngay2"]=r["ngay"].ToString();
						r3["lydo"]=r["ghichu"].ToString();
						if (r["makp"].ToString()=="0") r3["tenkp"]="";
						else
						{
							r4=d.getrowbyid(dtmakp,"id="+int.Parse(r["makp"].ToString()));
							if (r4!=null) r3["tenkp"]=r4["ten"].ToString();
							else r3["tenkp"]="";
						}
						ds.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							dr[0]["ngay2"]=r["ngay"].ToString();
							dr[0]["lydo"]=r["ghichu"].ToString();
							dr[0]["sl2"]=decimal.Parse(dr[0]["sl2"].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
						}
					}
				}
			}
		}

        private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void rb2_CheckedChanged(object sender, System.EventArgs e)
		{
			kho.Enabled=rb2.Checked;
			makp.Enabled=!rb2.Checked;
		}

		private void rb3_CheckedChanged(object sender, System.EventArgs e)
		{
			kho.Enabled=!rb3.Checked;
			makp.Enabled=rb3.Checked;
		}

		private void rb1_CheckedChanged(object sender, System.EventArgs e)
		{
			makp.Enabled=false;
			kho.Enabled=true;
		}
	}
}
