using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmKythuatxungdot : Form
    {
        Language lan = new Language();
        private LibVP.AccessData m_v;
        private DataSet m_dskythuatxungdot, m_dsgiavp, ds_mavpchong;
        private DataRow r;
        private string m_userid = "", m_id_gia = "", s_vpxungdot = "";
        private frmChonvpct m_frmchonvpct;
        public frmKythuatxungdot(LibVP.AccessData v_v, string v_userid, string v_id_gia)
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
                string sql = "select a.id, trim(a.ma) as ma, trim(a.ten) as ten, 0 as chon,trim(a.dvt) as dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.gia_cs, trim(b.ten) as tenloai,b.id as id_loai, c.ma as id_nhom, c.ten as tennhom, a.trongoi from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma where a.trongoi=0 and a.loaitrongoi=0 order by b.ten,b.stt, b.id, a.ten,a.stt";
                m_dsgiavp = m_v.get_data(sql);
                m_frmchonvpct = new frmChonvpct(m_v, m_userid, "GIA_TH", m_dsgiavp);
                m_frmchonvpct.ShowInTaskbar = false;
            }
            catch
            {
            }
        }
        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            f_Load_DG();
            ttStatus.Text = "";
        }
        private void f_Load_DG()
        {
            string sql="";
            try
            {
                txtTim.Text = lan.Change_language_MessageText("Tìm kiếm");
                foreach (DataRow dr in m_v.get_data(" select id_mavp_chong from medibv.v_giavp_chong where id_mavp=" + m_id_gia).Tables[0].Rows)
                {
                    s_vpxungdot = dr["id_mavp_chong"].ToString();
                }
                //string sql = "select b.id, b.stt,b.ma,b.ten,b.dvt,c.ten as tenloai, d.ten as tennhom, c.id as id_loai,d.ma as id_nhom from medibv.v_giavp_chong a inner join medibv.v_giavp b on a.id_mavp=b.id left join medibv.v_loaivp c on b.id_loai=c.id left join medibv.v_nhomvp d on c.id_nhom=d.ma where  b.hide=0 and  a.id_mavp in( select id_mavp_chong from medibv.v_giavp_chong where id_mavp=" + m_id_gia + ")";
                if(s_vpxungdot!="")
                    sql = "select a.id, a.stt,a.ma,a.ten,a.dvt,b.ten as tenloai, c.ten as tennhom, b.id as id_loai,c.ma as id_nhom from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma where  a.id in(" + s_vpxungdot + " )";
                else
                    sql = "select b.id, b.stt,b.ma,b.ten,b.dvt,c.ten as tenloai, d.ten as tennhom, c.id as id_loai,d.ma as id_nhom from medibv.v_giavp_chong a inner join medibv.v_giavp b on a.id_mavp=b.id left join medibv.v_loaivp c on b.id_loai=c.id left join medibv.v_nhomvp d on c.id_nhom=d.ma where  b.hide=0 and  a.id_mavp in( select id_mavp_chong from medibv.v_giavp_chong where id_mavp=" + m_id_gia + ")";
                m_dskythuatxungdot = m_v.get_data(sql);
                dataGridView1.DataSource = m_dskythuatxungdot.Tables[0];
                txtTim_TextChanged(null, null);
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
                    if (m_dskythuatxungdot.Tables[0].Select("id=" + atmp).Length <= 0)
                    {
                        foreach (DataRow r in m_dsgiavp.Tables[0].Select("id=" + atmp))
                        {
                            r1 = m_dskythuatxungdot.Tables[0].NewRow();
                            r1["id"] = r["id"].ToString();
                            r1["stt"] = stt;
                            r1["ma"] = r["ma"].ToString();
                            r1["ten"] = r["ten"].ToString();
                            r1["dvt"] = r["dvt"].ToString();

                            r1["id_nhom"] = r["id_nhom"].ToString();
                            r1["tennhom"] = r["tennhom"].ToString();
                            r1["id_loai"] = r["id_loai"].ToString();
                            r1["tenloai"] = r["tenloai"].ToString();
                            m_dskythuatxungdot.Tables[0].Rows.Add(r1.ItemArray);
                            stt++;
                        }
                    }
                }
            }
            catch
            {
            }
            
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
                    aten = m_v.get_data("select ten from medibv.v_giavp where id=" + m_id_gia).Tables[0].Rows[0]["ten"].ToString();
                }
                catch
                {
                    aten = "";
                }
                //int tylegiamgia = int.Parse(txtTiLe.Value.ToString());
                frmReport af = new frmReport(m_v, m_dskythuatxungdot.Tables[0], "v_kythuatxungdot.rpt", "", "", "", "", aten, "", "", "", "", "Gói viện phí", 1, true);
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
            string v_giavpxungdot = "";
            try
            {
                DataSet ads = m_dskythuatxungdot;
                int n = ads.Tables[0].Rows.Count;
                m_v.execute_data(" delete from medibv.v_giavp_chong where id_mavp = " + m_id_gia.ToString());
                if(n>0)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật chi tiết gói viện phí (") + n.ToString() + " Mục)?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        decimal i = 0, aid = 0;
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
                                v_giavpxungdot += r["id"].ToString() + ",";
                            }
                            catch
                            {
                               
                            }   
                        }
                        if (v_giavpxungdot != "")
                        {
                            v_giavpxungdot = v_giavpxungdot.Substring(0, v_giavpxungdot.Length - 1);
                            v_giavpxungdot = v_giavpxungdot.Trim();
                        }
                        try
                        {
                            ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:") + " " + i.ToString() + "/" + n.ToString() + " !";
                            m_v.execute_data("insert into medibv.v_giavp_chong (id_mavp,id_mavp_chong) values(" + aid.ToString() + ",'" + v_giavpxungdot + "')");
                        }
                        catch
                        {
                        }
                        
                        string aval = m_dskythuatxungdot.Tables[0].Rows.Count > 0 ? "1" : "0";
                        ttStatus.Text = lan.Change_language_MessageText("Cập nhật xong!");
                        f_Load_DG();
                        butLuu.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            v_giavpxungdot = "";
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
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //f_Tinhtien();
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
                m_dskythuatxungdot.Tables[0].Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                m_v.execute_data("delete from medibv.v_trongoi where id=" + m_id_gia + " and id_gia=" + arv["id"].ToString() + "");
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

    }
}