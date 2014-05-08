using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Configuration;
using DataAccessLayer;

namespace SMSAsync
{
    public class HttpServer
    {
        private HttpListener listener;

        private string datafile;
        private char delimiter;
        private string uriPrefix;
        private PgSqlDAL dao;

        public HttpServer()
        {
            listener = new HttpListener();
            uriPrefix = ConfigurationManager.AppSettings["ReceiveMessageUri"].ToString();
            listener.Prefixes.Add(uriPrefix);//server url
            listener.Start();
            //Start 20 servers
            for (int x = 0; x < 20; x++)
            {
                listener.BeginGetContext(new AsyncCallback(ListenerCallback), this.listener);
            }
        }

        public HttpServer(char v_delimiter, string v_datafile, PgSqlDAL v_dao)
        {
            delimiter = v_delimiter;
            datafile = v_datafile;
            uriPrefix = ConfigurationManager.AppSettings["ReceiveMessageUri"].ToString();
            dao = v_dao;

            listener = new HttpListener();
            listener.Prefixes.Add(uriPrefix);//server url
            listener.Start();
            //Start 20 servers
            for (int x = 0; x < 20; x++)
            {
                listener.BeginGetContext(new AsyncCallback(ListenerCallback), this.listener);
            }
        }

        protected void ListenerCallback(IAsyncResult result)
        {
            if (this.listener == null) return;
            HttpListenerContext context = this.listener.EndGetContext(result);
            //We setup a new context for the next request
            this.listener.BeginGetContext(new AsyncCallback(ListenerCallback), this.listener);
            this.ProcessRequest(context);
            context.Response.Close();
        }

        //Overridable method that can be used to implement a custom handler
        protected virtual void ProcessRequest(HttpListenerContext context)
        {
            string Sender = context.Request.QueryString["sender"];
            string Receiver = context.Request.QueryString["receiver"];
            string Msg = context.Request.QueryString["msg"];
            string ReceiverTime = context.Request.QueryString.Get("recvtime");
            string Operator = context.Request.QueryString.Get("operator");
            string Reference = context.Request.QueryString.Get("id");
            string Type = context.Request.QueryString.Get("msgtype");

            //DataAccessLayer.DataAccessLayerBaseClass dao = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(ConfigurationManager.AppSettings["DataProviderType"].ToString(), ConfigurationManager.AppSettings["ConnectionString"].ToString());
            dao.ExecuteQuery("INSERT INTO " + ConfigurationManager.AppSettings["Schema"].ToString() + "ozekimessagein(sender,receiver,msg,receivedtime,operator,msgtype,reference,status) VALUES('" + Sender + "','" + Receiver + "','" + Msg + "','" + ReceiverTime + "','" + Operator + "','" + Type + "','" + Reference + "','receive')");

            // Write to the file. 
            TextWriter tw = File.AppendText(datafile);
            // Date, Category, ticket number, duration.
            //tw.WriteLine(today.ToString("M/d/yyyy") + delimiter + "0" + delimiter + "" + delimiter + DurationMinutes(duration));
            tw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + delimiter + "nhận sms" + delimiter + "nhận thành công với id " + Reference + delimiter + "0");
            // Close the file.
            tw.Close();

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("{SMS:TEXT}{}{" + Receiver + "}{" + Sender + "}{Nhan luc " + ReceiverTime + ", ID: " + Reference + "}" + System.Environment.NewLine);
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        }
    }
}
