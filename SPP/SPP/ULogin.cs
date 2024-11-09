using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPP
{
    public partial class ULogin : UserControl
    {
        public event EventHandler<DataEventArgs> DataSent;
        Module mod = new Module();
        public ULogin()
        {
            InitializeComponent();
        }
        string data1;
        string data2;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void ULogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        public class DataEventArgs : EventArgs
        {
            public string DATA1 { get; set; }
            public string DATA2 { get; set; }
            public DataEventArgs(string data1,string data2){
                DATA1 = data1;
                DATA2 = data2;
            }
        }
    }
}
