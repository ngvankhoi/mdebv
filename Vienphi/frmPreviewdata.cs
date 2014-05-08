using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmPreviewdata : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private DataSet m_ds;
        private string m_curdir = "";
        public frmPreviewdata(string v_title, DataSet v_ds, string v_col_autosize)
        {
            try
            {
                InitializeComponent();
                lan.Read_Language_to_Xml(this.Name.ToString(), this);
                lan.Changelanguage_to_English(this.Name.ToString(), this);
                if (v_title != "")
                {
                    lbTitle.Text = v_title.ToUpper();
                }
                m_ds = v_ds;
                dataGridView1.DataSource = m_ds.Tables[0];
                lbTitle.Text = lbTitle.Text.Trim() + " (" + m_ds.Tables[0].Rows.Count.ToString() + " Records)";
                for (int i = 0; i < v_ds.Tables[0].Columns.Count; i++)
                {
                    if (v_ds.Tables[0].Columns[i].ColumnName.ToLower() == v_col_autosize.ToLower())
                    {
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        private void frmPreviewdata_Load(object sender, EventArgs e)
        {
            m_curdir = System.Environment.CurrentDirectory;
        }
        private void tmn_XML_Click(object sender, EventArgs e)
        {
            try
            {
                string atmp = Application.ExecutablePath;
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp += "\\Errors";
                if (!System.IO.Directory.Exists(atmp))
                {
                    System.IO.Directory.CreateDirectory(atmp);
                }
                SaveFileDialog adg = new SaveFileDialog();
                adg.RestoreDirectory = true;
                adg.Filter = "Microsoft XML Document(*.xml)|*.xml";
                adg.InitialDirectory = atmp;
                adg.FileName = DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Second.ToString().PadLeft(2, '0') + m_ds.Tables[0].TableName.ToString().Replace(" ", "") + ".xml";
                if(adg.ShowDialog() == DialogResult.OK)
                {
                    if (adg.FileName != "")
                    {
                        m_ds.WriteXml(adg.FileName,XmlWriteMode.WriteSchema);
                    }
                }
                adg.Dispose();
            }
            catch
            {
            }
        }

        private void tmn_Ketthuc_Click(object sender, EventArgs e)
        {
            System.Environment.CurrentDirectory = m_curdir;
            this.Close();
        }

        private void tmn_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                string atmp = Application.ExecutablePath;
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp = atmp.Substring(0, atmp.LastIndexOf("\\"));
                atmp += "\\Errors";
                if (!System.IO.Directory.Exists(atmp))
                {
                    System.IO.Directory.CreateDirectory(atmp);
                }
                SaveFileDialog adg = new SaveFileDialog();
                adg.RestoreDirectory = true;
                adg.Filter = "Microsoft Excel Document(*.xls)|*.xls";
                adg.InitialDirectory = atmp;
                adg.FileName = DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Second.ToString().PadLeft(2, '0') + m_ds.Tables[0].TableName.ToString().Replace(" ","") +".xls";
                if (adg.ShowDialog() == DialogResult.OK)
                {
                    if (adg.FileName != "")
                    {
                        f_export_excel(m_ds,adg.FileName);
                    }
                }
                adg.Dispose();
            }
            catch
            {
            }
        }
        public string f_export_excel(DataSet v_ds, string v_file)
        {
            try
            {
                if (v_file.ToLower().IndexOf(".xls") != v_file.Length - 4)
                {
                    v_file = v_file + ".xls";
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(v_file, false, System.Text.Encoding.UTF8);
                string astr = "";
                astr = "<Table>";
                astr = astr + "<tr>";
                for (int i = 0; i < v_ds.Tables[0].Columns.Count; i++)
                {
                    astr = astr + "<th>";
                    astr = astr + v_ds.Tables[0].Columns[i].ColumnName;
                    astr = astr + "</th>";
                }
                astr = astr + "</tr>";
                sw.Write(astr);
                for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
                {
                    astr = "<tr>";
                    for (int j = 0; j < v_ds.Tables[0].Columns.Count; j++)
                    {
                        astr = astr + "<td>";
                        astr = astr + v_ds.Tables[0].Rows[i][j].ToString();
                        astr = astr + "</td>";
                    }
                    astr = astr + "</tr>";
                    sw.Write(astr);
                }
                astr = "</Table>";
                sw.Write(astr);
                sw.Close();
                return v_file;
            }
            catch
            {
                return "";
            }
        }
    }
}