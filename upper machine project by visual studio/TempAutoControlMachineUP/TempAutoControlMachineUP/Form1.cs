using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;

namespace TempAutoControlMachineUP
{   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void getSerialPorts()//从注册表获取端口信息
        {
            RegistryKey keyComm = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            String[] comNames = keyComm.GetValueNames();
            if (comNames.Length != 0)
            {
                foreach (string s in comNames)
                {
                    comboBox_SerialPorts.Items.Add(keyComm.GetValue(s));
                }
                comboBox_SerialPorts.SelectedIndex = 0;
            }

        }
        //=========================combobox，串口初始化，打开按钮==================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            Label_Status.ForeColor = Color.Red;
            comboBox_SerialPorts.Items.Clear();
            getSerialPorts();//获取硬件串口，虚拟硬件
            RegistryKey serialKey = Registry.LocalMachine.OpenSubKey("Software\\TempAutoControl", true);
            if (serialKey == null)
            {
                serialKey = Registry.LocalMachine.CreateSubKey("Software\\TempAutoControl");
            }
            if (serialKey != null)
            {
                serialKey.SetValue("PortSerialNow", 11);
            }
        }

        private void SerialPortOpen_Click(object sender, EventArgs e)
        {
            if (SerialPortOpen.Text.Equals("打开串口"))
            {
                serialPort1.Close();
                serialPort1.PortName = comboBox_SerialPorts.Text.Trim();
                serialPort1.Open();
                SerialPortOpen.BackColor = System.Drawing.Color.MediumVioletRed;
                SerialPortOpen.Text = "关闭串口";
                Label_Status.Text = comboBox_SerialPorts.Text + "打开";
            }
            else
            {

                serialPort1.Close();
                SerialPortOpen.BackColor = System.Drawing.Color.Gray;
                SerialPortOpen.Text = "打开串口";
                Label_Status.Text = comboBox_SerialPorts.Text + "关闭";
            }
        }
        //=========================建立通信==================================================
        delegate void SetTextCallBack(string s);
        private void SetText(string s)//温度传到label，label需要刷新时调用
        {
            if (TempDisplay.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(SetText);
                Invoke(d, new object[] { s });
            }
            else//作用，刷新
            {
                TempDisplay.Text = s.Trim() + "℃";
                TempDisplay.Refresh();
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SetText(serialPort1.ReadLine().Trim());//串口收到温度的信息，传到SetText函数中去
        }
        //=========================按钮事件,全都是判断端口有没有开，然后write line==================================================
        private void RingLing_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                Label_Status.Text = "串口没有打开，请打开串口！！";
                Label_Status.ForeColor = Color.Red;
                return;
            }
            serialPort1.WriteLine("$RING_OPEN");
            Label_Status.Text = "警报器测试";
           
        }
        private void StopRing_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                Label_Status.Text = "串口没有打开，请打开串口！！";
                Label_Status.ForeColor = Color.MediumVioletRed;
                return;
            }
            serialPort1.WriteLine("$RESET");
            Label_Status.Text = "交还温度控制权给下位机，开始采集温度";
        }
        private void TempUp_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                Label_Status.Text = "串口没有打开，请打开串口！！";
                Label_Status.ForeColor = Color.MediumVioletRed;
                return;
            }
            serialPort1.WriteLine("$TEMP_UP");
            Label_Status.Text = "增加1℃，温度控制权在上位机，停止采集温度";
        }

        private void TempDown_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                Label_Status.Text = "串口没有打开，请打开串口！！";
                Label_Status.ForeColor = Color.MediumVioletRed;
                return;
            }
            serialPort1.WriteLine("$TEMP_DOWN");
            Label_Status.Text = "减少1℃，温度控制权在上位机，停止采集温度";
        }

        private void Wind_Switch_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                Label_Status.Text = "串口没有打开，请打开串口！！";
                Label_Status.ForeColor = Color.MediumVioletRed;
                return;
            }
            if (Wind_Switch.Text.Equals("开风机"))
            {
                serialPort1.WriteLine("$WIND_OPEN");
                Label_Status.Text = "风机已开启";
                Wind_Switch.BackColor = Color.AliceBlue;
                Wind_Switch.Text = "关风机";

            }
            else
            {
                serialPort1.WriteLine("$WIND_CLOSE");
                Label_Status.Text = "风机已停止";
                Wind_Switch.BackColor = Color.White;
                Wind_Switch.Text = "开风机";
            }
        }

        private void Light_Switch_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                Label_Status.Text = "串口没有打开，请打开串口！！";
                Label_Status.ForeColor = Color.MediumVioletRed;
                return;
            }
            if (Light_Switch.Text.Equals("开采光"))
            {
                serialPort1.WriteLine("$LIGHT_OPEN");
                Label_Status.Text = "采光已开启";
                Light_Switch.BackColor = Color.Yellow;
                Light_Switch.Text = "关采光";
            }
            else
            {
                serialPort1.WriteLine("$LIGHT_CLOSE");
                Label_Status.Text = "采光已停止";
                Light_Switch.BackColor = Color.White;
                Light_Switch.Text = "开采光";
            }
        }
    }
}
