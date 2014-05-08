namespace MEDISOFT2011.DESKTOP
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class ExceptionLog
    {
        public static void WriteSystemEventLog(DateTime date, string user, string sysEvent, string SampleID)
        {
            FileStream stream = null;
            StreamWriter writer = null;
            try
            {
                stream = File.Open(Application.StartupPath + @"\sysEvent.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                stream.Seek(0L, SeekOrigin.End);
                writer = new StreamWriter(stream);
                StringBuilder builder = new StringBuilder();
                builder.Append(date.ToString());
                builder.Append("\t");
                builder.Append(user + "\t");
                builder.Append(sysEvent + "\t");
                builder.Append(SampleID);
                writer.WriteLine(builder.ToString());
                writer.Close();
                stream.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public static void WriteToFile(string filename, Exception ex)
        {
            try
            {
                XmlWriter writer = XmlWriter.Create(filename);
                writer.WriteStartElement(ex.GetType().FullName);
                writer.WriteElementString("Data", ex.Data.ToString());
                writer.WriteElementString("HelpLink", ex.HelpLink);
                writer.WriteElementString("Message", ex.Message);
                writer.WriteElementString("Source", ex.Source);
                writer.WriteElementString("StackTrace", ex.StackTrace);
                writer.WriteElementString("TargetSite", ex.TargetSite.ToString());
                writer.WriteElementString("Time", DateTime.Now.ToString());
                writer.WriteEndElement();
                writer.Close();
            }
            catch (SerializationException)
            {
            }
            catch (ArgumentNullException)
            {
            }
            catch (ArgumentException)
            {
            }
        }

        public static void WriteToLogFile(Exception exp)
        {
            FileStream stream = null;
            StreamWriter writer = null;
            try
            {
                stream = File.Open(Application.StartupPath + @"\Exception.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                stream.Seek(0L, SeekOrigin.End);
                writer = new StreamWriter(stream);
                writer.WriteLine(DateTime.Now.ToString() + ":\tException \t" + exp.GetType().ToString());
                writer.WriteLine("ExceptionMessage   :\t " + exp.Message);
                writer.WriteLine("ExceptionSource    :\t" + exp.Source);
                writer.WriteLine("ExceptionStackTrace:\t " + exp.StackTrace);
                writer.WriteLine("\n");
                writer.Close();
                stream.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public static void WriteToLogFileSql(SqlException exp)
        {
            FileStream stream = null;
            StreamWriter writer = null;
            try
            {
                stream = File.Open(Application.StartupPath + @"\SqlException.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                stream.Seek(0L, SeekOrigin.End);
                writer = new StreamWriter(stream);
                writer.WriteLine(DateTime.Now.ToString() + ":\tException \t" + exp.GetType().ToString());
                writer.WriteLine("ExceptionMessage   :\t " + exp.Message);
                writer.WriteLine("ExceptionSource    :\t" + exp.Source);
                writer.WriteLine("ExceptionStackTrace:\t " + exp.StackTrace);
                writer.WriteLine("ExceptionNum       :\t" + exp.Number.ToString());
                writer.WriteLine("\n");
            }
            catch (Exception)
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}

