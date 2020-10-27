using System;
using System.Data;
using System.Data.OracleClient;


namespace COM
{
	/// <summary>
	/// ComVar :공통변수 클래스
	/// </summary>
	public class ComVar
	{
		public ComVar()
		{
			
		}


        #region Properties

		public static string This_Factory = "VJ";
        public static string This_CDC_Factory = "DS";
		public static string This_User = "admin";
		public static string This_Domain = @"@dskorea.com";
		public static string This_User_AD = "";
		public static string This_PassWD = "";
        public static string This_Area_CD = "";
        public static string This_Gen = "";
		public static string This_Name = "";
		public static string This_SysJob="P" ;
		public static string This_Lang = "KO";
		public static string This_Admin_YN ="Y";
		public static string This_JobCdoe = "M";
		public static string This_Dept = "120600";
		public static string This_Form = "";
		public static string This_Line = "";
		public static string This_Date = "";
		public static string This_FormDate = "20051017";
		public static string This_ToDate = "";
		public static string This_Order = "";
        public static string This_PowerUser_YN = "";
        public static string This_InsaCd = "";
        public static string This_CDCPower_Level = "";
        public static string This_CDCGroup_Code = "";
        public static string This_Return = "";
		public static string This_ManualLanuage = "";
		#endregion

        public enum Log_Type : int
        {
            Write_File_DB = 0,		// flie 저장 and DB저장
            Write_File = 1,			// flie 저장
            Write_DB = 2,			// DB저장
            Write_NOLog = 3			// log 저장 안함
        }

        #region 웹 서비스 참조 선언

        /// <summary>
        /// 
        /// </summary>
        //public static WebSvc.OraPKG _WebSvc = new WebSvc.OraPKG();
        public static WebSvc.OraPKG _WebSvc = new WebSvc.OraPKG();
        public static SEPHIROTHWebSvc.OraPKG _SephirothWebSvc = new SEPHIROTHWebSvc.OraPKG();
        public static string DS_WebSvc_Url = "";
        public static string QD_WebSvc_Url = "";
        public static string VJ_WebSvc_Url = "";
        public static string JJ_WebSvc_Url = "";
        public static string EIS_WebSvc_Url = "";
        #endregion 

    } 

}
