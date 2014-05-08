using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmTreoduyet.
	/// </summary>
	public class frmTreoduyet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d;
		private bool bCongdon,bThua,bTutrucchung,bSkip;
		private string s_makho,s_mmyy,xxx,user;
		private int i_makp,i_phieu,i_nhom,i_loai;
		private string s_ngay,s_phieu,sql,format_soluong;
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtph=new DataTable();
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.CheckedListBox phieudutru;
		private System.Windows.Forms.TextBox kp;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTreoduyet(LibDuoc.AccessData acc,DataTable tkp,int iNhom,int iMakp,int iLoai,int iPhieu,string ngay,bool congdon,bool thua,string makho,bool tutrucchung,string mmyy)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=iNhom;i_makp=iMakp;
			i_loai=iLoai;i_phieu=iPhieu;
			dtkp=tkp;bThua=thua;s_makho=makho;s_mmyy=mmyy;
			s_ngay=ngay;bCongdon=congdon;bTutrucchung=tutrucchung;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreoduyet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.butChon = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.ComboBox();
            this.phieudutru = new System.Windows.Forms.CheckedListBox();
            this.kp = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(134, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(57, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(169, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butChon
            // 
            this.butChon.Image = ((System.Drawing.Image)(resources.GetObject("butChon.Image")));
            this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.Location = new System.Drawing.Point(77, 432);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(72, 25);
            this.butChon.TabIndex = 7;
            this.butChon.Text = "     &Xem";
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(151, 432);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(88, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(160, 21);
            this.makp.TabIndex = 6;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // phieudutru
            // 
            this.phieudutru.CheckOnClick = true;
            this.phieudutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieudutru.Location = new System.Drawing.Point(57, 56);
            this.phieudutru.Name = "phieudutru";
            this.phieudutru.Size = new System.Drawing.Size(190, 372);
            this.phieudutru.TabIndex = 9;
            this.phieudutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kp
            // 
            this.kp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kp.Location = new System.Drawing.Point(57, 32);
            this.kp.Name = "kp";
            this.kp.Size = new System.Drawing.Size(30, 21);
            this.kp.TabIndex = 5;
            this.kp.Validated += new System.EventHandler(this.kp_Validated);
            this.kp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(256, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(528, 472);
            this.dataGrid1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lọc :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTreoduyet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.kp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phieudutru);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butChon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTreoduyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mặt hàng treo khi duyệt";
            this.Load += new System.EventHandler(this.frmTreoduyet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();return;
			}
			s_phieu="";
			if (phieudutru.CheckedItems.Count>0)
				for(int i=0;i<phieudutru.Items.Count;i++) 
					if (phieudutru.GetItemChecked(i)) s_phieu+=dtph.Rows[i]["id"].ToString().Trim()+",";
			i_makp=int.Parse(makp.SelectedValue.ToString());
            string stime = "'" + m.f_ngay + "'";
			sql=" select a.mabn,e.hoten,f.doituong,g.ten tenkho,d.ma,";
			sql+=" trim(d.ten)||' '||d.hamluong ten,d.tenhc,d.dang,b.slyeucau,b.slthuc,";
			sql+=" h.ten tennguon,d.hamluong";
			sql+=",i.ten as tennhom";
            sql += " from xxx.d_xtutrucll a," + user + ".d_treoduyet b,xxx.d_duyet c," + user + ".d_dmbd d," + user + ".btdbn e," + user + ".d_doituong f," + user + ".d_dmkho g," + user + ".d_dmnguon h," + user + ".d_dmnhom i";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and a.mabn=e.mabn and b.madoituong=f.madoituong and b.makho=g.id and b.manguon=h.id and d.manhom=i.id";
			sql+=" and c.done<>0 and b.slyeucau>b.slthuc and c.nhom="+i_nhom;
			sql+=" and a.maql<>0";
			if (bTutrucchung) sql+=" and c.makp="+i_makp;
			else sql+=" and c.makhoa="+i_makp;
			//sql+=" and to_date(c.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
            sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_phieu!="") sql+=" and c.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			sql+=" union all ";

			sql+=" select a.sophieu as mabn,f.doituong as hoten,f.doituong,g.ten tenkho,d.ma,";
			sql+=" trim(d.ten)||' '||d.hamluong ten,d.tenhc,d.dang,b.slyeucau,b.slthuc,";
			sql+=" h.ten tennguon,d.hamluong";
			sql+=",i.ten as tennhom";
            sql += " from xxx.d_haophill a," + user + ".d_treoduyet b,xxx.d_duyet c," + user + ".d_dmbd d," + user + ".d_doituong f," + user + ".d_dmkho g," + user + ".d_dmnguon h," + user + ".d_dmnhom i";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and b.madoituong=f.madoituong and b.makho=g.id and b.manguon=h.id and d.manhom=i.id";
			sql+=" and c.done<>0 and b.slyeucau>b.slthuc and c.nhom="+i_nhom;
			if (bTutrucchung) sql+=" and c.makp="+i_makp;
			else sql+=" and c.makhoa="+i_makp;
			//sql+=" and to_date(c.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
            sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_phieu!="") sql+=" and c.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			dt=d.get_data_mmyy(sql,tu.Text,den.Text,true).Tables[0];
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();System.GC.Collect();this.Close();
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void frmTreoduyet_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			format_soluong=d.format_soluong(i_nhom);
			if (bTutrucchung) label3.Text="Tủ trực :";
			load_ngay_duyet();

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=dtkp;
			makp.SelectedValue=i_makp.ToString();
			if (makp.Items.Count>0) kp.Text=dtkp.Rows[makp.SelectedIndex]["ma"].ToString();
			string sql="select * from "+user+".d_loaiphieu ";
			if (bThua) sql+=" where id=0";
			else
			{
				sql+=" where nhom="+i_nhom+" and loai="+i_loai;
				sql+=" and id<>0 order by stt";
			}
			dtph=d.get_data(sql).Tables[0];
			phieudutru.DisplayMember="TEN";
			phieudutru.ValueMember="ID";
			phieudutru.DataSource=dtph;			
			load_phieu();
		}

		private void load_phieu()
		{
			string s_phieuk = "", s_loai = "";
            sql = "select * from " + user + ".d_loaiphieu ";
			if (bThua) sql += " where id=0";
			else
			{
				s_phieuk = (makp.SelectedIndex != -1) ? dtkp.Rows[makp.SelectedIndex]["phieu"].ToString() : "";
				s_loai = (makp.SelectedIndex != -1) ? dtkp.Rows[makp.SelectedIndex]["loaiphieu"].ToString() : "";
				sql += " where nhom=" + i_nhom + " and loai=" + i_loai;
				if (s_phieuk.IndexOf(i_loai.ToString()) != -1 && s_loai != "") sql += " and id in (" + s_loai.Substring(0, s_loai.Length - 1) + ")";
				sql += " and id<>0 order by stt";
			}
			dtph = d.get_data(sql).Tables[0];
			phieudutru.DataSource = dtph;
			phieudutru.DisplayMember = "TEN";
			phieudutru.ValueMember = "ID";
		}

		private void chkNgay_Click(object sender, System.EventArgs e)
		{
			load_ngay_duyet();
		}
		private void load_ngay_duyet()
		{
			//Mac dinh lay ngay hien hanh, khi nao can moi Load lai nhung ngay chua duyet
			tu.Value=new DateTime(int.Parse(s_ngay.Substring(6,4)),int.Parse(s_ngay.Substring(3,2)),int.Parse(s_ngay.Substring(0,2)),0,0,0);
			den.Value=tu.Value;
		}

		private void kp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r=d.getrowbyid(dtkp,"ma='"+kp.Text+"'");
				if (r!=null) makp.SelectedValue=r["id"].ToString();
				else makp.SelectedIndex=-1;
			}
			catch{}
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp &&makp.SelectedIndex!=-1)
			{
				kp.Text=dtkp.Rows[makp.SelectedIndex]["ma"].ToString();
				load_phieu();
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
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=3;

			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = 90;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = "Kho";
			TextCol.Width = 90;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 170;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "slyeucau";
			TextCol.HeaderText = "Yêu cầu";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.Format = format_soluong;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "slthuc";
			TextCol.HeaderText = "Đã duyệt";
			TextCol.Width = 55;
			TextCol.Format = format_soluong;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
	}
}
