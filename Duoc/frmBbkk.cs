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
	/// Summary description for frmBbkk.
	/// </summary>
	public class frmBbkk : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butLuu;
		private AccessData d;
        private int i_makho, i_nhom, i_userid, irow = 0, i_thanhtien_le;
        private string s_mmyy, sql, format_soluong, user, xxx,format_dongia,s_ngay;
		private DataSet ds=new DataSet();
        private DataSet dsxml = new DataSet();
		private DataTable dt=new DataTable();
        private CheckBox chkXML;
        private bool bGiaban_danhmuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmBbkk(AccessData acc, int kho, string mmyy, string tenkho,int nhom,int userid,string ngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_makho = kho; s_mmyy = mmyy; i_nhom = nhom; i_userid = userid; s_ngay = ngay;
            this.Text = "Biên bản kiểm kê " + tenkho.Trim() + " tháng " + mmyy.Substring(0, 2) + " năm 20" + mmyy.Substring(2, 2);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBbkk));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -17);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 535);
            this.dataGrid1.TabIndex = 5;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(473, 524);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(49, 25);
            this.butIn.TabIndex = 3;
            this.butIn.Text = "&In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(522, 524);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(403, 524);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 2;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(333, 524);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(8, 529);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 6;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // frmBbkk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBbkk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng dự trù";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBbkk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBbkk_Load(object sender, System.EventArgs e)
		{
			//if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bGiaban_danhmuc = d.bGiaban_danhmuc(i_nhom);
            i_thanhtien_le = d.d_thanhtien_le(i_nhom);
            user = d.user; xxx = user + s_mmyy;
			format_soluong=d.format_soluong(i_nhom);
            format_dongia = d.format_dongia(i_nhom);			

            sql = "select a.makho,a.makp,a.sttt,a.mabd,c.ma,trim(c.ten)||' '||trim(c.hamluong) as ten,c.dang,";
            sql += "a.slton,a.slkk,a.thua,a.thieu,b.giamua,b.handung,b.losx,";
            sql += "f.ten as tenhang,g.ten as tennuoc,d.ten as tennguon,e.ten as tennx ";
            sql += " from " + xxx + ".d_bbkk a inner join " + xxx + ".d_theodoi b on a.sttt=b.id ";
            sql += " inner join " + user + ".d_dmbd c on a.mabd=c.id ";
            sql += " inner join " + user + ".d_dmnguon d on b.manguon=d.id ";
            sql += " inner join " + user + ".d_dmnx e on b.nhomcc=e.id ";
            sql += " inner join " + user + ".d_dmhang f on c.mahang=f.id ";
            sql += " inner join " + user + ".d_dmnuoc g on c.manuoc=g.id ";
            sql += " where a.makho=" + i_makho + " and a.makp=0";
			dt=d.get_data(sql).Tables[0];
			load();
			dataGrid1.ReadOnly=false;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
		}

		private void load()
		{
            sql = "select a.makho,a.stt,a.mabd,c.ma,trim(c.ten)||' '||trim(c.hamluong) as ten,c.dang,";
            sql += "a.tondau+a.slnhap-a.slxuat as slton,0000000000000.00 as slkk,0000000000000.00 as thua,0000000000.00 as thieu,b.giamua,b.handung,b.losx,";
            sql += "f.ten as tenhang,g.ten as tennuoc,d.ten as tennguon,e.ten as tennx,b.manguon,b.nhomcc,b.giaban,b.giaban2,b.gianovat as dongia,";
            sql += "b.sothe,b.namsx,b.namsd,b.baohanh,b.nguongoc,b.tinhtrang,b.chietkhau,b.gianovat,b.tyle_ggia,b.st_ggia,a.idn,a.sttn";
            sql += " from " + xxx + ".d_tonkhoct a inner join " + xxx + ".d_theodoi b on a.stt=b.id ";
            sql += " inner join " + user + ".d_dmbd c on a.mabd=c.id ";
            sql += " inner join " + user + ".d_dmnguon d on b.manguon=d.id ";
            sql += " inner join " + user + ".d_dmnx e on b.nhomcc=e.id ";
            sql += " inner join " + user + ".d_dmhang f on c.mahang=f.id ";
            sql += " inner join " + user + ".d_dmnuoc g on c.manuoc=g.id ";
            sql += " where a.makho=" + i_makho;
            sql += " order by c.ten";
			dsxml=d.get_data(sql);
            get_thua();
            get_thieu();
            ds = dsxml.Copy();
            ds.Clear();
            ds.Merge(dsxml.Tables[0].Select("slton<>0","ten"));
            DataRow r1;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r1 = d.getrowbyid(dt, "makho=" + int.Parse(r["makho"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                if (r1 != null)
                {
                    r["slkk"] = r1["slkk"].ToString();
                    r["thua"] = r1["thua"].ToString();
                    r["thieu"] = r1["thieu"].ToString();
                }
            }
            ds.HasChanges();
			dataGrid1.DataSource=ds.Tables[0];
		}

        private void get_thua()
        {
            DataRow r2;
            decimal id=0;
            foreach (DataRow r in d.get_data("select a.*,to_char(a.ngayhd,'dd/mm/yyyy') as ngay from " + xxx + ".d_nhapll a where a.loai='T' and a.bbkiem='BBKKTHUA' and a.makho=" + i_makho).Tables[0].Rows)
            {
                id = decimal.Parse(r["id"].ToString());
                sql = "select a.stt,a.mabd,a.handung,a.losx,";
                sql += "a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
                sql += "a.giaban,a.giamua,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
                sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
                sql += "a.st_ggia,case when a.vat=0 then 0 else round(a.sotien*a.vat/100," + i_thanhtien_le + ") end as sotienvat ";
                sql += " from " + xxx + ".d_nhapct a where a.id=" + id + " order by a.stt";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    r2=d.getrowbyid(dsxml.Tables[0],"idn="+id+" and sttn="+int.Parse(r1["stt"].ToString()));
                    if (r2!=null)
                        r2["slton"]=decimal.Parse(r2["slton"].ToString())-decimal.Parse(r1["soluong"].ToString());
                }
            }
        }
        private void get_thieu()
        {
            DataRow r2;
            foreach (DataRow r in d.get_data("select * from " + xxx + ".d_xuatll where loai='XK' and lydo='BBKKTHIEU' and khox=" + i_makho).Tables[0].Rows)
            {
                sql = "select * from " + xxx + ".d_xuatct where id=" + decimal.Parse(r["id"].ToString()) + " order by stt";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    r2 = d.getrowbyid(dsxml.Tables[0], "makho=" + i_makho + " and stt=" + decimal.Parse(r1["sttt"].ToString()));
                    if (r2 != null)
                        r2["slton"] = decimal.Parse(r2["slton"].ToString()) + decimal.Parse(r1["soluong"].ToString());
                }
            }
        }
        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol1;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;
            ts.MappingName = ds.Tables[0].TableName;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "tennguon";
            TextCol1.HeaderText = "Nguồn";
            TextCol1.ReadOnly = true;
            TextCol1.Width = 80;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "tennx";
            TextCol1.HeaderText = "Nhà cung cấp";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên thuốc - hàm lượng";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "dang";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 40;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "tenhang";
            TextCol1.HeaderText = "Hãng SX";
            TextCol1.Width = 150;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "giamua";
            TextCol1.HeaderText = "Đơn giá";
            TextCol1.Width = 70;
            TextCol1.Format = format_dongia;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "handung";
            TextCol1.HeaderText = "Date";
            TextCol1.Width = 40;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 7);
            TextCol1.MappingName = "losx";
            TextCol1.HeaderText = "Lô";
            TextCol1.Width = 80;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            TextCol1.MappingName = "slton";
            TextCol1.HeaderText = "Tồn cuối";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 9);
            TextCol1.MappingName = "slkk";
            TextCol1.HeaderText = "Kiểm kê";
            TextCol1.Width = 60;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 10);
            TextCol1.MappingName = "thua";
            TextCol1.HeaderText = "Thừa";
            TextCol1.Width = 50;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 11);
            TextCol1.MappingName = "thieu";
            TextCol1.HeaderText = "Thiếu";
            TextCol1.Width = 50;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 12);
            TextCol1.MappingName = "stt";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
        }	

		public Color MyGetColorRowCol(int row, int col)
		{
            if (decimal.Parse(dataGrid1[row,10].ToString())!=0 || decimal.Parse(dataGrid1[row,11].ToString())!=0) return Color.Red;
            else return Color.Black;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			if (ds.HasChanges())
				if (MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn cập nhật thay đổi ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) butLuu_Click(sender,e);
			d.close();this.Close();
		}

        private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (d.bKhoaso(i_nhom,s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " +lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " +lan.Change_language_MessageText("đã khóa !") + "\n" +lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                return;
            }
            Cursor = Cursors.WaitCursor;
            ds.AcceptChanges();
            foreach (DataRow r in ds.Tables[0].Rows)
                d.upd_bbkk(s_mmyy, i_makho, 0, decimal.Parse(r["stt"].ToString()), int.Parse(r["mabd"].ToString()), decimal.Parse(r["slton"].ToString()), decimal.Parse(r["slkk"].ToString()), decimal.Parse(r["thua"].ToString()), decimal.Parse(r["thieu"].ToString()), i_userid);
            upd_thua();
            upd_thieu();
            Cursor = Cursors.Default;
            butKetthuc.Focus();
		}

        private void upd_thua()
        {
            decimal id = 0;
            foreach (DataRow r in d.get_data("select a.*,to_char(a.ngayhd,'dd/mm/yyyy') as ngay from " + xxx + ".d_nhapll a where a.loai='T' and a.bbkiem='BBKKTHUA' and a.makho="+i_makho).Tables[0].Rows)
            {
                id = decimal.Parse(r["id"].ToString());
                sql = "select a.stt,a.mabd,a.handung,a.losx,";
                sql += "a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
                sql += "a.giaban,a.giamua,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
                sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
                sql += "a.st_ggia,case when a.vat=0 then 0 else round(a.sotien*a.vat/100," + i_thanhtien_le + ") end as sotienvat ";
                sql += " from " + xxx + ".d_nhapct a where a.id=" + id + " order by a.stt";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    d.upd_tonkhoct_nhapct(d.delete, s_mmyy, r["ngay"].ToString(), id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), i_makho, int.Parse(r["manguon"].ToString()), int.Parse(r["madv"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, "T", 0, 0, 0, i_nhom, "", 0, 1, decimal.Parse(r["chietkhau"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
                d.execute_data("delete from " + xxx + ".d_nhapct where id=" + id);
                d.execute_data("delete from " + xxx + ".d_nhapll where id=" + id);
            }
            int stt = 1;
            foreach (DataRow r in ds.Tables[0].Select("thua>0"))
            {
                id = d.get_id_nhap;
                d.upd_nhapll(s_mmyy,id,i_nhom,stt.ToString().PadLeft(4,'0'),s_ngay,stt.ToString().PadLeft(4,'0'),s_ngay,"BBKKTHUA",s_ngay,"T",
                    "",int.Parse(r["nhomcc"].ToString()),i_makho,int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()),
                    "","",i_userid,0,0);
                d.upd_nhapct(s_mmyy,id,1,int.Parse(r["mabd"].ToString()), r["handung"].ToString(), r["losx"].ToString(),0,
                    decimal.Parse(r["thua"].ToString()), decimal.Parse(r["giamua"].ToString()),
                    decimal.Parse(r["giamua"].ToString())*decimal.Parse(r["thua"].ToString()),
                    decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["giamua"].ToString()),
                    decimal.Parse(r["thua"].ToString()),1,0, 0, 0,r["namsx"].ToString(), "",int.Parse(r["baohanh"].ToString()),
                    int.Parse(r["nguongoc"].ToString()), int.Parse(r["tinhtrang"].ToString()),r["sothe"].ToString(),
                    decimal.Parse(r["giaban"].ToString()),decimal.Parse(r["giamua"].ToString()),
                    decimal.Parse(r["giaban2"].ToString()),0,0,0,"");
                d.upd_tonkhoct_nhapct(d.insert, s_mmyy,s_ngay,id,1,decimal.Parse(r["thua"].ToString()),
                    decimal.Parse(r["giamua"].ToString())*decimal.Parse(r["thua"].ToString()),0,i_makho,
                    int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()), int.Parse(r["mabd"].ToString()),
                    r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["giaban"].ToString()),r["namsx"].ToString(),
                    0, 0,"T",int.Parse(r["baohanh"].ToString()),int.Parse(r["nguongoc"].ToString()),int.Parse(r["tinhtrang"].ToString()),
                    i_nhom,r["sothe"].ToString(),0, 1,0, decimal.Parse(r["giaban2"].ToString()),decimal.Parse(r["giamua"].ToString()),
                    decimal.Parse(r["giamua"].ToString()) * decimal.Parse(r["thua"].ToString()), 0, 0, decimal.Parse(r["dongia"].ToString()), bGiaban_danhmuc,"");
                d.execute_data("update " + xxx + ".d_nhapll set paid=1 where id=" + id);
                stt++;
            }
        }

        private void upd_thieu()
        {
            decimal id = 0;
            foreach (DataRow r in d.get_data("select a.* as ngay from " + xxx + ".d_xuatll a where a.loai='XK' and a.lydo='BBKKTHIEU' and a.khox=" + i_makho).Tables[0].Rows)
            {
                id = decimal.Parse(r["id"].ToString());
                sql = "select a.stt,a.sttt,a.mabd,t.handung,t.losx,a.soluong,t.giamua as dongia,a.soluong*t.giamua as sotien,";
                sql += " t.giaban,t.giamua,t.manguon,t.nhomcc,t.sothe,a.mabs,'' as tenbs,a.hotenbn ";
                sql += " from " + xxx + ".d_xuatct a," + xxx + ".d_theodoi t ";
                sql += " where a.sttt=t.id and a.id=" + id + " order by a.stt";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    d.upd_tonkhoct_xuatct(d.delete, s_mmyy,"XK",i_makho,3,decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                d.execute_data("delete from " + xxx + ".d_xuatct where id=" + id);
                d.execute_data("delete from " + xxx + ".d_xuatll where id=" + id);
            }
            int stt = 1;
            if (ds.Tables[0].Select("thieu>0").Length > 0)
            {
                id = d.get_id_xuat;
                d.upd_xuatll(s_mmyy, id, i_nhom, "0001", s_ngay, "XK", i_makho, 3, "BBKKTHIEU", i_userid,"");
            }
            foreach (DataRow r in ds.Tables[0].Select("thieu>0"))
            {
                d.upd_xuatct(s_mmyy,id,stt,decimal.Parse(r["stt"].ToString()),int.Parse(r["mabd"].ToString()),
                    decimal.Parse(r["thieu"].ToString()), "", "", decimal.Parse(r["giaban"].ToString()));
                d.upd_tonkhoct_xuatct(d.insert, s_mmyy,"XK",i_makho,3,decimal.Parse(r["stt"].ToString()),
                    int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()),int.Parse(r["mabd"].ToString()),
                    r["handung"].ToString(), r["losx"].ToString(), decimal.Parse(r["thieu"].ToString()),
                    decimal.Parse(r["giamua"].ToString())*decimal.Parse(r["thieu"].ToString()),
                    decimal.Parse(r["giaban"].ToString()),decimal.Parse(r["giamua"].ToString()));
                stt++;
            }
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
            if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
            if (chkXML.Checked)
            {
                ds.WriteXml("..\\..\\dataxml\\bbkk.xml", XmlWriteMode.WriteSchema);
            }
            string tmp_rpt = "rptBbkk.rpt";
            if (System.IO.File.Exists("..\\..\\..\\report\\" + tmp_rpt) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy file '" + tmp_rpt + "'"));
                return;
            }
            frmReport f = new frmReport(d, ds.Tables[0], i_userid, "", tmp_rpt);
            f.ShowDialog();
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid1.CurrentCell.ColumnNumber == 9)
                {
                    decimal stt = decimal.Parse(dataGrid1[irow, 12].ToString());
                    DataRow r = d.getrowbyid(ds.Tables[0], "stt=" + stt);
                    if (r != null)
                    {
                        decimal slton = decimal.Parse(r["slton"].ToString());
                        decimal slkk = decimal.Parse(r["slkk"].ToString());
                        if (slkk > 0)
                        {
                            r["thua"] = (slkk > slton) ? slkk - slton : 0;
                            r["thieu"] = (slton > slkk) ? slton - slkk : 0;
                        }
                    }
                }
                irow = dataGrid1.CurrentRowIndex;
            }
            catch { }
        }
	}
}
