using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
using ConvertFont;

namespace Medisoft
{
    public partial class frmDsexcel : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private int i_userid,i_phai;
        private long l_donvi;
        private string s_mmyy,s_ma = "",s_mabn="",s_hoten="",s_namsinh="",nam="",s_mann="",s_madantoc="",s_matt="",vd_namsinh="";
        private DataTable dt = new DataTable();
        private bool bMabn_ct = false;
        public bool bOk = false;
        private ConvertFont.MyClass cvf = new ConvertFont.MyClass();
        public frmDsexcel(AccessData acc,string mmyy,string ma,long donvi,int userid,string title)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_mmyy = mmyy; s_ma = ma; l_donvi = donvi; i_userid = userid;
            this.Text = title;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            dt = get_excel(path.Text).Tables[0];
            if (dt.Columns.Count < 5 && tt.SelectedIndex == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Tập tin không đúng mẫu !")+"\n"+lan.Change_language_MessageText("STT")+"\n"+lan.Change_language_MessageText("Họ")+"\n"+lan.Change_language_MessageText("Tên")+"\n"+lan.Change_language_MessageText("Nam")+"\n"+lan.Change_language_MessageText("Nữ"), LibMedi.AccessData.Msg);
                return;
            }
            if (dt.Columns.Count < 4 && tt.SelectedIndex==1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Tập tin không đúng mẫu !")+"\n"+lan.Change_language_MessageText("STT")+"\n"+lan.Change_language_MessageText("Họ và Tên")+"\n"+lan.Change_language_MessageText("Nam")+"\n"+lan.Change_language_MessageText("Nữ"), LibMedi.AccessData.Msg);
                return;
            }
            decimal stt = 1;
            foreach (DataRow r in dt.Rows)
            {
                if (tt.SelectedIndex == 0)
                {
                    if (r[2].ToString().Trim() != "")
                    {
                        if (rb2.Checked) s_hoten = m.abc_uni(r[1].ToString()).Trim() + " " + m.abc_uni(r[2].ToString());
                        else if (rb3.Checked) s_hoten = cvf.Vni_Uni(r[1].ToString()).Trim() + " " + cvf.Vni_Uni(r[2].ToString());
                        else s_hoten = r[1].ToString().Trim() + " " + r[2].ToString();
                        s_hoten = s_hoten.ToUpper();
                        i_phai = (r[4].ToString().Trim() != "" && r[4].ToString().Trim() != "0") ? 1 : 0;
                        s_namsinh = (r[3].ToString().Trim() != "" && r[3].ToString().Trim() != "0") ? r[3].ToString() : r[4].ToString();
                        if (bMabn_ct) s_mabn = s_ma + m.get_ma_btdbn(s_mmyy, l_donvi);
                        else s_mabn = s_mmyy.Substring(2, 2) + m.get_mabn(int.Parse(s_mmyy.Substring(2, 2)), 1, 1, true).ToString().PadLeft(6, '0');
                        m.upd_ct_btdbn(s_mmyy, l_donvi, stt, s_mabn, s_hoten, s_namsinh, i_phai, i_userid);
                        if (!bMabn_ct)
                        {
                            nam = m.get_mabn_nam(s_mabn);
                            if (nam.IndexOf(s_mmyy + "+") == -1) nam = nam + s_mmyy + "+";
                            if (s_namsinh == "") s_namsinh = vd_namsinh;
                            m.upd_btdbn(s_mabn, s_hoten, "", s_namsinh, i_phai, s_mann, s_madantoc, "", "", "", s_matt, s_matt + "00", s_matt + "0000", i_userid, nam);
                        }
                        stt++;
                    }
                }
                else
                {
                    if (r[1].ToString().Trim() != "")
                    {
                        if (rb2.Checked) s_hoten = m.abc_uni(r[1].ToString()).Trim();
                        else if (rb3.Checked) s_hoten = cvf.Vni_Uni(r[1].ToString()).Trim();
                        else s_hoten = r[1].ToString().Trim();
                        s_hoten = s_hoten.ToUpper();
                        i_phai = (r[3].ToString().Trim() != "" && r[3].ToString().Trim() != "0") ? 1 : 0;
                        s_namsinh = (r[2].ToString().Trim() != "" && r[2].ToString().Trim() != "0") ? r[2].ToString() : r[3].ToString();
                        if (bMabn_ct) s_mabn = s_ma + m.get_ma_btdbn(s_mmyy, l_donvi);
                        else s_mabn = s_mmyy.Substring(2, 2) + m.get_mabn(int.Parse(s_mmyy.Substring(2, 2)), 1, 1, true).ToString().PadLeft(6, '0');
                        m.upd_ct_btdbn(s_mmyy, l_donvi, stt, s_mabn, s_hoten, s_namsinh, i_phai, i_userid);
                        if (!bMabn_ct)
                        {
                            nam = m.get_mabn_nam(s_mabn);
                            if (nam.IndexOf(s_mmyy + "+") == -1) nam = nam + s_mmyy + "+";
                            if (s_namsinh == "") s_namsinh = vd_namsinh;
                            m.upd_btdbn(s_mabn, s_hoten, "", s_namsinh, i_phai, s_mann, s_madantoc, "", "", "", s_matt, s_matt + "00", s_matt + "0000", i_userid, nam);
                        }
                        stt++;
                    }
                }
            }
            bOk = true;
            m.close();this.Close();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void sheet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.XLS|*.*";
            of.ShowDialog();
            path.Text = of.FileName.ToString();
            System.Environment.CurrentDirectory = sDir;
            if (path.Text != "") sheet.DataSource = LoadSchemaFromFile(path.Text); 
        }

        private OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + fileName + ";" +
                " Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
        }

        private string[] LoadSchemaFromFile(string fileName)
        {
            string[] SheetNames = null;
            OleDbConnection conn = this.ReturnConnection(fileName);
            try
            {
                conn.Open();

                DataTable SchemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null });
                if (SchemaTable.Rows.Count > 0)
                {
                    SheetNames = new string[SchemaTable.Rows.Count];
                    int i = 0;
                    foreach (DataRow TmpRow in SchemaTable.Rows)
                    {
                        SheetNames[i] = TmpRow["TABLE_NAME"].ToString();
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return SheetNames;
        }

        private DataSet get_excel(string fileName)
        {
            OleDbConnection con = this.ReturnConnection(fileName);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet.Text + "]", con);
            OleDbDataAdapter dest = new OleDbDataAdapter();
            dest.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dest.Fill(ds);
            cmd.Dispose();
            con.Close();
            return ds;
        }

        private void frmDsexcel_Load(object sender, EventArgs e)
        {
            bMabn_ct = m.bMabn_ct_rieng;
            if (!bMabn_ct)
            {
                s_mann = m.vodanh_nghenghiep; s_madantoc = m.vodanh_dantoc; s_matt = m.vodanh_tinh;
                int ns = DateTime.Now.Year - m.vodanh_tuoi;
                vd_namsinh = ns.ToString().PadLeft(4, '0');
            }
            tt.SelectedIndex = 0;
        }
    }
}