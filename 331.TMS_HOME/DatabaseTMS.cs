using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace FORM
{
    public class DatabaseTMS
    {
        public DataSet TMS_DELIVERY_GETDATA(string PROC_NAME, string ARG_FAC, string ARG_YMD, string ARG_LINE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = PROC_NAME;
                MyOraDB.ReDim_Parameter(10);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR4";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR5";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR6";
                MyOraDB.Parameter_Name[9] = "OUT_CURSOR7";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[7] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[8] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[9] = (char)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_LINE;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";
                MyOraDB.Parameter_Values[7] = "";
                MyOraDB.Parameter_Values[8] = "";
                MyOraDB.Parameter_Values[9] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }

        public DataSet TMS_DELIVERY_DETAIL(string PROC_NAME, string ARG_FAC,string ARG_OP_CD,string ARG_CMP_CD, string ARG_YMD, string ARG_LINE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = PROC_NAME;
                MyOraDB.ReDim_Parameter(11);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[3] = "ARG_YMD";
                MyOraDB.Parameter_Name[4] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR4";
                MyOraDB.Parameter_Name[9] = "OUT_CURSOR5";
                MyOraDB.Parameter_Name[10] = "OUT_CURSOR6";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[7] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[8] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[9] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[10] = (char)OracleType.Cursor;


                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = ARG_YMD;
                MyOraDB.Parameter_Values[4] = ARG_LINE;
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";
                MyOraDB.Parameter_Values[7] = "";
                MyOraDB.Parameter_Values[8] = "";
                MyOraDB.Parameter_Values[9] = "";
                MyOraDB.Parameter_Values[10] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetDeliveryDetail(string ARG_FAC, string ARG_YMD, string ARG_LINE_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_DELIVERY_DETAIL_SET";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[3] = "";

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

        public DataTable GetDeliveryDetailv1(string ARG_FAC,string ARG_OP_CD,string ARG_CMP_CD, string ARG_YMD, string ARG_LINE_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_DELIVERY_DETAIL_SET_V1";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMO_CD";
                MyOraDB.Parameter_Name[3] = "ARG_YMD";
                MyOraDB.Parameter_Name[4] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = ARG_YMD;
                MyOraDB.Parameter_Values[4] = ARG_LINE_CD;
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

        public DataTable getSetStatus(string ARG_QTYPE,string ARG_OP_CD,string ARG_CMP_CD, string ARG_YMD, string ARG_LINE_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_SET_STATUS_SEL_V1";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[3] = "ARG_YMD";
                MyOraDB.Parameter_Name[4] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = ARG_YMD;
                MyOraDB.Parameter_Values[4] = ARG_LINE_CD;
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

        public DataTable getSetDetailPopup(string ARG_QTYPE, string ARG_YMD, string ARG_LINE_CD,string ARG_STYLE_CD,string ARG_CS_SIZE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_SET_STATUS_POPUP";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_STYLE_CD";
                MyOraDB.Parameter_Name[4] = "ARG_CS_SIZE";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_STYLE_CD;
                MyOraDB.Parameter_Values[4] = ARG_CS_SIZE;
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

        public DataTable getSetDetailPopupV1(string ARG_QTYPE, string ARG_YMD,string ARG_OP_CD,string ARG_CMP_CD, string ARG_LINE_CD, string ARG_STYLE_CD, string ARG_CS_SIZE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_SET_STATUS_POPUP_V1";
                MyOraDB.ReDim_Parameter(8);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[3] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[4] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[5] = "ARG_STYLE_CD";
                MyOraDB.Parameter_Name[6] = "ARG_CS_SIZE";
                MyOraDB.Parameter_Name[7] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_OP_CD;
                MyOraDB.Parameter_Values[3] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[4] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[5] = ARG_STYLE_CD;
                MyOraDB.Parameter_Values[6] = ARG_CS_SIZE;
                MyOraDB.Parameter_Values[7] = "";

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
        public DataTable GetPlant(string ARG_FAC,string ARG_OP_CD, string ARG_CMP_CD, string ARG_YMD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_PLANT_SEL_V1";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[3] = "ARG_YMD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = ARG_YMD;
                MyOraDB.Parameter_Values[4] = "";

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

        public DataTable GetOutScnByTrip(string ARG_O_SCN, string ARG_OP_CD, string ARG_CMP_CD, string ARG_LINE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_TRIP_OUT_SCN_V1";
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_O_SCN";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[3] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_O_SCN;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = ARG_LINE;
                MyOraDB.Parameter_Values[4] = "";

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

        public DataTable GetOutScnByDay(string ARG_FAC,string ARG_OP_CD, string ARG_CMP_CD, string ARG_YMD, string ARG_LINE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_OUT_SCN_BY_DAY_V1";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[3] = "ARG_YMD";
                MyOraDB.Parameter_Name[4] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = ARG_YMD;
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
    }
}
