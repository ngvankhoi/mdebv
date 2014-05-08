using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class Client
    {
       private string _host="";
       private string _port="";
       private string _dbname="medisoft";
       private string _userdb="medisoft";
       private string _passdb="links1920";
       private string _server = "";
       private long _id=0;
       private int _thoigian = 5;
       private int _stt = 0;
       private string _dklink;
       private string image_path;
       private string image_path_HinhBN;
       private string image_path_HinhChungtu;
       public Client()
       { }
       public Client(string host,string port,string dbname,string userdb,string passdb,string servername)
       {
           this.Host = host;
           this.DatabaseName = dbname;
           this.Port = port;
           this.Userdb = userdb;
           this.Passworddb = passdb;
           this.ServerName = servername;
           //this.Thoigian = thoigian;
       }
       /// <summary>
       /// Địa chỉ ip hoặc tên máy trạm. get,set.
       /// </summary>
       public string Host
       {
           get { return _host; }
           set { _host = value; }
       }
       /// <summary>
       /// địa chỉ cổng mà database sử dụng. get,set
       /// </summary>
       public string Port
       {
           get { return _port; }
           set { _port = value; }
       }
       /// <summary>
       /// tên database lưu trên máy trạm. get,set
       /// </summary>
       public string DatabaseName
       {
           get { return _dbname; }
           set { _dbname = value; }
       }
       /// <summary>
       /// tên để đăng nhập vào database.get,set
       /// </summary>
       public string Userdb
       {
           get { return _userdb; }
           set { _userdb = value; }
       }
       /// <summary>
       /// mật khẩu để vào database.get,set
       /// </summary>
       public string Passworddb
       {
           get { return _passdb; }
           set { _passdb = value; }
       }
       /// <summary>
       /// tên máy chủ trạm. get,set
       /// </summary>
       public string ServerName
       {
           get { return _server; }
           set { _server = value; }
       }
       /// <summary>
       /// Khoảng thời gian để cập nhật.get,set
       /// </summary>
       public int Thoigian
       {
           get { return _thoigian; }
           set { _thoigian = value; }
       }
       public long ID
       {
           get { return _id; }
           set { _id = value; }
       }
       public string DbLink
       {
           get { return _dklink; }
           set { _dklink = value; }
       }
       public int STT
       {
           get { return (int)(this.ID * 3 - 2); }
           set { _stt = value; }
       }
       public bool TaoDBLink()
       {
           if (_host == "") return false;
           if (_port == "") return false;
           if (_userdb == "") return false;
           if (_passdb == "") return false;
           if (_dbname == "") return false;
           if (_stt == -1) return false;
           if (_dklink == "") return false;
           Accessdata acc = new Accessdata();
           return acc.CreateDblink(this);
       }
       public bool XoaDBLink()
       {
           Accessdata acc = new Accessdata();
           return acc.DropdbLink(this);
       }
       public string ImagePath
       {
           set { image_path = value; }
           get { return image_path; }
       }

       public string ImagePath_BN
       {
           set { image_path_HinhBN = value; }
           get { return image_path_HinhBN; }
       }
       public string ImagePath_Chungtu
       {
           set { image_path_HinhChungtu = value; }
           get { return image_path_HinhChungtu; }
       }
    }
}
