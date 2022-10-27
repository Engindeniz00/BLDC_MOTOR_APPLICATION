using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LED_CONTROL
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);
        
        public Form1()
        {
            InitializeComponent();
            _serialPort.Handshake = Handshake.None;
            _serialPort.WriteTimeout = 500;
        }

        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Makes sure serial port is open before trying to write  
            try
            {
                if (!(_serialPort.IsOpen))
                    _serialPort.Open();
                //_serialPort.Write("SI\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
            }
        }
        private delegate void SetTextDeleg(string text);
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            string data = _serialPort.ReadLine();
            // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.  
            // ---- The "si_DataReceived" method will be executed on the UI thread which allows populating of the textbox.  
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }
        private void si_DataReceived(string data) { textBox1.Text = data.Trim(); }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == SystemColors.Control) 
            {
                _serialPort.Write("led1 on");
                button1.BackColor = Color.Coral;
            }
            else 
            {
                _serialPort.Write("led1 off");
                button1.BackColor = SystemColors.Control;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == SystemColors.Control)
            {
                _serialPort.Write("led2 on");
                button1.BackColor = Color.Coral;
            }
            else
            {
                _serialPort.Write("led2 off");
                button1.BackColor = SystemColors.Control;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == SystemColors.Control)
            {
                _serialPort.Write("led3 on");
                button1.BackColor = Color.Coral;
            }
            else
            {
                _serialPort.Write("led3 off");
                button1.BackColor = SystemColors.Control;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == SystemColors.Control)
            {
                _serialPort.Write("led4 on");
                button1.BackColor = Color.Coral;
            }
            else
            {
                _serialPort.Write("led4 off");
                button1.BackColor = SystemColors.Control;
            }
        }
    }
}
