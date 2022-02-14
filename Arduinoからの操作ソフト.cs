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

namespace Arduinoシリアル通信監視アプリ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                comboBox1.SelectedItem = port;
                serialPort1.Close();
                serialPort1.PortName = port;
                serialPort1.Open();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Arduinoシリアル通信監視アプリ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            string port = (String)comboBox1.SelectedItem;
            Console.WriteLine(port);
            serialPort1.PortName = port;
            serialPort1.Open();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort1.ReadLine();
                if (!string.IsNullOrEmpty(data))
                {
                    Console.WriteLine(data);

                    var proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = @"開きたい.exeのファイルパスを入力";
                    proc.Start();
                    System.Threading.Thread.Sleep(100);　　　　　 //遅延
                    SendKeys.SendWait("{実行したいキーを入力}");　//キーボードの操作
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
