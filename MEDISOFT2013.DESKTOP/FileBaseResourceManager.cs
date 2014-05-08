namespace MEDISOFT2011.DESKTOP
{
    using System;
    using System.Resources;
    using System.Windows.Forms;

    public class FileBaseResourceManager
    {
        private StringResourceNotFoundException exception = new StringResourceNotFoundException();
        private System.Resources.ResourceManager rm;

        public FileBaseResourceManager(string baseName, string strResourcesDir)
        {
            this.rm = System.Resources.ResourceManager.CreateFileBasedResourceManager(baseName, strResourcesDir, null);
        }

        public string GetString(string name)
        {
            string str = null;
            try
            {
                str = this.rm.GetString(name);
            }
            catch (Exception exception)
            {
                ExceptionLog.WriteToLogFile(exception);
                MessageBox.Show(exception.Message);
            }
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return str;
        }
    }
}

