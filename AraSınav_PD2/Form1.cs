using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AraSınav_PD2
{
    public partial class Vize : Form
    {
        
        public Vize()
        {
           
            InitializeComponent();
        }

        int time = 0;
        bool ikinci = false;
        public static int _mayinSayisi;
       public void Mayin_doldur(int mayinSayisi,int boyut)
        {
           
            List<int> mayinOlasiliklari = new List<int>(25);
            for (int i = 1; i <= 25; i++)
            {
                mayinOlasiliklari.Add(i);
            }

            Random random = new Random();
            List<int> mayinlarr = new List<int>(mayinSayisi);
            for (int i = 0; i < mayinSayisi; i++)
            {
                int randomVar = random.Next(0, 25 - i);
                var i1 = mayinOlasiliklari[randomVar];
                mayinlarr.Add(i1);
                mayinOlasiliklari.Remove(i1);
            }

            for (int i = 1; i <= 25; i++)
            {
                var control = (Button)this.Controls.Find($"button{i}", true).First();
                control.Enabled = true;
                control.Visible = true;
                int mayinsayisi = 0;

                if (i - 5 > 0 && i - 5 < 26)
                {
                    if (mayinlarr.Contains(i - 5))
                    {
                        mayinsayisi++;
                    }
                }
                if (i - 6 > 0 && i - 6 < 26 && i % 5 != 1)
                {
                    if (mayinlarr.Contains(i - 6))
                    {
                        mayinsayisi++;
                    }
                }
                if (i - 4 > 0 && i - 4 < 26 && i % 5 != 0)
                {
                    if (mayinlarr.Contains(i - 4))
                    {
                        mayinsayisi++;
                    }
                }
                if (i - 1 > 0 && i - 1 < 26 && i % 5 != 1)
                {
                    if (mayinlarr.Contains(i - 1))
                    {
                        mayinsayisi++;
                    }
                }
                if (i + 1 > 0 && i + 1 < 26 && i % 5 != 0)
                {
                    if (mayinlarr.Contains(i + 1))
                    {
                        mayinsayisi++;
                    }
                }
                if (i + 4 > 0 && i + 4 < 26 && i % 5 != 1)
                {
                    if (mayinlarr.Contains(i + 4))
                    {
                        mayinsayisi++;
                    }
                }
                if (i + 5 > 0 && i + 5 < 26)
                {
                    if (mayinlarr.Contains(i + 5))
                    {
                        mayinsayisi++;
                    }
                }
                if (i + 6 > 0 && i + 6 < 26)
                {
                    if (mayinlarr.Contains(i + 6))
                    {
                        mayinsayisi++;
                    }
                }

                if (mayinlarr.Contains(i))
                {
                    control.Tag = new { isMayin = true, mayinSayisi = mayinsayisi };
                }
              
                else
                {
                    control.Tag = new { isMayin = false, mayinSayisi = mayinsayisi };
                }
            }

        }

        public void ButtonClk(object sender, EventArgs e)
        {
         

            Button tikla = (Button)sender;

            object tag = tikla.Tag;

            var isMayin = (bool)tag.GetType().GetProperty("isMayin").GetValue(tag);
            var mayinSayisi = (int)tag.GetType().GetProperty("mayinSayisi").GetValue(tag);

            if (isMayin == true)
            {
                tikla.BackColor = Color.Red;
                tikla.Text = mayinSayisi.ToString();
                timer1.Enabled = false;
                MessageBox.Show("Oyun Bitti !!");
                onizlemeEkrani.Close();
                Mayin_doldur((int)numericUpDown1.Value, 24);
               
                for (int i = 1; i < 26; i++)
                {
                    var control = (Button)this.Controls.Find($"button{i}", true).First();
                    control.Text = "";
                    control.BackColor = Color.Gray;
                }
                ikinci = false;

            }
            else
            {
                time = Convert.ToInt32(numericUpDown2.Value);
                tikla.BackColor = Color.Green;
                tikla.Text = mayinSayisi.ToString();
                   

            }

        }
       
      
        // ARMSTRONG SAYILARI//Buradan
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void BulBtn_Click(object sender, EventArgs e)
        {
            int sayi1 = Convert.ToInt32(textBox1.Text);
            int sayi2 = Convert.ToInt32(textBox2.Text);

            ArmListbox.Items.Clear();


            for (int a = sayi1; a < sayi2; a++)
            {
                int toplam = 0;

                string strSayi = a.ToString();
                int bs = strSayi.Length;

                for (int i = 0; i < bs; i++)
                {
                    double taban = double.Parse(strSayi[i].ToString());
                    toplam += (int)Math.Pow(taban, bs);

                }

                if (toplam == a)
                {
                    ArmListbox.Items.Add(a);
                }

            }

        }

        // ARMSTRONG SAYILARI//BURAYA KADAR

        
        OnizlemeEkrani onizlemeEkrani;
        private void BaslaBtn_Click(object sender, EventArgs e)
        {
            _mayinSayisi = (int)numericUpDown1.Value;

            if (!ikinci)
            {
                Mayin_doldur(_mayinSayisi, 24);

                onizlemeEkrani = new OnizlemeEkrani();
                onizlemeEkrani.Show();
         

            timer1.Enabled = true;
            time =Convert.ToInt32(numericUpDown2.Value);

                ikinci = true;
            }
            else
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Yeni oyun başlatma istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo ,MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    Mayin_doldur((int)numericUpDown1.Value, 24);

                    for (int i=1;i<26;i++)
                    {
                       var control = (Button)this.Controls.Find($"button{i}", true).First();
                        control.Text = "";
                        control.BackColor = Color.Gray;
                    }
                 
                }
                else
                {
                  
                }
            }
            
        }  
          
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            KalanSureLbl.Text ="Kalan Süre = " + time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Süre Bitti !!");
                onizlemeEkrani.Close();
                Mayin_doldur((int)numericUpDown1.Value, 24);
               
                for (int i = 1; i < 26; i++)
                {
                    var control = (Button)this.Controls.Find($"button{i}", true).First();
                    control.Text = "";
                    control.BackColor = Color.Gray;
                }
                ikinci = false;

            }
           
        }
    }
}

        
    

