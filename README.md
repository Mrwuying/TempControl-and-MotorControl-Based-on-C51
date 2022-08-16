### 简介
  这是我大二时的一个课程设计，利用proteus 8 professional上进行仿真开发C51的项目，keil 4 编写C51代码
  下位机仿真图：
   ![image](https://github.com/Mrwuying/TempControl-and-MotorControl-Based-on-C51/blob/master/%E4%B8%8B%E4%BD%8D%E6%9C%BAPCB%E4%BB%BF%E7%9C%9F.png)
   上位机程序图：
   ![image](https://github.com/Mrwuying/TempControl-and-MotorControl-Based-on-C51/blob/master/%E4%B8%8A%E4%BD%8D%E6%9C%BA%E7%A8%8B%E5%BA%8F%E9%A2%84%E8%A7%88.png)

### 主要功能有：
根据温度控制电机正转、反转。
根据温度亮报警灯和蜂鸣器。
上位机控制。
文件说明
TempAutoControlMachineUP.exe 上位机程序
upper machine project by visual studio 上位机Visual studio项目，C#编写
lower machine code and design drawing 下位机源代码和keil项目的文件夹，存放着虚拟接线和keil项目代码

### 使用说明
1、VSPD虚拟串口模拟，建立COM3,COM4串口

2、上位机打开COM4，下位机默认是COM3，双击下位机的MAX232模块可以更改默认端口
3、打开TempAutoControlMachineUP.exe，打开lower machine code and design drawing下的DSN文件，DSN文件打开方式proteus 8 professional

DSN文件打开如图：

4、上位机选择COM4端口，下位机仿真的温度数据会显示在上位机，并且能够控制下位机的事件

当上位机加减温度后，温度控制权在上位机，仿真图中的温度模拟控件不工作

### 上位机功能
1、温度实时查看
2、控制温度，并夺取下位机的温度显示、控制权，此时改变DS18B20模块的温度不会影响LCD和上位机的温度显示； 需要点击交换温度控制权或者点击下位机复位即可恢复DS18B20的正常工作。
3、可以打开下位机采风，采光电机
4、开关串口，测试警报器这些小功能

### 下位机功能
1、温度影响左下直流电机。
  [0~10)摄氏度，亮“过冷灯”，电机加速反转；
  [10~36]摄氏度，没事发生；
  (36~60]摄氏度，电机加速正转；
  60度以上，电机加速正转，亮“过热灯”，警报响起；
2、LED状态指示灯显示
