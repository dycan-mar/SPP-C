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
    public partial class UPetugas : UserControl
    {
        Module mod = new Module();
        string id, sql;
        bool aksi=true;
        void awal()
        {
            string sql = "SELECT * FROM petugas WHERE petugas LIKE '%"+textBox1.Text+"%'";
            dataGridView1.DataSource = mod.getData(sql);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Petugas";
            dataGridView1.Columns[2].HeaderText = "Alamat";
            dataGridView1.Columns[3].HeaderText = "Username";
            dataGridView1.Columns[4].HeaderText = "Pasword";
            pass();
            mod.clearForm(groupBox2);
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            id = "0";
            aksi = true;

        }
        void open ()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
        }
        void pass()
        {
            if (checkBox1.Checked)
            {
                textBox5.UseSystemPasswordChar = false;
            }
            else
            {
                textBox5.UseSystemPasswordChar = true;
            }
        }
        public UPetugas()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //btn-tambah
        private void button5_Click(object sender, EventArgs e)
        {
            open();
            mod.clearForm(groupBox2);
            
        }

        private void UPetugas_Load(object sender, EventArgs e)
        {
           
        
            awal();
        }

        //btn-ubah
        private void button4_Click(object sender, EventArgs e)
        {
            if (id =="0")
            {
                mod.msg("pilih data dulu");
            }
            else
            {
                aksi = false;
                open();
            }
        }

        //btn-hapus
        private void button3_Click(object sender, EventArgs e)
        {
            if (id == "0")
            {
                mod.msg("pilih data dulu");
            }
            else
            {
                if (mod.dialogForm("apakah anda yakin ingin menghapus?"))
                {
                    sql = "DELETE FROM petugas WHERE id_petugas=" + id;
                    mod.exc(sql);
                    mod.msg("data berhasil dihapus");
                    awal();
                }

            }
        }

        //btn-batal
        private void button2_Click(object sender, EventArgs e)
        {
            awal();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mod.adaKosong(groupBox2))
            {
                mod.msg("Lengkapi data terlebih dahulu");
            }
            else
            {
                if (aksi)
                {
                    //tambah
                    sql = "INSERT INTO petugas VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    mod.exc(sql);
                    mod.msg("data berhasil ditambahkan");
                    awal();
                }
                else
                {
                    //ubah
                    sql = "UPDATE petugas SET petugas ='" + textBox2.Text + "',alamat='" + textBox3.Text + "',username='" + textBox4.Text + "',password='" + textBox5.Text + "' WHERE id_petugas="+id;
                    mod.exc(sql);
                    mod.msg("data berhasil diubah");
                    awal();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pass();
        }   
    }
}
