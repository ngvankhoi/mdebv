using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using LibVP;

namespace Vienphi
{
    public partial class frmDotKhuyenMai : Form
    {
        private string m_menu_id = "mnukhaibaodotkhuyenmai";
        Language lan = new Language();
        private LibVP.AccessData m_v;
        private string m_id="",m_userid="";
        public frmDotKhuyenMai(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            lan.Read_dtgrid_to_Xml(dataGridView1, this.Name + "_" + "dataGridView1");
            lan.Change_dtgrid_HeaderText_to_English(dataGridView1, this.Name + "_" + "dataGridView1");
            m_v = v_v;
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            f_Load_DotKhuyenMai();
            f_Enable(false);
            ttStatus.Text = "";
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_DotKhuyenMai()
        {
            try
            {

                DataSet ads = m_v.get_data("select to_char(id,'999999999999')as id,ten,to_char(userid,'9999999') as userid,to_char(tungay,'dd/MM/yyyy') as tungay,to_char(denngay,'dd/MM/yyyy') as denngay,tugio,dengio,CASE WHEN HIDE = 0 THEN 'Có' ELSE 'Không ' END AS HIDE,ngayud,theogio,loai from " + m_v.user + ".v_dot_khuyenmai");
                treeView1.Nodes.Clear();
                TreeNode anode;
                foreach (DataRow r in ads.Tables[0].Select("","ten"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.ImageIndex = 0;
                    anode.SelectedImageIndex = 1;
                    anode.Tag = r["id"].ToString();
                    treeView1.Nodes.Add(anode);
                }
                if (ads.Tables[0].Rows.Count == 0)
                {
                    anode = new TreeNode(lan.Change_language_MessageText("{Chưa khai đợt khuyến mãi}"));
                    anode.Tag = "-1";
                    anode.ImageIndex = 2;
                    anode.SelectedImageIndex = 2;
                    treeView1.Nodes.Add(anode);
                }
                if (treeView1.Nodes.Count > 1)
                {
                    anode = new TreeNode(lan.Change_language_MessageText("{Tất cả}"));
                    anode.Tag = "-1";
                    anode.ImageIndex = 3;
                    anode.SelectedImageIndex = 3;
                    treeView1.Nodes.Add(anode);
                }
                if (treeView1.Nodes.Count > 0)
                {
                    treeView1.SelectedNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
                }

                if (ads.Tables[0].Select("id=-1").Length <= 0)
                {
                    DataRow r = ads.Tables[0].NewRow();
                    r["id"] = -1;
                    r["ten"] = "...";
                    ads.Tables[0].Rows.InsertAt(r, ads.Tables[0].Rows.Count);
                }
               dataGridView1.DataSource = ads.Tables[0];
                toolStrip_Tim_TextChanged(null, null);
            }
            catch (Exception ex)
            {
            }
        }
        private void f_Load_Sua()
        {
            try
            {
                DataRowView arv = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                foreach (DataRow r in m_v.get_data("select * from medibv.v_dot_khuyenmai where id ="+arv["id"].ToString()).Tables[0].Rows)
                {
                    //m_id = r["id"].ToString();
                    txtID.Text = r["id"].ToString();
                    txtTen.Text = r["ten"].ToString();
                    chkReadonly.Checked = r["readonly"].ToString() == "1";
                    break;
                }
            }
            catch
            {
            }
        }
        private void f_Load_View()
        {
            try
            {
                if (!butLuu.Enabled)
                {
                    DataRowView r = (DataRowView)(dataGridView1.CurrentRow.DataBoundItem);
                    txtID.Text = r["id"].ToString().Trim();
                    txtTen.Text = r["ten"].ToString();
                    txtTuNgay.Text = r["tungay"].ToString().Substring(0, 10);
                    txtDenNgay.Text = r["denngay"].ToString().Substring(0, 10);
                    chkReadonly.Checked = r["hide"].ToString() == "Không ";
                    string a = r["theogio"].ToString();
                    checkBox1.Checked = r["theogio"].ToString() == "1";
                    cmbLoaikm.SelectedIndex = int.Parse(r["loai"].ToString());
                    txtTuGio.Text = r["tugio"].ToString();
                    txtDenGio.Text = r["dengio"].ToString();
                    f_Enable(false);
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        private void f_Enable(bool v_bool)
        {
            butMoi.Enabled = !v_bool;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool ;//&& m_id != "";
            butXoa.Enabled = !v_bool ;//&& m_id != "";
            butBoqua.Enabled = true;
            txtID.Enabled = false;
            txtTen.Enabled = v_bool;
            cmbLoaikm.Enabled = v_bool;
            txtTuNgay.Enabled = v_bool;
            txtDenNgay.Enabled = v_bool;
            chkReadonly.Enabled = v_bool;
            checkBox1.Enabled = v_bool;
            txtTuGio.Enabled = false;
            txtDenGio.Enabled = false;
           
        }
        private void f_Moi()
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_them(aquyenchitiet))
            {
                MessageBox.Show("Chưa được phân quyền thêm!");
                return;
            }
            try
            {
                txtID.Text = "";
                chkReadonly.Checked = false;
                checkBox1.Checked = false;
                txtTen.Text = "";
                txtTuNgay.Text = "";
                txtDenNgay.Text = "";
                f_Enable(true);
                txtTen.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void butClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void toolStrip_Refresh_Click(object sender, EventArgs e)
        {
            f_Load_DotKhuyenMai();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            f_Load_View();
        }
        private void toolStrip_Tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string aft = "",adkm = "";
                if (toolStrip_Tim.Text != "")
                {
                    aft = "(ten like '%" + toolStrip_Tim.Text.Replace("'","''") + "%' or userid like '%" + toolStrip_Tim.Text.Replace("'","''") + "%')";
                }
                try
                {
                    adkm = treeView1.SelectedNode.Tag.ToString();
                }
                catch
                {
                    adkm = "";
                }
                if(adkm =="-1")
                {
                    adkm = "";
                }
                if (adkm != "")
                {
                    if (aft != "")
                    {
                        aft += " and ";
                    }
                    aft += "id=" + adkm;
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách đợt khuyến mãi (") + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch (Exception ex)
            {
                toolStrip_Title.Text = lan.Change_language_MessageText("Danh sách đợt khuyến mãi");
            }
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            string stugio, sdengio;
            string iddot = "0";

            if (!m_v.f_quyenchitiet_them(aquyenchitiet) && (m_id == "" || m_id == "0"))
            {
                MessageBox.Show("Chưa được phân quyền thêm mới!");
                return;
            }
            else if (!m_v.f_quyenchitiet_sua(aquyenchitiet) && (m_id != "" && m_id != "0"))
            {
                MessageBox.Show("Chưa được phân quyền sửa!");
                return;
            }
            
            try
            {
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập tên đợt khuyến mãi!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (txtTuNgay.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập giờ bắt đầu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTuNgay.Focus();
                    return;
                }
                if (txtDenNgay.Text.Trim() == "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Nhập giờ kết thúc!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDenNgay.Focus();
                    return;
                }
              
                if (!KTNgay(txtTuNgay) || !KTNgay(txtDenNgay))
                {
                    return;
                }
                if (checkBox1.Checked)
                {
                    if (!KTGio(txtTuGio) || !KTGio(txtDenGio))
                    {
                        return;
                    }
                    stugio = txtTuGio.Text;
                    sdengio = txtDenGio.Text;
                }
                else
                {
                    stugio = "00:00";
                    sdengio = "00:00";
                }
                string SdayBegin = txtTuNgay.Text.Substring(3, 3) + txtTuNgay.Text.Substring(0, 3) + txtTuNgay.Text.Substring(6, 4) + " 00:00";
                string SdayEnd = txtDenNgay.Text.Substring(3, 3) + txtDenNgay.Text.Substring(0, 3) + txtDenNgay.Text.Substring(6, 4) + " 00:00";
                DateTime DayBegin = DateTime.Now, DayEnd = DateTime.Now;
                try
                {
                    DayBegin = Convert.ToDateTime(SdayBegin);
                    DayEnd = Convert.ToDateTime(SdayEnd);
                }
                catch (Exception ex)
                {

                }
                if (DayEnd < DayBegin)
                {
                    MessageBox.Show("Ngày hết hạn không được nhỏ hơn ngày bắt đầu !");
                    Mark(0,16,txtDenNgay);
                    return;
                }
                if (DayBegin == DayEnd && int.Parse(sdengio.Substring(0, 2)) == int.Parse(stugio.Substring(0, 2)))
                {
                    if (int.Parse(sdengio.Substring(3, 2)) < int.Parse(stugio.Substring(3, 2)))
                    {
                        MessageBox.Show("Giờ hết hạn không được nhỏ hơn giờ bắt đầu !");
                        Mark(0, 5, txtDenGio);
                        return;
                    }
                }
                if (int.Parse(sdengio.Substring(0, 2)) < int.Parse(stugio.Substring(0, 2)))
                {
                    MessageBox.Show("Giờ hết hạn không được nhỏ hơn giờ bắt đầu !");
                    Mark(0,5,txtDenGio);
                    return;
                }
                DataSet ds = m_v.get_data("select * from medibv.v_dot_khuyenmai where ten ='" + txtTen.Text.Trim() + "' and id <> " + txtID.Text.Trim());
                if (ds == null)
                {
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Tên đợt đã tồn tại, chọn tên khác!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                    return;
                }
                if (txtID.Text == "")
                {
                    iddot = get_id("v_dot_khuyenmai").ToString();
                }
                else
                {
                    iddot = txtID.Text;
                }
                if (!chkReadonly.Checked)
                {
                    
                    try
                    {
                        DataSet dsgiavp = new DataSet();
                        dsgiavp = m_v.get_data("select a.id, b.tylekhuyenmai, a.ten from medibv.v_giavp a inner join medibv.v_giavp_khuyenmai b on a.id=b.idvp where b.iddot="+iddot);
                        //m_v.execute_data("update medibv.v_dot_khuyenmai set hide=1 where id <>" + iddot);
                        if (dsgiavp.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow r in dsgiavp.Tables[0].Rows)
                            {
                                m_v.execute_data("update medibv.v_giavp set tylekhuyenmai="+r["tylekhuyenmai"]+" where id="+ r["id"]);
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    m_v.execute_data("update medibv.v_giavp set tylekhuyenmai=0 where id in (select idvp from medibv.v_giavp_khuyenmai where iddot =" + iddot + ")");

                }
                if (txtID.Text == "")
                    upd_v_dot_khuyenmai(get_id("v_dot_khuyenmai").ToString(), txtTen.Text, txtTuNgay.Text.Substring(0, 10), txtDenNgay.Text.Substring(0, 10), stugio, sdengio, chkReadonly.Checked ? "1" : "0", checkBox1.Checked ? "1" : "0", int.Parse(cmbLoaikm.SelectedIndex.ToString()));
                else
                    upd_v_dot_khuyenmai(txtID.Text.Trim(), txtTen.Text, txtTuNgay.Text.Substring(0, 10), txtDenNgay.Text.Substring(0, 10), stugio, sdengio, chkReadonly.Checked ? "1" : "0", checkBox1.Checked ? "1" : "0", int.Parse(cmbLoaikm.SelectedIndex.ToString()));
                f_Enable(false);
                f_Load_DotKhuyenMai();
                butMoi.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_sua(aquyenchitiet))
            {
                MessageBox.Show("Chưa được phân quyền sửa!");
                return;
            }
            f_Enable(true);
            txtDenGio.Enabled = checkBox1.Checked == true;
            txtTuGio.Enabled = checkBox1.Checked == true;
            txtTen.Focus();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            string id = txtID.Text;
            if (!m_v.f_quyenchitiet_xoa(aquyenchitiet))
            {
                MessageBox.Show("Chưa được phân quyền xóa!");
                return;
            }
            try
            {
              if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý xoá đợt khuyến mãi ?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
              {
                  if ((m_v.get_data("select * from medibv.v_giavp_khuyenmai where iddot=" + id)).Tables[0].Rows.Count > 0)
                  {
                      MessageBox.Show("Không được phép xóa !!!\nĐợt này đã tồn tại trong giá viện phí khuyến mãi!");
                  }
                  else if ((m_v.get_data("select * from medibv.v_km_nhommien where iddot=" + id)).Tables[0].Rows.Count > 0)
                  {
                      MessageBox.Show("Không được phép xóa !!!\nĐợt này đã được khai báo tỷ lệ khuyến mãi theo nhóm miễn!");
                  }
                  else
                  {
                      m_v.execute_data("delete from medibv.v_dot_khuyenmai where id=" + txtID.Text);
                  }
                        
                            f_Load_DotKhuyenMai();
                            butBoqua_Click(null, null);
              }
            }
            catch
            {
            }
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_Sua();
                f_Load_View();
                f_Enable(false);
                butMoi.Focus();
            }
            catch
            {
            }
        }
        private void txtID_KeyDown(object sender, KeyEventArgs e)
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
    
        private void txtTen_KeyDown(object sender, KeyEventArgs e)
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

        private void chkReadonly_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    butLuu.Focus();
                }
            }
            catch
            {
            }
        }
        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid, "DMBP");
                af.TopMost = true;
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private void butLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog afo = new OpenFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Microsoft XML Document (*.XML)|*.xml";
                afo.Title = lan.Change_language_MessageText("Chọn file dữ liệu đã download từ Medisoft Center Update");
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Cập nhật thành công!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
            

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = Color.Red;
                toolStrip_Tim_TextChanged(null, null);
            }
            catch
            {
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Black;
            }
            catch
            {
            }
        }

        private void butNhomduoc_Click(object sender, EventArgs e)
        {
            try
            {
                frmPhannhomduoc af = new frmPhannhomduoc(m_v,m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
            }
            catch
            {
            }
        }
        private void f_In()
        {
            try
            {
                DataSet ads = new DataSet();
                string sql = "";
                sql = "select ten,to_char(tungay,'dd/mm/yyyy') tungay,to_char(denngay,'dd/mm/yyyy')denngay,tugio,dengio from medibv.v_dot_khuyenmai order by ten";
                ads = m_v.get_data(sql);
                //ads.WriteXml("..//..//Datareport//v_dotkm.xml", XmlWriteMode.WriteSchema);
                //return;

                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ActiveViewIndex = -1;
                crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                crystalReportViewer1.Name = "crystalReportViewer1";
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                crystalReportViewer1.TabIndex = 85;

                System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                af.WindowState = FormWindowState.Maximized;
                af.Controls.Add(crystalReportViewer1);
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                string areport = "v_2007_dotkm.rpt";
                ReportDocument cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = lan.Change_language_MessageText("Phân đợt khuyến mãi (") + areport + ")";
                af.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            f_In();
        }
        private void upd_v_dot_khuyenmai(string id,string ten,string tn,string dn,string tgio,string dgio, string hide,string theogio,int iloai)
        {//khong update loai khuyen mai. Muon sua loai khuyen mai thi xoa dot km xong roi tao moi dot km khac
            m_v.execute_data(" update medibv.v_dot_khuyenmai set id=" + id + ",ten='" + ten + "',tungay=to_date('" + tn.ToString().Substring(0, 10) + "','dd/mm/yyyy'),denngay=to_date('" + dn.ToString().Substring(0, 10) + "','dd/mm/yyyy'),tugio='" + tgio + "',dengio='" + dgio + "',hide=" + hide.ToString() + ",userid=" + m_userid + ",ngayud=to_date('" + DateTime.Now.Date.ToString().Substring(0, 10) + "','mm/dd/yyyy'), theogio = "+theogio+" where id=" + id);
               try
                {
                    m_v.execute_data("insert into medibv.v_dot_khuyenmai(id,ten,userid,tungay,denngay,tugio,dengio,hide,ngayud,theogio,loai) values (" + id + ",'" + ten + "'," + m_userid + ",to_date('" + tn.ToString().Substring(0, 10) + "','dd/mm/yyyy'),to_date('" + dn.ToString().Substring(0, 10) + "','dd/mm/yyyy'),'" + tgio + "','" + dgio + "'," + hide + ",to_date('" + DateTime.Now.Date.ToString().Substring(0, 10) + "','mm/dd/yyyy')," + theogio + ","+iloai+")");
                }
                catch
                {
                    MessageBox.Show("không lưu được");
                }
            
        }
        private int get_id(string table)
        {
            int rs = 0;
            DataSet ds = new DataSet();
            try
            {
                ds = m_v.get_data("select max(id) from " + m_v.user + "." + table);
            }
            catch { ds = null; }
            if (ds == null)
            { }
            else if (ds.Tables[0].Rows.Count == 0)
                rs = 1;
            else
            {
                rs = int.Parse(ds.Tables[0].Rows[0][0].ToString() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString()) + 1;
            }
           return rs;
        }

        private void txtTuNgay_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDenNgay_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtTuNgay_TextChanged(object sender, EventArgs e)
        {
        }
        private bool KTNgay(MaskedTextBox txtNgay)
        {
            string a = txtNgay.Text;
            int ngay, thang, nam;
            try
            {
                ngay = int.Parse(a.Substring(0,2).Trim());
            }
            catch
            {
                Mark(0, 2, txtNgay);
                return false;
            }
            if (ngay > 31 || ngay <= 0)
            {
                Mark(0, 2, txtNgay);
                return false;
            }
            try
            {
                thang = int.Parse(a.Substring(3,2).Trim());
            }
            catch
            {
                Mark(3,2,txtNgay);
                return false;
            }
            if (thang > 12 || thang <= 0)
            {
                Mark(3, 2, txtNgay);
                return false;
            }
            else
            {
                if ((thang == 4 || thang == 6 || thang == 9 || thang == 11) && ngay > 30)
                {
                    Mark(0,2,txtNgay);
                    return false;
                }
                else if (thang == 2 && ngay > 29)
                {
                    Mark(0, 2, txtNgay);
                    return false;
                }
            }
            try
            {
                nam = int.Parse(a.Substring(6,4));
            }
            catch
            {
                Mark(6,4,txtNgay);
                return false;
            }
            if (nam % 4 != 0 && nam % 100 != 0 && nam % 400 != 0 && ngay > 28 && thang == 2)
            {
                Mark(0,2,txtNgay);
                return false;
            }
            
            return true;
        }
        private bool KTGio(MaskedTextBox txtGio)
        {
            string a = txtGio.Text;
            int gio, phut;
            try
            {
                gio = int.Parse(a.Substring(0, 2));
            }
            catch
            {
                Mark(0, 2, txtGio);
                return false;
            }
            if (gio > 23)
            {
                Mark(0, 2, txtGio);
                return false;
            }
            try
            {
                phut = int.Parse(a.Substring(3, 2));
            }
            catch
            {
                Mark(3, 2, txtGio);
                return false;
            }
            if (phut > 59)
            {
                Mark(3, 2, txtGio);
                return false;
            }
            return true;

        }
        private void Mark(int start, int lenght, MaskedTextBox txtDay)
        {
            txtDay.Focus();
            txtDay.Select(start, lenght);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Enabled = true;
                label4.Enabled = true;
                txtTuGio.Enabled = true;
                txtDenGio.Enabled = true;
            }
            else
            {
                label4.Enabled = false;
                label1.Enabled = false;
                txtTuGio.Enabled = false;
                txtDenGio.Enabled = false;
            }
        }

        


        private void txtTuGio_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDenGio_KeyDown(object sender, KeyEventArgs e)
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

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
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


      
 
        

        

        

        

        



        

      
       
    }
}