using System;
using System.Data;
using System.Data.OracleClient;



namespace COM
{
	/// <summary>
	/// ComFunction : Phuoc.iT
	/// </summary>
	public class ComFunction
	{
		public ComFunction()
		{
		}

		#region Webservice URL

		public static void Change_WebService_URL(string arg_factory)
		{
			try
			{

				switch(arg_factory)
				{
					case "DS":
						COM.ComVar._WebSvc.Url = COM.ComVar.DS_WebSvc_Url;
						break;

					case "QD":
						COM.ComVar._WebSvc.Url = COM.ComVar.QD_WebSvc_Url;
						break;

					case "VJ":
						COM.ComVar._WebSvc.Url = COM.ComVar.VJ_WebSvc_Url;
						break;

					case "JJ":
						COM.ComVar._WebSvc.Url = COM.ComVar.JJ_WebSvc_Url;
						break;

					case "EIS":
						COM.ComVar._WebSvc.Url = COM.ComVar.EIS_WebSvc_Url;
						break;

				}


			}
			catch
			{
				COM.ComVar._WebSvc.Url = COM.ComVar.DS_WebSvc_Url;
				//COM.ComFunction.User_Message(ex.Message, "Change_WebService_URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 

		}

		#endregion

        public static string[] Set_UserInfo(ComVar.Log_Type LType)
        {
            string[] info = new string[5];

            info[0] = ComVar.This_Factory.ToString();
            info[1] = ComVar.This_User.ToString();
            info[2] = ComVar.This_SysJob.ToString();
            info[3] = "";
            info[4] = ((int)LType).ToString();

            return info;
        }
	}




}
