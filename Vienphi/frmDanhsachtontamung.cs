using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vienphi.VPDatasets;

namespace Vienphi
{
    public partial class frmDanhsachtontamung : Form
    {
        Language lan = new Language();
        private LibVP.AccessData m_v;
        private string m_userid="",m_quyenso="",m_id="",m_ngaythu="";
        private DataSet m_dstamung = new DataSet();
        public frmDanhsachtontamung(LibVP.AccessData v_v, string v_userid)
        {
            try
            {
                InitializeComponent();


                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                lan.Read_dtgrid_to_Xml(dgDanhsach, this.Name + "_" + "dgDanhsach");
                lan.Change_dtgrid_HeaderText_to_English(dgDanhsach, this.Name + "_" + "dgDanhsach");
                m_v = v_v;
                m_userid = v_userid;
                m_v.f_SetEvent(this);
                f_Load_Data();
             //   f_Load_DG();
            }
            catch
            {
            }
        }
       
/// <summary>
/// Kiểm tra dữ liệu tồn tháng trước đã được chuyển sang tháng này chưa nếu chưa thì tạo một BackgroundWork để chuyển tồn.
/// </summary>
/// <returns></returns>
        bool KiemtraChuyenTonTamUng()
        {
            DataTable data = new DataTable();
            if (m_v == null)
                m_v = new LibVP.AccessData();
            using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand("select * from updatedatatontamung order by stt desc ", new Npgsql.NpgsqlConnection(m_v.ConStr)))
            {
                try
                {
                    cmm.Connection.Open();
                    Npgsql.NpgsqlDataReader dtrd = cmm.ExecuteReader();
                    for (int i = 0; i < dtrd.FieldCount; i++)
                    {

                        data.Columns.Add(dtrd.GetName(i), dtrd.GetFieldType(i));
                    }

                    while (dtrd.Read())
                    {
                        DataRow dr = data.NewRow();
                        foreach (DataColumn dc in data.Columns)
                        {
                            dr[dc] = dtrd[dc.ColumnName];
                        }
                        data.Rows.Add(dr);
                    }
                }
                catch
                {
                    using (Npgsql.NpgsqlCommand cmm2 = new Npgsql.NpgsqlCommand("create table updatedatatontamung (stt serial, ngayupdate date,userid number)", new Npgsql.NpgsqlConnection(m_v.ConStr)))
                    {
                        try
                        {
                            cmm2.Connection.Open();
                            cmm2.ExecuteNonQuery();
                            
                        }
                        finally
                        {
                            cmm2.Connection.Close();
                        }
                    }
                }
                finally
                {
                    cmm.Connection.Close();
                }
            }
            if (data.Rows.Count == 0 || (DateTime.Today.Month > ((DateTime)data.Rows[0]["ngayupdate"]).Month))
            {                
                //fst.ThucThi();
                return false;
            }
            else
                return true;
        }

        void fst_HoanTatXuLy()
        {
            f_Load_DG();
        }
        
        public string s_quyenso
        {
            set
            {
                m_quyenso=value;
            }
        }
        public DateTime s_ngay
        {
            set
            {
                txtTN.Value = value;
                txtDN.Value = value;
            }
        }
        public string s_id
        {
            get
            {
                return m_id;
            }
        }
        public string s_ngaythu
        {
            get
            {
                return m_ngaythu;
            }
        }
        private void f_Load_Data()
        {
            dgDanhsach.EndEdit();
            try
            {
                try
                {
                    tmn_Title.Text = m_v.get_data("select hoten from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString().ToUpper();
                    string a = m_v.get_data("select admin from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString();
                    if (a == "1")
                        tmn_DaHoan.Enabled = true;
                }
                catch
                {
                    tmn_Title.Text = "";
                }
                tmn_Fullgrid.Checked = m_v.get_o_fullgrid_frmdanhsachthutamung(m_userid);
                f_Set_Fullgrid();
                //txtLimit.Value = decimal.Parse(m_v.get_o_limit_frmdanhsachthutamung(m_userid).ToString());
                //m_v.set_o_limit_frmtimhoadon(m_userid, txtLimit.Value.ToString());
            }
            catch
            {
            }
        }
        private void f_Load_DG()
        {
            this.Cursor = Cursors.WaitCursor;
            tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
            ParamAsynResult agr = new ParamAsynResult();
            agr.Ngay = txtTN.Value;
            agr.m_v = m_v;
            agr.m_userid = m_userid;
            dgDanhsach.AutoGenerateColumns = false;
            butTim.Enabled = false;
            backgroundWorker1.RunWorkerAsync(agr);
        }

        private void tmn_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void tmn_Boqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tmn_Chon_Click(object sender, EventArgs e)
        {

        }

        private void tmn_Inhoadon_Click(object sender, EventArgs e)
        {
        }

 

        private void frmDanhsachthutamung_Load(object sender, EventArgs e)
        {
            
            if (KiemtraChuyenTonTamUng())
                f_Load_DG();
            else
            {
                frmCapNhatTonTamUng fst = new frmCapNhatTonTamUng(m_v, m_userid);
                fst.progressBar1.Value = 0;
                // fst.Parent = this;
                fst.HoanTatXuLy += new frmCapNhatTonTamUng.XuLyCapNhatTonTamUngHoanTat(fst_HoanTatXuLy);
                fst.Show();
                fst.ThucHien();
                //backgroundWorker1.RunWorkerAsync();
            }
            datasetDanhsachtontamung1.Initialize(m_v.ConStr);
            datasetDanhsachtontamung1.ThongBaoQuaTrinhTai += new datasetDanhsachtontamung.QuaTrinhTai(datasetDanhsachtontamung1_ThongBaoQuaTrinhTai);
        }

        void datasetDanhsachtontamung1_ThongBaoQuaTrinhTai(decimal percent, long curentRecord, long maxRecord, string message)
        {
            toolStrip1.Invoke((MethodInvoker)delegate()
            {
                if (toolStripProgressBar1.Maximum != (int)maxRecord)
                {
                    toolStripProgressBar1.Maximum = (int)maxRecord;
                    toolStripProgressBar1.Step = 1;
                }
                if (curentRecord == 0)
                    toolStripProgressBar1.Value = 0;
                else
                    toolStripProgressBar1.PerformStep();
            });            
        }

        private void txtTN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch
            {
            }
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
            }
            catch
            {
            }
        }

        private void frmDanhsachthutamung_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    m_id = "";
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void txtTN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTN.Value > txtDN.Value)
                {
                    txtDN.Value = txtTN.Value;
                }
            }
            catch
            {
            }
        }

        private void txtDN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDN.Value < txtTN.Value)
                {
                    txtTN.Value = txtDN.Value;
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_TextChanged(object sender, EventArgs e)
       {
            try
            {
                string aft = "";
                string atmp = tmn_Timnhanh.Text.Trim();
                if (atmp.ToLower().Trim() != lan.Change_language_MessageText("tìm kiếm") && atmp.ToLower().Trim() != "")
                {
                    aft = "mabn like '%"+atmp+"%' or hoten like '%"+atmp+"%' or sohieu like '%"+atmp+"%' or sobienlai like '%"+atmp.ToString()+"%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tmn_Timnhanh_Enter(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.LightYellow;
                if (tmn_Timnhanh.Text.Trim().ToLower() == lan.Change_language_MessageText("tìm kiếm"))
                {
                    tmn_Timnhanh.Text = "";
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_Leave(object sender, EventArgs e)
        {
            try
            {
                tmn_Timnhanh.BackColor = Color.White;
                if (tmn_Timnhanh.Text.Trim() == "")
                {
                    tmn_Timnhanh.Text = lan.Change_language_MessageText("Tìm kiếm");
                }
            }
            catch
            {
            }
        }

        private void tmn_Timnhanh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int aid = 0;
                if (e.KeyCode == Keys.Up)
                {
                    if (dgDanhsach.CurrentCell.RowIndex > 0)
                    {
                        aid = dgDanhsach.CurrentCell.RowIndex - 1;
                        dgDanhsach.Rows[aid].Selected = true;
                        dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                        SendKeys.Send("{End}");
                    }
                    else
                        if (dgDanhsach.RowCount > 0)
                        {
                            aid = dgDanhsach.RowCount - 1;
                            dgDanhsach.Rows[aid].Selected = true;
                            dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                }
                else
                    if (e.KeyCode == Keys.Down)
                    {
                        if (dgDanhsach.CurrentCell.RowIndex < dgDanhsach.Rows.Count - 1)
                        {
                            aid = dgDanhsach.CurrentCell.RowIndex + 1;
                            dgDanhsach.Rows[aid].Selected = true;
                            dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                            SendKeys.Send("{End}");
                        }
                        else
                            if (dgDanhsach.RowCount > 0)
                            {
                                aid = 0;
                                dgDanhsach.Rows[aid].Selected = true;
                                dgDanhsach.CurrentCell = dgDanhsach.Rows[aid].Cells[1];
                                SendKeys.Send("{End}");
                            }
                    }
            }
            catch
            {
            }
        }

        private void butTim_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butTim.Focus();
                }
            }
            catch
            {
            }
        }
        private void f_Set_Fullgrid()
        {
            try
            {
                dgDanhsach.Columns["Column2_4"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_3"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_2"].Frozen = !tmn_Fullgrid.Checked;
                dgDanhsach.Columns["Column2_1"].Frozen = !tmn_Fullgrid.Checked;
            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            try
            {
                f_Set_Fullgrid();
                m_v.set_o_fullgrid_frmdanhsachthutamung(m_userid, tmn_Fullgrid.Checked);
            }
            catch
            {
            }
        }

        private void dgDanhsach_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void tmn_ChuyenTon_Click(object sender, EventArgs e)
        {
            frmChuyentontamung frm = new frmChuyentontamung(m_v);//gam 07/09/2011
            //frm.MdiParent = this;
            //frm.ShowInTaskbar = false;
           // frm.MdiParent = this;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            f_Load_DG();
        }

        private void tmn_DaHoan_Click(object sender, EventArgs e)
       {
           dgDanhsach.EndEdit();
           dgDanhsach.RefreshEdit();
           m_dstamung.AcceptChanges();
           string aid = "", asql = "", aexp = "", asql1 = "";
            //bool rchon=false;
           foreach (DataRow dr in m_dstamung.Tables[0].Select("chon=True"))//.Rows )
           {
               aexp = m_v.get_mmyy(dr["ngay"].ToString());
               if (m_v.bMmyy(aexp))
               {
                   aid = dr["id"].ToString();
                   asql = "update " + m_v.user + aexp + ".v_tamung set done=1,ngaytra = to_date( '" + m_v.s_curddmmyyyy + "' ,'ddmmyyyy') where id in (" + aid + ")";
                   asql1 = "update " + m_v.user + m_v.s_curmmyy + ".v_tontamung set done = 1,ngaytra = to_date( '" + m_v.s_curddmmyyyy + "' ,'ddmmyyyy') where id in (" + aid + ")";
                   try
                   {
                       m_v.execute_data(asql);
                       m_v.execute_data(asql1);
                       //MessageBox.Show(aid);
                   }
                   catch
                   {
                   }
               }
           }
            f_Load_DG();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgDanhsach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void tmn_In_Click(object sender, EventArgs e)
        {
            m_dstamung.WriteXml("v_dstontamung.xml", XmlWriteMode.WriteSchema);
            frmReport af = new frmReport(m_v, m_dstamung.Tables[0], "v_tontamung.rpt", "", "", "", "", "", "", "", "", "", "Tồn Tạm Ứng", 1, true);
            af.ShowDialog();
        }

        private void dgDanhsach_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void dgDanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            dgDanhsach.BeginEdit(true);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            decimal asotienton = 0;
            int sohoadon = 0;
            ParamAsynResult arg = (ParamAsynResult)e.Argument;
            
            backgroundWorker1.ReportProgress(0);
            try
            {
                string ngay = arg.Ngay.ToString("dd/MM/yyyy");
                string sql = "", aexp = "", aexp1 = "";
                //try
                //{
                //    alimit = int.Parse(txtLimit.Value.ToString());
                //}
                //catch
                //{
                //    alimit = 0;
                //}m_
                string mmyy = arg.m_v.get_mmyy(txtDN.Value.ToString("dd/MM/yyyy"));
                DataTable dt = new DataTable();
                
                aexp = "where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + ngay + "','dd/mm/yyyy') ";
                aexp1 = " where (to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + ngay +
                    "','dd/mm/yyyy') and a.done=0) or (a.done=1 and  to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" +
                    ngay + "','dd/mm/yyyy') and  to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <=" +
                    " to_date('" + ngay + "','dd/mm/yyyy') ) ";

                //sql = "select case when a.done = 0 then 1 else case when to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" +
                //    txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  then 1 else 0 end end as ton, a.mabn,g.hoten,case when g.ngaysinh is null"+
                //    " then g.namsinh else to_char(g.ngaysinh,'dd/mm/yyyy') end as namsinh,h.ten as gioitinh,a.id,to_char(a.ngay,'dd/mm/yyyy')"+
                //    " as ngay,b.sohieu,to_char(a.sobienlai,'9999999999') as sobienlai,case when a.done = 0 then a.sotien else case when "+
                //    "to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy')  "+
                //    "then a.sotien else 0 end end as sotienton," +
                //    " a.sotien,f.tenkp,d.ten as tenloaidv, e.ten as tenloaibn,a.lanin,c.hoten||' ('||c.userid||')' "+
                //    "as user, trim(g.sonha||' '||g.thon) as diachi"+
                //    " from medibv.v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join "+
                //    "medibv.v_dlogin c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma left join medibv.v_loaibn"+
                //    " e on a.loaibn=e.id left join medibv.btdkp_bv f on a.makp=f.makp left join medibv.btdbn g on a.mabn=g.mabn "+
                //    "left join medibv.dmphai h on g.phai=h.ma " + aexp;

                sql = "select case when a.done = 0 then 1 else case when to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" +
                    ngay + "','dd/mm/yyyy')  then 1 else 0 end end as ton, a.mabn,g.hoten,case when g.ngaysinh is null" +
                    " then g.namsinh else to_char(g.ngaysinh,'dd/mm/yyyy') end as namsinh,h.ten as gioitinh,a.id,to_char(a.ngay,'dd/mm/yyyy')" +
                    " as ngay,b.sohieu,to_char(a.sobienlai,'9999999999') as sobienlai,case when a.done = 0 then a.sotien else case when " +
                    "to_date(to_char(a.ngaytra,'dd/mm/yyyy'),'dd/mm/yyyy') > to_date('" + ngay + "','dd/mm/yyyy')  " +
                    "then a.sotien else 0 end end as sotienton," +
                    " a.sotien,f.tenkp,d.ten as tenloaidv, e.ten as tenloaibn,a.lanin,c.hoten||' ('||c.userid||')' " +
                    "as user, trim(g.sonha||' '||g.thon) as diachi" +
                    " from " + arg.m_v.user + mmyy + ".v_tamung a left join medibv.v_quyenso b on a.quyenso=b.id left join " +
                    "medibv.v_dlogin c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma left join medibv.v_loaibn" +
                    " e on a.loaibn=e.id left join medibv.btdkp_bv f on a.makp=f.makp left join medibv.btdbn g on a.mabn=g.mabn " +
                    "left join medibv.dmphai h on g.phai=h.ma " + aexp;
                //ton tamung

                sql += " union all ";
                sql += " select 1 as ton, a.mabn,g.hoten,case when g.ngaysinh is null then g.namsinh else " +
                    "to_char(g.ngaysinh,'dd/mm/yyyy') end as namsinh,h.ten as gioitinh,a.id,to_char(a.ngay,'dd/mm/yyyy')" +
                    " as ngay,b.sohieu,to_char(a.sobienlai,'9999999999') as sobienlai,a.sotien as sotienton," +
                    " 0 as sotien,f.tenkp,d.ten as tenloaidv, e.ten as tenloaibn,a.lanin,c.hoten||' ('||c.userid||')' " +
                    "as user, trim(g.sonha||' '||g.thon) as diachi";
                sql += " from medibv"+mmyy+".v_tontamung a left join medibv.v_quyenso b on a.quyenso=b.id" +
                    " left join medibv.v_dlogin c on a.userid=c.id left join medibv.v_tenloaivp d on a.loai=d.ma left join" +
                    " medibv.v_loaibn e on a.loaibn=e.id left join medibv.btdkp_bv f on a.makp=f.makp left join medibv.btdbn" +
                    " g on a.mabn=g.mabn left join medibv.dmphai h on g.phai=h.ma " + aexp1;

                arg.Data = arg.m_v.get_data(sql);
                backgroundWorker1.ReportProgress(70);
                arg.Data.Tables[0].Columns.Add("chon", typeof(bool));
                foreach (DataRow r in arg.Data.Tables[0].Rows)
                {
                    r["chon"] = false;
                    sohoadon++;
                    asotienton += decimal.Parse(r["sotienton"].ToString());
                }
                //m_dstamung.Dispose();
                //m_dstamung = new DataSet();
                //m_dstamung.Tables.Add(dt);
                arg.sohoadon = sohoadon;
                arg.asotienton = asotienton;
                e.Result = arg;
                //dataGridView1.DataSource = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtTN.Text.Substring(0, 10), false).Tables[0];
                //dgDanhsach.Update();
                backgroundWorker1.ReportProgress(100);
            }
            catch
            {
                e.Result = null;               

            }
           

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStrip1.Invoke((MethodInvoker)delegate()
            {
                if (e.ProgressPercentage == 0)
                {
                    toolStripProgressBar1.Maximum = 100;
                    toolStripProgressBar1.Value = 0;
                    toolStripProgressBar1.Step = 10;
                }
                this.toolStripProgressBar1.Value = e.ProgressPercentage;
            });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                this.Cursor = Cursors.Arrow; 
            });
            
           
            if (e.Result != null)
            {
                ParamAsynResult result = e.Result as ParamAsynResult;
                m_dstamung = result.Data;
                dgDanhsach.DataSource = result.Data.Tables[0];
                tmn_Sotien.Text = lan.Change_language_MessageText(result.sohoadon.ToString() + " HĐ = " + result.asotienton.ToString("###,###,###,##0.##") + " Đ");
                // sohoadon = 0;
                // asotienton = 0;
                dgDanhsach.EndEdit();
            }
            else
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)(BindingContext[dgDanhsach.DataSource, dgDanhsach.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    dv.Table.Rows.Clear();
                }
                catch
                { 
                }
            }
            toolStripProgressBar1.Value = 0;
            butTim.Enabled = true;
        }
        class ParamAsynResult
        {
            DataSet data;
            public DataSet Data { set { data = value; } get { return data; } }
            DateTime ngayxem;
            public DateTime Ngay { set { ngayxem = value; } get { return ngayxem; } }
            public LibVP.AccessData m_v;
            public string m_userid;
            public decimal asotienton ;
            public int sohoadon;
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           // int rcount = 0;
            //decimal tongtamung = 0;
            foreach (DataGridViewRow dtgr in dataGridView1.Rows)
            {
                dtgr.Cells["stt"].Value = int.Parse(dtgr.Index.ToString())+1;
             //   tongtamung += decimal.Parse(dtgr.Cells["tientamung"].Value.ToString());
            }
            //this.Invoke((MethodInvoker)delegate()
            //{
            //    lb_tongcong.Text = tongtamung.ToString();
            //});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
             dataGridView1.Cursor = Cursors.WaitCursor;
            button1.Enabled = false;
            dataGridView1.DataSource = null;
            datasetDanhsachtontamung1.LoadDataAsyn(int.Parse((bds_thang_nam.Current as DataRowView)["thang"].ToString()),
                int.Parse((bds_thang_nam.Current as DataRowView)["nam"].ToString()), new datasetDanhsachtontamung.TaiHoanTat(XulyLoadHoanTat));
        }
        void XulyLoadHoanTat(datasetDanhsachtontamung.ERROCODE er, datasetDanhsachtontamung data)
        {
            button1.Enabled = true;
            dataGridView1.Focus();
            dataGridView1.Refresh();
            this.Cursor = Cursors.Arrow;
            toolStripProgressBar1.Value = 0;
            dataGridView1.Cursor = Cursors.Arrow;
            dataGridView1.DataSource = bds_DanhSachDongTamUng;
            decimal tong = 0;
            foreach (DataRowView drrr in bds_DanhSachDongTamUng)
            {
                decimal t = 0;
                if (decimal.TryParse(drrr["tientamung"].ToString(), out t))
                {
                    tong += t;
                }
            }
            lb_tongcong.Text = tong.ToString();
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}