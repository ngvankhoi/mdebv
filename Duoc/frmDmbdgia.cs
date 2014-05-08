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
	public class frmDmbdgia : System.Windows.Forms.Form
	{
        //linh
        int i_sole = 0;
        int irow = 0;
        //end
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;private bool bvattuyte = false;
		private int i_nhom,itable,i_userid;
        private string user,mmyy;
        private bool bGiaban_noi_ngoai,bGiaban, bGiaban_dotnhap=false ;
		private System.Data.DataTable dt=new System.Data.DataTable();
        private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		Excel.Application oxl;
		Excel._Workbook owb;
        Excel._Worksheet osheet;
        private System.Windows.Forms.CheckBox chkBHYTChiTra;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmbdgia(AccessData acc,int nhom,string _mmyy,int userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmbdgia));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.chkBHYTChiTra = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(717, 529);
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
            this.dataGrid1.Size = new System.Drawing.Size(784, 517);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
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
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(647, 529);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(577, 529);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 24;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkBHYTChiTra
            // 
            this.chkBHYTChiTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBHYTChiTra.AutoSize = true;
            this.chkBHYTChiTra.Location = new System.Drawing.Point(5, 537);
            this.chkBHYTChiTra.Name = "chkBHYTChiTra";
            this.chkBHYTChiTra.Size = new System.Drawing.Size(176, 17);
            this.chkBHYTChiTra.TabIndex = 25;
            this.chkBHYTChiTra.Text = "Danh sách Thuốc BHYT chi trả";
            this.chkBHYTChiTra.UseVisualStyleBackColor = true;
            this.chkBHYTChiTra.CheckedChanged += new System.EventHandler(this.chkBHYTChiTra_CheckedChanged);
            // 
            // frmDmbdgia
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.chkBHYTChiTra);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDmbdgia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật giá";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDmbdgia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        DataSet dstyleban = new DataSet();
		private void frmDmbdgia_Load(object sender, System.EventArgs e)
		{
            //linh
            i_sole = d.d_dongia_le(i_nhom);
            user = d.user;
            dstyleban = d.get_data("select * from " + user + ".dmtyleban");
            //end
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bGiaban_dotnhap = d.bGiaban_theodot(i_nhom);
            itable = d.tableid("", "d_dmbd");
            bGiaban_noi_ngoai = d.bGiaban_noi_ngtru(i_nhom);
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
            try
            {
                System.Data.DataTable dttmp = dt.GetChanges();
                int i_vat = 0;
                foreach (DataRow r in dttmp.Rows)
                {
                    d.upd_eve_tables(itable, i_userid, "upd");
                    d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_dmbd", "id=" + decimal.Parse(r["id"].ToString())));
                    if (r["vat"].ToString() != "")
                    {
                        i_vat = int.Parse(r["vat"].ToString());
                    }
                    else
                    {
                        i_vat = 0;
                    }
                    string s_sql = "update " + user + ".d_dmbd set giaban=" + decimal.Parse(r["giaban_vat"].ToString()) + "," +//Sua giaban =>giaban_vat : aLinh noi gia ban trong d_dmbd la gia da co vat roi
                        "vat=" + i_vat + "," + "dongia=" + decimal.Parse(r["giamua"].ToString()) + "," +
                        "gia_bh=" + decimal.Parse(r["gia_bh"].ToString()) + ",gia_phuthu=" + decimal.Parse(r["gia_phuthu"].ToString())+
                    ",gia_bh_novat=" + decimal.Parse(r["gia_bh_novat"].ToString()) + "";
                    if (bGiaban_noi_ngoai)
                    {
                        s_sql += ",giaban2=" + decimal.Parse(r["giaban2"].ToString());
                    }
                    else
                    {
                        s_sql += ",giaban2=giaban";
                    }
                    //s_sql += ",ngayud=now(),gia_cucduoc=" + decimal.Parse(r["gia_cucduoc"].ToString()).ToString() + " where id=" + decimal.Parse(r["id"].ToString());//Thuy 30.01.2013 ko update ngayud=>A Binh yêu cầu
                    s_sql += ",gia_cucduoc=" + decimal.Parse(r["gia_cucduoc"].ToString()).ToString() + " where id=" + decimal.Parse(r["id"].ToString());//Thuy 30.01.2013 ko update ngayud=>A Binh yêu cầu
                    d.execute_data(s_sql);
                }
            }
            catch(Exception ex)
            {
            }
			Cursor=Cursors.Default;
			MessageBox.Show(lan.Change_language_MessageText("Đã cập nhật thành công !"),d.Msg);
		}

		private void load_grid()
		{
            string sql = "select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,a.vat,";
            sql += "round(a.dongia/(1+a.vat/100)," + i_sole.ToString() + ") as giamua,round(dongia," + i_sole.ToString() + ") as giamua_vat,"; 
            //sql += "round(gia_bh_novat," + i_sole.ToString() + ") as gia_bh,(round(gia_bh," + i_sole.ToString() + ")*vat/100 + gia_bh) as gia_bh_vat,";
            sql += "round(gia_bh_novat," + i_sole.ToString() + ") as gia_bh_novat,(round(gia_bh," + i_sole.ToString() + ")) as gia_bh,";
            sql += "round(gia_phuthu," + i_sole.ToString() + ") as gia_phuthu,(round(gia_phuthu," + i_sole.ToString() + ")*vat/100 + gia_phuthu) as gia_phuthu_vat,";
            sql += "round(a.giaban," + i_sole.ToString() + ") as giaban_vat,(round(a.giaban,0)*100)/(vat+100) as giaban,";//(a.giaban - round(a.giaban," + i_sole.ToString() + ")*vat/100) as giaban,";
            sql += "round(a.giaban2," + i_sole.ToString() + ") as giaban2,";
            sql += "to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.giaban as giabancu, ";
            sql += "a.giaban2 as giabancu2 , 0 as sttt, 0 as slton,a.gia_cucduoc,a.vtyt";
            sql += " from " + user + ".d_dmbd a, " + user + ".d_dmhang c ";
            sql += " where a.mahang=c.id and a.nhom=" + i_nhom;
            //Thuy 24.02.2012
            if (chkBHYTChiTra.Checked)
            {
                sql += " and a.bhyt>0 ";
            }
            sql += " order by a.ten";
			
			dt=d.get_data(sql).Tables[0];
			dataGrid1.SetDataBinding(dt,dt.Namespace);//.DataSource=dt;
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
            TextCol.TextBox.Name= "id";
            TextCol.TextBox.Tag = "0";
			ts.GridColumnStyles.Add(TextCol);//0
			

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 70;
			TextCol.ReadOnly=true;
            TextCol.TextBox.Name = "ma";
            TextCol.TextBox.Tag = "1";
            ts.GridColumnStyles.Add(TextCol);//1
			

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
            TextCol.Width = 200;// -((bGiaban_noi_ngoai) ? 75 : 0);
			TextCol.ReadOnly=true;
            TextCol.TextBox.Name = "ten";
            TextCol.TextBox.Tag = "2";
            ts.GridColumnStyles.Add(TextCol);//2
			

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 53;
			TextCol.ReadOnly=true;
            TextCol.TextBox.Name = "dang";
            TextCol.TextBox.Tag = "3";
            ts.GridColumnStyles.Add(TextCol);//3
			

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
            TextCol.TextBox.Name = "tenhang";
            TextCol.TextBox.Tag = "4";
            ts.GridColumnStyles.Add(TextCol);//4

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vat";
			TextCol.HeaderText = "VAT";
			TextCol.Width = 30;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###";
			TextCol.ReadOnly=false;
            TextCol.TextBox.Name = "vat";
            TextCol.TextBox.Tag = "5";
            TextCol.NullText = "0.0";
            TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            ts.GridColumnStyles.Add(TextCol);//5

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giamua";
            TextCol.HeaderText = "Giá mua chưa VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = false;
            TextCol.TextBox.Name = "giamua";
            TextCol.TextBox.Tag = "6";
            TextCol.NullText = "0.0";
            TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            ts.GridColumnStyles.Add(TextCol);//6

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giamua_vat";
            TextCol.HeaderText = "Giá mua có VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.TextBox.Tag = "7";
            TextCol.TextBox.Name = "giamua_vat";
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = true;
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);//7

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_bh_novat";
            TextCol.HeaderText = "Giá BHYT chưa VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = false;
            TextCol.TextBox.Name = "gia_bh_novat";
            TextCol.TextBox.Tag = "8";
            TextCol.NullText = "0.0";
            TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            ts.GridColumnStyles.Add(TextCol);//8

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_bh";
            TextCol.HeaderText = "Giá BHYT có VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.TextBox.Name = "gia_bh";
            TextCol.TextBox.Tag = "9";
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = true;
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);//9

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giaban";
            TextCol.HeaderText = (bGiaban_noi_ngoai) ? "Giá bán nội trú" : "Giá bán chưa VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = false;
            TextCol.TextBox.Tag = "10";
            TextCol.TextBox.Name = "giaban";
            TextCol.NullText = "0.0";
            TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            TextCol.TextBox.Validated += new System.EventHandler(this.Textbox_Validated);
            ts.GridColumnStyles.Add(TextCol);//10

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giaban_vat";
            TextCol.HeaderText = (bGiaban_noi_ngoai) ? "Giá bán nội trú" : "Giá bán có VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = true;
            TextCol.TextBox.Tag = "11";
            TextCol.TextBox.Name = "giaban_vat";
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);//11

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giaban2";
            TextCol.HeaderText = (bGiaban_noi_ngoai)?"Giá bán ngoại trú":"";
            TextCol.Width = (bGiaban_noi_ngoai) ? 120 : 0;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###";
            TextCol.ReadOnly = bGiaban_noi_ngoai ? false : true;
            TextCol.TextBox.Tag = "12";
            TextCol.TextBox.Name = "giaban2";
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_phuthu";
            TextCol.HeaderText = "Giá phụ thu chưa VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = false;
            TextCol.TextBox.Name = "gia_phuthu";
            TextCol.TextBox.Tag = "13";
            TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_phuthu_vat";
            TextCol.HeaderText = "Giá phụ thu có VAT";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.TextBox.Name = "gia_phuthu_vat";
            TextCol.TextBox.Tag = "14";
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = true;
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);
            //gia_cucduoc

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_cucduoc";
            TextCol.HeaderText = "Giá Cục Dược";
            TextCol.Width = 120;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.TextBox.Name = "gia_cucduoc";
            TextCol.TextBox.Tag = "15";
            TextCol.TextBox.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
            TextCol.Format = "###,###,###,###." + "#".PadLeft(i_sole, '#');
            TextCol.ReadOnly = false;
            TextCol.NullText = "0.0";
            ts.GridColumnStyles.Add(TextCol);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngayud";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
            TextCol.TextBox.Tag = "16";
            TextCol.TextBox.Name = "ngayud";
            ts.GridColumnStyles.Add(TextCol);

            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "slton";
            //TextCol.HeaderText = (bGiaban_dotnhap) ? "Tồn cuối" : "";
            //TextCol.Width = (bGiaban_dotnhap) ? 100 : 0;
            //TextCol.ReadOnly = true;
            //ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
            string sql = "select a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang as dvt,a.giaban,a.giaban2 from ";
            sql += ""+ user + ".d_dmbd a," + user + ".d_dmnhom c where a.manhom=c.id and a.nhom=" + i_nhom + " ";
            //Thuy 24.02.2012
            if(chkBHYTChiTra.Checked)
            {
                sql += " and a.bhyt > 0 ";
            }
			sql+=" and a.giaban>0 order by ";
			if (d.bSort_mabd) sql+=" a.ma";
			else sql+=" a.ten";
			d.check_process_Excel();
			string tenfile=d.Export_Excel(dt,"dmthuoc");
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
        string active = "";
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            irow = dataGrid1.CurrentRowIndex; 
            decimal d_idbd = 0;
            try
            {
                d_idbd = (dataGrid1[i_cur, 0].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_cur, 0].ToString());
            }
            catch { d_idbd = 0; }
            DataRow dr1 = d.getrowbyid(dt, "id='" + d_idbd + "'");
            if (dr1 != null)
            {
                bvattuyte = dr1["vtyt"].ToString() == "1";
            }
            if (dataGrid1.CurrentCell.ColumnNumber == 6 && active=="giamua" && irow==i_cur)
            {
                active = "text";
                if (dstyleban.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        decimal d_tmp = decimal.Parse(dataGrid1[i_cur, dataGrid1.CurrentCell.ColumnNumber].ToString());
                        //DataRow[] dr = dstyleban.Tables[0].Select("tu<=" + d_tmp.ToString() + " and den>=" + d_tmp.ToString());
                        DataRow[] dr = dstyleban.Tables[0].Select("tu<=" + d_tmp.ToString() + " and den>=" + d_tmp.ToString() + " and vattu=" + (bvattuyte ? "1" : "0"));
                        decimal i_tyle = 0;
                        if (dr.Length > 0)
                        {
                            i_tyle = decimal.Parse(dr[0]["tyle"].ToString());
                            decimal d_giaban = d_tmp * i_tyle / 100 + d_tmp;
                            dataGrid1[i_cur, 10] = d_giaban;
                            int i_vat = int.Parse(dataGrid1[i_cur, 5].ToString());
                            decimal d_giaban_vat = d_giaban * i_vat / 100 + d_giaban;
                            dataGrid1[i_cur, 11] = d_giaban_vat;
                        }
                    }
                    catch { }
                }
            }
            else if (dataGrid1.CurrentCell.ColumnNumber == 10 && active=="giaban")
            {
                active = "text";
                try
                {
                    decimal d_tmp = decimal.Parse(dataGrid1[i_cur, dataGrid1.CurrentCell.ColumnNumber].ToString());
                    decimal d_giamua = decimal.Parse(dataGrid1[i_cur, 6].ToString());
                    int icur = i_cur;
                    i_cur = irow;
                    if (d_tmp < d_giamua)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Giá bán phải lớn hơn giá mua"), "Medisoft");
                        dataGrid1[icur, dataGrid1.CurrentCell.ColumnNumber] = d_giamua;
                        int i_vat = int.Parse(dataGrid1[icur, 5].ToString());
                        decimal d_giabanvat = d_giamua * ((decimal)i_vat / 100) + d_giamua;
                        dataGrid1[icur, 11] = d_giabanvat;
                        dataGrid1.CurrentCell = (DataGridCell)dataGrid1[icur, 10];// new DataGridCell(icur, 10);
                    }
                }
                catch { }
            }
        }
        int i_cur = 0;
        void Textbox_TextChanged(object sender, EventArgs e)
        {
            active = "text";
            System.Windows.Forms.TextBox text=(System.Windows.Forms.TextBox)sender;
            text.Refresh();
            if (ActiveControl == text)
            {
                i_cur = irow;
                try
                {
                    decimal d_tmp = decimal.Parse(text.Text);
                    if (text.Name.ToLower() == "vat")
                    {
                        decimal d_giamua = 1;
                        try
                        {
                            d_giamua = decimal.Parse(dataGrid1[irow, 6].ToString());
                        }
                        catch { d_giamua = 1; }
                        decimal d_giamua_vat = (d_giamua * d_tmp / 100) + d_giamua;
                        dataGrid1[irow, 7] = d_giamua_vat;
                        decimal d_giabh = 1;
                        try
                        {
                            d_giabh = decimal.Parse(dataGrid1[irow, 8].ToString());
                        }
                        catch { d_giabh = 1; }
                        decimal d_giabh_vat = (d_giabh * d_tmp / 100) + d_giabh;
                        dataGrid1[irow, 9] = d_giabh_vat;
                        decimal d_giaban = 1;
                        try
                        {
                            d_giaban = decimal.Parse(dataGrid1[irow, 10].ToString());
                        }
                        catch { d_giaban = 1; }
                        decimal d_giaban_vat = (d_giaban * d_tmp / 100) + d_giaban;
                        dataGrid1[irow, 11] = d_giaban_vat;
                        decimal d_giaphuthu = 1;
                        try
                        {
                            d_giaphuthu = decimal.Parse(dataGrid1[irow, 13].ToString());
                        }
                        catch { d_giaphuthu = 1; }
                        decimal d_giaphuthu_vat = (d_giaphuthu * d_tmp / 100) + d_giaphuthu;
                        dataGrid1[irow, 14] = d_giaphuthu_vat;
                    }
                    else
                    {
                        int i_vat = 0;
                        try
                        {
                            i_vat = int.Parse(dataGrid1[irow, 5].ToString());
                        }
                        catch { i_vat = 0; }
                        decimal d_gia_vat = (d_tmp * i_vat / 100) + d_tmp;
                        if (text.Name.ToLower() == "giamua")
                        {
                            active = "giamua";
                            dataGrid1[irow, 7] = d_gia_vat;
                            if (dstyleban.Tables[0].Rows.Count > 0)
                            {
                                DataRow[] dr = dstyleban.Tables[0].Select("tu<=" + d_tmp.ToString() + " and den>=" + d_tmp.ToString());
                                decimal i_tyle = 0;
                                if (dr.Length > 0)
                                {
                                    i_tyle = decimal.Parse(dr[0]["tyle"].ToString());
                                }
                                decimal d_giaban = d_tmp * i_tyle / 100 + d_tmp;
                                dataGrid1[i_cur, 10] = d_giaban;
                                decimal d_giaban_vat = d_giaban * i_vat / 100 + d_giaban;
                                dataGrid1[i_cur, 11] = d_giaban_vat;
                            }
                        }
                        else if (text.Name.ToLower() == "gia_bh_novat")
                        {
                            dataGrid1[irow, 9] = d_gia_vat;
                        }
                        else if (text.Name.ToLower() == "giaban")
                        {
                            active = "giaban";
                            dataGrid1[irow, 11] = d_gia_vat;
                        }
                        else if (text.Name.ToLower() == "gia_phuthu")
                        {
                            dataGrid1[irow, 14] = d_gia_vat;
                        }
                    }
                }
                catch { text.Text = ""; }
            }
        }
        DataGridCell cell;
        void Textbox_Validated(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox text = (System.Windows.Forms.TextBox)sender;
            if (text.Name.ToLower() == "giamua")
            {
                if (dstyleban.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        decimal d_tmp = decimal.Parse(text.Text);
                        DataRow[] dr = dstyleban.Tables[0].Select("tu<=" + d_tmp.ToString() + " and den>=" + d_tmp.ToString());
                        decimal i_tyle = 0;
                        if (dr.Length > 0)
                        {
                            i_tyle = decimal.Parse(dr[0]["tyle"].ToString());
                        }
                        decimal d_giaban = d_tmp * i_tyle / 100 + d_tmp;
                        dataGrid1[i_cur, 10] = d_giaban;
                        int i_vat = int.Parse(dataGrid1[i_cur, 5].ToString());
                        decimal d_giaban_vat = d_giaban * i_vat / 100 + d_giaban;
                        dataGrid1[i_cur, 11] = d_giaban_vat;
                    }
                    catch { }
                }
            }
            else if (text.Name.ToLower() == "giaban")
            {
                try
                {
                    decimal d_tmp = decimal.Parse(text.Text);
                    decimal d_giamua = decimal.Parse(dataGrid1[irow, 6].ToString());
                    if (d_tmp < d_giamua)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Giá bán phải lớn hơn giá mua"), "Medisoft");
                        dataGrid1[i_cur, 10] = d_giamua;
                        int i_vat = int.Parse(dataGrid1[i_cur, 5].ToString());
                        decimal d_giabanvat = d_giamua * ((decimal)i_vat / 100) + d_giamua;
                        dataGrid1[i_cur, 11] = d_giabanvat;
                        dataGrid1.CurrentCell = (DataGridCell)dataGrid1[i_cur, 10];
                    }
                }
                catch { }
            }
        }
        //Thuy 24.02.2012
        private void chkBHYTChiTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBHYTChiTra.Checked)
            {
                load_grid();
            }
            else
            {
                load_grid();
            }
        }
	}
}
