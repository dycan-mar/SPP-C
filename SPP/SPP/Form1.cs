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
    public partial class Form1 : Form
    {
        UBeranda beranda = new UBeranda();
        UMaster master = new UMaster();
        UTransaksi bayar = new UTransaksi();
        ULaporan laporan = new ULaporan();
        ULogin login = new ULogin();
        Module mod = new Module();
        

   
        void view(Control UC)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(UC);
            UC.Dock = DockStyle.Fill;
        }

        public string idPetugas = "0",petugas;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            beranda.label3.Text = petugas;
            view(beranda);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        ///btn-beranda
        private void button1_Click_1(object sender, EventArgs e)
        {
            view(beranda);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view(master);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bayar.idpetugas = idPetugas;
            view(bayar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view(laporan);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            idPetugas = "0";
            petugas = "petugas";
            FLogin fl = new FLogin();
            this.Hide();
            fl.ShowDialog();
        }
    }
}
