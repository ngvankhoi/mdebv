using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmGoivpct : Form
    {
        Language lan = new Language();
        private LibVP.AccessData m_v;
        private DataSet m_dsgoivp,m_dsgiavp,ds_dt,dsvienphi;
        private DataRow r;
        private string m_userid = "",m_id_gia="",sql="";
        private frmChonvpct m_frmchonvpct;
        
        public frmGoivpct(LibVP.AccessData v_v, string v_userid, string v_id_gia)
        {
            InitializeComponent();


            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");

            m_v = v_v;
            m_id_gia = v_id_gia;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
            f_Load_Data();
        }
        private void f_Load_Data()
        {
            try  
            {
                string sql = "";
                sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, ";
                sql+="a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, trim(b.ten) as tenloai,b.id as id_loai, ";
                sql+="c.ma as id_nhom, c.ten as tennhom, a.trongoi from medibv.v_giavp a left join ";
                sql+="medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma ";
                sql+="where a.trongoi=0 and a.loaitrongoi=0 ";
                //TU:09/05/2011
                sql += "union all ";
                sql+="select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(dang) as dvt,a.giaban as gia_th,";
                sql+="gia_bh,0 as gia_dv,0 as gia_nn,0 as gia_cs,'"+lan.Change_language_MessageText("Thuốc")+"' as tenloai,-999 as id_loai,";//-999 as id_loai
                sql += "c.ma as id_nhom, '" + lan.Change_language_MessageText("Thuốc") + "' as tennhom,0 as trongoi from " + m_v.user + ".d_dmbd a," + m_v.user + ".d_dmnhom b, ";
                sql += "" + m_v.user + ".v_nhomvp c where a.manhom=b.id and b.nhomvp=c.ma ";
                //end Tu
                //sql+="order by b.ten,b.stt, b.id, a.ten,a.stt";
                sql += "order by ten, id, ten";
                m_dsgiavp = m_v.get_data(sql);
                m_frmchonvpct = new frmChonvpct(m_v, m_userid, "GIA_TH", m_dsgiavp);
                m_frmchonvpct.ShowInTaskbar = false;

                ds_dt = m_v.get_data("select madoituong,doituong from "+m_v.user+".doituong order by madoituong");
                r = ds_dt.Tables[0].NewRow();
                r["madoituong"] = "0";
                r["doituong"] = " ";
                ds_dt.Tables[0].Rows.InsertAt(r, 0);

                Col_dt.DataSource = ds_dt.Tables[0]; 
                Col_dt.DisplayMember = "doituong";
                Col_dt.ValueMember = "madoituong";                
                Col_dt.DataPropertyName = "madoituong";
                try
                {
                    DataSet ds_tile = m_v.get_data("select giatri from " + m_v.user + ".v_option where ma='nrcMienGiam'");
                    txtTiLe.Value =  int.Parse(ds_tile.Tables[0].Rows[0][0].ToString());
                }
                catch { txtTiLe.Value = 0; }
            }
            catch
            {
            }
        }
        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            f_Load_DG();
           // ttStatus.Text = "";
            sql = "select a.id,a.ten,a.dvt,0 soluong,a.gia_th dongia,0 madoituong,a.id_loai, b.ten tenloai, c.ma id_nhom,a.ma, c.ten tennhom ";
            sql += " from medibv.v_giavp a, medibv.v_loaivp b, medibv.v_nhomvp c where a.id_loai=b.id and b.id_nhom=c.ma ";
            sql += " union all ";
            sql += " select a.id,a.ten||' - '||a.tenhc||' - '||a.hamluong,a.dang dvt,0 soluong,0 dongia,0 madoituong,a.maloai id_loai, b.ten tenloai, a.manhom id_nhom,a.ma, c.ten tennhom  ";
            sql += " from medibv.d_dmbd a, medibv.d_dmloai b, medibv.d_dmnhom c where a.maloai=b.id and a.manhom=c.id";
            dsvienphi=m_v.get_data(sql);
            listvp.DataSource = dsvienphi.Tables[0];
            listvp.DisplayMember = "ma";
            listvp.ValueMember = "ten";
        }
        private void f_Load_DG()
        {
            try
            {
                txtTim.Text = lan.Change_language_MessageText("Tìm kiếm");
                string sql = "";
                sql = "select distinct nvl(b.id,f.id) as id, a.stt,nvl(b.ma,f.ma) as ma,nvl(b.ten,f.ten) as ten,nvl(b.dvt,f.dang) as dvt,a.soluong as soluong, a.soluong*a.sotien as sotien";
                sql+=", c.ten as tenloai, nvl(d.ten,e.ten) as tennhom, nvl(c.id,-999) as id_loai,nvl(d.ma,e.id) as id_nhom,a.madoituong ";
                sql+="from medibv.v_trongoi a left join medibv.v_giavp b on a.id_gia=b.id left join ";
                sql+="medibv.v_loaivp c on b.id_loai=c.id left join medibv.v_nhomvp d on c.id_nhom=d.ma ";
                sql += "left join medibv.d_dmbd f on a.id_gia=f.id left join medibv.d_dmnhom e on f.manhom=e.id ";
                sql += "where a.id_gia<>0 and a.id=" + m_id_gia;// b.hide=0 and  
                m_dsgoivp = m_v.get_data(sql);
                dataGridView1.DataSource = m_dsgoivp.Tables[0];
                
                txtTim_TextChanged(null, null);
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private void f_Add(string v_mavp)
        {
            try
            {
                DataRow r1;
                int stt = 1;
                foreach(string atmp  in v_mavp.Split(','))
                {
                    if (m_dsgoivp.Tables[0].Select("id=" + atmp).Length <= 0)
                    {
                        foreach(DataRow r in m_dsgiavp.Tables[0].Select("id="+atmp))
                        {
                            r1 = m_dsgoivp.Tables[0].NewRow();
                            r1["id"] = r["id"].ToString();
                            r1["stt"] = stt;
                            r1["ma"] = r["ma"].ToString();
                            r1["ten"] = r["ten"].ToString();
                            r1["dvt"] = r["dvt"].ToString();
                            r1["soluong"] = 1;
                            r1["sotien"] = r["gia_th"].ToString();
                            r1["id_nhom"] = r["id_nhom"].ToString();
                            r1["tennhom"] = r["tennhom"].ToString();
                            r1["id_loai"] = r["id_loai"].ToString();
                            r1["tenloai"] = r["tenloai"].ToString();
                            r1["madoituong"] = "5";
                            m_dsgoivp.Tables[0].Rows.Add(r1.ItemArray);
                            stt++;
                        }
                    }
                }
            }
            catch
            {
            }
            f_Tinhtien();
        }
        private void f_Filter()
        {
            try
            {
                string aft = "";
                if (txtTim.Text.Trim() != "" && txtTim.Text.Trim() != lan.Change_language_MessageText("Tìm kiếm"))
                {
                    aft = "(ma like '%" + txtTim.Text.Replace("'", "''") + "%' or ten like '%" + txtTim.Text.Replace("'", "''") + "%' or dvt like '%" + txtTim.Text.Replace("'", "''") + "%' or tenloai like '%" + txtTim.Text.Replace("'", "''") + "%' or tennhom like '%" + txtTim.Text.Replace("'", "''") + "%')";
                }

                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
            }
            catch
            {
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            f_Filter();
        }
        private void butIn_Click(object sender, EventArgs e)
        {
            try
            {
                //m_dsgoivp.WriteXml("v_goivp.xml",XmlWriteMode.WriteSchema);
                string aten = "";
                try
                {
                    aten = m_v.get_data("select ten from medibv.v_giavp where id="+m_id_gia).Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    aten = "";
                }
                int tylegiamgia = int.Parse(txtTiLe.Value.ToString());
                frmReport af = new frmReport(m_v, m_dsgoivp.Tables[0], "v_goivp.rpt", "", "", tylegiamgia.ToString(), "", aten, "", "", "", "", "Gói viện phí", 1, true);
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private int TiLeGiam()
        {
           
            //foreach (Control a in frmNew.Controls)
            //{
            //    if (a.Name == "nrcMienGiam")
            //    {
            //        return int.Parse(a.Text);
            //    }
            //}
            return 0;
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_DG();
            }
            catch
            {
            }
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ads = m_dsgoivp;
                int n=ads.Tables[0].Rows.Count;
                m_v.execute_data("delete from medibv.v_trongoi where id = " + m_id_gia.ToString());
                if(n>0)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật chi tiết gói viện phí (") + n.ToString() + " Mục)?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        //ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        decimal i = 0, aid = 0, aid_nhom = 0, aid_loai = 0, aid_gia = 0, asotien = 0, astt = 1, adongia = 0, asoluong = 0, adoituong = 0;
                        try
                        {
                            aid = decimal.Parse(m_id_gia);
                        }
                        catch
                        {
                            aid=0;
                        }
                        if (aid == 0)
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chưa chọn giá viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                      
                        foreach (DataRow r in ads.Tables[0].Rows)
                        {
                            i++;
                            try
                            {
                                aid_nhom = decimal.Parse(r["id_nhom"].ToString());
                            }
                            catch
                            {
                                aid_nhom = 0;
                            }
                            try
                            {
                                aid_loai = decimal.Parse(r["id_loai"].ToString());
                            }
                            catch
                            {
                                aid_loai = 0;
                            }
                            try
                            {
                                aid_gia = decimal.Parse(r["id"].ToString());
                            }
                            catch
                            {
                                aid_gia = 0;
                            }
                            try
                            {
                                astt = decimal.Parse(r["stt"].ToString());
                            }
                            catch
                            {
                                astt = 1;
                            }
                            try
                            {
                                asotien = decimal.Parse(r["sotien"].ToString());
                            }
                            catch
                            {
                                asotien = 0;
                            }
                            try
                            {
                                asoluong = decimal.Parse(r["soluong"].ToString());
                            }
                            catch
                            {
                                asoluong = 1;
                            }
                            try
                            {
                                adoituong = decimal.Parse(r["madoituong"].ToString());
                            }
                            catch
                            {
                                adoituong = 0;
                            }
                            if (asoluong < 0)
                            {
                                asoluong = 1;
                            }
                            adongia += asotien;
                            try
                            {
                                //ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:")+" " + i.ToString() + "/" + n.ToString() + " !";                                
                                m_v.execute_data("insert into medibv.v_trongoi (id,id_nhom,id_loai,id_gia,soluong,sotien,stt,madoituong) values(" + aid.ToString() + "," + aid_nhom.ToString() + "," + aid_loai.ToString() + "," + aid_gia.ToString() + "," + asoluong.ToString() + "," + asotien.ToString() + "," + astt.ToString() + "," + adoituong.ToString() + ") ");
                            }
                            catch
                            {
                            }
                        }
                        string aval = m_dsgoivp.Tables[0].Rows.Count > 0 ? "1" : "0";
                        m_v.execute_data("update medibv.v_giavp set trongoi=" + aval + " where id = " + aid.ToString());
                        m_v.execute_data("update medibv.v_giavp set trongoi=0 where trongoi=1 and id not in (select distinct id from medibv.v_trongoi where id_gia<>0)");
                        //ttStatus.Text = lan.Change_language_MessageText("Cập nhật xong!");
                        f_Load_DG();
                        butLuu.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_Set_Fullgrid()
        {
            try
            {
                dataGridView1.Columns["Column_6"].Frozen = !tmn_Fullgrid.Checked;
                dataGridView1.Columns["Column_5"].Frozen = !tmn_Fullgrid.Checked;
                dataGridView1.Columns["Column_4"].Frozen = !tmn_Fullgrid.Checked;
                dataGridView1.Columns["Column_3"].Frozen = !tmn_Fullgrid.Checked;
            }
            catch
            {
            }
        }
        private void tmn_Fullgrid_Click(object sender, EventArgs e)
        {
            f_Set_Fullgrid();
        }

        private void f_Check(DataGridView v_dgv, string v_id, int v_val)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)(BindingContext[v_dgv.DataSource, v_dgv.DataMember]);
                DataView dv = (DataView)(cm.List);
                foreach (DataRow r in dv.Table.Select("id=" + v_id))
                {
                    r["chon"] = v_val;
                }
                v_dgv.Update();
            }
            catch
            {
            }
        }
        private void f_Tinhtien()
        {
            try
            {
                decimal atmp=0,asotien=0;
                foreach (DataRow r in m_dsgoivp.Tables[0].Rows)
                {
                    try
                    {
                        atmp = decimal.Parse(r["sotien"].ToString());
                    }
                    catch
                    {
                        atmp = 0;
                    }
                    if (atmp < 0)
                    {
                        atmp = 0;
                    }
                    r["sotien"] = atmp;
                    asotien += atmp;
                }
                lbSotien.Text = lan.Change_language_MessageText("Cộng giá trọn gói:")+" " + asotien.ToString("###,###,##0.##") + " đồng";
            }
            catch
            {
                lbSotien.Text = lan.Change_language_MessageText("Cộng giá trọn gói: 0 đồng");
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f_Tinhtien();
            }
            catch
            {
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text.Trim().ToLower() == lan.Change_language_MessageText("Tìm kiếm"))
                {
                    txtTim.Text = "";
                }
                f_Filter();
            }
            catch
            {
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text.Trim() == "")
                {
                    txtTim.Text = lan.Change_language_MessageText("Tìm kiếm");
                }
                f_Filter();
            }
            catch
            {
            }
        }

        private void tmn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_frmchonvpct.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmchonvpct.s_mavp != "")
                    {
                        f_Add(m_frmchonvpct.s_mavp);
                    }
                }
            }
            catch
            {
            }
        }

        private void tmn_Rem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView arv=(DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                m_dsgoivp.Tables[0].Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

                m_v.execute_data("delete from medibv.v_trongoi where id=" + m_id_gia + " and id_gia=" + arv["id"].ToString() + "");
                f_Tinhtien();
            }
            catch
            {
            }
        }

        private void tmn_Add_KP_Click(object sender, EventArgs e)
        {
            try
            {                
                DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);

                string id_gia_trongoi=r["id"].ToString();
                if (id_gia_trongoi != "")
                {
                    frmTrongoi_KP af = new frmTrongoi_KP(m_v, id_gia_trongoi,m_id_gia);
                    af.Show();
                }
                else
                {
                    MessageBox.Show("Chưa khai báo giá viện phí cho gói khoa phòng", m_v.s_AppName);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Chưa khai báo giá viện phí cho gói khoa phòng", m_v.s_AppName);               
            }
        }

        private void chkSort_ma_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTen)
            {
                Filt_tenbs(txtTen.Text);
                listvp.BrowseToICD10(txtTen, txtMa, butThem, txtMa.Location.X + txtMa.Width, txtMa.Location.Y-140 + txtMa.Height * 2, txtMa.Width + txtTen.Width + 2, txtMa.Height);//+mabs.Height
            }	
        }
        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listvp.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listvp.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listvp.Visible) listvp.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            

            if (m_v.getrowbyid(m_dsgoivp.Tables[0], "id=" + txtMa.Text.Trim()) == null&&txtTen.Text.Trim()!="")
            {
                DataRow r = m_v.getrowbyid(dsvienphi.Tables[0], "id=" + txtMa.Text.Trim());
                DataRow dr = m_dsgoivp.Tables[0].NewRow();

                dr["id"] = r["id"];
                dr["ma"] = r["ma"];
                dr["ten"] = r["ten"];
                dr["dvt"] = r["dvt"];
                dr["soluong"] = 1;
                dr["madoituong"] = r["madoituong"];
                dr["id_loai"] = r["id_loai"];
                dr["sotien"] = r["dongia"];
                dr["tenloai"] = r["tenloai"];
                dr["id_nhom"] = r["id_nhom"];
                dr["tennhom"] = r["tennhom"];

                m_dsgoivp.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = m_dsgoivp.Tables[0];
                txtTen.Text = "";
                txtTen.Focus();
            }
        }

        private void chkChoSuaGiachitiet_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["Column_8"].ReadOnly = !chkChoSuaGiachitiet.Checked;
        }

    }
}