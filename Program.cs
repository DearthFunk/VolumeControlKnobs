using System;
using System.Text;
using System.IO.Ports;
using System.Timers;

namespace VolControl
{
    class Program
    {
        
        static int keyLength = 2; //adjust for length of control string from arduino
        static String dataBuffer = "";
        static SerialPort port = new SerialPort("COM3", 9600); //, Parity.None, 8, StopBits.One);
        static Device device = new Device();

        public static void Main()
        {

            port.ReceivedBytesThreshold = 1;
            port.RtsEnable = true;
            port.DtrEnable = true;
            port.Open();
            port.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            StartTimer();

        }

        public static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = port.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = port.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
            {
                return;
            }

            dataBuffer += Encoding.UTF8.GetString(data);
            if (dataBuffer.Length >= keyLength)
            {
                String bufferToHandle = dataBuffer.Substring(0, keyLength);
                device.HandleInput(bufferToHandle);
                dataBuffer = dataBuffer.Remove(0, keyLength);
            }
        }

        public static void StartTimer()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10;
            aTimer.Enabled = true;
            Console.WriteLine("Press \'q\' to quit.");
            while (Console.Read() != 'q') ;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {

        }
    }
}