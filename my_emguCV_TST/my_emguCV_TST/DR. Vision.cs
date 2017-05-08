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
    public partial class Form1 : Form
    {
        //private SerialPort port;
        private Capture _capture = null;
        private bool _captureInProgress;
        private bool _run = false;
        public int brojac = 0;
       
   



        public Form1()
        {
            //Point point1 = new Point();
            //Point point2 = new Point();
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            getPortnames();
            ProgramSetings();

            try
            {
                _capture = new Capture();
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //YOU START HERE MA MAN
            //setUP FORM DOSN'T WORK
            //Image _caper = new Emgu.CV.Capture();

            


            Mat frame = new Mat();
            Mat frame2 = new Mat();
            _capture.Retrieve(frame, 0);
            frame2 = frame.Clone();

            Point Set_point1 = new Point(0, 240);
            Point Set_point2 = new Point(640, 240);
            //yellow line
            CvInvoke.Line(frame2, Set_point1, Set_point2, new Bgr(Color.Yellow).MCvScalar, 1);

            Mat grayFrame = new Mat();
            //COLOR 2 GRAY
            CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray);
            Mat smallGrayFrame = new Mat();
            CvInvoke.PyrDown(grayFrame, smallGrayFrame);
            Mat smoothedGrayFrame = new Mat();
            CvInvoke.PyrUp(smallGrayFrame, smoothedGrayFrame);

            //Image<Gray, Byte> smallGrayFrame2 = grayFrame.PyrDown();
            //Image<Gray, Byte> smoothedGrayFrame = smallGrayFrame.PyrUp();
            Mat cannyFrame = new Mat();
            //FIND EDGES 
            CvInvoke.Canny(smoothedGrayFrame, cannyFrame, 110, 30);//100, 30 PARAMETERS 
            //LINE SEGMENTATION 
            LineSegment2D[] lines = CvInvoke.HoughLinesP(
               cannyFrame,
               1, //Distance resolution in pixel-related units
               Math.PI / 45.0, //Angle resolution measured in radians.
               1, //threshold
               1,//30 //min Line width
               0);//1 //gap between lines
            //VARIABLES 
            List<LineSegment2D> linesnew = new List<LineSegment2D>();
            List<LineSegment2D> linestemp = new List<LineSegment2D>();
            List<LineSegment2D> linestemp2 = new List<LineSegment2D>();
            List<LineSegment2D> linesfail = new List<LineSegment2D>();
            List<LineSegment2D> linesend = new List<LineSegment2D>();
            List<LineSegment2D> linesend2 = new List<LineSegment2D>();
            List<LineSegment2D> linesfail_forgood = new List<LineSegment2D>();

            if (MyGlobals.flag == 0)
            {
                MyGlobals.flag = 1;
            }
            //ROUGH THRESHOLDING in 200 - 350
            foreach (LineSegment2D line in lines)
            {
                if (line.P1.Y > 200 && line.P1.Y < 350)//200, 300
                {
                    linestemp.Add(line);
                    //        if (line.P1.X < MyGlobals.point11.X)
                    //        {
                    //            //linesnew.Add(line);
                    //            MyGlobals.point11.X = line.P1.X;
                    //        }
                    //        if (line.P1.Y < MyGlobals.point11.Y)
                    //        {
                    //            //linesnew.Add(line);
                    //            MyGlobals.point11.Y = line.P1.Y;
                    //            //MyGlobals.point22.Y = line.P1.Y;
                    //        }
                    //        if (line.P2.X > MyGlobals.point22.X)
                    //        {
                    //            //linesnew.Add(line);
                    //            MyGlobals.point22.X = line.P2.X;
                    //            MyGlobals.point22.Y = line.P2.Y;
                    //        }
                    //        if (line.P2.Y > MyGlobals.point22.Y)
                    //        {
                    //            //linesnew.Add(line);
                    //            //MyGlobals.point22.Y = line.P1.Y;//2
                    //        }
                    //        if (line.P1.Y > MyGlobals.point11.Y + 20)//10ok//3
                    //        {
                    //            linesfail.Add(line);
                    //        }
                }
            }
            double sum = 0;
            double avg = 0;
            //FIND REFF LINE
            foreach (LineSegment2D line in linestemp)
            {
                sum = sum + ((line.P1.Y + line.P2.Y) / 2);
                avg = (double)Math.Round(sum / linestemp.LongCount());//avg value Y
            }
            //SEPARATE LINES 
            foreach (LineSegment2D line in linestemp)
            {
                if (line.P1.Y < (avg + 2) && line.P2.Y < (avg + 2))//(line.P1.Y < (avg + 10) && line.P2.Y < (avg + 10))
                {                                                   //(line.P1.Y < (avg + 3) && line.P2.Y < (avg + 3))
                    linestemp2.Add(line);//LINES OK
                }
                else if (line.P1.Y >= (avg + 2) && line.P2.Y <= (avg + 10))
                {
                    //if (line.P1.Y < (avg + 2))
                    linesfail.Add(line);
                }
                

            }
            sum = 0;
            avg = 0;
            //SECOND AVG
            foreach (LineSegment2D line in linestemp2)
            {
                sum = sum + ((line.P1.Y + line.P2.Y) / 2);
                avg = (double)Math.Round(sum / linestemp2.LongCount());
            }

            //FIND TOP Y VALUE
            //int TEMPPP = 0;
            //foreach (LineSegment2D line in lines)
            //{
            //    if (line.P1.Y > TEMPPP)
            //    {
            //        TEMPPP = line.P1.Y;
            //        if (line.P2.Y > TEMPPP)
            //        {
            //            TEMPPP = line.P2.Y;
            //        }
            //    }
            //}

            //SECOND SEPARATION 
            int X_end = 0;//TOP RIGHT X 
            int X_start = 640;//BOTTOM LEFT X
            foreach (LineSegment2D line in linestemp2)
            {
                if (line.P1.Y <= (avg + 2) && line.P2.Y <= (avg + 2))//(line.P1.Y < (avg + 10) && line.P2.Y < (avg + 10))
                {                                                   //(line.P1.Y < (avg + 3) && line.P2.Y < (avg + 3))
                    linesnew.Add(line);
                    if (line.P2.X > X_end)
                    {
                        X_end = line.P2.X;//FIND TOP
                    }
                    else if (line.P1.X < X_start)
                    {
                        X_start = line.P1.X;//FIND BOTTOM
                    }
                }
                else if (line.P1.Y >= (avg + 2) && line.P2.Y < (avg + 10))//10 p2
                {
                   // if()
                    linesfail.Add(line);
                }
            }

            Mat lineImage = new Mat(cannyFrame.Size, DepthType.Cv8U, 3);
            lineImage.SetTo(new MCvScalar(0));
            //SHOW OK LINES
            //green lines
            foreach (LineSegment2D line in linesnew)
                CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Green).MCvScalar, 1);
            //SHOW AVG LINE IF NECESSARY
            //yellow line
            //CvInvoke.Line(lineImage, MyGlobals.point11, MyGlobals.point22, new Bgr(Color.Yellow).MCvScalar, 1);
            //SHOW LINESFAIL
            //cyan lines
            //foreach (LineSegment2D line in linesfail)
            //    CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Cyan).MCvScalar, 1);

            //SEPARATE LINESFAIL ON LINESEND AND REAL LINESFAIL
            foreach (LineSegment2D line in linesfail)
            {
                if ((line.P2.X > (X_end - 20) || line.P2.X < (X_end + 20)) && X_end < 639) //|| ((line.P1.X > (X_start - 10) || line.P1.X < (X_start + 10)) && X_start < 1))
                {
                    linesend.Add(line);
                }
                else if ((line.P1.X > (X_start - 20) || line.P1.X < (X_start + 20)) && X_start > 1)
                {
                    linesend2.Add(line);
                }
                else
                {
                    linesfail_forgood.Add(line);
                }
            }

            //FIND POINTS FOR SURROUNDING RECTANGLE 
            Point pointrect1 = new Point(700, 700); //700,700
            Point pointrect2 = new Point(0, 0);
            Point pointrect = new Point(0, 0);
            foreach (LineSegment2D line in linesfail_forgood)
            {
                if (line.P1.X < pointrect1.X)
                {
                    pointrect1.X = line.P1.X;
                }
                if (line.P1.Y < pointrect1.Y)
                {
                    pointrect1.Y = line.P1.Y;
                }
                if (line.P2.X > pointrect2.X)
                {
                    pointrect2.X = line.P2.X;
                }
                if (line.P2.Y > pointrect2.Y)
                {
                    pointrect2.Y = line.P2.Y;
                }
            }
            pointrect.X = pointrect1.X - 6;//ENLARGE RECTANGLE BY 6
            pointrect.Y = pointrect1.Y - 6;
            Size rectsize = new Size((pointrect2.X - pointrect1.X) + 12, (pointrect2.Y - pointrect1.Y) + 12);
            Rectangle rect = new Rectangle(pointrect, rectsize);

            //SHOW LINESEND IF EXIST
            foreach (LineSegment2D line in linesend)
                CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Yellow).MCvScalar, 1);
            //SHOW REAL LINESFAIL
            foreach (LineSegment2D line in linesfail_forgood)
                CvInvoke.Line(lineImage, line.P1, line.P2, new Bgr(Color.Cyan).MCvScalar, 1);
            //FAILING CONDITION !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (!(pointrect.X == (700 - 2) && pointrect.Y == (700 - 2)) && (linesend.Capacity == 0 || linesend2.Capacity == 0) && linesfail_forgood.Count > 2)
            {
                //SHOW RECTANGLE
                CvInvoke.Rectangle(lineImage, rect, new Bgr(Color.Red).MCvScalar, 1);
                MyGlobals.var_msgbox = true;
                brojac = brojac + 1;
 
            }
            //SHOW BAD
            if (MyGlobals.var_msgbox == true && brojac > MyGlobals.Err_Num)
            {
               
                show_bad1();
            }

            //SOME BLOB SHIT (IGNORE)
            //CvInvoke.Line(lineImage, new Point(0, pointrect1.Y), new Point(700,pointrect1.Y), new Bgr(Color.Cyan).MCvScalar, 1);
            //var webcamThreshImg = GrayImage2.ThresholdBinary(new Gray(100), new Gray(155));//150, 255
            //Emgu.CV.Cvb.CvBlobs resultingWebcamBlobs = new Emgu.CV.Cvb.CvBlobs();
            //Emgu.CV.Cvb.CvBlobDetector bDetect = new Emgu.CV.Cvb.CvBlobDetector();
            //uint numWebcamBlobsFound = bDetect.Detect(webcamThreshImg, resultingWebcamBlobs);
            //var blobImg = bDetect.DrawBlobs(webcamThreshImg, resultingWebcamBlobs, Emgu.CV.Cvb.CvBlobDetector.BlobRenderType.BoundingBox, 0.5);


            CaptureImageBox.Image = frame2;
            GrayscaleImageBox.Image = frame;
            SmoothedGrayscaleImageBox.Image = cannyFrame;
            CannyImageBox.Image = lineImage;

            //System.Threading.Thread.Sleep(100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MyGlobals.ComPort == "COMPORT")
            {
                MessageBox.Show("Prvo unesite vaš COM port");
            }
            else
            {
                if (_capture != null)
                {
                    if (_captureInProgress)
                    {  //stop the capture
                        button1.Text = "Camera ON";
                        _capture.Pause();
                        MyGlobals.point11.X = 700;
                        MyGlobals.point11.Y = 700;
                        MyGlobals.point22.X = 0;
                        MyGlobals.point22.Y = 0;
                    }
                    else
                    {
                        //start the capture
                        button1.Text = "Camera OFF";
                        _capture.Start();
                        //_capture.SetCaptureProperty.Height(345);
                        
                    }
                    _captureInProgress = !_captureInProgress;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//left
        {
            if (MyGlobals.ComPort == "COMPORT")
            {
                MessageBox.Show("Prvo unesite vaš COM port");
            }
            else
            {
                var Start_Command = new byte[] { 0x88, 0x88, 0x88 };
                var instance = new my_emguCV_TST.Serial();
                instance.SendCommand(Start_Command);
                

            }
        }      

        private void button4_Click(object sender, EventArgs e)//start
        {

            
            if (MyGlobals.ComPort == "COMPORT")
                {
                MessageBox.Show("Prvo unesite vaš COM port");
                }
            else if (button1.Text == "Camera OFF")
                {
                brojac = 0;
                var Start_Command = new byte[] { 0xAB, 0x11, 0x99 };
                var instance = new my_emguCV_TST.Serial();
                instance.SendCommand(Start_Command);
                MyGlobals.var_start = true;                    // ne znam zasto sam stavio    ali znam ja

                }
            else
              {
                MessageBox.Show("Camera must be ON");
              }

            
        }

        private void button3_Click(object sender, EventArgs e)//right
        {
            if (MyGlobals.ComPort == "COMPORT")
            {
                MessageBox.Show("Prvo unesite vaš COM port");
            }
            else
            {
                var Start_Command = new byte[] { 0x99, 0x99, 0x99 };
                var instance = new my_emguCV_TST.Serial();
                instance.SendCommand(Start_Command);
            }


        }

        private void btnSetCom_Click(object sender, EventArgs e)
        {

            
            MyGlobals.Stop_OnError = cmbErrorStop.Text;
            try
            {
                MyGlobals.Err_Num = Convert.ToInt32(txtErr_nums.Text);
            }
            catch
            {
                MessageBox.Show("Polje \"Broj grešaka\" mora sadržati broj!");
            }
            MyGlobals.ComPort = AvPort.Text;
            brojac = 0;

        }

        private void getPortnames()//DISPLAY AVAILABLE PORTS
        {
            String[] ports = SerialPort.GetPortNames();
            AvPort.Items.AddRange(ports);
        }

        private void show_bad1()//SHOW BAD
        {
            if (!(MyGlobals.Stop_OnError == "MAN") && MyGlobals.var_start == true)
            {
                var Stop_Command = new byte[] { 0xAB, 0x00, 0x99 };//SEND STOP COMMAND
                var instance = new my_emguCV_TST.Serial();
                instance.SendCommand(Stop_Command);

                ///Mnozine...
                #region
                string mnozine= "Nesto";
                if (brojac > 2 && brojac < 6)
                {
                    mnozine = " greške!!!";
                }
                else if (brojac > 5)
                {
                    mnozine = "grešaka!!!";
                }
                else
                {
                    mnozine = "grešku!!!";
                }
                #endregion///Mnozine...

                brojac = brojac - 1;

                               
                Application.Run(new MessageBoxBad());

                //MessageBox.Show("NEISPRAVAN \nSadrži:  " + brojac.ToString() +" "+ mnozine);
                MyGlobals.var_msgbox = false;
                MyGlobals.var_start = false;
                System.Threading.Thread.Sleep(100);
                //var Start_Command2 = new byte[] { 0xAB, 0x11, 0x99 };//SEND START COMMAND
                //var instance2 = new my_emguCV_TST.Serial();
                //instance2.SendCommand(Start_Command2);
                //System.Threading.Thread.Sleep(100);
                brojac = 0;
            }
            else
            {

            }
            }

        void ProgramSetings()
        {
            CaptureImageBox.Enabled = false;
            GrayscaleImageBox.Enabled = false;
            SmoothedGrayscaleImageBox.Enabled = false;
            CannyImageBox.Enabled = false;
            


        }

        private void Br_Gresaka_MouseHover(object sender, EventArgs e)
        {
            string greske = brojac.ToString();
            Br_Gresaka.Text = greske;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            var Stop_Command = new byte[] { 0xAB, 0x00, 0x99 };//SEND STOP COMMAND
            var instance = new my_emguCV_TST.Serial();
            instance.SendCommand(Stop_Command);
            MyGlobals.var_msgbox = false;
            MyGlobals.var_start = false;
            System.Threading.Thread.Sleep(100);
        }

        private void maxLeft_Click(object sender, EventArgs e)
        {
            if (MyGlobals.ComPort == "COMPORT")
            {
                MessageBox.Show("Prvo unesite vaš COM port");
            }
            else
            {
                var Start_Command = new byte[] { 0x44, 0x44, 0x44 };
                var instance = new my_emguCV_TST.Serial();
                instance.SendCommand(Start_Command);
            }
        }

        private void maxRight_Click(object sender, EventArgs e)
        {
            if (MyGlobals.ComPort == "COMPORT")
            {
                MessageBox.Show("Prvo unesite vaš COM port");
            }
            else
            {
                var Start_Command = new byte[] { 0x66, 0x66, 0x66 };
                var instance = new my_emguCV_TST.Serial();
                instance.SendCommand(Start_Command);

            }
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            var Stop_Command = new byte[] { 0xAB, 0x00, 0x99 };//SEND STOP COMMAND
            var instance = new my_emguCV_TST.Serial();
            instance.SendCommand(Stop_Command);
            MyGlobals.var_msgbox = false;
            MyGlobals.var_start = false;
            System.Threading.Thread.Sleep(100);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.NumPad6)
                {
                     if (MyGlobals.ComPort == "COMPORT")
                      {
                          MessageBox.Show("Prvo unesite vaš COM port");
                      }
                     else
                      {
                          var Start_Command = new byte[] { 0x88, 0x88, 0x88 };
                          var instance = new my_emguCV_TST.Serial();
                          instance.SendCommand(Start_Command);
                          //MessageBox.Show("Levo");
                      }    
                }
                if (e.KeyCode == Keys.NumPad4)
                {
                   if (MyGlobals.ComPort == "COMPORT")
                    {
                          MessageBox.Show("Prvo unesite vaš COM port");
                    }
                   else
                    {
                         var Start_Command = new byte[] { 0x99, 0x99, 0x99 };
                         var instance = new my_emguCV_TST.Serial();
                         instance.SendCommand(Start_Command);
                         //MessageBox.Show("desno");
                    }
                }
                if (e.KeyCode == Keys.NumPad1)
                {
                     if (MyGlobals.ComPort == "COMPORT")
                     {
                          MessageBox.Show("Prvo unesite vaš COM port");
                     }
                     else if (button1.Text == "Camera OFF")
                     {
                          brojac = 0;
                          var Start_Command = new byte[] { 0xAB, 0x11, 0x99 };
                          var instance = new my_emguCV_TST.Serial();
                          instance.SendCommand(Start_Command);
                          MyGlobals.var_start = true;                    // ne znam zasto sam stavio    ali znam ja
                          //MessageBox.Show("Start");
                     }
                     else
                     {
                        MessageBox.Show("Camera must be ON");
                     }
                 }
                if (e.KeyCode == Keys.NumPad0)
                {
                      var Stop_Command = new byte[] { 0xAB, 0x00, 0x99 };//SEND STOP COMMAND
                      var instance = new my_emguCV_TST.Serial();
                      instance.SendCommand(Stop_Command);
                      MyGlobals.var_msgbox = false;
                      MyGlobals.var_start = false;
                      System.Threading.Thread.Sleep(100);
                }
                 if (e.KeyCode == Keys.NumPad3)
                {
                     if (MyGlobals.ComPort == "COMPORT")
                     {
                         MessageBox.Show("Prvo unesite vaš COM port");
                     }
                     else
                      {
                           var Start_Command = new byte[] { 0x44, 0x44, 0x44 };
                           var instance = new my_emguCV_TST.Serial();
                           instance.SendCommand(Start_Command);
                           //MessageBox.Show("MaxLeft");
                       }
                 }
                 if (e.KeyCode == Keys.NumPad2)
                 {
                       if (MyGlobals.ComPort == "COMPORT")
                       {
                             MessageBox.Show("Prvo unesite vaš COM port");
                       }
                      else
                       {
                            var Start_Command = new byte[] { 0x66, 0x66, 0x66 };
                            var instance = new my_emguCV_TST.Serial();
                            instance.SendCommand(Start_Command);
                            //MessageBox.Show("MaxRight");
                       }
                 }
            
        }


    }



        //public void button2_MouseDown(object sender, EventArgs e)
        //{
        //    _run = true;
        //    MyAction();
        //}
        //public void button2_MouseUp(object sender, EventArgs e)
        //{
        //    _run = false;
        //}
        //public void MyAction()
        //{
        //    while (_run)
        //    {
        //        var Start_Command = new byte[] { 0x88, 0x88, 0x88 };//left
        //        var instance = new DR.Vision_nm.Serial();

        //        instance.SendCommand(Start_Command);
        //        System.Threading.Thread.Sleep(50);
        //    }
        //}

    
}

