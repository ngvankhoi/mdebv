using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmHoantra.
	/// </summary>
	public class frmHoantra : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ngay;
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DataGrid dataGrid1;
		private AccessData d;
		private int i_nhom,i_loai,i_userid,i_makp,i_khudt=0;
		private string user,xxx,s_ngay,sql,s_makp,s_mmyy,s_kho,s_userid;
		private DataTable dtdmbd=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtphieu=new DataTable();
		private bool bKhoaso,bGiaban;
		private decimal l_id=0;
		private DataRow r;
		private System.Windows.Forms.Button butChoduyet;
		private System.Windows.Forms.Button butDuyet;
        private System.Windows.Forms.Button butThuhoi;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butTim;
		private frmMain parent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHoantra(AccessData acc,int nhom,string ngay,int loai,int userid,string users,string makp,string mmyy,string kho,bool giaban,bool thuhoi,string _userid,int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; i_loai = loai; i_userid = userid; s_userid = _userid;
            s_ngay = ngay; s_makp = makp; s_mmyy = mmyy; s_kho = kho; bGiaban = giaban; butThuhoi.Enabled = thuhoi;
			this.Text="Duyệt hoàn trả thuốc, vật tư y tế theo người bệnh ("+users.Trim()+")";
            i_khudt = _khudt;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoantra));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.TextBox();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butChoduyet = new System.Windows.Forms.Button();
            this.butDuyet = new System.Windows.Forms.Button();
            this.butThuhoi = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butTim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(48, 3);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(88, 21);
            this.mabn.TabIndex = 1;
            this.mabn.SelectedIndexChanged += new System.EventHandler(this.mabn_SelectedIndexChanged);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(184, 3);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(344, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(452, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phiếu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(598, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Khoa :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(384, 3);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(68, 21);
            this.ngay.TabIndex = 7;
            // 
            // phieu
            // 
            this.phieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Enabled = false;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(492, 3);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(112, 21);
            this.phieu.TabIndex = 8;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(640, 3);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(144, 21);
            this.makp.TabIndex = 9;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(640, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(144, 499);
            this.treeView1.TabIndex = 10;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(503, 526);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(624, 511);
            this.dataGrid1.TabIndex = 101;
            // 
            // butChoduyet
            // 
            this.butChoduyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butChoduyet.Image = global::Duoc.Properties.Resources.chonkhoa;
            this.butChoduyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChoduyet.Location = new System.Drawing.Point(640, 526);
            this.butChoduyet.Name = "butChoduyet";
            this.butChoduyet.Size = new System.Drawing.Size(144, 25);
            this.butChoduyet.TabIndex = 102;
            this.butChoduyet.Text = "    Danh sách chờ duyệt";
            this.butChoduyet.Click += new System.EventHandler(this.butChoduyet_Click);
            // 
            // butDuyet
            // 
            this.butDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDuyet.Image = global::Duoc.Properties.Resources.Export;
            this.butDuyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDuyet.Location = new System.Drawing.Point(223, 526);
            this.butDuyet.Name = "butDuyet";
            this.butDuyet.Size = new System.Drawing.Size(70, 25);
            this.butDuyet.TabIndex = 103;
            this.butDuyet.Text = "&Duyệt";
            this.butDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDuyet.Click += new System.EventHandler(this.butDuyet_Click);
            // 
            // butThuhoi
            // 
            this.butThuhoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThuhoi.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butThuhoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThuhoi.Location = new System.Drawing.Point(293, 526);
            this.butThuhoi.Name = "butThuhoi";
            this.butThuhoi.Size = new System.Drawing.Size(70, 25);
            this.butThuhoi.TabIndex = 104;
            this.butThuhoi.Text = "&Thu hồi";
            this.butThuhoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThuhoi.Click += new System.EventHandler(this.butThuhoi_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(363, 526);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 106;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.Image = global::Duoc.Properties.Resources.search;
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(433, 526);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 108;
            this.butTim.Text = "    Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // frmHoantra
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butThuhoi);
            this.Controls.Add(this.butDuyet);
            this.Controls.Add(this.butChoduyet);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHoantra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoantra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHoantra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHoantra_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
            dtdmbd = d.get_data("select * from " + user + ".d_dmbd a where a.nhom=" + i_nhom + " order by a.id").Tables[0];
            dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + i_nhom + " and loai=" + i_loai + " order by stt").Tables[0];
			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
			phieu.DataSource=dtphieu;

            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
            if (i_khudt != 0) sql += " and (khu=0 or khu =" + i_khudt + ")";//binh 210411
			sql+=" order by stt";
			dtkp=d.get_data(sql).Tables[0];	
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=dtkp;
			butChoduyet_Click(null,null);

            sql = "select a.id,a.mabn,b.hoten,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.phieu,a.makp,a.idduyet,a.makhoa from " + xxx + ".d_xuatsdll a," + user + ".btdbn b," + user + ".d_duockp d ";
			sql+="where a.mabn=b.mabn and a.makp=d.id and a.loai="+i_loai+" and a.nhom="+i_nhom;
            if (i_khudt != 0) sql += " and (d.khu=0 or d.khu =" + i_khudt + ")";//binh 210411
			//if (d.bUserid) 
                sql+=" and a.userid="+i_userid;
			if (d.bLoclinh) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by a.id";
			dtll=d.get_data(sql).Tables[0];
			mabn.DisplayMember="MABN";
			mabn.ValueMember="ID";
			mabn.DataSource=dtll;
            if (dtll.Rows.Count > 0) l_id = decimal.Parse(mabn.SelectedValue.ToString());
            else l_id = 0;
			load_head();
			AddGridTableStyle();
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,t.giamua as dongia,a.soluong*t.giamua as sotien,t.giaban,t.giamua,a.madoituong,a.makho,t.manguon,t.nhomcc,'xx/xx/xxxx' as ngay ";
			sql+=" from "+xxx+".d_xuatsdct a,"+xxx+".d_theodoi t,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_dmnx d,"+user+".d_doituong e,"+user+".d_dmkho f ";
			sql+="where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.madoituong=e.madoituong and a.makho=f.id and a.id="+l_id;
            if (i_khudt != 0) sql += " and (f.khu=0 or f.khu =" + i_khudt + ")";//binh 210411
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtct.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=5;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bGiaban)?200:230;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = "Kho nhập";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
			TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?90:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 70;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format="###,###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?80:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void load_treeview()
		{
			sql="select c.makp,b.mabd,sum(b.slyeucau-b.slthuc) as soluong, c.loai, c.phieu, f.ten as tenphieu ";
            sql += " from " + xxx + ".d_hoantrall a," + xxx + ".d_hoantract b," + xxx + ".d_duyet c," + user + ".d_dmbd d," + user + ".d_dmphieu e," + user + ".d_loaiphieu f," + user + ".d_duockp g ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and c.loai=e.id and c.phieu=f.id and c.makp=g.id ";
            if (i_khudt != 0) sql += " and (g.khu=0 or a.khu =" + i_khudt + ")";//binh 210411            
			sql+=" and c.nhom="+i_nhom+" and c.loai="+i_loai;
			sql+=" and to_char(c.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" and c.done<>0 and b.slyeucau>b.slthuc and a.maql>0 group by c.makp,b.mabd, c.loai, c.phieu, f.ten order by c.makp,c.loai,c.phieu,b.mabd";
			treeView1.Nodes.Clear();
			TreeNode node;
			DataTable dtngay=d.get_data(sql).Tables[0];
			DataRow [] dr;
			i_makp=0;
			string s_makp="";
			foreach(DataRow r1 in dtngay.Rows)
			{
				if (s_makp!=r1["makp"].ToString()+r1["loai"].ToString()+r1["phieu"].ToString())
				{
					i_makp=int.Parse(r1["makp"].ToString());
					s_makp=r1["makp"].ToString()+r1["loai"].ToString()+r1["phieu"].ToString();
					r=d.getrowbyid(dtkp,"id="+i_makp);
					if (r!=null)
					{
						node=treeView1.Nodes.Add(r["ten"].ToString()+" - "+r1["tenphieu"].ToString());
						dr=dtngay.Select("makp="+i_makp+" and loai="+r1["loai"].ToString()+" and phieu="+r1["phieu"].ToString());
						for(int i=0;i<dr.Length;i++)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(dr[i]["mabd"].ToString()));
							if (r!=null) node.Nodes.Add(r["ten"].ToString().Trim()+"/"+r["tenhc"].ToString().Trim()+" "+r["dang"].ToString().Trim()+" ("+dr[i]["soluong"].ToString().Trim()+")");
						}
					}
				}
			}
		}

		private void butChoduyet_Click(object sender, System.EventArgs e)
		{
			load_treeview();
		}

		private void butDuyet_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			frmDuyet f=new frmDuyet(d,dtll,i_nhom,i_loai,s_makp,s_mmyy,s_kho,this.Text,s_ngay,i_userid,false,false,1,false,s_userid,i_khudt);
			f.ShowDialog(this);
			if (f.bOk)
			{
				dtll=f.dtll;
				dtll.AcceptChanges();
				mabn.Refresh();
				if (dtll.Rows.Count>0) l_id=decimal.Parse(mabn.SelectedValue.ToString());
				else l_id=0;
				load_head();
				butChoduyet_Click(null,null);
			}
		}

		private void mabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabn)
			{
				try
				{
					l_id=decimal.Parse(mabn.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			r=d.getrowbyid(dtll,"id='"+l_id+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
				ngay.Text=r["ngay"].ToString();
				makp.SelectedValue=r["makp"].ToString();
				phieu.SelectedValue=r["phieu"].ToString();
			}
			load_grid();
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butDuyet.Focus();
		}

		private void butThuhoi_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
            frmThuhoi f = new frmThuhoi(d, dtll, dtct, dtkp, dtphieu, int.Parse(makp.SelectedValue.ToString()), int.Parse(phieu.SelectedValue.ToString()), s_ngay, s_mmyy, i_nhom, i_loai, false, false, 1, s_kho, i_userid);
			f.ShowDialog(this);
			if (f.bOk)
			{
				dtll.AcceptChanges();
				mabn.Refresh();
				if (dtll.Rows.Count>0) l_id=decimal.Parse(mabn.SelectedValue.ToString());
				load_head();
				butChoduyet_Click(null,null);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmInphieu f=new frmInphieu(d,dtkp,dtphieu,(makp.SelectedIndex==-1)?-1:int.Parse(makp.SelectedValue.ToString()),(phieu.SelectedIndex==-1)?-1:int.Parse(phieu.SelectedValue.ToString()),s_ngay,s_mmyy,i_nhom,i_loai,s_kho,"PHIẾU HOÀN TRẢ",false,s_userid,false, i_khudt, i_userid);
			f.ShowDialog(this);
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			l_id=0;
			frmTimhoantra f=new frmTimhoantra(this);
			f.MdiParent=parent;
			f.RefreshText("");
			f.Show();
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[mabn.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+text.Trim()+"%'"+" or mabn like '%"+text.Trim()+"%'";
				l_id=decimal.Parse(mabn.SelectedValue.ToString());
				load_head();
			}
			catch{}
		}
	}
}
