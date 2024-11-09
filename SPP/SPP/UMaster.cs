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
    public partial class UMaster : UserControl
    {
        UPetugas petugas = new UPetugas();
        USiswa siswa = new USiswa();

        void view(Control UC)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(UC);
            UC.Dock = DockStyle.Fill;
        }
        public UMaster()
        {
            InitializeComponent();
        }

        private void UMaster_Load(object sender, EventArgs e)
        {
            view(petugas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view(petugas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view(siswa);
        }
    }
}
