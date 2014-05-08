using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class user:basic
    {
       private string _username = "links";
       private string _password = "links1920" + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2).PadLeft(2, '0');
       public user()
       { }
       public string UserName
       {
           get { return  _username; }
           set { _username = value; }
       }
       public string Password
       {
           get { return _password; }
           set { _password = value; }
       }
    }
}
