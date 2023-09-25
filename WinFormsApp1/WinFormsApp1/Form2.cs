using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private int CountChar()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("c:\\auth\\t1.txt"))
            {
                count=reader.ReadToEnd().Length;
                Thread.Sleep(5000);
            }
            return count;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
             Task<int> task = new Task<int>(CountChar);
                task.Start();
                label1.Text = "Started counting please wait.....";
                int c = await task;
                label1.Text = "Count " + c.ToString();
            
        }
    }
}
