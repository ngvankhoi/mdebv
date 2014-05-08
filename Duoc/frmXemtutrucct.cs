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
	/// Summary description for frmXemton.
	/// </summary>
	public class frmXemtutrucct : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_kho, i_makp, i_nhom, d_userid = 0;
		private bool bGiaban;
		private string s_mmyy,sql,format_sotien,format_soluong,format_dongia,s_tenkp,user;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butIn;
        private CheckBox chkChitiet; 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemtutrucct(AccessData acc,int kho,int makp,string mmyy,string tenkho,bool b_giaban,int nhom,string tenkp, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_kho=kho;
			i_makp=makp;
			i_nhom=nhom;
			s_mmyy=mmyy;
			bGiaban=b_giaban;s_tenkp=tenkp;
            d_userid = _userid;
			this.Text="Tồn "+tenkho.Trim()+" chi tiết tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemtutrucct));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.chkChitiet = new System.Windows.Forms.CheckBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 4);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 478);
            this.dataGrid1.TabIndex = 0;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(444, 500);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(304, 500);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(70, 25);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "&Refresh";
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(8, 1);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(776, 20);
            this.tim.TabIndex = 7;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(374, 500);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 8;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkChitiet
            // 
            this.chkChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChitiet.AutoSize = true;
            this.chkChitiet.Location = new System.Drawing.Point(704, 500);
            this.chkChitiet.Name = "chkChitiet";
            this.chkChitiet.Size = new System.Drawing.Size(69, 17);
            this.chkChitiet.TabIndex = 9;
            this.chkChitiet.Text = "In chi tiết";
            this.chkChitiet.UseVisualStyleBackColor = true;
            // 
            // frmXemtutrucct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkChitiet);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemtutrucct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemtutrucct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemtutrucct_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
            d.kiemtra_cstt_nhap(s_mmyy,i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			load_grid();
			AddGridTableStyle();
		}

		private void load_grid()
		{
			sql="select c.ten as tennguon,d.ten as tennhomcc,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,e.handung,nullif(e.losx,' ') as losx,a.tondau,a.tondau*e.giamua as sttondau,a.slnhap,a.slnhap*e.giamua as stnhap,a.slxuat,a.slxuat*e.giamua as stxuat,a.tondau+a.slnhap-a.slxuat as toncuoi,a.tondau*e.giamua+a.slnhap*e.giamua-a.slxuat*e.giamua as sttoncuoi,e.giaban,e.giamua ";
            sql += ", f.ten tenkho";
            sql += " from " + user + s_mmyy + ".d_tutrucct a inner join " + user + s_mmyy + ".d_theodoi e on a.stt=e.id inner join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmnguon c on e.manguon=c.id left join " + user + ".d_dmnx d on e.nhomcc=d.id  ";
            sql += " inner join " + user + ".d_dmkho f on a.makho=f.id ";
            sql += " where  a.makp=" + i_makp;
            if (i_kho != 0) sql += " and a.makho=" + i_kho;            
            if (d.bNhaptruocxuat(i_nhom)) sql += " order by a.stt";
            else sql += " order by substring(e.handung,3,2),substring(e.handung,1,2),a.stt";
			dt=d.get_data(sql).Tables[0];
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
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
			TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?90:0;
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
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giamua";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tondau";
			TextCol.HeaderText = "Tồn đầu";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sttondau";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slnhap";
			TextCol.HeaderText = "Nhập";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stnhap";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slxuat";
			TextCol.HeaderText = "Xuất";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stxuat";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "toncuoi";
			TextCol.HeaderText = "Tồn cuối";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sttoncuoi";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?70:0;
			TextCol.Format="###,###,###,##0";
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
                if (text == "Tìm kiếm")
                {
                    return;
                }
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbd like '%"+text.Trim()+"%' or tenhc like '%"+text.Trim()+"%' or ma like '%"+text.Trim()+"%'";
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			d.execute_data("delete from "+user+s_mmyy+".d_tutrucct where tondau=0 and slnhap=0 and slxuat=0");
            d.execute_data("delete from " + user + s_mmyy + ".d_tutructh where tondau=0 and slnhap=0 and slxuat=0");
			d.upd_tonkho(s_mmyy,i_nhom,2);
			load_grid();
            try
            {
                RefreshChildren(tim.Text);
            }
            catch { }
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
            //
            sql = "select g.stt as manhom,g.ten as tennhom, c.ten as tennguon,d.ten as tennhomcc,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.handung,nullif(e.losx,' ') as losx,a.tondau,a.tondau*e.giamua as sttondau,a.slnhap,a.slnhap*e.giamua as stnhap,a.slxuat,a.slxuat*e.giamua as stxuat,a.tondau+a.slnhap-a.slxuat as toncuoi,a.tondau*e.giamua+a.slnhap*e.giamua-a.slxuat*e.giamua as sttoncuoi,e.giaban,e.giamua ";
            sql += ", f.ten tenkho, h.ten as tenhang,u.ten as nuocsx ";
            sql += " from " + user + s_mmyy + ".d_tutrucct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + s_mmyy + ".d_theodoi e";
            sql += ", " + user + ".d_dmkho f, " + user + ".d_dmnhom g, " + user + ".d_dmhang h,"+user+".d_dmnuoc u ";
            sql += " where a.stt=e.id and a.mabd=b.id and e.manguon=c.id and a.makho=f.id  and e.nhomcc=d.id and b.manhom=g.id and b.mahang=h.id(+) and b.manuoc=u.id(+) ";
            sql += " and a.makp=" + i_makp;
            if (i_kho != 0) sql += " and a.makho=" + i_kho;
            if (d.bNhaptruocxuat(i_nhom)) sql += " order by a.stt";
            else sql += " order by g.stt,substring(e.handung,3,2),substring(e.handung,1,2),a.stt";

            DataSet lds = new DataSet();
            lds = d.get_data(sql);
            try
            {                
                //lds.Tables.Add(dv.Table.Copy());
                
                if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                lds.WriteXml("..\\..\\dataxml\\tutrucct.xml", XmlWriteMode.WriteSchema);
            }
            catch { }
            string tmp_rpt = "d_cstt_khoa.rpt";
            if (chkChitiet.Checked)
            {
                tmp_rpt = tmp_rpt.Replace(".rpt", "") + "_ct.rpt";
            }
            
            //
            //sql = "select d.stt as manhom,d.ten as tennhom,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tenhang,a.tondau,a.slnhap,a.slxuat ";
            //sql += " from " + user + s_mmyy + ".d_tutructh a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnhom d";
            //sql += " where a.mabd=b.id and b.mahang=c.id and b.manhom=d.id and a.makho=" + i_kho + " and a.makp=" + i_makp + " order by d.stt,b.ten";
            frmReport f1 = new frmReport(d, lds.Tables[0], d_userid, tmp_rpt, s_tenkp, "Tháng " + s_mmyy.Substring(0, 2) + " Năm 20" + s_mmyy.Substring(2), "", "", "", "", "", "", "", "");
            f1.ShowDialog(this);
		}
	}
}
