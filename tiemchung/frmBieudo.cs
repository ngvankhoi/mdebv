using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WebTel.Drawing.Chart;
using LibMedi;

namespace tiemchung
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmBieudo : System.Windows.Forms.Form
	{
        LibMedi.AccessData m = null;
        DataTable dt = null;
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private WebTel.Drawing.Chart.ucChart ucChart1;
        private Label lbl;
        private System.Windows.Forms.Button butBieudo;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
		private System.ComponentModel.IContainer components;

		public frmBieudo(AccessData acc)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
		}
        public frmBieudo(AccessData acc,DataTable _dt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            dt = _dt;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBieudo));
            this.ucChart1 = new WebTel.Drawing.Chart.ucChart();
            this.butBieudo = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ucChart1
            // 
            // Layout is suspended for performance reasons.
            this.ucChart1.Chart.SuspendLayout();
            this.ucChart1.Chart.CategoryX.Font = null;
            this.ucChart1.Chart.CategoryX.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.CategoryY.Font = null;
            this.ucChart1.Chart.CategoryY.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.ChartBackColor = System.Drawing.SystemColors.Info;
            this.ucChart1.Chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart1.Chart.MarginBackColor = System.Drawing.Color.White;
            this.ucChart1.Chart.ResumeLayout();
            this.ucChart1.Location = new System.Drawing.Point(188, 35);
            this.ucChart1.Name = "ucChart1";
            this.ucChart1.Size = new System.Drawing.Size(547, 469);
            this.ucChart1.TabIndex = 28;
            // 
            // butBieudo
            // 
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(79, 2);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(102, 25);
            this.butBieudo.TabIndex = 27;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.Click += new System.EventHandler(this.butBieudo_Click);
            // 
            // frmBieudo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butBieudo);
            this.Controls.Add(this.ucChart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBieudo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê số liệu theo biểu đồ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBieudo_Load);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 

		private void butBieudo_Click(object sender, System.EventArgs e)
		{
			
		}

        private void frmBieudo_Load(object sender, EventArgs e)
        {
            ucChart1.Chart.Series.Items.Clear();
            ucChart1.Chart.CategoryX.Items.Clear();
            try
            {
                ucChart1.Chart.ChartType = ChartTypes.Bar;
                ucChart1.Chart.CategoryY.Items.Add(new ChartCategory("Nhiệt độ lạnh"));
                ucChart1.Chart.CategoryX.Items.Add(new ChartCategory("Ngày"));
                foreach (DataRow r in dt.Rows)
                {
                    float[] f ={ float.Parse(r["nhietdo"].ToString())};
                    ChartValue[] chart ={ (ChartValue)r["ngay"] };
                    ucChart1.Chart.Series.Items.Add(new ChartSerie(Color.White, Color.Black, f));
                }
                ucChart1.Refresh();
            }
            catch { }
        }
	}
}
