using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace aplikasi_UKK
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\SMK\UKK PBO_Shabrina\aplikasi_UKK\aplikasi_UKK\bin\Debug\spacecraftsDb.accdb");
        public Form1()
        {
            InitializeComponent();
        }
        void showData()
        {
            koneksi.Open();
            string perintah = "select * From spacecraftsTB";
            OleDbDataAdapter da = new OleDbDataAdapter(perintah, koneksi);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "insert into spacecraftsTB (Nama_Barang, Stok) values ('"+textBox1.Text+"', '"+textBox2.Text+"')";
            OleDbCommand cmd = new OleDbCommand(perintah,koneksi);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data tersimpan");
            koneksi.Close();
            showData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "delete from spacecraftsTB where id=" +textBox3.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data terhapus");
            koneksi.Close();
            showData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "update spacecraftsTB set Stok = '"+textBox2.Text+"' where Nama_Barang = '"+textBox1.Text+"'";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data diperbarui");
            koneksi.Close();
            showData();
        }
    }
}
