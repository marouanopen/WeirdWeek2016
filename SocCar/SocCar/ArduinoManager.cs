using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SocCar
{
    public class ArduinoManager
    {
        private const int connectionSpeed = 9600;
        private SerialPort serialPort;
        public string port;
        GameManager gm;

        public ArduinoManager()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = connectionSpeed;
        }

        public List<string> FillSerialPortSelectionBoxWithAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            List<string> comPorts = new List<string>();
            foreach (String port in ports)
            {
                comPorts.Add(port);
            }
            return comPorts;
        }
        private void Connect()
        {
            try
            {
                serialPort.PortName = port;
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Could not connect to the given serial port: " + exception.Message);
            }
        }
        private bool VerzendBericht(String bericht)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(bericht);
                    return true;
                }
                catch (Exception)
                { }
            }
            return false;
        }
        public void VerwerkBerichten()
        {
            string str = serialPort.ReadLine();
            if (str == "L")
            {
                gm.goal("rood");
            }
            else if (str == "R")
            {
                gm.goal("blauw");
            }
        }


    }
}