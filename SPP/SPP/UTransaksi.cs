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
    public partial class UTransaksi : UserControl
    {
        Module mod = new Module();
        string idSiswa , sql;
        public string idpetugas;
        void awal()
        {
            sql = "SELECT * FROM siswa  WHERE siswa LIKE '%"+textBox1.Text+"%'";
            dataGridView1.DataSource = mod.getData(sql);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama siswa";
            dataGridView1.Columns[2].HeaderText = "Kelas";
            dataGridView1.Columns[3].HeaderText = "Jurusan";
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            idSiswa = "0";
            mod.clearForm(groupBox2);
        }
        void open()
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
        }
        public UTransaksi()
        {
            InitializeComponent();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UTransaksi_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                open();
                idSiswa = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label3.Text = "Siswa";
            awal();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                mod.msg("isi data terlebih dahulu");
            }
            else
            {
                sql = "INSERT INTO pembayaran VALUES('" + idpetugas + "','" + idSiswa + "','"+textBox2.Text+"','" + dateTimePicker1.Value.ToString("MMMM") + "','" + dateTimePicker2.Value.ToString("yyyy") + "','" + dateTimePicker3.Value.ToString("dd/MM/yyyy") + "')";
                if (mod.dialogForm("Apakah transaksi sudah benar?"))
                {
                    mod.msg(sql);
                    mod.exc(sql);
                    mod.msg("Pembayaran berhasil");
                    awal();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod.onlyNumber(e);
        }
    }
}
