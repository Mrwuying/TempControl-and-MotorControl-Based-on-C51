namespace TempAutoControlMachineUP
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TempDisplay = new System.Windows.Forms.Label();
            this.StopRing = new System.Windows.Forms.Button();
            this.RingLing = new System.Windows.Forms.Button();
            this.TempUp = new System.Windows.Forms.Button();
            this.comboBox_SerialPorts = new System.Windows.Forms.ComboBox();
            this.SerialPortOpen = new System.Windows.Forms.Button();
            this.TempDown = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.Wind_Switch = new System.Windows.Forms.Button();
            this.Light_Switch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TempDisplay);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(25, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "温度显示";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TempDisplay
            // 
            this.TempDisplay.AutoSize = true;
            this.TempDisplay.Font = new System.Drawing.Font("楷体", 20F);
            this.TempDisplay.Location = new System.Drawing.Point(155, 64);
            this.TempDisplay.Name = "TempDisplay";
            this.TempDisplay.Size = new System.Drawing.Size(152, 27);
            this.TempDisplay.TabIndex = 0;
            this.TempDisplay.Text = "waiting...";
            // 
            // StopRing
            // 
            this.StopRing.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StopRing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopRing.ForeColor = System.Drawing.Color.Red;
            this.StopRing.Location = new System.Drawing.Point(36, 216);
            this.StopRing.Name = "StopRing";
            this.StopRing.Size = new System.Drawing.Size(124, 56);
            this.StopRing.TabIndex = 1;
            this.StopRing.Text = "交还温度控制权";
            this.StopRing.UseVisualStyleBackColor = true;
            this.StopRing.Click += new System.EventHandler(this.StopRing_Click);
            // 
            // RingLing
            // 
            this.RingLing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RingLing.Location = new System.Drawing.Point(348, 216);
            this.RingLing.Name = "RingLing";
            this.RingLing.Size = new System.Drawing.Size(124, 56);
            this.RingLing.TabIndex = 2;
            this.RingLing.Text = "警报器测试";
            this.RingLing.UseVisualStyleBackColor = true;
            this.RingLing.Click += new System.EventHandler(this.RingLing_Click);
            // 
            // TempUp
            // 
            this.TempUp.AutoSize = true;
            this.TempUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempUp.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TempUp.Location = new System.Drawing.Point(224, 202);
            this.TempUp.Name = "TempUp";
            this.TempUp.Size = new System.Drawing.Size(60, 39);
            this.TempUp.TabIndex = 3;
            this.TempUp.Text = "+";
            this.TempUp.UseVisualStyleBackColor = true;
            this.TempUp.Click += new System.EventHandler(this.TempUp_Click);
            // 
            // comboBox_SerialPorts
            // 
            this.comboBox_SerialPorts.FormattingEnabled = true;
            this.comboBox_SerialPorts.Location = new System.Drawing.Point(138, 317);
            this.comboBox_SerialPorts.Name = "comboBox_SerialPorts";
            this.comboBox_SerialPorts.Size = new System.Drawing.Size(86, 20);
            this.comboBox_SerialPorts.TabIndex = 4;
            // 
            // SerialPortOpen
            // 
            this.SerialPortOpen.Location = new System.Drawing.Point(283, 317);
            this.SerialPortOpen.Name = "SerialPortOpen";
            this.SerialPortOpen.Size = new System.Drawing.Size(86, 20);
            this.SerialPortOpen.TabIndex = 5;
            this.SerialPortOpen.Text = "打开串口";
            this.SerialPortOpen.UseVisualStyleBackColor = true;
            this.SerialPortOpen.Click += new System.EventHandler(this.SerialPortOpen_Click);
            // 
            // TempDown
            // 
            this.TempDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempDown.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TempDown.Location = new System.Drawing.Point(224, 261);
            this.TempDown.Name = "TempDown";
            this.TempDown.Size = new System.Drawing.Size(60, 39);
            this.TempDown.TabIndex = 6;
            this.TempDown.Text = "-";
            this.TempDown.UseVisualStyleBackColor = true;
            this.TempDown.Click += new System.EventHandler(this.TempDown_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(526, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Label_Status
            // 
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(128, 17);
            this.Label_Status.Text = "欢迎使用温度检测系统";
            // 
            // Wind_Switch
            // 
            this.Wind_Switch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Wind_Switch.Location = new System.Drawing.Point(168, 5);
            this.Wind_Switch.Name = "Wind_Switch";
            this.Wind_Switch.Size = new System.Drawing.Size(68, 43);
            this.Wind_Switch.TabIndex = 8;
            this.Wind_Switch.Text = "开风机";
            this.Wind_Switch.UseVisualStyleBackColor = true;
            this.Wind_Switch.Click += new System.EventHandler(this.Wind_Switch_Click);
            // 
            // Light_Switch
            // 
            this.Light_Switch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Light_Switch.Location = new System.Drawing.Point(268, 4);
            this.Light_Switch.Name = "Light_Switch";
            this.Light_Switch.Size = new System.Drawing.Size(68, 43);
            this.Light_Switch.TabIndex = 9;
            this.Light_Switch.Text = "开采光";
            this.Light_Switch.UseVisualStyleBackColor = true;
            this.Light_Switch.Click += new System.EventHandler(this.Light_Switch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 382);
            this.Controls.Add(this.Light_Switch);
            this.Controls.Add(this.Wind_Switch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TempDown);
            this.Controls.Add(this.SerialPortOpen);
            this.Controls.Add(this.comboBox_SerialPorts);
            this.Controls.Add(this.TempUp);
            this.Controls.Add(this.RingLing);
            this.Controls.Add(this.StopRing);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "温度检测系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StopRing;
        private System.Windows.Forms.Button RingLing;
        private System.Windows.Forms.Button TempUp;
        private System.Windows.Forms.ComboBox comboBox_SerialPorts;
        private System.Windows.Forms.Button SerialPortOpen;
        private System.Windows.Forms.Button TempDown;
        private System.Windows.Forms.Label TempDisplay;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label_Status;
        private System.Windows.Forms.Button Wind_Switch;
        private System.Windows.Forms.Button Light_Switch;
    }
}

