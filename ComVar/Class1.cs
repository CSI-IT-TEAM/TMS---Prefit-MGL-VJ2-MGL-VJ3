using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OracleClient;

namespace ComVar
{


    
    public class Var
    {
        public delegate void ValueChangedEventHandler(string value);

        public static string _Value;
        public static string _Frm_Curr;
        public static string _Frm_Call;
        public static string _Frm_Back;
        public static List<Tuple<string, string>> _List_Back = new List<Tuple<string, string>>();
        public static bool _IsBack= false;
        public static string _Area ="";

        public static string _strValue1;
        public static string _strValue2;
        public static string _strValue3;
        public static string _strValue4;
        public static string _strValue5;
        public static int _iValue1;
        public static int _iValue2;
        public static int _iValue3;
        public static int _iValue4;
        public static int _iValue5;
        public static double _dValue1;
        public static double _dValue2;
        public static double _dValue3;
        public static double _dValue4;
        public static double _dValue5;
        public static bool _bValue1;
        public static bool _bValue2;
        public static bool _bValue3;
        public static bool _bValue4;
        public static bool _bValue5;

        public static string callForm
        {
            get { return _Value; }
            set
            {
                _Value = value;
                if (ValueChanged != null) ValueChanged(value);
            }
        }

        public static ValueChangedEventHandler ValueChanged;

        public static void writeToLog(string str)
        {
            try
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using (FileStream fs = new FileStream(path + "\\log"+ DateTime.Now.ToString("yyyyMMdd") +".log", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.WriteLine(str);
                }
            }
            catch
            { }

        }

        
    }

    public class Func
    {

        public static Dictionary<string, Tuple<string, string, string, string, string, string>> getInitForm2(string dll_name, string class_name)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            DataTable dt;
            Dictionary<string, Tuple<string, string, string, string, string, string>> dtn = null;
            string process_name = "SEPHIROTH.PROC_STB_GET_FORM_INIT";

            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = process_name;

            MyOraDB.Parameter_Name[0] = "ARG_DLL_NM";
            MyOraDB.Parameter_Name[1] = "ARG_CLASS_NM";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = dll_name;
            MyOraDB.Parameter_Values[1] = class_name;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);
            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret != null)
            {
                dt = ds_ret.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dtn = new Dictionary<string, Tuple<string, string, string, string, string, string>>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtn.Add(dt.Rows[i]["COM_NM"].ToString()
                               , new Tuple<string, string, string, string, string, string>(dt.Rows[i]["COM_VL"].ToString(), dt.Rows[i]["VALUE2"].ToString(), dt.Rows[i]["VALUE3"].ToString()
                                                                                         , dt.Rows[i]["VALUE4"].ToString(), dt.Rows[i]["VALUE5"].ToString(), dt.Rows[i]["VALUE6"].ToString()));
                    }
                }
            }
            return dtn;
        }


        public static Dictionary<string, string> getInitForm(string dll_name, string class_name)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            DataTable dt;
            Dictionary<string, string> dtn = null;
            string process_name = "SEPHIROTH.PROC_STB_GET_FORM_INIT";
                                             
            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = process_name;

            MyOraDB.Parameter_Name[0] = "ARG_DLL_NM";
            MyOraDB.Parameter_Name[1] = "ARG_CLASS_NM";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = dll_name;
            MyOraDB.Parameter_Values[1] = class_name;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);
            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret != null)
            {
                dt = ds_ret.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    dtn = new Dictionary<string, string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtn.Add(dt.Rows[i]["COM_NM"].ToString(), dt.Rows[i]["COM_VL"].ToString());
                    }
                }
            }
            return dtn;
        }

        public static DataTable ReadXML(string file, string name)
        {
            DataTable table = new DataTable(name);
            try
            {
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(file);
                table = lstNode.Tables[name];
                return table;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(file + "/ReadXML  :   " + ex.ToString());
                return table;
            }
        }

        public static DataSet ReadXMLToDs(string file, bool today)
        {
            
            DataSet lstNode = new DataSet();
            try
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\DB_XML\\" + file + ".XML";
                if (today)
                {
                    if (File.GetLastWriteTime(path).Date == DateTime.Now.Date)
                    {
                        lstNode.ReadXml(path, XmlReadMode.ReadSchema);
                    }
                    else
                        lstNode = null;
                }
                else
                {
                    lstNode.ReadXml(path, XmlReadMode.ReadSchema);
                }
                return lstNode;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("ReadXML-->" + file + "   :   " + ex.ToString());
                return null;
            }
        }

        public static void WriteXML(string file, DataSet ds)
        {
            try
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\DB_XML";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (StreamWriter fs = new StreamWriter(path + "\\" + file + ".XML")) 
                {
                    ds.WriteXml(fs, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("WriteXML-->" + file + "   :   " + ex.ToString());               
            }
        }
    }
}
