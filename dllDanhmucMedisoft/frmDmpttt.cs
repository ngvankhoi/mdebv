using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDmpttt.
	/// </summary>
	public class frmDmpttt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.TreeView treeView1;
		private AccessData m;
		public string user,m_mapt,m_tenpt,m_loaipt;
		private DataTable dt;
		private bool bEdit;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.CheckBox checkBox1;
        private Button butKetthuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmpttt(AccessData acc,string mapt,string tenpt,bool edit)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			m_mapt=mapt;
			m_tenpt=tenpt;
			bEdit=edit;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmpttt));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butChon = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ten = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.dataGrid1.Location = new System.Drawing.Point(160, -12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(584, 398);
            this.dataGrid1.TabIndex = 1;
            // 
            // butChon
            // 
            this.butChon.Image = ((System.Drawing.Image)(resources.GetObject("butChon.Image")));
            this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChon.Location = new System.Drawing.Point(306, 418);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(70, 25);
            this.butChon.TabIndex = 4;
            this.butChon.Text = "     &Chọn ";
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 8);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(144, 384);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Location = new System.Drawing.Point(152, 392);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(592, 20);
            this.ten.TabIndex = 3;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(8, 392);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "&Tìm theo phương pháp :";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(376, 418);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 39;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmDmpttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(752, 453);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butChon);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmpttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phẫu thuật / thủ thuật";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmpttt_KeyDown);
            this.Load += new System.EventHandler(this.frmDmpttt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDmpttt_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			butChon.Visible=bEdit;
			if (!bEdit) butKetthuc.Left=339;
			load_treeView();
			m_mapt=(m_mapt=="")?"P01":m_mapt;
			load_grid(m_mapt);
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
			TreeNode node;
			int i;
			foreach(DataRow r in m.get_data("select * from "+user+".phanloaipttt order by ma desc").Tables[0].Rows)
			{
				i=int.Parse(r["ma"].ToString());
				node=treeView1.Nodes.Add("PT"+i.ToString()+"-"+r["ten"].ToString());
                foreach (DataRow r1 in m.get_data("select * from " + user + ".muc where id_pttt=" + i + " order by id_muc").Tables[0].Rows)
				{
					node.Nodes.Add(r1["ma"].ToString()+"-"+r1["ten"].ToString());
				}
			}
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_mapt=dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString();
				m_tenpt=dataGrid1[dataGrid1.CurrentCell.RowNumber,1].ToString();
				m_loaipt=dataGrid1[dataGrid1.CurrentCell.RowNumber,6].ToString();
				m.close();this.Close();
			}
			catch{MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m_mapt="";
			m.close();this.Close();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("\\");
					string s_mapt=s.Substring(iPos+1,3);
					load_grid(s_mapt);
				}
				catch{}
			}
		}

		private void load_grid(string s_mapt)
		{
            string sql="select b.ten, a.* from " + user + ".dmpttt a, "+ user +".muc b where substr(mapt,1,3)=b.ma(+) ";
            if (s_mapt == "PT0")
                sql += " and a.id_pttt = 0";
            else if (s_mapt == "PT1")
                sql += " and a.id_pttt = 1";
            else
                sql+=" and a.mapt like '" + s_mapt + "%'";            
            sql+=" order by mapt";
            dt = m.get_data(sql).Tables[0];
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
			TextCol.MappingName = "mapt";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "noi_dung";
			TextCol.HeaderText = "Tên phẫu thuật / thủ thuật";
			TextCol.Width = 380;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dacbiet";
			TextCol.HeaderText = "DB";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai1";
			TextCol.HeaderText = "I";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai2";
			TextCol.HeaderText = "II";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai3";
			TextCol.HeaderText = "III";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loaipt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Mục";
            TextCol.Width = 120;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void frmDmpttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{	
//			try
//			{
//				dt=m.get_data("select * from dmpttt where ucase(trim(noi_dung)) like '%"+ten.Text.Trim().ToUpper()+"%'"+" order by mapt").Tables[0];
//				dataGrid1.DataSource=dt;
//			}
//			catch{}		
			try
			{
				try
				{
					dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
				}
				catch{}
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
				DataView dv= (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowDelete=false;
				dv.RowFilter = " NOI_DUNG LIKE '%"+ten.Text.Trim()+"%'";
				dataGrid1.Select(dataGrid1.CurrentRowIndex);
			}
			catch{}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			ten.Enabled=checkBox1.Checked;
			if (ten.Enabled)
			{
				load_grid("");
				ten.Focus();
			}
		}
	}
}
