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
	/// Summary description for frmTiensusk.
	/// </summary>
	public class frmTiensusk : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string m_ngay,user,xxx,sql;
		private decimal m_id;
        private Language lan=new Language();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.ComboBox cachthucde;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox du;
		private System.Windows.Forms.CheckBox thieu;
		private System.Windows.Forms.CheckBox say;
		private System.Windows.Forms.CheckBox hut;
		private System.Windows.Forms.CheckBox nao;
		private System.Windows.Forms.CheckBox covac;
		private System.Windows.Forms.CheckBox ngoai;
		private System.Windows.Forms.CheckBox trung;
		private System.Windows.Forms.CheckBox chet;
		private System.Windows.Forms.CheckBox song;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox taibien;
		private MaskedTextBox.MaskedTextBox cannang;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.TextBox nam;
		private System.Windows.Forms.Label label4;
		private AccessData m;

		public frmTiensusk(AccessData acc,decimal _id,string _ngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;m_id=_id;m_ngay=_ngay;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiensusk));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cachthucde = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.du = new System.Windows.Forms.CheckBox();
            this.thieu = new System.Windows.Forms.CheckBox();
            this.say = new System.Windows.Forms.CheckBox();
            this.hut = new System.Windows.Forms.CheckBox();
            this.nao = new System.Windows.Forms.CheckBox();
            this.covac = new System.Windows.Forms.CheckBox();
            this.ngoai = new System.Windows.Forms.CheckBox();
            this.trung = new System.Windows.Forms.CheckBox();
            this.chet = new System.Windows.Forms.CheckBox();
            this.song = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.taibien = new System.Windows.Forms.CheckBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.nam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
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
            this.dataGrid1.Size = new System.Drawing.Size(760, 184);
            this.dataGrid1.TabIndex = 200;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butThem
            // 
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(132, 238);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(75, 28);
            this.butThem.TabIndex = 21;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(207, 238);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(75, 28);
            this.butSua.TabIndex = 22;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(282, 238);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(75, 28);
            this.butLuu.TabIndex = 19;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(357, 238);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(75, 28);
            this.butBoqua.TabIndex = 20;
            this.butBoqua.Text = "     &Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(432, 238);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(75, 28);
            this.butHuy.TabIndex = 23;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(507, 238);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 28);
            this.butKetthuc.TabIndex = 24;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cachthucde
            // 
            this.cachthucde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachthucde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cachthucde.Enabled = false;
            this.cachthucde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachthucde.Location = new System.Drawing.Point(547, 205);
            this.cachthucde.Name = "cachthucde";
            this.cachthucde.Size = new System.Drawing.Size(152, 21);
            this.cachthucde.TabIndex = 17;
            this.cachthucde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachthucde_KeyDown);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(443, 208);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 16);
            this.label19.TabIndex = 16;
            this.label19.Text = "Phương pháp đẻ :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lần có thai :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(128, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // du
            // 
            this.du.Enabled = false;
            this.du.Location = new System.Drawing.Point(224, 184);
            this.du.Name = "du";
            this.du.Size = new System.Drawing.Size(88, 16);
            this.du.TabIndex = 4;
            this.du.Text = "Đẻ đủ tháng";
            this.du.CheckedChanged += new System.EventHandler(this.du_CheckedChanged);
            this.du.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // thieu
            // 
            this.thieu.Enabled = false;
            this.thieu.Location = new System.Drawing.Point(312, 184);
            this.thieu.Name = "thieu";
            this.thieu.Size = new System.Drawing.Size(104, 16);
            this.thieu.TabIndex = 5;
            this.thieu.Text = "Đẻ thiếu tháng";
            this.thieu.CheckedChanged += new System.EventHandler(this.thieu_CheckedChanged);
            this.thieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // say
            // 
            this.say.Enabled = false;
            this.say.Location = new System.Drawing.Point(408, 184);
            this.say.Name = "say";
            this.say.Size = new System.Drawing.Size(56, 16);
            this.say.TabIndex = 6;
            this.say.Text = "Sẩy";
            this.say.CheckedChanged += new System.EventHandler(this.say_CheckedChanged);
            this.say.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // hut
            // 
            this.hut.Enabled = false;
            this.hut.Location = new System.Drawing.Point(456, 184);
            this.hut.Name = "hut";
            this.hut.Size = new System.Drawing.Size(56, 16);
            this.hut.TabIndex = 7;
            this.hut.Text = "Hút";
            this.hut.CheckedChanged += new System.EventHandler(this.hut_CheckedChanged);
            this.hut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // nao
            // 
            this.nao.Enabled = false;
            this.nao.Location = new System.Drawing.Point(504, 184);
            this.nao.Name = "nao";
            this.nao.Size = new System.Drawing.Size(56, 16);
            this.nao.TabIndex = 8;
            this.nao.Text = "Nạo";
            this.nao.CheckedChanged += new System.EventHandler(this.nao_CheckedChanged);
            this.nao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // covac
            // 
            this.covac.Enabled = false;
            this.covac.Location = new System.Drawing.Point(560, 184);
            this.covac.Name = "covac";
            this.covac.Size = new System.Drawing.Size(56, 16);
            this.covac.TabIndex = 9;
            this.covac.Text = "Covac";
            this.covac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // ngoai
            // 
            this.ngoai.Enabled = false;
            this.ngoai.Location = new System.Drawing.Point(632, 184);
            this.ngoai.Name = "ngoai";
            this.ngoai.Size = new System.Drawing.Size(112, 16);
            this.ngoai.TabIndex = 10;
            this.ngoai.Text = "Chửa ngoài TC";
            this.ngoai.CheckedChanged += new System.EventHandler(this.ngoai_CheckedChanged);
            this.ngoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // trung
            // 
            this.trung.Enabled = false;
            this.trung.Location = new System.Drawing.Point(11, 208);
            this.trung.Name = "trung";
            this.trung.Size = new System.Drawing.Size(88, 16);
            this.trung.TabIndex = 11;
            this.trung.Text = "Chửa trứng";
            this.trung.CheckedChanged += new System.EventHandler(this.trung_CheckedChanged);
            this.trung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // chet
            // 
            this.chet.Enabled = false;
            this.chet.Location = new System.Drawing.Point(91, 208);
            this.chet.Name = "chet";
            this.chet.Size = new System.Drawing.Size(88, 16);
            this.chet.TabIndex = 12;
            this.chet.Text = "Thai chết lưu";
            this.chet.CheckedChanged += new System.EventHandler(this.chet_CheckedChanged);
            this.chet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // song
            // 
            this.song.Enabled = false;
            this.song.Location = new System.Drawing.Point(179, 208);
            this.song.Name = "song";
            this.song.Size = new System.Drawing.Size(96, 16);
            this.song.TabIndex = 13;
            this.song.Text = "Con hiện sống";
            this.song.CheckedChanged += new System.EventHandler(this.song_CheckedChanged);
            this.song.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(273, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cân nặng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.Enabled = false;
            this.taibien.Location = new System.Drawing.Point(707, 208);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(88, 16);
            this.taibien.TabIndex = 18;
            this.taibien.Text = "Tai biến";
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(345, 205);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 15;
            this.cannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cannang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // stt
            // 
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(80, 184);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(48, 21);
            this.stt.TabIndex = 1;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nam.Enabled = false;
            this.nam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(168, 184);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(48, 21);
            this.nam.TabIndex = 3;
            this.nam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nam_KeyPress);
            this.nam.Validated += new System.EventHandler(this.nam_Validated);
            this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stt_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(386, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 201;
            this.label4.Text = "gram";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTiensusk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(776, 287);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.cannang);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.song);
            this.Controls.Add(this.chet);
            this.Controls.Add(this.trung);
            this.Controls.Add(this.ngoai);
            this.Controls.Add(this.covac);
            this.Controls.Add(this.nao);
            this.Controls.Add(this.hut);
            this.Controls.Add(this.say);
            this.Controls.Add(this.thieu);
            this.Controls.Add(this.du);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cachthucde);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTiensusk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiền sử sản khoa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTiensusk_KeyDown);
            this.Load += new System.EventHandler(this.frmTiensusk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTiensusk_Load(object sender, System.EventArgs e)
		{
			user=m.user;xxx=user+m.mmyy(m_ngay);
			cachthucde.DisplayMember="TEN";
			cachthucde.ValueMember="ID";
			cachthucde.DataSource=m.get_data("select * from dmkieusanh order by stt").Tables[0];

			load_grid();
			AddGridTableStyle();
			ref_text();
		}

		private void load_grid()
		{
			sql="select a.stt,a.nam,decode(a.duthieu,1,'x',' ') as du,decode(a.duthieu,2,'x',' ') as thieu,";
			sql+="decode(a.sayhutnao,0,'x',' ') as say,decode(a.sayhutnao,1,'x',' ') as hut,decode(a.sayhutnao,2,'x',' ') as nao,";
			sql+="decode(a.covac,1,'x',' ') as covac,decode(a.ngoaitrung,0,'x',' ') as ngoai,decode(a.ngoaitrung,1,'x',' ') as trung,";
			sql+="decode(a.chetsong,0,'x',' ') as chet,decode(a.chetsong,1,'x',' ') as song,a.cannang,a.ppde,b.ten,decode(a.taibien,1,'x',' ') as taibien";
			sql+=" from "+xxx+".ba_tiensusk a,"+user+".dmkieusanh b where a.ppde=b.id and a.id="+m_id+" order by a.stt";			
			dt=m.get_data(sql).Tables[0];
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
			TextCol.HeaderText = "Số lần";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nam";
			TextCol.HeaderText = "Năm";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "du";
			TextCol.HeaderText = "Đủ tháng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thieu";
			TextCol.HeaderText = "Thiếu tháng";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "say";
			TextCol.HeaderText = "Sẩy";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hut";
			TextCol.HeaderText = "Hút";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nao";
			TextCol.HeaderText = "Nạo";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "Covac";
			TextCol.HeaderText = "Covac";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngoai";
			TextCol.HeaderText = "Chửa ngoài";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "trung";
			TextCol.HeaderText = "Chửa trứng";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chet";
			TextCol.HeaderText = "Thai chết lưu";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "song";
			TextCol.HeaderText = "Con hiện sống";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Phương pháp đẻ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "taibien";
			TextCol.HeaderText = "Tai biến";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ena_object(bool ena)
		{
			nam.Enabled=ena;
            du.Enabled=ena;
			cachthucde.Enabled=ena;
			thieu.Enabled=ena;
			say.Enabled=ena;
			hut.Enabled=ena;
			nao.Enabled=ena;
			covac.Enabled=ena;
			ngoai.Enabled=ena;
			trung.Enabled=ena;
			chet.Enabled=ena;
			song.Enabled=ena;
			cannang.Enabled=ena;
			cachthucde.Enabled=ena;
			taibien.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butThem.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void emp_text()
		{
			try
			{
				stt.Value=decimal.Parse(dt.Rows[dt.Rows.Count-1]["stt"].ToString())+1;
			}
			catch{stt.Value=1;}
			nam.Text="";du.Checked=true;thieu.Checked=false;
			say.Checked=false;hut.Checked=false;nao.Checked=false;
			covac.Checked=false;ngoai.Checked=false;trung.Checked=true;
			chet.Checked=false;song.Checked=true;cannang.Text="";taibien.Checked=false;
			cachthucde.SelectedIndex=-1;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			emp_text();
			ena_object(true);
			nam.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			ena_object(true);
			nam.Focus();
		}

		private bool kiemtra()
		{
			if (nam.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập năm !"),LibMedi.AccessData.Msg);
				nam.Focus();
				return false;
			}

			if (cachthucde.SelectedIndex==-1)
			{
				cachthucde.Focus();
				return false;
			}
			if (cannang.Text=="" || cannang.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập cân nặng !"),LibMedi.AccessData.Msg);
				cannang.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			m.upd_ba_tiensusk(m_ngay,m_id,stt.Value,nam.Text,(du.Checked)?1:(thieu.Checked)?2:0,(say.Checked)?0:(hut.Checked)?1:(nao.Checked)?2:3,(covac.Checked)?1:0,(ngoai.Checked)?0:1,(chet.Checked)?0:1,(cannang.Text!="")?decimal.Parse(cannang.Text):0,int.Parse(cachthucde.SelectedValue.ToString()),(taibien.Checked)?1:0);
			load_grid();
			ena_object(false);
			butThem.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			butThem.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					m.execute_data("delete from "+xxx+".ba_tiensusk where id="+m_id+" and stt="+stt.Value);
					load_grid();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				DataRow r=m.getrowbyid(dt,"stt="+stt.Value);
				if (r!=null)
				{
					nam.Text=r["nam"].ToString();
					du.Checked=r["du"].ToString()=="x";
					thieu.Checked=r["thieu"].ToString()=="x";
					say.Checked=r["say"].ToString()=="x";
					hut.Checked=r["hut"].ToString()=="x";
					nao.Checked=r["nao"].ToString()=="x";
					covac.Checked=r["covac"].ToString()=="x";
					ngoai.Checked=r["ngoai"].ToString()=="x";
					trung.Checked=r["trung"].ToString()=="x";
					chet.Checked=r["chet"].ToString()=="x";
					song.Checked=r["song"].ToString()=="x";
					cachthucde.SelectedValue=r["ppde"].ToString();
					taibien.Checked=r["taibien"].ToString()=="x";
					cannang.Text=r["cannang"].ToString();
				}
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmTiensusk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void cachthucde_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (cachthucde.SelectedIndex==-1 && cachthucde.Items.Count>0) cachthucde.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void stt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void du_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==du && thieu.Checked) thieu.Checked=!du.Checked;
		}

		private void thieu_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thieu && du.Checked) du.Checked=!thieu.Checked;
		}

		private void ngoai_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngoai) trung.Checked=!ngoai.Checked;
		}

		private void trung_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==trung) ngoai.Checked=!trung.Checked;
		}

		private void chet_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chet) song.Checked=!chet.Checked;
		}

		private void song_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==song) chet.Checked=!song.Checked;
		}

		private void say_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==say && say.Checked)
			{
				hut.Checked=false;
				nao.Checked=false;
			}
		}

		private void hut_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hut && hut.Checked)
			{
				say.Checked=false;
				nao.Checked=false;
			}
		}

		private void nao_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nao && nao.Checked)
			{
				hut.Checked=false;
				say.Checked=false;
			}
		}

		private void nam_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void nam_Validated(object sender, System.EventArgs e)
		{
			if (nam.Text.Length<4) nam.Text=Convert.ToString(DateTime.Now.Year-int.Parse(nam.Text));
		}
	}
}
