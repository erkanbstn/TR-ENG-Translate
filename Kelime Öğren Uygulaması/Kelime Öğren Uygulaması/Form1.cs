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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        OleDbConnection bgl = new OleDbConnection (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\profe\Desktop\Access Verileri\Sözlük.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            FrmPanel fr = new FrmPanel();
            fr.tr = textBox1.Text;
            fr.ing = textBox2.Text;
            fr.Show();
        

        }
        int sayac = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listBox1.ForeColor = Color.Orange;
            listBox1.Items.Add("İngilizce-Türkçe Sözlüğe Hoşgeldiniz");
            textBox3.Text = "Nimet";
           
            //bgl.Open();
            //OleDbCommand k = new OleDbCommand("Select İngilizce,Türkçe from Sözcükler", bgl);
            //OleDbDataReader dr = k.ExecuteReader();
            //while (dr.Read())
            //{
            //    listBox1.Items.Add(dr[0].ToString() + " " + "=" + " " + dr[1].ToString());
            //}
            //bgl.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                textBox1.BackColor = Color.RosyBrown;
                listBox1.ForeColor = Color.White;
                listBox1.BackColor = Color.RosyBrown;
                listBox1.Items.Clear();
                bgl.Open();
                OleDbCommand k = new OleDbCommand("Select İngilizce,Türkçe from Sözcükler where Türkçe like'"+ textBox1.Text + "%'", bgl);
                OleDbDataReader dr = k.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[1].ToString() + " " + "=" + " " + dr[0].ToString());
                    
                }
                bgl.Close();
                if (textBox1.Text == "")
                {
                    OleDbCommand k2 = new OleDbCommand("Select İngilizce,Türkçe from Sözcükler Türkçe where Türkçe like'" + textBox1.Text + "%' order by Türkçe", bgl);
                    OleDbDataReader dr2 = k2.ExecuteReader();
                    while (dr2.Read())
                    {
                        listBox1.Items.Add(dr2[1].ToString() + " " + "=" + " " + dr2[0].ToString());
                        
                    }
                    bgl.Close();
                }
            }
            catch (Exception)
            {

               
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                textBox2.BackColor = Color.RosyBrown;
                listBox1.ForeColor = Color.White;
                listBox1.BackColor = Color.RosyBrown;
                listBox1.Items.Clear();
                bgl.Open();
                OleDbCommand k = new OleDbCommand("Select İngilizce,Türkçe from Sözcükler where İngilizce like'" + textBox2.Text + "%'", bgl);
                OleDbDataReader dr = k.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString() + " " + "=" + " " + dr[1].ToString());
                }
                bgl.Close();
                if (textBox2.Text == "")
                {                  
                    OleDbCommand k2 = new OleDbCommand("Select İngilizce,Türkçe from Sözcükler where İngilizce  order by İngilizce", bgl);
                    OleDbDataReader dr2 = k2.ExecuteReader();
                    while (dr2.Read())
                    {
                        listBox1.Items.Add(dr2[0].ToString() + " " + "=" + " " + dr2[1].ToString());                     
                    }
                    bgl.Close();
                }
            }
            catch (Exception)
            {
           

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
           
            if (sayac == 5)
            {
                label4.Visible = true;
                label4.BackColor = Color.Red;
                label4.ForeColor = Color.White;
                label4.Text = "Gelişmeye Hazır mısınız ?";
             
            }
            if (sayac == 10)
            {
              
               listBox1.Items.Clear();
                listBox1.ForeColor = Color.Green;
                listBox1.Items.Add("Kelimeleri Öğrenmek Artık Çok Basit");           
            }
            if (sayac ==15)
            {
                label4.BackColor = Color.Yellow;
                label4.ForeColor = Color.Blue;
                label4.Text = "Öğrenmeye Hazır mısınız ?";
            }
            if (sayac == 20)
            {
               
                listBox1.Items.Clear();
                listBox1.ForeColor = Color.Blue;
                listBox1.Items.Add("İlgili Alanlara Değer Girin");
            }
            if (sayac == 25)
            {
                label4.BackColor = Color.White;
                label4.ForeColor = Color.Red;
                label4.Text = "Şimdi Öğrenmenin Tam Zamanı ! ";
            }
                
            if (sayac == 34)
            {
              
                listBox1.Items.Clear();
                listBox1.ForeColor = Color.Red;
                listBox1.Items.Add("Ve Öğrenmenin Tadını Çıkarın");
               
            }
            if (sayac == 35)
            {
                label4.ForeColor = Color.White;
                label4.BackColor = Color.Green;
                label4.Text = "Bu Bölüme Kelimeleri Girin !";            
            }
            if (sayac == 40)
            {
     
                sayac = 0;
            }          
        }

        private void Form1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text=="" && textBox2.Text == "")
            {
                timer1.Start();
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                listBox1.BackColor = Color.White;                  
            }      
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.RosyBrown;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.RosyBrown;
        }
    }
    
}
