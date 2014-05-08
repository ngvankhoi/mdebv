using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmDanhsachdutru : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        LibDuoc.AccessData d;
        string s_makp = "";
        DataSet dsdutru,dslinh;
        public frmDanhsachdutru(string d_makp)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); //tv.GanBogo(this, textBox111);
            s_makp = d_makp;
        }
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dsdutru.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 5;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loaiphieu";
            TextCol.HeaderText = "Loại phiếu";
            TextCol.Width = 120;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenphieu";
            TextCol.HeaderText = "Tên phiếu";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chuachuyen";
            TextCol.HeaderText = "Chưa chuyển";
            TextCol.Width = 80;
            TextCol.Alignment = HorizontalAlignment.Center;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chuyen";
            TextCol.HeaderText = "Đã chuyển";
            TextCol.Width = 80;
            TextCol.Alignment = HorizontalAlignment.Center;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "duyet";
            TextCol.HeaderText = "Đã duyệt";
            TextCol.Width = 80;
            TextCol.Alignment = HorizontalAlignment.Center;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Người nhập";
            TextCol.Width = 200;
            TextCol.Alignment = HorizontalAlignment.Left;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);

            dataGrid1.TableStyles.Add(ts);
        }
        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dslinh.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 5;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenphieu";
            TextCol.HeaderText = "Tên phiếu";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);

            dataGrid2.TableStyles.Add(ts);
        }
        private void butThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTungay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmDanhsachdutru_Load(object sender, EventArgs e)
        {
            d = new LibDuoc.AccessData();
            cboKhoa.DisplayMember = "TEN";
            cboKhoa.ValueMember = "ID";
            string sql = "select id,ten from " + d.user + ".d_duockp";
            if (s_makp != "") sql += " where makp in ('" + s_makp.Replace(",","','") + "')";
            sql += " order by ten";
            cboKhoa.DataSource = d.get_data(sql).Tables[0];
            txtThang.Value = (decimal)DateTime.Now.Month;
            txtNam.Value = (decimal)DateTime.Now.Year;
            dsdutru = d.get_data("select 0 as id,'' as ngay,'' as loaiphieu,'' as tenphieu").Clone();
            dslinh = d.get_data("select '' as ngay,'' as tenphieu").Clone();
            AddGridTableStyle();
            AddGridTableStyle2();
            this.WindowState = FormWindowState.Maximized;
        }

        private void butXem_Click(object sender, EventArgs e)
        {
            d = new LibDuoc.AccessData();
            string mmyy = txtThang.Value.ToString().PadLeft(2, '0') + txtNam.Value.ToString().Substring(2);
            if (d.bMmyy(mmyy))
            {
                string user = d.user;
                string xxx = user + mmyy;
                string exp = " where a.makp=" + cboKhoa.SelectedValue.ToString() + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTungay.Text + "','dd/mm/yyyy') and to_date('" + txtDenngay.Text + "','dd/mm/yyyy') ";
                string sql = "select distinct a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as loaiphieu,c.ten as tenphieu,";
                sql+=" case when a.done=0 then 'x' else '' end as chuachuyen,";
                sql+=" case when a.done=1 then 'x' else '' end as chuyen,";
                sql+=" case when a.done=2 then 'x' else '' end as duyet,a.loai,d.hoten ";
                sql+=" from " + xxx + ".d_duyet a inner join "+xxx+".d_dutrull a1 on a.id=a1.idduyet inner join " + user + ".d_dmphieu b on a.loai=b.id ";
                sql+=" inner join " + user + ".d_loaiphieu c on a.phieu=c.id ";
                sql+= " left join " + user + ".dlogin d on a.userid=d.id ";
                sql+= exp;
                sql+=" union all ";
                sql += "select distinct a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as loaiphieu,c.ten as tenphieu,";
                sql += " case when a.done=0 then 'x' else '' end as chuachuyen,";
                sql += " case when a.done=1 then 'x' else '' end as chuyen,";
                sql += " case when a.done=2 then 'x' else '' end as duyet,a.loai,d.hoten ";
                sql += " from " + xxx + ".d_duyet a inner join "+xxx+".d_xtutrucll a1 on a.id=a1.idduyet inner join " + user + ".d_dmphieu b on a.loai=b.id ";
                sql += " inner join " + user + ".d_loaiphieu c on a.phieu=c.id ";
                sql += " left join " + user + ".dlogin d on a.userid=d.id ";
                sql += exp;
                sql += " union all ";
                sql += "select distinct a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as loaiphieu,c.ten as tenphieu,";
                sql += " case when a.done=0 then 'x' else '' end as chuachuyen,";
                sql += " case when a.done=1 then 'x' else '' end as chuyen,";
                sql += " case when a.done=2 then 'x' else '' end as duyet,a.loai,d.hoten ";
                sql += " from " + xxx + ".d_duyet a inner join " + xxx + ".d_hoantrall a1 on a.id=a1.idduyet inner join " + user + ".d_dmphieu b on a.loai=b.id ";
                sql += " inner join " + user + ".d_loaiphieu c on a.phieu=c.id ";
                sql += " left join " + user + ".dlogin d on a.userid=d.id ";
                sql += exp;
                sql += " union all ";
                sql += "select distinct a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as loaiphieu,c.ten as tenphieu,";
                sql += " case when a.done=0 then 'x' else '' end as chuachuyen,";
                sql += " case when a.done=1 then 'x' else '' end as chuyen,";
                sql += " case when a.done=2 then 'x' else '' end as duyet,a.loai,d.hoten ";
                sql += " from " + xxx + ".d_duyet a inner join " + xxx + ".d_haophill a1 on a.id=a1.idduyet inner join " + user + ".d_dmphieu b on a.loai=b.id ";
                sql += " inner join " + user + ".d_loaiphieu c on a.phieu=c.id ";
                sql += " left join " + user + ".dlogin d on a.userid=d.id ";
                sql += exp;
                dsdutru = d.get_data(sql);
                dataGrid1.DataSource = dsdutru.Tables[0];
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            d = new LibDuoc.AccessData();
            string mmyy = txtThang.Value.ToString().PadLeft(2, '0') + txtNam.Value.ToString().Substring(2);
            if (d.bMmyy(mmyy))
            {
                string user = d.user;
                string d_user = user + mmyy;
                //string file = "d_dutrull";
                string sql = "";
                switch (dataGrid1[dataGrid1.CurrentRowIndex, 1].ToString())
                {
                    case "2": sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu from xxx.d_xuatsdll a," + user + ".d_loaiphieu b,xxx.d_bucstt c where a.id=c.id and a.phieu=b.id and a.idduyet in(select id from " + d_user + ".d_xtutrucll where idduyet in(select id from " + d_user + ".d_duyet where id =" + dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString() + "))";
                        break;
                    case "3": sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu from xxx.d_xuatsdll a," + user + ".d_loaiphieu b where a.phieu=b.id and a.idduyet in(select id from " + d_user + ".d_hoantrall where idduyet in(select id from " + d_user + ".d_duyet where id =" + dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString() + "))";
                        break;
                    case "4": sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu from xxx.d_xuatsdll a," + user + ".d_loaiphieu b where a.phieu=b.id and a.idduyet in(select id from " + d_user + ".d_haophill where idduyet in(select id from " + d_user + ".d_duyet where id =" + dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString() + "))";
                        break;
                    default: sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu from xxx.d_xuatsdll a," + user + ".d_loaiphieu b where a.phieu=b.id and a.idduyet in(select id from " + d_user + ".d_dutrull where idduyet in(select id from " + d_user + ".d_duyet where id =" + dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString() + "))";
                        break;
                };
                dslinh = d.get_data_mmyy(sql,txtTungay.Text,txtDenngay.Text,true);
                dataGrid2.DataSource = dslinh.Tables[0];
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
            txtTim.BackColor=SystemColors.Info;
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            txtTim.Text = "Tìm kiếm";
            txtTim.BackColor = Color.White;
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "Tìm kiếm") return;
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ngay like '%" + txtTim.Text.Trim() + "%' or loaiphieu like '%" + txtTim.Text + "%' or tenphieu like '%" + txtTim.Text + "%'";
            }
            catch { }
        }
    }
}