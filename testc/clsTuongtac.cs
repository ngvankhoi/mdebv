using System.Windows.Forms;
using System;
using System.Data;
using LibDuoc;

namespace testc
{
	/// <summary>
	/// Summary description for clsTuongtac.
	/// </summary>
	public class clsTuongtac
	{
        Language lan = new Language();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private LibMedi.AccessData m = new LibMedi.AccessData();
		private string sql="";
        private int flag_language = 0;
        private DataTable dttt, dteffect, dtaction, dtmechanism;
        public string s_severity = "", s_effect = "", s_actions = "", s_mec_detail = "", s_mechanism = "", s_tenhc1 = "", s_tenhc2 = "", s_tenbd1="", s_tenbd2="",s_tenbd_tt1="", s_tenbd_tt2="";
        public string s_tieude_tuongtac = "", s_diengiai_tuongtac = "";
        private string s_mabdtt = "";
        private string suser_tt = "medibv_drug";
		public clsTuongtac()
		{
			//
			// TODO: Add constructor logic here
			//
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
		}
		public DataTable get_db_tuongtac(string s_generic1)
		{
            string suser = d.user;
            //sql = "select * from " + suser + ".d_group where lower(generic1)='" + s_generic1.Trim() + "'";
            sql = "select lower(generic1) as generic1, lower(generic2) as generic2, g1, g2, effect, a.severity, action1, action2, action3, action4, action5 ";
            sql += ", b.effect_eng, effect_vn, c1.action_eng as action_eng1, c1.action_vn as action_vn1, c2.action_eng as action_eng2, c2.action_vn as action_vn2, c3.action_eng as action_eng3, c3.action_vn as action_vn3, c4.action_eng as action_eng4, c4.action_vn as action_vn4, c5.action_eng as action_eng5, c5.action_vn as action_vn5 ";
            sql += ", d.vietnam as severity_v, d.severity_e, a.kt_ ";
            sql += " from " + suser_tt + ".d_drug_interaction_full a, " + suser_tt + ".d_effect b,  " + suser_tt + ".d_action c1," + suser_tt + ".d_action c2," + suser_tt + ".d_action c3, " + suser_tt + ".d_action c4, " + suser_tt + ".d_action c5 ";
            sql += " , " + suser_tt + ".d_severity d";
            sql += " where a.effect=b.code(+) and a.action1=c1.code(+) and a.action2=c2.code(+) and a.action3=c3.code(+) and a.action4=c4.code(+) and a.action5=c5.code (+) ";
            sql += " and a.severity = d.code(+)";
            sql += " and lower(a.generic1)='" + s_generic1.Trim().ToLower() + "'";
			return d.get_data(sql).Tables[0];
		}

        public DataTable get_db_tuongtac_group(string s_group)
        {
            //sql = "select * from " + d.user + ".d_group where lower(group1)='" + s_group.Trim() + "'";            
            sql = "select * from " + suser_tt + ".drug_interaction where lower(g1)='" + s_group.Trim() + "'";            
            return d.get_data(sql).Tables[0];
        }
		public bool get_tuongtac_group(DataTable dthc, string s_generic1, string s_generic2)
		{			
			//
			s_actions="";
			s_effect="";
            //s_effect_vn = "";
			s_severity="";
			s_mec_detail="";
			s_mechanism="";
            s_tieude_tuongtac = "";
            s_diengiai_tuongtac = "";
			//
			bool b_tuongtac=false;
            string s_ten_group1 = "";
            string s_ten_group2 = "";
			string []s1;
			string []s2;
            string[] a_mabdtt;
			s1=s_generic1.Split('+');
			s2=s_generic2.Split('+');
            a_mabdtt = s_mabdtt.Split('+');
            int i_tuongtac = 1;
			for(int i=0;i<s1.Length;i++)
			{                
                s_ten_group1 = get_ten_group(dthc, s1[i].Trim().Replace("'", ""));
                if (s_ten_group1.Trim() != "")
                {
                    dttt = get_db_tuongtac_group(s_ten_group1);
                    //
                    for (int j = i; j < s2.Length; j++)
                    {

                        if (s1[i].Trim().Replace("'", "") != s2[j].Trim().Replace("'", "") && a_mabdtt[i]!=a_mabdtt[j])
                        {
                            s_ten_group2 = get_ten_group(dthc, s2[j].Trim().Replace("'", ""));                            
                            if (s_ten_group2 != "")
                            {
                                string exp = " effect_eng<>'' and (group1='" + s_ten_group1 + "' and group2='" + s_ten_group2 + "')";// or (group1='" + s_ten_group2 + "' and group2='" + s_ten_group1 + "')";
                                DataRow dr = getrowbyid(dttt, exp);
                                if (dr != null)
                                {
                                    s_tenhc1 = s1[i].Trim();
                                    s_tenhc2 = s2[j].Trim();
                                    s_effect = dr["effect_eng"].ToString().Trim();
                                    s_effect = (flag_language == 0) ? get_effect_vn(dteffect, s_effect) : s_effect;
                                    s_actions = "";
                                    if (dr["action1_en"].ToString().Trim() != "") s_actions = ((flag_language == 0) ? get_action_vn(dtaction, dr["action1_en"].ToString().Trim()) : dr["action1_en"].ToString().Trim()) + "\n";
                                    if(dr["action2_en"].ToString().Trim()!="") s_actions += ((flag_language == 0) ? get_action_vn(dtaction, dr["action2_en"].ToString().Trim()) : dr["action2_en"].ToString().Trim()) + "\n";
                                    if (dr["action3_en"].ToString().Trim() != "") s_actions += ((flag_language == 0) ? get_action_vn(dtaction, dr["action3_en"].ToString().Trim()) : dr["action3_en"].ToString().Trim()) + "\n";
                                    if (dr["action4_en"].ToString().Trim() != "") s_actions += ((flag_language == 0) ? get_action_vn(dtaction, dr["action4_en"].ToString().Trim()) : dr["action4_en"].ToString().Trim()) + "\n";
                                    if (dr["action5_en"].ToString().Trim() != "") s_actions += ((flag_language == 0) ? get_action_vn(dtaction, dr["action5_en"].ToString().Trim()) : dr["action5_en"].ToString().Trim()) + "\n";
                                    //
                                    s_severity = dr["severity"].ToString().Trim();
                                    s_mechanism = dr["mechanism"].ToString().Trim();
                                    s_mec_detail = dr["mec_detail"].ToString().Trim();
                                    //
                                    if (s_tieude_tuongtac.Trim() != "") s_tieude_tuongtac += "\n";
                                    
                                    //
                                    if (s_diengiai_tuongtac.Trim() != "") s_diengiai_tuongtac += "\n\n";
                                    if (flag_language == 0)//viet nam
                                    {
                                        s_tieude_tuongtac += i_tuongtac.ToString() + ". '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                        s_diengiai_tuongtac += i_tuongtac.ToString() + ". \n" + "+ TÁC ĐỘNG : '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                        s_diengiai_tuongtac += "\n";
                                        s_diengiai_tuongtac += "+ MỨC ĐỘ NGHIÊM TRỌNG : " + s_severity;
                                        s_diengiai_tuongtac += "\n";
                                        s_diengiai_tuongtac += "+ XỬ TRÍ: \n" + s_actions;
                                        s_diengiai_tuongtac += "\n";
                                        s_diengiai_tuongtac += "+ CƠ CHẾ : " + s_mec_detail;
                                    }
                                    else
                                    {
                                        s_tieude_tuongtac += i_tuongtac.ToString() + ". '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                        s_diengiai_tuongtac += i_tuongtac.ToString() + ". \n" + "+ EFFECT : '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                        s_diengiai_tuongtac += "\n";
                                        s_diengiai_tuongtac += "+ SEVERITY LEVEL : " + s_severity;
                                        s_diengiai_tuongtac += "\n";
                                        s_diengiai_tuongtac += "+ ACTIONS: " + s_actions;
                                        s_diengiai_tuongtac += "\n";
                                        s_diengiai_tuongtac += "+ MECHANISM DETAIL : " + s_mec_detail;
                                    }
                                    i_tuongtac += 1;
                                    // 
                                    b_tuongtac = true;
                                }
                            }
                        }
                    }
                }
			}
            return b_tuongtac;
		}

        public bool get_tuongtac(string s_generic1, string s_generic2)
        {
            //
            s_actions = "";
            s_effect = "";            
            s_severity = "";
            s_mec_detail = "";
            s_mechanism = "";
            s_tieude_tuongtac = "";
            s_diengiai_tuongtac = "";
            //
            bool b_tuongtac = false;
            string s_ten_group1 = "";
            string s_ten_group2 = "";
            string s_datuongtac = "";
            string s_kt_="";
            string[] s1;
            string[] s2;
            string[] a_tenbd1;
            string[] a_tenbd2;
            string[] a_mabdtt;
            s1 = s_generic1.Split('+');
            s2 = s_generic2.Split('+');
            //
            a_tenbd1 = s_tenbd1.Split('+');
            a_tenbd2 = s_tenbd2.Split('+');
            //
            a_mabdtt = s_mabdtt.Split('+');
            int i_tuongtac = 1;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i].Replace("'", "").Trim() != "")
                {
                    dttt = get_db_tuongtac(s1[i].Trim().Replace("'",""));
                    if(dttt.Rows.Count>0)
                    {
                    //
                        for (int j = 0; j < s2.Length; j++)
                        {
                            string s_tmp_datuongtac = j.ToString().PadLeft(3, '0') + i.ToString().PadLeft(3,'0') + "+";//kiem tra nhung thuoc da co tuong tac 1 chieu roi thi khong can kiem tra lai: vi du: A tuong tac B thi loai bo B tuong A
                            if (i != j && s_datuongtac.IndexOf(s_tmp_datuongtac)<0 && s1[i].Trim().Replace("'", "") != s2[j].Trim().Replace("'", "") && a_mabdtt[i] != a_mabdtt[j])
                            {
                                if (s2[j].Replace("'", "").Trim() != "")
                                {
                                    //string exp = " effect_eng<>'' and (group1='" + s_ten_group1 + "' and group2='" + s_ten_group2 + "')";// or (group1='" + s_ten_group2 + "' and group2='" + s_ten_group1 + "')";
                                    string exp = "generic1='" + s1[i].Replace("'", "").Trim().ToLower() + "' and generic2='" + s2[j].Replace("'", "").Trim().ToLower() + "'";
                                    DataRow dr = getrowbyid(dttt, exp);
                                    if (dr != null)
                                    {
                                        s_datuongtac += i.ToString().PadLeft(3, '0') + j.ToString().PadLeft(3,'0') + "+";//danh dau nhung thuoc da tuong tac

                                        s_tenhc1 = s1[i].Trim();
                                        s_tenhc2 = s2[j].Trim();
                                        s_tenbd_tt1 = a_tenbd1[i].ToString().Trim();
                                        s_tenbd_tt2 = a_tenbd2[j].ToString().Trim();
                                        //
                                        s_ten_group1 = dr["g1"].ToString();
                                        s_ten_group2 = dr["g2"].ToString();
                                        //
                                        s_kt_=dr["kt_"].ToString().Trim();
                                        //
                                        s_effect = (flag_language == 0) ? dr["effect_vn"].ToString().Trim() : dr["effect_eng"].ToString().Trim();
                                        //
                                        s_actions = "";
                                        string s_actions1 = ((flag_language == 0) ? dr["action_vn1"].ToString().Trim() : dr["action_eng1"].ToString().Trim());
                                        if (s_actions1.Trim() != "") s_actions1 += "\n";
                                        string s_actions2 = ((flag_language == 0) ? dr["action_vn2"].ToString().Trim() : dr["action_eng2"].ToString().Trim());
                                        if (s_actions2.Trim() != "") s_actions2 += "\n";
                                        string s_actions3 = ((flag_language == 0) ? dr["action_vn3"].ToString().Trim() : dr["action_eng3"].ToString().Trim());
                                        if (s_actions3.Trim() != "") s_actions3 += "\n";
                                        string s_actions4 = ((flag_language == 0) ? dr["action_vn4"].ToString().Trim() : dr["action_eng4"].ToString().Trim());
                                        if (s_actions4.Trim() != "") s_actions4 += "\n";
                                        string s_actions5 = ((flag_language == 0) ? dr["action_vn5"].ToString().Trim() : dr["action_eng5"].ToString().Trim());
                                        if (s_actions5.Trim() != "") s_actions5 += "\n";
                                        //
                                        s_actions = s_actions1 + s_actions2 + s_actions3 + s_actions4 + s_actions5;
                                        //
                                        s_severity = (flag_language == 0) ? dr["severity"].ToString().Trim() + " - " + dr["severity_v"].ToString().Trim() : dr["severity"].ToString().Trim() + " - " + dr["severity_e"].ToString().Trim();
                                        //s_mec_detail = dr["mec_detail"].ToString().Trim();
                                        //
                                        s_mec_detail = "";
                                        DataRow dr_mec = get_mechanism_vn(dtmechanism, s_ten_group1, s_ten_group2);
                                        if (dr_mec != null)
                                        {
                                            s_mec_detail = dr_mec["mec_vn"].ToString().Trim();// (flag_language == 0) ? dr_mec["mec_vn"].ToString().Trim() : dr_mec["mec_detail"].ToString().Trim();
                                        }                                        
                                        //
                                        try
                                        {
                                            int i_index = s_mec_detail.IndexOf("VN:");
                                            if (i_index >= 0)
                                            {
                                                if (flag_language == 0)
                                                {
                                                    s_mec_detail = s_mec_detail.Substring(i_index + 3).Trim();
                                                }
                                                else
                                                {
                                                    s_mec_detail = s_mec_detail.Substring(0, i_index).Trim();
                                                }
                                            }
                                        }
                                        catch { }
                                        //
                                        if (s_tieude_tuongtac.Trim() != "") s_tieude_tuongtac += "\n";

                                        //
                                        if (s_diengiai_tuongtac.Trim() != "") s_diengiai_tuongtac += "\n\n";
                                        if (flag_language == 0)//viet nam
                                        {
                                            if(s_kt_.Trim().ToLower()=="cheo")
                                            {
                                                s_tieude_tuongtac += i_tuongtac.ToString() + ". '" + s_tenbd_tt1 + " (" + s_tenhc1.ToUpper() + ")' " + s_effect + " '" + s_tenbd_tt2 + " (" + s_tenhc2.ToUpper() + ")'";
                                                s_diengiai_tuongtac += i_tuongtac.ToString() + ". \n" + "+ TÁC ĐỘNG : '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                            }
                                            else
                                            {
                                                s_tieude_tuongtac += i_tuongtac.ToString() + ". '" + s_tenbd_tt2 + " (" + s_tenhc2.ToUpper() + ")' " + s_effect + " '" + s_tenbd_tt1 + " (" + s_tenhc1.ToUpper() + ")'";
                                                s_diengiai_tuongtac += i_tuongtac.ToString() + ". \n" + "+ TÁC ĐỘNG : '" + s_tenhc2.ToUpper() + "' " + s_effect + " '" + s_tenhc1.ToUpper() + "'";
                                            }
                                            s_diengiai_tuongtac += "\n";
                                            s_diengiai_tuongtac += "+ MỨC ĐỘ NGHIÊM TRỌNG : " + s_severity;
                                            s_diengiai_tuongtac += "\n";
                                            s_diengiai_tuongtac += "+ XỬ TRÍ: \n" + s_actions;
                                            s_diengiai_tuongtac += "\n";
                                            s_diengiai_tuongtac += "+ CƠ CHẾ : " + s_mec_detail;
                                        }
                                        else
                                        {
                                            if (s_kt_.Trim().ToLower() == "cheo")
                                            {
                                                s_tieude_tuongtac += i_tuongtac.ToString() + ". '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                                s_diengiai_tuongtac += i_tuongtac.ToString() + ". \n" + "+ EFFECT : '" + s_tenhc1.ToUpper() + "' " + s_effect + " '" + s_tenhc2.ToUpper() + "'";
                                            }
                                            else
                                            {
                                                s_tieude_tuongtac += i_tuongtac.ToString() + ". '" + s_tenhc2.ToUpper() + "' " + s_effect + " '" + s_tenhc1.ToUpper() + "'";
                                                s_diengiai_tuongtac += i_tuongtac.ToString() + ". \n" + "+ EFFECT : '" + s_tenhc2.ToUpper() + "' " + s_effect + " '" + s_tenhc1.ToUpper() + "'";
                                            }
                                            s_diengiai_tuongtac += "\n";
                                            s_diengiai_tuongtac += "+ SEVERITY LEVEL : " + s_severity;
                                            s_diengiai_tuongtac += "\n";
                                            s_diengiai_tuongtac += "+ ACTIONS: " + s_actions;
                                            s_diengiai_tuongtac += "\n";
                                            s_diengiai_tuongtac += "+ MECHANISM DETAIL : " + s_mec_detail;
                                        }
                                        i_tuongtac += 1;
                                        // 
                                        b_tuongtac = true;
                                    }
                                }
                            }
                        }//end dttt.roes.count>0
                    }
                }
            }
            return b_tuongtac;
        }
        public DataTable get_dmbd(string i_nhomkho)
        {
            sql = "select * from " + d.user + ".d_dmbd where nhom=" + i_nhomkho;
            return d.get_data(sql).Tables[0];
        }
        public string get_tenhc(DataTable dtdmbd, DataTable dttoa)
        {
            string exp = "", s_tenhc="";
            string[] a_hc;
            //
            s_tenbd1 = "";
            s_tenbd2 = "";
            //
            foreach (DataRow r in dttoa.Rows)
            {
                exp = "id="+r["mabd"].ToString();
                DataRow dr = getrowbyid(dtdmbd, exp);
                if (dr != null)
                {
                    try
                    {
                        //lay field generic cua BS tien bo sung sau. Neu khong co field nay thi lay field tenhc
                        if (dr["generic"].ToString().Trim() != "")
                        {
                            s_tenhc += dr["generic"].ToString().Trim().ToLower() + "+";                            
                            a_hc = dr["generic"].ToString().Split('+');
                            for (int j = 0; j < a_hc.Length; j++)
                            {
                                s_mabdtt += r["mabd"].ToString() + "+";
                                //
                                s_tenbd1 += dr["ten"].ToString() + " " + dr["hamluong"].ToString() + "+";//+ " [" + dr["dang"].ToString() + "]" + "+";
                                //
                            }
                        }
                        else if (dr["tenhc"].ToString().Trim() != "")
                        {
                            s_tenhc += dr["tenhc"].ToString().Trim().ToLower() + "+";
                            a_hc = dr["tenhc"].ToString().Split('+');
                            for (int j = 0; j < a_hc.Length; j++)
                            {
                                s_mabdtt += r["mabd"].ToString() + "+";
                                //
                                s_tenbd1 += dr["ten"].ToString() + " " + dr["hamluong"].ToString() + "+"; //+" [" + dr["dang"].ToString() + "]" + "+";
                                //
                            }
                        }
                    }
                    catch
                    {
                        if (dr["tenhc"].ToString().Trim() != "")
                        {
                            s_tenhc += dr["tenhc"].ToString().Trim().ToLower() + "+";
                            a_hc = dr["tenhc"].ToString().Split('+');
                            for (int j = 0; j < a_hc.Length; j++)
                            {
                                s_mabdtt += r["mabd"].ToString() + "+";
                                //
                                s_tenbd1 += dr["ten"].ToString() + " " + dr["hamluong"].ToString() + "+"; //+ " [" + dr["dang"].ToString() + "]" + "+";
                                //
                            }
                        }
                    }
                }
            }
            s_mabdtt.Trim('+');
            s_tenbd1 = s_tenbd1.Trim().Trim('+');
            s_tenbd2 = s_tenbd1; 
            return s_tenhc.Trim().Trim('+');
        }

        public string get_ten_group(DataTable dtdmhc, string s_tenhc)
        {
            string exp = "", s_ten_group = "";
            exp = "generic='" + s_tenhc.Trim() + "'";
            //
            foreach (DataRow r in dtdmhc.Select(exp))
            {
                if (r["_group"].ToString().Trim() != "")
                        s_ten_group = r["_group"].ToString().Trim().ToLower();                
            }
            //
            return s_ten_group.Trim().Trim('+');
        }

        public DataTable get_dmhc_bo()
        {
            sql = "select * from " + suser_tt + ".dmhc ";// where nhom=" + i_nhomkho;
            return d.get_data(sql).Tables[0];
        }
        /// <summary>
        /// Kiem tra tuong tac thuoc giua cac thuoc trong toa
        /// Thong so: dttoa: danh sach cac thuoc trong toa, dttoa phai co file mabd
        /// thong so: i_nhomkho: la ma nhom kho
        /// </summary>
        /// <param name="dttoa"></param>
        /// <param name="i_nhomkho"></param>
        /// <returns>l,,l,l</returns>
        public bool kiemtra_tuongtac(DataTable dttoa, int i_nhomkho)
        {
            //Kiem tra xem co cai dat tuong tac thuoc chua
            //b1: Nhap toa cua BS
            //b2: lay danh muc d_dmbd: get_dmbd
            //b3: goi ham lay ten hoach: get_tenhc: lay 2 bien ten hoat chat1
            //b4: goi ham get_tuongtac(ten goup hc1, group hc2)
            //b5: lay ket qua tuong tac: la cac bien sau:
            //s_actions
            //s_effect 
            //s_severity 
            //s_mec_detail 
            //s_mechanism
            
            //
            int i_error = 0;
            bool b_tuongtac = false;
            //
            //
            if (dttoa.Rows.Count <= 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập toa thuốc vào!"), lan.Change_language_MessageText("Thông báo - Tương tác thuốc"));
                return b_tuongtac;
            }
            //
            b_tuongtac = check_module_tuongtacthuoc(suser_tt);
            if (b_tuongtac == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa cài đặt tương tác thuốc vào hệ thống, đề nghị liên hệ với Quản trị mạng!"), lan.Change_language_MessageText("Thông báo - Tương tác thuốc"));
                return b_tuongtac;
            }
            //
            load_dmeffect();
            load_dmaction();
            load_dmmechanism();
            try
            {
                DataTable dtdmbd = get_dmbd(i_nhomkho.ToString());
                s_mabdtt = "";
                s_tenbd1 = "";
                s_tenbd2 = "";
                string s_hc1 = get_tenhc(dtdmbd, dttoa);
                string s_hc2 = s_hc1;
                i_error += 1;
                //DataTable dtdmhc = get_dmhc();
                //i_error += 1;
                b_tuongtac=get_tuongtac( s_hc1, s_hc2);
                //b_tuongtac = get_tuongtac_group(dtdmhc, s_hc1, s_hc2);
                i_error += 1;
                if (b_tuongtac)
                {
                    frmhienthi_tuongtac f = new frmhienthi_tuongtac(s_tieude_tuongtac, s_diengiai_tuongtac);
                    f.Show();
                }                
                else
                {
                    b_tuongtac = false;
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy tương tác trên cơ sở dữ liệu hiện hành của hệ thống!"), lan.Change_language_MessageText("Thông báo - Tương tác thuốc"));
                }
                dtdmbd.Dispose();
                //dtdmhc.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(i_error.ToString() + " - " + ex.Message);
            }
            return b_tuongtac;
        }
        private void load_dmeffect()
        {
            sql = " select * from " + suser_tt + ".d_effect" ;
            dteffect = d.get_data(sql).Tables[0];
        }

        
        private string get_effect_vn(DataTable dt, string effect_eng)
        {
            string exp = " effect_eng='" + effect_eng + "'";
            DataRow dr = getrowbyid(dt, exp);
            string s_eff = effect_eng;
            if(dr!=null)
            {
                s_eff = dr["effect_vn"].ToString();
            }
            return s_eff;
        }

        private string get_action_vn(DataTable dt, string action_eng)
        {
            string exp = " action_eng='" + action_eng + "'";
            DataRow dr = getrowbyid(dt, exp);
            string s_action = action_eng;
            if (dr != null)
            {
                s_action  = dr["action_vn"].ToString();
            }
            return s_action ;
        }
        private void create_table_kqtt()
        {
            sql = "SELECT 0 AS IDDRUG1, '' AS DRUG1, 0 AS IDDRUG2, '' AS DRUG2, '' AS GENERIC1, '' AS GROUP1, '' AS GENERIC2, '' AS GROUP2, '' AS EFFECT, 0 AS SEVERITY, '' AS ACTIONS, '' AS MECHANISM, '' AS MECDETAIL FROM " + d.user + ".doituong where 1=2 ";
            DataSet ds = d.get_data(sql);
            ds.WriteXml("..\\..\\..\\xml\\d_kqtuongtac.xml", XmlWriteMode.WriteSchema);
        }

        private void load_dmaction()
        {
            sql = " select * from " + suser_tt + ".d_action ";
            dtaction= d.get_data(sql).Tables[0];
        }

        private void load_dmmechanism()
        {
            sql = " select * from " + suser_tt + ".d_mechanism";//d_group
            dtmechanism = d.get_data(sql).Tables[0];
        }

        private DataRow get_mechanism_vn(DataTable dt, string group1, string group2)
        {            
            string exp = " g1='" + group1 + "' and g2='" + group2 + "'";
            DataRow dr = getrowbyid(dt, exp);            
            return dr ;
        }

        public DataRow getrowbyid(DataTable dt, string exp)
        {
            try
            {
                DataRow[] r = dt.Select(exp);
                return r[0];
            }
            catch { return null; }
        }

        private bool check_module_tuongtacthuoc(string s_schemaname)
        {
            try
            {
                sql = "Select * from pg_tables where schemaname='" + s_schemaname + "'";
                DataSet lds = d.get_data(sql);
                if (lds.Tables.Count <= 0) return false;
                else if (lds.Tables[0].Rows.Count <= 0) return false;
                else return true;

            }
            catch
            {
                return false;
            }
        }
	}
}
