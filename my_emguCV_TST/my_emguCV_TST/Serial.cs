using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
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

namespace my_emguCV_TST
{
    public class Serial
    {
        private SerialPort port;
        public static bool errorflag = false;
        public Serial()
        {
            try
            {
                this.port = new SerialPort(MyGlobals.ComPort, 38400, Parity.None, 8, StopBits.One);
                this.port.WriteTimeout = 2000; port.ReadTimeout = 2000;


                this.port.Open();

                //this.port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            }
            catch
            {
                MessageBox.Show("Izabrali ste pogrešan port");
                MyGlobals.ComPort = "COMPORT";
                errorflag = true;
            }
            
        }
        public void SendCommand(byte[] command)
        {
            try
            {
                this.port.Write(command, 0, command.Length);
                port.Close();
                //string chars = "";
                //foreach (byte charbyte in command) chars += (char)charbyte;
                //Console.WriteLine(" -> " + chars);
            }
            catch
            {
                MessageBox.Show("Unesite vaš COM port");
                MyGlobals.ComPort = "COMPORT";
                errorflag = true;
                
            }
        }
    }
}
