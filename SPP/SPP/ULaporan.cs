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
    public partial class ULaporan : UserControl
    {
        Module mod = new Module();
        void awal()
        {
            string sql = "SELECT id_Pembayaran,siswa,kelas,jurusan,petugas,jumlah_bayar,bulan,tahun,tgl_bayar FROM View_spp WHERE siswa LIKE '%"+textBox1.Text+"%' OR petugas LIKE '%"+textBox1.Text+"%' ORDER BY tgl_bayar ASC";
            dataGridView1.DataSource = mod.getData(sql);
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Siswa";
            dataGridView1.Columns[2].HeaderText = "Kelas";
            dataGridView1.Columns[3].HeaderText = "Jurasan";
            dataGridView1.Columns[4].HeaderText = "Petugas";
            dataGridView1.Columns[5].HeaderText = "Jumlah bayar";
            dataGridView1.Columns[6].HeaderText = "Bulan yang dibayar";
            dataGridView1.Columns[7].HeaderText = "Tahun yang dibayar";
            dataGridView1.Columns[8].HeaderText = "Tanggal bayar";
            mod.msg(dataGridView1.RowCount.ToString());
            mod.msg(dataGridView1.ColumnCount.ToString());
            mod.msg(dataGridView1.Columns.Count.ToString());
        }
        void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch(Exception e)
            {
                obj = null;
                mod.msg(e.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public ULaporan()
        {
            InitializeComponent();
        }

        private void ULaporan_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            awal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application exlApp;
                Microsoft.Office.Interop.Excel.Workbook exlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet exlWorkSheet;
                object missValue = System.Reflection.Missing.Value;
                int i, j,k;

                exlApp = new Microsoft.Office.Interop.Excel.Application();
                exlWorkBook = exlApp.Workbooks.Add(missValue);
                exlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)exlWorkBook.Sheets["Sheet1"];

                for (i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        for (k = 1; k < dataGridView1.Columns.Count; k++)
                        {
                            exlWorkSheet.Cells[1,k]=dataGridView1.Columns[k-1].HeaderText;
                            exlWorkSheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                        }
                    }
                }
                exlWorkSheet.SaveAs(saveFileDialog1.FileName);
                exlWorkBook.Close();
                exlApp.Quit();
                ReleaseObject(exlApp);
                ReleaseObject(exlWorkBook);
                ReleaseObject(exlWorkSheet);
                mod.msg("Ekspor Berhasil");
            }
        }
    }
}
