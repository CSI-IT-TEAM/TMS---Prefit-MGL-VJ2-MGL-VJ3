using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace MAIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Ora
        private DataTable VISUAL_IMAGES_SELECT(string ARG_TYPE, string ARG_YMD, string ARG_OP, string ARG_ORD_ID, string ARG_LINE, byte[] ARG_DATA)
        {
            try
            {

                COM.OraDB MyOraDB = new COM.OraDB(1);
                System.Data.DataSet ds_ret;
                string process_name = "LMES.SP_ID_GET_IMAGES";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_OPR";
                MyOraDB.Parameter_Name[3] = "ARG_ORD_ID";
                MyOraDB.Parameter_Name[4] = "ARG_LINE";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_TYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_OP;
                MyOraDB.Parameter_Values[3] = ARG_ORD_ID;
                MyOraDB.Parameter_Values[4] = ARG_LINE;
                MyOraDB.Parameter_Values[5] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (!bgWoker.IsBusy)
                bgWoker.RunWorkerAsync();
            try
            {
                
            }
            catch { }
        }


        private void downloadImages(DataTable dt)
        {
            try
            {
                string subPath = "C:\\IMG1"; // your code goes here
                bool exists = System.IO.Directory.Exists(subPath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(subPath);

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                pgBar.Minimum = 0;
                pgBar.Maximum = dt.Rows.Count;



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] data = webClient.DownloadData(dt.Rows[i]["URL"].ToString());
                        using (MemoryStream mem = new MemoryStream(data))
                        {
                            System.Drawing.Image img = Image.FromStream(mem);
                            img.Save(subPath + "\\" + txtWO.Text + "_" + i + ".png");
                        }
                    }
                    pgBar.Value = (i + 1);
                    
                }

              
            }
            catch { }
        }
        private void BindingImg(string subPath)
        {
            int iCol = -1, iRow = -1;
            while (tblMain.Controls.Count > 0)
                tblMain.Controls.Clear();
            for (int i = 0; i < 9; i++)
            {
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.BackgroundImage = Image.FromFile(subPath + "\\" + txtWO.Text + "_" + i + ".png");
                pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                pictureBox1.Name = "pictureBox_" + (i + 1);
                pictureBox1.TabIndex = i;

                if (iCol <= 2)
                {
                    iCol++;
                    iRow = 0;
                }
                else
                {
                    iCol = 0;
                    iRow++;
                }
                tblMain.Controls.Add(pictureBox1, iCol, iRow);
            }
        }
        private void bgWoker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt = VISUAL_IMAGES_SELECT("Q", "20200611", "FGA", txtWO.Text, "011", null);
            downloadImages(dt);

        }

        private void bgWoker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BindingImg("C:\\IMG1");
            }
            catch { }
        }
    }
}
