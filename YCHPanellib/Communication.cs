using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using Basic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Drawing.Drawing2D;

namespace YCHPanellib
{
    public enum ChipType
    {
        ESP32,
        BW16,
    }
    public enum HorizontalAlignment
    {
        Left = 0,
        Right = 1,
        Center = 2
    }
    public class Communication
    {
        static public bool ConsoleWrite = false;
        static public int UDP_TimeOut = 1000;
        static public int UDP_RetryNum = 5;
        static public readonly int Image_Buffer_SIZE = 1200;
        static public ChipType Chip_Type = ChipType.BW16;
        //static public int EPD583_frameDIV = 10;
        public enum enum_LED_Type : int
        {
            WHITE, RED, BLUE, YELLOW, WARM_WHITE
        }
        private enum UDP_Command
        {
            WS2812_Blink = (byte)'5',

            Set_UDP_SendTime = (byte)'F',
      
            Set_ServerConfig = (byte)'H',
            Set_JsonStringSend = (byte)'I',

            Set_WS2812_Buffer = (byte)'L',
            Set_GetewayConfig = (byte)'M',
            Set_LocalPort = (byte)'N',
            Get_WS2812_Buffer = (byte)'O',


              
        }
  

   
        static public bool Set_WS2812_Blink(UDP_Class uDP_Class, string IP, int blinkTime, Color color)
        {
            return Command_WS2812_Blink(uDP_Class, IP, blinkTime, color);
        }   
        static public bool Set_UDP_SendTime(UDP_Class uDP_Class, string IP, int ms)
        {
            return Command_Set_UDP_SendTime(uDP_Class, IP, ms);
        }       
        static public bool Set_WS2812_Buffer(UDP_Class uDP_Class, string IP, int start_ptr, byte[] bytes_RGB)
        {
            return Command_Set_WS2812_Buffer(uDP_Class, IP, start_ptr, bytes_RGB);
        }
        static public byte[] Get_WS2812_Buffer(UDP_Class uDP_Class, string IP , int lenth)
        {
            return Command_Get_WS2812_Buffer(uDP_Class, IP, lenth);
        }
        static public bool Set_GatewayConfig(UDP_Class uDP_Class, string IP, string Geteway)
        {
            return Command_Set_GetewayConfig(uDP_Class, IP, Geteway);
        }
        static public bool Set_LocalPort(UDP_Class uDP_Class, string IP, int LocalPort)
        {
            return Command_Set_LocalPort(uDP_Class, IP, LocalPort);
        }
      
        static private bool Command_WS2812_Blink(UDP_Class uDP_Class, string IP, int blinkTime, Color color)
        {
            bool flag_OK = true;
            byte checksum = 0;

            int R = color.R;
            int G = color.G;
            int B = color.B;
            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)UDP_Command.WS2812_Blink);
            list_byte.Add((byte)(blinkTime));
            list_byte.Add((byte)((blinkTime >> 8)));
            list_byte.Add((byte)(R));
            list_byte.Add((byte)(G));
            list_byte.Add((byte)(B));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(),IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
        
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set_WS2812_Buffer {string.Format(flag_OK ? "sucess" : "failed")}!");
            return flag_OK;
        }       
        static private bool Command_Set_UDP_SendTime(UDP_Class uDP_Class, string IP, int ms)
        {
            bool flag_OK = true;
            byte checksum = 0;
            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Set_UDP_SendTime));
            list_byte.Add((byte)(ms));
            list_byte.Add((byte)((ms >> 8)));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set UDP SendTime {string.Format(flag_OK ? "sucess" : "failed")}!");
            return flag_OK;
        }
    
        static private bool Command_Set_ServerConfig(UDP_Class uDP_Class, string IP, string ServerIP ,int ServerPort)
        {
            bool flag_OK = true;
            byte checksum = 0;

            string[] IP_Array = ServerIP.Split('.');
            if (IP_Array.Length != 4) return false;
            int IPA = IP_Array[0].StringToInt32();
            int IPB = IP_Array[1].StringToInt32();
            int IPC = IP_Array[2].StringToInt32();
            int IPD = IP_Array[3].StringToInt32();
            if (IPA < 0 || IPA > 255) return false;
            if (IPB < 0 || IPB > 255) return false;
            if (IPC < 0 || IPC > 255) return false;
            if (IPD < 0 || IPD > 255) return false;

            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Set_ServerConfig));
            list_byte.Add((byte)(IPA));
            list_byte.Add((byte)(IPB));
            list_byte.Add((byte)(IPC));
            list_byte.Add((byte)(IPD));
            list_byte.Add((byte)(ServerPort));
            list_byte.Add((byte)((ServerPort >> 8)));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set ServerConfig {string.Format(flag_OK ? "sucess" : "failed")}!");
            return flag_OK;
        }
        static private bool Command_Set_JsonStringSend(UDP_Class uDP_Class, string IP)
        {
            bool flag_OK = true;
            byte checksum = 0;
            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Set_JsonStringSend));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set JsonStringSend {string.Format(flag_OK ? "sucess" : "failed")}!");
            return flag_OK;
        }
      
        static private bool Command_Set_WS2812_Buffer(UDP_Class uDP_Class, string IP, int start_ptr, byte[] bytes_RGB)
        {
            bool flag_OK = true;
            byte checksum = 0;
            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Set_WS2812_Buffer));
            list_byte.Add((byte)start_ptr);
            list_byte.Add((byte)(start_ptr >> 8));
            for (int i = 0; i < bytes_RGB.Length; i++)
            {
                list_byte.Add(bytes_RGB[i]);
            }
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set_WS2812_Buffer {string.Format(flag_OK ? "sucess" : "failed")}!");
            return flag_OK;
        }
        static private byte[] Command_Get_WS2812_Buffer(UDP_Class uDP_Class, string IP , int lenth)
        {
            bool flag_OK = true;
            byte checksum = 0;
            byte[] Dbyte = new byte[lenth];
            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Get_WS2812_Buffer));
            list_byte.Add((byte)lenth);
            list_byte.Add((byte)(lenth >> 8));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                       
                        byte[] bytes_buf = Encoding.GetEncoding("BIG5").GetBytes(UDP_RX);
                        for (int i = 0; i < bytes_buf.Length; i++)
                        {
                            if (i > Dbyte.Length) break;
                            Dbyte[i] = bytes_buf[i];
                        }
                        break;
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Get WS2812_Buffer {string.Format(flag_OK ? "sucess" : "failed")}!");
            return Dbyte;
        }
        static private bool Command_Set_GetewayConfig(UDP_Class uDP_Class, string IP, string Geteway)
        {
            bool flag_OK = true;
            byte checksum = 0;

            string[] IP_Array = Geteway.Split('.');
            if (IP_Array.Length != 4) return false;
            int IPA = IP_Array[0].StringToInt32();
            int IPB = IP_Array[1].StringToInt32();
            int IPC = IP_Array[2].StringToInt32();
            int IPD = IP_Array[3].StringToInt32();
            if (IPA < 0 || IPA > 255) return false;
            if (IPB < 0 || IPB > 255) return false;
            if (IPC < 0 || IPC > 255) return false;
            if (IPD < 0 || IPD > 255) return false;

            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Set_GetewayConfig));
            list_byte.Add((byte)(IPA));
            list_byte.Add((byte)(IPB));
            list_byte.Add((byte)(IPC));
            list_byte.Add((byte)(IPD));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set GetewayConfig {string.Format(flag_OK ? "sucess" : "failed")}!");
            return flag_OK;
        }
        static private bool Command_Set_LocalPort(UDP_Class uDP_Class, string IP, int LocalPort)
        {
            bool flag_OK = true;
            byte checksum = 0;


            List<byte> list_byte = new List<byte>();
            list_byte.Add(2);
            list_byte.Add((byte)(UDP_Command.Set_LocalPort));
            list_byte.Add((byte)(LocalPort));
            list_byte.Add((byte)((LocalPort >> 8)));
            list_byte.Add(3);
            for (int i = 0; i < list_byte.Count; i++)
            {
                checksum += list_byte[i];
            }
            MyTimer MyTimer_UART_TimeOut = new MyTimer();
            int retry = 0;
            int cnt = 0;
            while (true)
            {
                if (cnt == 0)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    uDP_Class.Set_ReadLineClearByIP(IP);
                    uDP_Class.WriteByte(list_byte.ToArray(), IP);
                    MyTimer_UART_TimeOut.TickStop();
                    MyTimer_UART_TimeOut.StartTickTime(UDP_TimeOut);
                    cnt++;
                }
                else if (cnt == 1)
                {
                    if (retry >= UDP_RetryNum)
                    {
                        flag_OK = false;
                        break;
                    }
                    if (MyTimer_UART_TimeOut.IsTimeOut())
                    {
                        retry++;
                        cnt = 0;
                    }
                    string UDP_RX = uDP_Class.Get_ReadLineByIP(IP);
                    if (UDP_RX != "")
                    {
                        if (UDP_RX == checksum.ToString("000"))
                        {
                            flag_OK = true;
                            break;
                        }
                        else
                        {
                            cnt = 0;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            if (ConsoleWrite) Console.WriteLine($"{IP}:{uDP_Class.Port} : Set LocalPort {string.Format(flag_OK ? "sucess" : "failed")}! Port : {LocalPort}");
            return flag_OK;
        }
       


        #region UART
        static private int UART_TimeOut = 1000;
        static private int UART_RetryNum = 3;
        private enum UART_Command
        {
            Get_Setting = (byte)'0',
            Set_Station = (byte)'1',
            Set_IP_Adress = (byte)'2',
            Set_Subnet = (byte)'3',
            Set_Gateway = (byte)'4',
            Set_DNS = (byte)'5',
            Set_Server_IP_Adress = (byte)'6',
            Set_Local_Port = (byte)'7',
            Set_Server_Port = (byte)'8',
            Set_SSID = (byte)'9',
            Set_Password = (byte)'A',
            Set_UDP_SendTime = (byte)'B',

            Sset_RFID_Enable = (byte)'Z',
        }
        static public bool UART_Command_Get_Setting(MySerialPort MySerialPort, out string IP_Adress, out string Subnet, out string Gateway, out string DNS, out string Server_IP_Adress, out string Local_Port, out string Server_Port, out string SSID, out string Password, out string Station, out string UDP_SendTime ,out string RFID_Enable)
        {
            bool flag_OK = false;
            IP_Adress = "";
            Subnet = "";
            Gateway = "";
            DNS = "";
            Server_IP_Adress = "";
            Local_Port = "";
            Server_Port = "";
            SSID = "";
            Password = "";
            Station = "";
            UDP_SendTime = "";
            RFID_Enable = "";
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer myTimer_Timeout = new MyTimer();
                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Get_Setting));
                list_byte.Add(3);
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write("Receive data lenth error!\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_RX[0] == 2 && UART_RX[UART_RX.Length - 1] == 3)
                            {
                                string str = "";
                                for (int i = 1; i < (UART_RX.Length - 1); i++)
                                {
                                    str += (char)UART_RX[i];
                                }
                                string[] str_array = str.Split(',');
                                if (str_array.Length == 12)
                                {
                                    IP_Adress = str_array[0];
                                    Subnet = str_array[1];
                                    Gateway = str_array[2];
                                    DNS = str_array[3];
                                    Server_IP_Adress = str_array[4];
                                    Local_Port = str_array[5];
                                    Server_Port = str_array[6];
                                    SSID = str_array[7];
                                    Password = str_array[8];
                                    Station = str_array[9];
                                    UDP_SendTime = str_array[10];
                                    RFID_Enable = str_array[11];
                                    if (ConsoleWrite) Console.Write("Receive data sucessed!\n");
                                    flag_OK = true;
                                    break;
                                }
                                else
                                {
                                    retry++;
                                    cnt = 0;
                                }

                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Get_Setting(MySerialPort MySerialPort, out string IP_Adress, out string Subnet, out string Gateway, out string DNS, out string Server_IP_Adress, out string Local_Port, out string Server_Port, out string SSID, out string Password, out string Station, out string UDP_SendTime)
        {
            bool flag_OK = false;
            IP_Adress = "";
            Subnet = "";
            Gateway = "";
            DNS = "";
            Server_IP_Adress = "";
            Local_Port = "";
            Server_Port = "";
            SSID = "";
            Password = "";
            Station = "";
            UDP_SendTime = "";
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer myTimer_Timeout = new MyTimer();
                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Get_Setting));
                list_byte.Add(3);
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write("Receive data lenth error!\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_RX[0] == 2 && UART_RX[UART_RX.Length - 1] == 3)
                            {
                                string str = "";
                                for (int i = 1; i < (UART_RX.Length - 1); i++)
                                {
                                    str += (char)UART_RX[i];
                                }
                                string[] str_array = str.Split(',');
                                if (str_array.Length == 11)
                                {
                                    IP_Adress = str_array[0];
                                    Subnet = str_array[1];
                                    Gateway = str_array[2];
                                    DNS = str_array[3];
                                    Server_IP_Adress = str_array[4];
                                    Local_Port = str_array[5];
                                    Server_Port = str_array[6];
                                    SSID = str_array[7];
                                    Password = str_array[8];
                                    Station = str_array[9];
                                    UDP_SendTime = str_array[10];
                                    if (ConsoleWrite) Console.Write("Receive data sucessed!\n");
                                    flag_OK = true;
                                    break;
                                }
                                else
                                {

                                    retry++;
                                    cnt = 0;
                                }

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Station(MySerialPort MySerialPort, int station)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Station));
                list_byte.Add((byte)(station >> 0));
                list_byte.Add((byte)(station >> 8));
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! station: {station}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! station : {station}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_IP_Adress(MySerialPort MySerialPort, string IP)
        {
            bool flag_OK = false;
            if (!IP.Check_IP_Adress())
            {
                return false;
            }
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                byte[] IP_bytes = IP2Bytes(IP);

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_IP_Adress));
                list_byte.Add(IP_bytes[0]);
                list_byte.Add(IP_bytes[1]);
                list_byte.Add(IP_bytes[2]);
                list_byte.Add(IP_bytes[3]);
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! IP: {IP}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! IP : {IP}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Subnet(MySerialPort MySerialPort, string IP)
        {
            bool flag_OK = false;
            if (!IP.Check_IP_Adress())
            {
                return false;
            }
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                byte[] IP_bytes = IP2Bytes(IP);

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Subnet));
                list_byte.Add(IP_bytes[0]);
                list_byte.Add(IP_bytes[1]);
                list_byte.Add(IP_bytes[2]);
                list_byte.Add(IP_bytes[3]);
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! Subnet: {IP}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! Subnet : {IP}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Gateway(MySerialPort MySerialPort, string IP)
        {
            bool flag_OK = false;
            if (!IP.Check_IP_Adress())
            {
                return false;
            }
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                byte[] IP_bytes = IP2Bytes(IP);

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Gateway));
                list_byte.Add(IP_bytes[0]);
                list_byte.Add(IP_bytes[1]);
                list_byte.Add(IP_bytes[2]);
                list_byte.Add(IP_bytes[3]);
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! Gateway: {IP}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! Gateway : {IP}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_DNS(MySerialPort MySerialPort, string IP)
        {
            bool flag_OK = false;
            if (!IP.Check_IP_Adress())
            {
                return false;
            }
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                byte[] IP_bytes = IP2Bytes(IP);

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_DNS));
                list_byte.Add(IP_bytes[0]);
                list_byte.Add(IP_bytes[1]);
                list_byte.Add(IP_bytes[2]);
                list_byte.Add(IP_bytes[3]);
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! DNS: {IP}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! DNS : {IP}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Server_IP_Adress(MySerialPort MySerialPort, string IP)
        {
            bool flag_OK = false;
            if (!IP.Check_IP_Adress())
            {
                return false;
            }
            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                byte[] IP_bytes = IP2Bytes(IP);

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Server_IP_Adress));
                list_byte.Add(IP_bytes[0]);
                list_byte.Add(IP_bytes[1]);
                list_byte.Add(IP_bytes[2]);
                list_byte.Add(IP_bytes[3]);
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! Server IP: {IP}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! Server IP : {IP}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Local_Port(MySerialPort MySerialPort, int port)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Local_Port));
                list_byte.Add((byte)(port >> 0));
                list_byte.Add((byte)(port >> 8));
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! LocalPort : {port}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! LocalPort : {port}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Server_Port(MySerialPort MySerialPort, int port)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Server_Port));
                list_byte.Add((byte)(port >> 0));
                list_byte.Add((byte)(port >> 8));
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! ServerPort: {port}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! ServerPort : {port}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_SSID(MySerialPort MySerialPort, string ssid)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                char[] chars = ssid.ToCharArray();
                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_SSID));
                for (int i = 0; i < chars.Length; i++)
                {
                    list_byte.Add((byte)chars[i]);
                }
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! SSID: {ssid}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! SSID : {ssid}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_Password(MySerialPort MySerialPort, string password)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;
                char[] chars = password.ToCharArray();
                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_Password));
                for (int i = 0; i < chars.Length; i++)
                {
                    list_byte.Add((byte)chars[i]);
                }
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! Password: {password}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! Password : {password}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_UDP_SendTime(MySerialPort MySerialPort, int ms)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Set_UDP_SendTime));
                list_byte.Add((byte)(ms >> 0));
                list_byte.Add((byte)(ms >> 8));
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! UDP SendTime: {ms}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed! UDP SendTime : {ms}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }
        static public bool UART_Command_Set_RFID_Enable(MySerialPort MySerialPort, int Disenable)
        {
            bool flag_OK = false;

            if (MySerialPort.SerialPortOpen())
            {
                MyTimer MyTimer_UART_TimeOut = new MyTimer();
                int retry = 0;
                int cnt = 0;
                byte checksum = 0;

                MySerialPort.ClearReadByte();
                List<byte> list_byte = new List<byte>();
                list_byte.Add(2);
                list_byte.Add((byte)(UART_Command.Sset_RFID_Enable));
                list_byte.Add((byte)(Disenable >> 0));
                list_byte.Add(3);

                for (int i = 0; i < list_byte.Count; i++)
                {
                    checksum += list_byte[i];
                }


                while (true)
                {
                    if (cnt == 0)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            if (ConsoleWrite) Console.Write($"Set data error! RFID Disenable: {Disenable}\n");
                            flag_OK = false;
                            break;
                        }
                        MySerialPort.WriteByte(list_byte.ToArray());
                        MyTimer_UART_TimeOut.TickStop();
                        MyTimer_UART_TimeOut.StartTickTime(UART_TimeOut);
                        cnt++;
                    }
                    if (cnt == 1)
                    {
                        if (retry >= UART_RetryNum)
                        {
                            flag_OK = false;
                            break;
                        }
                        if (MyTimer_UART_TimeOut.IsTimeOut())
                        {
                            retry++;
                            cnt = 0;
                        }
                        byte[] UART_RX = MySerialPort.ReadByte();
                        if (UART_RX != null)
                        {
                            if (UART_CheckSum(UART_RX, checksum))
                            {
                                if (ConsoleWrite) Console.Write($"Set Data sucessed!  RFID Disenable : {Disenable}\n");
                                flag_OK = true;
                                break;

                            }
                        }

                    }

                    System.Threading.Thread.Sleep(1);
                }
            }
            MySerialPort.SerialPortClose();
            return flag_OK;
        }


        static private bool UART_CheckSum(byte[] UART_RX, byte checksum)
        {
            if (UART_RX.Length == 3)
            {
                string str = "";
                str += (char)UART_RX[0];
                str += (char)UART_RX[1];
                str += (char)UART_RX[2];
                byte temp = 0;

                byte.TryParse(str, out temp);
                if (temp == checksum) return true;
            }
            return false;
        }
        #endregion

      
        static private byte[] IP2Bytes(string IP)
        {
            byte[] bytes = new byte[4];
            string[] str = IP.Split('.');
            if (str.Length == 4)
            {
                byte.TryParse(str[0], out bytes[0]);
                byte.TryParse(str[1], out bytes[1]);
                byte.TryParse(str[2], out bytes[2]);
                byte.TryParse(str[3], out bytes[3]);
            }
            return bytes;
        }
    }
}
