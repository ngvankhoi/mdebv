using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;

namespace MACAddress
{
    public partial class frmMACaddress : Form
    {
        public frmMACaddress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// using System.Net.NetworkInformation;
        /// </summary>
        /// <returns></returns>
        string GetMACAddress2()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString() + ";";
                    break;
                }
            }
            return macAddresses.Trim(';');
        }

        /// <summary>
        /// using System.Management;
        /// </summary>
        /// <returns></returns>
        string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = "";
            lblCach1.Text = "";
            foreach (ManagementObject mo in moc)
            {
                if (mo["MacAddress"] != null)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        MACAddress += mo["MacAddress"].ToString() + ";";

                    }
                }
            }
            return MACAddress.Trim(';');
        }

        private void frmMACaddress_Load(object sender, EventArgs e)
        {
            lblCach1.Text = GetMACAddress();
            lblCach2.Text = GetMACAddress2(); 
        }
    }
}