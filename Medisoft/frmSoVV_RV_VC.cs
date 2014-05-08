using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using LibMedi;
using Excel;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSoluutruhosobenhan.
	/// </summary>
	public class frmSoVV_RV_VC : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m = new LibMedi.AccessData();
		private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private System.Data.DataTable dtkp;
		private DataSet ads,ads1;
		private DataRow r2;
		private DataColumn dc;
		private string haison="",sql="",tenfile="",user;
		private Excel.Application oxl;
		private Excel._Workbook owb;
		private Excel._Worksheet osheet;
		private Excel.Range orange;
        private string s_makp = "", s_tenkp = "";

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker den;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DataGrid grid;
        private System.Windows.Forms.CheckBox chkNoitru;
        private System.Windows.Forms.CheckBox chkngoaitru;
        private System.Windows.Forms.CheckBox chkPK;
        private System.Windows.Forms.CheckBox chkPL;
        private CheckedListBox cbkhoa;
        private System.Windows.Forms.CheckBox chkall;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSoVV_RV_VC()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoVV_RV_VC));
            this.label1 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGrid();
            this.chkNoitru = new System.Windows.Forms.CheckBox();
            this.chkngoaitru = new System.Windows.Forms.CheckBox();
            this.chkPK = new System.Windows.Forms.CheckBox();
            this.chkPL = new System.Windows.Forms.CheckBox();
            this.cbkhoa = new System.Windows.Forms.CheckedListBox();
            this.chkall = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(52, 20);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(88, 20);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(180, 20);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(88, 20);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIN
            // 
            this.butIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIN.ForeColor = System.Drawing.Color.Black;
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(75, 296);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(70, 25);
            this.butIN.TabIndex = 6;
            this.butIN.Text = "   &In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Black;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(147, 296);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.DataMember = "";
            this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grid.Location = new System.Drawing.Point(276, 20);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(0, 306);
            this.grid.TabIndex = 8;
            // 
            // chkNoitru
            // 
            this.chkNoitru.AutoSize = true;
            this.chkNoitru.Location = new System.Drawing.Point(52, 252);
            this.chkNoitru.Name = "chkNoitru";
            this.chkNoitru.Size = new System.Drawing.Size(57, 17);
            this.chkNoitru.TabIndex = 9;
            this.chkNoitru.Text = "Nôi trú";
            this.chkNoitru.UseVisualStyleBackColor = true;
            // 
            // chkngoaitru
            // 
            this.chkngoaitru.AutoSize = true;
            this.chkngoaitru.Location = new System.Drawing.Point(114, 252);
            this.chkngoaitru.Name = "chkngoaitru";
            this.chkngoaitru.Size = new System.Drawing.Size(69, 17);
            this.chkngoaitru.TabIndex = 10;
            this.chkngoaitru.Text = "Ngoại trú";
            this.chkngoaitru.UseVisualStyleBackColor = true;
            // 
            // chkPK
            // 
            this.chkPK.AutoSize = true;
            this.chkPK.Location = new System.Drawing.Point(183, 252);
            this.chkPK.Name = "chkPK";
            this.chkPK.Size = new System.Drawing.Size(86, 17);
            this.chkPK.TabIndex = 11;
            this.chkPK.Text = "Phòng khám";
            this.chkPK.UseVisualStyleBackColor = true;
            // 
            // chkPL
            // 
            this.chkPL.AutoSize = true;
            this.chkPL.Location = new System.Drawing.Point(52, 271);
            this.chkPL.Name = "chkPL";
            this.chkPL.Size = new System.Drawing.Size(116, 17);
            this.chkPL.TabIndex = 12;
            this.chkPL.Text = "Phòng cấp cứu lưu";
            this.chkPL.UseVisualStyleBackColor = true;
            // 
            // cbkhoa
            // 
            this.cbkhoa.FormattingEnabled = true;
            this.cbkhoa.Location = new System.Drawing.Point(52, 62);
            this.cbkhoa.Name = "cbkhoa";
            this.cbkhoa.Size = new System.Drawing.Size(216, 184);
            this.cbkhoa.TabIndex = 13;
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Location = new System.Drawing.Point(52, 44);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(143, 17);
            this.chkall.TabIndex = 14;
            this.chkall.Text = "Chọn tất cả khoa/phòng";
            this.chkall.UseVisualStyleBackColor = true;
            this.chkall.Click += new System.EventHandler(this.chkall_Click);
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // frmSoVV_RV_VC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(274, 331);
            this.Controls.Add(this.chkall);
            this.Controls.Add(this.cbkhoa);
            this.Controls.Add(this.chkPL);
            this.Controls.Add(this.chkPK);
            this.Controls.Add(this.chkngoaitru);
            this.Controls.Add(this.chkNoitru);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSoVV_RV_VC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số vào viện - ra viện - chuyển viện";
            this.Load += new System.EventHandler(this.frmSoluutruhosobenhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Taotable()
		{
			try
			{
				ads = new DataSet();
				haison = "";
				ads.ReadXml("..//..//..//xml//m_hosoVV_RV_CV.xml");

                haison = "STT+Mã BN+Họ tên+Nam+Nữ+Công nhân viên+Số thẻ+Có BHYT+Thành thị+Nông thôn+TE <12 tháng+TE 1-15 tuổi+Nghề nghiệp+Địa chỉ+Nơi giới thiệu+Vào viện+Chuyển viện+Ra viện+Tử vong+T.vong trong 24 giờ+Tuyến dưới+Khoa khám bệnh+Khoa điều trị+";
           
				ads1 = m.get_data("select * from "+user+".ketqua where ma not in(5)");
				foreach (DataRow r in ads1.Tables[0].Rows)
				{
					haison += r["ten"].ToString() + "+";
					dc = new DataColumn();
					dc.ColumnName = "kq_" + r["ma"].ToString();
					dc.DataType = Type.GetType("System.String");
					ads.Tables[0].Columns.Add(dc);
				}
				haison += "TS ngày ĐT";
				dc = new DataColumn();
				dc.ColumnName = "ngaydt";
				dc.DataType = Type.GetType("System.String");
				ads.Tables[0].Columns.Add(dc);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void exp_excel(bool print)
		{
			try
			{
				d.check_process_Excel();
				int i_rec = 0, be = 4, dong = 6, sodong = ads.Tables[0].Rows.Count + 6, socot = ads.Tables[0].Columns.Count - 1, dongke = sodong - 1;
				char[] cSplit ={ '+' };
				string[] sTitle = haison.Split(cSplit);
				i_rec = sTitle.Length;
				tenfile = d.Export_Excel(ads, "HOSOBENHAN");
				oxl = new Excel.Application();

				owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				osheet = (Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines = true;

				for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(0) + "5", d.getIndex(0) + "5").EntireRow.Delete(Missing.Value);//remove row field
				osheet.get_Range(d.getIndex(0) + "4", d.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                
				for (int i = 0; i < i_rec; i++)
				{
					osheet.Cells[dong - 2, i + 1] = sTitle[i].ToString();

				}
				orange = osheet.get_Range(d.getIndex(i_rec * 2 + 4) + "4", d.getIndex(i_rec * 2 + 5) + "4");
				orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Bold = true;
				orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(socot) + sodong.ToString());
				orange.Font.Name = "Arial";
				orange.Font.Size = 8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros = false;
//				osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
//				osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
//				osheet.PageSetup.LeftMargin = 20;
//				osheet.PageSetup.RightMargin = 20;
//				osheet.PageSetup.TopMargin = 30;
//				osheet.PageSetup.CenterFooter = "Trang : &P/&N";
				osheet.Cells[1, 1] = d.Syte; osheet.Cells[2, 1] = d.Tenbv;
				orange = osheet.get_Range(d.getIndex(1) + "1", d.getIndex(3) + "2");
				orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

				osheet.Cells[1, 8] = "SỔ VÀO VIỆN - RA VIỆN - CHUYỂN VIỆN";
				osheet.Cells[2, 8] = (tu.Text == den.Text) ? "Tháng " + tu.Text : "Từ ngày " + tu.Text + " đến ngày" + den.Text;
                if (s_tenkp.Trim().Trim(',') != "") osheet.Cells[3, 8] = s_tenkp;
                orange = osheet.get_Range(d.getIndex(3) + "1", d.getIndex(socot - 1) + "3");

				orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size = 12;
				orange.Font.Bold = true;
				if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				else oxl.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void frmSoluutruhosobenhan_Load(object sender, System.EventArgs e)
		{
            user = m.user;			
            dtkp = m.get_data("select * from " + user + ".btdkp_bv order by loai, makp").Tables[0];
            cbkhoa.DataSource = dtkp;
            cbkhoa.DisplayMember = "TENKP";
            cbkhoa.ValueMember = "MAKP";
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			if(ads != null && ads.Tables[0].Rows.Count>0)
			{
				if(DialogResult.No == MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn tổng hợp lại không ?"),this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
					return;
			}
			DataSet ds= new DataSet();
			Taotable();
			int stt = 1;
            string stime = "'" + m.f_ngay + "'";
            //
            s_makp = "";
            s_tenkp = "";
            for (int i = 0; i < cbkhoa.Items.Count; i++)
            {
                if (cbkhoa.GetItemChecked(i))
                {
                    s_makp += "'" + dtkp.Rows[i]["makp"].ToString() + "',";
                    s_tenkp += dtkp.Rows[i]["tenkp"].ToString() + ",";
                }
            }
            //
            sql = "";
            if (chkNoitru.Checked || (chkNoitru.Checked == false && chkngoaitru.Checked == false && chkPK.Checked == false && chkPL.Checked == false))
            {
                sql = "select a.mabn,a.hoten,case when a.phai=0 then a.namsinh else '' end as nam,case when a.phai=0 then '' else a.namsinh end as nu,";
                sql += " h.sothe,a.mann,g.tennn as nghenghiep,trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) as diachi,";
                sql += " j.tenbv as noigioithieu,to_char(b.ngay,'dd/mm/yyyy hh24:mi')as ngayvao,to_char(c.ngay,'dd/mm/yyyy hh24:mi')as ngayra,i.maicd as icd_noigioithieu,n.vviet as cd_noigioithieu,b.chandoan as cd_vao,b.maicd as maicd_vao,c.chandoan as cd_ra,c.maicd as maicd_ra";
                sql += " ,substr(m.tuoivao,1,3)||case when substr(m.tuoivao,4,1)=0 then 'TU' else case when substr(m.tuoivao,4,1)=1 then 'TH' else case when substr(m.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoi,c.ketqua,ttlucrv,c.ngay-b.ngay as giotv,";
                sql += " date(to_char(c.ngay,'yyyymmdd'))-date(to_char(b.ngay,'yyyymmdd'))+1 as ngaydt ";
                sql += " from " + user + ".btdbn a inner join " + user + ".benhandt b on a.mabn=b.mabn inner join " + user + ".xuatvien c on b.maql=c.maql inner join " + user + ".btdtt d on a.matt=d.matt inner join " + user + ".btdquan e on a.maqu=e.maqu inner join " + user + ".btdpxa f on a.maphuongxa=f.maphuongxa inner join " + user + ".btdnn_bv g on a.mann=g.mann left join " + user + ".bhyt h on b.maql=h.maql and (h.sudung=1 or h.sudung is null) left join " + user + ".noigioithieu i on b.maql=i.maql left join " + user + ".dstt j on i.mabv=j.mabv left join " + user + ".icd10 n on i.maicd=cicd10 inner join " + user + ".lienhe m on m.maql=c.maql";
                sql += "  where length(a.namsinh)=4 ";
                //if (cbKhoa1.SelectedIndex != -1) sql += " and b.makp='" + cbKhoa1.SelectedValue.ToString() + "'";
                if (s_makp.Trim().Trim(',') != "") sql += " and b.makp in(" + s_makp.Trim().Trim(',') + ")";
                sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + den.Text.Substring(0, 10) + "'," + stime + ")";
            }
            if (chkngoaitru.Checked || (chkNoitru.Checked == false && chkngoaitru.Checked == false && chkPK.Checked == false && chkPL.Checked == false)) 
            {
                if (sql != "") sql += " union all ";
                sql += "select a.mabn,a.hoten,case when a.phai=0 then a.namsinh else '' end as nam,case when a.phai=0 then '' else a.namsinh end as nu,";
                sql += " h.sothe,a.mann,g.tennn as nghenghiep,trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) as diachi,";
                sql += " j.tenbv as noigioithieu,to_char(b.ngay,'dd/mm/yyyy hh24:mi')as ngayvao,to_char(b.ngayrv,'dd/mm/yyyy hh24:mi')as ngayra,i.maicd as icd_noigioithieu,n.vviet as cd_noigioithieu,b.chandoan as cd_vao,b.maicd as maicd_vao,b.chandoanrv as cd_ra,b.maicdrv as maicd_ra";
                sql += " ,substr(m.tuoivao,1,3)||case when substr(m.tuoivao,4,1)=0 then 'TU' else case when substr(m.tuoivao,4,1)=1 then 'TH' else case when substr(m.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoi,b.ketqua,b.ttlucrv,b.ngayrv-b.ngay as giotv,";
                sql += " date(to_char(b.ngayrv,'yyyymmdd'))-date(to_char(b.ngay,'yyyymmdd'))+1 as ngaydt ";
                sql += " from " + user + ".btdbn a inner join " + user + ".benhanngtr b on a.mabn=b.mabn inner join " + user + ".btdtt d on a.matt=d.matt inner join " + user + ".btdquan e on a.maqu=e.maqu inner join " + user + ".btdpxa f on a.maphuongxa=f.maphuongxa inner join " + user + ".btdnn_bv g on a.mann=g.mann left join " + user + ".bhyt h on b.maql=h.maql left join " + user + ".noigioithieu i on b.maql=i.maql left join " + user + ".dstt j on i.mabv=j.mabv left join " + user + ".icd10 n on i.maicd=cicd10 inner join " + user + ".lienhe m on m.maql=b.maql";
                sql += "  where length(a.namsinh)=4 ";
                //if (cbKhoa1.SelectedIndex != -1) sql += " and b.makp='" + cbKhoa1.SelectedValue.ToString() + "'";
                if (s_makp.Trim().Trim(',') != "") sql += " and b.makp in(" + s_makp.Trim().Trim(',') + ")";
                sql += " and " + m.for_ngay("b.ngayrv", stime) + " between to_date('" + tu.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + den.Text.Substring(0, 10) + "'," + stime + ")";
            }
			ds = m.get_data(sql);
			//
            sql = "";
            if (chkPL.Checked || (chkNoitru.Checked == false && chkngoaitru.Checked == false && chkPK.Checked == false && chkPL.Checked == false))
            {
                if (sql != "") sql += " union all ";
                sql += "select a.mabn,a.hoten,case when a.phai=0 then a.namsinh else '' end as nam,case when a.phai=0 then '' else a.namsinh end as nu,";
                sql += " h.sothe,a.mann,g.tennn as nghenghiep,trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) as diachi,";
                sql += " j.tenbv as noigioithieu,to_char(b.ngay,'dd/mm/yyyy hh24:mi')as ngayvao,to_char(b.ngayrv,'dd/mm/yyyy hh24:mi')as ngayra,i.maicd as icd_noigioithieu,n.vviet as cd_noigioithieu,b.chandoan as cd_vao,b.maicd as maicd_vao,b.chandoanrv as cd_ra,b.maicdrv as maicd_ra";
                sql += " ,substr(m.tuoivao,1,3)||case when substr(m.tuoivao,4,1)=0 then 'TU' else case when substr(m.tuoivao,4,1)=1 then 'TH' else case when substr(m.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoi,to_number('2') as ketqua,b.ttlucrv,b.ngayrv-b.ngay as giotv,";
                sql += " date(to_char(b.ngayrv,'yyyymmdd'))-date(to_char(b.ngay,'yyyymmdd'))+1 as ngaydt ";
                sql += " from " + user + ".btdbn a inner join xxx.benhancc b on a.mabn=b.mabn inner join " + user + ".btdtt d on a.matt=d.matt inner join " + user + ".btdquan e on a.maqu=e.maqu inner join " + user + ".btdpxa f on a.maphuongxa=f.maphuongxa inner join " + user + ".btdnn_bv g on a.mann=g.mann left join xxx.bhyt h on b.maql=h.maql left join xxx.noigioithieu i on b.maql=i.maql left join " + user + ".dstt j on i.mabv=j.mabv left join " + user + ".icd10 n on i.maicd=cicd10 inner join xxx.lienhe m on m.maql=b.maql";
                sql += "  where length(a.namsinh)=4 ";
                //if (cbKhoa1.SelectedIndex != -1) sql += " and b.makp='" + cbKhoa1.SelectedValue.ToString() + "'";
                if (s_makp.Trim().Trim(',') != "") sql += " and b.makp in(" + s_makp.Trim().Trim(',') + ")";
                sql += " and " + m.for_ngay("b.ngayrv", stime) + " between to_date('" + tu.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + den.Text.Substring(0, 10) + "'," + stime + ")";
                ds.Merge(m.get_data_mmyy(sql, tu.Text, den.Text, false));
            }
            sql = "";
            if (chkPK.Checked || (chkNoitru.Checked == false && chkngoaitru.Checked == false && chkPK.Checked == false && chkPL.Checked == false))
            {
                if (sql != "") sql += " union all ";
                sql += "select a.mabn,a.hoten,case when a.phai=0 then a.namsinh else '' end as nam,case when a.phai=0 then '' else a.namsinh end as nu,";
                sql += " h.sothe,a.mann,g.tennn as nghenghiep,trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) as diachi,";
                sql += " j.tenbv as noigioithieu,to_char(b.ngay,'dd/mm/yyyy hh24:mi')as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi')as ngayra,i.maicd as icd_noigioithieu,n.vviet as cd_noigioithieu,b.chandoan as cd_vao,b.maicd as maicd_vao,b.chandoan as cd_ra,b.maicd as maicd_ra";
                sql += " ,substr(m.tuoivao,1,3)||case when substr(m.tuoivao,4,1)=0 then 'TU' else case when substr(m.tuoivao,4,1)=1 then 'TH' else case when substr(m.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoi,to_number('1') as ketqua,b.ttlucrv,b.ngay-b.ngay as giotv,";
                sql += " 1 as ngaydt ";
                sql += " from " + user + ".btdbn a inner join xxx.benhanpk b on a.mabn=b.mabn inner join " + user + ".btdtt d on a.matt=d.matt inner join " + user + ".btdquan e on a.maqu=e.maqu inner join " + user + ".btdpxa f on a.maphuongxa=f.maphuongxa inner join " + user + ".btdnn_bv g on a.mann=g.mann left join xxx.bhyt h on b.maql=h.maql left join xxx.noigioithieu i on b.maql=i.maql left join " + user + ".dstt j on i.mabv=j.mabv left join " + user + ".icd10 n on i.maicd=cicd10 inner join xxx.lienhe m on m.maql=b.maql";
                sql += "  where length(a.namsinh)=4 ";
                //if (cbKhoa1.SelectedIndex != -1) sql += " and b.makp='" + cbKhoa1.SelectedValue.ToString() + "'";
                if (s_makp.Trim().Trim(',') != "") sql += " and b.makp in(" + s_makp.Trim().Trim(',') + ")";
                sql += " and " + m.for_ngay("b.ngay", stime) + " between to_date('" + tu.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + den.Text.Substring(0, 10) + "'," + stime + ")";
                ds.Merge(m.get_data_mmyy(sql, tu.Text, den.Text, false));
            }
            //
			if( ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0 )
			{
				foreach (DataRow r in ds.Tables[0].Rows)
				{
					r2 = ads.Tables[0].NewRow();
					r2["stt"] = stt.ToString();                            
					r2["mabn"] = r["mabn"].ToString();
					r2["hoten"] = r["hoten"].ToString();
					r2["nam"] = r["nam"].ToString();
					r2["nu"] = r["nu"].ToString();
					if (r["mann"].ToString() == "06" || r["mann"].ToString() == "07" || r["mann"].ToString() == "08" || r["mann"].ToString() == "09")
					{
						r2["CVC"] = "X";
					}
					else
					{
						r2["CVC"] = "";
					}

					if (r["sothe"].ToString() != "")
					{
						r2["bhyt"] = "X";
					}
					else
					{
						r2["bhyt"] = " ";
					}
					r2["thanhthi"] = "";
					if (r["mann"].ToString() == "05")
					{
						r2["nongthon"] = "X";
					}
					else
					{
						r2["nongthon"] = "";
					}
					if (decimal.Parse(r["tuoi"].ToString().Substring(0, 3)) < 12 && r["tuoi"].ToString().Substring(3, 2) == "TH")
					{
						r2["TEduoi12"] = "X";
					}
					else
					{
						r2["TEduoi12"] = "";
					}

					if (decimal.Parse(r["tuoi"].ToString().Substring(0, 3)) <= 15 && r["tuoi"].ToString().Substring(3, 2) == "TU")
					{
						r2["TE1-15"] = "X";
					}
					else
					{
						r2["TE1-15"] = "";
					}

					r2["nghenghiep"] = r["nghenghiep"].ToString();
					r2["diachi"] = r["diachi"].ToString().Trim().Trim('-').Trim('+');
                    r2["noigioithieu"] = r["noigioithieu"].ToString().Trim().Trim('-').Trim('+');
					r2["vaovien"] = r["ngayvao"].ToString();
					if (r["ttlucrv"].ToString() == "6")
					{
						r2["Chuyenvien"] = r["ngayra"].ToString();
					}
					else
					{
						r2["Chuyenvien"] = "";
					}        
					r2["ravien"] = r["ngayra"].ToString();
					if (r["ttlucrv"].ToString() == "7")
					{
						r2["tuvong"] = r["ngayra"].ToString();
					}
					else
					{
						r2["tuvong"] = "";
					}
					if (r["ttlucrv"].ToString() == "7" && r["giotv"].ToString().IndexOf("days")==-1)
					{
						r2["tuvong24h"] = r["ngayra"].ToString();
					}
					else
					{
						r2["tuvong24h"] = "";
					}
                    r2["CDGioithieu"] = (r["cd_noigioithieu"].ToString() == "") ? "" : (r["cd_noigioithieu"].ToString().Trim().Trim('-').Trim('+') + " [" + r["icd_noigioithieu"].ToString() + "]");
                    r2["CDvao"] = (r["cd_vao"].ToString().Trim() == "") ? "" : (r["cd_vao"].ToString().Trim().Trim('-').Trim('+') + " [" + r["maicd_vao"].ToString() + "]");
                    r2["CDra"] = (r["cd_ra"].ToString().Trim() == "") ? "" : (r["cd_ra"].ToString().Trim().Trim('-').Trim('+') + " [" + r["maicd_ra"].ToString() + "]");
					foreach (DataRow rr in ads1.Tables[0].Rows)
					{
						r2["kq_" + rr["ma"].ToString()] = "";
					}
					if (r["ketqua"].ToString() == "1")
					{
						r2["kq_1"] = "X";
					}
					if (r["ketqua"].ToString() == "2")
					{
						r2["kq_2"] = "X";
					}
					if (r["ketqua"].ToString() == "3")
					{
						r2["kq_3"] = "X";
					}
					if (r["ketqua"].ToString() == "4")
					{
						r2["kq_4"] = "X";
					}
					if (int.Parse(r["ngaydt"].ToString()) == 0)
					{
						r2["ngaydt"] = "1";
					}
					else
					{
						r2["ngaydt"] = r["ngaydt"].ToString();
					}
                    r2["sothe"] = r["sothe"].ToString();
					ads.Tables[0].Rows.Add(r2);
					stt += 1;
				}
				if(ads != null && ads.Tables[0].Rows.Count > 0)
				{
					exp_excel(false);            
				}
			}
			else 
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),this.Text);
			}
			
		}

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbkhoa.Items.Count; i++)
            {
               if(chkall.Checked) cbkhoa.SetItemCheckState(i, CheckState.Checked);
               else cbkhoa.SetItemCheckState(i, CheckState.Unchecked);
            }
            //
        }
	}
}
