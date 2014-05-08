using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDmthuoc.
	/// </summary>
	public class frmDmcachdung : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private DataTable dt=new DataTable();
		private LibMedi.AccessData m;
        private string user;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.DataGrid dataGrid1;
        private TextBox stt;
        private TextBox cachdung;
        private CheckBox chkhide;
        private Label label1;
        private Label label2;
        private Button butThem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmcachdung(LibMedi.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmcachdung));
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.stt = new System.Windows.Forms.TextBox();
            this.cachdung = new System.Windows.Forms.TextBox();
            this.chkhide = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(226, 392);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 5;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(296, 392);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.Location = new System.Drawing.Point(156, 392);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(424, 370);
            this.dataGrid1.TabIndex = 25;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(33, 367);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(33, 20);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // cachdung
            // 
            this.cachdung.Location = new System.Drawing.Point(125, 367);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(273, 20);
            this.cachdung.TabIndex = 1;
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // chkhide
            // 
            this.chkhide.AutoSize = true;
            this.chkhide.Location = new System.Drawing.Point(399, 370);
            this.chkhide.Name = "chkhide";
            this.chkhide.Size = new System.Drawing.Size(39, 17);
            this.chkhide.TabIndex = 2;
            this.chkhide.Text = "Ẩn";
            this.chkhide.UseVisualStyleBackColor = true;
            this.chkhide.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "STT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cách dùng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butThem
            // 
            this.butThem.Location = new System.Drawing.Point(86, 392);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 3;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // frmDmcachdung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 429);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkhide);
            this.Controls.Add(this.cachdung);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butKetthuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmcachdung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục cách dùng";
            this.Load += new System.EventHandler(this.frmDmcachdung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmcachdung_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void load_grid()
		{
            dt = m.get_data("select ten, stt, viettat, stt as stt_cu from " + user + ".d_dmcachdung order by ten").Tables[0];
			dataGrid1.DataSource=dt;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
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
			TextCol.Width = 40;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 350;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					d.del_dmcachdung(dataGrid1[i,1].ToString());
					load_grid();
				}
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			dt.AcceptChanges();
            int i_stt = 0;
            if (cachdung.Text != "")
            {
                try
                {
                    i_stt = stt.Text == "" ? 0 : int.Parse(stt.Text);
                }
                catch{}
                d.upd_dmcachdung(cachdung.Text,i_stt);
                clear_obj();
            }
            foreach (DataRow r in dt.Select("stt<>stt_cu", "")) 
				d.upd_dmcachdung(r["ten"].ToString(),int.Parse(r["stt"].ToString()));
			//butKetthuc.Focus();
            load_grid();
            enable_obj(false);
            try
            {
                butThem.Focus();
            }
            catch { }
		}

        private void butThem_Click(object sender, EventArgs e)
        {
            clear_obj();
            enable_obj(true);
            stt.Focus();
        }

        private void enable_obj(bool ena)
        {
            stt.Enabled = ena;
            cachdung.Enabled = ena;
            chkhide.Enabled = ena;

            butThem.Enabled = !ena;
            butLuu.Enabled = ena;
            butHuy.Enabled = !ena;


        }
        private void clear_obj()
        {
            cachdung.Text = "";
            stt.Text = "0";
        }

        private void stt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
	}
}
