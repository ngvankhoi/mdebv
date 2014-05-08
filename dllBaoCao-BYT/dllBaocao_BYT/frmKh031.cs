using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllBaocao_BYT
{
	/// <summary>
	/// Summary description for frmBieu01.
	/// </summary>
	public class frmKh031 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string s_userid,sql;
		private int i_userid,i_mabv,i_tong,i_col,i_row=0;
		private decimal l_id=0;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox dk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butHuy;
		private bool bPhatsinh;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKh031(AccessData acc,string hoten,int userid,int mabv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_userid=hoten;
			i_userid=userid;
			i_mabv=mabv;
			this.Text+="//"+s_userid;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmKh031(string hoten, int userid, int mabv)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
            s_userid = hoten;
            i_userid = userid;
            i_mabv = mabv;
            this.Text += "//" + s_userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKh031));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ten = new System.Windows.Forms.TextBox();
            this.dk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(40, 4);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(88, 20);
            this.ngay.TabIndex = 1;
            this.ngay.Visible = false;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // cmbNgay
            // 
            this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgay.Location = new System.Drawing.Point(40, 4);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(88, 21);
            this.cmbNgay.TabIndex = 2;
            this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
            this.cmbNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNgay_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(207, 521);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 6;
            this.butMoi.Text = "   &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(269, 521);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 7;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(331, 521);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(393, 521);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(517, 521);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(68, 25);
            this.butKetthuc.TabIndex = 9;
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 505);
            this.dataGrid1.TabIndex = 3;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(130, 4);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(434, 21);
            this.ten.TabIndex = 42;
            // 
            // dk
            // 
            this.dk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dk.Enabled = false;
            this.dk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dk.Location = new System.Drawing.Point(568, 4);
            this.dk.Name = "dk";
            this.dk.Size = new System.Drawing.Size(216, 21);
            this.dk.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(556, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "=";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(455, 521);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 8;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // frmKh03
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dk);
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKh03";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tình hình thu chi ngân sách của ngành y tế địa phương";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKh03_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKh03_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			bPhatsinh=m.bSolieu;
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			load_ngay();
			dt=m.get_data("select * from "+m.user+".khdm_031_dk").Tables[0];
			load_grid(false);
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dataGrid1.Visible=false;
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			dataGrid1.Visible=true;
			dataGrid1.ReadOnly=true;
		}
        #region load data to grid
        void load_grid(bool dm)
        {
            if (dm) ds = m.get_data("Select ma,stt,ten,c01,c02,c03,c04,c05,c06,c07,c08,c09,c10,c11,idloaics from "+m.user+".khdm_031 order by sttt ");
            else
                load_data();
            dataGrid1.DataSource = ds.Tables[0];
        }
        #endregion
       #region load data
        void load_data()
        {
            if (bPhatsinh)
            {
                sql = "select a.*, b.stt,b.ten,b.ma as ma,b.idloaics from "+m.user+".khbieu_031 a, "+m.user+".khdm_031 b where a.ma=b.ma and a.id=" + l_id + " order by b.sttt";
                ds = m.get_data(sql);
            }
            else
                load_value(false);
        }
        #endregion
        #region load value
        void load_value(bool load)
        {
            ds = m.get_data("Select ma,stt,ten,c01,c02,c03,c04,c05,c06,c07,c08,c09,c10,c11,idloaics from "+m.user+".khdm_031 order by sttt");
            DataRow[] dr;
            foreach (DataRow r in m.get_data("Select * from "+m.user+".khbieu_031 where id=" + l_id).Tables[0].Rows)
            {
                dr = ds.Tables[0].Select("ma=" + r["ma"].ToString());
                if (dr.Length != 0)
                {
                    dr[0]["c01"] = r["c01"].ToString();
                    dr[0]["c02"] = r["c02"].ToString();
                    dr[0]["c03"] = r["c03"].ToString();
                    dr[0]["c04"] = r["c04"].ToString();
                    dr[0]["c05"] = r["c05"].ToString();
                    dr[0]["c06"] = r["c06"].ToString();
                    dr[0]["c07"] = r["c07"].ToString();
                    dr[0]["c08"] = r["c08"].ToString();
                    dr[0]["c09"] = r["c09"].ToString();
                    dr[0]["c10"] = r["c10"].ToString();
                    dr[0]["c11"] = r["c11"].ToString();
                }
            }
            if (load) dataGrid1.DataSource = ds.Tables[0];
        }
        #endregion
		private void load_ngay()
		{
			cmbNgay.DataSource=m.get_data("select ID,to_char(ngay,'dd/mm/yyyy') as NGAY from "+m.user+".khbieu_031 group by id,ngay order by ngay").Tables[0];
		}

		private void ena_object(bool ena)
		{
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butKetthuc.Enabled=!ena;
			butHuy.Enabled=!ena;
			dataGrid1.ReadOnly=!ena;
			ngay.Visible=ena;
			cmbNgay.Visible=!ena;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_id=m.get_capid(27);
			load_grid(true);
			ena_object(true);
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.Items.Count==0) return;
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				int dd=int.Parse(cmbNgay.Text.Substring(0,2));
				int mm=int.Parse(cmbNgay.Text.Substring(3,2));
				int yyyy=int.Parse(cmbNgay.Text.Substring(6,4));
				ngay.Value=new DateTime(yyyy,mm,dd,0,0,0);
				load_value(true);
				ena_object(true);
				dataGrid1.Focus();
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.HasChanges()) tongcong();
				if (ds.HasChanges())
				{
					m.execute_data("delete from "+m.user+".khbieu_031 where id="+l_id);
                    string exp = "c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11 >0";
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    Int16 cRec = Convert.ToInt16(dr.Length);
                    for (int i = 0; i < cRec; i++)
                    {
                        m.upd_kh031(l_id, int.Parse(dr[i]["ma"].ToString()), ngay.Text, int.Parse(dr[i]["C01"].ToString()), int.Parse(dr[i]["C02"].ToString()),
                            int.Parse(dr[i]["C03"].ToString()), int.Parse(dr[i]["C04"].ToString()), int.Parse(dr[i]["C05"].ToString()), int.Parse(dr[i]["C06"].ToString()),
                            int.Parse(dr[i]["C07"].ToString()), int.Parse(dr[i]["C08"].ToString()), int.Parse(dr[i]["C09"].ToString()), int.Parse(dr[i]["C10"].ToString()), int.Parse(dr[i]["C11"].ToString()), i_userid);
                    }
				}
				ena_object(false);
				decimal id=l_id;
				load_ngay();
				cmbNgay.SelectedValue=id.ToString();
				l_id=id;
			}
			catch{}
			load_grid(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
			}
			catch{l_id=0;}
			load_grid(false);
			butMoi.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.Items.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				m.execute_data("delete from "+m.user+".khbieu_031 where id="+l_id);
				load_ngay();
				load_grid(false);
			}
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				load_grid(false);
			}
			catch{l_id=0;}
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "ma";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "stt";
            TextCol1.HeaderText = "STT";
            TextCol1.Width = 24;
            TextCol1.ReadOnly = true;
            TextCol1.Alignment = HorizontalAlignment.Center;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên cơ sở y tế";
            TextCol1.ReadOnly = true;
            TextCol1.Alignment = HorizontalAlignment.Left;
            TextCol1.Width = 150;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "c01";
            TextCol1.HeaderText = "C03";
            TextCol1.Width = 60;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "c02";
            TextCol1.HeaderText = "C04";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "c03";
            TextCol1.HeaderText = "C05";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "c04";
            TextCol1.HeaderText = "C06";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 7);
            TextCol1.MappingName = "c05";
            TextCol1.HeaderText = "C07";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            TextCol1.MappingName = "c06";
            TextCol1.HeaderText = "C08";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 9);
            TextCol1.MappingName = "c07";
            TextCol1.HeaderText = "C09";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 10);
            TextCol1.MappingName = "c08";
            TextCol1.HeaderText = "C10";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 11);
            TextCol1.MappingName = "c09";
            TextCol1.HeaderText = "C11";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 12);
            TextCol1.MappingName = "c10";
            TextCol1.HeaderText = "C12";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 13);
            TextCol1.MappingName = "c11";
            TextCol1.HeaderText = "C13";
            TextCol1.Width = 50;
            TextCol1.Format = "## ### ###";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
		}

        #region delegate
        public Color MyGetColorRowCol(int row, int col)
        {
            string s = "ABCDEFGH";
            Color c = Color.Black;
            if (s.IndexOf(this.dataGrid1[row, 1].ToString().Trim()) != -1)
            {
                c = Color.Red;
                i_tong = row;
            }
            if (row == i_tong) c = Color.Red;
            return c;
        }
        #endregion
		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
            i_col = dataGrid1.CurrentCell.ColumnNumber;
            DataRow r = m.getrowbyid(dt, "ma='C" + i_col.ToString().PadLeft(2, '0') + "'");
            if (r != null)
            {
                ten.Text = r["ten"].ToString();
                dk.Text = r["dk"].ToString();
            }
            else
            {
                ten.Text = "";
                dk.Text = "";
            }
            if (butMoi.Enabled) return;
            decimal l_tong = 0;
            i_col = dataGrid1.CurrentCell.ColumnNumber;
            string exp = "", stt = "";
            int index = 0;
            try
            {
                if (i_col < 3) return;
                index = int.Parse(ds.Tables[0].Rows[i_row]["idloaics"].ToString());
                DataRow[] dr;
                switch (index)
                {
                    case 1:// thuoc linh vuc y te quan ly
                        l_tong = 0;
                        stt = "B";
                        exp = "idloaics=1";
                        dr = ds.Tables[0].Select(exp);
                        if (dr.Length != 0)
                        {
                            for (int i = 0; i < dr.Length; i++)
                            {
                                try
                                {
                                    l_tong += decimal.Parse(dr[i][i_col].ToString());
                                }
                                catch { }
                            }
                            m.updrec_01(ds.Tables[0], stt, i_col, l_tong);
                        }
                        break;
                    case 2:
                        l_tong = 0;
                        stt = "C";
                        exp = "idloaics=2";
                        dr = ds.Tables[0].Select(exp);
                        if (dr.Length != 0)
                        {
                            for (int i = 0; i < dr.Length; i++)
                            {
                                try
                                {
                                    l_tong += decimal.Parse(dr[i][i_col].ToString());
                                }
                                catch { }
                            }
                            m.updrec_01(ds.Tables[0], stt, i_col, l_tong);
                        }
                        break;
                    case 3:
                        l_tong = 0;
                        stt = "D";
                        exp = "idloaics=3";
                        dr = ds.Tables[0].Select(exp);
                        if (dr.Length != 0)
                        {
                            for (int i = 0; i < dr.Length; i++)
                            {
                                try
                                {
                                    l_tong += decimal.Parse(dr[i][i_col].ToString());
                                }
                                catch { }
                            }
                            m.updrec_01(ds.Tables[0], stt, i_col, l_tong);
                        }
                        break;
                    default: break;
                }
                if (i_col >= 3 && i_col <= 13 && dataGrid1[i_row, i_col].ToString() != "")
                {
                    kiemtranhap(i_row, i_col);
                }
                i_row = dataGrid1.CurrentRowIndex;
            }
            catch { }
		}
        void kiemtranhap(int r, int c)
        {
            if (decimal.Parse(dataGrid1[r, 3].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C01>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 4].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C02>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 5].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C03>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 6].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C04>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 7].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C05>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 8].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C06>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 9].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C07>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 10].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C08>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 11].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C09>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 12].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C10>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }
            if (decimal.Parse(dataGrid1[r, 13].ToString()) < 0)
            {
                MessageBox.Show("Không hợp lệ ! C11>=0", LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid1[r, c] = 0;
            }

        }
		private void cmbNgay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

        void tongcong()
        {
            decimal l_tong = 0;
            DataRow[] dr;
            string exp = "", stt = "";
            exp = "idloaics<0";
            for (int k = 3; k < ds.Tables[0].Columns.Count - 1; k++)
            {
                exp = "idloaics=1";
                stt = "B";
                dr = ds.Tables[0].Select(exp);
                if (dr.Length != 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        try
                        {
                            l_tong += decimal.Parse(dr[i][k].ToString());
                        }
                        catch { }
                    }
                    m.updrec_01(ds.Tables[0], stt, k, l_tong);
                    l_tong = 0;
                }
                exp = "idloaics=2";
                stt = "C";
                dr = ds.Tables[0].Select(exp);
                if (dr.Length != 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        try
                        {
                            l_tong += decimal.Parse(dr[i][k].ToString());
                        }
                        catch { }
                    }
                    m.updrec_01(ds.Tables[0], stt, k, l_tong);
                    l_tong = 0;
                }
                exp = "idloaics=3";
                stt = "D";
                dr = ds.Tables[0].Select(exp);
                if (dr.Length != 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        try
                        {
                            l_tong += decimal.Parse(dr[i][k].ToString());
                        }
                        catch { }
                    }
                    m.updrec_01(ds.Tables[0], stt, k, l_tong);
                    l_tong = 0;
                }
            }
        }
	}
}
