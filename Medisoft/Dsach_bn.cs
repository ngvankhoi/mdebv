using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibMedi;
using System.Data;

namespace Medisoft
{
	public class Dsach_bn : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		LibMedi.AccessData m = new LibMedi.AccessData();
		private DataSet ds=new DataSet();
		private string user,b_hoten="",b_namsinh="",b_mabn="", b_ten="";
		private System.Windows.Forms.Button butboqua;
		private System.Windows.Forms.Button butchon;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHoten;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtnamsinh;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtsont;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.DataGrid dtg;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmb;
		private System.ComponentModel.Container components = null;

		public Dsach_bn(string hoten,string namsinh)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);


//			b=acc;
			if(hoten!="")
			{
				b_hoten=hoten;
				int i=hoten.LastIndexOf(" ");
				b_ten=hoten.Substring(i+1);
				b_hoten=hoten.Substring(0,i);
				b_namsinh=namsinh;
				txtHoten.Text=b_hoten;
				txtTen.Text=b_ten;
				txtnamsinh.Text=namsinh;
			}
		}

//		public Dsach_bn(DataSet lds)
//		{
//			InitializeComponent();
//			ds=lds;
//			//
//		}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dsach_bn));
            this.butboqua = new System.Windows.Forms.Button();
            this.butchon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtnamsinh = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtsont = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.dtg = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // butboqua
            // 
            this.butboqua.BackColor = System.Drawing.Color.Transparent;
            this.butboqua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butboqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butboqua.Image = ((System.Drawing.Image)(resources.GetObject("butboqua.Image")));
            this.butboqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butboqua.Location = new System.Drawing.Point(329, 304);
            this.butboqua.Name = "butboqua";
            this.butboqua.Size = new System.Drawing.Size(70, 25);
            this.butboqua.TabIndex = 7;
            this.butboqua.Text = "Bỏ qua";
            this.butboqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butboqua.UseVisualStyleBackColor = false;
            this.butboqua.Click += new System.EventHandler(this.butboqua_Click);
            // 
            // butchon
            // 
            this.butchon.BackColor = System.Drawing.Color.Transparent;
            this.butchon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butchon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butchon.Image = ((System.Drawing.Image)(resources.GetObject("butchon.Image")));
            this.butchon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butchon.Location = new System.Drawing.Point(259, 304);
            this.butchon.Name = "butchon";
            this.butchon.Size = new System.Drawing.Size(70, 25);
            this.butchon.TabIndex = 6;
            this.butchon.Text = "     &Chọn";
            this.butchon.UseVisualStyleBackColor = false;
            this.butchon.Click += new System.EventHandler(this.butchon_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 513;
            this.label1.Text = "Họ, tên đệm ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(326, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 514;
            this.label2.Text = "Năm sinh ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoten
            // 
            this.txtHoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoten.Location = new System.Drawing.Point(78, 24);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(148, 21);
            this.txtHoten.TabIndex = 0;
            this.txtHoten.Validating += new System.ComponentModel.CancelEventHandler(this.txtHoten_Validating);
            this.txtHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoten_KeyDown);
            // 
            // txtnamsinh
            // 
            this.txtnamsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnamsinh.Location = new System.Drawing.Point(378, 24);
            this.txtnamsinh.Name = "txtnamsinh";
            this.txtnamsinh.Size = new System.Drawing.Size(36, 21);
            this.txtnamsinh.TabIndex = 2;
            this.txtnamsinh.Validated += new System.EventHandler(this.txtnamsinh_Validated);
            this.txtnamsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnamsinh_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(654, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "    Tìm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTen
            // 
            this.txtTen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(260, 24);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(64, 21);
            this.txtTen.TabIndex = 1;
            this.txtTen.Validating += new System.ComponentModel.CancelEventHandler(this.txtTen_Validating);
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(231, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 516;
            this.label3.Text = "Tên ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(399, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "Sửa Tên BN";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtsont
            // 
            this.txtsont.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtsont.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsont.ForeColor = System.Drawing.Color.Red;
            this.txtsont.Location = new System.Drawing.Point(576, 24);
            this.txtsont.Name = "txtsont";
            this.txtsont.Size = new System.Drawing.Size(72, 21);
            this.txtsont.TabIndex = 4;
            this.txtsont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsont.Validating += new System.ComponentModel.CancelEventHandler(this.txtsont_Validating);
            this.txtsont.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnamsinh_KeyDown);
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(505, 24);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(68, 23);
            this.label46.TabIndex = 530;
            this.label46.Text = "&Số lưu trữ ";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtg
            // 
            this.dtg.AllowSorting = false;
            this.dtg.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dtg.BackColor = System.Drawing.Color.White;
            this.dtg.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg.CaptionVisible = false;
            this.dtg.DataMember = "";
            this.dtg.FlatMode = true;
            this.dtg.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dtg.GridLineColor = System.Drawing.Color.RoyalBlue;
            this.dtg.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dtg.HeaderForeColor = System.Drawing.Color.Yellow;
            this.dtg.Location = new System.Drawing.Point(4, 59);
            this.dtg.Name = "dtg";
            this.dtg.ReadOnly = true;
            this.dtg.RowHeaderWidth = 20;
            this.dtg.SelectionBackColor = System.Drawing.Color.Red;
            this.dtg.SelectionForeColor = System.Drawing.Color.White;
            this.dtg.Size = new System.Drawing.Size(720, 232);
            this.dtg.TabIndex = 531;
            this.dtg.CurrentCellChanged += new System.EventHandler(this.dtg_CurrentCellChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(418, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 532;
            this.label4.Text = "Phái";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb
            // 
            this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cmb.Location = new System.Drawing.Point(448, 24);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(58, 21);
            this.cmb.TabIndex = 3;
            this.cmb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            // 
            // Dsach_bn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(728, 350);
            this.ControlBox = false;
            this.Controls.Add(this.cmb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtg);
            this.Controls.Add(this.txtsont);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtnamsinh);
            this.Controls.Add(this.txtHoten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butboqua);
            this.Controls.Add(this.butchon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dsach_bn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bệnh nhân";
            this.Load += new System.EventHandler(this.Dsach_bn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Dsach_bn_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			cmb.SelectedIndex=0;
			if(b_hoten.Length > 1 && b_namsinh.Length ==4)
			load_grid_();			
		}
		private void load_grid(string b_sonoitru)
		{
            string sql = "select a.mabn,a.hoten,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a," + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
			sql+=" where d.maphuongxa=a.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql and b.soluutru='"+b_sonoitru+"'";
            DataSet dss = m.get_data(sql);
			if(dss.Tables[0].Rows.Count >0)
			{
				dtg.DataSource=dss.Tables[0];
				LoadGridStyle(dss.Tables[0]);
			}
			else
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có dữ liệu"),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
				dtg.DataSource=null;
				return;
			}					

		}

		private void load_grid_ho_or_ten(string b_ho, string b_ten,int phai)
		{
			string ho = m.Hoten_khongdau(b_ho);
			string ten = m.Hoten_khongdau(b_ten);

			if(ten.Length !=0 )
			{
                string sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a, " + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
				sql+=" where a.phai="+phai+" and a.hotenkdau like '%"+ten+"' and d.maphuongxa=a.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql ";
				DataSet ds = m.get_data(sql);
				if(ds.Tables[0].Rows.Count >0)
				{
					dtg.DataSource=ds.Tables[0];
					LoadGridStyle(ds.Tables[0]);				
				}
				else
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có dữ liệu"),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					dtg.DataSource=null;
					return;
				}
			}
			else
			{
				if(ho.Length >0)
				{
                    string sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a, " + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
					sql+=" where a.phai="+phai+" and a.hotenkdau like '"+ho+"%' and d.maphuongxa=a.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql";
					DataSet ds = m.get_data(sql);
					if(ds.Tables[0].Rows.Count > 0)
					{
						dtg.DataSource=ds.Tables[0];
						LoadGridStyle(ds.Tables[0]);				
					}
					else
					{
						MessageBox.Show(lan.Change_language_MessageText("Không có dữ liệu"),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
						dtg.DataSource=null;
						return;
					}		
				}
			}

		}

		private void load_gridhoten(string b_ho, string b_ten,int phai, string namsinh,string b_sonoitru)
		{			
			string ho =(b_ho!="")?m.Hoten_khongdau(b_ho):"";
			string ten =(b_ten!="")?m.Hoten_khongdau(b_ten):"";

            string sql = "select a.mabn,a.hoten,to_char(a.ngaysinh,'dd/mm/yyyy') as ngaysinh,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a, " + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
			sql+=" where a.maphuongxa=d.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql and a.phai = "+phai+"";
			if(namsinh!="")sql+=" and namsinh='"+namsinh+"'";
			if(ho!="")sql+=" and hotenkdau like '"+ho+"%'";
			if(ten!="")sql+=" and hotenkdau like '%"+ten+"'";
			if(b_sonoitru!="")sql+=" and b.soluutru='"+b_sonoitru+"'";
			DataSet ds = m.get_data(sql);
			if(ds.Tables[0].Rows.Count >0)
			{
				dtg.DataSource=ds.Tables[0];
				LoadGridStyle(ds.Tables[0]);				
			}
			else
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có dữ liệu"),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
				dtg.DataSource=null;
				return;
			}					
		}					

		private void LoadGridStyle(DataTable tbb)
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName= tbb.TableName.ToString();

			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;
			tbs.RowHeaderWidth=10;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="MABN";
			c0.HeaderText="Mã BN";
			c0.Width=60;
			c0.NullText="";
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="HOTEN";
			c1.HeaderText="Tên B.Nhân";
			c1.NullText="";
			c1.Width=138;
			tbs.GridColumnStyles.Add(c1);			

			DataGridTextBoxColumn c2=new DataGridTextBoxColumn();
			c2.MappingName="Ngaysinh";
			c2.HeaderText="Năm Sinh";
			c2.NullText="";
			c2.Width=75;
			tbs.GridColumnStyles.Add(c2);

			DataGridTextBoxColumn c3=new DataGridTextBoxColumn();
			c3.MappingName="NAMSINH";
			c3.HeaderText="N.Sinh";
			c3.NullText="";
			c3.Width=50;
			tbs.GridColumnStyles.Add(c3);

			DataGridTextBoxColumn c4=new DataGridTextBoxColumn();
			c4.MappingName="DIACHI";
			c4.HeaderText="Địa Chỉ";
			c4.NullText="";
			c4.Width=280;
			tbs.GridColumnStyles.Add(c4);

			DataGridTextBoxColumn c5=new DataGridTextBoxColumn();
			c5.MappingName="SOLUUTRU";
			c5.HeaderText="Số lưu trữ";
			c5.NullText="";
			c5.Width=65;
			tbs.GridColumnStyles.Add(c5);
            
			dtg.TableStyles.Clear();
			dtg.TableStyles.Add(tbs);
		}		

		private void ref_text()
		{
			try
			{
				BindingManagerBase bm;
				bm=BindingContext[ds,"btdbn"];
				if (bm.Position>-1)
				{
					b_mabn=ds.Tables[0].Rows[bm.Position][0].ToString();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		
		private void butboqua_Click(object sender, System.EventArgs e)
		{
			b_mabn="";
			m.close();this.Close();			
		}

		private void butchon_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();	
		}

//		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
//		{
//
//		}

		private void txtHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void txtnamsinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}{f4}");
			}
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			if(txtsont.Text.Trim() !="")// tim theo so luu tru
				load_grid(txtsont.Text.Trim());
			else
			{
				if(txtnamsinh.TextLength >0 && txtHoten.Text=="" && txtTen.Text=="" && txtsont.Text=="")
				{ // tim theo nam sinh
					loadgridnamsinh(txtnamsinh.Text.Trim(),int.Parse(cmb.SelectedIndex.ToString()));
				}
				else
				{
					if(txtHoten.Text!="" && txtTen.Text!=""&& txtnamsinh.TextLength>4)
					{// tim theo ho ten va nam sinh 
						loadgridhotennamsinh(txtHoten.Text.Trim()+txtTen.Text.Trim(),txtnamsinh.Text.ToString(),int.Parse(cmb.SelectedIndex.ToString()));
					}
					else
					{//ho hoac ten + nam sinh
						if((txtHoten.Text!="" || txtTen.Text!="") && txtnamsinh.TextLength >0)
						{
							//load_gridhoten(txtHoten.Text.Trim(),txtTen.Text.Trim(),int.Parse(cmb.SelectedIndex.ToString()),txtnamsinh.Text.ToString());
						}
						else
						{
							if((txtHoten.Text!="" || txtTen.Text!="") && txtnamsinh.TextLength ==0)
							{
								load_grid_ho_or_ten(txtHoten.Text.ToString(),txtTen.Text.ToString(),int.Parse(cmb.SelectedIndex.ToString()));
							}
							else
							{
								MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập Họ tên Bệnh nhân cần tìm vào."),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);		
								dtg.DataSource=null;
								return;
							}
						}
					}
				}
			}
		}

		private void txtHoten_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(txtHoten.Text.Trim()!="")
				txtHoten.Text=m.Caps(txtHoten.Text.ToString());
		}

		private void txtTen_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(txtTen.Text.Trim()!="")txtTen.Text=m.Caps(txtTen.Text.ToString());			
		}

		private void txtTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)SendKeys.Send("{Tab}");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			frmSuahc ff=new frmSuahc(m,"",0,m.bSoluutru_nhapvien,"");
			ff.Show();
		}

		private void txtsont_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(txtsont.Text.Trim()!="") txtsont.Text=txtsont.Text.PadLeft(8,'0');
		}				

		public string Mabn
		{
			get
			{
				return b_mabn; 
			}
		}

		public string Hotenbn
		{
			get
			{
				return b_hoten.Trim();
			}
		}

		#region phamductien

		private void load_grid_()
		{
			if(b_hoten.Trim()+b_ten.Trim()!="")
			{
				string hoten = m.Hoten_khongdau(b_hoten.Trim()+" "+b_ten.Trim());
                string sql = "select a.mabn,a.hoten,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a, " + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
				sql+=" where d.maphuongxa=a.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql and a.hotenkdau='"+hoten+"'";
				DataTable tb = m.get_data(sql).Tables[0];
				if(tb.Rows.Count >0)
				{
					dtg.DataSource = tb;
					LoadGridStyle(tb);
				}
				else
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có dữ liệu"),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					dtg.DataSource=null;
					return;
				}
			}
		
		}

		private void loadgridnamsinh(string birthyear, int phai)
		{
            string sql = "select a.mabn,a.hoten,a.ngaysinh,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a, " + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
			sql+=" where a.namsinh='"+birthyear+"' and a.phai="+phai+" and d.maphuongxa=a.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql";
			DataSet dts = m.get_data(sql);
			dtg.DataSource = dts.Tables[0];
			LoadGridStyle(dts.Tables[0]);
		}

		private void loadgridhotennamsinh(string name,string namsinh,int phai)
		{
			string hoten = m.Hoten_khongdau(name);
            string sql = "select a.mabn,a.hoten,a.ngaysinh,a.namsinh,a.thon||' - '||d.tenpxa||' - '||e.tenquan||' - '||f.tentt as diachi , b.soluutru from " + user + ".btdbn a, " + user + ".lienhe b, " + user + ".benhandt c, " + user + ".btdpxa d," + user + ".btdquan e," + user + ".btdtt f";
			sql+=" where d.maphuongxa=a.maphuongxa and a.maqu=e.maqu and a.matt=f.matt and a.mabn=c.mabn and c.maql=b.maql and a.namsinh='"+namsinh+"' and a.phai="+phai+" and a.hotenkdau='"+hoten+"'";
			DataTable tb = m.get_data(sql).Tables[0];
			if(tb.Rows.Count >0)
			{
				dtg.DataSource = tb;
				LoadGridStyle(tb);
			}
			else
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có dữ liệu"),lan.Change_language_MessageText("Thông Báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
				dtg.DataSource=null;
				return;
			}
		}
		#endregion

		private void txtnamsinh_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if(txtnamsinh.Text !="")
				{
					int a = int.Parse(txtnamsinh.Text.ToString());
				}				
			}
			catch
			{
				txtnamsinh.Focus();
				return;
			}
		}

		private void dtg_CurrentCellChanged(object sender, System.EventArgs e)
		{
			b_mabn =dtg[dtg.CurrentCell.RowNumber,0].ToString();
            b_hoten=dtg[dtg.CurrentCell.RowNumber,1].ToString();			
		}

		private void cmb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)		
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			load_gridhoten(txtHoten.Text,txtTen.Text,cmb.SelectedIndex,txtnamsinh.Text,txtsont.Text);
		}

	}
}
