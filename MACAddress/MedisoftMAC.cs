using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using Medisoft2009.License;

namespace Medisoft2009.MACAddress
{
    public class MedisoftMAC
    {
        /// <summary>
        /// using System.Net.NetworkInformation;
        /// </summary>
        /// <returns></returns>
        static public string GetMACAddress()
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
        static public string MACAddress
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                string MACAddress = "";
                foreach (ManagementObject mo in moc)
                {
                    if (mo["MacAddress"] != null)
                    {
                        //if ((bool)mo["IPEnabled"] == true)
                        if (mo["MacAddress"].ToString() != "")
                        {
                            MACAddress += mo["MacAddress"].ToString() + ";";
                        }
                    }
                }
                return MACAddress.Trim(';');
            }
        }

        static public string CPUID
        {
            get
            {
                string cpuInfo = String.Empty;
                ManagementClass managementClass = new ManagementClass("Win32_Processor");
                ManagementObjectCollection managementObjCol = managementClass.GetInstances();
                foreach (ManagementObject managementObj in managementObjCol)
                {
                    if (cpuInfo == String.Empty)
                    {
                        cpuInfo = managementObj.Properties["ProcessorId"].Value.ToString();
                    }
                }
                return cpuInfo;
            }
        }

        /// <summary>
        /// Mã hóa MAC +CPU
        /// </summary>
        static public string KeyInfo
        {
            get
            {
                string s_CPU = CPUID;
                string s_MAC = MACAddress;
                string s_Key = Encryption.EnCode(s_MAC + s_CPU);
                return s_Key;
            }
        }
    }
}
