# Mrwuying-TempControl-and-MotorControl-Based-on-C51

这是我的课程设计
基于C51温度监控和电机工作系统的设计与实现

文件说明：

TempAutoControlMachineUP.exe	上位机程序

upper machine project by visual studio	上位机Visual studio项目

lower machine code only text	下位机纯文本代码

lower machine code and design drawing	下位机源代码和keil项目文件

使用说明：

下载VSPD虚拟串口模拟，建立COM3,COM4串口

上位机打开COM4，下位机默认是COM3，双击下位机的MAX232模块可以改

上位机功能：

1，温度实时查看

2，控制温度，并夺取下位机的温度显示、控制权，此时改变DS18B20模块的温度不会影响LCD和上位机的温度显示；
需要点击交换温度控制权或者点击下位机复位即可恢复DS18B20的正常工作。

3，可以打开下位机采风，采光电机

4，开光串口，测试警报器这些小功能

下位机功能：

1，温度影响左下直流电机。

[0~10）摄氏度，亮“过冷灯”，电机加速反转；

[10~36]摄氏度，没事发生；

（36~60]摄氏度，电机加速正转；

60度以上，电机加速正转，亮“过热灯”，警报响起；

2，LED状态指示灯显示
