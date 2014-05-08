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
	/// Summary description for frmThuhoi.
	/// </summary>
	public class frmThuhoi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private DataTable dtphieu=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private string xxx,user,s_ngay,s_mmyy,sql,s_makho,s_noidung;
		private int i_nhom,i_loai,i_makp,i_phieu,i_thuoc,i_userid;
		public bool bOk=false;
        private bool bBuhaophi, bThua, bKiemtra, b1kho, bIntheocstt, bDuyettreole, bNguoiduyet_nguoithuhoi=true;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThuhoi(LibDuoc.AccessData acc,DataTable dtl,DataTable dtc,DataTable kp,DataTable phieu,int imakp,int iphieu,string ngay,string mmyy,int nhom,int loai,bool buhaophi,bool thua,int thuoc,string makho,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			dtphieu=phieu;dtkp=kp;dtll=dtl;dtct=dtc;
            i_makp = imakp; i_phieu = iphieu; bBuhaophi = buhaophi; bThua = thua; i_userid = userid;
			s_ngay=ngay;s_mmyy=mmyy;i_nhom=nhom;i_loai=loai;i_thuoc=thuoc;s_makho=makho;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuhoi));
            this.phieu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(48, 34);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(206, 21);
            this.phieu.TabIndex = 3;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phiếu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(48, 10);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(206, 21);
            this.makp.TabIndex = 1;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(63, 71);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Duoc.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(133, 71);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmThuhoi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(262, 119);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThuhoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thu hồi";
            this.Load += new System.EventHandler(this.frmThuhoi_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmThuhoi_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy;
            f_capnhat_db(s_mmyy);
            //
            bNguoiduyet_nguoithuhoi = d.bNguoiduyet_nguoithuhoi(i_nhom);
            bIntheocstt=d.bIntheocstt(i_nhom);
            if (bIntheocstt && i_loai == 2) label1.Text = "Tủ trực :";
			if (bBuhaophi) s_noidung="PHIEU HAO PHI";
			else
			{
				switch (i_loai)
				{
					case 1: s_noidung="PHIEU LINH";
						break;
					case 2: s_noidung="PHIEU TU TRUC";
						break;
					case 3: s_noidung="PHIEU HOAN TRA";
						break;
					default: s_noidung="PHIEU HAO PHI";
						break;
				}
			}
			bKiemtra=d.bKiemtra_phat_thuhoi(i_nhom);
			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
			phieu.DataSource=dtphieu;
			if (i_phieu!=-1) phieu.SelectedValue=i_phieu.ToString();
			else phieu.SelectedIndex=0;

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=dtkp;
			if (i_makp!=-1) makp.SelectedValue=i_makp.ToString();
			else makp.SelectedIndex=0;
            b1kho = d.b1kho(s_makho);
            load_phieu();
		}

        private void load_phieu()
        {
            if (bThua) sql = "select * from " + user + ".d_loaiphieu where id=0";
            else
            {
                string s_phieu = "";
                string tenfile = (i_loai == 2) ? "d_bucstt" : "d_xuatsdct";
                sql = "select distinct a.phieu from " + xxx + ".d_xuatsdll a," + xxx + "."+tenfile+" b where a.id=b.id and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (makp.SelectedIndex != -1)
                {
                    if (bIntheocstt) sql += " and a.makp=" + int.Parse(makp.SelectedValue.ToString());
                    else sql += " and a.makhoa=" + int.Parse(makp.SelectedValue.ToString());
                }
                if (s_makho != "") sql += " and b.makho in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    s_phieu += r["phieu"].ToString() + ",";

                sql = "select * from " + user + ".d_loaiphieu where nhom=" + i_nhom;
                sql += " and loai=" + i_loai;
                if (s_phieu != "") sql += " and id in (" + s_phieu.Substring(0, s_phieu.Length - 1) + ")";
                sql += " order by stt";
            }
            dtphieu = d.get_data(sql).Tables[0];
            phieu.DataSource = dtphieu;
        }

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
                load_phieu();
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phieu.SelectedIndex==-1) phieu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			bOk=true;
			bool bChieu_sang=m.bChieu_sang;
			if (bChieu_sang)
			{
				DataRow r1,r2;
				r2=d.getrowbyid(dtphieu,"id="+int.Parse(phieu.SelectedValue.ToString()));
				if (r2!=null)
				{
					if (r2["buoi"].ToString()=="0")
					{
						r1=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
						if (r1!=null)
						{
							if (d.get_ttngay(s_ngay,r1["makp"].ToString()))
							{
								MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+" "+lan.Change_language_MessageText("viện phí đã in danh sách thu tiền")+"\n"+lan.Change_language_MessageText("Yêu cầu chọn phiếu buổi chiều !"),d.Msg);
								return;
							}
						}
					}
				}
			}
			if (makp.SelectedIndex==-1 || phieu.SelectedIndex==-1)
			{
				if (makp.SelectedIndex==-1) makp.Focus();
				else phieu.Focus();
				return;
			}
			i_makp=int.Parse(makp.SelectedValue.ToString());
			i_phieu=int.Parse(phieu.SelectedValue.ToString());
            DataTable tmp=d.get_data("select * from "+xxx+".d_daduyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and makp="+i_makp+" and loai="+i_loai+" and phieu="+i_phieu+" and makp="+i_makp).Tables[0];
            if (tmp.Select("done=1").Length>0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Phiếu này đã đánh dấu phát")+"\n"+lan.Change_language_MessageText("Không cho phép hủy ?"), d.Msg);
                makp.Focus();
                return;
            }
            try
            {
                bDuyettreole = tmp.Select("duyettreole=1").Length > 0;
            }
            catch { bDuyettreole = false;}
			string tenfile=(i_loai==2 || bBuhaophi)?"d_bucstt":"d_xuatsdct";
			sql="select distinct a.mabn,a.maql";
            if (!bIntheocstt) sql += ",a.makhoa";
            sql += ",b.mabd";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+"."+tenfile+" b where a.id=b.id and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" and a.nhom="+i_nhom+" and a.loai="+i_loai+" and a.phieu="+i_phieu;
            if (i_loai == 2)
            {
                if (bIntheocstt) sql += " and a.makp=" + i_makp;
                else sql += " and a.makhoa=" + i_makp;
            }
            else sql += " and a.makhoa=" + i_makp;
			sql+=" and a.thuoc="+i_thuoc;
			if (bBuhaophi || i_loai==4 || bThua || i_thuoc==2) sql+=" and a.maql=0";
			else sql+=" and a.maql<>0";
			tmp=d.get_data(sql).Tables[0];
			if (tmp.Rows.Count==0)
			{
                if (kiemtra())
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã thu hồi xong."), lan.Change_language_MessageText("Thu hồi"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    d.close();this.Close();
                    return;
                }
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
                f_thuhoi_phieu_biloi(s_mmyy, s_ngay, i_makp, i_nhom, i_phieu);
				makp.Focus();
				return;
			}
            string s_makhoa = "";
            if (!bIntheocstt)
                foreach (DataRow r in tmp.Select("true", "makhoa"))
                    if (s_makhoa.IndexOf(r["makhoa"].ToString().Trim() + ",") == -1) s_makhoa += r["makhoa"].ToString().Trim() + ",";

            bool bFound = false;
            if (i_loai == 1 || i_loai == 3)
            {
                string s_id="";
                sql = "select distinct a.id";
                sql += " from " + xxx + ".d_xuatsdll a," + xxx + "." + tenfile + " b where a.id=b.id and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.phieu=" + i_phieu;
                sql += " and a.makhoa=" + i_makp;
                sql += " and a.thuoc=" + i_thuoc;
                sql += " and a.maql<>0";
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    s_id += r["id"].ToString().Trim() + ",";
                if (s_id != "")
                {
                    string _mabn="";
                    foreach(DataRow r in d.get_data("select a.mabn,b.hoten from " + xxx + ".d_tienthuoc a,"+user+".btdbn b where a.mabn=b.mabn and a.id in (" + s_id.Substring(0, s_id.Length - 1) + ") and a.done=1 order by a.mabn").Tables[0].Rows)
                        if (_mabn.IndexOf(r["mabn"].ToString()+" "+r["hoten"].ToString().Trim())==-1) _mabn+=r["mabn"].ToString()+" "+r["hoten"].ToString().Trim()+"\n";
                    if (_mabn != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Những người bệnh sau :\n"+_mabn+" đã thanh toán, không được thu hồi !"), d.Msg);
                        makp.Focus();
                        return;
                    }
                }
            }
            if (i_loai == 1)
            {
                string s_mabd = "", s_maql = "";
                foreach (DataRow r in tmp.Select("true", "maql"))
                    if (s_maql.IndexOf(r["maql"].ToString().Trim() + ",") == -1) s_maql += r["maql"].ToString().Trim() + ",";
                sql = "select distinct c.mabd, b.mabn, to_char(a.ngay,'dd/mm/yyyy') as ngay, d.ten as phieu from xxx.d_duyet a,xxx.d_hoantrall b,xxx.d_hoantract c,"+user+".d_loaiphieu d where a.id=b.idduyet and b.id=c.id and a.phieu=d.id";
                sql += " and a.done=2 and c.slthuc>0 and a.nhom=" + i_nhom + " and a.loai=3 and to_char(c.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and a.makp=" + i_makp;
                if (s_maql != "") sql += " and b.maql in (" + s_maql.Substring(0, s_maql.Length - 1) + ")";
                string s_ptra = "";
                foreach (DataRow r in d.get_data_mmyy(sql, s_ngay, s_ngay, true).Tables[0].Rows)
                {
                    s_mabd += r["mabd"].ToString().PadLeft(7, '0') + ",";
                    s_ptra = "Ngày: " + r["ngay"].ToString() + "- Phiếu: " + r["phieu"].ToString() + "- MSBN: " + r["mabn"].ToString();
                }
                if (s_mabd != "")
                {
                    foreach (DataRow r in tmp.Rows)
                    {
                        if (s_mabd.IndexOf(r["mabd"].ToString().PadLeft(7, '0')) != -1)
                        {
                            bFound = true;
                            break;
                        }
                    }
                    if (bFound)
                    {
                        MessageBox.Show(phieu.Text + " có hoàn trả, không được thu hồi.\nPhải thu hồi phiếu hoàn trả trước !.\n"+s_ptra, d.Msg);
                        makp.Focus();
                        return;
                    }
                }
            }
            else if (i_loai == 2 && d.bThuhoi_kiemtra_tutruc(i_nhom))
            {
                bFound = false;
                DataRow r1;
                sql = "select a.makp, b.sttt,b.makho,sum(b.soluong) as soluong from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b where a.id=b.id and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                sql += " and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.phieu=" + i_phieu;
                if (bIntheocstt) sql += " and a.makp=" + i_makp;
                else sql += " and a.makhoa=" + i_makp;
                sql += " and a.thuoc=" + i_thuoc;
                if (bBuhaophi || i_loai == 4 || bThua || i_thuoc == 2) sql += " and a.maql=0";
                else sql += " and a.maql<>0";
                sql += " group by b.sttt,b.makho,a.makp";
                //
                DataSet lds = d.get_data(sql);
                string s_makp_tt = ",";
                foreach (DataRow dr in lds.Tables[0].Rows)
                {
                    s_makp_tt += (s_makp_tt.IndexOf("," + dr["makp"].ToString() + ",") < 0) ? dr["makp"].ToString() + "," : "";
                }
                if (s_makp_tt.Trim().Trim(',') == "") s_makp_tt = i_makp.ToString();
                else s_makp_tt = s_makp_tt.Trim().Trim(',');
                //
                tmp = d.get_data("select makp,makho,stt,sum(tondau+slnhap-slxuat) as soluong from "+xxx+".d_tutrucct where makp in (" + s_makp_tt.Trim().Trim(',') + ") group by makho,stt,makp").Tables[0];
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    r1 = d.getrowbyid(tmp, "makho=" + int.Parse(r["makho"].ToString()) + " and stt=" + decimal.Parse(r["sttt"].ToString()) + " and makp=" + r["makp"].ToString());
                    if (r1 != null)
                    {
                        if (decimal.Parse(r["soluong"].ToString()) > decimal.Parse(r1["soluong"].ToString()))
                        {
                            bFound = true;
                            break;
                        }
                    }
                }
                if (bFound)
                {
                    MessageBox.Show(phieu.Text + " có xuất, không được thu hồi.\nPhải thu hồi phiếu xuất tủ trực trước !", d.Msg);
                    makp.Focus();
                    return;
                }
            }
			if (bKiemtra)
			{
				if (i_loai==1 || (i_loai==3 && i_thuoc==1 && !bThua))
				{
					bFound=false;
					DataRow r2;
					DataTable dthoten=new DataTable();
					string s_ravien="";
					r2=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
					if (r2!=null)
					{
						sql="select maql from "+user+".xuatvien where makp='"+r2["makp"].ToString()+"'";
						dthoten=d.get_data(sql).Tables[0];
						bFound=true;
					}
					if (bFound)
					{
						foreach(DataRow r in tmp.Rows)
						{	
							r2=d.getrowbyid(dthoten,"maql="+decimal.Parse(r["maql"].ToString()));
							if (r2!=null)
								s_ravien+=r["mabn"].ToString()+"\n";
						}
					}
					if (s_ravien!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện")+"\n"+s_ravien+lan.Change_language_MessageText("không được thu hồi !"),d.Msg);
						return;
					}
				}
			}
			Cursor=Cursors.WaitCursor;
            if (i_loai == 2 && d.bBucstt_tronso(i_nhom))
            {
                if (s_makhoa != "")
                    sql = "select idduyet from "+xxx+".d_ngayduyet where nhom=" + i_nhom + " and loai=" + i_loai + " and phieu=" + i_phieu + " and makp in (" + s_makhoa.Substring(0, s_makhoa.Length - 1) + ") and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                else
                    sql = "select idduyet from "+xxx+".d_ngayduyet where nhom=" + i_nhom + " and loai=" + i_loai + " and phieu=" + i_phieu + " and makp=" + i_makp + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (s_makho != "") sql += " and makho='" + s_makho + "'";
                tmp = d.get_data(sql).Tables[0];
                string sid = "";
                foreach (DataRow r in tmp.Rows) sid += r["idduyet"].ToString() + ",";
                string sql1="select to_char(a.ngay,'dd/mm/yyyy') as ngay,c.ten from xxx.d_xuatsdll a,xxx.d_bucstt b,"+user+".d_loaiphieu c where a.id=b.id and a.phieu=c.id and b.sltreo>0 ";
                if (sid!="") sql1 += " and a.idduyet in (" + sid.Substring(0, sid.Length - 1) + ")";
                sql1 += " and a.makp=" + i_makp + " and a.nhom=" + i_nhom;
                sid = "";

                ////Binh 23032012: comment --> chua hieu kiem tra de lam gi???
                ////foreach(DataRow r in d.get_data_mmyy(sql1, s_ngay, s_ngay, 30).Tables[0].Rows)
                ////{
                ////    sid = "Ngày " + r["ngay"].ToString() + "\nPhiếu " + r["ten"].ToString() + " có duyệt treo\nPhải thu hồi phiếu này trước !";
                ////    break;
                ////}
                ////if (sid != "")
                ////{
                ////    MessageBox.Show(sid, d.Msg);
                ////    Cursor = Cursors.Default;
                ////    return;
                ////}
                foreach (DataRow r in tmp.Rows)
                {
                    sql = "select b.* from xxx.d_xtutrucll a,"+user+".d_treoduyet b where a.id=b.id and a.idduyet=" + decimal.Parse(r["idduyet"].ToString());
                    foreach (DataRow r1 in d.get_data_mmyy(sql, s_ngay, s_ngay, 30).Tables[0].Rows)
                    {
                        if (d.get_data("select a.* from " + xxx + ".d_xuatsdll a," + xxx + ".d_bucstt b where a.id=b.id and a.idduyet=" + decimal.Parse(r1["id"].ToString()) + " and b.sttduyet=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count == 0)
                        {
                            d.execute_data("update " + user + ".d_treoduyet set slthuc=0 where id=" + decimal.Parse(r1["id"].ToString()) + " and stt=" + int.Parse(r1["stt"].ToString()));
                        }
                    }
                }
            }
            d.upd_duyet(s_mmyy, i_makp, i_nhom, i_loai, i_phieu, s_ngay, (bNguoiduyet_nguoithuhoi ? s_makho : ""));//s_makho
			d.upd_theodoiduyet(s_mmyy,s_ngay,i_nhom,i_loai,i_makp,1);
            d.upd_thuhoi(s_mmyy, i_nhom, s_ngay, i_loai, i_makp, i_userid, i_phieu);
			sql="select distinct a.id, to_char(a.ngayylenh,'dd/mm/yyyy') as ngayylenh from "+xxx+".d_xuatsdll a,"+xxx+"."+tenfile+" b where a.id=b.id and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
            sql += " and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.phieu=" + i_phieu;
            if (i_loai == 2)
            {
                if (bIntheocstt) sql += " and a.makp=" + i_makp;
                else sql += " and a.makhoa=" + i_makp;
            }
            else sql += " and a.makhoa=" + i_makp;
			sql+=" and a.thuoc="+i_thuoc;
            if (b1kho) sql += " and a.lydo=" + int.Parse(s_makho.Substring(0, s_makho.Length - 1));
			if (bBuhaophi || i_loai==4 || bThua || i_thuoc==2) sql+=" and a.maql=0";
			else sql+=" and a.maql<>0";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                d.del(s_mmyy, tenfile, decimal.Parse(r["id"].ToString()), dtll, i_loai, bBuhaophi, i_nhom, i_phieu, s_ngay, i_userid, bDuyettreole, r["ngayylenh"].ToString());
            }
            //
            string file = (i_loai == 2) ? "d_thucbucstt" : "d_thucxuat";
            sql = "select distinct a.id from " + xxx + ".d_xuatsdll a," + xxx + "." + file + " b where a.id=b.id and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            sql += " and a.nhom=" + i_nhom + " and a.loai=" + i_loai + " and a.phieu=" + i_phieu;
            if (i_loai == 2)
            {
                if (bIntheocstt) sql += " and a.makp=" + i_makp;
                else sql += " and a.makhoa=" + i_makp;
            }
            else sql += " and a.makhoa=" + i_makp;
            sql += " and a.thuoc=" + i_thuoc;
            if (b1kho) sql += " and a.lydo=" + int.Parse(s_makho.Substring(0, s_makho.Length - 1));
            if (bBuhaophi || i_loai == 4 || bThua || i_thuoc == 2) sql += " and a.maql=0";
            else sql += " and a.maql<>0";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                d.execute_data("delete from " + xxx + "."+file+" where id=" + decimal.Parse(r["id"].ToString()));
            //
			dtct.Clear();
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
				d.execute_data("delete from "+xxx+".d_daduyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and makp="+i_makp+" and loai="+i_loai+" and phieu="+i_phieu+" and makho="+int.Parse(r["id"].ToString()));
            if (d.bKiemtra_duyet(i_nhom)) d.upd_tonkho(s_mmyy, i_nhom, 0);
            int itable = d.tableid(s_mmyy, "d_ngayduyet");
            d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
            d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", i_nhom.ToString() + "^" + i_loai.ToString() + "^" + i_makp.ToString() + "^" + s_ngay + "^0^" + i_phieu.ToString() + "^" + s_makho + "^0");

			Cursor=Cursors.Default;
			if (d.bTinnhan(i_nhom))
			{
				DataRow r=d.getrowbyid(dtkp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null)
				{
					if (r["computer"].ToString()!="")
						d.netsend(d.sDomain(i_nhom),r["computer"].ToString().Trim(),s_noidung+" KHOA "+m.khongdau(makp.Text)+" PHIEU "+m.khongdau(phieu.Text)+" DA THU HOI !");
				}
			}
			//
			MessageBox.Show(lan.Change_language_MessageText("Đã thu hồi xong."),lan.Change_language_MessageText("Thu hồi"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			d.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

        private void makp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == makp) load_phieu();
        }

        private bool kiemtra()
        {
            string f1="",f2 = "";
            bool bFound = true;
            switch (i_loai)
            {
                case 1: f1 = "xxx.d_dutru"; break;
                case 2: f1 = "xxx.d_xtutruc"; break;
                case 3: f1 = "xxx.d_hoantra"; break;
                default: f1 = "xxx.d_haophi"; break;
            }
            f2 = f1 + "ct"; f1 += "ll";
            sql = "select distinct b.idduyet from xxx.d_duyet a," + f1 + " b," + f2 + " c," + user + ".d_dmbd d ";
            sql += "where a.id=b.idduyet and b.id=c.id and c.mabd=d.id ";
            sql += "and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            sql += "and a.loai=" + i_loai + " and a.phieu=" + i_phieu;
            if (i_loai == 2)
            {
                if (bIntheocstt) sql += " and a.makp=" + i_makp;
                else sql += " and a.makhoa=" + i_makp;
            }
            else sql += " and a.makhoa=" + i_makp;
            DataTable dt = d.get_thuoc(s_ngay,s_ngay, sql).Tables[0];
            bFound = dt.Rows.Count > 0;
            if (bFound)
            {
                decimal id=decimal.Parse(dt.Rows[0]["idduyet"].ToString());
                sql = "update " + f2 + " set slthuc=0 where id in (select a.id from " + f1 + " a,xxx.d_duyet b where a.idduyet=b.id ";
                sql += "and b.id="+id;
                sql += ")";
                d.exe_thuoc(s_ngay,s_ngay, sql);
                d.upd_duyet(s_mmyy, i_makp, i_nhom, i_loai, i_phieu, s_ngay,"");
            }
            return bFound;
        }

        private void f_thuhoi_phieu_biloi(string mmyy, string sngay, int imakp, int inhom, int iphieu)
        {
            string sxxx = d.user + mmyy;
            if (inhom != 2)
            {
                sql = "delete from " + sxxx + ".d_thucxuat where id in(select id from " + sxxx + ".d_xuatsdll where makp=" + imakp + " and nhom=" + inhom + " and phieu=" + iphieu + " and to_char(ngay,'dd/mm/yyyy')='" + sngay + "')";
                d.execute_data(sql);

                sql = "delete from " + sxxx + ".d_xuatsdct where id in(select id from " + sxxx + ".d_xuatsdll where makp=" + imakp + " and nhom=" + inhom + " and phieu=" + iphieu + " and to_char(ngay,'dd/mm/yyyy')='" + sngay + "')";
                d.execute_data(sql);
            }
            else
            {
                sql = "delete from " + sxxx + ".d_thucbucstt where id in(select id from " + sxxx + ".d_xuatsdll where makp=" + imakp + " and nhom=" + inhom + " and phieu=" + iphieu + " and to_char(ngay,'dd/mm/yyyy')='" + sngay + "')";
                d.execute_data(sql);

                sql = "delete from " + sxxx + ".d_bucstt where id in(select id from " + sxxx + ".d_xuatsdll where makp=" + imakp + " and nhom=" + inhom + " and phieu=" + iphieu + " and to_char(ngay,'dd/mm/yyyy')='" + sngay + "')";
                d.execute_data(sql);
            }

            sql = "delete from " + sxxx + ".d_xuatsdll where id in(select id from " + sxxx + ".d_xuatsdll where makp=" + imakp + " and nhom=" + inhom + " and phieu=" + iphieu + " and to_char(ngay,'dd/mm/yyyy')='" + sngay + "')";
            d.execute_data(sql);

            sql = "delete from " + sxxx + ".d_ngayduyet where makp=" + imakp + " and nhom=" + inhom + " and phieu=" + iphieu + " and to_char(ngay,'dd/mm/yyyy')='" + sngay + "'";
            d.execute_data(sql);
        }

        private void f_capnhat_db(string mmyy)
        {
            if (d.bMmyy(mmyy))
            {
                //string xxx = d.user + mmyy;
                //sql = "select userid from " + xxx + ".d_theodoiduyet where 1=2";
                //try
                //{
                //    if (d.get_data(sql).Tables.Count <= 0)
                //    {
                //        sql = "alter table " + xxx + ".d_theodoiduyet add phieu numeric(7) default 0";
                //        d.execute_data(sql, false);
                //        sql = "alter table " + xxx + ".d_theodoiduyet add userid numeric(7) default 0";
                //        d.execute_data(sql, false);
                //        sql = "alter table " + xxx + ".ngayud add ngayud timestamp default now()";
                //        d.execute_data(sql, false);
                //    }
                //}
                //catch
                //{
                //    sql = "alter table " + xxx + ".d_theodoiduyet add phieu numeric(7) default 0";
                //    d.execute_data(sql, false);
                //    sql = "alter table " + xxx + ".d_theodoiduyet add userid numeric(7) default 0";
                //    d.execute_data(sql, false);
                //    sql = "alter table " + xxx + ".ngayud add ngayud timestamp default now()";
                //    d.execute_data(sql, false);
                //}
                if (xxx == "") xxx = d.user + mmyy;
                sql = "select phieu from " + xxx + ".d_thuhoi where 1=2";
                DataSet lds = d.get_data(sql);
                try
                {
                    if (lds==null || lds.Tables.Count<=0)//(d.get_data(sql).Tables.Count <= 0)
                    {
                        sql = " create table " + xxx + ".d_thuhoi (nhom numeric(3), ngay timestamp, loai numeric(3) default 0, makp numeric(3), phieu numeric (5) default 0, userid numeric(7) default(0), ngayud timestamp, constraint pk_d_thuhoi primary key(ngayud, loai, phieu, makp, userid) USING INDEX TABLESPACE medi_index) with oids";
                        d.execute_data(sql, false);
                    }
                }
                catch
                {
                    sql = " create table " + xxx + ".d_thuhoi (nhom numeric(3), ngay timestamp, loai numeric(3) default 0, makp numeric(3), phieu numeric (5) default 0, userid numeric(7) default(0), ngayud timestamp, constraint pk_d_thuhoi primary key(ngayud, loai, phieu, makp, userid) USING INDEX TABLESPACE medi_index) with oids";
                    d.execute_data(sql, false);
                }
            }
        }
	}
}
