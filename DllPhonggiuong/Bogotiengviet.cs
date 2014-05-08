using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Net.SourceForge.Vietpad.InputMethod;

namespace DllPhonggiuong
{
    public class Bogotiengviet
    {
        public void GanBogo(Form frm,System.Windows.Forms.TextBox textBox1)
        {                   
            TabControl tabclt;            
            VietKeyHandler keyHandler = new VietKeyHandler(textBox1);
            textBox1.KeyPress += new KeyPressEventHandler(keyHandler.OnKeyPress);
            foreach (Control ctl in frm.Controls)
            {
                System.Windows.Forms.TextBox txt;  
                switch (ctl.GetType().ToString())
                {
                    case "System.Windows.Forms.Panel":

                        foreach (Control ctl1 in ctl.Controls)
                        {
                            System.Windows.Forms.TextBox txt1;  
                            if (ctl1.GetType().ToString() == "MaskedBox.MaskedBox")
                                continue;
                            if (ctl1.GetType().ToString() == "MaskedTextBox.MaskedTextBox")
                                continue;
                            if (ctl1.GetType().ToString() == "System.Windows.Forms.Button")
                            {                                
                                continue;
                            }
                            if (ctl1.GetType().ToString() == "System.Windows.Forms.TextBox")
                            {
                                txt1 = (TextBox)ctl1;
                                txt1.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txt1).OnKeyPress);
                            }
                            foreach (Control ctl2 in ctl1.Controls)
                            {
                                if (ctl2.GetType().ToString() == "MaskedBox.MaskedBox")
                                    continue;
                                if (ctl2.GetType().ToString() == "MaskedTextBox.MaskedTextBox")
                                    continue;
                                if (ctl2.GetType().ToString() == "System.Windows.Forms.TextBox")
                                {
                                    txt1 = (TextBox)ctl2;
                                    txt1.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txt1).OnKeyPress);
                                }
                            }
                        }
                        break;
                    case "System.Windows.Forms.GroupBox":                        
                        foreach (Control ctl1 in ctl.Controls)
                        {
                            System.Windows.Forms.TextBox txt2;
                            if (ctl1.GetType().ToString() == "MaskedBox.MaskedBox")
                                continue;
                            if (ctl1.GetType().ToString() == "MaskedTextBox.MaskedTextBox")
                                continue;
                            if (ctl1.GetType().ToString() == "System.Windows.Forms.TextBox")
                            {
                                txt2 = (TextBox)ctl1;
                                txt2.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txt2).OnKeyPress);
                            }
                        }
                        break;
                    
                    case "System.Windows.Forms.TabControl":
                        tabclt = (TabControl)ctl;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            foreach (Control ct in tab.Controls)
                            {
                                System.Windows.Forms.TextBox txt3;
                                switch (ct.GetType().ToString())
                                {
                                    case "MaskedBox.MaskedBox":
                                        break;
                                    case "System.Windows.Forms.ComboBox":
                                        break;
                                    case "System.Windows.Forms.TextBox":
                                        txt3 = (TextBox)ct;
                                        txt3.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txt3).OnKeyPress);
                                        break;
                                    case "System.Windows.Forms.GroupBox":

                                        foreach (Control ct1 in ct.Controls)
                                        {
                                        }   
                                        break;
                                    case "System.Windows.Forms.Button":                                        
                                        break;                                    
                                    
                                }
                            }
                        }
                        break;
                    case "System.Windows.Forms.TextBox":
                        txt = (TextBox) ctl;
                        txt.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txt).OnKeyPress);
                        break;
                    default:
                        
                        break;
                }
            }
            VietKeyHandler.InputMethod = InputMethods.VNI;
            VietKeyHandler.VietModeEnabled = true;
            VietKeyHandler.SmartMark = true;
        }

    }

}
