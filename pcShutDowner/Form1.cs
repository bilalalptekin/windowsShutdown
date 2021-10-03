using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcShutDowner
{
    public partial class Form1 : Form
    {
       
        private int second;
        private int minute;
        private int hour;
        public Form1()
        {
            InitializeComponent();

            timer1.Stop();
            
            cmbSaniye.Text = "0";
            cmbSaat.Text = "0";
            cmbDakika.Text = "5";

            
          
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
            second = Convert.ToInt32(cmbSaniye.Text);
            minute= Convert.ToInt32(cmbDakika.Text);
            hour = Convert.ToInt32(cmbSaat.Text);
            kapat(hour, minute, second);
            

            
        }
        static int kapatmasuresi(int saat,int dakika,int saniye)
        {
            int sure = saat * 3600 + dakika * 60 + saniye;
            return sure;
        }
        static void kapat(int saat,int dakika,int saniye)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = $"/k shutdown -s -t {kapatmasuresi(saat, dakika, saniye)}";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(startInfo);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second>=0 && hour>=0 && minute>=0) {

                second--;
                if (second == -1)
                {
                    second = 59;
                    minute--;
                    if (minute % 60 == -1)
                    {
                        minute = 59;
                        hour--;
                    }
                }
            }
            lblKalansure.Text = $"{hour.ToString()} sa {minute.ToString()} dk {second.ToString()} sn ";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void uykuyaal(int saat, int dakika, int saniye)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = $"/k shutdown -s -t {kapatmasuresi(saat, dakika, saniye)}";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(startInfo);
        }
        private void iptalet()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = $"/k shutdown -a";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(startInfo);
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iptalet();
            cmbSaniye.Text = "0";
            cmbSaat.Text = "0";
            cmbDakika.Text = "5";
            lblKalansure.Text = "0 sa 0 dk 0 sn";
        }
    }
}
