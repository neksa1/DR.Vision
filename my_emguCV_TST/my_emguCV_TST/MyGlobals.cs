using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace my_emguCV_TST
{
    public class MyGlobals
    {
        //public const int flag = 0;
        public static Point point11 = new Point(700, 700);
        public static Point point22 = new Point(0, 0);
        static int _globalValue = 0;
        public static bool var_start = true;
        public static bool var_msgbox = false;
        public static string ComPort = "COMPORT";
        public static string Stop_OnError= "AUTO";
        public static int Err_Num = 5;


        public void SetPort(string ComPort )
        {
            int a = 1;
        }



        public static int flag
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }
    }
}
