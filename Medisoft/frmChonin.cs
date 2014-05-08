using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
 
namespace Medisoft
{
    public partial class frmChonin : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush alertBackBrush;
        private System.Drawing.Font alertFont;
        private Brush alertTextBrush;
        private System.Drawing.Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged;
        private string user, sql;
        private int checkCol = 0,i_userid;
        private AccessData m;
        private DataTable dt;
        private DataSet dsnhan;
        private dllReportM.Print print = new dllReportM.Print();
        public frmChonin(AccessData acc,DataTable _dt,DataSet _ds,string ngay,int userid)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; dt = _dt; dsnhan = _ds; ngayvv.Text = ngay; i_userid = userid;
        }

        private void frmChonin_Load(object sender, EventArgs e)
        {
            user = m.user;
            chkXem.Checked = m.bPreview;
            dt.Columns.Add("Chon", typeof(bool));
            foreach (DataRow r in dt.Rows) r["chon"] = false;
            dataGrid1.DataSource = dt;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false; 
            AddGridTableStyle();

            this.disabledBackBrush = new SolidBrush(Color.FromArgb(255, 255, 192));
            this.disabledTextBrush = new SolidBrush(Color.FromArgb(255, 0, 0));

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new System.Drawing.Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new System.Drawing.Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
            butOk.Focus();
       }

       private void AddGridTableStyle()
       {
           DataGridTableStyle ts = new DataGridTableStyle();
           ts.MappingName = dt.TableName;
           ts.AlternatingBackColor = Color.Beige;
           ts.BackColor = Color.GhostWhite;
           ts.ForeColor = Color.MidnightBlue;
           ts.GridLineColor = Color.RoyalBlue;
           ts.HeaderBackColor = Color.MidnightBlue;
           ts.HeaderForeColor = Color.Lavender;
           ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
           ts.SelectionForeColor = Color.PaleGreen;
           ts.RowHeaderWidth = 5;

           FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
           discontinuedCol.MappingName = "chon";
           discontinuedCol.HeaderText = "Chọn";
           discontinuedCol.Width = 30;
           discontinuedCol.AllowNull = false;

           discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
           ts.GridColumnStyles.Add(discontinuedCol);
           dataGrid1.TableStyles.Add(ts);

           FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
           TextCol.MappingName = "mabn";
           TextCol.HeaderText = "Mã BN";
           TextCol.Width = 60;
           TextCol.ReadOnly = true;
           TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           ts.GridColumnStyles.Add(TextCol);
           dataGrid1.TableStyles.Add(ts);

           TextCol = new FormattableTextBoxColumn();
           TextCol.MappingName = "idcls";
           TextCol.HeaderText = "ID CLS";
           TextCol.Width = 70;
           TextCol.ReadOnly = true;
           TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           ts.GridColumnStyles.Add(TextCol);
           dataGrid1.TableStyles.Add(ts);

           TextCol = new FormattableTextBoxColumn();
           TextCol.MappingName = "hoten";
           TextCol.HeaderText = "Họ tên";
           TextCol.Width = 150;
           TextCol.ReadOnly = false;
           TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           ts.GridColumnStyles.Add(TextCol);
           dataGrid1.TableStyles.Add(ts);

           TextCol = new FormattableTextBoxColumn();
           TextCol.MappingName = "tuoi";
           TextCol.HeaderText = "Tuổi";
           TextCol.Width = 30;
           TextCol.ReadOnly = false;
           TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           ts.GridColumnStyles.Add(TextCol);
           dataGrid1.TableStyles.Add(ts);

           TextCol = new FormattableTextBoxColumn();
           TextCol.MappingName = "loai";
           TextCol.HeaderText = "Loại";
           TextCol.Width = 80;
           TextCol.ReadOnly = false;
           TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           ts.GridColumnStyles.Add(TextCol);
           dataGrid1.TableStyles.Add(ts);

           TextCol = new FormattableTextBoxColumn();
           TextCol.MappingName = "vung";
           TextCol.HeaderText = "Vùng";
           TextCol.Width = 150;
           TextCol.ReadOnly = false;
           TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
           ts.GridColumnStyles.Add(TextCol);
           dataGrid1.TableStyles.Add(ts);
       }

       private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
       {
           try
           {
               bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
               if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
               {
                   //e.BackBrush = this.disabledBackBrush;
                   e.ForeBrush = this.disabledTextBrush;
               }
               else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
               {
                   e.BackBrush = this.currentRowBackBrush;
                   e.TextFont = this.currentRowFont;
               }
           }
           catch { }
       }

       private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
       {
           this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
           RefreshRow(e.Row);
           this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
       }
       private void RefreshRow(int row)
       {
           System.Drawing.Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
           rect = new System.Drawing.Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
           this.dataGrid1.Invalidate(rect);
       }

       private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
       {
           if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
               this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
           afterCurrentCellChanged = true;
       }

       private void dataGrid1_Click(object sender, System.EventArgs e)
       {
           System.Drawing.Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
           DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
           BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
           if (afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == checkCol)
           {
               this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
               RefreshRow(hti.Row);
           }
           afterCurrentCellChanged = false;
       }

        private void butCancel_Click(object sender, EventArgs e)
        {
              m.close();this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (dt.Select("chon=true").Length == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn danh sách cần in ?"), LibMedi.AccessData.Msg);
                dataGrid1.Focus();
                return;
            }
            dsnhan.Clear();
            DataRow r;
            DataRow[] r1 = dt.Select("chon=true","mabn,loai,idcls");
            int i=0;
            string _mabn = "";
            while (i<r1.Length)
            {
                _mabn = r1[i]["mabn"].ToString();
                r = dsnhan.Tables[0].NewRow();
                r["mabn"] = r1[i]["mabn"].ToString();
                r["hoten"] = r1[i]["hoten"].ToString();
                r["tuoi"] = r1[i]["tuoi"].ToString();
                r["phai"] = r1[i]["phai"].ToString();
                r["diachi"] = r1[i]["diachi"].ToString().Replace(lan.Change_language_MessageText("Không xác định"),"");
                r["khoa"] = r1[i]["makp"].ToString();
                r["ngay"] = r1[i]["ngay"].ToString();
                r["idcls"] = r1[i]["idcls"].ToString();
                r["bscd"] = r1[i]["bscd"].ToString().Trim().ToUpper() + "/" + r1[i]["bvcd"].ToString().Trim().ToUpper();
                r["bvcd"] = "";
                r["loai"] = r1[i]["loai"].ToString().Trim().ToUpper() + "." + r1[i]["vung"].ToString().Trim().ToUpper();
                r["vung"] = "";
                i++;
                if (i < r1.Length)
                {
                    if (_mabn == r1[i]["mabn"].ToString())
                    {
                        r["mabn"] = r1[i]["mabn"].ToString();
                        r["hoten"] = r1[i]["hoten"].ToString();
                        r["tuoi"] = r1[i]["tuoi"].ToString();
                        r["phai"] = r1[i]["phai"].ToString();
                        r["diachi"] = r1[i]["diachi"].ToString().Replace(lan.Change_language_MessageText("Không xác định"), "");
                        r["khoa"] = r1[i]["makp"].ToString();
                        r["ngay"] = r1[i]["ngay"].ToString();
                        r["idcls"] = r["idcls"].ToString().Trim()+"-"+r1[i]["idcls"].ToString().Trim();
                        if (r["bscd"].ToString().IndexOf(r["bscd"].ToString().Trim() + "-" + r1[i]["bscd"].ToString().Trim().ToUpper() + "/" + r1[i]["bvcd"].ToString().Trim().ToUpper())!=-1) r["bscd"] = r["bscd"].ToString().Trim() + "-" + r1[i]["bscd"].ToString().Trim().ToUpper() + "/" + r1[i]["bvcd"].ToString().Trim().ToUpper();
                        r["bvcd"] = "";
                        r["loai"] = r["loai"].ToString().Trim() + "-" + r1[i]["loai"].ToString().Trim().ToUpper() + "." + r1[i]["vung"].ToString().Trim().ToUpper();
                        r["vung"] = "";
                        i++;
                    }
                    else if (i < r1.Length) 
                    {
                        _mabn = r1[i]["mabn"].ToString();
                        r["mabn1"] = r1[i]["mabn"].ToString();
                        r["hoten1"] = r1[i]["hoten"].ToString();
                        r["tuoi1"] = r1[i]["tuoi"].ToString();
                        r["phai1"] = r1[i]["phai"].ToString();
                        r["diachi1"] = r1[i]["diachi"].ToString().Replace(lan.Change_language_MessageText("Không xác định"), "");
                        r["khoa1"] = r1[i]["makp"].ToString();
                        r["ngay1"] = r1[i]["ngay"].ToString();
                        r["idcls1"] = r1[i]["idcls"].ToString();
                        r["bscd1"] = r1[i]["bscd"].ToString().Trim().ToUpper() + "/" + r1[i]["bvcd"].ToString().Trim().ToUpper();
                        r["bvcd1"] = "";// r1[i]["bvcd"].ToString();
                        r["loai1"] = r1[i]["loai"].ToString().Trim().ToUpper() + "." + r1[i]["vung"].ToString().Trim().ToUpper();
                        r["vung1"] = "";// r1[i]["vung"].ToString();
                        i++;
                        if (i < r1.Length)
                        {
                            if (_mabn == r1[i]["mabn"].ToString())
                            {
                                r["mabn1"] = r1[i]["mabn"].ToString();
                                r["hoten1"] = r1[i]["hoten"].ToString();
                                r["tuoi1"] = r1[i]["tuoi"].ToString();
                                r["phai1"] = r1[i]["phai"].ToString();
                                r["diachi1"] = r1[i]["diachi"].ToString().Replace(lan.Change_language_MessageText("Không xác định"), "");
                                r["khoa1"] = r1[i]["makp"].ToString();
                                r["ngay1"] = r1[i]["ngay"].ToString();
                                r["idcls1"] = r["idcls1"].ToString().Trim() + "-" + r1[i]["idcls"].ToString().Trim();
                                if (r["bscd1"].ToString().IndexOf(r["bscd1"].ToString().Trim() + "-" + r1[i]["bscd"].ToString().Trim().ToUpper() + "/" + r1[i]["bvcd"].ToString().Trim().ToUpper()) != -1) r["bscd1"] = r["bscd1"].ToString().Trim() + "-" + r1[i]["bscd"].ToString().Trim().ToUpper() + "/" + r1[i]["bvcd"].ToString().Trim().ToUpper();
                                r["bvcd1"] = "";
                                r["loai1"] = r["loai1"].ToString().Trim() + "-" + r1[i]["loai"].ToString().Trim().ToUpper() + "." + r1[i]["vung"].ToString().Trim().ToUpper();
                                r["vung1"] = "";
                                i++;
                            }
                        }
                    }
                }
                dsnhan.Tables[0].Rows.Add(r);
            }
            if (chkXem.Checked)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsnhan, "", "rptNhan.rpt", true);
                f.ShowDialog();
            }
            else print.Printer(m, dsnhan, "rptNhan.rpt", "", 1);
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == timkiem) RefreshChildren(timkiem.Text);
        }

        private void timkiem_Enter(object sender, System.EventArgs e)
        {
            timkiem.Text = "";
        }

        private void RefreshChildren(string text)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + text.Trim() + "%' or mabn like '%" + text + "%' or idcls like '%"+text+"%' or vung like '%"+text+"%'";
            }
            catch {}
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            string sql = "true",text=timkiem.Text.Trim();
            if (text != "") sql+=" and (hoten like '%" + text + "%' or mabn like '%" + text + "%' or idcls like '%" + text + "%' or vung like '%" + text + "%')";
            foreach (DataRow r in dt.Select(sql)) r["chon"] = true;
        }

        private void ngayvv_Validated(object sender, EventArgs e)
        {
            if (ngayvv.Text == "")
            {
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = ngayvv.Text.Trim();
            if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
            if (ngayvv.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày!"));
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) return;
            string xxx = user + m.mmyy(ngayvv.Text);
            sql = "select a.mabn,b.hoten,to_number(to_char(now(),'yyyy'))-to_number(b.namsinh) as tuoi,";
            sql += " case when b.phai=0 then 'M' else 'F' end as phai,";
            sql += " trim(b.sonha)||' '||trim(b.thon)||' '||trim(e.tenpxa)||' '||trim(d.tenquan)||' '||c.tentt as diachi,";
            sql += " a.makpcd as makp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += " a.idcls,a.bscd,a.bvcd,f.ten as loai,g.ten as vung ";
            sql += " from " + xxx + ".cls_ketqua a," + user + ".btdbn b," + user + ".btdtt c," + user + ".btdquan d," + user + ".btdpxa e ";
            sql += "," + user + ".cls_loai f," + user + ".cls_noidung g ";
            sql += " where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa ";
            sql += " and a.loai=f.id and a.idvung=g.id and to_char(a.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            sql += " and a.userid=" + i_userid;
            sql += " order by a.idcls";
            dt = m.get_data(sql).Tables[0];
            dt.Columns.Add("Chon", typeof(bool));
            foreach (DataRow r in dt.Rows) r["chon"] = false;
            dataGrid1.DataSource = dt;
        }
    }
}