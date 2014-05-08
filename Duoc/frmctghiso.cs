using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibDuoc;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmctghiso.
	/// </summary>
	public class frmctghiso : System.Windows.Forms.Form
	{
		AccessData d=new AccessData();
		int i_nhomkho,i_userid, i_kho;
		string s_makho, s_mmyy,s_ngay;
		long l_id=0;
		DataSet ds;
		//
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label lSoluong;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox sotien;
		private System.Windows.Forms.TextBox soct;
		private System.Windows.Forms.TextBox co;
		private System.Windows.Forms.TextBox no;
		private System.Windows.Forms.TextBox diengiai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmctghiso(int nhomkho, string makho, string mmyy, int userid, string ngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			i_nhomkho=nhomkho;
			s_makho=(makho=="")?"":makho.Substring(0,makho.Length-1);
			s_mmyy=mmyy;
			s_ngay=ngay;
			i_userid=userid;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmctghiso));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.butIn = new System.Windows.Forms.Button();
			this.butTim = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butMoi = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.sotien = new System.Windows.Forms.TextBox();
			this.soct = new System.Windows.Forms.TextBox();
			this.co = new System.Windows.Forms.TextBox();
			this.no = new System.Windows.Forms.TextBox();
			this.lSoluong = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.diengiai = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, -16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(776, 464);
			this.dataGrid1.TabIndex = 13;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(473, 488);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 11;
			this.butIn.Text = "&In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butTim
			// 
			this.butTim.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTim.Image")));
			this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTim.Location = new System.Drawing.Point(600, 520);
			this.butTim.Name = "butTim";
			this.butTim.Size = new System.Drawing.Size(75, 28);
			this.butTim.TabIndex = 10;
			this.butTim.Text = "          &Tìm";
			this.butTim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTim.Visible = false;
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(520, 520);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(75, 28);
			this.butHuy.TabIndex = 9;
			this.butHuy.Text = "          &Hủy";
			this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Visible = false;
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(396, 488);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(75, 28);
			this.butBoqua.TabIndex = 8;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(319, 488);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 7;
			this.butLuu.Text = "           &Lưu";
			this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(242, 488);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(75, 28);
			this.butSua.TabIndex = 6;
			this.butSua.Text = "         &Sửa";
			this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(165, 488);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(75, 28);
			this.butMoi.TabIndex = 5;
			this.butMoi.Text = "  &Tổng hợp";
			this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(550, 488);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 12;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// sotien
			// 
			this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sotien.Enabled = false;
			this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sotien.Location = new System.Drawing.Point(660, 456);
			this.sotien.Name = "sotien";
			this.sotien.Size = new System.Drawing.Size(124, 21);
			this.sotien.TabIndex = 4;
			this.sotien.Text = "";
			this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// soct
			// 
			this.soct.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.soct.Enabled = false;
			this.soct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soct.Location = new System.Drawing.Point(79, 456);
			this.soct.MaxLength = 6;
			this.soct.Name = "soct";
			this.soct.Size = new System.Drawing.Size(56, 21);
			this.soct.TabIndex = 0;
			this.soct.Text = "";
			// 
			// co
			// 
			this.co.BackColor = System.Drawing.SystemColors.HighlightText;
			this.co.Enabled = false;
			this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.co.Location = new System.Drawing.Point(552, 456);
			this.co.Name = "co";
			this.co.Size = new System.Drawing.Size(64, 21);
			this.co.TabIndex = 3;
			this.co.Text = "";
			// 
			// no
			// 
			this.no.BackColor = System.Drawing.SystemColors.HighlightText;
			this.no.Enabled = false;
			this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.no.Location = new System.Drawing.Point(459, 456);
			this.no.Name = "no";
			this.no.Size = new System.Drawing.Size(64, 21);
			this.no.TabIndex = 2;
			this.no.Text = "";
			// 
			// lSoluong
			// 
			this.lSoluong.Location = new System.Drawing.Point(616, 456);
			this.lSoluong.Name = "lSoluong";
			this.lSoluong.Size = new System.Drawing.Size(40, 23);
			this.lSoluong.TabIndex = 51;
			this.lSoluong.Text = "Số tiền";
			this.lSoluong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(431, 456);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 23);
			this.label9.TabIndex = 50;
			this.label9.Text = "Nợ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(521, 456);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 23);
			this.label8.TabIndex = 49;
			this.label8.Text = "Có";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// diengiai
			// 
			this.diengiai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diengiai.Enabled = false;
			this.diengiai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diengiai.Location = new System.Drawing.Point(187, 456);
			this.diengiai.Name = "diengiai";
			this.diengiai.Size = new System.Drawing.Size(240, 21);
			this.diengiai.TabIndex = 1;
			this.diengiai.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 456);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 48;
			this.label1.Text = "Số chứng từ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(136, 456);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 47;
			this.label2.Text = "Diễn giải ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmctghiso
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.sotien,
																		  this.soct,
																		  this.co,
																		  this.no,
																		  this.lSoluong,
																		  this.label9,
																		  this.label8,
																		  this.diengiai,
																		  this.label1,
																		  this.label2,
																		  this.butIn,
																		  this.butTim,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.butKetthuc,
																		  this.dataGrid1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmctghiso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chứng từ ghi sổ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmctghiso_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private void ena_object(bool ena)
		{
			//soct.Enabled=ena;
			diengiai.Enabled=ena;
			no.Enabled=ena;
			co.Enabled=ena;
			//sotien.Enabled=ena;
			//
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butTim.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			dataGrid1.ReadOnly=!ena;
		}
		private void load_ctughiso()
		{
			string sql="select a.soct, a.mmyy, a.ngay, a.userid, c.ten tenkho, d.ten tenkp, (nvl(b.no,'')||nvl(b.co,'')||decode(b.makho,19,'1','0')) tk, b.* ";
			sql+=" from d_ctghisoll a, d_ctghisoct b,"+d.user+".d_dmkho c,"+d.user+".d_duockp d ";
			sql+=" where a.id=b.id and b.makho=c.id(+) and b.makp=d.id(+) ";
			sql+=" and a.nhom="+i_nhomkho+" and a.mmyy='"+s_mmyy+"'";
			if(s_makho!="")sql+=" and b.makho in ("+s_makho+")";
			ds=new DataSet();
			ds=d.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
		}
		private void tonghop_ctghso_xuat()
		{
			string sql=" select a.mmyy, b.makho,e.ten tenkho, c.sotk, d.ten tennhom,d.ma, sum(b.soluong*b.giamua) sotien";
			sql+=" from d_xuatsdll a, d_thucxuat b,"+d.user+".d_dmbd c,"+d.user+".d_dmnhomkt d,"+d.user+".d_dmkho e where a.id=b.id and b.mabd=c.id and c.sotk=d.id(+) and b.makho=e.id and a.mmyy='"+s_mmyy+"' and a.nhom="+i_nhomkho;
			if(s_makho!="")sql+=" and b.makho in ("+s_makho+")";
			sql+=" group by a.mmyy, b.makho,e.ten,c.sotk,d.ten,d.ma";
			sql+=" union all ";
			sql+=" select a.mmyy, b.makho,e.ten tenkho, c.sotk, d.ten tennhom,d.ma, sum(b.soluong*b.giamua) sotien";
			sql+=" from bhytkb a, bhytthuoc b,"+d.user+".d_dmbd c,"+d.user+".d_dmnhomkt d,"+d.user+".d_dmkho e where a.id=b.id and b.mabd=c.id and c.sotk=d.id(+) and b.makho=e.id and a.mmyy='"+s_mmyy+"' and a.nhom="+i_nhomkho;
			if(s_makho!="")sql+=" and b.makho in ("+s_makho+")";
			sql+=" group by a.mmyy, b.makho,e.ten,c.sotk,d.ten,d.ma";
			sql+=" union all ";
			sql+=" select a.mmyy, b.makho,e.ten tenkho, c.sotk, d.ten tennhom, d.ma, sum(b.soluong*b.giamua) sotien";
			sql+=" from d_ngtrull a, d_ngtruct b,"+d.user+".d_dmbd c,"+d.user+".d_dmnhomkt d,"+d.user+".d_dmkho e where a.id=b.id and b.mabd=c.id and c.sotk=d.id(+) and b.makho=e.id and a.mmyy='"+s_mmyy+"' and a.nhom="+i_nhomkho;
			if(s_makho!="")sql+=" and b.makho in ("+s_makho+")";
			sql+=" group by a.mmyy, b.makho,e.ten,c.sotk,d.ten,d.ma";

			DataTable dt=d.get_data(sql).Tables[0];
			string s_diengiai="";
			foreach(DataRow r in dt.Rows)
			{
				l_id=d.get_id_ctghiso;
				s_diengiai="Tiền xuất "+r["tennhom"].ToString()+" của "+r["tenkho"].ToString();
				d.upd_ctghisoll(l_id,i_nhomkho,l_id.ToString(),s_ngay,s_mmyy,i_userid);
				d.upd_ctghisoct(s_mmyy,l_id,int.Parse(r["makho"].ToString()),0,"",r["ma"].ToString(),decimal.Parse(r["sotien"].ToString()),s_diengiai);
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			bool bln=check_tonghop();
			DialogResult dlg;
			if(bln==true)		dlg =MessageBox.Show("Tháng này đã tổng hợp chứng từ ghi sổ rồi. Bạn có muốn tổng hợp lại không ?","CT ghi sổ",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);				
			else 				dlg=DialogResult.Yes;
			if(dlg==DialogResult.Yes)
			{
				Del_ctghiso();
				tonghop_ctghso_nhap();
				tonghop_ctghso_xuat();
				load_ctughiso();
			}
		}

		private void frmctghiso_Load(object sender, System.EventArgs e)
		{
			load_ctughiso();
			AddGridTableStyle();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
				
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "SOCT";
			TextCol.HeaderText = "SCT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "diengiai";
			TextCol.HeaderText = "Diễn giải";
			TextCol.Width = 380;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "NO";
			TextCol.HeaderText = "TK nợ";
			TextCol.Width = 80;
			TextCol.NullText=String.Empty;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "CO";
			TextCol.HeaderText = "TK Có";
			TextCol.Width = 80;
			TextCol.NullText=String.Empty;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 150;
			TextCol.Format="###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
					
		}
		private void tonghop_ctghso_nhap()
		{
			string sql=" select a.mmyy, a.makho,e.ten tenkho, c.sotk, d.ten tennhom,d.ma,decode(f.nhomcc,1,1,0) nhom, sum(b.sotien+b.sotien*b.vat/100) sotien";
			sql+=" from d_nhapll a, d_nhapct b,"+d.user+".d_dmbd c,"+d.user+".d_dmnhomkt d,"+d.user+".d_dmkho e,"+d.user+".d_dmnx f";
			sql+=" where a.id=b.id and b.mabd=c.id and c.sotk=d.id(+) and a.makho=e.id and a.madv=f.id ";
			sql+=" and a.mmyy='"+s_mmyy+"' and a.nhom="+i_nhomkho+" and a.loai='M'";
			if(s_makho!="")sql+=" and a.makho in ("+s_makho+")";
			sql+=" group by a.mmyy, a.makho,e.ten,c.sotk,d.ten,d.ma,decode(f.nhomcc,1,1,0)";
			//
			DataTable dt=d.get_data(sql).Tables[0];
			//update ctu ghi so: nhap			
			string s_diengiai="";
			string s_no="";
			foreach(DataRow r in dt.Select("sotien>0"))
			{
				l_id=d.get_id_ctghiso;
				if(r["nhom"].ToString()=="1")//hang khuyen mai
				{
					s_diengiai="Tiền "+r["tennhom"].ToString()+" khuyến mại nhập vào "+r["tenkho"].ToString();
					s_no="";
				}
				else
				{
					s_no=r["ma"].ToString();
					s_diengiai="Tiền nhập "+r["tennhom"].ToString()+" vào "+r["tenkho"].ToString();
				}
				//
				d.upd_ctghisoll(l_id,i_nhomkho,l_id.ToString(),s_ngay,s_mmyy,i_userid);
				d.upd_ctghisoct(s_mmyy,l_id,int.Parse(r["makho"].ToString()),0,s_no ,"",decimal.Parse(r["sotien"].ToString()),s_diengiai);
			}
		}
		private void ref_text(long id)
		{
			try
			{
				DataRow r;
				if (id==0)
				{
					int i=dataGrid1.CurrentCell.RowNumber;
					r=d.getrowbyid(ds.Tables[0],"id="+long.Parse(dataGrid1[i,0].ToString()));
				}
				else r=d.getrowbyid(ds.Tables[0],"id="+id);
				if (r!=null)
				{
					soct.Text=r["soct"].ToString();
					diengiai.Text=r["diengiai"].ToString();
					no.Text=r["no"].ToString();
					co.Text=r["co"].ToString();
					sotien.Text=r["sotien"].ToString();	
					i_kho=int.Parse(r["makho"].ToString());
				}
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				l_id=long.Parse(dataGrid1[i,0].ToString());
				ref_text(l_id);
				//ena_object(false);
			}
			catch{}
		}
		private bool check_tonghop()
		{
			string sql=" select * from d_ctghisoll where mmyy='"+s_mmyy+"'";
			DataTable dt=d.get_data(sql).Tables[0];
			bool bln=(dt.Rows.Count>0)?true:false;
			return bln;
		}

		private void Del_ctghiso()
		{
			string sql="delete from d_ctghisoct where id in (select id from d_ctghisoll where mmyy='"+s_mmyy+"')";
			d.execute_data(sql);
			sql="delete from d_ctghisoll where mmyy='"+s_mmyy+"'";
			d.execute_data(sql);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if(kiemtra())
			{
				d.upd_ctghisoll(l_id,i_nhomkho,soct.Text,s_ngay,s_mmyy,i_userid);
				d.upd_ctghisoct(s_mmyy,l_id,i_kho,0,no.Text,co.Text,decimal.Parse(sotien.Text),diengiai.Text);
				upd_items();
				load_ctughiso();
				ena_object(false);
			}
		}

		private void upd_items()
		{
			foreach(DataRow r in ds.Tables[0].Rows)
				d.upd_ctghisoct(s_mmyy,long.Parse(r["id"].ToString()),int.Parse(r["makho"].ToString()),int.Parse(r["makp"].ToString()),r["no"].ToString(),r["co"].ToString(),decimal.Parse(r["sotien"].ToString()),r["diengiai"].ToString());
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
		}
	
		private void Del_ctghiso(long id)
		{
			string sql="delete from d_ctghsoct where id ="+id;
			d.execute_data(sql);
			sql="delete from d_ctghisoll where id="+id;
			d.execute_data(sql);
		}
		private bool kiemtra()
		{
			bool bln=true;
			if(diengiai.Text=="")
			{
				MessageBox.Show("Đề nghị nhập diễn giải của chứng từ vào!","CT ghi sổ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				bln=false;
				return bln;
			}
			if(no.Text=="")
			{
				MessageBox.Show("Đề nghị nhập định khoản Nợ vào!","CT ghi sổ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				bln=false;
				return bln;
			}

			if(co.Text=="")
			{
				MessageBox.Show("Đề nghị nhập định khoản Có vào!","CT ghi sổ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				bln=false;
				return bln;
			}
			return bln;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frminctgs f=new frminctgs(i_nhomkho,s_makho,s_mmyy);
			f.ShowDialog();
		}
	}
}
