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
	/// Summary description for frmKiemtrakhoa.
	/// </summary>
	public class frmKiemtrakhoa : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.ComboBox makp;
		private AccessData d;
		private int i_nhom,i_load=0;
        private bool bThuhoi = false;
		private string sql,f1,f2,user,stime;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKiemtra;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKiemtrakhoa(AccessData acc,int _nhom,string _ngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=_nhom;
            tu.Value = den.Value = new DateTime(int.Parse(_ngay.Substring(6, 4)), int.Parse(_ngay.Substring(3, 2)), int.Parse(_ngay.Substring(0, 2)), 0, 0, 0);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemtrakhoa));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKiemtra = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(123, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(44, 4);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(149, 4);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(360, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(504, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Phiếu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(656, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Khoa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(386, 4);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(120, 21);
            this.loai.TabIndex = 7;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // phieu
            // 
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(536, 4);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(120, 21);
            this.phieu.TabIndex = 9;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(688, 4);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(104, 21);
            this.makp.TabIndex = 11;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(264, 4);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(96, 21);
            this.nhom.TabIndex = 5;
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(229, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nhóm";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 509);
            this.dataGrid1.TabIndex = 20;
            // 
            // butKiemtra
            // 
            this.butKiemtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKiemtra.Image = global::Duoc.Properties.Resources.ok;
            this.butKiemtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKiemtra.Location = new System.Drawing.Point(262, 525);
            this.butKiemtra.Name = "butKiemtra";
            this.butKiemtra.Size = new System.Drawing.Size(70, 25);
            this.butKiemtra.TabIndex = 12;
            this.butKiemtra.Text = "Kiểm tra";
            this.butKiemtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKiemtra.Click += new System.EventHandler(this.butKiemtra_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(332, 525);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 13;
            this.butSua.Text = "Thu hồi";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.Cancel;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(402, 525);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 14;
            this.butHuy.Text = "     Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(472, 525);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmKiemtrakhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butKiemtra);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmKiemtrakhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra số liệu của khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKiemtrakhoa_KeyDown);
            this.Load += new System.EventHandler(this.frmKiemtrakhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmKiemtrakhoa_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; stime = "'" + d.f_ngay + "'";
			sql="select * from "+user+".d_dmnhomkho where id="+i_nhom+" order by stt";
			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			nhom.DataSource=d.get_data(sql).Tables[0];

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
            loai.DataSource = d.get_data("select * from " + user + ".d_dmphieu order by stt").Tables[0];
			load_phieu();

            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
			sql+=" order by stt";
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=d.get_data(sql).Tables[0];
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai) load_phieu();		
		}

		private void load_phieu()
		{
            sql = "select * from " + user + ".d_loaiphieu where loai=" + int.Parse(loai.SelectedValue.ToString());
            if (loai.SelectedValue.ToString() == "3") sql += " and (nhom=" + i_nhom + " or id=0)";
            else sql += " and nhom=" + i_nhom;
            sql+=" order by stt";
            phieu.DataSource = d.get_data(sql).Tables[0];
		}

		private bool kiemtra()
		{
			sql="";f1="";f2="";
			if (loai.SelectedIndex==-1)
			{
				loai.Focus();return false;
			}
			if (phieu.SelectedIndex==-1)
			{
				phieu.Focus();return false;
			}
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();return false;
			}
			switch (int.Parse(loai.SelectedValue.ToString()))
			{
				case 1: f1="xxx.d_dutru";break;
				case 2: f1="xxx.d_xtutruc";break;
				case 3: f1="xxx.d_hoantra";break;
				default : f1="xxx.d_haophi";break;
			}
			f2=f1+"ct";f1+="ll";
			return true;
		}
		private void load_grid()
		{
			if (!kiemtra()) return;
			sql="select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.id,b.idduyet,c.stt,";
			if (loai.SelectedValue.ToString()=="4") sql+="b.sophieu as ma,";
			else sql+="b.mabn as ma,";
			sql+="c.mabd,trim(d.ten)||' '||d.hamluong as tenbd,d.dang,c.slyeucau,c.slthuc,c.manguon,a.done ";
            sql += "from xxx.d_duyet a," + f1 + " b," + f2 + " c," + user + ".d_dmbd d ";
			sql+="where a.id=b.idduyet and b.id=c.id and c.mabd=d.id ";
			sql+="and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+") ";
			sql+="and a.loai="+int.Parse(loai.SelectedValue.ToString())+" and a.phieu="+int.Parse(phieu.SelectedValue.ToString())+" and a.makhoa="+int.Parse(makp.SelectedValue.ToString());
			sql+=" order by a.ngay,b.id,c.stt";
			Cursor=Cursors.WaitCursor;
			dt=d.get_thuoc(tu.Text,den.Text,sql).Tables[0];
			dataGrid1.DataSource=dt;
			Cursor=Cursors.Default;
			if (i_load==0) AddGridTableStyle();
			i_load=1;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
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
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 65;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "ID";
			TextCol.Width = 75;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "idduyet";
			TextCol.HeaderText = "ID Duyệt";
			TextCol.Width = 75;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabd";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 45;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 250;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slyeucau";
			TextCol.HeaderText = "Yêu cầu";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slthuc";
			TextCol.HeaderText = "Duyệt";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butKiemtra_Click(object sender, System.EventArgs e)
		{
			load_grid();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			//if (!kiemtra() || dt.Rows.Count==0  || loai.SelectedValue.ToString()=="2") return;
            /*
             * Chuc nang nay chi cho thu hoi nhung phieu duyet bi loi: 
             * Khi duyet nhun trong table d_xuatsdll, d_xuatsdct, d_thucxuat, d_bucstt, d_thucbucstt..: khong co so lieu
             *nhung lai update trong cac table d_dutruct, d_xtutrucct... set slthuc=slyeucau
             * --> Do do chuc nang nay co tac dung la update lai slthuc=0
             * Con nhung phieu hop le: thi so lieu bi mat, va nguoi dung co the thu duyet them 1 lan nua --> lam tien thuoc cua BN tang gap doi
            */
            if (!bThuhoi)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không được phép thu hồi, hãy 'Thu hồi' trong phần Duyệt.")+"\n"+lan.Change_language_MessageText("(Menu: Duyệt cấp theo người bệnh, duyệt bù tủ trực, duyệt hoàn trả...)"));
                return;
            }
            if (!kiemtra() || dt.Rows.Count == 0) return;
            
            //
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý thu hồi ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				Cursor=Cursors.WaitCursor;
				sql="update "+f2+" set slthuc=0 where id in (select a.id from "+f1+" a,xxx.d_duyet b where a.idduyet=b.id ";
                sql+="and b.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ") ";
				sql+="and b.loai="+int.Parse(loai.SelectedValue.ToString())+" and b.phieu="+int.Parse(phieu.SelectedValue.ToString())+" and b.makhoa="+int.Parse(makp.SelectedValue.ToString());
				sql+=")";
				if (loai.SelectedValue.ToString()=="1") sql+=" and tutruc=0";
				d.exe_thuoc(tu.Text,den.Text,sql);
                sql = "delete from xxx.d_ngayduyet where to_date(ngay,'dd/mm/yy') between to_date('" + tu.Text + "','dd/mm/yy') and to_date('" + den.Text + "','dd/mm/yy') ";
                sql += " and loai=" + int.Parse(loai.SelectedValue.ToString()) + " and phieu=" + int.Parse(phieu.SelectedValue.ToString()) + " and makp=" + int.Parse(makp.SelectedValue.ToString());
                sql += " and nhom=" + int.Parse(nhom.SelectedValue.ToString());
                d.exe_thuoc(tu.Text,den.Text,sql);
				Cursor=Cursors.Default;
				load_grid();
			}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            MessageBox.Show(lan.Change_language_MessageText("Bạn không được phép hủy phiếu này, đề nghị vào lại phiếu dự trù (hay xuất tủ trực) để xóa."));
            return;
			if (!kiemtra() || dt.Rows.Count==0 || loai.SelectedValue.ToString()=="2") return;
			if (dt.Select("done=2").Length>1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đã duyệt không được hủy !"),d.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				Cursor=Cursors.WaitCursor;
				sql="delete from "+f2+" where id in (select a.id from "+f1+" a,xxx.d_duyet b where a.idduyet=b.id ";
                sql += "and b.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ") ";
                sql+="and b.loai="+int.Parse(loai.SelectedValue.ToString())+" and b.phieu="+int.Parse(phieu.SelectedValue.ToString())+" and b.makhoa="+int.Parse(makp.SelectedValue.ToString());
				sql+=")";
				d.exe_thuoc(tu.Text,den.Text,sql);
				sql="delete from "+f1+" where idduyet in (select id from xxx.d_duyet where ";
                sql += "and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ") ";
				sql+="and loai="+int.Parse(loai.SelectedValue.ToString())+" and phieu="+int.Parse(phieu.SelectedValue.ToString())+" and makhoa="+int.Parse(makp.SelectedValue.ToString());
				sql+=")";
				d.exe_thuoc(tu.Text,den.Text,sql);
				Cursor=Cursors.Default;
				dataGrid1.DataSource=null;
			}           
		}
        private bool Phieu_daduyet(int loai, int phieu, string sngay, int makp, decimal id_duyet)
        {
            bool bDaduyet = false;
            sql = " select distinct a.id";
            sql += " from xxx.d_xuasdll a, xxx.d_xuatsdct b, xxx.d_dutrull c, xxx.d_dutruct d, xxx.d_duyet e";
            sql += " where a.id=b.id and b.idduyet=c.id c.idduyet=e.id and c.id=d.id ";
            sql += " and e.loai=" + loai + " and a.phieu=" + phieu + " and e.makp=" + makp + " and e.id=" + id_duyet;
            bDaduyet = d.get_data_mmyy(sql, tu.Text, den.Text, true).Tables[0].Rows.Count > 0;
            return bDaduyet;
        }

        private void frmKiemtrakhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && e.Control && e.Shift && e.Alt)
                bThuhoi = !bThuhoi;
        }
	}
}
