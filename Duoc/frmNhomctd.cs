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
	/// Summary description for frmDm.
	/// </summary>
	public class frmNhomctd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stt;
		private decimal l_id;
		private int i_nhom;
        private string user;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox dvt;
        private Button butmap;
        private Button butdmchuan;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNhomctd(AccessData acc,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomctd));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dvt = new System.Windows.Forms.TextBox();
            this.butmap = new System.Windows.Forms.Button();
            this.butdmchuan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -13);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 510);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(463, 532);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(70, 503);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nội dung :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(138, 503);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(534, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(113, 532);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 5;
            this.butMoi.Text = "      &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(183, 532);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "      &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(253, 532);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(323, 532);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(393, 532);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 7;
            this.butHuy.Text = "      &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(-9, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "STT :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(40, 503);
            this.stt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 21);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(655, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Đơn vị :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dvt
            // 
            this.dvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dvt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dvt.Enabled = false;
            this.dvt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvt.Location = new System.Drawing.Point(720, 503);
            this.dvt.Name = "dvt";
            this.dvt.Size = new System.Drawing.Size(64, 21);
            this.dvt.TabIndex = 2;
            this.dvt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // butmap
            // 
            this.butmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butmap.Image = global::Duoc.Properties.Resources.Export;
            this.butmap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butmap.Location = new System.Drawing.Point(648, 532);
            this.butmap.Name = "butmap";
            this.butmap.Size = new System.Drawing.Size(106, 25);
            this.butmap.TabIndex = 43;
            this.butmap.Text = "    &Map danh mục";
            this.butmap.Visible = false;
            this.butmap.Click += new System.EventHandler(this.butmap_Click);
            // 
            // butdmchuan
            // 
            this.butdmchuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butdmchuan.Image = global::Duoc.Properties.Resources.ok;
            this.butdmchuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdmchuan.Location = new System.Drawing.Point(533, 532);
            this.butdmchuan.Name = "butdmchuan";
            this.butdmchuan.Size = new System.Drawing.Size(115, 25);
            this.butdmchuan.TabIndex = 42;
            this.butdmchuan.Text = "    &Danh mục chuẩn";
            this.butdmchuan.Visible = false;
            this.butdmchuan.Click += new System.EventHandler(this.butdmchuan_Click);
            // 
            // frmNhomctd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butmap);
            this.Controls.Add(this.butdmchuan);
            this.Controls.Add(this.dvt);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhomctd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhóm công tác dược";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhomctd_KeyDown);
            this.Load += new System.EventHandler(this.frmNhomctd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNhomctd_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
			load_grid();
			AddGridTableStyle();
			ref_text();
		}

		private void load_grid()
		{
			dt=d.get_data("select * from "+user+".d_nhomctd where nhom="+i_nhom+" order by stt").Tables[0];
			dataGrid1.DataSource=dt;
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
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 615;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dvt";
			TextCol.HeaderText = "Đơn vị";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			stt.Enabled=ena;
			ten.Enabled=ena;
			dvt.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
                stt.Value = decimal.Parse(d.get_data("select max(stt) from " + user + ".d_nhomctd where nhom=" + i_nhom).Tables[0].Rows[0][0].ToString()) + 1;
			}
			catch{stt.Value=1;}
			l_id=0;
			ten.Text="";
			dvt.Text="";
			ena_object(true);
			stt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			l_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,3].ToString());
			ena_object(true);
			stt.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (l_id==0)
			{
				try
				{
                    l_id = decimal.Parse(d.i_Chinhanh_hientai.ToString() + d.get_capid(103).ToString().PadLeft(3,'0'));//decimal.Parse(d.get_data("select max(id) from " + user + ".d_nhomctd").Tables[0].Rows[0][0].ToString()) + 1;
				}
				catch{l_id=1;}
			}
			if (!d.upd_nhomctd(l_id,ten.Text,dvt.Text,i_nhom,int.Parse(stt.Value.ToString())))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin")+" "+this.Text.Trim()+" !",d.Msg);
				return;
			}
			load_grid();
			ena_object(false);
			ref_text();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ref_text();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cho phép hủy ?"),d.Msg);
				return;
			}	
			try
			{
                if (d.get_data("select * from " + user + ".d_dmloai where loai=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString())).Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nội dung đang sử dụng không cho phép hủy !"),d.Msg);
					return;
				}
			}
			catch{}
			if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                d.execute_data("delete from " + user + ".d_nhomctd where id=" + decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 3].ToString()));
				load_grid();
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid1[i,0].ToString());
				ten.Text=dataGrid1[i,1].ToString();
				dvt.Text=dataGrid1[i,2].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmNhomctd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void stt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (l_id==0 && ten.Text!="")
			{
				DataRow r1=d.getrowbyid(dt,"ten='"+ten.Text+"'");
				if (r1!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nội dung đã nhập !"),d.Msg);
					ten.Focus();
				}
			}
		}

        private void butdmchuan_Click(object sender, EventArgs e)
        {
            MapDanhmuc.frmMap f = new MapDanhmuc.frmMap(5);
            f.Danhmucchuan();
        }

        private void butmap_Click(object sender, EventArgs e)
        {
            MapDanhmuc.frmMap f = new MapDanhmuc.frmMap(5);
            f.ShowDialog();
        }
	}
}
