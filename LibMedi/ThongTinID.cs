using System;
using System.Collections.Generic;
using System.Text;

namespace LibMedi
{
    class ThongTinID
    {
    }
    public enum LoaiChungTuCanKyTen
    {
        GiayHoiChanCTCanQuang = 1,
        GiayCamDoanCTCanQuang = 2,
        GiayCamDoanPTTT = 3,
        PhieuKhamBenhCTXQuang = 4,
    }
    public enum IDThongSo
    {
        ID_SoPhieuDuyetDuTruKho = -99,
        ID_SoPhieuDuyetKeHoachDatHang = -98,
        ID_SoPhieuDuTruMuaTaiKhoDuoc = -97,
        ID_SoPhieuDuTruTuTrucKhoaPhong = -96,
        ID_SoPhieuDuyetKeHoachMuaHang = -95,
        ID_SoNgayToaThuocCanCanhBao = -1000,
        ID_TangCSTT = -1001,
        ID_SophieuNhap = -1002,
        ID_Sophieuxuat = -1003,
        ID_Apgia = -1004,
        ID_Sophieuxuat_kho = -1005,
        ID_ThongTuLienTich15042012 = -1006,
        ID_NgayVienPhiThongTuLienTich15042012 = -1007,
        ID_NgayBenhNhanThongTuLienTich15042012 = -1008,
    }

    public enum ma_table_capid
    {
        Sovaovien_tudong_ngoaitru_chungnoitru=5,
        Sovaovien_tudong_ngoaitru_rieng=-5,
        SoluutruPK_PL_NGT_tudong=200,
        Soluutru_ngtru_nam=-999,
    }

    public enum LoaiBenhAn
    {
        Noitru=1,
        Ngoaitru=2,
        Phongkham=3,
        Phongluu=4,
        Tiepdon=5,
    }
    /// <summary>
    /// Nhom phieu khai bao trong duoc
    /// </summary>
    public enum NhomPhieuLinh_CapToa
    {
        Phieulinh=1,
        PhieuXuatBuTuTruc=2,
        PhieuHoanTra=3,
        PhieuHaoPhiKhoaPhong=4,
        CapToaBHYT=5,
        CapToaBNPK_Khong_BHYT=6,
        CapToaDichvu=7,
        CapToa_BN_Dieutringoaitru=8,
        CaptoaThuocChuongTrinh=9,
    }
}
