using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPP
{
    class Module
    {
       
        /// <summary>
        /// deklarasi variable
        /// </summary>
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataTable dt;
        public SqlCommand cmd;

        public readonly string NamaServer ="Data Source=DESKTOP-DF0KBGJ\\SQLEXPRESS;Initial Catalog=SPP;Integrated Security=True";

        /// <summary>
        /// koneksi ke db
        /// </summary>
        public void connection(){
            conn =new SqlConnection(NamaServer);
            if(conn.State == ConnectionState.Closed){
                conn.Open();
            }
        }
        /// <summary>
        /// menutup koneksi dari db
        /// </summary>
        public void closeConnection(){
            conn.Close();
            cmd.Dispose();
        }
        /// <summary>
        /// mengambil data dari db
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable getData(string query){
            connection();
            try{
                cmd=new SqlCommand(query,conn);
                da=new SqlDataAdapter();
                dt=new DataTable();
                da.SelectCommand=cmd;
                da.Fill(dt);
                return dt;
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                return null;
            }finally{
                closeConnection();
            }
        }
        /// <summary>
        /// mengambil jumlah data 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int getCount(string query){
            connection();
            try{
                cmd =new SqlCommand(query,conn);
                da=new SqlDataAdapter();
                dt=new DataTable();
                da.SelectCommand=cmd;
                da.Fill(dt);
                return dt.Rows.Count ;
           }catch(Exception ex){
                MessageBox.Show(ex.Message);
                return 0;
           }finally{
                closeConnection();
                cmd.Dispose();
           }
       }
        /// <summary>
        /// mengambil data secara spesifik
        /// </summary>
        /// <param name="query"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public object getValue(string query,string col){
            connection();
            object value=null;
            try{
                cmd  =new SqlCommand(query,conn);
                dr=cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows){
                    if(dr.IsDBNull(dr.GetOrdinal(col))){
                        return "";
                    }else{
                        value=dr[col];
                        return value.ToString();
                    }
                }else{
                    return"";
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                return "";
            }finally{
                closeConnection();
            }
        }
        /// <summary>
        /// mengeksekusi query sql
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool exc(string query){
            connection();
            try{
                cmd=new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                return true;
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                return false;
            }finally{
                closeConnection();
            }
        }
        /// <summary>
        /// mengecek jika ada input control yang belum di isi pada groupBox
        /// </summary>
        /// <param name="gb"></param>
        /// <returns></returns>
        public bool adaKosong(GroupBox gb){
            bool status=false;
            foreach(Control ct in gb.Controls){
                TextBox tb=ct as TextBox;
                if(tb != null && tb.Text.Trim()== string.Empty){
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// untuk menghapus isi pada input control yang ada dalam groupBox 
        /// </summary>
        /// <param name="gb"></param>
        public void clearForm(GroupBox gb){
            foreach(Control ct in gb.Controls){
                if(ct is TextBox){
                    TextBox tx = (TextBox)ct;
                    tx.Text = "";
                }
                else if (ct is NumericUpDown) {
                    NumericUpDown nud = (NumericUpDown)ct;
                    nud.Value = 0;
                }else if(ct is ComboBox){
                    ComboBox cb = (ComboBox)ct;
                    cb.SelectedIndex = 0;
                }
            }
        }
        public void onlyNumber(KeyPressEventArgs e){
            if (e.KeyChar != (char)Keys.Back){
                if (e.KeyChar < '0' || e.KeyChar > '9'){
                    e.Handled = true;
                }
            }
        }
        public bool dialogForm(string s)
        {
            DialogResult a = MessageBox.Show(s, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public void msg(string pesan){
            MessageBox.Show(pesan);
        }
    }
}
