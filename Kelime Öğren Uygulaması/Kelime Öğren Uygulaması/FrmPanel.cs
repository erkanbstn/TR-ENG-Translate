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

namespace Kelime_Öğren_Uygulaması
{
    public partial class FrmPanel : Form
    {
        public FrmPanel()
        {
            InitializeComponent();
        }
        
        public string ing;
        public string tr;
        OleDbConnection bgl = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\profe\Desktop\Access Verileri\Sözlük.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            OleDbCommand k = new OleDbCommand("insert into Sözcükler (İngilizce,Türkçe) values (@p1,@p2)", bgl);
            k.Parameters.AddWithValue("@p1", ing);
            k.Parameters.AddWithValue("@p2", tr);
            k.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kelime Başarıyla Eklendi","Sözlük İşlemleri",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmPanel_Load(object sender, EventArgs e)
        {        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            OleDbCommand k = new OleDbCommand("update Sözcükler set İngilizce=@p1,Türkçe=@p2 where İngilizce=@p1", bgl);
            k.Parameters.AddWithValue("@p1", ing);
            k.Parameters.AddWithValue("@p2", tr);
            k.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("İngilizce Kelime Başarıyla Güncellendi", "Sözlük İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bgl.Open();
            OleDbCommand k = new OleDbCommand("update Sözcükler set İngilizce=@p1,Türkçe=@p2 where Türkçe=@p2", bgl);
            k.Parameters.AddWithValue("@p1", ing);
            k.Parameters.AddWithValue("@p2", tr);
            k.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Türkçe Kelime Başarıyla Güncellendi", "Sözlük İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
