using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO.Ports;

namespace my_emguCV_TST
{
    public partial class SetUP : Form
    {
        private Capture _capture1 = null;
        private bool _captureInProgress1;
        public SetUP()
        {
            //Point point1 = new Point();
            //Point point2 = new Point();
            //Point point 3 =  new pint();
            InitializeComponent();
            getPortnames();
            CvInvoke.UseOpenCL = false;
            try
            {
                _capture1 = new Capture();
                _capture1.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            _capture1.Retrieve(frame, 0);

            Point Set_point1 = new Point(0, 172);
            Point Set_point2 = new Point(411, 172);
            //yellow line
            CvInvoke.Line(frame, Set_point1, Set_point2, new Bgr(Color.Yellow).MCvScalar, 1);


            CaptureImageBox.Image = frame;

            //System.Threading.Thread.Sleep(100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
         }

        private void Start_Click(object sender, EventArgs e)
        {
            if (_capture1 != null)
            {
                if (_captureInProgress1)
                {  //stop the capture
                    _capture1.Stop();
                    CaptureImageBox.Hide();  
                }
                else
                {
                    //start the capture
                    Start.Text = "Set";
                    _capture1.Start();
                    CaptureImageBox.Show();
                }

                _captureInProgress1 = !_captureInProgress1;
            }
        }

        private void Left_Click(object sender, EventArgs e)
        {
         
            var Start_Command = new byte[] { 0x88, 0x88, 0x88 };//left
            var instance = new my_emguCV_TST.Serial();
            instance.SendCommand(Start_Command);

            //var instance = new DR.Vision_nm.Serial();///////////////////////////////////////////
            //instance.SendCommand(Start_Command);////////////////////////////////////////////////
            //DR.Vision_nm.Serial.
            //SendCommand(Start_Command);
        }

        private void Right_Click(object sender, EventArgs e)
        {
            var Start_Command = new byte[] { 0x99, 0x99, 0x99 };
            var instance = new my_emguCV_TST.Serial();
            instance.SendCommand(Start_Command);
        }

        private void CaptureImageBox_Click(object sender, EventArgs e)
        {

        }

        private void getPortnames()//DISPLAY AVAILABLE PORTS
        {
            String[] ports = SerialPort.GetPortNames();
            cmbSetupPort.Items.AddRange(ports);
        }

        private void btnSetComSetup_Click(object sender, EventArgs e)
        {
            MyGlobals.ComPort = cmbSetupPort.Text;
        }
    }
}
