using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPP
{
    public partial class FLogin : Form
    {
        UBeranda beranda;
        Form1 utama=new Form1();
        Module mod = new Module();
        void pass()
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
        public FLogin()
        {
            this.beranda = new UBeranda();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text==""){
                mod.msg("username atau password belum diisi");
            }
            else
            {
                string sql = "SELECT * FROM petugas WHERE username='"+textBox1.Text+"' AND password='"+textBox2.Text+"'";
                if (mod.getCount(sql)>0)
                {
                    mod.msg("berhasil login");
                    utama.idPetugas = mod.getValue(sql, "id_petugas").ToString();
                    utama.petugas = mod.getValue(sql, "petugas").ToString();
                    textBox1.Clear();
                    textBox2.Clear();
                    this.Hide();
                    utama.ShowDialog();
                }
                else
                {
                    mod.msg("Username atau password salah");
                }
            }
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pass();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            pass();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
