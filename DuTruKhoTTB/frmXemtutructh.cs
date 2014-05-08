using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibTTB;

namespace DuTruKhoTTB
{
	/// <summary>
	/// Summary description for frmXemton.
	/// </summary>
	public class frmXemtutructh : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private LibTTB.AccessData ttb = new LibTTB.AccessData();
		private int i_kho,i_makp,i_nhom,i_loai;
		private string s_mmyy,sql,format_soluong,s_tenkp,user,xxx;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butIn; 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemtutructh(int nhom,int kho,int makp,string mmyy,string tenkho,string tenkp,int loai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (ttb.bBogo) tv.GanBogo(this, textBox111);

            i_kho=kho;i_makp=makp;s_mmyy=mmyy;
			s_tenkp=tenkp;i_nhom=nhom;i_loai=loai;
			this.Text="Tồn "+tenkho.Trim()+" tổng hợp tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemtutructh));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 480);
            this.dataGrid1.TabIndex = 4;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::DuTruKhoTTB.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(431, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 3;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.Image = ((System.Drawing.Image)(resources.GetObject("butRef.Image")));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(291, 496);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(70, 25);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "&Refresh";
            this.butRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(8, 3);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(776, 20);
            this.tim.TabIndex = 0;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(361, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 2;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // frmXemtutructh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemtutructh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemtutructh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemtutructh_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = ttb.user; xxx = user + s_mmyy;
			format_soluong=ttb.format_soluong(i_nhom);
			load_grid();
			AddGridTableStyle();
		}

		private void load_grid()
		{
			sql="select c.ten as tennguon,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,a.tondau,a.slnhap,a.slxuat,a.tondau+a.slnhap-a.slxuat as toncuoi, d.ten as tenkho ";
            sql += " from " + xxx + ".ttb_tutructh a," + user + ".ttb_dmbd b," + user + ".ttb_dmnguon c," + user + ".ttb_dmkho d ";
            sql += " where a.mabd=b.id and a.manguon=c.id and a.makho=d.id and a.makp=" + i_makp;
            if (i_kho > 0) sql += "  and a.makho=" + i_kho + "";
            sql+=" order by d.ten, b.ten";
			dt=ttb.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
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
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (ttb.bQuanlynguon(i_nhom) || i_loai==2)?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (ttb.bHoatchat && i_loai==1)?200:270;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (ttb.bHoatchat && i_loai==1)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tondau";
			TextCol.HeaderText = "Tồn đầu";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slnhap";
			TextCol.HeaderText = "Nhập";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slxuat";
			TextCol.HeaderText = "Xuất";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "toncuoi";
			TextCol.HeaderText = "Tồn cuối";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkho";
            TextCol.HeaderText = "Kho";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbd like '%"+text.Trim()+"%' or tenhc like '%"+text.Trim()+"%' or ma like '%"+text.Trim()+"%'";
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			ttb.close();this.Close();
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			ttb.execute_data("delete from "+xxx+".ttb_tutrucct where tondau=0 and slnhap=0 and slxuat=0");
			ttb.execute_data("delete from "+xxx+".ttb_tutructh where tondau=0 and slnhap=0 and slxuat=0");
			load_grid();
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim) RefreshChildren(tim.Text);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			sql="select d.stt as manhom,d.ten as tennhom,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tenhang,a.tondau,a.slnhap,a.slxuat ";
			sql+=" from "+xxx+".ttb_tutructh a,"+user+".ttb_dmbd b,"+user+".ttb_dmhang c,"+user+".ttb_dmnhom d";
			sql+=" where a.mabd=b.id and b.mahang=c.id and b.manhom=d.id and a.makho="+i_kho+" and a.makp="+i_makp+" order by d.stt,b.ten";
			dllReportM.frmReport f1=new dllReportM.frmReport(m,ttb.get_data(sql).Tables[0],"d_cstt_khoa.rpt",s_tenkp,"Tháng "+s_mmyy.Substring(0,2)+" Năm 20"+s_mmyy.Substring(2),"","","","","","","","");
			f1.ShowDialog(this);
		}
	}
}
