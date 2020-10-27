using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace MAIN
{
    class DBLog
    {
        public Boolean INSERT_FRM_LOG(string ARG_PGM_CD, string ARG_PGM_NM, string ARG_FRM_CD, string ARG_FRM_NM, string ARG_REMARK, string ARG_UPD_USER)
        {

            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(6);
            MyOraDB.Process_Name = "MES.PKG_SMT_B1_PHUOC.SAVE_FRM_LOG";

            MyOraDB.Parameter_Name[0] = "ARG_PGM_CD";
            MyOraDB.Parameter_Name[1] = "ARG_PGM_NM";
            MyOraDB.Parameter_Name[2] = "ARG_FRM_CD";
            MyOraDB.Parameter_Name[3] = "ARG_FRM_NM";
            MyOraDB.Parameter_Name[4] = "ARG_REMARK";
            MyOraDB.Parameter_Name[5] = "ARG_UPD_USER";

            for (int i = 0; i <= 5; i++)
                MyOraDB.Parameter_Type[i] = (char)OracleType.VarChar;

            MyOraDB.Parameter_Values[0] = ARG_PGM_CD;
            MyOraDB.Parameter_Values[1] = ARG_PGM_NM;
            MyOraDB.Parameter_Values[2] = ARG_FRM_CD;
            MyOraDB.Parameter_Values[3] = ARG_FRM_NM;
            MyOraDB.Parameter_Values[4] = ARG_REMARK;
            MyOraDB.Parameter_Values[5] = ARG_UPD_USER;

            MyOraDB.Add_Modify_Parameter(true);

            retDS = MyOraDB.Exe_Modify_Procedure();

            if (retDS == null) return false;

            return true;
        }
    }
}
