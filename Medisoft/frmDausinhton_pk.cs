using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmDausinhton_pk : frmDausinhton_chung
    {
        public frmDausinhton_pk()
        {
            InitializeComponent();
            base.Init();
        }
        public frmDausinhton_pk(LibMedi.AccessData _acc,string _s_makp,decimal _l_maql,string _s_table,int _i_loaiba,string _s_mabn,decimal _d_mavaovien,string _ngay, string _mabs)
        {
            InitializeComponent();
            base.Init();
            base.acc = _acc;
            base.s_Makp = _s_makp;
            base.l_Maql = _l_maql;
            base.l_idkhoa = _l_maql;
            base.s_Table = _s_table;
            base.i_Loaiba = _i_loaiba;
            base.s_Mabn = _s_mabn;
            base.d_Mavaovien = _d_mavaovien;
            base.s_Ngay = _ngay;
            base.s_mabs = _mabs;
            s_table = _s_table;
            l_maql = _l_maql;
            i_loaiba = _i_loaiba;
        }

        private void frmDausinhton_pk_Load(object sender, EventArgs e)
        {
            base.Load_form();
            user = base.user;
            xxx = base.acc.mmyy(base.acc.ngayhienhanh_server.Substring(0, 10));
            //cbongayvaovien.DataSource = dthoten;
            //cbongayvaovien.DisplayMember = "NGAYVAO";
            //cbongayvaovien.ValueMember = "MAQL";

            //cbotenkp.DataSource = dthoten;
            //cbotenkp.DisplayMember = "TENKP";
            //cbotenkp.ValueMember = "MAKP";

            chieucao.Enabled = false;
            butMoi_Click(null, null);
            //try { DataTable dt_chieucao = base.acc.get_data("select chieucao from " + user + xxx + ".d_dausinhton where 1=0").Tables[0]; }
            //catch { base.acc.execute_data("alter table " + user + xxx + ".d_dausinhton add chieucao numeric(7,2)"); }
        }
        void load_default()
        {
            ngay.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            string s_sql = "select * from " + user + ".dmgiatribt";
            foreach (DataRow r in acc.get_data(s_sql).Tables[0].Rows)
            {
                mach.Text = r["mach"].ToString();
                nhietdo.Text = r["nhietdo"].ToString();
                huyetap.Text = r["huyetap"].ToString();
                nhiptho.Text = r["nhiptho"].ToString();
                //cannang.Text = r["cannang"].ToString();
                //chieucao.Text = r["chieucao"].ToString();
                break;
            }
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            xxx = base.xxx;
            base.acc.execute_data("update " + user + xxx + ".d_dausinhton set chieucao=" + (chieucao.Text == "" ? 0 : decimal.Parse(chieucao.Text)) + ",makp='"+s_makp+"' where id=" + base.l_id + "");
            chieucao.Enabled = false;
        }

        private void chieucao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) butLuu.Focus();
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataRow r in dtct.Select("id="+base.l_id+""))
            {
                chieucao.Text = r["chieucao"].ToString();
                break;
            }
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            chieucao.Enabled = true;
            load_default();
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            chieucao.Enabled = true;
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            chieucao.Enabled = false;
        }
    }
}