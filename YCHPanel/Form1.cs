﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic;
using YCHPanellib;
namespace YCHPanel
{
    public partial class Form1 : Form
    {
        public Color color
        {
            get
            {
                if (radioButton_Drawer_紅.Checked)
                {
                    return Color.Red;
                }
                if (radioButton_Drawer_藍.Checked)
                {
                    return Color.Blue;
                }
                if (radioButton_Drawer_綠.Checked)
                {
                    return Color.Green;
                }
                if (radioButton_Drawer_黃.Checked)
                {
                    return Color.Yellow;
                }
                if (radioButton_Drawer_白.Checked)
                {
                    return Color.White;
                }
             
                return Color.Black;
            }
        }
        public string IP
        {
            get
            {
                return $"{textBox_IPA.Text}.{textBox_IPB.Text}.{textBox_IPC.Text}.{textBox_IPD.Text}"; 
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button_ConnectTest.Click += Button_ConnectTest_Click;
            this.button_V_Line_Show.Click += Button_V_Line_Show_Click; ;
            this.button_H_Line_Show.Click += Button_H_Line_Show_Click;
            this.button_Drawer_Clear.Click += Button_Drawer_Clear_Click;
            this.button_Drawer_ShowBox.Click += Button_Drawer_ShowBox_Click;
        }

     
        private void Button_ConnectTest_Click(object sender, EventArgs e)
        {
            string IP = $"{textBox_IPA.Text}.{textBox_IPB.Text}.{textBox_IPC.Text}.{textBox_IPD.Text}";
            if(!IP.Check_IP_Adress())
            {
                MessageBox.Show("IP 位址不正確!");
                return;
            }
            string str = YCHPanellib.Net.ConnectTest(IP) ? "OK" : "NG" ;
            MessageBox.Show($"ConnectTest {str}!");
        }
        private void Button_V_Line_Show_Click(object sender, EventArgs e)
        {
            byte[] bytes = YCHPanellib.Drawer.Get_Empty_LEDBytes();
            bytes.Set_Drawer_V_Leds((int)(numericUpDown_V_Line_index.Value - 1), color);
            bytes.Set_LEDBytes_UDP(IP);
        }
        private void Button_H_Line_Show_Click(object sender, EventArgs e)
        {
            byte[] bytes = YCHPanellib.Drawer.Get_Empty_LEDBytes();
            bytes.Set_Drawer_H_Leds((int)(numericUpDown_H_Line_index.Value - 1), color);
            bytes.Set_LEDBytes_UDP(IP);
        }
        private void Button_Drawer_Clear_Click(object sender, EventArgs e)
        {
            YCHPanellib.Drawer.Set_Clear_UDP(IP);
        }
        private void Button_Drawer_ShowBox_Click(object sender, EventArgs e)
        {
            int x = (int)this.numericUpDown_Drawer_PointX.Value;
            int y = (int)this.numericUpDown_Drawer_PointY.Value;
            int width = (int)numericUpDown_Drawer_Width.Value;
            int height = (int)numericUpDown_Drawer_Height.Value;
            byte[] bytes = YCHPanellib.Drawer.Get_Empty_LEDBytes();
            bytes.Set_Drawer_Box_Leds(x, y, width, height, color);
            bytes.Set_LEDBytes_UDP(IP);
        }

    }
}
