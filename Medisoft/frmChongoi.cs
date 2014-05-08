using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for rptThekho.
	/// </summary>
	public class frmChongoi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private decimal l_id;
		public DataTable dt=new DataTable();
		private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lmabs;
        private System.Windows.Forms.Button butTiep;
		private string user,sql;
		private int i_nhom=5,i_loai=-1;
        private TextBox tim;
        private CheckBox chkPTTT;
        private bool bGoiPTTT = false;
        private string m_MaPTTT = "", m_MaMauPTTT = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChongoi(LibMedi.AccessData acc,int loai,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_loai = loai; i_nhom = nhom; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChongoi));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.lmabs = new System.Windows.Forms.ComboBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.chkPTTT = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(290, 348);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(5, 8);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(623, 334);
            this.dataGrid2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmabs
            // 
            this.lmabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lmabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmabs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmabs.Location = new System.Drawing.Point(42, 2);
            this.lmabs.Name = "lmabs";
            this.lmabs.Size = new System.Drawing.Size(389, 21);
            this.lmabs.TabIndex = 0;
            this.lmabs.SelectedIndexChanged += new System.EventHandler(this.lmabs_SelectedIndexChanged);
            this.lmabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmabs_KeyDown);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(220, 348);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 13;
            this.butTiep.Text = "     Chọn";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(543, 2);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(87, 21);
            this.tim.TabIndex = 277;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // chkPTTT
            // 
            this.chkPTTT.AutoSize = true;
            this.chkPTTT.Location = new System.Drawing.Point(435, 4);
            this.chkPTTT.Name = "chkPTTT";
            this.chkPTTT.Size = new System.Drawing.Size(102, 17);
            this.chkPTTT.TabIndex = 278;
            this.chkPTTT.Text = "Phẫu - thủ thuật";
            this.chkPTTT.UseVisualStyleBackColor = true;
            this.chkPTTT.Click += new System.EventHandler(this.chkPTTT_Click);
            // 
            // frmChongoi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(635, 382);
            this.Controls.Add(this.chkPTTT);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.lmabs);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butKetthuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChongoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn gói";
            this.Load += new System.EventHandler(this.frmChongoi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChongoi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChongoi_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            if (bGoiPTTT)
            {
                chkPTTT.Checked = true;
                chkPTTT.Enabled = false;
            }
            //lmabs.DisplayMember="GHICHU";
            //lmabs.ValueMember="ID";
			load_head();
			load_chitiet();
			AddGridTableStyle1();
		}

		private void load_head()
        {
            DataTable dt_temp = new DataTable();
            if (bGoiPTTT == true)
            {
                sql = "select distinct a.ma, b.ten, b.mapt, a.ma as id, b.ten as ghichu from medibv.pttt_thuoc a inner join medibv.pttt_mau b on a.ma=b.ma ";
                sql += " where 1=1 ";
                if (m_MaPTTT != "") sql += " and (b.mapt='" + m_MaPTTT + "' or b.ma='" + m_MaPTTT + "')";
                sql += " order by b.ten ";
                lmabs.DataSource = null;
                lmabs.DisplayMember = "TEN";
                lmabs.ValueMember = "MA";
                dt_temp = m.get_data(sql).Tables[0];
                if (dt_temp.Rows.Count == 0)
                {
                    bGoiPTTT = false;
                    chkPTTT.Checked = false;
                }
            }
            if (bGoiPTTT == false || (bGoiPTTT ==true && dt_temp.Rows.Count ==0))
            {
                sql = "select * from " + user + ".d_theodonll where mabs='' and ghichu<>'' and stt=" + i_loai + " order by ghichu";
                lmabs.DisplayMember = "GHICHU";
                lmabs.ValueMember = "ID";
            }
			lmabs.DataSource=m.get_data(sql).Tables[0];
            try
            {
                if (bGoiPTTT == false)
                {
                    l_id = (lmabs.SelectedIndex != -1) ? decimal.Parse(lmabs.SelectedValue.ToString()) : 0;
                }
                else
                {
                    l_id = (lmabs.SelectedIndex != -1) ? decimal.Parse(lmabs.SelectedValue.ToString()) : 0;
                    m_MaMauPTTT = (lmabs.SelectedIndex != -1) ? lmabs.SelectedValue.ToString() : m_MaMauPTTT;
                }
            }
            catch
            {
                l_id = 0;
            }
		}
	

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            dt.Clear();
			m.close();this.Close();
		}

		private void load_chitiet()
		{
            if (bGoiPTTT)
            {
                sql = "select b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,";
                if (i_loai == -1) sql += "a.tenhc,";
                else sql += "c.ten as tenhc,";
                sql += "b.soluong,' ' as cachdung,a.mahc, b.madoituong ";
                sql += " from " + user + ".d_dmbd a," + user + ".pttt_thuoc b," + user + ".d_dmhang c ";
                sql += " where a.id=b.mabd and a.mahang=c.id ";
                if (m_MaMauPTTT != "") sql += " and b.ma='" + m_MaMauPTTT + "'";
                dt = m.get_data(sql).Tables[0];
            }
            if (bGoiPTTT == false || (bGoiPTTT && dt.Rows.Count == 0))
            {
                sql = "select b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,";
                if (i_loai == -1) sql += "a.tenhc,";
                else sql += "c.ten as tenhc,";
                sql += "b.soluong,b.cachdung,a.mahc,b.madoituong";
                sql += " from " + user + ".d_dmbd a," + user + ".d_theodonct b," + user + ".d_dmhang c ";
                sql += " where a.id=b.mabd and a.mahang=c.id and b.id=" + l_id;            
            }
			dt=m.get_data(sql).Tables[0];
			dataGrid2.DataSource=dt;
		}

		private void AddGridTableStyle1()
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
			TextCol.MappingName = "mabd";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 250;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = (i_loai==-2)?"Hãng":"Hoạt chất";
			TextCol.Width = (i_loai==-2)?185:0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = (i_loai==-1)?"Cách dùng":"";
			TextCol.Width = (i_loai==-1)?185:0;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void lmabs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lmabs)
			{
                if (bGoiPTTT == false)
                {
                    l_id = (lmabs.SelectedIndex != -1) ? decimal.Parse(lmabs.SelectedValue.ToString()) : 0;
                }
                else
                {
                    l_id = 0;
                    m_MaMauPTTT = (lmabs.SelectedIndex != -1) ? lmabs.SelectedValue.ToString() : m_MaMauPTTT;
                }
				load_chitiet();
			}
		}

		private void lmabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
            m.close();this.Close();
		}

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[lmabs.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "ghichu like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
                try
                {
                    l_id = (lmabs.SelectedIndex != -1) ? decimal.Parse(lmabs.SelectedValue.ToString()) : 0;
                }
                catch { l_id = 0;}                
                load_chitiet();
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void frmChongoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) butTiep_Click(sender, e);
        }

        private void chkPTTT_Click(object sender, EventArgs e)
        {            
            bGoiPTTT = chkPTTT.Checked;
            load_head();
        }

        public bool GoiPTTT
        {
            set
            {
                bGoiPTTT = value;
            }
        }
        public string Ma_PTTT
        {
            set
            {
                m_MaPTTT = value;
            }
        }

        public string Ma_Mau_PTTT
        {
            set
            {
                m_MaMauPTTT = value;
            }
        }
	}
}
