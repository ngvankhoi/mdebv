using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;

using System.Data;
using System.Collections;
using System.Reflection;
using DevExpress.XtraEditors;

namespace MEDISOFT2011.DESKTOP
{
    public class CauHinhResouce : Profile
    {
        Form fForm;
        string[,] s_Tmp = new string[80, 3];
        int i = 0;
        public CauHinhResouce(Form frm)
        {
            base.frmBase = frm;
        }

        public override void LoadProfile(string sNgonngu)
        {   
            i = 0;
            ResourceManager res = new ResourceManager(@"MEDISOFT2011.DESKTOP.Language" + base.frmBase.Name + sNgonngu, GetType().Assembly);
             
            foreach (Control c in base.frmBase.Controls)
            {
                GetAllControl(c, res);
            }
            s_Tmp[i, 0] = "Title";
            s_Tmp[i, 1] = base.frmBase.Text;
            s_Tmp[i, 2] = res.GetString("Title");
            int j = 0;
            try
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(@"D:\AnhVu\Medisoft_English\MEDISOFT2011.DESKTOP\Language\" + base.frmBase.Name + sNgonngu + ".resx"))
                {
                    for (j = 0; j <= i; j++)
                    {
                        if (s_Tmp[j, 2] == null || s_Tmp[j, 2] == "")
                            try
                            {
                                resx.AddResource(s_Tmp[j, 0], s_Tmp[j, 1]);
                            }
                            catch
                            {
                            }
                        else
                            try
                            {
                                resx.AddResource(s_Tmp[j, 0], s_Tmp[j, 2]);
                            }
                            catch
                            {
                            }
                    }
                    resx.Close();
                }
            }
            catch
            {
            }
        }

        public void LoadProfile(string sNgonngu, Form f_Form, string s_DirectoryPathResource)
        {
            i = 0;
            ResourceManager res = new ResourceManager(@"MEDISOFT2011.DESKTOP.Language." + f_Form.Name + sNgonngu, GetType().Assembly);

            foreach (Control c in f_Form.Controls)
            {
                GetAllControl(c, res);
            }
            s_Tmp[i, 0] = "Title";
            s_Tmp[i, 1] = f_Form.Text;
            s_Tmp[i, 2] = res.GetString("Title");
            int j = 0;
            try
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(s_DirectoryPathResource + f_Form.Name + sNgonngu + ".resx"))
                {
                    for (j = 0; j <= i; j++)
                    {
                        if (s_Tmp[j, 2] == null || s_Tmp[j, 2] == "")
                            try
                            {
                                resx.AddResource(s_Tmp[j, 0], s_Tmp[j, 1]);
                            }
                            catch
                            {
                            }
                        else
                            try
                            {
                                resx.AddResource(s_Tmp[j, 0], s_Tmp[j, 2]);
                            }
                            catch
                            {
                            }
                    }
                    resx.Close();
                }
            }
            catch
            {
            }
        }

        //Get value for control
        private void GetAllControl(Control M, ResourceManager res)
        {
            try
            {
                string sType = M.GetType().ToString().ToLower();
                if (sType.IndexOf("textbox") > -1 ||
                          sType.IndexOf("system.windows.forms.label") > -1 ||
                          sType.IndexOf("button")>-1||
                          sType.IndexOf("checkbox") > -1 ||
                          sType.IndexOf("combobox")> -1||
                          sType.IndexOf("system.windows.forms.radiobutton")>-1
                          )
                {

                    s_Tmp[i, 0] = M.Name;
                    s_Tmp[i, 1] = M.Text;
                    s_Tmp[i, 2] = res.GetString(M.Name);
                    i++;

                }
                else if (sType.IndexOf("system.windows.forms.tabcontrol") > -1)
                {
                    System.Windows.Forms.TabControl TAB = (System.Windows.Forms.TabControl)M;
                    foreach (System.Windows.Forms.TabPage tabpage in TAB.Controls)
                    {
                        s_Tmp[i, 0] = tabpage.Name;
                        s_Tmp[i, 1] = tabpage.Text;
                        s_Tmp[i, 2] = res.GetString(tabpage.Name);
                        i++;
                        foreach (Control col in tabpage.Controls)
                            GetAllControl(col, res);
 
                    }
                }
                else if (sType.IndexOf("system.windows.forms.linklabel") > -1)
                {
                    System.Windows.Forms.LinkLabel link= (System.Windows.Forms.LinkLabel)M;
                    s_Tmp[i, 0] = link.Name;
                    s_Tmp[i, 1] = link.Text;
                    s_Tmp[i, 2] = res.GetString(link.Name);
                    i++;
                }
                else if (sType.IndexOf("system.windows.forms.contextmenustrip") > -1)
                {
                    System.Windows.Forms.ContextMenuStrip contextmenu= (System.Windows.Forms.ContextMenuStrip)M;
                    foreach (System.Windows.Forms.ToolStripMenuItem menuitems in contextmenu.Items)
                    {
                        s_Tmp[i, 0] = menuitems.Name;
                        s_Tmp[i, 1] = menuitems.Text;
                        s_Tmp[i, 2] = res.GetString(menuitems.Name);
                        i++;
                    }
                }
                else if (sType.IndexOf("system.windows.forms.statusstrip") > -1)
                {
                    System.Windows.Forms.StatusStrip status = (System.Windows.Forms.StatusStrip)M;
                    foreach (System.Windows.Forms.ToolStripStatusLabel statuslabel in status.Items)
                    {
                        s_Tmp[i, 0] = statuslabel.Name;
                        s_Tmp[i, 1] = statuslabel.Text;
                        s_Tmp[i, 2] = res.GetString(statuslabel.Name);
                        i++;
                    }
                }
                else if (sType.IndexOf("ltccontrol.ltcdatagridlist") > -1)
                {
                    LTCControl.LTCDataGridList ltcGrid = (LTCControl.LTCDataGridList)M;
                    foreach (System.Windows.Forms.DataGridViewTextBoxColumn dvcol in ltcGrid.Controls)
                    {
                        s_Tmp[i, 0] = dvcol.Name;
                        s_Tmp[i, 1] = dvcol.HeaderText;
                        s_Tmp[i, 2] = res.GetString(dvcol.Name);
                        i++;
                    }
                }
                else if (sType.IndexOf("datagridview") > -1)
                {
                    System.Windows.Forms.DataGridView data = (DataGridView)M;
                    foreach (System.Windows.Forms.DataGridViewTextBoxColumn dgcol in data.Columns)
                    {
                        s_Tmp[i, 0] = dgcol.Name;
                        s_Tmp[i, 1] = dgcol.HeaderText;
                        s_Tmp[i, 2] = res.GetString(dgcol.Name);
                        i++;
                    }

                }
                else if (sType.IndexOf("system.windows.forms.panel") > -1)
                {
                    System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)M;
                    foreach (Control m in panel.Controls)
                        GetAllControl(m, res);
                }
                else if (sType.IndexOf("system.windows.forms.groupbox") > -1)
                {
                    System.Windows.Forms.GroupBox p = (System.Windows.Forms.GroupBox)M;
                    s_Tmp[i, 0] = M.Name;
                    s_Tmp[i, 1] = M.Text;
                    s_Tmp[i, 2] = res.GetString(M.Name);
                    i++;
                    foreach (Control m in p.Controls)
                        GetAllControl(m, res);
                }
            }
            catch 
            {
               
            }
                
        }

        //read and write resource
        private void ReadResource(string s_DirectoryPath)
        {
            string [,] ars_Resource = new string[80,2];
            int i = 0;
            //folder have resource
            string path = s_DirectoryPath+@"\";
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                if (fileInfo.Name.IndexOf("_vn.resx") != -1)
                {
                    //get value resource
                    i = 0;
                    ResXResourceReader reader = new ResXResourceReader(fileInfo.FullName);
                    if (reader != null)
                    {
                        IDictionaryEnumerator id = reader.GetEnumerator();
                        foreach (DictionaryEntry d in reader)
                        {
                            if (d.Value != null)
                            {
                                ars_Resource[i, 0] = d.Key.ToString();
                                ars_Resource[i, 1] = d.Value.ToString();
                                i++;
                            }
                        }

                        reader.Close();
                        if (i == 0) continue;

                        //  set value resource
                        int j = 0;
                        using (ResXResourceWriter resx = new ResXResourceWriter(fileInfo.FullName.Substring(0,fileInfo.FullName.Length-8)+"_en.resx"))
                        {
                            for (j = 0; j <i; j++)
                            {
                                resx.AddResource(ars_Resource[j, 0], ars_Resource[j,1]);
                            }
                            resx.Close();
                        }
                    } 
                }
            }
           
        }
        int ba = 0;
        public void CreateResource(string s_DirectoryPathForm, string s_DirectoryPathResource)
        {
            string[,] ars_Resource = new string[80, 2];
            //folder have resource
            string s_PathForm = s_DirectoryPathForm + @"\";
            string s_PathResource = s_DirectoryPathResource + @"\";

            DirectoryInfo dir = new DirectoryInfo(s_PathForm);
            ba = 0;
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                if (fileInfo.Name.IndexOf(".resx") == -1 && fileInfo.Name.ToLower().IndexOf("designer.cs") == -1 && fileInfo.Name.IndexOf(".cs") !=1)
                {
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                   
                    foreach (Assembly a in assemblies)
                    {
                        Type[] types = a.GetTypes();
                        foreach (Type t in types)
                        {
                            if (t.IsPublic && t.BaseType == typeof(Form))
                            {
                                if (!t.FullName.Contains("MEDISOFT2011.DESKTOP." + fileInfo.Name.Substring(0, fileInfo.Name.Length - 3)))
                                    continue;
                                if (t.FullName.Contains(fileInfo.Name.Substring(0, fileInfo.Name.Length - 3)))
                                {
                                    try
                                    {
                                        ba = ba + 1;
                                        fForm= (System.Windows.Forms.Form)a.CreateInstance(t.FullName);

                                        using (ResXResourceWriter resx = new ResXResourceWriter(s_PathResource + fForm.Name + "_vn" + ".resx"))
                                        {
            
                                            resx.Close();
                                        }
                                        using (ResXResourceWriter resx = new ResXResourceWriter(s_PathResource + fForm.Name + "_en" + ".resx"))
                                        {
                                            resx.Close();
                                        }
                                        LoadProfile("_vn", fForm, s_PathResource);
                                        LoadProfile("_en", fForm, s_PathResource);
                                    }
                                    catch
                                    { 
                                    }
                                }
 
                            }
                        }
                    }
                }
            }
            MessageBox.Show(ba.ToString());

        }
    }
}
