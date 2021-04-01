﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_SMT_MGL_DSF_VJ2 : Form
    {
        public FRM_SMT_MGL_DSF_VJ2()
        {
            InitializeComponent();

        }
        int cCount = 0;
        bool isBack = false;
        private void setImg(int number)
        {
            for (int i = 0; i < number; i++)
            {
                UC.UC_DSF DSF = (UC.UC_DSF)tblLayout.GetControlFromPosition(i, 0);
                DSF.OnTitleClick += clickMenu;
                DSF.image_name(i);
                DSF.LoadImage_final(i);
            }
        }
        private void InitLayout(int number)  
        {

            DataTable dt = new DataTable();
            dt = PRINTING_OS_PRODUCTION_DATA("Q");
            //for (int i = 0; i < tblLayout.ColumnCount; i++)
            //{
            //    UC.UC_DSF DSF = (UC.UC_DSF)tblLayout.GetControlFromPosition(i, 0);
            //    DSF.OnTitleClick += clickMenu;
            //    DSF.image_name(i);
            //    DSF.LoadImage_final(i);
            //}

            for (int i = 0; i < number; i++)
            {
               // UC.UC_DSF DSF = new UC.UC_DSF();
               // DSF.TabIndex = i;
               // tblLayout.Controls.Add(DSF, i, 0);

                UC.UC_DSF DSF = (UC.UC_DSF)tblLayout.GetControlFromPosition(i, 0);
                //DSF.OnTitleClick += clickMenu;
                //DSF.image_name(i);
                //DSF.LoadImage_final(i);

                //if (i == 0)
                //{
                //    if (dt.Select("TYPE = 'PRINTING'", "").Count() > 0 )
                //    { 
                //        DataTable dt_printing = dt.Select("TYPE = 'PRINTING'", "").CopyToDataTable() ;
                //        if(dt_printing.Rows.Count > 0 && dt_printing != null)
                //        { 
                //         DSF.BindingData(dt_printing);
                //        }
                //    }
                //}
                //else if (i == 1)
                //{
                //    if (dt.Select("TYPE = 'HF'", "").Count() > 0)
                //    {
                //        DataTable dt_hf = dt.Select("TYPE = 'HF'", "").CopyToDataTable();
                //        if (dt_hf.Rows.Count > 0 && dt_hf != null)
                //        {
                //            DSF.BindingData(dt_hf);
                //        }
                //    }
                //}
                //else if (i == 2)
                //{
                //    if (dt.Select("TYPE = 'LASER'", "").Count() > 0)
                //    {
                //        DataTable dt_laser = dt.Select("TYPE = 'LASER'", "").CopyToDataTable();
                //        if (dt_laser.Rows.Count > 0 && dt_laser != null)
                //        {
                //            DSF.BindingData(dt_laser);
                //        }
                //    }
                //}
                //else if (i == 3)
                //{
                //    if (dt.Select("TYPE = 'NOSEW'", "").Count() > 0)
                //    {
                //        DataTable dt_nosew = dt.Select("TYPE = 'NOSEW'", "").CopyToDataTable();
                //        if (dt_nosew.Rows.Count > 0 && dt_nosew != null)
                //        {
                //            DSF.BindingData(dt_nosew);
                //        }
                //    }
                //}
                //else if (i == 4)
                //{
                //    if (dt.Select("TYPE = 'EMB'", "").Count() > 0)
                //    {
                //        DataTable dt_emb = dt.Select("TYPE = 'EMB'", "").CopyToDataTable();
                //        if (dt_emb.Rows.Count > 0 && dt_emb != null)
                //        {
                //            DSF.BindingData(dt_emb);
                //        }
                //    }
                //}

                DSF.BindingData(dt);
               // DSF.LoadImage_final(i);
                DSF.Dock = DockStyle.Fill;
            }

          
        }
        void clickMenu(string argFrom)
        {
            FRM_SMT_EMD_UNDER u = new FRM_SMT_EMD_UNDER();
            //switch (((DevExpress.XtraEditors.SimpleButton)sender).TabIndex)
            //{
             
               if (argFrom == "PRINTING")
               {
                    ComVar.Var.callForm = "301"; 
               }
                   
               if (argFrom == "HF")
               {
                   ComVar.Var.callForm = "332";
               }
               if (argFrom == "LASER")
               {
                    ComVar.Var.callForm = "310";
               }
               if (argFrom == "NOSEW")
               {
                   ComVar.Var.callForm = "320"; 
               }
               if (argFrom == "EMB") 
               {
                   ComVar.Var.callForm = "506";
               }
            

        }
          
         
        private void FRM_SMT_MGL_DSF_VJ2cs_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                                                                                         // DataTable _dtXML = null;

            //  _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
            isBack = ComVar.Var._IsBack;
            try 
            {
                for (int i = 0; i < 5; i++)
                {
                    UC.UC_DSF DSF = new UC.UC_DSF();
                    DSF.TabIndex = i;
                    tblLayout.Controls.Add(DSF, i, 0);
                }
                 
               
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
               // InitLayout(5);
                setImg(5);
                InitLayout(5); 
            }
            catch (Exception ex)
            { }

        }
        private void tmr_Tick(object sender, EventArgs e) 
        {
            cCount++; 
            try
            {
               
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                if (cCount >= 60)
                {
                    splashScreenManager1.ShowWaitForm();
                    for (int i = 4; i > 0; i--)
                    {
                        //UC.UC_DSF DSF = new UC.UC_DSF();
                        //  DSF.TabIndex = i;
                      //  tblLayout.Controls.RemoveAt(i);
                    } 
                    InitLayout(5); 
                    cCount = 0;
                    splashScreenManager1.CloseWaitForm();
                }
                
            } 
            catch { splashScreenManager1.CloseWaitForm(); }
            
        }

        private void splMain_Panel1_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }
      
       
        public DataTable PRINTING_OS_PRODUCTION_DATA(string ARG_QTYPE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PRINTING_VJ2_PLANTB.PRINTING_SELECT_MENU";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
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


       // public DevExpress.XtraEditors.SimpleButton sender { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void FRM_SMT_MGL_DSF_VJ2_VisibleChanged(object sender, EventArgs e)
        {
                btnBack.Visible = isBack;
            cCount = 0;
             tmr.Start();
        }

        private void btnPrefit_Cockpit_Click(object sender, EventArgs e)
        {
            ComVar.Var._Frm_Back = "300";
            ComVar.Var.callForm = "600";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmr.Stop();
        }
    }

}
