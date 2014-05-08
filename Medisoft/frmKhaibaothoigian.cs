using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmKhaibaothoigian : Form
    {
        LibMedi.AccessData m = new LibMedi.AccessData();
        Language lan = new Language();
        string sql = "", s_msg="",s_ngay="";
        int id = 0;
        DataTable dtthoigian = new DataTable();
        DataTable dtletet = new DataTable();
        DataTable dtngaynghi = new DataTable();
        DataTable dtdoituong = new DataTable();

        public frmKhaibaothoigian()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtthoigian.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = true;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "ID";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = lan.Change_language_MessageText("Tên");
            TextCol.Width = 180;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tugio_s";
            TextCol.HeaderText = lan.Change_language_MessageText("Sáng-Từ giờ");
            TextCol.NullText = "";
            TextCol.Width = 75;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dengio_s";
            TextCol.HeaderText = lan.Change_language_MessageText("Sáng-Đến giờ");
            TextCol.Width = 75;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tugio_c";
            TextCol.HeaderText = lan.Change_language_MessageText("Chiều-Từ giờ");
            TextCol.Width = 75;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dengio_c";
            TextCol.HeaderText = lan.Change_language_MessageText("Chiều-Đến giờ");
            TextCol.Width = 75;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "madoituong";
            TextCol.HeaderText = "";//lan.Change_language_MessageText("Đối tượng");
            TextCol.Width = 0;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "doituong";
            TextCol.HeaderText = lan.Change_language_MessageText("Đối tượng");
            TextCol.Width = 100;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtletet.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

        }

        private void AddGridTableStyle3()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtngaynghi.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tugio";
            TextCol.HeaderText = "Từ giờ";
            TextCol.Width = 100;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dengio";
            TextCol.HeaderText = "Đến giờ";
            TextCol.Width = 100;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "nghi";
            TextCol.HeaderText = "Nghỉ";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);
        }

        private void frmKhaibaothoigian_Load(object sender, EventArgs e)
        {
            s_msg = LibMedi.AccessData.Msg;
            sql = "select a.*,b.doituong from " + m.user + ".dmloaitg a left join " + m.user + ".doituong b on a.madoituong=b.madoituong  order by a.id";
            dtthoigian = m.get_data(sql).Tables[0];
            dataGrid1.DataSource = dtthoigian;
            AddGridTableStyle();
            ena_obj(false);

            sql = "select * from "+m.user+".letet";
            dtletet = m.get_data(sql).Tables[0];
            dataGrid2.DataSource = dtletet;
            AddGridTableStyle2();

            sql = "select * from " + m.user + ".ngaynghi order by oid";
            dtngaynghi = m.get_data(sql).Tables[0];
            dataGrid3.DataSource = dtngaynghi;
            AddGridTableStyle3();
            dataGrid3_CurrentCellChanged(null, null);

            sql = "select * from " + m.user + ".doituong";
            dtdoituong = m.get_data(sql).Tables[0];
            cmbDoituong.DataSource = dtdoituong;
            cmbDoituong.DisplayMember = "doituong";
            cmbDoituong.ValueMember = "madoituong";
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;

                id = int.Parse(dataGrid1[i, 0].ToString());
               
                    tusang.Text = dataGrid1[i, 2].ToString() == "" ? "" : dataGrid1[i, 2].ToString();
                    densang.Text = dataGrid1[i, 3].ToString() == "" ? "" : dataGrid1[i, 3].ToString();
                    tuchieu.Text = dataGrid1[i, 4].ToString() == "" ? "" : dataGrid1[i, 4].ToString();
                    denchieu.Text = dataGrid1[i, 5].ToString() == "" ? "" : dataGrid1[i, 5].ToString();
                    try
                    {
                        cmbDoituong.SelectedValue = int.Parse(dataGrid1[i, 6].ToString());
                    }
                    catch {
                        cmbDoituong.SelectedValue = -1;
                    }
                    if (id == 0)
                    {
                    ena_obj(true);

                 }
                else
                {
                    ena_obj(false);
                }
            }
            catch { }
        }
        private void ena_obj(bool ena)
        {
            tusang.Enabled = ena;
            densang.Enabled = ena;
            tuchieu.Enabled = ena;
            denchieu.Enabled = ena;
            //butLuu.Enabled = ena;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {

            //if (id == 0)
            //{
                if (tuchieu.Text.Trim().Trim(':') != "" && denchieu.Text.Trim().Trim(':') != "" && tusang.Text.Trim().Trim(':') != "" && densang.Text.Trim().Trim(':') != "")
                {
                    
                    if (int.Parse(tusang.Text.Split(':')[0]) > 12 || int.Parse(tusang.Text.Split(':')[0]) > 59)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thời gian không hợp lệ !"), s_msg);
                        tusang.Focus();
                        return;
                    }
                    if (int.Parse(densang.Text.Split(':')[0]) > 12 || int.Parse(densang.Text.Split(':')[0]) > 59)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thời gian không hợp lệ !"), s_msg);
                        densang.Focus();
                        return;
                    }
                    if (int.Parse(tuchieu.Text.Split(':')[0]) > 23 || int.Parse(tuchieu.Text.Split(':')[0]) > 59)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thời gian không hợp lệ !"), s_msg);
                        tuchieu.Focus();
                        return;
                    }
                    if (int.Parse(denchieu.Text.Split(':')[0]) > 23 || int.Parse(denchieu.Text.Split(':')[0]) > 59)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thời gian không hợp lệ !"), s_msg);
                        denchieu.Focus();
                        return;
                    }
                    if (!kiemtra()) return;
                    if (int.Parse(densang.Text.Split(':')[0]) == int.Parse(tuchieu.Text.Split(':')[0]))
                    {
                        if (int.Parse(densang.Text.Split(':')[1]) > int.Parse(tuchieu.Text.Split(':')[1]))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                            densang.Focus();
                            return;
                        }
                    }
                    else if (int.Parse(densang.Text.Split(':')[0]) > int.Parse(tuchieu.Text.Split(':')[0]))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                        densang.Focus();
                        return;
                    }

                    if (!m.execute_data("update " + m.user + ".dmloaitg set tugio_s='" + tusang.Text + "',dengio_s='" + densang.Text + "',tugio_c='" + tuchieu.Text + "',dengio_c='" + denchieu.Text + "',madoituong="+cmbDoituong.SelectedValue+" where id=0"))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), s_msg);
                        return;
                    }
                }
                else if (tuchieu.Text.Trim().Trim(':') == "" && denchieu.Text.Trim().Trim(':') == "" && tusang.Text.Trim().Trim(':') == "" && densang.Text.Trim().Trim(':') == "")
                {
                    if (!m.execute_data("update " + m.user + ".dmloaitg set tugio_s=null,dengio_s=null,tugio_c=null,dengio_c=null,madoituong=" + cmbDoituong.SelectedValue + " where id="+id))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), s_msg);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập đầy đủ các mốc thời gian hoặc xóa trắng tất cả !"), s_msg);
                    return;
                }
                MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công !"), s_msg);
                sql = "select a.*,b.doituong from " + m.user + ".dmloaitg a left join " + m.user + ".doituong b on a.madoituong=b.madoituong  order by a.id";
                dtthoigian = m.get_data(sql).Tables[0];
                dataGrid1.DataSource = dtthoigian;
            //}
        }

        private bool kiemtra()
        {
            if (tusang.Text.Trim().Trim(':') != "" && densang.Text.Trim().Trim(':') != "")
            {
                if (int.Parse(tusang.Text.Split(':')[0]) == int.Parse(densang.Text.Split(':')[0]))
                {
                    if (int.Parse(tusang.Text.Split(':')[1]) > int.Parse(densang.Text.Split(':')[1]))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                        tusang.Focus();
                        return false;
                    }
                }
                else if (int.Parse(tusang.Text.Split(':')[0]) > int.Parse(densang.Text.Split(':')[0]))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                    tusang.Focus();
                    return false;
                }
            }
            if (tuchieu.Text.Trim().Trim(':') != "" && denchieu.Text.Trim().Trim(':') != "")
            {
                if (int.Parse(tuchieu.Text.Split(':')[0]) == int.Parse(denchieu.Text.Split(':')[0]))
                {
                    if (int.Parse(tuchieu.Text.Split(':')[1]) > int.Parse(denchieu.Text.Split(':')[1]))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                        tuchieu.Focus();
                        return false;
                    }
                }
                else if (int.Parse(tuchieu.Text.Split(':')[0]) > int.Parse(denchieu.Text.Split(':')[0]))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                    tuchieu.Focus();
                    return false;
                }
            }
            return true;
        }


        private void tusang_Validated(object sender, EventArgs e)
        {
            tusang.Text = tusang.Text.Split(':')[0].Trim().PadLeft(2, '0') + ":" + tusang.Text.Split(':')[1].Trim().PadLeft(2, '0');
            if (tusang.Text == "00:00")
                tusang.Text = "";
        }

        private void densang_Validated(object sender, EventArgs e)
        {
            densang.Text = densang.Text.Split(':')[0].Trim().PadLeft(2, '0') + ":" + densang.Text.Split(':')[1].Trim().PadLeft(2, '0');
            if (densang.Text == "00:00")
                densang.Text = "";
        }

        private void tuchieu_Validated(object sender, EventArgs e)
        {
            tuchieu.Text = tuchieu.Text.Split(':')[0].Trim().PadLeft(2, '0') + ":" + tuchieu.Text.Split(':')[1].Trim().PadLeft(2, '0');
            if (tuchieu.Text == "00:00")
                tuchieu.Text = "";
        }

        private void denchieu_Validated(object sender, EventArgs e)
        {
            denchieu.Text = denchieu.Text.Split(':')[0].Trim().PadLeft(2, '0') + ":" + denchieu.Text.Split(':')[1].Trim().PadLeft(2, '0');
            if (denchieu.Text == "00:00")
                denchieu.Text = "";
        }

        private void tusang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void dataGrid3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid3.CurrentCell.RowNumber;
                s_ngay = dataGrid3[i, 0].ToString();
                DataRow r = m.getrowbyid(dtngaynghi, "ngay='" + s_ngay + "'");
                nghitu.Text = r["tugio"].ToString().Trim().Trim(':') == "" ? "" : r["tugio"].ToString();
                nghiden.Text = r["dengio"].ToString().Trim().Trim(':') == "" ? "" : r["dengio"].ToString();
                chkNghi.Checked = r["nghi"].ToString() == "1" ? true : false;
                txtNgay.Text = s_ngay;

            }
            catch { }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            ena_obj2(true);
        }

        private void ena_obj2(bool ena)
        {
            butLuu2.Enabled = ena;
            butBoqua.Enabled = ena;
            butSua.Enabled = !ena;
            nghiden.Enabled = ena;
            nghitu.Enabled = ena;
            chkNghi.Enabled = ena;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_obj2(false);
            dataGrid3_CurrentCellChanged(null, null);
        }

        private void butLuu3_Click(object sender, EventArgs e)
        {
            m.execute_data("delete from "+m.user+".letet");
            for (int i = 0; i<dtletet.Rows.Count; i++)
            {
                if (dtletet.Rows[i]["ngay"].ToString().Trim() != "")
                {
                    m.execute_data("insert into " + m.user + ".letet values('" + dtletet.Rows[i]["ngay"].ToString().Trim() + "')");
                }
            }
            sql = "select * from " + m.user + ".letet";
            dtletet = m.get_data(sql).Tables[0];
            dataGrid2.DataSource = dtletet;
        }

        private void butLuu2_Click(object sender, EventArgs e)
        {
            if (nghitu.Text.Trim().Trim(':') != "" && nghiden.Text.Trim().Trim(':') != "")
            {
                if (int.Parse(nghitu.Text.Split(':')[0]) > 23 || int.Parse(nghitu.Text.Split(':')[0]) > 59)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thời gian không hợp lệ !"), s_msg);
                    nghitu.Focus();
                    return;
                }
                if (int.Parse(nghiden.Text.Split(':')[0]) > 23 || int.Parse(nghiden.Text.Split(':')[0]) > 59)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thời gian không hợp lệ !"), s_msg);
                    nghiden.Focus();
                    return;
                }
                if (int.Parse(nghitu.Text.Split(':')[0]) == int.Parse(nghiden.Text.Split(':')[0]))
                {
                    if (int.Parse(nghitu.Text.Split(':')[1]) > int.Parse(nghiden.Text.Split(':')[1]))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                        nghitu.Focus();
                        return;
                    }
                }
                else if (int.Parse(nghitu.Text.Split(':')[0]) > int.Parse(nghiden.Text.Split(':')[0]))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mốc thời gian không hợp lệ !"), s_msg);
                    nghitu.Focus();
                    return;
                }
                
                if (!m.execute_data("update " + m.user + ".ngaynghi set tugio='" + nghitu.Text + "',dengio='" + nghiden.Text + "',nghi=" + (chkNghi.Checked ? 1 : 0) + " where ngay='" + txtNgay.Text.Trim() + "'"))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ngày nghỉ!"), s_msg);
                    return;
                }
            }
            else
            {
                
                if (!m.execute_data("update " + m.user + ".ngaynghi set tugio=null,dengio=null,nghi=" + (chkNghi.Checked ? 1 : 0) + " where ngay='" + txtNgay.Text.Trim() + "'"))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ngày nghỉ!"), s_msg);
                    return;
                }
            }
            sql = "select * from " + m.user + ".ngaynghi";
            dtngaynghi = m.get_data(sql).Tables[0];
            dataGrid3.DataSource = dtngaynghi;
            dataGrid3_CurrentCellChanged(null, null);
            ena_obj2(false);

        }

        private void nghitu_Validated(object sender, EventArgs e)
        {
            nghitu.Text = nghitu.Text.Split(':')[0].Trim().PadLeft(2, '0') + ":" + nghitu.Text.Split(':')[1].Trim().PadLeft(2, '0');
            if (nghitu.Text == "00:00")
                nghitu.Text = "";
        }

        private void nghiden_Validated(object sender, EventArgs e)
        {
            nghiden.Text = nghiden.Text.Split(':')[0].Trim().PadLeft(2, '0') + ":" + nghiden.Text.Split(':')[1].Trim().PadLeft(2, '0');
            if (nghiden.Text == "00:00")
                nghiden.Text = "";
        }
    }
}