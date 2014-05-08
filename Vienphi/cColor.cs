using System;
using System.Drawing;
using System.Data;
using System.Xml;
////
namespace Vienphi
{
	/// <summary>
	/// Summary description for cColor.
	/// </summary>
	public class cColor
	{
		public Color m_bgcolor_head =  SystemColors.Control ;//Color.FromArgb(84,167,167);
		public Color m_color_head =  SystemColors.ControlText ;//Color.FromArgb(221,255,255);

		public Color m_bgcolor_content =  Color.WhiteSmoke;//Color.FromArgb(230,255,255);
		public Color m_color_content =  SystemColors.ControlText;//Color.FromArgb(0,98,98);

		public Color m_bgcolor_ba =  SystemColors.Control;//Color.FromArgb(0,128,128);
		public Color m_color_ba =  SystemColors.ControlText;//Color.FromArgb(0,128,128);

		public cColor()
		{
			f_LoadOption();
		}
		public void f_LoadOption()
		{
			try
			{
				int ar=0,ag=0,ab=0;
				DataSet ads = new DataSet();
				try
				{
					if(!System.IO.Directory.Exists("..//..//options"))
					{
						System.IO.Directory.CreateDirectory("..//..//options");
					}
					ads.ReadXml("..//..//options//ba_option_color.xml");
				}
				catch{}
				try
				{
					ar = int.Parse(ads.Tables[0].Select("ma='bgcolor_ba_R'")[0]["giatri"].ToString().Trim());
					ag = int.Parse(ads.Tables[0].Select("ma='bgcolor_ba_G'")[0]["giatri"].ToString().Trim());
					ab = int.Parse(ads.Tables[0].Select("ma='bgcolor_ba_B'")[0]["giatri"].ToString().Trim());
					m_bgcolor_ba = Color.FromArgb(ar,ag,ab);
				}
				catch
				{
					m_bgcolor_ba =  Color.FromArgb(0,128,128);
				}

				try
				{
					ar = int.Parse(ads.Tables[0].Select("ma='color_ba_R'")[0]["giatri"].ToString().Trim());
					ag = int.Parse(ads.Tables[0].Select("ma='color_ba_G'")[0]["giatri"].ToString().Trim());
					ab = int.Parse(ads.Tables[0].Select("ma='color_ba_B'")[0]["giatri"].ToString().Trim());
					m_color_ba = Color.FromArgb(ar,ag,ab);
				}
				catch
				{
					m_color_ba =  Color.FromArgb(221,255,255);
				}
				try
				{
					ar = int.Parse(ads.Tables[0].Select("ma='bgcolor_head_R'")[0]["giatri"].ToString().Trim());
					ag = int.Parse(ads.Tables[0].Select("ma='bgcolor_head_G'")[0]["giatri"].ToString().Trim());
					ab = int.Parse(ads.Tables[0].Select("ma='bgcolor_head_B'")[0]["giatri"].ToString().Trim());
					m_bgcolor_head = Color.FromArgb(ar,ag,ab);
				}
				catch
				{
					m_bgcolor_head = Color.FromArgb(84,167,167);
				}

				try
				{
					ar = int.Parse(ads.Tables[0].Select("ma='color_head_R'")[0]["giatri"].ToString().Trim());
					ag = int.Parse(ads.Tables[0].Select("ma='color_head_G'")[0]["giatri"].ToString().Trim());
					ab = int.Parse(ads.Tables[0].Select("ma='color_head_B'")[0]["giatri"].ToString().Trim());
					m_color_head = Color.FromArgb(ar,ag,ab);
				}
				catch
				{
					m_color_head = Color.FromArgb(215,255,255);
				}

				try
				{
					ar = int.Parse(ads.Tables[0].Select("ma='bgcolor_content_R'")[0]["giatri"].ToString().Trim());
					ag = int.Parse(ads.Tables[0].Select("ma='bgcolor_content_G'")[0]["giatri"].ToString().Trim());
					ab = int.Parse(ads.Tables[0].Select("ma='bgcolor_content_B'")[0]["giatri"].ToString().Trim());
					m_bgcolor_content = Color.FromArgb(ar,ag,ab);
				}
				catch
				{
					m_bgcolor_content = Color.FromArgb(230,255,255);;
				}

				try
				{
					ar = int.Parse(ads.Tables[0].Select("ma='color_content_R'")[0]["giatri"].ToString().Trim());
					ag = int.Parse(ads.Tables[0].Select("ma='color_content_G'")[0]["giatri"].ToString().Trim());
					ab = int.Parse(ads.Tables[0].Select("ma='color_content_B'")[0]["giatri"].ToString().Trim());
					m_color_content = Color.FromArgb(ar,ag,ab);
				}
				catch
				{
					m_color_content = Color.FromArgb(0,98,98);
				}
			}
			catch{}
		}
		public void f_SaveOption()
		{
			try
			{
				try
				{
					if(!System.IO.Directory.Exists("..//..//options"))
					{
						System.IO.Directory.CreateDirectory("..//..//options");
					}
				}
				catch{}
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("ma");
				ads.Tables[0].Columns.Add("giatri");
				ads.Tables[0].Rows.Add(new string []{"bgcolor_ba_R",m_bgcolor_ba.R.ToString()});
				ads.Tables[0].Rows.Add(new string []{"bgcolor_ba_G",m_bgcolor_ba.G.ToString()});
				ads.Tables[0].Rows.Add(new string []{"bgcolor_ba_B",m_bgcolor_ba.B.ToString()});

				ads.Tables[0].Rows.Add(new string []{"color_ba_R",m_color_ba.R.ToString()});
				ads.Tables[0].Rows.Add(new string []{"color_ba_G",m_color_ba.G.ToString()});
				ads.Tables[0].Rows.Add(new string []{"color_ba_B",m_color_ba.B.ToString()});

				ads.Tables[0].Rows.Add(new string []{"bgcolor_head_R",m_bgcolor_head.R.ToString()});
				ads.Tables[0].Rows.Add(new string []{"bgcolor_head_G",m_bgcolor_head.G.ToString()});
				ads.Tables[0].Rows.Add(new string []{"bgcolor_head_B",m_bgcolor_head.B.ToString()});

				ads.Tables[0].Rows.Add(new string []{"color_head_R",m_color_head.R.ToString()});
				ads.Tables[0].Rows.Add(new string []{"color_head_G",m_color_head.G.ToString()});
				ads.Tables[0].Rows.Add(new string []{"color_head_B",m_color_head.B.ToString()});

				ads.Tables[0].Rows.Add(new string []{"bgcolor_content_R",m_bgcolor_content.R.ToString()});
				ads.Tables[0].Rows.Add(new string []{"bgcolor_content_G",m_bgcolor_content.G.ToString()});
				ads.Tables[0].Rows.Add(new string []{"bgcolor_content_B",m_bgcolor_content.B.ToString()});

				ads.Tables[0].Rows.Add(new string []{"color_content_R",m_color_content.R.ToString()});
				ads.Tables[0].Rows.Add(new string []{"color_content_G",m_color_content.G.ToString()});
				ads.Tables[0].Rows.Add(new string []{"color_content_B",m_color_content.B.ToString()});

				ads.WriteXml("..//..//options//ba_option_color.xml",XmlWriteMode.WriteSchema);
			}
			catch{}
		}

		public void f_ResetColor()
		{
			try
			{
				m_bgcolor_head =  Color.FromArgb(192,192,192);
				m_color_head =  SystemColors.ControlText ;//Color.FromArgb(221,255,255);

				m_bgcolor_content =  SystemColors.Control;//Color.FromArgb(230,255,255);
				m_color_content =  SystemColors.ControlText;//Color.FromArgb(0,98,98);

				m_bgcolor_ba =  SystemColors.Control;//Color.FromArgb(0,128,128);
				m_color_ba =  SystemColors.ControlText;//Color.FromArgb(0,128,128);

//				m_bgcolor_head = Color.FromArgb(84,167,167);
//				m_color_head = Color.FromArgb(215,255,255);
//				m_bgcolor_content = Color.FromArgb(230,255,255);
//				m_color_content = Color.FromArgb(0,98,98);
//				m_bgcolor_ba =  Color.FromArgb(0,128,128);
//				m_color_ba =  Color.FromArgb(221,255,255);
				f_SaveOption();
			}
			catch{}
		}
	}
}
