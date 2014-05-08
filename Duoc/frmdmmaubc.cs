using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Duoc
{
	public class frmdmmaubc : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //lan.Read_Language_to_Xml(this.Name.ToString(),this);
		//lan.Changelanguage_to_English(this.Name.ToString(),this);
        
        private LibDuoc.AccessData m;
		private DataSet dsxml=new DataSet();
		private DataTable dtct=new DataTable();
        private string s_maloai = "", sql="";
        private decimal l_id = 0;
        private int i_loai=0,i_tonghop=0;
        private bool b_admin = false;
        //
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboLoai;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox ma;
        private System.Windows.Forms.TextBox ten;
        private TextBox txttenloai;
		private System.ComponentModel.Container components = null;

        public frmdmmaubc(LibDuoc.AccessData acc, int loai, int tonghop, string maloai)
		{
			InitializeComponent();
           // Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        lan.Read_Language_to_Xml(this.Name.ToString(),this);
		lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc;
            i_loai = loai;
            i_tonghop = tonghop;
            s_maloai = maloai;
		}
        public frmdmmaubc(LibDuoc.AccessData acc)
        {
            InitializeComponent();
            m = acc;            
        }
        public frmdmmaubc(LibDuoc.AccessData acc,string maloai)
        {
            InitializeComponent();
            m = acc;
            s_maloai = maloai;
        }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdmmaubc));
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txttenloai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(383, 297);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(73, 25);
            this.butHuy.TabIndex = 9;
            this.butHuy.Text = "          &Hủy";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(310, 297);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(73, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(237, 297);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(73, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            this.butLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(164, 297);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(73, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "         &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            this.butSua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(91, 297);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(73, 25);
            this.butMoi.TabIndex = 5;
            this.butMoi.Text = "          &Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            this.butMoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(456, 297);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(0, 25);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(575, 205);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(54, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên file Report :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.Color.White;
            this.ma.Location = new System.Drawing.Point(151, 263);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(424, 20);
            this.ma.TabIndex = 4;
            this.ma.TextChanged += new System.EventHandler(this.ma_TextChanged);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.Color.White;
            this.ten.Location = new System.Drawing.Point(151, 240);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(424, 20);
            this.ten.TabIndex = 3;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(100, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên mẫu :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-27, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Loại báo cáo :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLoai
            // 
            this.cboLoai.BackColor = System.Drawing.Color.White;
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Location = new System.Drawing.Point(78, 2);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(497, 21);
            this.cboLoai.TabIndex = 0;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);
            this.cboLoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // stt
            // 
            this.stt.BackColor = System.Drawing.Color.White;
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(54, 240);
            this.stt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 20);
            this.stt.TabIndex = 2;
            this.stt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số thứ tự :";
            // 
            // txttenloai
            // 
            this.txttenloai.BackColor = System.Drawing.Color.White;
            this.txttenloai.Location = new System.Drawing.Point(78, 3);
            this.txttenloai.Name = "txttenloai";
            this.txttenloai.Size = new System.Drawing.Size(497, 20);
            this.txttenloai.TabIndex = 1;
            this.txttenloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenloai_KeyDown);
            // 
            // frmdmmaubc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(581, 333);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboLoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttenloai);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmdmmaubc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo mẫu báo cáo BHYT";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmdmmaubc_KeyDown);
            this.Load += new System.EventHandler(this.frmMaubaocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        public string s_title
        {
            set
            {
                this.Text = value;
            }
        }
		private void frmMaubaocao_Load(object sender, System.EventArgs e)
		{
            Load_LoaiBC(s_maloai);
            if (cboLoai.Items.Count > 0)
            {
                cboLoai.SelectedIndex = 0;
                loadgrid(cboLoai.SelectedValue.ToString());
            }
            else
            {
                loadgrid(s_maloai);
            }
			AddGridTableStyle();
			ena_object(false);
		}
		private void loadgrid(string maloai)
		{
			try
			{
                sql = " Select * from " + m.user + ".bhyt_maubaocao ";
                if (maloai.Trim() != "") sql += " where maloai='" + maloai + "'";
                dsxml = m.get_data(sql);
                dtct = dsxml.Tables[0].Copy();
				dataGrid1.DataSource=dtct;
			}
			catch
			{}
		}
		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsxml.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.Gainsboro;
			ts.HeaderForeColor = Color.Blue;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();//0
			TextCol.MappingName = "id";
			TextCol.HeaderText = "id";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//1
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//2
			TextCol.MappingName = "ten";
            TextCol.HeaderText = "Mẫu";
			TextCol.Width =350;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//3
			TextCol.MappingName = "filereport";
			TextCol.HeaderText = "Report";
			TextCol.Width =dataGrid1.Width-115;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            if (b_admin == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được quyền thêm danh mục này, liên hệ với người quản trị."));
                return;
            }
            l_id = 0;
			ena_object(true);
			stt.Value=decimal.Parse(dtct.Rows.Count.ToString())+1;
			cleartext();
			stt.Focus();
		}
		private void cleartext()
		{
			ma.Text="";
			ten.Text="";			
            //txttenloai.Text = "";
		}
		private void ena_object(bool ena)
		{
            stt.Enabled = ena;
            dataGrid1.Enabled=!ena;
			butMoi.Enabled=!ena;
            butSua.Enabled = !ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
			cboLoai.Enabled=!ena;
			
            txttenloai.Enabled = (cboLoai.Items.Count<=0)? ena:false;
            txttenloai.Visible = (cboLoai.Items.Count <= 0) ? ena : false;
            cboLoai.Visible = (cboLoai.Items.Count > 0) ? true : !ena;
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
            if (b_admin == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được quyền sửa danh mục này, liên hệ với người quản trị."));
                return;
            }
            if (l_id > 0)
            {
                ena_object(true);
                ma.Focus();
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn mẫu báo cáo cần sửa."));
            }
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			
            if(l_id <=0) l_id = m.get_id_bhyt_maubaocao();

            if (cboLoai.Items.Count > 0)
            {
                if (txttenloai.Text.Trim() == "")
                {
                    txttenloai.Text = this.Text.Trim();                    
                }
                if (ten.Text.Trim() == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập mẫu báo cáo"));
                    ten.Focus();
                    return;
                }
            }
            else txttenloai.Text = this.Text.Trim();
            if (ma.Text.Trim ()== "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập tên file report"));
                ma.Focus();
                return;
            }

            if(s_maloai=="")s_maloai=cboLoai.SelectedValue.ToString();
            m.upd_bhyt_mabaocao(l_id,s_maloai,txttenloai.Text,ten.Text,ma.Text,1,int.Parse(stt.Value.ToString()),i_loai,i_tonghop);
            //
            loadgrid(s_maloai);
			dataGrid1.Refresh();
            ena_object(false);
            try
            {
                if (cboLoai.Items.Count <= 0) Load_LoaiBC(s_maloai);
                butMoi.Focus();
            }
            catch { }
		}
		private void upd_doituong(DataTable dt)
		{
			DataRow nr=m.getrowbyid(dt,"id="+int.Parse(stt.Value.ToString())+" and loai="+cboLoai.SelectedIndex);
			if(nr==null)
			{
				DataRow r= dt.NewRow();
				r["id"]=int.Parse(stt.Value.ToString());
				r["ma"]=ma.Text.Trim();
				r["ten"]=ten.Text.Trim();
				r["loai"]=cboLoai.SelectedIndex;				
				dt.Rows.Add(r);
			}
			else
			{	
				nr["id"]=int.Parse(stt.Value.ToString());
				nr["ma"]=ma.Text.Trim();
				nr["ten"]=ten.Text.Trim();
				nr["loai"]=cboLoai.SelectedIndex;				
			}
			dt.AcceptChanges();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			Reft_text();
		}
		private void Reft_text()
		{
			try
			{
                l_id= decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
				stt.Value=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,1].ToString());
				ten.Text=dataGrid1[dataGrid1.CurrentCell.RowNumber,2].ToString();//mau bao cao
				ma.Text=dataGrid1[dataGrid1.CurrentCell.RowNumber,3].ToString();//file report
				
			}
			catch{}
		}
		private void butHuy_Click(object sender, System.EventArgs e)
		{
            if (b_admin == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được quyền hủy danh mục này, liên hệ với người quản trị."));
                return;
            }
			if(l_id<=0) return;
			if(MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy?"),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
			{
                sql = "delete from " + m.user + ".bhyt_maubaocao where id=" + l_id;
                m.execute_data(sql);
                loadgrid(s_maloai);
				dataGrid1.Refresh();
			}
			ena_object(false);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            //dsxml.WriteXml(@"..\..\..\xml\maubaocao_bhyt.xml",XmlWriteMode.WriteSchema);
			this.Close();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Reft_text();
			}
			catch{}
		}

		private void cboLoai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dtct.Clear();
            if (cboLoai.SelectedIndex >= 0)
            {
                txttenloai.Text = cboLoai.Text;
                //s_maloai = cboLoai.SelectedValue.ToString();
                loadgrid(cboLoai.SelectedValue.ToString());
            }
            else
                loadgrid("");
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
            //else if(e.KeyCode==Keys.A&&e.Control&&e.Shift&&e.Alt)
            //{				
            //    butSua.Enabled=!butSua.Enabled;
            //}
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ma_TextChanged(object sender, EventArgs e)
        {

        }

        private void Load_LoaiBC(string maloai)
        {
            sql = " select distinct maloai, tenloai from " + m.user + ".bhyt_maubaocao";
            if (maloai.Trim() != "") sql += " where maloai='" + maloai + "'";
            cboLoai.DataSource = m.get_data(sql).Tables[0];
            cboLoai.DisplayMember = "TENLOAI";
            cboLoai.ValueMember= "MALOAI";
        }

        private void txttenloai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}"); 
            }
        }

        private void frmdmmaubc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10) butKetthuc_Click(sender, e);
            else if (e.KeyCode == Keys.A && e.Alt && e.Shift && e.Control)
            {
                b_admin = !b_admin;
            }
        }
	}
}
