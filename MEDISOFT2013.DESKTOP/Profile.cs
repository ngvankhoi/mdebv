using System;
using System.Windows.Forms;
using System.Resources;

namespace MEDISOFT2011.DESKTOP
{
    public abstract class Profile
    {
        public Form frmBase;
        public abstract void LoadProfile(string sNgonngu);
    }
}
