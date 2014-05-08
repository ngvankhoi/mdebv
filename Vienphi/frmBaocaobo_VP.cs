using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace Vienphi
{
	public class frmBaocaobo_VP : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibVP.AccessData m_v;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.RadioButton rdNgay;
		private System.Windows.Forms.RadioButton rdKy;
		private System.Windows.Forms.CheckBox chkCosolieu;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TreeView tree_Baocao;
		private System.Windows.Forms.Button butKetchuyen;
		private System.Windows.Forms.Button butKhaibao;
		private System.Windows.Forms.ComboBox cbKybaocao;
		private System.Windows.Forms.CheckBox chkCLS;
		private System.Windows.Forms.CheckBox chkConggop;
		private System.ComponentModel.Container components = null;

		public frmBaocaobo_VP(LibVP.AccessData _m_v)
		{
            this.m_v = _m_v;
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaobo_VP));
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKybaocao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.rdNgay = new System.Windows.Forms.RadioButton();
            this.rdKy = new System.Windows.Forms.RadioButton();
            this.chkCosolieu = new System.Windows.Forms.CheckBox();
            this.tree_Baocao = new System.Windows.Forms.TreeView();
            this.butKetchuyen = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butKhaibao = new System.Windows.Forms.Button();
            this.chkCLS = new System.Windows.Forms.CheckBox();
            this.chkConggop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Enabled = false;
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(230, 30);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(82, 21);
            this.txtDN.TabIndex = 7;
            this.txtDN.ValueChanged += new System.EventHandler(this.txtDN_ValueChanged);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Enabled = false;
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(81, 30);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(82, 21);
            this.txtTN.TabIndex = 5;
            this.txtTN.ValueChanged += new System.EventHandler(this.txtTN_ValueChanged);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(166, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKybaocao
            // 
            this.cbKybaocao.BackColor = System.Drawing.Color.White;
            this.cbKybaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKybaocao.Location = new System.Drawing.Point(81, 8);
            this.cbKybaocao.Name = "cbKybaocao";
            this.cbKybaocao.Size = new System.Drawing.Size(82, 21);
            this.cbKybaocao.TabIndex = 1;
            this.cbKybaocao.SelectedIndexChanged += new System.EventHandler(this.cbKybaocao_SelectedIndexChanged);
            this.cbKybaocao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbKybaocao_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(198, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 162;
            this.label4.Text = "Năm";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(230, 8);
            this.txtNam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(50, 21);
            this.txtNam.TabIndex = 2;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.txtNam.ValueChanged += new System.EventHandler(this.cbKybaocao_SelectedIndexChanged);
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNam_KeyDown);
            // 
            // rdNgay
            // 
            this.rdNgay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdNgay.Location = new System.Drawing.Point(8, 32);
            this.rdNgay.Name = "rdNgay";
            this.rdNgay.Size = new System.Drawing.Size(72, 17);
            this.rdNgay.TabIndex = 4;
            this.rdNgay.Text = "Từ ngày:";
            this.rdNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdNgay.CheckedChanged += new System.EventHandler(this.rdKy_CheckedChanged);
            // 
            // rdKy
            // 
            this.rdKy.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rdKy.Checked = true;
            this.rdKy.Location = new System.Drawing.Point(8, 10);
            this.rdKy.Name = "rdKy";
            this.rdKy.Size = new System.Drawing.Size(72, 17);
            this.rdKy.TabIndex = 0;
            this.rdKy.TabStop = true;
            this.rdKy.Text = "Kỳ hạn:";
            this.rdKy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdKy.CheckedChanged += new System.EventHandler(this.rdKy_CheckedChanged);
            // 
            // chkCosolieu
            // 
            this.chkCosolieu.Checked = true;
            this.chkCosolieu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCosolieu.Location = new System.Drawing.Point(81, 53);
            this.chkCosolieu.Name = "chkCosolieu";
            this.chkCosolieu.Size = new System.Drawing.Size(146, 18);
            this.chkCosolieu.TabIndex = 3;
            this.chkCosolieu.Text = "Chỉ xem mục có số liệu";
            this.chkCosolieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCosolieu_KeyDown);
            // 
            // tree_Baocao
            // 
            this.tree_Baocao.CheckBoxes = true;
            this.tree_Baocao.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Baocao.FullRowSelect = true;
            this.tree_Baocao.Location = new System.Drawing.Point(5, 71);
            this.tree_Baocao.Name = "tree_Baocao";
            this.tree_Baocao.ShowLines = false;
            this.tree_Baocao.ShowPlusMinus = false;
            this.tree_Baocao.ShowRootLines = false;
            this.tree_Baocao.Size = new System.Drawing.Size(472, 177);
            this.tree_Baocao.Sorted = true;
            this.tree_Baocao.TabIndex = 8;
            this.tree_Baocao.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Baocao_AfterCheck);
            this.tree_Baocao.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_Baocao_AfterSelect);
            // 
            // butKetchuyen
            // 
            this.butKetchuyen.BackColor = System.Drawing.Color.White;
            this.butKetchuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetchuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetchuyen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetchuyen.Image = ((System.Drawing.Image)(resources.GetObject("butKetchuyen.Image")));
            this.butKetchuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetchuyen.Location = new System.Drawing.Point(193, 251);
            this.butKetchuyen.Name = "butKetchuyen";
            this.butKetchuyen.Size = new System.Drawing.Size(190, 29);
            this.butKetchuyen.TabIndex = 10;
            this.butKetchuyen.Text = "      Kết &chuyển Medisoft 2003";
            this.butKetchuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetchuyen.UseVisualStyleBackColor = false;
            this.butKetchuyen.Click += new System.EventHandler(this.butKetchuyen_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.White;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(383, 251);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(93, 29);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "       &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butKhaibao
            // 
            this.butKhaibao.BackColor = System.Drawing.Color.White;
            this.butKhaibao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKhaibao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKhaibao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKhaibao.Image = ((System.Drawing.Image)(resources.GetObject("butKhaibao.Image")));
            this.butKhaibao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhaibao.Location = new System.Drawing.Point(98, 251);
            this.butKhaibao.Name = "butKhaibao";
            this.butKhaibao.Size = new System.Drawing.Size(95, 29);
            this.butKhaibao.TabIndex = 9;
            this.butKhaibao.Text = "       Kh&ai báo";
            this.butKhaibao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKhaibao.UseVisualStyleBackColor = false;
            this.butKhaibao.Click += new System.EventHandler(this.butKhaibao_Click);
            // 
            // chkCLS
            // 
            this.chkCLS.Checked = true;
            this.chkCLS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCLS.Location = new System.Drawing.Point(230, 53);
            this.chkCLS.Name = "chkCLS";
            this.chkCLS.Size = new System.Drawing.Size(210, 18);
            this.chkCLS.TabIndex = 163;
            this.chkCLS.Text = "Cận lâm sàng lấy số liệu từ viện phí";
            this.chkCLS.Visible = false;
            // 
            // chkConggop
            // 
            this.chkConggop.Checked = true;
            this.chkConggop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConggop.Location = new System.Drawing.Point(284, 10);
            this.chkConggop.Name = "chkConggop";
            this.chkConggop.Size = new System.Drawing.Size(112, 18);
            this.chkConggop.TabIndex = 164;
            this.chkConggop.Text = "Công dồn số liệu";
            this.chkConggop.CheckedChanged += new System.EventHandler(this.cbKybaocao_SelectedIndexChanged);
            // 
            // frmBaocaobo_VP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(482, 293);
            this.Controls.Add(this.chkConggop);
            this.Controls.Add(this.tree_Baocao);
            this.Controls.Add(this.butKhaibao);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butKetchuyen);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.cbKybaocao);
            this.Controls.Add(this.txtDN);
            this.Controls.Add(this.txtTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdKy);
            this.Controls.Add(this.rdNgay);
            this.Controls.Add(this.chkCLS);
            this.Controls.Add(this.chkCosolieu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 318);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(488, 318);
            this.Name = "frmBaocaobo_VP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo Viện phí, Cận lâm sàng về Bộ y tế";
            this.Load += new System.EventHandler(this.frmBaocaobo_VP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmBaocaobo_VP_Load(object sender, System.EventArgs e)
		{
			f_Prepare();
			try
			{
				txtNam.Value = DateTime.Now.Year;
				f_Load_CB_Kybaocao();
				f_Load_Tree_Baocao();
				if(DateTime.Now.Month>9)
				{
					cbKybaocao.SelectedValue=12;
				}
				else
					if(DateTime.Now.Month>6)
				{
					cbKybaocao.SelectedValue=9;
				}
				else
					if(DateTime.Now.Month>3)
				{
					cbKybaocao.SelectedValue=6;
				}
				else
				{
					cbKybaocao.SelectedValue=3;
				}
			}
			catch
			{
			}
		}
		private void f_Prepare()
		{
			decimal n =0;
			try
			{
                n = decimal.Parse(m_v.get_data("select ma from medibv.dm_1021_ct").Tables[0].Rows.Count.ToString());
			}
			catch
			{
                m_v.execute_data("create table medibv.dm_1021_ct(ma number(3), mavp number(7), constraint pk_dm_1021_ct primary key(ma,mavp))");
			}
		}
		private void f_Load_CB_Kybaocao()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("MA");
				ads.Tables[0].Columns.Add("TEN");
				ads.Tables[0].Rows.Add(new string []{"3","3 Tháng"});
				ads.Tables[0].Rows.Add(new string []{"6","6 Tháng"});
				ads.Tables[0].Rows.Add(new string []{"9","9 Tháng"});
				ads.Tables[0].Rows.Add(new string []{"12","12 Tháng"});
				cbKybaocao.DisplayMember="TEN";
				cbKybaocao.ValueMember="MA";
				cbKybaocao.DataSource=ads.Tables[0];
			}
			catch
			{
			}
		}
		private void f_Load_Tree_Baocao()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("MA");
				ads.Tables[0].Columns.Add("TEN");
				//ads.Tables[0].Rows.Add(new string []{"DM_06","Hoạt động cận lâm sàng (Biểu 06-CLS)"});
				//ads.Tables[0].Rows.Add(new string []{"DM_101","Hoạt động tài chánh (Biểu 10.1-TC)"});
				ads.Tables[0].Rows.Add(new string []{"DM_1021","Chi tiết về thu viện phí, Bảo hiểm (Biểu 10.2.1-TCTVP/BH)"});
				//ads.Tables[0].Rows.Add(new string []{"DM_1022","Chi tiế về các khoản chi (Biểu 10.2.2-TCC)"});
				//ads.Tables[0].Rows.Add(new string []{"DM_103","Các khoản không thu được (Biểu 10.3-TC/KT)"});
				f_Load_Tree(tree_Baocao,ads);
			}
			catch
			{
			}
		}
		private void f_Load_Tree(TreeView v_tree, DataSet v_ds)
		{
			try
			{
				TreeNode anode;
				v_tree.Nodes.Clear();
				v_tree.Sorted=false;
				for(int i=0;i<v_ds.Tables[0].Rows.Count;i++)
				{
					anode = new TreeNode(v_ds.Tables[0].Rows[i]["ten"].ToString());
					anode.Tag = v_ds.Tables[0].Rows[i]["ma"].ToString();
					v_tree.Nodes.Add(anode);
				}
			}
			catch
			{
			}
		}

		private void cbKybaocao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					txtNam.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtNam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					chkCosolieu.Focus();
				}
			}
			catch
			{
			}
		}

		private void chkCosolieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					butKetchuyen.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtTN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					txtDN.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtDN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					butKetchuyen.Focus();
				}
			}
			catch
			{
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tree_Baocao_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		
		}

		private void tree_Baocao_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Black:Color.DimGray;
			}
			catch
			{
			}
		}

		private void rdKy_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				cbKybaocao.Enabled=rdKy.Checked;
				txtNam.Enabled=rdKy.Checked;
				txtTN.Enabled=rdNgay.Checked;
				txtDN.Enabled=rdNgay.Checked;
			}
			catch
			{
			}
		}

		private void cbKybaocao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(chkConggop.Checked)
				{
					switch(cbKybaocao.SelectedValue.ToString())
					{
						case "3":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),3,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),3));
							break;
						case "6":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),6,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),6));
							break;
						case "9":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),9,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),9));
							break;
						case "12":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),12,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),12));
							break;
					}
				}
				else
				{
					switch(cbKybaocao.SelectedValue.ToString())
					{
						case "3":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),3,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),3));
							break;
						case "6":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),4,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),6,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),6));
							break;
						case "9":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),7,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),9,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),9));
							break;
						case "12":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),10,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),12,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),12));
							break;
					}
				}
			}
			catch
			{
			}
		}
		private void txtTN_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTN.Value>txtDN.Value)
				{
					txtDN.Value=txtTN.Value;
				}
			}
			catch
			{
			}
		}
		private void txtDN_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTN.Value>txtDN.Value)
				{
					txtTN.Value=txtDN.Value;
				}
			}
			catch
			{
			}
		}

		private void butKetchuyen_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			this.Enabled=false;
			try
			{
				if(f_Ketchuyen()=="1")
				{
					MessageBox.Show(this,"Chuyển số liệu viện phí sang báo cáo Medisoft2003 xong!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(this,"Chưa chuyển số liệu!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			catch
			{
			}
			finally
			{
				this.Cursor=Cursors.Default;
				this.Enabled=true;
			}
		}
		private string f_Ketchuyen()
		{
			try
			{
				if(m_v.get_data("select id from medibv.bieu_1021 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+txtTN.Text.Substring(0,10)+"','dd/mm/yyyy') and to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')").Tables[0].Rows.Count>0)
				{
					DialogResult  adg = MessageBox.Show(this,"Số liệu tổng hợp trong thời gian từ ["+txtTN.Text.Substring(0,10)+"] đến ["+txtDN.Text.Substring(0,10)+"] đã có.\nCó muốn xoá dữ liệu cũ không?","Thông báo",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button3);
					if(adg==DialogResult.Yes)
					{
                        m_v.execute_data("delete from medibv.bieu_1021 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')");
					}
					else
						if(adg==DialogResult.Cancel)
					{
						return "";
					}
				}

				string aid = "1";
				try
				{
                    aid = decimal.Parse(m_v.get_data("select max(id)+1 from medibv.bieu_1021").Tables[0].Rows[0][0].ToString()).ToString();
				}
				catch
				{
					aid="1";
				}
                m_v.execute_data("insert into medibv.bieu_1021(id,ma,ngay,vienphi,bhyt,userid,ngayud) select " + aid + " as id, ma, to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') as ngay,0,0,-1,sysdate from dm_1021");
				string sql="";
				//Thu truc tiep
				try
				{
					sql="select c.ma,sum(decode(b.madoituong,1,0,b.soluong*b.dongia-b.mien-b.thieu)) vienphi,sum(decode(b.madoituong,1,b.soluong*b.dongia-b.mien-b.thieu,0)) bhyt from medibvmmyy.v_vienphill a, medibvmmyy.v_vienphict b, medibv.dm_1021_ct c where a.id=b.id and b.mavp=c.mavp and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+txtTN.Text.Substring(0,10)+"','dd/mm/yyyy') and to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy') group by c.ma";
					foreach(DataRow r in m_v.get_data_bc(txtTN.Value,txtDN.Value,sql).Tables[0].Rows)
					{
                        m_v.execute_data("update medibv.bieu_1021 set vienphi=vienphi+" + r["vienphi"].ToString() + ", bhyt=bhyt+" + r["bhyt"].ToString() + " where id=" + aid + " and ma=" + r["ma"].ToString());
					}
				}
				catch
				{
				}
				//Thanh toan ra vien
				try
				{
					sql="select c.ma,sum(decode(b.madoituong,1,0,b.soluong*b.dongia)) vienphi,sum(decode(b.madoituong,1,b.soluong*b.dongia,0)) bhyt from medibvmmyy.v_ttrvll a, medibvmmyy.v_ttrvct b, medibv.dm_1021_ct c where a.id=b.id and b.mavp=c.mavp and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+txtTN.Text.Substring(0,10)+"','dd/mm/yyyy') and to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy') group by c.ma";
					foreach(DataRow r in m_v.get_data_bc(txtTN.Value,txtDN.Value,sql).Tables[0].Rows)
					{
                        m_v.execute_data("update medibv.bieu_1021 set vienphi=vienphi+" + r["vienphi"].ToString() + ", bhyt=bhyt+" + r["bhyt"].ToString() + " where id=" + aid + " and ma=" + r["ma"].ToString());
					}
				}
				catch
				{
				}
                m_v.execute_data("update medibv.bieu_1021 set vienphi=round(vienphi/1000), bhyt=round(bhyt/1000) where id=" + aid);
				return "1";
			}
			catch
			{
				return "";
			}
		}

		private void butKhaibao_Click(object sender, System.EventArgs e)
		{
			try
			{
                frmDM_1021_ct af = new frmDM_1021_ct("", m_v);
				af.ShowInTaskbar=false;
				af.ShowDialog();
			}
			catch
			{
			}
		}
	}
}
