using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmTyleuudai_bhyt : Form
    {
        LibMedi.AccessData m;
        DataTable dtthe = new DataTable();
        DataTable dttyle = new DataTable();
        DataTable dtdotkm = new DataTable();
        string sql = "", ma = "", s_msg="";
        Language lan = new Language();
        
        public frmTyleuudai_bhyt(LibMedi.AccessData _m)
        {

            InitializeComponent();
            m = _m;
        }

        private void frmTyleuudai_bhyt_Load(object sender, EventArgs e)
        {
            sql = "select * from " + m.user + ".v_dot_khuyenmai where loai=1 order by tungay,denngay";
            dtdotkm = m.get_data(sql).Tables[0];
            cmdDotkm.DataSource = dtdotkm;
            cmdDotkm.ValueMember = "id";
            cmdDotkm.DisplayMember = "ten";
            if (dtdotkm.Rows.Count > 0)
                cmdDotkm.SelectedValue = dtdotkm.Rows[0]["id"];
            else
                return;

            s_msg = LibMedi.AccessData.Msg;
            load_grid_the();
            AddGridTableStyle2();
            
            sql = "select id,ten,0 tyle,0 chenhlech from  " + m.user + ".v_nhommien";
            dttyle = m.get_data(sql).Tables[0];
            dataGrid2.DataSource = dttyle;
            AddGridTableStyle();
            dataGrid1_CurrentCellChanged(null, null);
        }
        private void AddGridTableStyle()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dttyle.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;


            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nhóm miễn giảm";
            TextCol.Width = 210;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tyle";
            TextCol.HeaderText = "Tỷ lệ chênh lệch";
            TextCol.Width = 100;
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chenhlech";
            TextCol.HeaderText = "Tỷ lệ đồng chi trả";
            TextCol.Width = 100;
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;

        }

        private void AddGridTableStyle2()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtthe.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;


            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã thẻ";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "vitri";
            TextCol.HeaderText = "Vị trí";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chieudai";
            TextCol.HeaderText = "Chiều dài";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "daset";
            TextCol.HeaderText = "Đã đặt tỷ lệ";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void load_grid_the()
        {
            try
            {
                sql = "select a.ma,a.tu||'-'||a.den vitri,a.chieudai,case when b.ma is not null then 'X' else '' end daset from " + m.user + ".dmloaibhyt a left join (select ma,iddotkm from " + m.user + ".tyleuudai_loaibhyt where iddotkm=" + cmdDotkm.SelectedValue + " group by ma,iddotkm ) b on a.ma=b.ma and b.iddotkm=" + cmdDotkm.SelectedValue + "";
                dtthe = m.get_data(sql).Tables[0];
                dataGrid1.DataSource = dtthe;
            }
            catch { }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                ma = dataGrid1[i, 0].ToString().Trim();
                if (dataGrid1[i, 3].ToString().Trim() == "X")
                {
                    sql = "select a.id,a.ten,nvl(b.tyle,0) tyle,nvl(b.tldongchitra,0) chenhlech from  " + m.user + ".v_nhommien a left join " + m.user + ".tyleuudai_loaibhyt b on a.id=b.id_nhommien and b.ma='" + ma + "' and b.iddotkm=" + cmdDotkm.SelectedValue + " order by a.ten";
                    dttyle = m.get_data(sql).Tables[0];
                    dataGrid2.DataSource = dttyle;
                }
                //else
                //    sql = "select id,ten,0 tyle from  " + m.user + ".v_nhommien order by ten";
                
            }
            catch { }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            dataGrid1_CurrentCellChanged(null, null);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in dttyle.Rows)
            {
                if (int.Parse(r["tyle"].ToString()) > 100 || int.Parse(r["tyle"].ToString()) < 0 || int.Parse(r["chenhlech"].ToString()) > 100 || int.Parse(r["chenhlech"].ToString()) < 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ không hợp lệ!"), s_msg);
                    return;
                }
            }
            foreach (DataRow r in dttyle.Rows)
            {
                if (r["id"].ToString().Trim() != "")
                {
                    if (!m.upd_tyleuudai_loaibhyt(ma, int.Parse(r["tyle"].ToString()), int.Parse(r["id"].ToString()), decimal.Parse(cmdDotkm.SelectedValue.ToString()), int.Parse(r["chenhlech"].ToString())))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tỷ lệ ưu đãi !"), s_msg);
                        return;
                    }
                }
            }
            load_grid_the();
            //m.execute_data("delete form " + m.user + ".tyleuudai_loaibhyt where ma='"+ma+"' and tyle=0");
        }

        private void cmdDotkm_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid_the();
            dataGrid1_CurrentCellChanged(null, null);
        }
    }
}