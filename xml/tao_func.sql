create or replace function medibv0514.upd_tiepdon(m_mabn varchar,m_mavaovien numeric,m_maql numeric,m_makp varchar,m_ngay varchar,m_madoituong numeric,m_sovaovien varchar,m_tuoivao varchar,m_userid numeric,m_bnmoi numeric,m_noitiepdon numeric,m_loai numeric) returns void as 
$BODY$
begin
    update medibv0514.tiepdon set mabn=m_mabn,mavaovien=m_mavaovien,makp=m_makp,ngay=to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),madoituong=m_madoituong,sovaovien=m_sovaovien,tuoivao=m_tuoivao,userid=m_userid,bnmoi=m_bnmoi,noitiepdon=m_noitiepdon,loai=m_loai where maql=m_maql;
    if found=false then
        insert into medibv0514.tiepdon(mabn,mavaovien,maql,makp,ngay,madoituong,sovaovien,tuoivao,userid,bnmoi,noitiepdon,loai) values (m_mabn,m_mavaovien,m_maql,m_makp,to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),m_madoituong,m_sovaovien,m_tuoivao,m_userid,m_bnmoi,m_noitiepdon,m_loai);
    end if;
end;
$BODY$
language 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_lienhe(m_maql numeric,m_sonha text,m_thon text,m_cholam text,m_matt varchar,m_maqu varchar,m_maphuongxa varchar,m_tuoivao varchar,m_loai numeric,m_bnmoi numeric)  RETURNS void AS
$BODY$
begin
    update medibv0514.lienhe set  sonha=m_sonha,thon=m_thon,cholam=m_cholam,matt=m_matt,maqu=m_maqu,maphuongxa=m_maphuongxa,tuoivao=m_tuoivao,loai=m_loai,bnmoi=m_bnmoi where maql=m_maql;
    if found=false then
        insert into medibv0514.lienhe(maql,sonha,thon,cholam,matt,maqu,maphuongxa,tuoivao,loai,bnmoi) values (m_maql,m_sonha,m_thon,m_cholam,m_matt,m_maqu,m_maphuongxa,m_tuoivao,m_loai,m_bnmoi);
    end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_quanhe(m_maql numeric,m_quanhe text,m_hoten text,m_diachi text,m_dienthoai text)  RETURNS void AS
$BODY$
begin
    update medibv0514.quanhe set quanhe=m_quanhe,hoten=m_hoten,diachi=m_diachi,dienthoai=m_dienthoai  where maql=m_maql;
    if found=false then
        insert into medibv0514.quanhe(maql,quanhe,hoten,diachi,dienthoai) values (m_maql,m_quanhe,m_hoten,m_diachi,m_dienthoai);
    end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_quanhe(m_maql numeric,m_quanhe text,m_hoten text,m_diachi text,m_dienthoai text,m_phuongtien text)  RETURNS void AS
$BODY$
begin
    update medibv0514.quanhe set quanhe=m_quanhe,hoten=m_hoten,diachi=m_diachi,dienthoai=m_dienthoai,phuongtien=m_phuongtien  where maql=m_maql;
    if found=false then
        insert into medibv0514.quanhe(maql,quanhe,hoten,diachi,dienthoai,phuongtien) values (m_maql,m_quanhe,m_hoten,m_diachi,m_dienthoai,m_phuongtien);
    end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_sukien(m_mabn varchar,m_matiepdon numeric,m_noitiepdon numeric,m_macap numeric)
RETURNS void AS
$BODY$
begin
    update medibv0514.sukien set mabn=m_mabn where matiepdon=m_matiepdon and noitiepdon=m_noitiepdon and macap=m_macap;
    if found=false then
         insert into medibv0514.sukien(mabn,matiepdon,noitiepdon,macap) values (m_mabn,m_matiepdon,m_noitiepdon,m_macap);
 	end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_chidinh(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_ngay varchar,v_loai numeric,v_makp varchar,v_madoituong numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_vattu numeric,v_userid numeric,v_tinhtrang numeric,v_thuchien numeric,v_computer varchar,v_idchidinh numeric,v_maicd varchar,v_chandoan text,v_mabs text,v_loaiba numeric)
RETURNS void AS
$BODY$
begin
    update medibv0514.v_chidinh set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),loai=v_loai,makp=v_makp,madoituong=v_madoituong,mavp=v_mavp,soluong=v_soluong,dongia=v_dongia,vattu=v_vattu,userid=v_userid,tinhtrang=v_tinhtrang,thuchien=v_thuchien,computer=v_computer,maicd=v_maicd,chandoan=v_chandoan,mabs=v_mabs,loaiba=v_loaiba where id=v_id;
    if found=false then
        insert into medibv0514.v_chidinh(id,mabn,mavaovien,maql,idkhoa,ngay,loai,makp,madoituong,mavp,soluong,dongia,vattu,userid,tinhtrang,thuchien,computer,idchidinh,maicd,chandoan,mabs,loaiba) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_loai,v_makp,v_madoituong,v_mavp,v_soluong,v_dongia,v_vattu,v_userid,v_tinhtrang,v_thuchien,v_computer,v_idchidinh,v_maicd,v_chandoan,v_mabs,v_loaiba);
	end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_chidinh(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_ngay varchar,v_loai numeric,v_makp varchar,v_madoituong numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_vattu numeric,v_userid numeric,v_tinhtrang numeric,v_thuchien numeric,v_computer varchar,v_idchidinh numeric,v_maicd varchar,v_chandoan text,v_mabs text,v_loaiba numeric,v_ghichu text)
RETURNS void AS
$BODY$
begin
    update medibv0514.v_chidinh set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),loai=v_loai,makp=v_makp,madoituong=v_madoituong,mavp=v_mavp,soluong=v_soluong,dongia=v_dongia,vattu=v_vattu,userid=v_userid,tinhtrang=v_tinhtrang,thuchien=v_thuchien,computer=v_computer,maicd=v_maicd,chandoan=v_chandoan,mabs=v_mabs,loaiba=v_loaiba,ghichu=v_ghichu where id=v_id;
    if found=false then
        insert into medibv0514.v_chidinh(id,mabn,mavaovien,maql,idkhoa,ngay,loai,makp,madoituong,mavp,soluong,dongia,vattu,userid,tinhtrang,thuchien,computer,idchidinh,maicd,chandoan,mabs,loaiba,ghichu) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_loai,v_makp,v_madoituong,v_mavp,v_soluong,v_dongia,v_vattu,v_userid,v_tinhtrang,v_thuchien,v_computer,v_idchidinh,v_maicd,v_chandoan,v_mabs,v_loaiba,v_ghichu);
	end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_v_bhyt(v_id numeric,v_sothe varchar,v_maphu numeric,v_mabv varchar,v_noigioithieu varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_bhyt set sothe=v_sothe,maphu=v_maphu,mabv=v_mabv,noigioithieu=v_noigioithieu where id=v_id;
    if found=false then
        insert into medibv0514.v_bhyt(id,sothe,maphu,mabv,noigioithieu) values (v_id,v_sothe,v_maphu,v_mabv,v_noigioithieu);
    end if;
end;
$BODY$
LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_vienphill(v_id numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_makp varchar,v_hoten text,v_phai numeric,v_namsinh varchar,v_diachi text,v_loai numeric,v_loaibn numeric,v_userid numeric,v_masothue in varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_vienphill set quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,makp=v_makp,hoten=v_hoten,phai=v_phai,namsinh=v_namsinh,diachi=v_diachi,loai=v_loai,loaibn=v_loaibn,userid=v_userid,masothue=v_masothue where id=v_id;
    if found=false then
        insert into medibv0514.v_vienphill(id,quyenso,sobienlai,ngay,mabn,mavaovien,maql,idkhoa,makp,hoten,phai,namsinh,diachi,loai,loaibn,userid,masothue) values (v_id,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_mabn,v_mavaovien,v_maql,v_idkhoa,v_makp,v_hoten,v_phai,v_namsinh,v_diachi,v_loai,v_loaibn,v_userid,v_masothue);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_vienphict(v_id numeric,v_stt numeric,v_madoituong numeric,v_mavp numeric,v_ten text,v_soluong numeric,v_dongia numeric,v_mien numeric,v_thieu numeric,v_vattu numeric,v_mabs varchar,v_makp varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_vienphict set madoituong=v_madoituong,mavp=v_mavp,ten=v_ten,soluong=v_soluong,dongia=v_dongia,mien=v_mien,thieu=v_thieu,vattu=v_vattu,mabs=v_mabs,makp=v_makp  where id=v_id and stt=v_stt;
    if found=false then
        insert into medibv0514.v_vienphict(id,stt,madoituong,mavp,ten,soluong,dongia,mien,thieu,vattu,mabs,makp) values (v_id,v_stt,v_madoituong,v_mavp,v_ten,v_soluong,v_dongia,v_mien,v_thieu,v_vattu,v_mabs,v_makp);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_kiemtra(d_nhom numeric) 
RETURNS void AS
$BODY$
DECLARE
    d_id numeric;d_makho numeric;d_manguon numeric;d_nhomcc numeric;d_sttt numeric;d_tyle_ggia numeric;d_st_ggia numeric;d_slnhap numeric;d_slxuat numeric;
    d_stt numeric;d_mabd numeric;d_handung varchar;d_losx varchar;d_soluong numeric;d_giaban numeric;d_giamua numeric;
    d_loai varchar;d_khox numeric;d_khon numeric;d_thuoc numeric;i_loai numeric;d_makp numeric;d_theodoi numeric;
    d_stttchuyen numeric;d_namsx varchar;d_baohanh numeric;d_nguongoc numeric;d_tinhtrang numeric;d_sothe varchar;d_found numeric;
    cur_ll cursor (p_nhom numeric) is select id,makho,manguon,nhomcc from medibv0514.d_nhapll where nhom=p_nhom;
    cur_ct cursor (p_id numeric) is select stt,mabd,handung,losx,soluong,giaban,giamua,namsx,baohanh,nguongoc,tinhtrang,sothe,tyle_ggia,st_ggia from medibv0514.d_nhapct where id=p_id;
    cur_temp_tonkho cursor (p_nhom numeric) is select makho,mabd,sttt,sum(slnhap) as slnhap,sum(slxuat) as slxuat from temp_tonkhoct group by makho,mabd,sttt;
    cur_temp_tutruc cursor (p_nhom numeric) is select makho,makp,mabd,sttt,sum(slnhap) as slnhap,sum(slxuat) as slxuat from temp_tutrucct group by makho,makp,mabd,sttt;
begin
    update medibv0514.d_tonkhoct set slnhap=0,slxuat=0 where makho in (select id from medibv.d_dmkho where nhom=d_nhom);
    update medibv0514.d_tutrucct set slnhap=0,slxuat=0 where makho in (select id from medibv.d_dmkho where nhom=d_nhom);
    open cur_ll(d_nhom);
    loop
        fetch cur_ll into d_id,d_makho,d_manguon,d_nhomcc;
        if found=false then
            exit;
        end if;
        open cur_ct(d_id);
        loop
            fetch cur_ct into d_stt,d_mabd,d_handung,d_losx,d_soluong,d_giaban,d_giamua,d_namsx,d_baohanh,d_nguongoc,d_tinhtrang,d_sothe,d_tyle_ggia,d_st_ggia;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tonkhoct set slnhap=slnhap+d_soluong where idn=d_id and sttn=d_stt and makho=d_makho;
            d_found:=1;
            if found=false then
                update medibv.d_capid set id=id+1 where ma=9;
                select to_number(to_char(now(),'yyMMdd') || trim(to_char(floor(random()*100000000000) ,'000000000000'))) into d_sttt ;
                d_found:=0;
            else
                select stt into d_sttt from medibv0514.d_tonkhoct where idn=d_id and sttn=d_stt and makho=d_makho;
            end if;
            update medibv0514.d_theodoi set mabd=d_mabd,manguon=d_manguon,nhomcc=d_nhomcc,handung=d_handung,losx=d_losx,sothe=d_sothe,namsx=d_namsx,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,giamua=d_giamua,giaban=d_giaban,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_sttt;
            if found=false then
                insert into medibv0514.d_theodoi(id,mabd,manguon,nhomcc,handung,losx,sothe,namsx,namsd,baohanh,nguongoc,tinhtrang,giamua,giaban,tyle_ggia,st_ggia) values (d_sttt,d_mabd,d_manguon,d_nhomcc,d_handung,d_losx,d_sothe,d_namsx,d_namsx,d_baohanh,d_nguongoc,d_tinhtrang,d_giamua,d_giaban,d_tyle_ggia,d_st_ggia);
            end if;
            if d_found=0 then
                insert into medibv0514.d_tonkhoct(makho,stt,idn,sttn,mabd,tondau,slnhap,slxuat) values (d_makho,d_sttt,d_id,d_stt,d_mabd,0,d_soluong,0);
            end if;
        end loop;
        close cur_ct;
    end loop;
    close cur_ll;
    CREATE GLOBAL TEMPORARY TABLE temp_tonkhoct ( 
    makho numeric(3) default 0,sttt numeric(25) default 0, mabd numeric(7), tondau numeric(12,4), slnhap numeric(12,4), slxuat numeric(12,4))WITH OIDS ON COMMIT PRESERVE ROWS TABLESPACE medi_data;
    truncate table temp_tonkhoct;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select a.khox as makho,b.mabd,b.sttt,sum(soluong) as slxuat, 0 as slnhap from medibv0514.d_xuatll a,medibv0514.d_xuatct b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id and a.nhom=d_nhom and a.loai in('BS','CK','XK','VA','XC') group by a.khox,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select a.khon as makho,b.mabd,b.sttt,0 as slxuat,sum(soluong) as slnhap from medibv0514.d_xuatll a,medibv0514.d_xuatct b,medibv0514.d_theodoi c where a.id=b.id  and b.sttt=c.id and a.nhom=d_nhom and a.loai in('CK','TH','HT','NC') group by a.khon,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.d_ngtrull a,medibv0514.d_ngtruct b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id  and a.nhom=d_nhom  group by b.makho,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.bhytkb a,medibv0514.bhytthuoc b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id  and a.nhom=d_nhom  group by b.makho,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.d_xuatsdll a,medibv0514.d_thucxuat b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id  and a.nhom=d_nhom  and loai not in(2,3) group by b.makho,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.sttt,0 as slxuat,sum(soluong) as slnhap from medibv0514.d_xuatsdll a,medibv0514.d_thucxuat b,medibv0514.d_theodoi c where a.id=b.id  and b.sttt=c.id and a.nhom=d_nhom  and loai in(3) group by b.makho,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.d_xuatsdll a,medibv0514.d_thucbucstt b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id  and a.nhom=d_nhom  and loai in(2) group by b.makho,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.d_chuyenll a,medibv0514.d_chuyenct b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id  and a.nhom=d_nhom  group by b.makho,b.mabd,b.sttt;
    insert into temp_tonkhoct(makho,mabd,sttt,slxuat,slnhap)
        select b.makho,b.mabd,b.stttchuyen sttt,0 as slxuat,sum(soluong) as slnhap from medibv0514.d_chuyenll a,medibv0514.d_chuyenct b,medibv0514.d_theodoi c where a.id=b.id and b.stttchuyen=c.id  and a.nhom=d_nhom  group by b.makho,b.mabd,b.stttchuyen;
    open cur_temp_tonkho(d_nhom);
        loop
            fetch cur_temp_tonkho into d_makho,d_mabd,d_sttt,d_slnhap,d_slxuat;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tonkhoct set slnhap=slnhap+d_slnhap,slxuat=slxuat+d_slxuat where makho=d_makho and stt=d_sttt;
            if found=false then
                insert into medibv0514.d_tonkhoct(makho,stt,idn,sttn,mabd,tondau,slnhap,slxuat) values (d_makho,d_sttt,0,0,d_mabd,0,d_slnhap,d_slxuat);
            end if;
        end loop;
    close cur_temp_tonkho;
    CREATE GLOBAL TEMPORARY TABLE temp_tutrucct ( 
        makho numeric(3) default 0,makp numeric(7),sttt numeric(25) default 0, mabd numeric(7), tondau numeric(12,4), slnhap numeric(12,4), slxuat numeric(12,4))WITH OIDS ON COMMIT PRESERVE ROWS TABLESPACE medi_data;
    truncate table temp_tutrucct;
    insert into temp_tutrucct(makp,makho,mabd,sttt,slxuat,slnhap)
        select a.khox as makp,a.khon as makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.d_xuatll a,medibv0514.d_xuatct b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id and a.nhom=1 and a.loai in('HT','TH')
        group by a.khox,a.khon,b.mabd,b.sttt;
    insert into temp_tutrucct(makp,makho,mabd,sttt,slxuat,slnhap)    
        select a.khon as makp,a.khox makho,b.mabd,b.sttt,0 as slxuat,sum(soluong) as slnhap from medibv0514.d_xuatll a,medibv0514.d_xuatct b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id  and a.nhom=d_nhom and a.loai in('BS')
        group by a.khon,a.khox,b.mabd,b.sttt;
    insert into temp_tutrucct(makp,makho,mabd,sttt,slxuat,slnhap)
        select a.makp,b.makho,b.mabd,b.sttt,sum(soluong) as slxuat,0 as slnhap from medibv0514.d_xuatsdll a,medibv0514.d_thucxuat b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id and a.nhom=d_nhom  and a.loai in(2)
        group by a.makp,b.makho,b.mabd,b.sttt;
    insert into temp_tutrucct(makp,makho,mabd,sttt,slxuat,slnhap)
        select a.makp,b.makho,b.mabd,b.sttt,0 as slxuat,sum(soluong) as slnhap from medibv0514.d_xuatsdll a,medibv0514.d_thucbucstt b,medibv0514.d_theodoi c where a.id=b.id and b.sttt=c.id and a.nhom=d_nhom and a.loai in(2)
        group by a.makp,b.makho,b.mabd,b.sttt;
    open cur_temp_tutruc(d_nhom);
        loop
            fetch cur_temp_tutruc into d_makho,d_makp,d_mabd,d_sttt,d_slnhap,d_slxuat;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tutrucct set slnhap=slnhap+d_slnhap,slxuat=slxuat+d_slxuat where makho=d_makho and makp=d_makp and mabd=d_mabd and stt=d_sttt;
            if found=false then
                insert into medibv0514.d_tutrucct(makp,makho,stt,mabd,tondau,slnhap,slxuat) values (d_makp,d_makho,d_sttt,d_mabd,0,d_slnhap,d_slxuat);
            end if;
        end loop;
   close cur_temp_tutruc;
   update medibv0514.d_tutrucct set slnhap=0 where slnhap is null;
   update medibv0514.d_tutrucct set slxuat=0 where slxuat is null;
   update medibv0514.d_tonkhoct set slnhap=0 where slnhap is null;
   update medibv0514.d_tonkhoct set slxuat=0 where slxuat is null;
end;
$BODY$
 LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_kiemtra_cstt(d_nhom numeric)
RETURNS void AS
$BODY$
DECLARE
    d_id numeric;d_makho numeric;d_manguon numeric;d_nhomcc numeric;d_sttt numeric;d_tyle_ggia numeric;d_st_ggia numeric;
    d_stt numeric;d_mabd numeric;d_handung varchar;d_losx varchar;d_soluong numeric;d_giaban numeric;d_giamua numeric;
    d_loai varchar;d_khox numeric;d_khon numeric;d_thuoc numeric;i_loai numeric;d_makp numeric;d_theodoi numeric;
    d_stttchuyen numeric;d_namsx varchar;d_baohanh numeric;d_nguongoc numeric;d_tinhtrang numeric;d_sothe varchar;d_found numeric;
    cur_xuatll cursor (p_nhom numeric) is select id,loai,khox,khon from medibv0514.d_xuatll where nhom=p_nhom and loai='BS';
    cur_xuatct cursor (p_id numeric) is select stt,sttt,mabd,soluong from medibv0514.d_xuatct where id=p_id;
    cur_sdll cursor (p_nhom numeric) is select id,makp,loai,thuoc from medibv0514.d_xuatsdll where nhom=p_nhom and loai=4;
    cur_xuat cursor (p_id numeric) is select a.sttt,a.makho,a.mabd,a.soluong,c.theodoi from medibv0514.d_thucxuat a,medibv.d_dmbd b,medibv.d_dmnhom c where a.mabd=b.id and b.manhom=c.id and a.id=p_id;
    cur_sdbu cursor (p_nhom numeric) is select id,makp,loai,thuoc from medibv0514.d_xuatsdll where loai=2 and nhom=p_nhom;
    cur_bu cursor (p_id numeric) is select sttt,makho,mabd,soluong from medibv0514.d_thucbucstt where id=p_id;
begin
    update medibv0514.d_tutrucct set slnhap=0 where makho in (select id from medibv.d_dmkho where nhom=d_nhom);
    open cur_xuatll(d_nhom);
    loop
        fetch cur_xuatll into d_id,d_loai,d_khox,d_khon;
        if found=false then
            exit;
        end if;
        open cur_xuatct(d_id);
        loop
            fetch cur_xuatct into d_stt,d_sttt,d_mabd,d_soluong;
            if found=false then
                exit;
            end if;
            if d_loai='BS' then
                update medibv0514.d_tutrucct set slnhap=slnhap+d_soluong where makp=d_khon and makho=d_khox and stt=d_sttt;
                if found=false then
	                insert into medibv0514.d_tutrucct(makp,makho,stt,mabd,tondau,slnhap,slxuat) values (d_khon,d_khox,d_sttt,d_mabd,0,d_soluong,0);
                end if;
            end if;
        end loop;
        close cur_xuatct;
    end loop;
    close cur_xuatll;
    open cur_sdll(d_nhom);
    loop
        fetch cur_sdll into d_id,d_makp,i_loai,d_thuoc;
        if found=false then
            exit;
        end if;
        open cur_xuat(d_id);
        loop
            fetch cur_xuat into d_sttt,d_makho,d_mabd,d_soluong,d_theodoi;
            if found=false then
                exit;
            end if;
            if d_theodoi=1 then
                if i_loai=4 then
	                update medibv0514.d_tutrucct set slnhap=slnhap+d_soluong where makp=d_makp and makho=d_makho and stt=d_sttt;
	                if found=false then
		                insert into medibv0514.d_tutrucct(makp,makho,stt,mabd,tondau,slnhap,slxuat) values (d_makp,d_makho,d_sttt,d_mabd,0,d_soluong,0);
	                end if;
                end if;
            end if;
        end loop;
        close cur_xuat;
    end loop;
    close cur_sdll;
    open cur_sdbu(d_nhom);
    loop
        fetch cur_sdbu into d_id,d_makp,i_loai,d_thuoc;
        if found=false then
            exit;
        end if;
        open cur_bu(d_id);
        loop
            fetch cur_bu into d_sttt,d_makho,d_mabd,d_soluong;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tutrucct set slnhap=slnhap+d_soluong where makp=d_makp and makho=d_makho and stt=d_sttt;
            if found=false then
                insert into medibv0514.d_tutrucct(makp,makho,stt,mabd,tondau,slnhap,slxuat) values(d_makp,d_makho,d_sttt,d_mabd,0,d_soluong,0);
            end if;
        end loop;
    close cur_bu;
    end loop;
    close cur_sdbu;
end;
$BODY$
 LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_theodoi(d_id numeric,d_mabd numeric,d_manguon numeric,d_nhomcc numeric,d_handung varchar,d_losx varchar,d_sothe varchar,d_namsx varchar,d_namsd varchar,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_giamua numeric,d_giaban numeric,d_chietkhau numeric,d_giaban2 numeric,d_gianovat numeric,d_tyle_ggia numeric,d_st_ggia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_theodoi set mabd=d_mabd,manguon=d_manguon,nhomcc=d_nhomcc,handung=d_handung,losx=d_losx,sothe=d_sothe,namsx=d_namsx,namsd=d_namsd,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,giamua=d_giamua,giaban=d_giaban,chietkhau=d_chietkhau,giaban2=d_giaban2,gianovat=d_gianovat,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_id;
    if found=false then
        insert into medibv0514.d_theodoi(id,mabd,manguon,nhomcc,handung,losx,sothe,namsx,namsd,baohanh,nguongoc,tinhtrang,giamua,giaban,chietkhau,giaban2,gianovat,tyle_ggia,st_ggia) values (d_id,d_mabd,d_manguon,d_nhomcc,d_handung,d_losx,d_sothe,d_namsx,d_namsd,d_baohanh,d_nguongoc,d_tinhtrang,d_giamua,d_giaban,d_chietkhau,d_giaban2,d_gianovat,d_tyle_ggia,d_st_ggia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_theodoi(d_id numeric,d_mabd numeric,d_manguon numeric,d_nhomcc numeric,d_handung varchar,d_losx varchar,d_sothe varchar,d_namsx varchar,d_namsd varchar,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_giamua numeric,d_giaban numeric,d_chietkhau numeric,d_gianovat numeric,d_tyle_ggia numeric,d_st_ggia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_theodoi set mabd=d_mabd,manguon=d_manguon,nhomcc=d_nhomcc,handung=d_handung,losx=d_losx,sothe=d_sothe,namsx=d_namsx,namsd=d_namsd,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,giamua=d_giamua,giaban=d_giaban,chietkhau=d_chietkhau,gianovat=d_gianovat,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_id;
    if found=false then
        insert into medibv0514.d_theodoi(id,mabd,manguon,nhomcc,handung,losx,sothe,namsx,namsd,baohanh,nguongoc,tinhtrang,giamua,giaban,chietkhau,gianovat,tyle_ggia,st_ggia) values (d_id,d_mabd,d_manguon,d_nhomcc,d_handung,d_losx,d_sothe,d_namsx,d_namsd,d_baohanh,d_nguongoc,d_tinhtrang,d_giamua,d_giaban,d_chietkhau,d_gianovat,d_tyle_ggia,d_st_ggia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_theodoi(d_id numeric,d_mabd numeric,d_manguon numeric,d_nhomcc numeric,d_handung varchar,d_losx varchar,d_sothe varchar,d_namsx varchar,d_namsd varchar,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_giamua numeric,d_giaban numeric,d_gianovat numeric,d_tyle_ggia numeric,d_st_ggia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_theodoi set mabd=d_mabd,manguon=d_manguon,nhomcc=d_nhomcc,handung=d_handung,losx=d_losx,sothe=d_sothe,namsx=d_namsx,namsd=d_namsd,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,giamua=d_giamua,giaban=d_giaban,gianovat=d_gianovat,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_id;
    if found=false then
        insert into medibv0514.d_theodoi(id,mabd,manguon,nhomcc,handung,losx,sothe,namsx,namsd,baohanh,nguongoc,tinhtrang,giamua,giaban,gianovat,tyle_ggia,st_ggia) values (d_id,d_mabd,d_manguon,d_nhomcc,d_handung,d_losx,d_sothe,d_namsx,d_namsd,d_baohanh,d_nguongoc,d_tinhtrang,d_giamua,d_giaban,d_gianovat,d_tyle_ggia,d_st_ggia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tonkho(d_nhom numeric,d_loai numeric)
 RETURNS void AS
$BODY$
DECLARE
   d_makp numeric;d_makho numeric;d_mabd numeric;d_tondau numeric;d_slnhap numeric;d_slxuat numeric;d_manguon numeric;
   cur_tonkho cursor (p_nhom numeric) is select a.makho,a.mabd,sum(a.tondau) as tondau,sum(a.slnhap) as slnhap,sum(a.slxuat) as slxuat,b.manguon from medibv0514.d_tonkhoct a,medibv0514.d_theodoi b where a.stt=b.id and a.makho in (select id from medibv.d_dmkho where nhom=p_nhom) group by a.makho,a.mabd,b.manguon;
   cur_tutruc cursor (p_nhom numeric) is select a.makp,a.makho,a.mabd,sum(a.tondau) as tondau,sum(a.slnhap) as slnhap,sum(a.slxuat) as slxuat,b.manguon from medibv0514.d_tutrucct a,medibv0514.d_theodoi b where a.stt=b.id and a.makho in (select id from medibv.d_dmkho where nhom=p_nhom) group by a.makp,a.makho,a.mabd,b.manguon;
begin
    if d_loai=0 or d_loai=1 then
        update medibv0514.d_tonkhoth set tondau=0,slnhap=0,slxuat=0 where makho in (select id from medibv.d_dmkho where nhom=d_nhom);
        open cur_tonkho(d_nhom);
        loop
            fetch cur_tonkho into d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tonkhoth set tondau=tondau+d_tondau,slnhap=slnhap+d_slnhap,slxuat=slxuat+d_slxuat where makho=d_makho and mabd=d_mabd and manguon=d_manguon;
            if found=false then
                  insert into medibv0514.d_tonkhoth(makho,mabd,tondau,slnhap,slxuat,manguon) values (d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon);
            end if;
        end loop;
        close cur_tonkho;
    end if;
    if d_loai=0 or d_loai=2 then
        update medibv0514.d_tutructh set tondau=0,slnhap=0,slxuat=0 where makho in (select id from medibv.d_dmkho where nhom=d_nhom);
        open cur_tutruc(d_nhom);
        loop
            fetch cur_tutruc into d_makp,d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tutructh set tondau=tondau+d_tondau,slnhap=slnhap+d_slnhap,slxuat=slxuat+d_slxuat where makp=d_makp and makho=d_makho and mabd=d_mabd and manguon=d_manguon;
            if found=false then
                insert into medibv0514.d_tutructh(makp,makho,mabd,tondau,slnhap,slxuat,manguon) values (d_makp,d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon);
            end if;
        end loop;
        close cur_tutruc;
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tonkho(d_makho numeric)
 RETURNS void AS
$BODY$
DECLARE
   d_mabd numeric;d_tondau numeric;d_slnhap numeric;d_slxuat numeric;d_manguon numeric;
   cur_tonkho cursor(p_makho numeric) is select a.mabd,sum(a.tondau) as tondau,sum(a.slnhap) as slnhap,sum(a.slxuat) as slxuat,b.manguon from medibv0514.d_tonkhoct a,medibv0514.d_theodoi b where a.stt=b.id and a.makho=p_makho group by a.mabd,b.manguon;
begin
    update medibv0514.d_tonkhoth set tondau=0,slnhap=0,slxuat=0 where makho=d_makho;
    open cur_tonkho(d_makho);
    loop
        fetch cur_tonkho into d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tonkhoth set tondau=tondau+d_tondau,slnhap=slnhap+d_slnhap,slxuat=slxuat+d_slxuat where makho=d_makho and mabd=d_mabd and manguon=d_manguon;
        if found=false then
              insert into medibv0514.d_tonkhoth(makho,mabd,tondau,slnhap,slxuat,manguon) values (d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon);
        end if;
    end loop;
    close cur_tonkho;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tonkhoct(d_makho numeric,d_stt numeric,d_mabd numeric,d_tondau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_tonkhoct set mabd=d_mabd,tondau=d_tondau where makho=d_makho and stt=d_stt;
    if found=false then
        insert into medibv0514.d_tonkhoct(makho,stt,idn,sttn,mabd,tondau,slnhap,slxuat) values (d_makho,d_stt,0,0,d_mabd,d_tondau,0,0);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tutrucct(d_makp numeric,d_makho numeric,d_stt numeric,d_mabd numeric,d_tondau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_tutrucct set mabd=d_mabd,tondau=d_tondau where makp=d_makp and makho=d_makho and stt=d_stt;
    if found=false then
        insert into medibv0514.d_tutrucct(makp,makho,stt,mabd,tondau,slnhap,slxuat) values (d_makp,d_makho,d_stt,d_mabd,d_tondau,0,0);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngaysp varchar,d_sohd text,d_ngayhd varchar,d_bbkiem varchar,d_ngaykiem varchar,d_loai varchar,d_nguoigiao text,d_madv numeric,d_makho numeric,d_manguon numeric,d_nhomcc numeric,d_no text,d_co varchar,d_userid numeric,d_lydo numeric,d_chietkhau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapll set nhom=d_nhom,sophieu=d_sophieu,ngaysp=to_timestamp(d_ngaysp,'dd/mm/yyyy'),sohd=d_sohd,ngayhd=to_timestamp(d_ngayhd,'dd/mm/yyyy'),bbkiem=d_bbkiem,ngaykiem=null,loai=d_loai,nguoigiao=d_nguoigiao,madv=d_madv,makho=d_makho,manguon=d_manguon,nhomcc=d_nhomcc,no=d_no,co=d_co,userid=d_userid,lydo=d_lydo,chietkhau=d_chietkhau where id=d_id;
    if found=false then
        insert into medibv0514.d_nhapll(id,nhom,sophieu,ngaysp,sohd,ngayhd,bbkiem,ngaykiem,loai,nguoigiao,madv,makho,manguon,nhomcc,no,co,userid,lydo,chietkhau) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngaysp,'dd/mm/yyyy'),d_sohd,to_timestamp(d_ngayhd,'dd/mm/yyyy'),d_bbkiem,null,d_loai,d_nguoigiao,d_madv,d_makho,d_manguon,d_nhomcc,d_no,d_co,d_userid,d_lydo,d_chietkhau);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapll_kk(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngaysp varchar,d_sohd text,d_ngayhd varchar,d_bbkiem varchar,d_ngaykiem varchar,d_loai varchar,d_nguoigiao text,d_madv numeric,d_makho numeric,d_manguon numeric,d_nhomcc numeric,d_no text,d_co varchar,d_userid numeric,d_lydo numeric,d_chietkhau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapll set nhom=d_nhom,sophieu=d_sophieu,ngaysp=to_timestamp(d_ngaysp,'dd/mm/yyyy'),sohd=d_sohd,ngayhd=to_timestamp(d_ngayhd,'dd/mm/yyyy'),bbkiem=d_bbkiem,ngaykiem=to_timestamp(d_ngaykiem,'dd/mm/yyyy'),loai=d_loai,nguoigiao=d_nguoigiao,madv=d_madv,makho=d_makho,manguon=d_manguon,nhomcc=d_nhomcc,no=d_no,co=d_co,userid=d_userid,lydo=d_lydo,chietkhau=d_chietkhau where id=d_id;
    if found=false then
        insert into medibv0514.d_nhapll(id,nhom,sophieu,ngaysp,sohd,ngayhd,bbkiem,ngaykiem,loai,nguoigiao,madv,makho,manguon,nhomcc,no,co,userid,lydo,chietkhau) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngaysp,'dd/mm/yyyy'),d_sohd,to_timestamp(d_ngayhd,'dd/mm/yyyy'),d_bbkiem,to_timestamp(d_ngaykiem,'dd/mm/yyyy'),d_loai,d_nguoigiao,d_madv,d_makho,d_manguon,d_nhomcc,d_no,d_co,d_userid,d_lydo,d_chietkhau);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapct(d_id numeric,d_stt numeric,d_mabd numeric,d_handung varchar,d_losx varchar,d_vat numeric,d_soluong numeric,d_dongia numeric,d_sotien numeric,d_giaban numeric,d_giamua numeric,d_sl1 numeric,d_sl2 numeric,d_tyle numeric,d_cuocvc numeric,d_chaythu numeric,d_namsx varchar,d_tailieu text,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_sothe varchar,d_giabancu numeric,d_tyle_ggia numeric,d_st_ggia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapct set mabd=d_mabd,handung=d_handung,losx=d_losx,vat=d_vat,soluong=d_soluong,dongia=d_dongia,sotien=d_sotien,giaban=d_giaban,giamua=d_giamua,sl1=d_sl1,sl2=d_sl2,tyle=d_tyle,cuocvc=d_cuocvc,chaythu=d_chaythu,namsx=d_namsx,tailieu=d_tailieu,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,sothe=d_sothe,giabancu=d_giabancu,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_nhapct(id,stt,mabd,handung,losx,vat,soluong,dongia,sotien,giaban,giamua,sl1,sl2,tyle,cuocvc,chaythu,namsx,tailieu,baohanh,nguongoc,tinhtrang,sothe,giabancu,tyle_ggia,st_ggia) values (d_id,d_stt,d_mabd,d_handung,d_losx,d_vat,d_soluong,d_dongia,d_sotien,d_giaban,d_giamua,d_sl1,d_sl2,d_tyle,d_cuocvc,d_chaythu,d_namsx,d_tailieu,d_baohanh,d_nguongoc,d_tinhtrang,d_sothe,d_giabancu,d_tyle_ggia,d_st_ggia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapct(d_id numeric,d_stt numeric,d_mabd numeric,d_handung varchar,d_losx varchar,d_vat numeric,d_soluong numeric,d_dongia numeric,d_sotien numeric,d_giaban numeric,d_giamua numeric,d_sl1 numeric,d_sl2 numeric,d_tyle numeric,d_cuocvc numeric,d_chaythu numeric,d_namsx varchar,d_tailieu text,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_sothe varchar,d_giabancu numeric,d_giamuacu numeric,d_tyle_ggia numeric,d_st_ggia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapct set mabd=d_mabd,handung=d_handung,losx=d_losx,vat=d_vat,soluong=d_soluong,dongia=d_dongia,sotien=d_sotien,giaban=d_giaban,giamua=d_giamua,sl1=d_sl1,sl2=d_sl2,tyle=d_tyle,cuocvc=d_cuocvc,chaythu=d_chaythu,namsx=d_namsx,tailieu=d_tailieu,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,sothe=d_sothe,giabancu=d_giabancu,giamuacu=d_giamuacu,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_nhapct(id,stt,mabd,handung,losx,vat,soluong,dongia,sotien,giaban,giamua,sl1,sl2,tyle,cuocvc,chaythu,namsx,tailieu,baohanh,nguongoc,tinhtrang,sothe,giabancu,giamuacu,tyle_ggia,st_ggia) values (d_id,d_stt,d_mabd,d_handung,d_losx,d_vat,d_soluong,d_dongia,d_sotien,d_giaban,d_giamua,d_sl1,d_sl2,d_tyle,d_cuocvc,d_chaythu,d_namsx,d_tailieu,d_baohanh,d_nguongoc,d_tinhtrang,d_sothe,d_giabancu,d_giamuacu,d_tyle_ggia,d_st_ggia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapct(d_id numeric,d_stt numeric,d_mabd numeric,d_handung varchar,d_losx varchar,d_vat numeric,d_soluong numeric,d_dongia numeric,d_sotien numeric,d_giaban numeric,d_giamua numeric,d_sl1 numeric,d_sl2 numeric,d_tyle numeric,d_cuocvc numeric,d_chaythu numeric,d_namsx varchar,d_tailieu text,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_sothe varchar,d_giabancu numeric,d_giamuacu numeric,d_giaban2 numeric,d_tyle2 numeric,d_tyle_ggia numeric,d_st_ggia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapct set mabd=d_mabd,handung=d_handung,losx=d_losx,vat=d_vat,soluong=d_soluong,dongia=d_dongia,sotien=d_sotien,giaban=d_giaban,giamua=d_giamua,sl1=d_sl1,sl2=d_sl2,tyle=d_tyle,cuocvc=d_cuocvc,chaythu=d_chaythu,namsx=d_namsx,tailieu=d_tailieu,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,sothe=d_sothe,giabancu=d_giabancu,giamuacu=d_giamuacu,giaban2=d_giaban2,tyle2=d_tyle2,tyle_ggia=d_tyle_ggia,st_ggia=d_st_ggia where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_nhapct(id,stt,mabd,handung,losx,vat,soluong,dongia,sotien,giaban,giamua,sl1,sl2,tyle,cuocvc,chaythu,namsx,tailieu,baohanh,nguongoc,tinhtrang,sothe,giabancu,giamuacu,giaban2,tyle2,tyle_ggia,st_ggia) values (d_id,d_stt,d_mabd,d_handung,d_losx,d_vat,d_soluong,d_dongia,d_sotien,d_giaban,d_giamua,d_sl1,d_sl2,d_tyle,d_cuocvc,d_chaythu,d_namsx,d_tailieu,d_baohanh,d_nguongoc,d_tinhtrang,d_sothe,d_giabancu,d_giamuacu,d_giaban2,d_tyle2,d_tyle_ggia,d_st_ggia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapct2(d_id numeric,d_stt numeric,d_mabd numeric,d_soluong numeric,d_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapct2 set mabd=d_mabd,soluong=d_soluong,sotien=d_sotien where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_nhapct2(id,stt,mabd,soluong,sotien) values (d_id,d_stt,d_mabd,d_soluong,d_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapbbll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngaysp varchar,d_sohd text,d_ngayhd varchar,d_bbkiem varchar,d_ngaykiem varchar,d_loai varchar,d_nguoigiao text,d_madv numeric,d_makho numeric,d_manguon numeric,d_nhomcc numeric,d_no text,d_co varchar,d_userid numeric,d_lydo numeric,d_chietkhau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapbbll set nhom=d_nhom,sophieu=d_sophieu,ngaysp=to_timestamp(d_ngaysp,'dd/mm/yyyy'),sohd=d_sohd,ngayhd=to_timestamp(d_ngayhd,'dd/mm/yyyy'),bbkiem=d_bbkiem,ngaykiem=null,loai=d_loai,nguoigiao=d_nguoigiao,madv=d_madv,makho=d_makho,manguon=d_manguon,nhomcc=d_nhomcc,no=d_no,co=d_co,userid=d_userid,lydo=d_lydo,chietkhau=d_chietkhau where id=d_id;
    if found=false then
        insert into medibv0514.d_nhapbbll(id,nhom,sophieu,ngaysp,sohd,ngayhd,bbkiem,ngaykiem,loai,nguoigiao,madv,makho,manguon,nhomcc,no,co,userid,lydo,chietkhau) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngaysp,'dd/mm/yyyy'),d_sohd,to_timestamp(d_ngayhd,'dd/mm/yyyy'),d_bbkiem,null,d_loai,d_nguoigiao,d_madv,d_makho,d_manguon,d_nhomcc,d_no,d_co,d_userid,d_lydo,d_chietkhau);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapbbll_kk(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngaysp varchar,d_sohd text,d_ngayhd varchar,d_bbkiem varchar,d_ngaykiem varchar,d_loai varchar,d_nguoigiao text,d_madv numeric,d_makho numeric,d_manguon numeric,d_nhomcc numeric,d_no text,d_co varchar,d_userid numeric,d_lydo numeric,d_chietkhau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapbbll set nhom=d_nhom,sophieu=d_sophieu,ngaysp=to_timestamp(d_ngaysp,'dd/mm/yyyy'),sohd=d_sohd,ngayhd=to_timestamp(d_ngayhd,'dd/mm/yyyy'),bbkiem=d_bbkiem,ngaykiem=to_timestamp(d_ngaykiem,'dd/mm/yyyy'),loai=d_loai,nguoigiao=d_nguoigiao,madv=d_madv,makho=d_makho,manguon=d_manguon,nhomcc=d_nhomcc,no=d_no,co=d_co,userid=d_userid,lydo=d_lydo,chietkhau=d_chietkhau where id=d_id;
    if found=false then
        insert into medibv0514.d_nhapbbll(id,nhom,sophieu,ngaysp,sohd,ngayhd,bbkiem,ngaykiem,loai,nguoigiao,madv,makho,manguon,nhomcc,no,co,userid,lydo,chietkhau) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngaysp,'dd/mm/yyyy'),d_sohd,to_timestamp(d_ngayhd,'dd/mm/yyyy'),d_bbkiem,to_timestamp(d_ngaykiem,'dd/mm/yyyy'),d_loai,d_nguoigiao,d_madv,d_makho,d_manguon,d_nhomcc,d_no,d_co,d_userid,d_lydo,d_chietkhau);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapbbct(d_id numeric,d_stt numeric,d_mabd numeric,d_handung varchar,d_losx varchar,d_vat numeric,d_soluong numeric,d_dongia numeric,d_sotien numeric,d_giaban numeric,d_giamua numeric,d_sl1 numeric,d_sl2 numeric,d_tyle numeric,d_cuocvc numeric,d_chaythu numeric,d_namsx varchar,d_tailieu text,d_baohanh numeric,d_nguongoc numeric,d_tinhtrang numeric,d_sothe varchar,d_giabancu numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapbbct set mabd=d_mabd,handung=d_handung,losx=d_losx,vat=d_vat,soluong=d_soluong,dongia=d_dongia,sotien=d_sotien,giaban=d_giaban,giamua=d_giamua,sl1=d_sl1,sl2=d_sl2,tyle=d_tyle,cuocvc=d_cuocvc,chaythu=d_chaythu,namsx=d_namsx,tailieu=d_tailieu,baohanh=d_baohanh,nguongoc=d_nguongoc,tinhtrang=d_tinhtrang,sothe=d_sothe,giabancu=d_giabancu where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_nhapbbct(id,stt,mabd,handung,losx,vat,soluong,dongia,sotien,giaban,giamua,sl1,sl2,tyle,cuocvc,chaythu,namsx,tailieu,baohanh,nguongoc,tinhtrang,sothe,giabancu) values (d_id,d_stt,d_mabd,d_handung,d_losx,d_vat,d_soluong,d_dongia,d_sotien,d_giaban,d_giamua,d_sl1,d_sl2,d_tyle,d_cuocvc,d_chaythu,d_namsx,d_tailieu,d_baohanh,d_nguongoc,d_tinhtrang,d_sothe,d_giabancu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_theodoigia(d_mabd numeric,d_ngay varchar,d_dongia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_theodoigia set dongia=d_dongia where mabd=d_mabd and to_char(ngay,'dd/mm/yyyy')=d_ngay;
    if found=false then
        insert into medibv0514.d_theodoigia(mabd,ngay,dongia) values (d_mabd,to_timestamp(d_ngay,'dd/mm/yyyy'),d_dongia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thanhtoan(d_id numeric,d_ngay varchar,d_no varchar,d_co varchar,d_datra numeric,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thanhtoan set ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),no=d_no,co=d_co,datra=d_datra,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_thanhtoan(id,ngay,no,co,sotien,datra,userid) values (d_id,to_timestamp(d_ngay,'dd/mm/yyyy'),d_no,d_co,0,d_datra,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapslll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngaysp varchar,d_sohd text,d_ngayhd varchar,d_loai varchar,d_nguoigiao text,d_madv numeric,d_makho numeric,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapslll set nhom=d_nhom,sophieu=d_sophieu,ngaysp=to_timestamp(d_ngaysp,'dd/mm/yyyy'),sohd=d_sohd,ngayhd=to_timestamp(d_ngayhd,'dd/mm/yyyy'),loai=d_loai,madv=d_madv,makho=d_makho,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_nhapslll(id,nhom,sophieu,ngaysp,sohd,ngayhd,loai,nguoigiao,madv,makho,userid) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngaysp,'dd/mm/yyyy'),d_sohd,to_timestamp(d_ngayhd,'dd/mm/yyyy'),d_loai,d_nguoigiao,d_madv,d_makho,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhapslct(d_id numeric,d_stt numeric,d_mabd numeric,d_handung varchar,d_losx varchar,d_soluong numeric,d_sl1 numeric,d_sl2 numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_nhapslct set mabd=d_mabd,handung=d_handung,losx=d_losx,soluong=d_soluong,sl1=d_sl1,sl2=d_sl2 where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_nhapslct(id,stt,mabd,handung,losx,soluong,sl1,sl2) values (d_id,d_stt,d_mabd,d_handung,d_losx,d_soluong,d_sl1,d_sl2);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xuatll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngay varchar,d_loai varchar,d_khox numeric,d_khon numeric,d_lydo text,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xuatll set nhom=d_nhom,sophieu=d_sophieu,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),loai=d_loai,khox=d_khox,khon=d_khon,lydo=d_lydo,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_xuatll(id,nhom,sophieu,ngay,loai,khox,khon,lydo,userid) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngay,'dd/mm/yyyy'),d_loai,d_khox,d_khon,d_lydo,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xuatll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngay varchar,d_loai varchar,d_khox numeric,d_khon numeric,d_lydo text,d_userid numeric,d_idduyet numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xuatll set nhom=d_nhom,sophieu=d_sophieu,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),loai=d_loai,khox=d_khox,khon=d_khon,lydo=d_lydo,userid=d_userid,idduyet=d_idduyet where id=d_id;
    if found=false then
        insert into medibv0514.d_xuatll(id,nhom,sophieu,ngay,loai,khox,khon,lydo,userid,idduyet) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngay,'dd/mm/yyyy'),d_loai,d_khox,d_khon,d_lydo,d_userid,d_idduyet);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xuatct(d_id numeric,d_stt numeric,d_sttt numeric,d_mabd numeric,d_soluong numeric,d_mabs varchar,d_hotenbn text,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xuatct set sttt=d_sttt,mabd=d_mabd,soluong=d_soluong,mabs=d_mabs,hotenbn=d_hotenbn,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_xuatct(id,stt,sttt,mabd,soluong,mabs,hotenbn,giaban) values (d_id,d_stt,d_sttt,d_mabd,d_soluong,d_mabs,d_hotenbn,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_dutrucapll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngay varchar,d_loai varchar,d_khox numeric,d_khon numeric,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_dutrucapll set nhom=d_nhom,sophieu=d_sophieu,loai=d_loai,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),khox=d_khox,khon=d_khon,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_dutrucapll(id,nhom,sophieu,ngay,loai,khox,khon,userid) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngay,'dd/mm/yyyy'),d_loai,d_khox,d_khon,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_dutrucapct(d_id numeric,d_manguon numeric,d_mabd numeric,d_slyeucau numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_dutrucapct set slyeucau=d_slyeucau where id=d_id and manguon=d_manguon and mabd=d_mabd;
    if found=false then
        insert into medibv0514.d_dutrucapct(id,manguon,mabd,slyeucau) values (d_id,d_manguon,d_mabd,d_slyeucau);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_chuyenll(d_id numeric,d_nhom numeric,d_sophieu varchar,d_ngay varchar,d_lydo varchar,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_chuyenll set nhom=d_nhom,sophieu=d_sophieu,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),lydo=d_lydo,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_chuyenll(id,nhom,sophieu,ngay,lydo,userid) values (d_id,d_nhom,d_sophieu,to_timestamp(d_ngay,'dd/mm/yyyy'),d_lydo,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;  
CREATE OR REPLACE FUNCTION medibv0514.upd_chuyenct(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_nguonchuyen numeric,d_stttchuyen numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_chuyenct set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,nguonchuyen=d_nguonchuyen,stttchuyen=d_stttchuyen where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_chuyenct(id,stt,sttt,makho,mabd,soluong,nguonchuyen,stttchuyen) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_nguonchuyen,d_stttchuyen);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_ngtrull(d_id numeric,d_nhom numeric,d_mabn varchar,d_hoten text,d_namsinh varchar,d_ngay varchar,d_mabs varchar,d_makp numeric,d_loai numeric,d_userid numeric,d_sotoa numeric,d_maql numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_ngtrull set nhom=d_nhom,mabn=d_mabn,hoten=d_hoten,namsinh=d_namsinh,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabs=d_mabs,makp=d_makp,loai=d_loai,userid=d_userid,sotoa=d_sotoa,maql=d_maql where id=d_id;
    if found=false then
        insert into medibv0514.d_ngtrull(id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,userid,sotoa,maql) values (d_id,d_nhom,d_mabn,d_hoten,d_namsinh,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabs,d_makp,d_loai,d_userid,d_sotoa,d_maql);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_ngtrull(d_id numeric,d_nhom numeric,d_mabn varchar,d_hoten text,d_namsinh varchar,d_ngay varchar,d_mabs varchar,d_makp numeric,d_loai numeric,d_userid numeric,d_sotoa numeric,d_maql numeric,d_diachi text,d_ghichu text)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_ngtrull set nhom=d_nhom,mabn=d_mabn,hoten=d_hoten,namsinh=d_namsinh,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabs=d_mabs,makp=d_makp,loai=d_loai,userid=d_userid,sotoa=d_sotoa,maql=d_maql,diachi=d_diachi,ghichu=d_ghichu where id=d_id;
    if found=false then
        insert into medibv0514.d_ngtrull(id,nhom,mabn,hoten,namsinh,ngay,mabs,makp,loai,userid,sotoa,maql,diachi,ghichu) values (d_id,d_nhom,d_mabn,d_hoten,d_namsinh,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabs,d_makp,d_loai,d_userid,d_sotoa,d_maql,d_diachi,d_ghichu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_ngtruct(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_ngtruct set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_ngtruct(id,stt,sttt,makho,mabd,soluong,giaban) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_ngtruct(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric,d_madoituong numeric(2),d_paid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_ngtruct set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,giaban=d_giaban,madoituong=d_madoituong,paid=d_paid where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_ngtruct(id,stt,sttt,makho,mabd,soluong,giaban,madoituong,paid) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_giaban,d_madoituong,d_paid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_xuatsdll(d_id numeric,d_nhom numeric,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_idkhoa numeric,d_ngay varchar,d_loai numeric,d_phieu numeric,d_makp numeric,d_userid numeric,d_idduyet numeric,d_thuoc numeric,d_makhoa numeric,d_lydo numeric,d_lk numeric,d_ghichu text,d_ngayylenh varchar)
    RETURNS void AS
$BODY$
begin
    update medibv0514.d_xuatsdll set nhom=d_nhom,mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,idkhoa=d_idkhoa,ngayylenh=to_timestamp(d_ngayylenh,'dd/mm/yyyy'),ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),loai=d_loai,phieu=d_phieu,makp=d_makp,userid=d_userid,idduyet=d_idduyet,thuoc=d_thuoc,makhoa=d_makhoa,lydo=d_lydo,lk=d_lk,ghichu=d_ghichu where id=d_id;
    if found=false then
        insert into medibv0514.d_xuatsdll(id,nhom,mabn,mavaovien,maql,idkhoa,ngayylenh,ngay,loai,phieu,makp,userid,idduyet,thuoc,makhoa,lydo,lk,ghichu) values (d_id,d_nhom,d_mabn,d_mavaovien,d_maql,d_idkhoa,to_timestamp(d_ngayylenh,'dd/mm/yyyy'),to_timestamp(d_ngay,'dd/mm/yyyy'),d_loai,d_phieu,d_makp,d_userid,d_idduyet,d_thuoc,d_makhoa,d_lydo,d_lk,d_ghichu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_xuatsdct(d_id numeric,d_stt numeric,d_sttt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_sttduyet numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xuatsdct set sttt=d_sttt,madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,soluong=d_soluong,sttduyet=d_sttduyet,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_xuatsdct(id,stt,sttt,madoituong,makho,mabd,soluong,sttduyet,giaban) values (d_id,d_stt,d_sttt,d_madoituong,d_makho,d_mabd,d_soluong,d_sttduyet,d_giaban);
    end if;	
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_xuatsdct(d_id numeric,d_stt numeric,d_sttt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_sttduyet numeric,d_giaban numeric, d_ngayylenh varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xuatsdct set sttt=d_sttt,madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,soluong=d_soluong,sttduyet=d_sttduyet,giaban=d_giaban, ngayylenh=to_timestamp(d_ngayylenh,'dd/mm/yyyy') where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_xuatsdct(id,stt,sttt,madoituong,makho,mabd,soluong,sttduyet,giaban, ngayylenh) values (d_id,d_stt,d_sttt,d_madoituong,d_makho,d_mabd,d_soluong,d_sttduyet,d_giaban,to_timestamp(d_ngayylenh,'dd/mm/yyyy') );
    end if;	
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bucstt(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_sttduyet numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_bucstt set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,sttduyet=d_sttduyet,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_bucstt(id,stt,sttt,makho,mabd,soluong,sttduyet,giaban) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_sttduyet,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bucstt(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_sttduyet numeric,d_giaban numeric,d_sltreo numeric,d_madoituong numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_bucstt set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,sttduyet=d_sttduyet,giaban=d_giaban,sltreo=d_sltreo,madoituong=d_madoituong where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_bucstt(id,stt,sttt,makho,mabd,soluong,sttduyet,giaban,sltreo,madoituong) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_sttduyet,d_giaban,d_sltreo,d_madoituong);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thucxuat(d_id numeric,d_sttt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thucxuat set mabd=d_mabd,soluong=soluong+d_soluong,giaban=d_giaban where id=d_id and sttt=d_sttt and madoituong=d_madoituong and makho=d_makho;
    if found=false then
        insert into medibv0514.d_thucxuat(id,sttt,madoituong,makho,mabd,soluong,giaban) values (d_id,d_sttt,d_madoituong,d_makho,d_mabd,d_soluong,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thucxuat_stt(d_id numeric,d_sttt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_stt numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
   update medibv0514.d_thucxuat set mabd=d_mabd,soluong=d_soluong,sttt=d_sttt,madoituong=d_madoituong,makho=d_makho,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_thucxuat(id,sttt,madoituong,makho,mabd,soluong,stt,giaban) values (d_id,d_sttt,d_madoituong,d_makho,d_mabd,d_soluong,d_stt,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thucbucstt(d_id numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thucbucstt set mabd=d_mabd,soluong=soluong+d_soluong,giaban=d_giaban where id=d_id and sttt=d_sttt and makho=d_makho;
    if found=false then
        insert into medibv0514.d_thucbucstt(id,sttt,makho,mabd,soluong,giaban) values (d_id,d_sttt,d_makho,d_mabd,d_soluong,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thucbucstt_stt(d_id numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_stt numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thucbucstt set mabd=d_mabd,soluong=d_soluong,sttt=d_sttt,makho=d_makho,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_thucbucstt(id,sttt,makho,mabd,soluong,stt,giaban) values (d_id,d_sttt,d_makho,d_mabd,d_soluong,d_stt,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytkb(d_id numeric,d_nhom numeric,d_quyenso numeric,d_sobienlai numeric,d_ngay varchar,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_makp varchar,d_chandoan text,d_maicd varchar,d_mabs varchar,d_sothe varchar,d_maphu numeric,d_mabv varchar,d_congkham numeric,d_thuoc numeric,d_cls numeric,d_bntra numeric,d_bhyttra numeric,d_userid numeric,d_loaiba numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytkb set nhom=d_nhom,quyenso=d_quyenso,sobienlai=d_sobienlai,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,makp=d_makp,chandoan=d_chandoan,maicd=d_maicd,mabs=d_mabs,sothe=d_sothe,maphu=d_maphu,mabv=d_mabv,congkham=d_congkham,thuoc=d_thuoc,cls=d_cls,bntra=d_bntra,bhyttra=d_bhyttra,userid=d_userid,loaiba=d_loaiba where id=d_id;
    if found=false then
        insert into medibv0514.bhytkb(id,nhom,quyenso,sobienlai,ngay,mabn,mavaovien,maql,makp,chandoan,maicd,mabs,sothe,maphu,mabv,congkham,thuoc,cls,bntra,bhyttra,userid,sotoa,loaiba) values (d_id,d_nhom,d_quyenso,d_sobienlai,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabn,d_mavaovien,d_maql,d_makp,d_chandoan,d_maicd,d_mabs,d_sothe,d_maphu,d_mabv,d_congkham,d_thuoc,d_cls,d_bntra,d_bhyttra,d_userid,0,d_loaiba);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytkb(d_id numeric,d_nhom numeric,d_quyenso numeric,d_sobienlai numeric,d_ngay varchar,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_makp varchar,d_chandoan text,d_maicd varchar,d_mabs varchar,d_sothe varchar,d_maphu numeric,d_mabv varchar,d_congkham numeric,d_thuoc numeric,d_cls numeric,d_bntra numeric,d_bhyttra numeric,d_userid numeric,d_loaiba numeric,d_traituyen numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytkb set nhom=d_nhom,quyenso=d_quyenso,sobienlai=d_sobienlai,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,makp=d_makp,chandoan=d_chandoan,maicd=d_maicd,mabs=d_mabs,sothe=d_sothe,maphu=d_maphu,mabv=d_mabv,congkham=d_congkham,thuoc=d_thuoc,cls=d_cls,bntra=d_bntra,bhyttra=d_bhyttra,userid=d_userid,loaiba=d_loaiba,traituyen=d_traituyen where id=d_id;
    if found=false then
        insert into medibv0514.bhytkb(id,nhom,quyenso,sobienlai,ngay,mabn,mavaovien,maql,makp,chandoan,maicd,mabs,sothe,maphu,mabv,congkham,thuoc,cls,bntra,bhyttra,userid,sotoa,loaiba,traituyen) values (d_id,d_nhom,d_quyenso,d_sobienlai,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabn,d_mavaovien,d_maql,d_makp,d_chandoan,d_maicd,d_mabs,d_sothe,d_maphu,d_mabv,d_congkham,d_thuoc,d_cls,d_bntra,d_bhyttra,d_userid,0,d_loaiba,d_traituyen);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytkb(d_id numeric,d_nhom numeric,d_ngay varchar,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_makp varchar,d_chandoan text,d_maicd varchar,d_mabs varchar,d_sothe varchar,d_maphu numeric,d_mabv varchar,d_userid numeric,d_loaiba numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytkb set nhom=d_nhom,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,makp=d_makp,chandoan=d_chandoan,maicd=d_maicd,mabs=d_mabs,sothe=d_sothe,maphu=d_maphu,mabv=d_mabv,userid=d_userid,loaiba=d_loaiba where id=d_id;
    if found=false then
        insert into medibv0514.bhytkb(id,nhom,quyenso,sobienlai,ngay,mabn,mavaovien,maql,makp,chandoan,maicd,mabs,sothe,maphu,mabv,congkham,thuoc,cls,bntra,bhyttra,userid,sotoa,loaiba) values (d_id,d_nhom,0,0,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabn,d_mavaovien,d_maql,d_makp,d_chandoan,d_maicd,d_mabs,d_sothe,d_maphu,d_mabv,0,0,0,0,0,d_userid,0,d_loaiba);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytkb(d_id numeric,d_nhom numeric,d_ngay varchar,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_makp varchar,d_chandoan text,d_maicd varchar,d_mabs varchar,d_sothe varchar,d_maphu numeric,d_mabv varchar,d_userid numeric,d_loaiba numeric,d_traituyen numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytkb set nhom=d_nhom,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,makp=d_makp,chandoan=d_chandoan,maicd=d_maicd,mabs=d_mabs,sothe=d_sothe,maphu=d_maphu,mabv=d_mabv,userid=d_userid,loaiba=d_loaiba,traituyen=d_traituyen where id=d_id;
    if found=false then
        insert into medibv0514.bhytkb(id,nhom,quyenso,sobienlai,ngay,mabn,mavaovien,maql,makp,chandoan,maicd,mabs,sothe,maphu,mabv,congkham,thuoc,cls,bntra,bhyttra,userid,sotoa,loaiba,traituyen) values (d_id,d_nhom,0,0,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabn,d_mavaovien,d_maql,d_makp,d_chandoan,d_maicd,d_mabs,d_sothe,d_maphu,d_mabv,0,0,0,0,0,d_userid,0,d_loaiba,d_traituyen);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytds(d_mabn varchar,d_hoten text,d_namsinh varchar,d_diachi text)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytds set hoten=d_hoten,namsinh=d_namsinh,diachi=d_diachi where mabn=d_mabn;
    if found=false then
        insert into medibv0514.bhytds(mabn,hoten,namsinh,diachi) values (d_mabn,d_hoten,d_namsinh,d_diachi);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytthuoc(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_cachdung text,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytthuoc set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,cachdung=d_cachdung,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then	
        insert into medibv0514.bhytthuoc(id,stt,sttt,makho,mabd,soluong,cachdung,giaban) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_cachdung,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytthuoc(d_id numeric,d_stt numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_cachdung text,d_giaban numeric,d_gia_bh numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytthuoc set sttt=d_sttt,makho=d_makho,mabd=d_mabd,soluong=d_soluong,cachdung=d_cachdung,giaban=d_giaban,gia_bh=d_gia_bh where id=d_id and stt=d_stt;
    if found=false then	
        insert into medibv0514.bhytthuoc(id,stt,sttt,makho,mabd,soluong,cachdung,giaban,gia_bh) values (d_id,d_stt,d_sttt,d_makho,d_mabd,d_soluong,d_cachdung,d_giaban,d_gia_bh);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_bhytcls(d_id numeric,d_stt numeric,d_mavp numeric,d_soluong numeric,d_dongia numeric,d_idchidinh numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.bhytcls set mavp=d_mavp,soluong=d_soluong,dongia=d_dongia,idchidinh=d_idchidinh where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.bhytcls(id,stt,mavp,soluong,dongia,idchidinh) values (d_id,d_stt,d_mavp,d_soluong,d_dongia,d_idchidinh);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_toathuocll(d_id numeric,d_sophieu numeric,d_mabn varchar,d_maql numeric,d_ngay varchar,d_makp varchar,d_chandoan text,d_maicd varchar,d_mabs varchar,d_ghichu text,d_userid numeric,d_songay numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_toathuocll set sophieu=d_sophieu,mabn=d_mabn,maql=d_maql,ngay=to_timestamp(d_ngay,'dd/mm/yyyy hh24:mi'),makp=d_makp,chandoan=d_chandoan,maicd=d_maicd,mabs=d_mabs,ghichu=d_ghichu,userid=d_userid,songay=d_songay where id=d_id;
    if found=false then
        insert into medibv0514.d_toathuocll(id,sophieu,mabn,maql,ngay,makp,chandoan,maicd,mabs,ghichu,userid,songay) values (d_id,d_sophieu,d_mabn,d_maql,to_timestamp(d_ngay,'dd/mm/yyyy hh24:mi'),d_makp,d_chandoan,d_maicd,d_mabs,d_ghichu,d_userid,d_songay);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_toathuocct(d_id numeric,d_stt numeric,d_mabd numeric,d_soluong numeric,d_cachdung text,d_solan numeric,d_lan numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_toathuocct set mabd=d_mabd,soluong=d_soluong,cachdung=d_cachdung,solan=d_solan,lan=d_lan where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_toathuocct(id,stt,mabd,soluong,cachdung,solan,lan) values (d_id,d_stt,d_mabd,d_soluong,d_cachdung,d_solan,d_lan);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thuocbhytll(d_id numeric,d_nhom numeric,d_ngay varchar,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_userid numeric,d_madoituong numeric,d_ghichu text,d_songay numeric,d_makp varchar,d_mabs varchar,d_chandoan text,d_maicd varchar,d_loaiba numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thuocbhytll set nhom=d_nhom,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,userid=d_userid,madoituong=d_madoituong,ghichu=d_ghichu,songay=d_songay,makp=d_makp,mabs=d_mabs,chandoan=d_chandoan,maicd=d_maicd,loaiba=d_loaiba where id=d_id;
    if found=false then
        insert into medibv0514.d_thuocbhytll(id,nhom,ngay,mabn,mavaovien,maql,userid,madoituong,ghichu,songay,makp,mabs,chandoan,maicd,loaiba) values (d_id,d_nhom,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabn,d_mavaovien,d_maql,d_userid,d_madoituong,d_ghichu,d_songay,d_makp,d_mabs,d_chandoan,d_maicd,d_loaiba);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thuocbhytct(d_id numeric,d_stt numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_cachdung text,d_manguon numeric,d_solan numeric,d_lan numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thuocbhytct set makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,cachdung=d_cachdung,manguon=d_manguon,solan=d_solan,lan=d_lan where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_thuocbhytct(id,stt,makho,mabd,slyeucau,slthuc,cachdung,manguon,solan,lan) values (d_id,d_stt,d_makho,d_mabd,d_slyeucau,0,d_cachdung,d_manguon,d_solan,d_lan);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_thuocbhytct(d_id numeric,d_stt numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_cachdung text,d_manguon numeric,d_solan numeric,d_lan numeric,d_madoituong numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thuocbhytct set makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,cachdung=d_cachdung,manguon=d_manguon,solan=d_solan,lan=d_lan,madoituong=d_madoituong where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_thuocbhytct(id,stt,makho,mabd,slyeucau,slthuc,cachdung,manguon,solan,lan,madoituong) values (d_id,d_stt,d_makho,d_mabd,d_slyeucau,0,d_cachdung,d_manguon,d_solan,d_lan,d_madoituong);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_benhanpk(m_mabn varchar,m_mavaovien numeric,m_maql numeric,m_makp varchar,m_ngay varchar,m_dentu numeric,m_nhantu numeric,m_madoituong numeric,m_chandoan text,m_maicd varchar,m_ttlucrv numeric,m_mabs varchar,m_sovaovien varchar,m_bienchung numeric,m_taibien numeric,m_giaiphau numeric,m_mangtr numeric,m_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.benhanpk set mabn=m_mabn,mavaovien=m_mavaovien,makp=m_makp,ngay=to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),dentu=m_dentu,nhantu=m_nhantu,madoituong=m_madoituong,chandoan=m_chandoan,maicd=m_maicd,ttlucrv=m_ttlucrv,mabs=m_mabs,sovaovien=m_sovaovien,bienchung=m_bienchung,taibien=m_taibien,giaiphau=m_giaiphau,mangtr=m_mangtr,userid=m_userid where maql=m_maql;
    if found=false then
        insert into medibv0514.benhanpk(mabn,mavaovien,maql,makp,ngay,dentu,nhantu,madoituong,chandoan,maicd,ttlucrv,mabs,sovaovien,bienchung,taibien,giaiphau,mangtr,userid) values (m_mabn,m_mavaovien,m_maql,m_makp,to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),m_dentu,m_nhantu,m_madoituong,m_chandoan,m_maicd,m_ttlucrv,m_mabs,m_sovaovien,m_bienchung,m_taibien,m_giaiphau,m_mangtr,m_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xutrikbct(m_maql numeric,m_xutri text,m_makp varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.xutrikbct set xutri=m_xutri,makp=m_makp where maql=m_maql;
    if found=false then
        insert into medibv0514.xutrikbct(maql,xutri,makp) values (m_maql,m_xutri,m_makp);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_vpkhoa(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_ngay varchar,v_makp varchar,v_madoituong numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_vattu numeric,v_userid numeric,v_buoi numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_vpkhoa set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),makp=v_makp,madoituong=v_madoituong,mavp=v_mavp,soluong=v_soluong,dongia=v_dongia,vattu=v_vattu,userid=v_userid,buoi=v_buoi where id=v_id;
    if found=false then
        insert into medibv0514.v_vpkhoa(id,mabn,mavaovien,maql,idkhoa,ngay,makp,madoituong,mavp,soluong,dongia,vattu,done,userid,buoi) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_makp,v_madoituong,v_mavp,v_soluong,v_dongia,v_vattu,0,v_userid,v_buoi);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tienthuoc(d_id numeric,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_idkhoa numeric,d_ngay varchar,d_makp numeric,d_madoituong numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric,d_giamua numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_tienthuoc set giaban=d_giaban,soluong=soluong+d_soluong where mabn=d_mabn and mavaovien=d_mavaovien and maql=d_maql and idkhoa=d_idkhoa and to_char(ngay,'dd/mm/yyyy')=d_ngay and makp=d_makp and mabd=d_mabd and giamua=d_giamua and madoituong=d_madoituong and done=0 and id=d_id;
    if found=false then
        insert into medibv0514.d_tienthuoc(id,mabn,mavaovien,maql,idkhoa,ngay,makp,madoituong,mabd,soluong,giaban,done,giamua) values (d_id,d_mabn,d_mavaovien,d_maql,d_idkhoa,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_madoituong,d_mabd,d_soluong,d_giaban,0,d_giamua);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tienthuoc(d_id numeric,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_idkhoa numeric,d_ngay varchar,d_makp numeric,d_madoituong numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric,d_giamua numeric,d_gianovat numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_tienthuoc set giaban=d_giaban,gianovat=d_gianovat,soluong=soluong+d_soluong where mabn=d_mabn and mavaovien=d_mavaovien and maql=d_maql and idkhoa=d_idkhoa and to_char(ngay,'dd/mm/yyyy')=d_ngay and makp=d_makp and mabd=d_mabd and giamua=d_giamua and madoituong=d_madoituong and done=0 and id=d_id;
    if found=false then
        insert into medibv0514.d_tienthuoc(id,mabn,mavaovien,maql,idkhoa,ngay,makp,madoituong,mabd,soluong,giaban,done,giamua,gianovat) values (d_id,d_mabn,d_mavaovien,d_maql,d_idkhoa,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_madoituong,d_mabd,d_soluong,d_giaban,0,d_giamua,d_gianovat);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_dutrull(d_id numeric,d_idduyet numeric,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_idkhoa numeric,d_ngayvv varchar,d_songay numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_dutrull set idduyet=d_idduyet,mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,idkhoa=d_idkhoa,ngayvv=to_timestamp(d_ngayvv,'dd/mm/yyyy hh24:mi'),songay=d_songay where id=d_id;
    if found=false then
        insert into medibv0514.d_dutrull(id,idduyet,mabn,mavaovien,maql,idkhoa,ngayvv,songay) values (d_id,d_idduyet,d_mabn,d_mavaovien,d_maql,d_idkhoa,to_timestamp(d_ngayvv,'dd/mm/yyyy hh24:mi'),d_songay);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_duyet(d_id numeric,d_nhom numeric,d_ngay varchar,d_loai numeric,d_phieu numeric,d_makp numeric,d_done numeric,d_userid numeric,d_makhoa numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_duyet set nhom=d_nhom,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),loai=d_loai,phieu=d_phieu,makp=d_makp,userid=d_userid,makhoa=d_makhoa where id=d_id;
    if found=false then
        insert into medibv0514.d_duyet(id,nhom,ngay,loai,phieu,makp,done,userid,makhoa) values (d_id,d_nhom,to_timestamp(d_ngay,'dd/mm/yyyy'),d_loai,d_phieu,d_makp,d_done,d_userid,d_makhoa);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_dausinhton(d_id numeric,d_idkhoa numeric,d_iddutru numeric,d_ngay varchar,d_mabs varchar,d_manv varchar,d_mach numeric,d_nhietdo numeric,d_huyetap varchar,d_nhiptho numeric,d_cannang numeric,d_phong varchar,d_giuong varchar,d_ghichu text)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_dausinhton set idkhoa=d_idkhoa,iddutru=d_iddutru,ngay=to_timestamp(d_ngay,'dd/mm/yyyy hh24:mi'),mabs=d_mabs,manv=d_manv,mach=d_mach,nhietdo=d_nhietdo,huyetap=d_huyetap,nhiptho=d_nhiptho,cannang=d_cannang,phong=d_phong,giuong=d_giuong,ghichu=d_ghichu where id=d_id;
    if found=false then
        insert into medibv0514.d_dausinhton(id,idkhoa,iddutru,ngay,mabs,manv,mach,nhietdo,huyetap,nhiptho,cannang,phong,giuong,ghichu) values (d_id,d_idkhoa,d_iddutru,to_timestamp(d_ngay,'dd/mm/yyyy hh24:mi'),d_mabs,d_manv,d_mach,d_nhietdo,d_huyetap,d_nhiptho,d_cannang,d_phong,d_giuong,d_ghichu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_dutruct(d_id numeric,d_stt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_cachdung text,d_manguon numeric,d_tutruc numeric,d_solan numeric,d_lan numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_dutruct set madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,cachdung=d_cachdung,manguon=d_manguon,tutruc=d_tutruc,solan=d_solan,lan=d_lan where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_dutruct(id,stt,madoituong,makho,mabd,slyeucau,slthuc,cachdung,manguon,tutruc,solan,lan) values (d_id,d_stt,d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_cachdung,d_manguon,d_tutruc,d_solan,d_lan);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_dutruct(d_id numeric,d_stt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_cachdung text,d_manguon numeric,d_tutruc numeric,d_solan numeric,d_lan numeric,d_choduyet numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_dutruct set madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,cachdung=d_cachdung,manguon=d_manguon,tutruc=d_tutruc,solan=d_solan,lan=d_lan,choduyet=d_choduyet where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_dutruct(id,stt,madoituong,makho,mabd,slyeucau,slthuc,cachdung,manguon,tutruc,solan,lan,choduyet) values (d_id,d_stt,d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_cachdung,d_manguon,d_tutruc,d_solan,d_lan,d_choduyet);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_hoantrall(d_id numeric,d_idduyet numeric,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_idkhoa numeric,d_ngayvv varchar,d_lydo numeric,d_thuoc numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_hoantrall set idduyet=d_idduyet,mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,idkhoa=d_idkhoa,ngayvv=to_timestamp(d_ngayvv,'dd/mm/yyyy hh24:mi'),lydo=d_lydo,thuoc=d_thuoc where id=d_id;
    if found=false then
        insert into medibv0514.d_hoantrall(id,idduyet,mabn,mavaovien,maql,idkhoa,ngayvv,lydo,thuoc) values (d_id,d_idduyet,d_mabn,d_mavaovien,d_maql,d_idkhoa,to_timestamp(d_ngayvv,'dd/mm/yyyy hh24:mi'),d_lydo,d_thuoc);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_hoantract(d_id numeric,d_stt numeric,d_ngay varchar,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_manguon numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_hoantract set ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,manguon=d_manguon where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_hoantract(id,stt,ngay,madoituong,makho,mabd,slyeucau,slthuc,manguon) values (d_id,d_stt,to_timestamp(d_ngay,'dd/mm/yyyy'),d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_manguon);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_hoantract(d_id numeric,d_stt numeric,d_ngay varchar,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_manguon numeric,d_sttt numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_hoantract set ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,manguon=d_manguon,sttt=d_sttt where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_hoantract(id,stt,ngay,madoituong,makho,mabd,slyeucau,slthuc,manguon,sttt) values (d_id,d_stt,to_timestamp(d_ngay,'dd/mm/yyyy'),d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_manguon,d_sttt);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_haophill(d_id numeric,d_idduyet numeric,d_sophieu varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_haophill set idduyet=d_idduyet,sophieu=d_sophieu where id=d_id;
    if found=false then
        insert into medibv0514.d_haophill(id,idduyet,sophieu) values (d_id,d_idduyet,d_sophieu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_haophict(d_id numeric,d_stt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_manguon numeric,d_tutruc numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_haophict set madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,manguon=d_manguon,tutruc=d_tutruc where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_haophict(id,stt,madoituong,makho,mabd,slyeucau,slthuc,manguon,tutruc) values (d_id,d_stt,d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_manguon,d_tutruc);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xtutrucll(d_id numeric,d_idduyet numeric,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_idkhoa numeric,d_ngayvv varchar,d_songay numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xtutrucll set idduyet=d_idduyet,mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,idkhoa=d_idkhoa,ngayvv=to_timestamp(d_ngayvv,'dd/mm/yyyy hh24:mi'),songay=d_songay where id=d_id;
    if found=false then
        insert into medibv0514.d_xtutrucll(id,idduyet,mabn,mavaovien,maql,idkhoa,ngayvv,songay) values (d_id,d_idduyet,d_mabn,d_mavaovien,d_maql,d_idkhoa,to_timestamp(d_ngayvv,'dd/mm/yyyy hh24:mi'),d_songay);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xtutrucct(d_id numeric,d_stt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_cachdung text,d_manguon numeric,d_idvpkhoa numeric,d_solan numeric,d_lan numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xtutrucct set madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,cachdung=d_cachdung,manguon=d_manguon,idvpkhoa=d_idvpkhoa,solan=d_solan,lan=d_lan where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_xtutrucct(id,stt,madoituong,makho,mabd,slyeucau,slthuc,cachdung,manguon,idvpkhoa,solan,lan) values (d_id,d_stt,d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_cachdung,d_manguon,d_idvpkhoa,d_solan,d_lan);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_xtutrucct_cdha(d_id numeric,d_stt numeric,d_madoituong numeric,d_makho numeric,d_mabd numeric,d_slyeucau numeric,d_slthuc numeric,d_cachdung text,d_manguon numeric,d_idvpkhoa numeric,d_solan numeric,d_lan numeric,d_hu numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_xtutrucct set madoituong=d_madoituong,makho=d_makho,mabd=d_mabd,slyeucau=d_slyeucau,cachdung=d_cachdung,manguon=d_manguon,idvpkhoa=d_idvpkhoa,solan=d_solan,lan=d_lan,hu=d_hu where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_xtutrucct(id,stt,madoituong,makho,mabd,slyeucau,slthuc,cachdung,manguon,idvpkhoa,solan,lan,hu) values (d_id,d_stt,d_madoituong,d_makho,d_mabd,d_slyeucau,d_slthuc,d_cachdung,d_manguon,d_idvpkhoa,d_solan,d_lan,d_hu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ngayduyet(d_nhom numeric,d_loai numeric,d_phieu numeric,d_makp numeric,d_ngay varchar,d_idduyet numeric,d_makho text,d_sttduyet text)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_ngayduyet set idduyet=d_idduyet,sttduyet=d_sttduyet where nhom=d_nhom and loai=d_loai and phieu=d_phieu and makp=d_makp and to_char(ngay,'dd/mm/yyyy')=d_ngay and idduyet=d_idduyet and makho=d_makho;
    if found=false then
        insert into medibv0514.d_ngayduyet(nhom,loai,phieu,makp,ngay,idduyet,makho,sttduyet) values (d_nhom,d_loai,d_phieu,d_makp,to_timestamp(d_ngay,'dd/mm/yyyy'),d_idduyet,d_makho,d_sttduyet);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_phieuxuat(d_id numeric,d_soct varchar,d_ngay varchar,d_makp numeric,d_nhom numeric,d_loai varchar,d_phieu varchar,d_kho varchar,d_sotien numeric,d_no varchar,d_co varchar,d_diengiai text,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_phieuxuat set soct=d_soct,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),makp=d_makp,nhom=d_nhom,loai=d_loai,phieu=d_phieu,kho=d_kho,sotien=d_sotien,no=d_no,co=d_co,diengiai=d_diengiai,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_phieuxuat(id,soct,ngay,makp,nhom,loai,phieu,kho,sotien,no,co,diengiai,userid) values (d_id,d_soct,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_nhom,d_loai,d_phieu,d_kho,d_sotien,d_no,d_co,d_diengiai,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_phieuxuat(d_id numeric,d_ngay varchar,d_makp numeric,d_nhom numeric,d_loai varchar,d_phieu varchar,d_kho varchar,d_sotien numeric,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_phieuxuat set ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),makp=d_makp,nhom=d_nhom,loai=d_loai,phieu=d_phieu,kho=d_kho,sotien=d_sotien,userid=d_userid where id=d_id;
    if found=false then
        insert into medibv0514.d_phieuxuat(id,soct,ngay,makp,nhom,loai,phieu,kho,sotien,no,co,diengiai,userid) values (d_id,'',to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_nhom,d_loai,d_phieu,d_kho,d_sotien,'','','',d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;	
CREATE OR REPLACE FUNCTION medibv0514.upd_thucbucstt(d_id numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thucbucstt set mabd=d_mabd,soluong=soluong+d_soluong,giaban=d_giaban where id=d_id and sttt=d_sttt and makho=d_makho;
    if found=false then
        insert into medibv0514.d_thucbucstt(id,sttt,makho,mabd,soluong,giaban) values (d_id,d_sttt,d_makho,d_mabd,d_soluong,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;	
CREATE OR REPLACE FUNCTION medibv0514.upd_thucbucstt_stt(d_id numeric,d_sttt numeric,d_makho numeric,d_mabd numeric,d_soluong numeric,d_stt numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_thucbucstt set mabd=d_mabd,soluong=d_soluong,sttt=d_sttt,makho=d_makho,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_thucbucstt(id,sttt,makho,mabd,soluong,stt,giaban) values (d_id,d_sttt,d_makho,d_mabd,d_soluong,d_stt,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;	
CREATE OR REPLACE FUNCTION  medibv0514.upd_tienthuoc(d_mabn varchar, d_maql numeric)
 RETURNS void AS
$BODY$
DECLARE
    t_id numeric;t_mabn varchar;t_mavaovien numeric;t_maql numeric;t_idkhoa numeric;t_ngay varchar;t_makp numeric;t_madoituong numeric;t_mabd numeric;t_soluong numeric;t_giaban numeric;t_giamua numeric;t_gianovat numeric;t_done numeric;t_idttrv numeric;t_datra numeric;t_traituyen numeric;
    tienthuocs cursor (p_mabn varchar,p_maql numeric) is select id,mabn,maql, idkhoa, to_char(ngay,'dd/mm/yyyy') as ngay, makp, madoituong, mabd, giamua, done,idttrv,datra,gianovat from medibv0514.d_tienthuoc where  mabn=p_mabn and maql=p_maql and done=1;
    thuocsd cursor  (p_mabn varchar, p_maql numeric) is select a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngayylenh,'dd/mm/yyyy') as ngay, a.makhoa as makp,b.madoituong, b.mabd, case when a.loai=3 then -1*b.soluong else b.soluong end as soluong,t.giaban,t.giamua,t.gianovat, a.traituyen from medibv0514.d_xuatsdll a, medibv0514.d_xuatsdct b,medibv0514.d_theodoi t where a.id=b.id and b.sttt=t.id and a.mabn=p_mabn and a.maql=p_maql;
begin
    open tienthuocs(d_mabn,d_maql);
    open thuocsd(d_mabn,d_maql);
    delete from medibv0514.d_tienthuoc where mabn=d_mabn and maql=d_maql and done=0;
    loop
        fetch thuocsd into t_id,t_mabn,t_mavaovien,t_maql,t_idkhoa,t_ngay,t_makp,t_madoituong,t_mabd,t_soluong,t_giaban,t_giamua,t_gianovat,t_traituyen;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tienthuoc set soluong=soluong+t_soluong,giaban=t_giaban,traituyen=t_traituyen where mabn=t_mabn and maql=t_maql and makp=t_makp and idkhoa=t_idkhoa and mabd=t_mabd and to_char(ngay,'dd/mm/yyyy')=t_ngay and madoituong=t_madoituong and giamua=t_giamua and done=0 and id=t_id;
        if found=false then
            insert into medibv0514.d_tienthuoc (id,mabn,mavaovien,maql,makp,idkhoa,ngay, madoituong,mabd,soluong,giaban,done,giamua,gianovat,traituyen)	values (t_id,t_mabn,t_mavaovien,t_maql, t_makp,t_idkhoa,to_timestamp(t_ngay,'dd/mm/yyyy'), t_madoituong, t_mabd, t_soluong,t_giaban,0,t_giamua,t_gianovat,t_traituyen);
        end if;
    end loop;
    close thuocsd;
    loop
        fetch tienthuocs into t_id,t_mabn,t_maql,t_idkhoa,t_ngay,t_makp,t_madoituong,t_mabd,t_giamua,t_done,t_idttrv,t_datra,t_gianovat;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tienthuoc set done=t_done,idttrv=t_idttrv,datra=t_datra where id=t_id and mabn=t_mabn and maql=t_maql and idkhoa=t_idkhoa and to_char(ngay,'dd/mm/yyyy')=t_ngay and makp=t_makp and madoituong=t_madoituong and mabd=t_mabd and giamua=t_giamua and done=0;
    end loop;
    close tienthuocs;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;	
CREATE OR REPLACE FUNCTION  medibv0514.upd_tienthuoc1(d_mabn varchar, d_maql numeric)
 RETURNS void AS
$BODY$
DECLARE
    t_id numeric;t_mabn varchar;t_mavaovien numeric;t_maql numeric;t_idkhoa numeric;t_ngay varchar;t_makp numeric;t_madoituong numeric;t_mabd numeric;t_soluong numeric;t_giaban numeric;t_giamua numeric;t_gianovat numeric;t_gia_bh numeric;t_done numeric;t_idttrv numeric;t_datra numeric;t_traituyen numeric;
    tienthuocs cursor (p_mabn varchar,p_maql numeric) is select id,mabn,maql, idkhoa, to_char(ngay,'dd/mm/yyyy') as ngay, makp, madoituong, mabd, giamua, done,idttrv,datra,gianovat,gia_bh from medibv0514.d_tienthuoc where  mabn=p_mabn and maql=p_maql and done=1;
    thuocsd cursor  (p_mabn varchar, p_maql numeric) is select a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(b.ngayylenh,'dd/mm/yyyy') as ngay, a.makhoa as makp,b.madoituong, b.mabd, case when a.loai=3 then -1*b.soluong else b.soluong end as soluong,t.giaban,t.giamua,t.gianovat, a.traituyen,b.gia_bh from medibv0514.d_xuatsdll a, medibv0514.d_xuatsdct b,medibv0514.d_theodoi t where a.id=b.id and b.sttt=t.id and a.mabn=p_mabn and a.maql=p_maql;
begin
    open tienthuocs(d_mabn,d_maql);
    open thuocsd(d_mabn,d_maql);
    delete from medibv0514.d_tienthuoc where mabn=d_mabn and maql=d_maql and done=0;
    loop
        fetch thuocsd into t_id,t_mabn,t_mavaovien,t_maql,t_idkhoa,t_ngay,t_makp,t_madoituong,t_mabd,t_soluong,t_giaban,t_giamua,t_gianovat,t_traituyen,t_gia_bh;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tienthuoc set soluong=soluong+t_soluong,giaban=t_giaban,traituyen=t_traituyen,gia_bh=t_gia_bh where mabn=t_mabn and maql=t_maql and makp=t_makp and idkhoa=t_idkhoa and mabd=t_mabd and to_char(ngay,'dd/mm/yyyy')=t_ngay and madoituong=t_madoituong and giamua=t_giamua and done=0 and id=t_id;
        if found=false then
            insert into medibv0514.d_tienthuoc (id,mabn,mavaovien,maql,makp,idkhoa,ngay, madoituong,mabd,soluong,giaban,done,giamua,gianovat,traituyen,gia_bh)	values (t_id,t_mabn,t_mavaovien,t_maql, t_makp,t_idkhoa,to_timestamp(t_ngay,'dd/mm/yyyy'), t_madoituong, t_mabd, t_soluong,t_giaban,0,t_giamua,t_gianovat,t_traituyen,t_gia_bh);
        end if;
    end loop;
    close thuocsd;
    loop
        fetch tienthuocs into t_id,t_mabn,t_maql,t_idkhoa,t_ngay,t_makp,t_madoituong,t_mabd,t_giamua,t_done,t_idttrv,t_datra,t_gianovat,t_gia_bh;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tienthuoc set done=t_done,idttrv=t_idttrv,datra=t_datra,gia_bh=t_gia_bh where id=t_id and mabn=t_mabn and maql=t_maql and idkhoa=t_idkhoa and to_char(ngay,'dd/mm/yyyy')=t_ngay and makp=t_makp and madoituong=t_madoituong and mabd=t_mabd and giamua=t_giamua and done=0;
    end loop;
    close tienthuocs;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;	
CREATE OR REPLACE FUNCTION  medibv0514.upd_tienthuoc_ktcao(d_mabn varchar, d_maql numeric)
 RETURNS void AS
$BODY$
DECLARE
    t_id numeric;t_mabn varchar;t_mavaovien numeric;t_maql numeric;t_idkhoa numeric;t_ngay varchar;t_makp numeric;t_madoituong numeric;t_mabd numeric;t_soluong numeric;t_giaban numeric;t_giamua numeric;t_gianovat numeric;t_gia_bh numeric;t_done numeric;t_idttrv numeric;t_datra numeric;t_traituyen numeric;t_id_ktcao numeric;
    tienthuocs cursor (p_mabn varchar,p_maql numeric) is select id,mabn,maql, idkhoa, to_char(ngay,'dd/mm/yyyy') as ngay, makp, madoituong, mabd, giamua, done,idttrv,datra,gianovat,gia_bh,id_ktcao from medibv0514.d_tienthuoc where  mabn=p_mabn and maql=p_maql and done=1;
    thuocsd cursor  (p_mabn varchar, p_maql numeric) is select a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(b.ngayylenh,'dd/mm/yyyy') as ngay, a.makhoa as makp,b.madoituong, b.mabd, case when a.loai=3 then -1*b.soluong else b.soluong end as soluong,t.giaban,t.giamua,t.gianovat, a.traituyen,b.gia_bh,b.id_ktcao from medibv0514.d_xuatsdll a, medibv0514.d_xuatsdct b,medibv0514.d_theodoi t where a.id=b.id and b.sttt=t.id and a.mabn=p_mabn and a.maql=p_maql;
begin
    open tienthuocs(d_mabn,d_maql);
    open thuocsd(d_mabn,d_maql);
    delete from medibv0514.d_tienthuoc where mabn=d_mabn and maql=d_maql and done=0;
    loop
        fetch thuocsd into t_id,t_mabn,t_mavaovien,t_maql,t_idkhoa,t_ngay,t_makp,t_madoituong,t_mabd,t_soluong,t_giaban,t_giamua,t_gianovat,t_traituyen,t_gia_bh,t_id_ktcao;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tienthuoc set soluong=soluong+t_soluong,giaban=t_giaban,traituyen=t_traituyen,gia_bh=t_gia_bh where mabn=t_mabn and maql=t_maql and makp=t_makp and idkhoa=t_idkhoa and mabd=t_mabd and to_char(ngay,'dd/mm/yyyy')=t_ngay and madoituong=t_madoituong and giamua=t_giamua and done=0 and id=t_id and id_ktcao=t_id_ktcao;
        if found=false then
            insert into medibv0514.d_tienthuoc (id,mabn,mavaovien,maql,makp,idkhoa,ngay, madoituong,mabd,soluong,giaban,done,giamua,gianovat,traituyen,gia_bh,id_ktcao)	values (t_id,t_mabn,t_mavaovien,t_maql, t_makp,t_idkhoa,to_timestamp(t_ngay,'dd/mm/yyyy'), t_madoituong, t_mabd, t_soluong,t_giaban,0,t_giamua,t_gianovat,t_traituyen,t_gia_bh,t_id_ktcao);
        end if;
    end loop;
    close thuocsd;
    loop
        fetch tienthuocs into t_id,t_mabn,t_maql,t_idkhoa,t_ngay,t_makp,t_madoituong,t_mabd,t_giamua,t_done,t_idttrv,t_datra,t_gianovat,t_gia_bh,t_id_ktcao;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tienthuoc set done=t_done,idttrv=t_idttrv,datra=t_datra,gia_bh=t_gia_bh where id=t_id and mabn=t_mabn and maql=t_maql and idkhoa=t_idkhoa and to_char(ngay,'dd/mm/yyyy')=t_ngay and makp=t_makp and madoituong=t_madoituong and mabd=t_mabd and giamua=t_giamua and done=0 and id_ktcao=t_id_ktcao;
    end loop;
    close tienthuocs;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;	
CREATE OR REPLACE FUNCTION medibv0514.upd_tontutruc(d_nhom numeric,d_makp numeric)
 RETURNS void AS
$BODY$
DECLARE
 d_makho numeric;d_mabd numeric;d_tondau numeric;d_slnhap numeric;d_slxuat numeric;d_manguon numeric;
 cur_tutruc cursor (p_nhom numeric,p_makp numeric) is select a.makho,a.mabd,sum(a.tondau) as tondau,sum(a.slnhap) as slnhap,sum(a.slxuat) as slxuat,t.manguon from medibv0514.d_tutrucct a,medibv0514.d_theodoi t where a.stt=t.id and a.makp=p_makp and a.makho in (select id from medibv.d_dmkho where nhom=p_nhom) group by a.makho,a.mabd,t.manguon;
begin
    update medibv0514.d_tutructh set tondau=0,slnhap=0,slxuat=0 where makp=d_makp and makho in (select id from medibv.d_dmkho where nhom=d_nhom);
    open cur_tutruc(d_nhom,d_makp);
    loop
        fetch cur_tutruc into d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon;
        if found=false then
            exit;
        end if;
        update medibv0514.d_tutructh set tondau=tondau+d_tondau,slnhap=slnhap+d_slnhap,slxuat=slxuat+d_slxuat where makp=d_makp and makho=d_makho and mabd=d_mabd and manguon=d_manguon;
        if found=false then
            insert into medibv0514.d_tutructh(makp,makho,mabd,tondau,slnhap,slxuat,manguon) values (d_makp,d_makho,d_mabd,d_tondau,d_slnhap,d_slxuat,d_manguon);
        end if;
    end loop;
    close cur_tutruc;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_slnhap(d_nhom numeric)
 RETURNS void AS
$BODY$
DECLARE
    d_id numeric;d_makho numeric;d_stt numeric;d_sttn numeric;d_mabd numeric;d_soluong numeric;
    cur_ll cursor (p_nhom numeric) is select id,makho from medibv0514.d_nhapll where nhom=p_nhom;
    cur_ct cursor (p_id numeric) is select stt,mabd,soluong from medibv0514.d_nhapct where id=p_id;
begin
    update medibv0514.d_tonkhoct set slnhap=0 where idn<>0 and makho in (select id from medibv.d_dmkho where nhom=d_nhom);
    open cur_ll(d_nhom);
    loop
        fetch cur_ll into d_id,d_makho;
        if found=false then
            exit;
        end if;
        open cur_ct(d_id);
        loop
            fetch cur_ct into d_sttn,d_mabd,d_soluong;
            if found=false then
                exit;
            end if;
            update medibv0514.d_tonkhoct set slnhap=slnhap+d_soluong,mabd=d_mabd where idn=d_id and sttn=d_sttn and makho=d_makho;
            if found=false then
                update medibv.d_capid set id=id+1 where ma=9;
                select id into d_stt from medibv.d_capid where ma=9;
                insert into medibv0514.d_tonkhoct(makho,stt,idn,sttn,mabd,tondau,slnhap,slxuat) values (d_makho,d_stt,d_id,d_sttn,d_mabd,0,d_soluong,0);
            end if;	
        end loop;
        close cur_ct;
    end loop;
    close cur_ll;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_benhancc(m_mabn varchar,m_mavaovien numeric,m_maql numeric,m_makp varchar,m_ngay varchar,m_dentu numeric,m_nhantu numeric,m_madoituong numeric,m_chandoan text,m_maicd varchar,m_sovaovien varchar,m_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.benhancc set mabn=m_mabn,mavaovien=m_mavaovien,makp=m_makp,ngay=to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),dentu=m_dentu,nhantu=m_nhantu,madoituong=m_madoituong,chandoan=m_chandoan,maicd=m_maicd,sovaovien=m_sovaovien,userid=m_userid where maql=m_maql;
    if found=false then
        insert into medibv0514.benhancc(mabn,mavaovien,maql,makp,ngay,dentu,nhantu,madoituong,chandoan,maicd,sovaovien,userid) values (m_mabn,m_mavaovien,m_maql,m_makp,to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),m_dentu,m_nhantu,m_madoituong,m_chandoan,m_maicd,m_sovaovien,m_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_benhancc(m_mabn varchar,m_mavaovien numeric,m_maql numeric,m_makp varchar,m_ngay varchar,m_dentu numeric,m_nhantu numeric,m_madoituong numeric,m_mabsnb varchar,m_chandoan text,m_maicd varchar,m_sovaovien varchar,m_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.benhancc set mabn=m_mabn,mavaovien=m_mavaovien,makp=m_makp,ngay=to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),dentu=m_dentu,nhantu=m_nhantu,madoituong=m_madoituong,mabsnb=m_mabsnb,chandoan=m_chandoan,maicd=m_maicd,sovaovien=m_sovaovien,userid=m_userid where maql=m_maql;
    if found=false then
        insert into medibv0514.benhancc(mabn,mavaovien,maql,makp,ngay,dentu,nhantu,madoituong,mabsnb,chandoan,maicd,sovaovien,userid) values (m_mabn,m_mavaovien,m_maql,m_makp,to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),m_dentu,m_nhantu,m_madoituong,m_mabsnb,m_chandoan,m_maicd,m_sovaovien,m_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_benhancc(m_maql numeric,m_ngayrv varchar,m_ketqua numeric,m_ttlucrv numeric,m_chandoanrv text,m_maicdrv varchar,m_mabs varchar,m_bienchung numeric,m_taibien numeric,m_giaiphau numeric,m_soluutru varchar,m_giuong varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.benhancc set ngayrv=to_timestamp(m_ngayrv,'dd/mm/yyyy hh24:mi'),ketqua=m_ketqua,ttlucrv=m_ttlucrv,chandoanrv=m_chandoanrv,maicdrv=m_maicdrv,mabs=m_mabs,bienchung=m_bienchung,taibien=m_taibien,giaiphau=m_giaiphau,soluutru=m_soluutru,giuong=m_giuong where maql=m_maql;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_huybienlai(v_id numeric,v_tables varchar,v_loai numeric,v_mabn varchar,v_hoten text,v_makp varchar,v_ngay varchar,v_quyenso numeric,v_sobienlai numeric,v_lydo text,v_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_huybienlai set loai=v_loai,mabn=v_mabn,hoten=v_hoten,makp=v_makp,ngay=to_timestamp(v_ngay,'dd/mm/yyyy'),quyenso=v_quyenso,sobienlai=v_sobienlai,lydo=v_lydo,userid=v_userid where id=v_id and tables=v_tables;
    if found=false then
        insert into medibv0514.v_huybienlai(id,tables,loai,mabn,hoten,makp,ngay,quyenso,sobienlai,lydo,userid) values (v_id,v_tables,v_loai,v_mabn,v_hoten,v_makp,to_timestamp(v_ngay,'dd/mm/yyyy'),v_quyenso,v_sobienlai,v_lydo,v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_nhom(v_id numeric,v_ma numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_nhom set sotien=v_sotien where id=v_id and ma=v_ma;
    if found=false then
        insert into medibv0514.v_nhom(id,ma,sotien) values (v_id,v_ma,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_trongoi(v_id numeric,v_sotien numeric,v_tamung numeric,v_hoantra numeric,v_pm numeric,v_yc numeric,v_ghichu text)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_trongoi set sotien=v_sotien,tamung=v_tamung,hoantra=v_hoantra,pm=v_pm,yc=v_yc,ghichu=v_ghichu where id=v_id;
    if found=false then
        insert into medibv0514.v_trongoi(id,sotien,tamung,hoantra,pm,yc,ghichu) values (v_id,v_sotien,v_tamung,v_hoantra,v_pm,v_yc,v_ghichu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_hoantra(v_id numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_mabn varchar,v_hoten text,v_makp varchar,v_sotien numeric,v_ghichu text,v_userid numeric,v_loai numeric,v_loaibn numeric,v_ngaythu varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_hoantra set quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),mabn=v_mabn,hoten=v_hoten,makp=v_makp,sotien=v_sotien,ghichu=v_ghichu,userid=v_userid,loai=v_loai,loaibn=v_loaibn,ngayud=to_timestamp(v_ngaythu,'dd/mm/yyyy hh24:mi') where id=v_id;
    if found=false then
        insert into medibv0514.v_hoantra(id,quyenso,sobienlai,ngay,mabn,hoten,makp,sotien,ghichu,userid,loai,loaibn,ngayud) values (v_id,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_mabn,v_hoten,v_makp,v_sotien,v_ghichu,v_userid,v_loai,v_loaibn,to_timestamp(v_ngaythu,'dd/mm/yyyy hh24:mi'));
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tamung(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_loai numeric,v_loaibn numeric,v_makp varchar,v_madoituong numeric,v_sotien numeric,v_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_tamung set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),loai=v_loai,loaibn=v_loaibn,makp=v_makp,madoituong=v_madoituong,sotien=v_sotien,userid=v_userid where id=v_id;
    if found=false then
        insert into medibv0514.v_tamung(id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,loaibn,makp,madoituong,sotien,userid) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_loai,v_loaibn,v_makp,v_madoituong,v_sotien,v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tamungcd(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_makp varchar,v_ngay varchar,v_madoituong numeric,v_loai numeric,v_loaibn numeric,v_ten text,v_sotien numeric,v_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_tamungcd set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),loai=v_loai,loaibn=v_loaibn,makp=v_makp,madoituong=v_madoituong,ten=v_ten,sotien=v_sotien,userid=v_userid where id=v_id;
    if found=false then
        insert into medibv0514.v_tamungcd(id,mabn,mavaovien,maql,idkhoa,ngay,loai,loaibn,makp,madoituong,ten,sotien,userid) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_loai,v_loaibn,v_makp,v_madoituong,v_ten,v_sotien,v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvll(v_id numeric,v_loaibn numeric,v_loai numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_makp varchar,v_sotien numeric,v_tamung numeric,v_mien numeric,v_bhyt numeric,v_nopthem numeric,v_thieu numeric,v_vattu numeric,v_chenhlech numeric,v_userid numeric,v_idtonghop numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvll set loaibn=v_loaibn,loai=v_loai,quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),makp=v_makp,sotien=v_sotien,tamung=v_tamung,mien=v_mien,bhyt=v_bhyt,nopthem=v_nopthem,thieu=v_thieu,vattu=v_vattu,chenhlech=v_chenhlech,userid=v_userid,idtonghop=v_idtonghop where id=v_id;
    if found=false then
        insert into medibv0514.v_ttrvll(id,loaibn,loai,quyenso,sobienlai,ngay,makp,sotien,tamung,mien,bhyt,nopthem,thieu,vattu,chenhlech,userid,idtonghop) values (v_id,v_loaibn,v_loai,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_makp,v_sotien,v_tamung,v_mien,v_bhyt,v_nopthem,v_thieu,v_vattu,v_chenhlech,v_userid,v_idtonghop);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvct(v_id numeric,v_stt numeric,v_ngay varchar,v_makp varchar,v_madoituong numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_vat numeric,v_vattu numeric,v_sotien numeric,v_sothe varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvct set ngay=to_timestamp(v_ngay,'dd/mm/yyyy'),makp=v_makp,madoituong=v_madoituong,mavp=v_mavp,soluong=v_soluong,dongia=v_dongia,vat=v_vat,vattu=v_vattu,sotien=v_sotien,sothe=v_sothe where id=v_id and stt=v_stt;
    if found=false then
        insert into medibv0514.v_ttrvct(id,stt,ngay,makp,madoituong,mavp,soluong,dongia,vat,vattu,sotien,sothe) values (v_id,v_stt,to_timestamp(v_ngay,'dd/mm/yyyy'),v_makp,v_madoituong,v_mavp,v_soluong,v_dongia,v_vat,v_vattu,v_sotien,v_sothe);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvds(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_giuong varchar,v_ngayvao varchar,v_ngayra varchar,v_chandoan text,v_maicd varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvds set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,giuong=v_giuong,ngayvao=to_timestamp(v_ngayvao,'dd/mm/yyyy hh24:mi'),ngayra=to_timestamp(v_ngayra,'dd/mm/yyyy hh24:mi'),chandoan=v_chandoan,maicd=v_maicd where id=v_id;
    if found=false then
        insert into medibv0514.v_ttrvds(id,mabn,mavaovien,maql,idkhoa,giuong,ngayvao,ngayra,chandoan,maicd) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,v_giuong,to_timestamp(v_ngayvao,'dd/mm/yyyy hh24:mi'),to_timestamp(v_ngayra,'dd/mm/yyyy hh24:mi'),v_chandoan,v_maicd);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvbhyt(v_id numeric,v_sothe varchar,v_maphu numeric,v_tungay varchar,v_ngay varchar,v_mabv varchar,v_noigioithieu varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvbhyt set sothe=v_sothe,maphu=v_maphu,tungay=to_timestamp(v_tungay,'dd/mm/yyyy'),ngay=to_timestamp(v_ngay,'dd/mm/yyyy'),mabv=v_mabv,noigioithieu=v_noigioithieu where id=v_id;
    if found=false then
        insert into medibv0514.v_ttrvbhyt(id,sothe,maphu,tungay,ngay,mabv,noigioithieu) values (v_id,v_sothe,v_maphu,to_timestamp(v_tungay,'dd/mm/yyyy'),to_timestamp(v_ngay,'dd/mm/yyyy'),v_mabv,v_noigioithieu);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvbhyt(v_id numeric,v_sothe varchar,v_maphu numeric,v_tungay varchar,v_ngay varchar,v_mabv varchar,v_noigioithieu varchar,v_traituyen numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvbhyt set sothe=v_sothe,maphu=v_maphu,tungay=to_timestamp(v_tungay,'dd/mm/yyyy'),ngay=to_timestamp(v_ngay,'dd/mm/yyyy'),mabv=v_mabv,noigioithieu=v_noigioithieu,traituyen=v_traituyen where id=v_id;
    if found=false then
        insert into medibv0514.v_ttrvbhyt(id,sothe,maphu,tungay,ngay,mabv,noigioithieu,traituyen) values (v_id,v_sothe,v_maphu,to_timestamp(v_tungay,'dd/mm/yyyy'),to_timestamp(v_ngay,'dd/mm/yyyy'),v_mabv,v_noigioithieu,v_traituyen);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_phieuchill(v_id numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_mabn varchar,v_maql numeric,v_idkhoa numeric,v_makp varchar,v_hoten text,v_loai numeric,v_loaibn numeric,v_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_phieuchill set quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),mabn=v_mabn,maql=v_maql,idkhoa=v_idkhoa,makp=v_makp,hoten=v_hoten,loai=v_loai,loaibn=v_loaibn,userid=v_userid where id=v_id;
    if found=false then
        insert into medibv0514.v_phieuchill(id,quyenso,sobienlai,ngay,mabn,maql,idkhoa,makp,hoten,loai,loaibn,userid) values (v_id,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_mabn,v_maql,v_idkhoa,v_makp,v_hoten,v_loai,v_loaibn,v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_phieuchict(v_id numeric,v_stt numeric,v_mavp numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_phieuchict set mavp=v_mavp,sotien=v_sotien where id=v_id and stt=v_stt;
    if found=false then
        insert into medibv0514.v_phieuchict(id,stt,mavp,sotien) values (v_id,v_stt,v_mavp,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_tamungct(v_id numeric,v_loaivp numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_tamungct set sotien=v_sotien where id=v_id and loaivp=v_loaivp;
    if found=false then
        insert into medibv0514.v_tamungct(id,loaivp,sotien) values (v_id,v_loaivp,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_hoantract(v_id numeric,v_loaivp numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_hoantract set sotien=v_sotien where id=v_id and loaivp=v_loaivp;
    if found=false then
        insert into medibv0514.v_hoantract(id,loaivp,sotien) values (v_id,v_loaivp,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thvpll(v_id numeric,v_mabn varchar,v_mavaovien numeric,v_maql numeric,v_idkhoa numeric,v_ngayvao varchar,v_ngayra varchar,v_giuong varchar,v_makp varchar,v_chandoan text,v_maicd varchar,v_sotien numeric,v_tamung numeric,v_bhyt numeric,v_mien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thvpll set mabn=v_mabn,mavaovien=v_mavaovien,maql=v_maql,idkhoa=v_idkhoa,ngayvao=to_timestamp(v_ngayvao,'dd/mm/yyyy hh24:mi'),ngayra=to_timestamp(v_ngayra,'dd/mm/yyyy hh24:mi'),giuong=v_giuong,makp=v_makp,chandoan=v_chandoan,maicd=v_maicd,sotien=v_sotien,tamung=v_tamung,bhyt=v_bhyt,mien=v_mien where id=v_id;
    if found=false then
        insert into medibv0514.v_thvpll(id,mabn,mavaovien,maql,idkhoa,ngayvao,ngayra,giuong,makp,chandoan,maicd,sotien,tamung,bhyt,mien,done) values (v_id,v_mabn,v_mavaovien,v_maql,v_idkhoa,to_timestamp(v_ngayvao,'dd/mm/yyyy hh24:mi'),to_timestamp(v_ngayra,'dd/mm/yyyy hh24:mi'),v_giuong,v_makp,v_chandoan,v_maicd,v_sotien,v_tamung,v_bhyt,v_mien,0);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thvpct(v_id numeric,v_ngay varchar,v_makp varchar,v_madoituong numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_sotien numeric,v_vattu numeric,v_sothe varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thvpct set soluong=soluong+v_soluong,sotien=sotien+v_sotien,vattu=v_vattu where id=v_id and to_char(ngay,'dd/mm/yyyy')=v_ngay and makp=v_makp and madoituong=v_madoituong and mavp=v_mavp and dongia=v_dongia;
    if found=false then
        insert into medibv0514.v_thvpct(id,ngay,makp,madoituong,mavp,soluong,dongia,sotien,vattu,sothe) values (v_id,to_timestamp(v_ngay,'dd/mm/yyyy'),v_makp,v_madoituong,v_mavp,v_soluong,v_dongia,v_sotien,v_vattu,v_sothe);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thvpct(v_id numeric,v_ngay varchar,v_makp varchar,v_madoituong numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_sotien numeric,v_vattu numeric,v_sothe varchar, v_traituyen numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thvpct set soluong=soluong+v_soluong,sotien=sotien+v_sotien,vattu=v_vattu, traituyen=v_traituyen where id=v_id and to_char(ngay,'dd/mm/yyyy')=v_ngay and makp=v_makp and madoituong=v_madoituong and mavp=v_mavp and dongia=v_dongia;
    if found=false then
        insert into medibv0514.v_thvpct(id,ngay,makp,madoituong,mavp,soluong,dongia,sotien,vattu,sothe, traituyen) values (v_id,to_timestamp(v_ngay,'dd/mm/yyyy'),v_makp,v_madoituong,v_mavp,v_soluong,v_dongia,v_sotien,v_vattu,v_sothe,v_traituyen);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thvpbhyt(v_id numeric,v_sothe varchar,v_maphu numeric,v_noigioithieu varchar,v_noicap varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thvpbhyt set sothe=v_sothe,maphu=v_maphu,noigioithieu=v_noigioithieu,noicap=v_noicap where id=v_id;
    if found=false then
        insert into medibv0514.v_thvpbhyt(id,sothe,maphu,noigioithieu,noicap) values (v_id,v_sothe,v_maphu,v_noigioithieu,v_noicap);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thvpbhyt(v_id numeric,v_sothe varchar,v_maphu numeric,v_noigioithieu varchar,v_noicap varchar,v_traituyen numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thvpbhyt set sothe=v_sothe,maphu=v_maphu,noigioithieu=v_noigioithieu,noicap=v_noicap,traituyen=v_traituyen where id=v_id;
    if found=false then
        insert into medibv0514.v_thvpbhyt(id,sothe,maphu,noigioithieu,noicap,traituyen) values (v_id,v_sothe,v_maphu,v_noigioithieu,v_noicap,v_traituyen);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvnhom(v_id numeric,v_ma numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvnhom set sotien=v_sotien where id=v_id and ma=v_ma;
    if found=false then
        insert into medibv0514.v_ttrvnhom(id,ma,sotien) values (v_id,v_ma,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvpttt(v_id numeric,v_ngay varchar,v_songay_tpt numeric,v_songay_spt numeric,v_mavp numeric,v_tenpt text,v_so numeric,v_loaipt numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvpttt set ngay=to_timestamp(v_ngay,'dd/mm/yyyy'),songay_tpt=v_songay_tpt,songay_spt=v_songay_spt,mavp=v_mavp,tenpt=v_tenpt,so=v_so,loaipt=v_loaipt where id=v_id;
    if found=false then
        insert into medibv0514.v_ttrvpttt(id,ngay,songay_tpt,songay_spt,mavp,tenpt,so,loaipt) values (v_id,to_timestamp(v_ngay,'dd/mm/yyyy'),v_songay_tpt,v_songay_spt,v_mavp,v_tenpt,v_so,v_loaipt);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ttrvptttct(v_id numeric,v_stt numeric,v_loaipt numeric,v_songay numeric,v_dongia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_ttrvptttct set loaipt=v_loaipt,songay=v_songay,dongia=v_dongia where id=v_id and stt=v_stt;
    if found=false then
        insert into medibv0514.v_ttrvptttct(id,stt,loaipt,songay,dongia) values (v_id,v_stt,v_loaipt,v_songay,v_dongia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_giuong(v_id numeric,v_mavp numeric,v_ngay varchar,v_dongia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_giuong set dongia=v_dongia where id=v_id and mavp=v_mavp and to_char(ngay,'dd/mm/yyyy')=v_ngay;
    if found=false then
        insert into medibv0514.v_giuong(id,mavp,ngay,dongia) values (v_id,v_mavp,to_timestamp(v_ngay,'dd/mm/yyyy'),v_dongia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thngayll(v_id numeric,v_madoituong numeric,v_mabn varchar,v_maql numeric,v_ngayvao varchar,v_tu varchar,v_den varchar,v_giuong varchar,v_makp varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thngayll set madoituong=v_madoituong,mabn=v_mabn,maql=v_maql,ngayvao=to_timestamp(v_ngayvao,'dd/mm/yyyy'),tu=to_timestamp(v_tu,'dd/mm/yyyy'),den=to_timestamp(v_den,'dd/mm/yyyy'),giuong=v_giuong,makp=v_makp where id=v_id;
    if found=false then
        insert into medibv0514.v_thngayll(id,madoituong,mabn,maql,ngayvao,tu,den,giuong,makp,done) values (v_id,v_madoituong,v_mabn,v_maql,to_timestamp(v_ngayvao,'dd/mm/yyyy'),to_timestamp(v_tu,'dd/mm/yyyy'),to_timestamp(v_den,'dd/mm/yyyy'),v_giuong,v_makp,0);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_thngayct(v_id numeric,v_ngay varchar,v_mavp numeric,v_soluong numeric,v_dongia numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.v_thngayct set soluong=soluong+v_soluong,sotien=sotien+v_sotien where id=v_id and to_char(ngay,'dd/mm/yyyy')=v_ngay and mavp=v_mavp and dongia=v_dongia;
    if found=false then
        insert into medibv0514.v_thngayct(id,ngay,mavp,soluong,dongia,sotien) values (v_id,to_timestamp(v_ngay,'dd/mm/yyyy'),v_mavp,v_soluong,v_dongia,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_daduyet(d_nhom numeric,d_ngay varchar,d_makp numeric,d_loai numeric,d_phieu numeric,d_makho numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_daduyet set nhom=d_nhom where nhom=d_nhom and to_char(ngay,'dd/mm/yyyy')=d_ngay and makp=d_makp and loai=d_loai and phieu=d_phieu and makho=d_makho;
    if found=false then
        insert into medibv0514.d_daduyet(nhom,ngay,makp,loai,phieu,makho) values (d_nhom,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_loai,d_phieu,d_makho);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_daduyet(d_nhom numeric,d_ngay varchar,d_makp numeric,d_loai numeric,d_phieu numeric,d_makho numeric,d_duyettreole numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_daduyet set duyettreole=d_duyettreole where nhom=d_nhom and to_char(ngay,'dd/mm/yyyy')=d_ngay and makp=d_makp and loai=d_loai and phieu=d_phieu and makho=d_makho;
    if found=false then
        insert into medibv0514.d_daduyet(nhom,ngay,makp,loai,phieu,makho,duyettreole) values (d_nhom,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_loai,d_phieu,d_makho,d_duyettreole);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_sophieu(d_nhom numeric,d_ngay varchar,d_makp numeric,d_loai numeric,d_phieu numeric,d_loaiin numeric,d_makho numeric,d_madoituong varchar,d_manguon varchar,d_nguoilinh text)
 RETURNS void AS
$BODY$
DECLARE
    d_so numeric;
begin
    update medibv0514.d_sophieu set lanin=lanin+1,nguoilinh=d_nguoilinh where nhom=d_nhom and to_char(ngay,'dd/mm/yyyy')=d_ngay and makp=d_makp and loai=d_loai and phieu=d_phieu and loaiin=d_loaiin and makho=d_makho and madoituong=d_madoituong and manguon=d_manguon;
    if found=false then	
        select max(so) into d_so from medibv0514.d_sophieu where nhom=d_nhom and makp=d_makp and loai=d_loai and loaiin=d_loaiin and makho=d_makho and madoituong=d_madoituong and manguon=d_manguon;
        if d_so is null then
            d_so:=0;
        end if;
        d_so:=d_so+1;
        insert into medibv0514.d_sophieu(nhom,ngay,makp,loai,phieu,loaiin,makho,madoituong,so,manguon,nguoilinh) values (d_nhom,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makp,d_loai,d_phieu,d_loaiin,d_makho,d_madoituong,d_so,d_manguon,d_nguoilinh);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_vienphill(v_id numeric,v_loai numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_mabn varchar,v_hoten text,v_masothue in varchar,v_userid numeric)
    RETURNS void AS
$BODY$
begin
    update medibv0514.ng_vienphill set loai=v_loai,quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),mabn=v_mabn,hoten=v_hoten,masothue=v_masothue,userid=v_userid where id=v_id;
    if found=false then
        insert into medibv0514.ng_vienphill(id,loai,quyenso,sobienlai,ngay,mabn,hoten,masothue,userid) values (v_id,v_loai,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_mabn,v_hoten,v_masothue,v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_vienphict(v_id numeric,v_idll numeric,v_mavp numeric,v_ten text,v_soluong numeric,v_dongia numeric,v_sotiennop numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_vienphict set mavp=v_mavp,ten=v_ten,soluong=v_soluong,dongia=v_dongia,sotiennop=v_sotiennop  where id=v_id;
    if found=false then
        insert into medibv0514.ng_vienphict(id,idll,mavp,ten,soluong,dongia,sotiennop) values (v_id,v_idll,v_mavp,v_ten,v_soluong,v_dongia,v_sotiennop);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_chia(v_id numeric,v_manv numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_chia set sotien=v_sotien  where id=v_id and manv=v_manv;
    if found=false then
        insert into medibv0514.ng_chia(id,manv,sotien) values (v_id,v_manv,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_huybienlai(v_id numeric,v_tables varchar,v_loai numeric,v_mabn varchar,v_hoten text,v_makp varchar,v_ngay varchar,v_quyenso numeric,v_sobienlai numeric,v_lydo text,v_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_huybienlai set loai=v_loai,mabn=v_mabn,hoten=v_hoten,makp=v_makp,ngay=to_timestamp(v_ngay,'dd/mm/yyyy'),quyenso=v_quyenso,sobienlai=v_sobienlai,lydo=v_lydo,userid=v_userid where id=v_id and tables=v_tables;
    if found=false then
        insert into medibv0514.ng_huybienlai(id,tables,loai,mabn,hoten,makp,ngay,quyenso,sobienlai,lydo,userid) values (v_id,v_tables,v_loai,v_mabn,v_hoten,v_makp,to_timestamp(v_ngay,'dd/mm/yyyy'),v_quyenso,v_sobienlai,v_lydo,v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_hoantra(v_id numeric,v_quyenso numeric,v_sobienlai numeric,v_ngay varchar,v_mabn varchar,v_hoten text,v_makp varchar,v_sotien numeric,v_ghichu text,v_userid numeric,v_loai numeric,v_loaibn numeric,v_ngaythu varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_hoantra set quyenso=v_quyenso,sobienlai=v_sobienlai,ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),mabn=v_mabn,hoten=v_hoten,makp=v_makp,sotien=v_sotien,ghichu=v_ghichu,userid=v_userid,loai=v_loai,loaibn=v_loaibn,ngayud=to_timestamp(v_ngaythu,'dd/mm/yyyy hh24:mi') where id=v_id;
    if found=false then
        insert into medibv0514.ng_hoantra(id,quyenso,sobienlai,ngay,mabn,hoten,makp,sotien,ghichu,userid,loai,loaibn,ngayud) values (v_id,v_quyenso,v_sobienlai,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_mabn,v_hoten,v_makp,v_sotien,v_ghichu,v_userid,v_loai,v_loaibn,to_timestamp(v_ngaythu,'dd/mm/yyyy hh24:mi'));
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_hoantract(v_id numeric,v_loaivp numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_hoantract set sotien=v_sotien where id=v_id and loaivp=v_loaivp;
    if found=false then
        insert into medibv0514.ng_hoantract(id,loaivp,sotien) values (v_id,v_loaivp,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_tiencong(v_ngay varchar,v_idct numeric,v_mavp numeric,v_idnv numeric,v_soluong numeric,v_phan numeric,v_sotien numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_tiencong set soluong=v_soluong,phan=v_phan,sotien=v_sotien  where to_char(ngay,'dd/mm/yyyy')=v_ngay and idct=v_idct and mavp=v_mavp and idnv=v_idnv;
    if found=false then
        insert into medibv0514.ng_tiencong(ngay,idct,mavp,idnv,soluong,phan,sotien) values (to_timestamp(v_ngay,'dd/mm/yyyy'),v_idct,v_mavp,v_idnv,v_soluong,v_phan,v_sotien);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_eve_tables(m_tableid numeric,m_ngay varchar,m_userid numeric,m_computerid numeric,m_ins numeric,m_upd numeric,m_del numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.eve_tables set ins=ins+m_ins,upd=upd+m_upd,del=del+m_del where tableid=m_tableid and to_char(ngay,'dd/mm/yyyy')=m_ngay and userid=m_userid and computerid=m_computerid;
    if found=false then
        insert into medibv0514.eve_tables(tableid,ngay,userid,computerid,ins,upd,del) values (m_tableid,to_timestamp(m_ngay,'dd/mm/yyyy'),m_userid,m_computerid,m_ins,m_upd,m_del);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_eve_upd_del(m_tableid numeric,m_userid numeric,m_computerid numeric,m_command varchar,m_noidung text)
  RETURNS void AS
$BODY$
begin
    insert into medibv0514.eve_upd_del(tableid,userid,computerid,command,noidung) values (m_tableid,m_userid,m_computerid,m_command,m_noidung);
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_khamll(v_id numeric,v_ngay varchar, v_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_khamll set ngay=to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),userid=v_userid where id=v_id;
    if found=false then
        insert into medibv0514.ng_khamll(id,ngay,userid) values (v_id,to_timestamp(v_ngay,'dd/mm/yyyy hh24:mi'),v_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_ng_khamct(v_id numeric,v_kyhieu varchar,v_tu numeric,v_den numeric,v_mavp numeric,v_soluong numeric,v_dongia numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.ng_khamct set kyhieu=v_kyhieu,tu=v_tu,den=v_den,soluong=v_soluong,dongia=v_dongia where id=v_id and mavp=v_mavp;
    if found=false then
        insert into medibv0514.ng_khamct(id,kyhieu,tu,den,mavp,soluong,dongia) values (v_id,v_kyhieu,v_tu,v_den,v_mavp,v_soluong,v_dongia);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_inchiphipk(m_mabn varchar,m_mavaovien numeric,m_ngay varchar,m_makp varchar)
  RETURNS void AS
$BODY$
begin
    update medibv0514.inchiphipk set mabn=m_mabn,ngay=to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),makp=m_makp,lan=lan+1 where mavaovien=m_mavaovien;
    if found=false then
        insert into medibv0514.inchiphipk(mabn,mavaovien,ngay,makp,lan) values (m_mabn,m_mavaovien,to_timestamp(m_ngay,'dd/mm/yyyy hh24:mi'),m_makp,1);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE;
CREATE OR REPLACE FUNCTION medibv0514.upd_htrathuocll(d_id numeric,d_nhom numeric,d_ngay varchar,d_mabn varchar,d_mavaovien numeric,d_maql numeric,d_madoituong numeric,d_makp varchar,d_mabs varchar,d_loaiba numeric,d_ghichu text,d_userid numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_htrathuocll set nhom=d_nhom,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),mabn=d_mabn,mavaovien=d_mavaovien,maql=d_maql,userid=d_userid,madoituong=d_madoituong,ghichu=d_ghichu,makp=d_makp,mabs=d_mabs,loaiba=d_loaiba where id=d_id;
    if found=false then
        insert into medibv0514.d_htrathuocll(id,nhom,ngay,mabn,mavaovien,maql,madoituong,makp,mabs,loaiba,ghichu,userid) values (d_id,d_nhom,to_timestamp(d_ngay,'dd/mm/yyyy'),d_mabn,d_mavaovien,d_maql,d_madoituong,d_ghichu,d_songay,d_makp,d_mabs,d_loaiba,d_ghichu,d_userid);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
CREATE OR REPLACE FUNCTION medibv0514.upd_htrathuocct(d_id numeric,d_stt numeric,d_sttt numeric,d_ngay varchar,d_makho numeric,d_mabd numeric,d_soluong numeric,d_giaban numeric)
  RETURNS void AS
$BODY$
begin
    update medibv0514.d_htrathuocct set sttt=d_sttt,ngay=to_timestamp(d_ngay,'dd/mm/yyyy'),makho=d_makho,mabd=d_mabd,soluong=d_soluong,giaban=d_giaban where id=d_id and stt=d_stt;
    if found=false then
        insert into medibv0514.d_htrathuocct(id,stt,sttt,ngay,makho,mabd,soluong,giaban) values (d_id,d_stt,d_sttt,to_timestamp(d_ngay,'dd/mm/yyyy'),d_makho,d_mabd,d_soluong,d_giaban);
    end if;
end;
$BODY$
  LANGUAGE 'plpgsql' VOLATILE; 
