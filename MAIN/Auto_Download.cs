using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace MAIN
{
    class Auto_Download
    {

        DataTable _dtXML = null;
        NetworkCredential _credentials = new NetworkCredential("ftpsystem", "csiftpsystem");
        string _exePath = "";
        public void DowloadFile()
        {
            _exePath = Path.GetDirectoryName(Application.ExecutablePath);
            _dtXML = ReadXML(Application.StartupPath + "\\config.XML");
            LoadData();
        }


        #region Read File XML
        private DataTable ReadXML(string file)
        {
            DataTable table = new DataTable(this.GetType().Name);
            try
            {
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(file);
                table = lstNode.Tables[this.GetType().Name];
                return table;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "/ReadXML  :   " + ex.ToString());
                return table;
            }
        }
        #endregion Read File XML

        #region DB
        private DataTable SEL_DATA()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "PROC_GET_INFOR_DOWNLOAD_V2";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_PROGAME";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = _dtXML.Rows[0]["grpFORM"].ToString();
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        #endregion DB


        public void CheckingFolder(string arg_folder)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + arg_folder))
                Directory.CreateDirectory(Environment.CurrentDirectory + arg_folder);
        }

        private void killProcess(string argProcess)
        {
            Process[] processlist = Process.GetProcessesByName(argProcess);
            foreach (Process theprocess in processlist)
            {
                theprocess.Kill();
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = SEL_DATA();

                killProcess(dt.Rows[0]["FILE_NAME"].ToString());
                string ftpDirectory, fileName, folder;
                int irow = dt.Rows.Count;
                DateTime tiLastModifiedSever, tiLastModifiedLocal;

                for (int i = 0; i < irow; i++)
                {
                    folder = dt.Rows[i]["FOLDER"].ToString();
                    fileName = dt.Rows[i]["FILE_NAME"].ToString();
                    ftpDirectory = dt.Rows[i]["FTP_DIRECTORY"].ToString();
                    CheckingFolder(folder);
                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpDirectory + fileName);                      
                        request.Credentials = _credentials;
                        request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                        using (FtpWebResponse aResponse = (FtpWebResponse)request.GetResponse())
                        {
                                tiLastModifiedSever = aResponse.LastModified;
                                tiLastModifiedLocal = System.IO.File.GetLastWriteTime(_exePath + folder + "\\" + fileName);
                        }
                       
                        if (tiLastModifiedSever != tiLastModifiedLocal)
                        {
                            DownloadFTP(ftpDirectory, folder, fileName);
                            File.SetLastWriteTime(_exePath + folder + "\\" + fileName, tiLastModifiedSever);
                        }
                    }
                    catch (Exception ex)
                    {
                        ComVar.Var.writeToLog(this.GetType().Name + "/LoadData :    " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "/LoadData  :   " + ex.ToString());
            }
            finally
            {
                //  Thread.Sleep(500);
                // this.Close();
            }
        }

        private void DownloadFTP(string arg_directory, string arg_folder, string arg_file_name)
        {
            try
            {
                WebRequest request = WebRequest.Create(arg_directory + arg_file_name);
                request.Credentials = _credentials;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                {
                    using (Stream fileStream = File.Create(_exePath + arg_folder + "\\" + arg_file_name))
                    {
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, read);
                        }
                    }
                }
            }
            catch (Exception ex)
            { ComVar.Var.writeToLog(this.GetType().Name + "/DownloadFTP /" + arg_file_name + "    :    " + ex.ToString()); }
        }

    }
}
