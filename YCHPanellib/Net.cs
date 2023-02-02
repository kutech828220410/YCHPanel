using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Basic;
namespace YCHPanellib
{
    static public class Net
    {
       

        static public bool ConnectTest(string IP)
        {
            return ConnectTest(IP, 200);
        }
        static public bool ConnectTest(string IP, int timeout)
        {
            bool flag_ok = false;
            if (!IP.Check_IP_Adress())
            {
                Console.WriteLine($"ConnectTest,{IP} format is incorrect! ");
                return false;
            }
            flag_ok = Basic.Net.Ping(IP, 1, timeout);
            string str = flag_ok ? "success" : "fail";
            Console.WriteLine($"ConnectTest,{IP} {str}!");
            return flag_ok;
        }
       
    }
    static public class Drawer
    {
        static int LocalPort = 29005;
        static int ServerPort = 30005;
        static private UDP_Class uDP_Class = new UDP_Class("0.0.0.0", LocalPort);

        static public int NumOfLED = 320;
        static private int NumOf_H_Line = 4;
        static private int NumOf_H_Leds = 8;
        static private int NumOf_V_Line = 4;
        static private int NumOf_V_Leds = 8;
        static private int NumOfLED_Pannel = 42;
        static private int NumOfLED_Drawer = 450 - NumOfLED_Pannel;

        private static List<int[]> List_H_Line_Leds = new List<int[]>();
        private static List<int[]> List_V_Line_Leds = new List<int[]>();

        static public void Set_Drawer_V_Leds(this byte[] LEDBytes, int col, Color color)
        {
            int offset = 0;
            int col_quo = col / NumOf_V_Line;
            int col_mod = col % NumOf_V_Line;
            int start_led = 0 + offset;
            if (col_quo % 2 == 0)
            {
                start_led = ((NumOf_V_Line * NumOf_V_Leds) * col_quo) + col_mod * NumOf_V_Leds;
            }
            else
            {
                start_led = ((NumOf_V_Line * NumOf_V_Leds) * col_quo) + (NumOf_V_Line - col_mod - 1) * NumOf_V_Leds;
            }
            start_led += offset;
            for (int i = start_led; i < NumOf_V_Leds + start_led; i++)
            {
                LEDBytes[i * 3 + 0] = color.R;
                LEDBytes[i * 3 + 1] = color.G;
                LEDBytes[i * 3 + 2] = color.B;
            }
        }
        static public void Set_Drawer_H_Leds(this byte[] LEDBytes, int row, Color color)
        {
            row -= 19;
            row *= -1;
            int offset = 160;
            int row_quo = row / NumOf_V_Line;
            int row_mod = row % NumOf_V_Line;
            int start_led = 0 + offset;
            if (row_quo % 2 == 0)
            {
                start_led = ((NumOf_V_Line * NumOf_V_Leds) * row_quo) + row_mod * NumOf_V_Leds;
            }
            else
            {
                start_led = ((NumOf_V_Line * NumOf_V_Leds) * row_quo) + (NumOf_V_Line - row_mod - 1) * NumOf_V_Leds;
            }
            start_led += offset;
            for (int i = start_led; i < NumOf_V_Leds + start_led; i++)
            {
                LEDBytes[i * 3 + 0] = color.R;
                LEDBytes[i * 3 + 1] = color.G;
                LEDBytes[i * 3 + 2] = color.B;
            }
        }
        static public void Set_Drawer_Box_Leds(this byte[] LEDBytes, int x, int y, int width, int height, Color color)
        {
            for (int i = x; i < (x + width); i++)
            {
                LEDBytes.Set_Drawer_H_Leds(i + y * NumOf_H_Line, color);

                LEDBytes.Set_Drawer_H_Leds(i + (y + height) * NumOf_H_Line, color);
            }

            for (int i = y; i < (y + height); i++)
            {
                LEDBytes.Set_Drawer_V_Leds(i + x * NumOf_V_Line, color);

                LEDBytes.Set_Drawer_V_Leds(i + (x + width) * NumOf_V_Line, color);
            }
        }

        static public byte[] Get_Empty_LEDBytes()
        {
            return new byte[NumOfLED * 3];
        }

        static public bool Set_LEDBytes_UDP(this byte[] LED_Bytes, string IP)
        {
            return Set_LEDBytes_UDP(IP, LED_Bytes);
        }
        static public bool Set_Clear_UDP(string IP)
        {
            if (uDP_Class != null)
            {
                return Communication.Set_WS2812_Buffer(uDP_Class, IP, 0, Get_Empty_LEDBytes());
            }
            return false;
        }
        static public bool Set_LEDBytes_UDP(string IP, byte[] LED_Bytes)
        {
            if (uDP_Class != null)
            {
                return Communication.Set_WS2812_Buffer(uDP_Class, IP, 0, LED_Bytes);
            }
            return false;
        }
        static public byte[] Get_LEDBytes_UDP(string IP)
        {
            byte[] LED_Bytes = new byte[NumOfLED * 3];
            if (uDP_Class != null)
            {
                return Communication.Get_WS2812_Buffer(uDP_Class, IP, NumOfLED * 3);
            }
            return LED_Bytes;
        }
    }
}
