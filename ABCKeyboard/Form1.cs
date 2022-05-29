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
using System.Diagnostics;
using System.IO;

namespace ABCKeyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StreamReader srl = new StreamReader("./Resources/language.ini");
            string language = srl.ReadLine();
            if (language == "0")
            {
                srl.Close();
                语言ToolStripMenuItem.Text = "语言";
                英文ToolStripMenuItem.Text = "英文";
                中文ToolStripMenuItem.Text = "中文";
                tabPage1.Text = "当前布局";
                tabPage2.Text = "布局一";
                tabPage3.Text = "布局二";
                tabPage4.Text = "布局三";
                button1.Text = "恢复默认";
                button2.Text = "立即生效";
                button4.Text = "应用布局";
                button3.Text = "立即生效";
                button6.Text = "应用布局";
                button5.Text = "立即生效";
                button8.Text = "应用布局";
                button7.Text = "立即生效";

            }
            else if (language == "1")
            {
                srl.Close();
                语言ToolStripMenuItem.Text = "Language";
                英文ToolStripMenuItem.Text = "English";
                中文ToolStripMenuItem.Text = "Chinese";
                tabPage1.Text = "Current Layout";
                tabPage2.Text = "Layout1";
                tabPage3.Text = "Layout2";
                tabPage4.Text = "Layout3";
                button1.Text = "Reset";
                button2.Text = "Effective";
                button4.Text = "Apply";
                button3.Text = "Effective";
                button6.Text = "Apply";
                button5.Text = "Effective";
                button8.Text = "Apply";
                button7.Text = "Effective";


            }


            
            pictureBox5.Image = Image.FromFile("./Resources/logo.png");
            pictureBox2.Image = Image.FromFile("./Resources/layout1.png");
            pictureBox3.Image = Image.FromFile("./Resources/layout2.png");
            pictureBox4.Image = Image.FromFile("./Resources/layout3.png");

            try
            {
                StreamReader srf = new StreamReader("./Resources/config.ini");
                string flag = srf.ReadLine();
                if (flag == "0")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/default.png");
                    
                    srf.Close();
                }
                else if (flag == "1")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout1.png");
                    
                    srf.Close();
                }
                else if (flag == "2")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout2.png");
                    
                    srf.Close();
                }
                else if (flag == "3")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout3.png");
                    
                    srf.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey hkIm = Registry.LocalMachine;
                RegistryKey software = hkIm.OpenSubKey("SYSTEM", true);
                RegistryKey currentControlSet = software.OpenSubKey("CurrentControlSet", true);
                RegistryKey control = currentControlSet.OpenSubKey("Control", true);
                RegistryKey keyboardLayout = control.OpenSubKey("Keyboard Layout", true);
                keyboardLayout.DeleteValue("Scancode Map");
                StreamWriter sw = new StreamWriter("./Resources/config.ini");
                sw.WriteLine("0");
                sw.Close();

                StreamReader srl = new StreamReader("./Resources/language.ini");
                string language = srl.ReadLine();
                if (language == "0")
                {
                    srl.Close();
                    MessageBox.Show("已恢复默认布局", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (language == "1")
                {
                    srl.Close();
                    MessageBox.Show("Default layout has been restored", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                StreamReader srf = new StreamReader("./Resources/config.ini");
                string flag = srf.ReadLine();
                if (flag == "0")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/default.png");

                    srf.Close();
                }
                else if (flag == "1")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout1.png");

                    srf.Close();
                }
                else if (flag == "2")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout2.png");

                    srf.Close();
                }
                else if (flag == "3")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout3.png");

                    srf.Close();
                }

            }
            catch (Exception)
            {
                StreamReader sr = new StreamReader("./Resources/language.ini");
                string language = sr.ReadLine();
                if (language == "0")
                {
                    sr.Close();
                    MessageBox.Show("已恢复默认布局", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (language == "1")
                {
                    sr.Close();
                    MessageBox.Show("Default layout has been restored", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("./Resources/language.ini");
            string language = sr.ReadLine();
            if (language == "0")
            {
                sr.Close();
                if (MessageBox.Show("立即生效需要注销当前系统用户，立即注销请点击确认！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
            else if (language == "1")
            {
                sr.Close();
                if (MessageBox.Show("Effective immediately need to log out the current system users, log out immediately please click to confirm!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] layout1 = { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 0x1E, 00, 0x10, 00, 0x30, 00, 0x11, 00, 0x2E, 00, 0x12, 00, 0x20, 00, 0x13, 00, 0x12, 00, 0x16, 00, 0x21, 00, 0X17, 00, 0x22, 00, 0X18, 00, 0x23, 00, 0x1E, 00, 0x17, 00, 0x1F, 00, 0x24, 00, 0x20, 00, 0x25, 00, 0x21, 00, 0x26, 00, 0x24, 00, 0x32, 00, 0x25, 00, 0x31, 00, 0x26, 00, 0x18, 00, 0x2C, 00, 0x19, 00, 0x2D, 00, 0x10, 00, 0x2E, 00, 0x33, 00, 0x2F, 00, 0x13, 00, 0x32, 00, 0x1F, 00, 0x33, 00, 0x14, 00, 0x34, 00, 0x16, 00, 0x14, 00, 0x2F, 00, 0x22, 00, 0x11, 00, 0x30, 00, 0x2D, 00, 0x15, 00, 0x15, 00, 0x23, 00, 0x2C, 00, 0x31, 00, 0x34, 00, 0x19, 00 };
            try
            {
                RegistryKey hkIm = Registry.LocalMachine;
                RegistryKey software = hkIm.OpenSubKey("SYSTEM", true);
                RegistryKey currentControlSet = software.OpenSubKey("CurrentControlSet", true);
                RegistryKey control = currentControlSet.OpenSubKey("Control", true);
                RegistryKey keyboardLayout = control.OpenSubKey("Keyboard Layout", true);
                keyboardLayout.SetValue("Scancode Map", layout1, RegistryValueKind.Binary);
                StreamWriter sw = new StreamWriter("./Resources/config.ini");
                sw.WriteLine(1);
                sw.Close();

                StreamReader sr = new StreamReader("./Resources/language.ini");
                string language = sr.ReadLine();
                if (language == "0")
                {
                    sr.Close();
                    MessageBox.Show("应用布局成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (language == "1")
                {
                    sr.Close();
                    MessageBox.Show("Application layout success", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                StreamReader srf = new StreamReader("./Resources/config.ini");
                string flag = srf.ReadLine();
                if (flag == "0")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/default.png");

                    srf.Close();
                }
                else if (flag == "1")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout1.png");

                    srf.Close();
                }
                else if (flag == "2")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout2.png");

                    srf.Close();
                }
                else if (flag == "3")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout3.png");

                    srf.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] layout2 = { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 0x1E, 00, 0x10, 00, 0x30, 00, 0x11, 00, 0x2E, 00, 0x12, 00, 0x20, 00, 0x13, 00, 0x12, 00, 0x16, 00, 0x21, 00, 0X17, 00, 0x22, 00, 0X18, 00, 0x23, 00, 0x1E, 00, 0x17, 00, 0x1F, 00, 0x24, 00, 0x20, 00, 0x25, 00, 0x21, 00, 0x26, 00, 0x24, 00, 0x32, 00, 0x25, 00, 0x31, 00, 0x26, 00, 0x18, 00, 0x2C, 00, 0x19, 00, 0x2D, 00, 0x10, 00, 0x2E, 00, 0x13, 00, 0x2F, 00, 0x1F, 00, 0x32, 00, 0x14, 00, 0x33, 00, 0x16, 00, 0x34, 00, 0x2F, 00, 0x14, 00, 0x11, 00, 0x22, 00, 0x2D, 00, 0x30, 00, 0x15, 00, 0x15, 00, 0x33, 00, 0x23, 00, 0x2C, 00, 0x31, 00, 0x34, 00, 0x19, 00 };
            try
            {
                RegistryKey hkIm = Registry.LocalMachine;
                RegistryKey software = hkIm.OpenSubKey("SYSTEM", true);
                RegistryKey currentControlSet = software.OpenSubKey("CurrentControlSet", true);
                RegistryKey control = currentControlSet.OpenSubKey("Control", true);
                RegistryKey keyboardLayout = control.OpenSubKey("Keyboard Layout", true);
                keyboardLayout.SetValue("Scancode Map", layout2, RegistryValueKind.Binary);
                StreamWriter sw = new StreamWriter("./Resources/config.ini");
                sw.WriteLine("2");
                sw.Close();

                StreamReader sr = new StreamReader("./Resources/language.ini");
                string language = sr.ReadLine();
                if (language == "0")
                {
                    sr.Close();
                    MessageBox.Show("应用布局成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (language == "1")
                {
                    sr.Close();
                    MessageBox.Show("Application layout success", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                StreamReader srf = new StreamReader("./Resources/config.ini");
                string flag = srf.ReadLine();
                if (flag == "0")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/default.png");

                    srf.Close();
                }
                else if (flag == "1")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout1.png");

                    srf.Close();
                }
                else if (flag == "2")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout2.png");

                    srf.Close();
                }
                else if (flag == "3")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout3.png");

                    srf.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] layout3 = { 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 0x1E, 00, 0x10, 00, 0x30, 00, 0x11, 00, 0x2E, 00, 0x12, 00, 0x20, 00, 0x13, 00, 0x12, 00, 0x16, 00, 0x21, 00, 0X17, 00, 0x22, 00, 0X18, 00, 0x23, 00, 0x1E, 00, 0x17, 00, 0x1F, 00, 0x24, 00, 0x20, 00, 0x25, 00, 0x21, 00, 0x32, 00, 0x24, 00, 0x31, 00, 0x25, 00, 0x18, 00, 0x26, 00, 0x10, 00, 0x2C, 00, 0x13, 00, 0x2D, 00, 0x1F, 00, 0x2E, 00, 0x34, 00, 0x2F, 00, 0x14, 00, 0x32, 00, 0x16, 00, 0x33, 00, 0x2F, 00, 0x34, 00, 0x11, 00, 0x14, 00, 0x33, 00, 0x22, 00, 0x2D, 00, 0x30, 00, 0x15, 00, 0x15, 00, 0x26, 00, 0x23, 00, 0x2C, 00, 0x31, 00, 0x19, 00, 0x27, 00, 0x27, 00, 0x19, 00 };
            try
            {
                RegistryKey hkIm = Registry.LocalMachine;
                RegistryKey software = hkIm.OpenSubKey("SYSTEM", true);
                RegistryKey currentControlSet = software.OpenSubKey("CurrentControlSet", true);
                RegistryKey control = currentControlSet.OpenSubKey("Control", true);
                RegistryKey keyboardLayout = control.OpenSubKey("Keyboard Layout", true);
                keyboardLayout.SetValue("Scancode Map", layout3, RegistryValueKind.Binary);
                StreamWriter sw = new StreamWriter("./Resources/config.ini");
                sw.WriteLine("3");
                sw.Close();

                StreamReader sr = new StreamReader("./Resources/language.ini");
                string language = sr.ReadLine();
                if (language == "0")
                {
                    sr.Close();
                    MessageBox.Show("应用布局成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (language == "1")
                {
                    sr.Close();
                    MessageBox.Show("Application layout success", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                StreamReader srf = new StreamReader("./Resources/config.ini");
                string flag = srf.ReadLine();
                if (flag == "0")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/default.png");

                    srf.Close();
                }
                else if (flag == "1")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout1.png");

                    srf.Close();
                }
                else if (flag == "2")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout2.png");

                    srf.Close();
                }
                else if (flag == "3")
                {
                    pictureBox1.Image = Image.FromFile("./Resources/layout3.png");

                    srf.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("./Resources/language.ini");
            string language = sr.ReadLine();
            if (language == "0")
            {
                sr.Close();
                if (MessageBox.Show("立即生效需要注销当前系统用户，立即注销请点击确认！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
            else if (language == "1")
            {
                sr.Close();
                if (MessageBox.Show("Effective immediately need to log out the current system users, log out immediately please click to confirm!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
        }

        private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter swl = new StreamWriter("./Resources/language.ini");
            swl.WriteLine("1");
            swl.Close();
            语言ToolStripMenuItem.Text = "Language";
            英文ToolStripMenuItem.Text = "English";
            中文ToolStripMenuItem.Text = "Chinese";
            tabPage1.Text = "Current Layout";
            tabPage2.Text = "Layout1";
            tabPage3.Text = "Layout2";
            tabPage4.Text = "Layout3";
            button1.Text = "Reset";
            button2.Text = "Effective";
            button4.Text = "Apply";
            button3.Text = "Effective";
            button6.Text = "Apply";
            button5.Text = "Effective";
            button8.Text = "Apply";
            button7.Text = "Effective";
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter swl = new StreamWriter("./Resources/language.ini");
            swl.WriteLine("0");
            swl.Close();
            语言ToolStripMenuItem.Text = "语言";
            英文ToolStripMenuItem.Text = "英文";
            中文ToolStripMenuItem.Text = "中文";
            tabPage1.Text = "当前布局";
            tabPage2.Text = "布局一";
            tabPage3.Text = "布局二";
            tabPage4.Text = "布局三";
            button1.Text = "恢复默认";
            button2.Text = "立即生效";
            button4.Text = "应用布局";
            button3.Text = "立即生效";
            button6.Text = "应用布局";
            button5.Text = "立即生效";
            button8.Text = "应用布局";
            button7.Text = "立即生效";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("./Resources/language.ini");
            string language = sr.ReadLine();
            if (language == "0")
            {
                sr.Close();
                if (MessageBox.Show("立即生效需要注销当前系统用户，立即注销请点击确认！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
            else if (language == "1")
            {
                sr.Close();
                if (MessageBox.Show("Effective immediately need to log out the current system users, log out immediately please click to confirm!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("./Resources/language.ini");
            string language = sr.ReadLine();
            if (language == "0")
            {
                sr.Close();
                if (MessageBox.Show("立即生效需要注销当前系统用户，立即注销请点击确认！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
            else if (language == "1")
            {
                sr.Close();
                if (MessageBox.Show("Effective immediately need to log out the current system users, log out immediately please click to confirm!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "/l");
                }
            }
        }
    }
}
