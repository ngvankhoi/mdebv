using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class Thongbao
    {
        public static void Message(string errorCode)
        {
            System.Windows.Forms.MessageBox.Show(Error(errorCode),"Synchrozise",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
        }
        public static void Message(string errorCode,int typeMsg,string msg)
        {
            switch (typeMsg)
            {
                case 1:
                    System.Windows.Forms.MessageBox.Show(Error(errorCode)+" "+msg, "Synchrozise", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    break;
                default: break;
            }
            
        }
        private static string Error(string code)
        {
            string msg = "";
            switch (code)
            {
                case "Syn001":
                    msg = "Bạn chưa nhập địa chỉ IP !";
                    break;
                case "Syn002":
                    msg = "Bạn chưa nhập địa chỉ Port !";
                    break;
                case "Syn003":
                    msg = "Bạn chưa nhập địa chỉ User !";
                    break;
                case "Syn004":
                    msg = "Bạn chưa nhập địa chỉ Password !";
                    break;
                case "Syn005":
                    msg = "Bạn chưa nhập địa chỉ database name !";
                    break;
                case "Syn006":
                    msg = "Bạn chưa nhập địa chỉ ten máy !";
                    break;
                case "MC001":
                    msg = "Tạo database link không thành công :"+DAL.Accessdata.error;
                    break;
                case "MC002":
                    msg = "Không lưu được thông tin máy trạm :" + DAL.Accessdata.error;
                    break;
                case "MC003":
                    msg = code+": Bạn không có quyền thực hiện chức năng này  ";
                    break;
                case "CL001":
                    msg = "Không thể lấy được ID từ server !" + DAL.Accessdata.error;
                    break;
                case "ER001":
                    msg = "Không tìm thấy file table.xml trong thư mục xml !";
                    break;
                case "001":
                    msg = "Lưu thành công ";
                    break;
                case "Log001":
                    msg = "Lỗi log001: Mật khẩu đăng nhập không hợn lệ! ";
                    break;
                case "Log002":
                    msg = "Lỗi Log002: Tên đăng nhập không hợp lê ! ";
                    break;
                case "Syn007":
                    msg = "Lỗi "+code+": Không có primary key ! ";
                    break;
                case "Syn008":
                    msg = "Lỗi " + code + ": ??? ! ";
                    break;
                default:
                    msg = "";
                    break;
            }
            return msg;
        }
    }
}
