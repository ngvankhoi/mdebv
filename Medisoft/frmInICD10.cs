using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmInICD10.
	/// </summary>
	public class frmInICD10 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m = new LibMedi.AccessData();
		private DataSet m_ds = new DataSet();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.ComboBox cbNhom;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butAThemAll;
		private System.Windows.Forms.Button butXoaAll;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cbChuong;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkICDBV;
		private System.Windows.Forms.CheckBox chkAll_Bo;
		private System.ComponentModel.IContainer components;
		private string s_table;

		public frmInICD10(string table)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
			s_table=table;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInICD10));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.cbNhom = new System.Windows.Forms.ComboBox();
            this.cbChuong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.butIn = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butAThemAll = new System.Windows.Forms.Button();
            this.butXoaAll = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkICDBV = new System.Windows.Forms.CheckBox();
            this.chkAll_Bo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowSorting = false;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.Black;
            this.dataGrid1.CaptionText = "Các bệnh lọc theo nhóm";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(2, 51);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 20;
            this.dataGrid1.Size = new System.Drawing.Size(380, 493);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // cbNhom
            // 
            this.cbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhom.Location = new System.Drawing.Point(48, 27);
            this.cbNhom.Name = "cbNhom";
            this.cbNhom.Size = new System.Drawing.Size(335, 21);
            this.cbNhom.TabIndex = 7;
            this.cbNhom.SelectedIndexChanged += new System.EventHandler(this.cbNhom_SelectedIndexChanged);
            // 
            // cbChuong
            // 
            this.cbChuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuong.Location = new System.Drawing.Point(48, 5);
            this.cbChuong.Name = "cbChuong";
            this.cbChuong.Size = new System.Drawing.Size(335, 21);
            this.cbChuong.TabIndex = 5;
            this.cbChuong.SelectedIndexChanged += new System.EventHandler(this.cbChuong_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nhóm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Chương";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid2
            // 
            this.dataGrid2.AllowSorting = false;
            this.dataGrid2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.dataGrid2.CaptionText = "Các bệnh chọn để in";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(416, 51);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 20;
            this.dataGrid2.Size = new System.Drawing.Size(376, 493);
            this.dataGrid2.TabIndex = 8;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.Location = new System.Drawing.Point(383, 51);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(32, 27);
            this.butIn.TabIndex = 18;
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butThem
            // 
            this.butThem.Location = new System.Drawing.Point(383, 80);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(32, 23);
            this.butThem.TabIndex = 21;
            this.butThem.Text = ">";
            this.toolTip1.SetToolTip(this.butThem, "Thêm bệnh này vào danh sách in");
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butAThemAll
            // 
            this.butAThemAll.Location = new System.Drawing.Point(383, 103);
            this.butAThemAll.Name = "butAThemAll";
            this.butAThemAll.Size = new System.Drawing.Size(32, 23);
            this.butAThemAll.TabIndex = 22;
            this.butAThemAll.Text = ">>";
            this.toolTip1.SetToolTip(this.butAThemAll, "Thêm tất cả bệnh này vào danh sách in");
            this.butAThemAll.Click += new System.EventHandler(this.butAThemAll_Click);
            // 
            // butXoaAll
            // 
            this.butXoaAll.Location = new System.Drawing.Point(383, 149);
            this.butXoaAll.Name = "butXoaAll";
            this.butXoaAll.Size = new System.Drawing.Size(32, 23);
            this.butXoaAll.TabIndex = 24;
            this.butXoaAll.Text = "<<";
            this.toolTip1.SetToolTip(this.butXoaAll, "Xoá tất cả các bệnh này khỏi danh sách in");
            this.butXoaAll.Click += new System.EventHandler(this.butXoaAll_Click);
            // 
            // butXoa
            // 
            this.butXoa.Location = new System.Drawing.Point(383, 126);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(32, 23);
            this.butXoa.TabIndex = 23;
            this.butXoa.Text = "<";
            this.toolTip1.SetToolTip(this.butXoa, "Xoá bệnh này khỏi danh sách in");
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.Location = new System.Drawing.Point(383, 173);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(32, 25);
            this.butKetthuc.TabIndex = 25;
            this.toolTip1.SetToolTip(this.butKetthuc, "Kết thúc");
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(393, 6);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(181, 19);
            this.chkAll.TabIndex = 26;
            this.chkAll.Text = "In ICD10  bệnh viện + bộ y tế";
            this.toolTip1.SetToolTip(this.chkAll, "In toàn bộ các bệnh trong bộ từ điển ICD10");
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkICDBV
            // 
            this.chkICDBV.Location = new System.Drawing.Point(393, 28);
            this.chkICDBV.Name = "chkICDBV";
            this.chkICDBV.Size = new System.Drawing.Size(133, 19);
            this.chkICDBV.TabIndex = 27;
            this.chkICDBV.Text = "In ICD bệnh viện khai";
            this.toolTip1.SetToolTip(this.chkICDBV, "In toàn bộ các bệnh trong bộ từ điển ICD10");
            this.chkICDBV.CheckedChanged += new System.EventHandler(this.chkICDBV_CheckedChanged);
            // 
            // chkAll_Bo
            // 
            this.chkAll_Bo.Location = new System.Drawing.Point(574, 6);
            this.chkAll_Bo.Name = "chkAll_Bo";
            this.chkAll_Bo.Size = new System.Drawing.Size(104, 19);
            this.chkAll_Bo.TabIndex = 28;
            this.chkAll_Bo.Text = "In ICD10 bộ y tế";
            this.toolTip1.SetToolTip(this.chkAll_Bo, "In toàn bộ các bệnh trong bộ từ điển ICD10 của bộ y tế");
            this.chkAll_Bo.CheckedChanged += new System.EventHandler(this.chkAll_Bo_CheckedChanged);
            // 
            // frmInICD10
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.chkAll_Bo);
            this.Controls.Add(this.chkICDBV);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.butXoaAll);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butAThemAll);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.cbNhom);
            this.Controls.Add(this.cbChuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInICD10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " In ICD10";
            this.Load += new System.EventHandler(this.frmInICD10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private void frmInICD10_Load(object sender, System.EventArgs e)
		{
			f_Load_CB_Chuong();
			f_Load_CB_Nhom();
			f_Load_DG_ICD();
		}
		private void f_Add(int i)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew=false;
				string exp = "cicd10='" + dv.Table.Rows[i]["cicd10"].ToString().Trim()+"'"; 
				if(m_ds.Tables[0].Select(exp).Length<=0)
				{
					m_ds.Tables[0].Rows.Add(dv.Table.Rows[i].ItemArray);
				}
				m_ds.AcceptChanges();
				dataGrid2.CaptionText="Các bệnh chọn để in: " + m_ds.Tables[0].Rows.Count.ToString();
				dataGrid1.CurrentRowIndex=dataGrid1.CurrentRowIndex+1;
			}
			catch
			{
			}
		}
		private void f_Rem()
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid2.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew=false;
				int i=dataGrid2.CurrentRowIndex;
				m_ds.Tables[0].Rows.RemoveAt(i);
				dataGrid2.CaptionText="Các bệnh chọn để in: " + m_ds.Tables[0].Rows.Count.ToString();
				dataGrid2_CurrentCellChanged(null,null);
			}
			catch
			{
			}
		}
		private void f_AddAll()
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew=false;
				for(int i=0;i<dv.Table.Rows.Count;i++)	f_Add(i);
			}
			catch
			{
			}
		}
	
		private void f_Load_CB_Chuong()
		{
			try
			{
				string asql = "select id_chapter as MA, chapter as TEN from "+m.user+".icd_chapter order by id_chapter";
				DataSet ads =  m.get_data(asql);
				DataRow r = ads.Tables[0].NewRow();
				r["ma"]="0";
				r["ten"]="Tất cả";
				ads.Tables[0].Rows.InsertAt(r,0);
				cbChuong.DisplayMember="TEN";
				cbChuong.ValueMember="MA";
				cbChuong.DataSource = ads.Tables[0];
				cbChuong.SelectedIndex=0;

				m_ds=m.get_data("select a.cicd10, a.vviet, a.vanh, a.id_chapter as id_chuong, a.id_nhom, b.chapter as chuong, c.nhom from "+m.user+"."+s_table+" a,"+m.user+".icd_chapter b,"+m.user+".icd_nhom c where a.id_chapter=b.id_chapter and a.id_nhom=c.id_nhom order by a.cicd10");
				AddGridTableStyle(dataGrid2,m_ds);
				lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
				lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void f_Load_CB_Nhom()
		{
			try
			{
				string asql = "select id_nhom as MA, nhom as TEN from "+m.user+".icd_nhom";
				if(cbChuong.SelectedValue.ToString()!="0")
					asql+=" where id_chapter="+int.Parse(cbChuong.SelectedValue.ToString());
				asql+=" order by id_nhom";
				DataSet ads =  m.get_data(asql);
				DataRow r = ads.Tables[0].NewRow();
				r["ma"]="0";
				r["ten"]="Tất cả";
				ads.Tables[0].Rows.InsertAt(r,0);
				cbNhom.DisplayMember="TEN";
				cbNhom.ValueMember="MA";
				cbNhom.DataSource = ads.Tables[0];
				cbNhom.SelectedIndex=0;
			}
			catch
			{
			}
		}
		private void f_Load_DG_ICD()
		{
			try
			{
				string asql = "select a.cicd10, a.vviet, a.vanh,a.id_chapter as id_chuong,a.id_nhom,b.chapter as chuong, c.nhom from "+m.user+"."+s_table+" a, "+m.user+".icd_chapter b, "+m.user+".icd_nhom c where a.id_chapter=b.id_chapter and a.id_nhom=c.id_nhom ";
				if(cbChuong.SelectedValue.ToString()!="0")
					asql+=" and a.id_chapter=" +int.Parse(cbChuong.SelectedValue.ToString());			
				if(cbNhom.SelectedValue.ToString()!="0")
					asql+=" and a.id_nhom=" +int.Parse(cbNhom.SelectedValue.ToString());
				asql+=" order by a.cicd10";
				DataSet ads =  m.get_data(asql);
				dataGrid1.CaptionText="Các bệnh lọc theo nhóm: " + ads.Tables[0].Rows.Count.ToString();
				AddGridTableStyle(dataGrid1,ads);
			}
			catch
			{
			}
		}

		private void cbChuong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==cbChuong)
			{
				f_Load_CB_Nhom();
				f_Load_DG_ICD();
			}
		}

		private void cbNhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==cbNhom)
			{
				f_Load_DG_ICD();
			}
		}

		private void butXoaAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_ds.Tables[0].Rows.Clear();
				m_ds.AcceptChanges();
			}
			catch
			{
			}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			try
			{
				f_Add(dataGrid1.CurrentRowIndex);
			}
			catch
			{
			}
		}

		private void butAThemAll_Click(object sender, System.EventArgs e)
		{
			f_AddAll();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			f_Rem();
		}
		private void f_In()
		{
			try
			{
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Chọn icd cần in"),lan.Change_language_MessageText("Thông báo"),MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				string areport="m_icd10.rpt";
				string angayin ="Ngày " + DateTime.Now.Day.ToString().PadLeft(2,'0') + " tháng " + DateTime.Now.Month.ToString().PadLeft(2,'0') + " năm " + DateTime.Now.Year.ToString();
				string aghichu = chkICDBV.Checked?"(Các mã icd do bệnh viện khai)":"";
				aghichu = chkAll.Checked?"(Các mã icd do bệnh viện khai + bộ y tế)":aghichu;
				aghichu = chkAll_Bo.Checked?"(Các mã icd do bộ y tế cấp)":aghichu;
			    frmReport f = new frmReport(m, m_ds, angayin,"", aghichu, areport);
                f.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void butIn_Click(object sender, System.EventArgs e)
		{
			f_In();
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chkAll.Checked)
				{
					m_ds=m.get_data("select a.cicd10, a.vviet, a.vanh, a.id_chapter as id_chuong,a.id_nhom,b.chapter as chuong, c.nhom from "+m.user+"."+s_table+" a,"+m.user+".icd_chapter b,"+m.user+".icd_nhom c where a.id_chapter=b.id_chapter and a.id_nhom=c.id_nhom order by a.cicd10");
					dataGrid2.DataSource=m_ds.Tables[0];
					dataGrid2.CaptionText="Các bệnh chọn để in: " + m_ds.Tables[0].Rows.Count.ToString();
					chkAll_Bo.Checked=false;
					chkICDBV.Checked=false;
				}
			}
			catch
			{
			}
		}
		private void AddGridTableStyle(DataGrid v_dg,DataSet v_ds)
		{
			try
			{
				if(v_dg.TableStyles.Count<=0)
				{
					DataGridTableStyle ts =new DataGridTableStyle();
					ts.MappingName = v_ds.Tables[0].TableName;
					ts.AlternatingBackColor = Color.Beige;
					ts.BackColor = Color.GhostWhite;
					ts.ForeColor = Color.MidnightBlue;
					ts.GridLineColor = Color.RoyalBlue;
					ts.HeaderBackColor = SystemColors.Control;//Color.MidnightBlue;
					ts.HeaderForeColor = Color.Black;//.Lavender;
					ts.SelectionBackColor = Color.Teal;
					ts.SelectionForeColor = Color.PaleGreen;
					ts.ReadOnly=false;
					ts.RowHeaderWidth=10;
						
					DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "cicd10";
					TextCol.HeaderText = "ICD10";
					TextCol.NullText = "";
					TextCol.Width = 50;
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);

					TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "vviet";
					TextCol.HeaderText = "Tên bệnh tật tiếng việt";
					TextCol.NullText="";
					TextCol.Width = 400;
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);

					TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "vanh";
					TextCol.HeaderText = "Tên bệnh tật tiếng anh";
					TextCol.NullText="";
					TextCol.Width = 295;
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);

					TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "id_chuong";
					TextCol.HeaderText = "";
					TextCol.NullText="";
					TextCol.Width = 0;
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);

					TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "id_nhom";
					TextCol.HeaderText = "";
					TextCol.NullText="";
					TextCol.Width = 0;
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);

					TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "chuong";
					TextCol.HeaderText = "Chương";
					TextCol.Width = 295;
					TextCol.NullText="";
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);

					TextCol=new DataGridTextBoxColumn();
					TextCol.MappingName = "nhom";
					TextCol.HeaderText = "Nhóm bệnh";
					TextCol.Width = 295;
					TextCol.NullText="";
					ts.GridColumnStyles.Add(TextCol);
					v_dg.TableStyles.Add(ts);
				}
				v_dg.DataSource=v_ds.Tables[0];
			}
			catch
			{
			}
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				dataGrid1.UnSelect(int.Parse(dataGrid1.Tag.ToString()));
			}
			catch
			{
			}
			
			try
			{
				dataGrid1.Tag=dataGrid1.CurrentRowIndex.ToString();
			}
			catch
			{
				dataGrid1.Tag="0";
			}

			try
			{
				dataGrid1.Select(int.Parse(dataGrid1.Tag.ToString()));
			}
			catch
			{
			}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				dataGrid2.UnSelect(int.Parse(dataGrid2.Tag.ToString()));
			}
			catch
			{
			}
			
			try
			{
				dataGrid2.Tag=dataGrid2.CurrentRowIndex.ToString();
			}
			catch
			{
				dataGrid2.Tag="0";
			}

			try
			{
				dataGrid2.Select(int.Parse(dataGrid2.Tag.ToString()));
			}
			catch
			{
			}
		}

		private void chkICDBV_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chkICDBV.Checked)
				{
					m_ds=m.get_data("select a.cicd10, a.vviet, a.vanh,a.id_chapter as id_chuong,a.id_nhom, b.chapter as chuong, c.nhom from "+m.user+"."+s_table+" a,"+m.user+".icd_chapter b,"+m.user+".icd_nhom c where a.id_chapter=b.id_chapter and a.id_nhom=c.id_nhom and a.readonly=0 order by a.cicd10");
					dataGrid2.DataSource=m_ds.Tables[0];
					dataGrid2.CaptionText="Các bệnh chọn để in: " + m_ds.Tables[0].Rows.Count.ToString();
					chkAll.Checked=false;
					chkAll_Bo.Checked=false;
				}
			}
			catch
			{
			}
		}

		private void chkAll_Bo_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chkAll_Bo.Checked)
				{
					m_ds=m.get_data("select a.cicd10, a.vviet, a.vanh, a.id_chapter as id_chuong,a.id_nhom as id_nhom, b.chapter as chuong, c.nhom from "+m.user+"."+s_table+" a,"+m.user+".icd_chapter b,"+m.user+".icd_nhom c where a.id_chapter=b.id_chapter and a.id_nhom=c.id_nhom and a.readonly=1 order by a.cicd10");
					dataGrid2.DataSource=m_ds.Tables[0];
					dataGrid2.CaptionText="Các bệnh chọn để in: " + m_ds.Tables[0].Rows.Count.ToString();
					chkAll.Checked=false;
					chkICDBV.Checked=false;
				}
			}
			catch
			{
			}
		}
	}
}
