using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptThekho.
	/// </summary>
	public class frmDmbdgiabh : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,itable,i_userid;
        private string user,mmyy;
        private bool bGiaban_noi_ngoai,bGiaban;
		private System.Data.DataTable dt=new System.Data.DataTable();
        private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
        private System.Windows.Forms.CheckBox chkupd_all;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmbdgiabh(AccessData acc,int nhom,string _mmyy,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; mmyy = _mmyy; i_userid = userid;            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbdgiabh));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.chkupd_all = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(362, 523);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(784, 511);
            this.dataGrid1.TabIndex = 23;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(5, 2);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(784, 21);
            this.tim.TabIndex = 1;
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(292, 523);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(222, 523);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 24;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkupd_all
            // 
            this.chkupd_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkupd_all.AutoSize = true;
            this.chkupd_all.Location = new System.Drawing.Point(498, 531);
            this.chkupd_all.Name = "chkupd_all";
            this.chkupd_all.Size = new System.Drawing.Size(293, 17);
            this.chkupd_all.TabIndex = 25;
            this.chkupd_all.Text = "Cập nhật giá BH cho những bệnh nhân chưa thanh toán";
            this.chkupd_all.UseVisualStyleBackColor = true;
            // 
            // frmDmbdgiabh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.chkupd_all);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmbdgiabh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật giá bảo hiểm quyết toán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmbdgiabh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmbdgiabh_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            itable = d.tableid("", "d_dmbd");
            bGiaban_noi_ngoai = d.bGiaban_noi_ngtru(i_nhom);
            user = d.user;
            f_capnhat_db();//
            if (!d.bGiaban_theodot(i_nhom))
                bGiaban = d.get_data("select * from " + user + ".d_doituong where loai=1").Tables[0].Rows.Count > 0;
			load_grid();
			AddGridTableStyle();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="ten like '%"+tim.Text.Trim()+"%' or ma like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) dataGrid1.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			dt.AcceptChanges();
            string asql = "", mm = "", yy = "", s_ngay = "";
            mm = DateTime.Now.AddMonths(-1).Month.ToString().PadLeft(2, '0');
            yy = DateTime.Now.AddMonths(-1).Year.ToString().Substring(2, 2);
            foreach (DataRow r in dt.Select("gia_bh<>gia_bhcu"))
            {
                d.upd_eve_tables(itable, i_userid, "upd");
                d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmbd", "id=" + decimal.Parse(r["id"].ToString())));
                d.execute_data("update " + user + ".d_dmbd set gia_bh=" + decimal.Parse(r["gia_bh"].ToString()) + ",ngayud=to_timestamp('" + d.Ngay_hethong_gio + "','dd/mm/yyyy hh24:mi') where id=" + decimal.Parse(r["id"].ToString()));
                //
                if (chkupd_all.Checked)
                {
                    asql = "update xxx.bhytthuoc set gia_bh=" + r["gia_bh"].ToString() + " where mabd=" + r["id"].ToString() + " and id in (select id from xxx.bhytkb where quyenso<>0 or sobienlai <>0 )";
                    d.execute_data_mmyy(asql, "01/" + mm + "/" + yy, s_ngay, true);
                }
            }
			Cursor=Cursors.Default;
			MessageBox.Show(lan.Change_language_MessageText("Đã cập nhật thành công !"),d.Msg);
		}

		private void load_grid()
		{
            string sql = "select a.ma,a.tenhc,trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,";
            sql += "trunc(a.gia_bh," + d.d_dongia_le(i_nhom).ToString("0#") + ") as gia_bh, trunc(a.gia_bh_novat," + d.d_dongia_le(i_nhom).ToString("0#") + ") as gia_bh_novat";
            sql += ",a.id,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.gia_bh as gia_bhcu,a.gia_bh as gia_bh_novatcu,d.ten as tennhom,e.ten as tennuoc, a.vat ";
            sql += ", a.gia_qd24, a.gia_qd24_novat, a.gia_qd24cu, a.gia_qd24_novatcu ";
            sql+=" from " + user + ".d_dmbd a," + user + ".d_dmhang c,"+user+".d_dmnhom d,"+user+".d_dmnuoc e";
            sql+=" where a.mahang=c.id and a.manhom=d.id and a.manuoc=e.id and a.nhom=" + i_nhom;
			sql+=" and a.bhyt<>0 order by ";
			if (d.bSort_mabd) sql+=" a.ma";
			else sql+=" a.ten";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenhc";
            TextCol.HeaderText = "Hoạt chất";
            TextCol.Width = 200;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 70;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 200;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 53;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            


            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "vat";
            TextCol.HeaderText = "VAT";
            TextCol.Width = 50;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_bh_novat";
            TextCol.HeaderText = "Giá chưa VAT";
            TextCol.Width = 75;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

    		TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "gia_bh";
			TextCol.HeaderText = "Gía bảo hiểm";
			TextCol.Width = 75;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_qd24_novat";
            TextCol.HeaderText = "Giá DV (QĐ24) chưa VAT";
            TextCol.Width = 75;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_qd24";
            TextCol.HeaderText = "Gía DV (QĐ24)";
            TextCol.Width = 75;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tennhom";
            TextCol.HeaderText = "Nhóm";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenhang";
            TextCol.HeaderText = "Hãng";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tennuoc";
            TextCol.HeaderText = "Nước";
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngayud";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
            string sql = "select a.ma,a.tenhc,trim(a.ten)||' '||a.hamluong as ten,a.dang as dvt,a.gia_bh from " + user + ".d_dmbd a," + user + ".d_dmnhom c where a.manhom=c.id and a.nhom=" + i_nhom + " and gia_bh>0 and bhyt<>0";
			sql+="order by ";
			if (d.bSort_mabd) sql+=" a.ma";
			else sql+=" a.ten";
			d.check_process_Excel();
			string tenfile=d.Export_Excel(d.get_data(sql),"dmthuoc");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlPortrait;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.LeftMargin=20;
			osheet.PageSetup.RightMargin=20;
			osheet.PageSetup.TopMargin=30;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";
			oxl.Visible=true;		
		}

        private void f_capnhat_db()
        {
            string asql = "";
            asql = "select vat, gia_bh_novat, gia_qd24,gia_qd24_novat from medibv.d_dmbd where 1=2";
            DataSet lds = d.get_data (asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table medibv.d_dmbd add vat numeric default 0";
                d.execute_data(asql);
                asql = "alter table medibv.d_dmbd add gia_bh_novat numeric default 0";
                d.execute_data(asql);
                asql = "alter table medibv.d_dmbd add gia_qd24_novat numeric default 0";
                d.execute_data(asql);
                asql = "alter table medibv.d_dmbd add gia_qd24 numeric default 0";
                d.execute_data(asql);
            }

        }
	}
}
