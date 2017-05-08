using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
namespace my_emguCV_TST
{
    public partial class WelcomeScr : Form
    {
        System.Windows.Forms.Timer tmr;

        public WelcomeScr()
        {
            InitializeComponent();
        }

        private void WelcomeScr_Shown(object sender, EventArgs e)
        {
            
            tmr = new System.Windows.Forms.Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            //Form1 mf = new Form1();
            //mf.Show();
            //hide this form
            this.Close(); 
        }

    }
}
