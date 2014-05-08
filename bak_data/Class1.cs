using System;
using System.Data;
using LibMedi;

namespace bak_data
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: Add code to start application here
			//
			AccessData m=new AccessData();
			Run f;
            string ip, post, owner, user, database, file, arg, path, tenfile, ngay = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            path = m.Path_backup + "\\" + ngay + "\\";
            file = @"pg_dump.exe";
            user = m.user;
            string aNgonngu = "";
            try
            {
                aNgonngu = m.Maincode("ngonngu");                
            }
            catch { aNgonngu = ""; }
            if (aNgonngu.Trim() != "") user += aNgonngu;
            //
            ip = m.Maincode("Ip");
            post = m.Maincode("Post");
            owner = m.Maincode("UserID");
            if (owner == "") owner = "medisoft";
            database = m.Maincode("Database");
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            
            foreach (DataRow r in m.get_data("select * from " + user + ".table where bak=0").Tables[0].Rows)
            {
                tenfile = user + r["mmyy"].ToString();
                arg = " -i -h " + ip + " -p " + post + " -U " + owner + " -F c -o -v -f " + path + tenfile + ".backup -n " + tenfile + " " + database;
                f = new Run(file, arg, true);
                f.Launch();
            }
            tenfile = user;
            arg = " -i -h " + ip + " -p " + post + " -U " + owner + " -F c -o -v -f " + path + tenfile + ".backup -n " + tenfile + " " + database;
            f = new Run(file, arg, true);
            f.Launch();
		}
	}
}
