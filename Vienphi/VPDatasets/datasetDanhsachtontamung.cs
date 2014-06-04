using System.Data;
namespace Vienphi.VPDatasets {


    partial class datasetDanhsachtontamung
    {
        partial class CHITIETTAMUNGDataTable
        {
        }
    
        partial class THANGNAMDataTable
        {
        }
    
        partial class TAMUNGDataTable
        {
        }
    
        string acc;
        public enum ERROCODE {
        SUCCESS,
            FAIL,
        }
        public void Initialize(string connectstr)
        {
            acc = connectstr;
            InitializeComponent();
            using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand("", new Npgsql.NpgsqlConnection(acc)))
            {
                try
                {
                    cmm.CommandText = "SELECT to_number(substring(substring(schema_name from '....$') from 1 for 2 )) thang,to_number('20'||(substring(substring(schema_name from '....$') from '..$'))) nam ,substring(substring(schema_name from '....$') from 1 for 2 )||'-20'||(substring(substring(schema_name from '....$') from '..$')) thangnam from information_schema.schemata where schema_name like 'medibv0%' or schema_name like 'medibv1%' order by thang,nam desc";
                    cmm.Connection.Open();
                    Npgsql.NpgsqlDataReader dtrd = cmm.ExecuteReader();
                    while (dtrd.Read())
                    {
                        THANGNAMRow nr = THANGNAM.NewTHANGNAMRow();
                        for (int i = 0; i < dtrd.FieldCount; i++)
                        {
                            if (THANGNAM.Columns.Contains(dtrd.GetName(i)))
                            {
                                nr[dtrd.GetName(i)] = dtrd[i];
                            }
                        }
                        THANGNAM.Rows.Add(nr);
                    }
                }
                finally
                {
                    cmm.Connection.Close();
                }
            }
        }
        private System.ComponentModel.BackgroundWorker bgW_LoadDataSet;
        public delegate void QuaTrinhTai(decimal percent,long curentRecord,long maxRecord,string message);
        public delegate void TaiHoanTat(ERROCODE er,datasetDanhsachtontamung data);
        public event QuaTrinhTai ThongBaoQuaTrinhTai;
       
       // private System.Windows.Forms.ProgressBar Progressbar;
        TaiHoanTat XulyTaiHoanTat;
        public void LoadDataAsyn(int thang,int nam,TaiHoanTat completcallback)
        {
            XulyTaiHoanTat = completcallback;
            if (acc == null)
                acc = new LibMedi.AccessData().ConStr;
            string schema = "medibv" + thang.ToString("00") + (nam % 100);
            TAMUNG.Clear();
            CHITIETTAMUNG.Clear();
            bgW_LoadDataSet.RunWorkerAsync(schema);
        }

        private void InitializeComponent()
        {
            this.bgW_LoadDataSet = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // bgW_LoadDataSet
            // 
            this.bgW_LoadDataSet.WorkerReportsProgress = true;
            this.bgW_LoadDataSet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgW_LoadDataSet_DoWork);
            this.bgW_LoadDataSet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgW_LoadDataSet_RunWorkerCompleted);
            this.bgW_LoadDataSet.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgW_LoadDataSet_ProgressChanged);
            // 
            // datasetDanhsachtontamung
            // 
            this.Initialized += new System.EventHandler(this.datasetDanhsachtontamung_Initialized);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private void bgW_LoadDataSet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            long max = 1;
            string schema = e.Argument.ToString();
            using (Npgsql.NpgsqlCommand cmm = new Npgsql.NpgsqlCommand("",new Npgsql.NpgsqlConnection(acc)))
            {
                try
                {
                    cmm.Connection.Open();
                    cmm.Transaction = cmm.Connection.BeginTransaction();
                    string sqlTb_tamungct = "select distinct * from (select ttu.mabn,bn.hoten,ttu.maql,ttu.mavaovien,ttu.quyenso,ttu.sobienlai,ttu.sotien as tiendong,ttu.ngay ngaydong,ht.sotien as hoantra,ht.ngay ngaytra, ttu.done, rv.sotien tongvienphi,rv.ngay ngayravien, (case when ba.maql is null then varchar 'Bệnh nhân không có bệnh án' else null end) as ghichu, b.hoten nguoithu,kp.tenkp from "+schema+".v_tontamung ttu left join  "+schema+".v_hoantra ht on ttu.quyenso = ht.quyenso and ttu.sobienlai = ht.sobienlai and ht.maql = ttu.maql left join  ( select sum(rvct.sotien) sotien,srv.mavaovien,max(rvct.ngay) ngay from "+schema+".v_ttrvds srv inner join "+schema+".v_ttrvct  as rvct on srv.id=rvct.id group by srv.mavaovien) rv on rv.mavaovien = ttu.mavaovien inner join medibv.btdbn bn on bn.mabn=ttu.mabn  left join medibv.benhandt ba on ba.maql = ttu.maql inner join medibv.v_dlogin b on ttu.userid= b.id left join medibv.btdkp_bv kp on ttu.makp= kp.makp group by ttu.mabn,ttu.maql,ttu.mavaovien,ttu.sotien ,ht.sotien ,ttu.quyenso,ttu.sobienlai, ht.quyenso , ht.sobienlai,ttu.done,bn.hoten,ttu.ngay,ht.ngay,ba.maql,rv.sotien,rv.ngay,b.hoten,kp.tenkp union all select ttu.mabn,bn.hoten,ttu.maql,ttu.mavaovien,ttu.quyenso,ttu.sobienlai,ttu.sotien as tiendong,ttu.ngay ngaydong,ht.sotien as hoantra,ht.ngay ngaytra, ttu.done, rv.sotien tongvienphi,rv.ngay ngayravien, (case when ba.maql is null then varchar 'Bệnh nhân không có bệnh án' else null end) as ghichu,b.hoten nguoithu,kp.tenkp from "+schema+".v_tamung ttu left join  "+schema+".v_hoantra ht on ttu.quyenso = ht.quyenso and ttu.sobienlai = ht.sobienlai and ht.maql = ttu.maql left join  ( select sum(rvct.sotien) sotien,srv.mavaovien,max(rvct.ngay) ngay from "+schema+".v_ttrvds srv inner join "+schema+".v_ttrvct  as rvct on srv.id=rvct.id group by srv.mavaovien) rv on rv.mavaovien = ttu.mavaovien inner join medibv.btdbn bn on bn.mabn=ttu.mabn  left join medibv.benhandt ba on ba.maql = ttu.maql inner join medibv.v_dlogin b on ttu.userid= b.id left join medibv.btdkp_bv kp on ttu.makp= kp.makp group by ttu.mabn,ttu.maql,ttu.mavaovien,ttu.sotien ,ht.sotien ,ttu.quyenso,ttu.sobienlai, ht.quyenso , ht.sobienlai,ttu.done,bn.hoten,ttu.ngay,ht.ngay,ba.maql,rv.sotien,rv.ngay,b.hoten,kp.tenkp)";
                    string sqlTb_tamung = "select mabn,hoten,maql,ngaynhapvien,sum(sotien) tientamung,count(*) solandong,sum(tienhoantra)tienhoantra,tienvienphi,min(done) hoantatca,ngayravien,ghichu,date_part('month',ngaynhapvien) thang,date_part('year',ngaynhapvien) nam from (select ttu.mabn,bn.hoten,ttu.maql,ba.ngay ngaynhapvien,ttu.sotien,ht.sotien as tienhoantra,rv.sotien tienvienphi, ttu.done, rv.ngay ngayravien, (case when ba.maql is null then varchar 'Bệnh nhân không có bệnh án' else null end) as ghichu from "+schema+".v_tontamung ttu left join  "+schema+".v_hoantra ht on ttu.quyenso = ht.quyenso and ttu.sobienlai = ht.sobienlai and ht.maql = ttu.maql left join  ( select sum(rvct.sotien) sotien,srv.mavaovien,max(rvct.ngay) ngay from "+schema+".v_ttrvds srv inner join "+schema+".v_ttrvct  as rvct on srv.id=rvct.id group by srv.mavaovien) rv on rv.mavaovien = ttu.mavaovien inner join medibv.btdbn bn on bn.mabn=ttu.mabn  left join medibv.benhandt ba on ba.maql = ttu.maql group by ttu.mabn,ba.ngay, ttu.done,bn.hoten,ttu.ngay,ht.ngay,ttu.maql,ba.maql,ttu.sotien,ht.sotien,rv.sotien,rv.ngay,ttu.quyenso,ttu.sobienlai union all select ttu.mabn,bn.hoten,ttu.maql,ba.ngay ngaynhapvien,ttu.sotien,ht.sotien as tienhoantra, rv.sotien tienvienphi, ttu.done, rv.ngay ngayravien, (case when ba.maql is null then varchar 'Bệnh nhân không có bệnh án' else null end) as ghichu from "+schema+".v_tamung ttu left join  "+schema+".v_hoantra ht on ttu.quyenso = ht.quyenso and ttu.sobienlai = ht.sobienlai and ht.maql = ttu.maql left join  ( select sum(rvct.sotien) sotien,srv.mavaovien,max(rvct.ngay) ngay from "+schema+".v_ttrvds srv inner join "+schema+".v_ttrvct  as rvct on srv.id=rvct.id group by srv.mavaovien) rv on rv.mavaovien = ttu.mavaovien inner join medibv.btdbn bn on bn.mabn=ttu.mabn  left join medibv.benhandt ba on ba.maql = ttu.maql  group by ttu.mabn,ba.ngay, ttu.done,bn.hoten,ttu.ngay,ht.ngay,ttu.maql,ba.maql,ttu.sotien,ht.sotien,rv.sotien,rv.ngay,ttu.quyenso,ttu.sobienlai) group by mabn,hoten,maql,ngaynhapvien,tienvienphi,ngayravien,ghichu";
                    //
                    cmm.CommandText = "select count(*) from (select id from " + schema + ".v_tontamung  union all select tu.id from " + schema + ".v_tamung tu )";
                    long sodongtamungct = 0;
                    Npgsql.NpgsqlDataReader dtrd = cmm.ExecuteReader();
                    if (dtrd.Read())
                    {
                        sodongtamungct = long.Parse(dtrd[0].ToString());
                    }
                    max += sodongtamungct;
                    cmm.CommandText = "select count(*) from(select distinct * from ( select distinct mabn,maql from " + schema + ".v_tontamung  union all select distinct mabn,maql from " + schema + ".v_tamung ))";
                    dtrd.Dispose();
                    dtrd = cmm.ExecuteReader();
                    if (dtrd.Read())
                    {
                        sodongtamungct = long.Parse(dtrd[0].ToString());
                    }
                    max += sodongtamungct;

                    //// bat dau load
                    if (ThongBaoQuaTrinhTai != null)
                        ThongBaoQuaTrinhTai(0, 0, max, "Begin Load");
                    long numcur = 0;
                    cmm.CommandText = sqlTb_tamungct;
                    dtrd.Dispose();
                    dtrd = cmm.ExecuteReader();
                    while (dtrd.Read())
                    {
                        numcur++;
                        CHITIETTAMUNGRow nr = CHITIETTAMUNG.NewCHITIETTAMUNGRow();
                        for (int i = 0; i < dtrd.FieldCount; i++)
                        {
                            if (CHITIETTAMUNG.Columns.Contains(dtrd.GetName(i)))
                            {
                                nr[dtrd.GetName(i)] = dtrd[i];
                            }
                        }
                        CHITIETTAMUNG.Rows.Add(nr);
                        if (ThongBaoQuaTrinhTai != null)
                            ThongBaoQuaTrinhTai(numcur / max * 100, numcur, max, "Load chi tiet tam ung");
                    }

                    cmm.CommandText = sqlTb_tamung;
                    dtrd.Dispose();
                    dtrd = cmm.ExecuteReader();
                    while (dtrd.Read())
                    {
                        numcur++;
                        TAMUNGRow nr = TAMUNG.NewTAMUNGRow();
                        for (int i = 0; i < dtrd.FieldCount; i++)
                        {
                            string name = dtrd.GetName(i);
                            if (TAMUNG.Columns.Contains(dtrd.GetName(i)))
                            {
                                nr[dtrd.GetName(i)] = dtrd[i];
                            }
                        }
                        TAMUNG.Rows.Add(nr);
                        if (ThongBaoQuaTrinhTai != null)
                            ThongBaoQuaTrinhTai(numcur / max * 100, numcur, max, "Load danh sach tam ung");
                    }
                    cmm.Transaction.Commit();
                    if (ThongBaoQuaTrinhTai != null)
                        ThongBaoQuaTrinhTai(max / max * 100, max, max, "Hoan tat");
                }
                catch
                {
                    if (ThongBaoQuaTrinhTai != null)
                       ThongBaoQuaTrinhTai(0 / max * 100, 0, max, "Loi trong qua trinh tai.");
                    if (XulyTaiHoanTat != null)
                        XulyTaiHoanTat(ERROCODE.FAIL, this);
                }
                finally
                {
                    cmm.Connection.Close();
                }
                
            }
        }

        private void bgW_LoadDataSet_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bgW_LoadDataSet_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (XulyTaiHoanTat != null)
                XulyTaiHoanTat(ERROCODE.SUCCESS,this);
        }

        private void datasetDanhsachtontamung_Initialized(object sender, System.EventArgs e)
        {

        }      
       
    }
}
