using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using System.Diagnostics;

namespace FORM
{
    public partial class WaitForm1 : WaitForm
    {
        public WaitForm1()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
            sw.Start();
            timerDuration.Start();
        }
        #region Overrides
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        Stopwatch sw = new Stopwatch();

        private void timerDuration_Tick(object sender, EventArgs e)
        {
           
        }

        public enum WaitFormCommand
        {
        }

        private void timerDuration_Tick_1(object sender, EventArgs e)
        {
            TimeSpan elapsed = sw.Elapsed;
            progressPanel1.Description =String.Format("{00:00}:{1:00}:{2:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds);
        }
    }
}