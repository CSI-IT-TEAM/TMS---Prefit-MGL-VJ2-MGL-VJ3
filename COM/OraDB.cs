using System;
using System.Data;
using System.Data.OracleClient;

namespace COM
{
    public class OraDB
    {

        #region Properties
        private DataSet DS_Select = new DataSet("Parameter DataSet");
        private DataSet DS_Modify = new DataSet("Modify DataSet");
        private DataSet DS_Run = new DataSet("Run DataSet");
        private DataSet DS_Ret = new DataSet("Return DataSet");
        public string Process_Name;
        public string[] Parameter_Name;
        public int[] Parameter_Type;
        public string[] Parameter_Values;
        public string[] Parameter_Matrix;
        int DefaultWebsvc = 2;
        #endregion


        public OraDB()
        {
            //Default là SEPHIROTH Service
            DefaultWebsvc = 2;
        }
        public OraDB(int webSvc)
        {
            DefaultWebsvc = webSvc;
        }
        public void ReDim_Parameter(int arg_count)
        {
            this.Parameter_Name = new string[arg_count];
            this.Parameter_Type = new int[arg_count];
            this.Parameter_Values = new string[arg_count];
        }
        private void Clear_Select_DataSet()
        {
            DS_Select.Reset();
        }

        private void Clear_Run_DataSet()
        {
            DS_Run.Reset();
        }

        public void Clear_Modify_DataSet()
        {
            DS_Modify.Reset();
        }



        public bool Add_Select_Parameter(bool AfterClear)
        {
            DataTable DT_Select = new DataTable(Process_Name);
            DataColumn[] dc = new DataColumn[3];

            try
            {
                dc[0] = new DataColumn("Parameter_Name", Type.GetType("System.String"));
                dc[1] = new DataColumn("Parameter_Type", Type.GetType("System.Int32"));
                dc[2] = new DataColumn("Parameter_Value", Type.GetType("System.String"));
                DT_Select.Columns.AddRange(dc);

                for (int i = 0; i < Parameter_Name.Length; i++)
                {
                    DataRow newRow = DT_Select.NewRow();

                    newRow["Parameter_Name"] = Parameter_Name[i];
                    newRow["Parameter_Type"] = (int)Parameter_Type[i];
                    newRow["Parameter_Value"] = (Parameter_Values[i] == null) ? "" : Parameter_Values[i];
                    DT_Select.Rows.Add(newRow);

                }
                if (AfterClear) this.Clear_Select_DataSet();
                DS_Select.Tables.Add(DT_Select);
                return true;
            }
            catch
            {
                return false;
            }


        }



        public bool Add_Run_Parameter(bool AfterClear) //string Process_Name, string[]  Parameter_Name, int[] Parameter_Type, string[] Parameter_Values)
        {
            DataTable DT_Run = new DataTable(Process_Name);
            DataColumn[] dc = new DataColumn[3];
            try
            {
                dc[0] = new DataColumn("Parameter_Name", Type.GetType("System.String"));
                dc[1] = new DataColumn("Parameter_Type", Type.GetType("System.Int32"));
                dc[2] = new DataColumn("Parameter_Value", Type.GetType("System.String"));
                DT_Run.Columns.AddRange(dc);

                for (int i = 0; i < Parameter_Name.Length; i++)
                {
                    DataRow newRow = DT_Run.NewRow();

                    newRow["Parameter_Name"] = Parameter_Name[i];
                    newRow["Parameter_Type"] = (int)Parameter_Type[i];
                    newRow["Parameter_Value"] = (Parameter_Values[i] == null) ? "" : Parameter_Values[i];
                    DT_Run.Rows.Add(newRow);

                }
                if (AfterClear) this.Clear_Run_DataSet();
                DS_Run.Tables.Add(DT_Run);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool Add_Modify_Parameter(bool AfterClear)
        {
            DataTable DT_Modify = new DataTable(Process_Name);
            DataColumn[] dc = new DataColumn[Parameter_Name.Length];

            int row, col;

            try
            {
                for (int i = 0; i < Parameter_Name.Length; i++)
                {
                    dc[i] = new DataColumn(Parameter_Name[i], Type.GetType("System.String"));
                }
                DT_Modify.Columns.AddRange(dc);

                col = 0;
                DataRow newRow = DT_Modify.NewRow();

                for (row = 0; row < Parameter_Values.Length; row++)
                {

                    newRow[col] = (Parameter_Values[row] == null) ? "" : Parameter_Values[row].ToString();
                    col = col + 1;
                    if (col == Parameter_Name.Length)
                    {
                        DT_Modify.Rows.Add(newRow);
                        col = 0;

                        if (row < (Parameter_Values.Length - 1)) newRow = DT_Modify.NewRow();
                    }

                }
                if (AfterClear) this.Clear_Modify_DataSet();
                this.DS_Modify.Tables.Add(DT_Modify);
                return true;
            }
            catch
            {
                return false;
            }


        }

        public DataSet Exe_Select_Procedure()
        {

            string[] RunUser;

            try
            {
                RunUser = ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
                if (DefaultWebsvc == 1)
                    DS_Ret = ComVar._WebSvc.Ora_Select_Procedure(RunUser, this.DS_Select);
                else
                    DS_Ret = ComVar._SephirothWebSvc.Ora_Select_Procedure(RunUser, this.DS_Select);
                if (DS_Ret.DataSetName == "ERROR")
                {
                    return null;

                }
                else
                {
                    return DS_Ret;
                }

            }
            catch (System.Threading.ThreadAbortException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }



        public DataSet Exe_Run_Procedure()
        {
            string[] RunUser;
            try
            {
                RunUser = ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
                if (DefaultWebsvc == 1)
                    DS_Ret = ComVar._WebSvc.Ora_Run_Procedure(RunUser, this.DS_Run);
                else
                    DS_Ret = ComVar._SephirothWebSvc.Ora_Run_Procedure(RunUser, this.DS_Run);

                if (DS_Ret.DataSetName == "ERROR")
                    return null;
                else
                    return DS_Ret;


            }
            catch (Exception)
            {
                return null;
            }

        }









        /// <summary>
        /// Exe_Modify_Procedure : º¹¼ö°³ÀÇ DataTableÀ» ÀÌ¿ëÇÏ¿© ¸¹Àº µ¥ÀÌÅÍ¸¦ ÀúÀå
        /// </summary>
        /// <returns>Á¤»ó : DataSet ,¿À·ù : null</returns>
        public DataSet Exe_Modify_Procedure()
        {
            //DataSet DS_Ret = new DataSet();
            string[] RunUser;

            try
            {
                RunUser = ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
                if (DefaultWebsvc == 1)
                    DS_Ret = ComVar._WebSvc.Ora_Modify_Procedure(RunUser, this.DS_Modify);
                else
                    DS_Ret = ComVar._SephirothWebSvc.Ora_Modify_Procedure(RunUser, this.DS_Modify);
                if (DS_Ret.DataSetName == "ERROR")		// ¿À·ù°¡ Return
                {
                    string err_msg = "";
                    for (int i = 0; i < DS_Ret.Tables.Count; i++)
                    {
                        DataRow dr = DS_Ret.Tables[i].Rows[0];
                        err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n";
                        err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n";
                    }
                    return null;

                }
                else
                {
                    return DS_Ret;
                }

            }
            catch
            {
                return null;
            }
        }




        public bool Exe_Modify_Procedure_all()
        {
            string[] RunUser;

            try
            {
                RunUser = ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
                if (DefaultWebsvc==1)
                DS_Ret = ComVar._WebSvc.Ora_Modify_Procedure(RunUser, this.DS_Modify);
                else
                    DS_Ret = ComVar._SephirothWebSvc.Ora_Modify_Procedure(RunUser, this.DS_Modify);
                if (DS_Ret.DataSetName == "ERROR")		// ¿À·ù°¡ Return
                {
                    string err_msg = "";
                    for (int i = 0; i < DS_Ret.Tables.Count; i++)
                    {
                        DataRow dr = DS_Ret.Tables[i].Rows[0];
                        err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n";
                        err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n";
                    }
                    return false;

                }
                else
                {
                    if (DS_Ret == null) return false;
                    else return true;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool Exe_Modify_Procedure_Blob(byte[] BlobData)
        {

            try
            {
                bool ret;
                if (DefaultWebsvc==1)
                    ret=ComVar._WebSvc.Ora_Run_Procedure_Blob(Process_Name, Parameter_Name, Parameter_Type, Parameter_Values, BlobData);
                else
                    ret = ComVar._SephirothWebSvc.Ora_Run_Procedure_Blob(Process_Name, Parameter_Name, Parameter_Type, Parameter_Values, BlobData);
                return ret;
            }
            catch
            {
                return false;
            }
        }

        public DataSet Exe_Select_Query(string SqlTxt)
        {
            string[] RunUser;

            try
            {
                RunUser = ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
                if (DefaultWebsvc == 1)
                DS_Ret = ComVar._WebSvc.Ora_Select(RunUser, SqlTxt);
                else
                    DS_Ret = ComVar._SephirothWebSvc.Ora_Select(RunUser, SqlTxt);
                if (DS_Ret.DataSetName == "ERROR")		// ¿À·ù°¡ Return
                {
                    string err_msg = "";
                    for (int i = 0; i < DS_Ret.Tables.Count; i++)
                    {
                        DataRow dr = DS_Ret.Tables[i].Rows[0];
                        err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n";
                        err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n";
                    }
                    return DS_Ret;

                }
                else
                {
                    return DS_Ret;
                }

            }
            catch
            {
                return null;
            }


        }


    }
}
