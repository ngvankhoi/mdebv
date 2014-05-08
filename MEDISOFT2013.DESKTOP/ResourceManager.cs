namespace MEDISOFT2011.DESKTOP
{
    using System;


    internal sealed class ResourceManager
    {
        public string m_filename = "";

        private static FileBaseResourceManager _ResourceManager = new FileBaseResourceManager(get_file(), "./MultiLanguage");

        public static string GetString(string name)
        {

            return _ResourceManager.GetString(name);
        }
        public static string get_file()
        {
            string m_file = "";
            int ngonngu = 0;
            LibMedi.AccessData m = new LibMedi.AccessData();
            ngonngu = int.Parse(m.Thongso("Ngonngu").ToString());
            switch (ngonngu)
            {
                case 0:
                    m_file = "MEDISOFTDESKTOP_vn";
                    break;
                case 1:
                    m_file = "MEDISOFTDESKTOP_en";
                    break;
                case 2:
                    m_file = "MEDISOFTDESKTOP_ot";
                    break;
            }
            return m_file;
        }

    }
}

