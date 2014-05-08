using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Configuration;
using DataAccessLayer;

namespace SMSAsync
{
    public partial class frmMain : Form
    {
        private FileStream myfile;
        private System.Windows.Forms.Timer tmrDigitalClock;
        private System.Windows.Forms.Timer tmrSMSprocess;
        private DateTime starttime;
        private DateTime stoptime;
        private DateTime today;

        private char delimiter;
        private DataTable mytable;
        private DataTable mysummarytable;

        private string datafile;
        private string reportfile;
        private int exitFlag;

        private PgSqlDAL dao;
        private HttpServer smsReceiver;

        private NotifyIcon notifySMS;

        public frmMain()
        {
            InitializeComponent();

            notifySMS = new NotifyIcon();
            notifySMS.Icon = new System.Drawing.Icon(Application.StartupPath + @"\327.ico");
            notifySMS.BalloonTipIcon = ToolTipIcon.Info;
            notifySMS.BalloonTipTitle = "SMS Async";
            notifySMS.BalloonTipText = "Giúp gửi và nhận tin nhắn qua Ozeki Message Server";
            notifySMS.DoubleClick += new System.EventHandler(this.notifySMS_Click);
            notifySMS.MouseMove += new MouseEventHandler(notifySMS_MouseMove);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            exitFlag = 0;

            string filedir = Application.StartupPath.ToString();
            reportfile = filedir + "\\" + ConfigurationManager.AppSettings["ReportFile"].ToString();//ReportFile.xml";
            datafile = filedir + "\\" + ConfigurationManager.AppSettings["DataFile"].ToString();//TimeSheet.txt";
            CheckOutputFile(datafile);

            delimiter = '^';

            // Set up the timer
            tmrDigitalClock = new System.Windows.Forms.Timer();
            tmrDigitalClock.Enabled = true;
            tmrDigitalClock.Interval = 1000;
            tmrDigitalClock.Tick += new System.EventHandler(tmrDigitalClock_Tick);

            tmrSMSprocess = new System.Windows.Forms.Timer();
            tmrSMSprocess.Enabled = true;
            tmrSMSprocess.Interval = 30000;
            tmrSMSprocess.Tick += new System.EventHandler(tmrSMSprocess_Tick);

            starttime = System.DateTime.MinValue;

            /*Begin: Same as btnStart_Click() function.*/
            // Make UI read only for the duration.
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            starttime = DateTime.Now;
            /*End: Same as btnStart_Click() function.*/

            txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEndDate.Text = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");

            //InitializeComponent();
            mytable = CreateTable();
            mysummarytable = CreateTable();

            dao = new PgSqlDAL(ConfigurationManager.AppSettings["ConnectionString"].ToString());

            /*Begin: kiểm tra và tạo ozekimessagein & ozekimessageout nếu chưa có.*/
            try
            {
                DataSet ds = dao.ExecuteDataSet("SELECT * FROM " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessageout LIMIT 1");
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("does not exist") != -1)
                {
                    string sqlQuery = "CREATE TABLE " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessagein(id serial NOT NULL,sender character varying(30),receiver character varying(30),msg character varying(160),senttime character varying(100),receivedtime character varying(100),\"operator\" character varying(100),msgtype character varying(160),reference character varying(100),status character varying(20),CONSTRAINT ozekimessagein_id PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH (OIDS=FALSE);";
                    int result = dao.ExecuteQuery(sqlQuery);
                    sqlQuery = "ALTER TABLE " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessagein OWNER TO medisoft;";
                    result = dao.ExecuteQuery(sqlQuery);
                    sqlQuery = "CREATE TABLE " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessageout(id serial NOT NULL,sender character varying(30),receiver character varying(30),msg character varying(160),senttime character varying(100),receivedtime character varying(100),reference character varying(100),status character varying(20),\"operator\" character varying(100),msgtype character varying(160),CONSTRAINT ozekimessageout_id PRIMARY KEY (id) USING INDEX TABLESPACE medi_index) WITH (OIDS=FALSE);";
                    result = dao.ExecuteQuery(sqlQuery);
                    sqlQuery = "ALTER TABLE " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessageout OWNER TO medisoft;";
                    result = dao.ExecuteQuery(sqlQuery);
                }
            }
            /*End: kiểm tra và tạo ozekimessagein & ozekimessageout nếu chưa có.*/

            smsReceiver = new HttpServer(delimiter, datafile, dao);            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitFlag != 2) { exitFlag = 1; btnStop_Click(sender, e); }

            tmrDigitalClock.Enabled = false;
            tmrDigitalClock.Dispose();

            tmrSMSprocess.Enabled = false;
            tmrSMSprocess.Dispose();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifySMS.Visible = true;
                notifySMS.ShowBalloonTip(5000);
                this.Hide();                
            }            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Make UI read only for the duration.
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            starttime = DateTime.Now;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stoptime = DateTime.Now;
            System.TimeSpan duration = stoptime.Subtract(starttime);
            starttime = System.DateTime.MinValue;

            // Have to have this at the end in case you leave app open for more than a day.
            today = DateTime.Now;

            // Write to the file. 
            TextWriter tw = File.AppendText(datafile);

            // Date, Category, ticket number, duration.
            //tw.WriteLine(today.ToString("M/d/yyyy") + delimiter + "0" + delimiter + "" + delimiter + DurationMinutes(duration));
            tw.WriteLine(today.ToString("dd/MM/yyyy HH:mm:ss") + delimiter + "khoảng thời gian thực thi" + delimiter + "SMSagent" + delimiter + DurationMinutes(duration));

            // Close the file.
            tw.Close();

            // Refresh the UI.
            lblTimeCounter.Text = "000 00:00:00";
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            // The user wants to exit the application. Close everything down.
            if (exitFlag != 1) { exitFlag = 2; Application.Exit(); }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //Show data in a DataGridView.
            DataView dv = DataGridViewRender();

            // Write to the file.  
            File.Delete(reportfile);
            TextWriter tw = File.AppendText(reportfile);

            tw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            tw.WriteLine("<?xml-stylesheet type=\"text/xsl\" href=\"TimeSheetReport.xsl\"?>");


            tw.WriteLine("<TimeSheet>");
            tw.WriteLine("<DateRange>");
            tw.WriteLine("Thời gian: " + txtStartDate.Text + " - " + txtEndDate.Text);
            tw.WriteLine("</DateRange>");

            // Date, Category, ticket number, duration.  
            //foreach (DataRow dr in dv.Table.Select(filter))
            foreach (DataRow dr in dv.Table.Select(CreateFilter()))
            {
                tw.WriteLine("<TimeRow>");
                for (int i = 0; i < dr.ItemArray.Length; i++)
                {
                    if (i == 0)
                    {
                        tw.WriteLine("<Date>");
                        DateTime myDT = DateTime.Parse(dr.ItemArray[i].ToString());
                        //tw.WriteLine(myDT.Date.ToShortDateString());
                        tw.WriteLine(myDT.ToString("dd/MM/yyyy HH:mm:ss"));
                        tw.WriteLine("</Date>");
                    }
                    else if (i == 1)
                    {
                        tw.WriteLine("<Code>");
                        tw.WriteLine(dr.ItemArray[i].ToString());
                        tw.WriteLine("</Code>");
                    }
                    else if (i == 2)
                    {
                        tw.WriteLine("<Ticket>");
                        tw.WriteLine(dr.ItemArray[i].ToString());
                        tw.WriteLine("</Ticket>");
                    }
                    else if (i == 3)
                    {
                        tw.WriteLine("<Duration>");
                        tw.WriteLine(dr.ItemArray[i].ToString());
                        tw.WriteLine("</Duration>");
                    }
                }
                tw.WriteLine("</TimeRow>");
            }
            tw.WriteLine("</TimeSheet>");

            // Close the file.
            tw.Close();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            string filedir = Application.StartupPath.ToString();
            string myfile = filedir + "\\" + ConfigurationManager.AppSettings["ReportFile"].ToString();//;ReportFile.xml";
            System.Diagnostics.Process process = new System.Diagnostics.Process();

            // Open Browser with the report as argument.
            System.Diagnostics.Process.Start("IExplore.exe", myfile);
        }

        private void tmrDigitalClock_Tick(object sender, System.EventArgs e)
        {
            if (starttime != System.DateTime.MinValue)
            {
                stoptime = DateTime.Now;
                System.TimeSpan duration = stoptime.Subtract(starttime);

                lblTimeCounter.Text = ReadableDuration(duration);
            }
        }

        private void tmrSMSprocess_Tick(object sender, System.EventArgs e)
        {
            DateTime begintime = DateTime.Now;
            DateTime endtime;

            /*Begin of SMS process.*/
            string sData = "";
            string category = "";
            string isSend = "";
            try
            {
                DataSet ds = dao.ExecuteDataSet("SELECT * FROM " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessageout WHERE status = 'send'");

                String getUri = ConfigurationManager.AppSettings["SendMessageUri"].ToString() + @"&login=" + ConfigurationManager.AppSettings["UserLogin"].ToString() + @"&password=" + ConfigurationManager.AppSettings["UserPassword"].ToString() + @"&recepient=";
                WebRequest request;
                HttpWebResponse response;
                StreamReader responseReader;
                String resultmsg;
                XmlDocument doc;
                XmlNode xmlResponse, xmlData, xmlAcceptReport, xmlStatusCode, xmlMessageID;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    // prepare the web page we will be asking for
                    getUri += row["receiver"].ToString() + @"&messageData=" + row["msg"].ToString();
                    request = (WebRequest)WebRequest.Create(getUri);
                    // execute the request
                    response = (HttpWebResponse)request.GetResponse();
                    //read the response
                    responseReader = new StreamReader(response.GetResponseStream());
                    resultmsg = responseReader.ReadToEnd();
                    responseReader.Close();
                    // Load Xml Response.
                    doc = new XmlDocument();
                    doc.LoadXml(resultmsg.Replace("&lt;", "<").Replace("&gt;", ">"));
                    xmlResponse = doc.DocumentElement;
                    xmlData = xmlResponse.ChildNodes[1];
                    xmlAcceptReport = xmlData.ChildNodes[0];
                    xmlStatusCode = xmlAcceptReport.ChildNodes[0];
                    xmlMessageID = xmlAcceptReport.ChildNodes[2];
                    if (xmlStatusCode.InnerText == "0")
                    {
                        isSend = "gửi";
                        sData += "gửi thành công với id: " + xmlMessageID.InnerText + "; ";
                    }
                    else isSend = "gửi";

                    string isReceive = "";

                    category = (isSend != "" || isReceive != "") ? (isSend + ((isReceive != "") ? "/" : "") + isReceive + " sms") : "kiểm tra sms định kỳ";
                    //Update status into the database.
                    if (xmlStatusCode.InnerText == "0")
                        dao.ExecuteQuery("UPDATE " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessageout SET status='transmitted', senttime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', reference='" + xmlMessageID.InnerText + "' WHERE id = " + row["id"].ToString());
                    else dao.ExecuteQuery("UPDATE " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessageout SET status='deleted' WHERE id = " + row["id"].ToString());
                }
                if (category == "") category = "kiểm tra sms định kỳ";
            }
            catch (Exception ex)
            {
                category = "gửi sms";
                sData = ex.Message;
            }
            /*End of SMS process.*/

            endtime = DateTime.Now;
            System.TimeSpan duration = endtime.Subtract(begintime);
            begintime = System.DateTime.MinValue;

            // Have to have this at the end in case you leave app open for more than a day.
            today = DateTime.Now;

            // Write to the file. 
            TextWriter tw = File.AppendText(datafile);

            // Date, Category, ticket number, duration.
            tw.WriteLine(today.ToString("dd/MM/yyyy HH:mm:ss") + delimiter + category + delimiter + sData + delimiter + DurationMinutes(duration));

            // Close the file.
            tw.Close();

            //Show data in a DataGridView.
            DataGridViewRender();
        }
        
        private void notifySMS_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            notifySMS.Visible = false; //if you want to remove from tray when clicked on.
        }

        private void notifySMS_MouseMove(object sender, MouseEventArgs e)
        {
            notifySMS.ShowBalloonTip(5000);
        }

        private void CheckOutputFile(string strFile)
        {
            // Create the file if doesn't already exist  
            if (!File.Exists(strFile))
            {
                myfile = new FileStream(strFile, FileMode.Create);
                myfile.Close();
            }
        }

        private DataTable CreateTable()
        {
            try
            {
                DataTable inputtable = new DataTable();

                // Declare DataColumn and DataRow variables.
                DataColumn column;

                // Create new DataColumns, set DataType, ColumnName, and add to DataTable.    
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Date";
                inputtable.Columns.Add(column);
                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = "Code";
                inputtable.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Ticket";
                inputtable.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Duration in minutes";
                inputtable.Columns.Add(column);
                return inputtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private double DurationMinutes(System.TimeSpan duration)
        {
            double rc = 0;
            int hours, minutes;
            double seconds;

            hours = Int32.Parse(duration.Hours.ToString());
            minutes = Int32.Parse(duration.Minutes.ToString());
            seconds = Int32.Parse(duration.Seconds.ToString());
            rc = hours * 60 + minutes + seconds / 60.00;
            return rc;
        }

        private DataView DataGridViewRender()
        {
            // Load the DataTable from the file.
            mytable.Clear();
            PopulateTable(mytable);

            // Filter to get the relevant data.
            DataTable outputtable = new DataTable();

            DataView dv = null;

            string filter = CreateFilter();
            try
            {
                dv = new DataView(mytable);
                dv.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filter = " + filter + "\n" + ex.ToString());
            }
            dgvReport.DataSource = dv;
            foreach (DataGridViewColumn column in dgvReport.Columns)
            {
                if (column.HeaderText == "Date") { column.HeaderText = "Ngày"; column.Width = 140; column.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; }
                else if (column.HeaderText == "Code") { column.HeaderText = "Thao tác"; column.Width = 160; }
                else if (column.HeaderText == "Ticket") { column.HeaderText = "Ghi chú"; column.Width = 165; }
                else if (column.HeaderText == "Duration in minutes") { column.HeaderText = "Thời gian"; column.Width = 80; }
            }
            return dv;
        }

        private void PopulateTable(DataTable dtDataTable)
        {
            string contents;
            int tabSize = 4;
            string[] arInfo;
            string line;
            DataRow row;

            try
            {
                string FILENAME = datafile;
                StreamReader objStreamReader;
                objStreamReader = File.OpenText(FILENAME);

                while ((line = objStreamReader.ReadLine()) != null)
                {
                    contents = line; //.Replace(("").PadRight(tabSize, ' '), "\t");

                    // define which character is seperating fields
                    char[] textdelimiter = { delimiter };
                    arInfo = contents.Split(textdelimiter);
                    for (int i = 0; i <= arInfo.Length; i++)
                    {
                        row = dtDataTable.NewRow();
                        if ((i < arInfo.Length) && (arInfo[i].ToString() != null))
                        {
                            //row["Date"] = DateTime.Parse(arInfo[0].ToString());
                            row["Date"] = DateTime.ParseExact(arInfo[0].ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (i + 1 < arInfo.Length)
                        {
                            row["Code"] = arInfo[1].ToString();
                        }
                        if (i + 2 < arInfo.Length)
                        {
                            row["Ticket"] = arInfo[2].ToString();
                        }
                        if (i + 3 < arInfo.Length)
                        {
                            double dbDuration = Double.Parse(arInfo[3].ToString());
                            string strDuration = string.Format("{0:F2}", dbDuration);
                            row["Duration in minutes"] = strDuration;
                            dtDataTable.Rows.Add(row);
                        }
                        i = i + 2;
                    }
                }
                objStreamReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string CreateFilter()
        {
            string start = null, end = null;
            try
            {
                //DateTime.Parse(txtStartDate.Text);
                //start = txtStartDate.Text;
                start = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                //DateTime.Parse(txtEndDate.Text);
                //end = txtEndDate.Text;
                end = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
            }
            catch
            {
                MessageBox.Show("Could not create filter based on input dates. Check format ese."
                    + "\n ");
                return null;
            }
            string filter = null;
            filter = "Date >= '" + start + "' AND Date <= '" + end + "'";
            return filter;
        }

        private string ReadableDuration(System.TimeSpan duration)
        {
            string strDays = null;
            string strHours = null;
            string strMinutes = null;
            string strSeconds = null;
            string strDuration = null;

            // Format for readability.
            strDays = duration.Days.ToString().PadLeft(3, '0');
            strHours = duration.Hours.ToString().PadLeft(2, '0');
            strMinutes = duration.Minutes.ToString().PadLeft(2, '0');
            strSeconds = duration.Seconds.ToString().PadLeft(2, '0');

            strDuration = strDays + " " + strHours + ":" + strMinutes + ":" + strSeconds;
            return strDuration;
        }
    }
}