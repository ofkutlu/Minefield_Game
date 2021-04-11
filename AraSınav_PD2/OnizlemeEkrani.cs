using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AraSınav_PD2
{
    public partial class OnizlemeEkrani : Form
    {
        public OnizlemeEkrani()
        {
           
            InitializeComponent();
        }  
        private void OnizlemeEkrani_Load(object sender, EventArgs e)
        {
           
            Mayin_doldur(Vize._mayinSayisi, 24);

            for (int i = 1; i < 26; i++)
            {
                var control = (Button)this.Controls.Find($"button{i}", true).First();
                object tag = control.Tag;
                var isMayin = (bool)tag.GetType().GetProperty("isMayin").GetValue(tag);
                var mayinSayisi = (int)tag.GetType().GetProperty("mayinSayisi").GetValue(tag);

                if (isMayin == true)
                {
                    control.BackColor = Color.Red;
                    control.Text = mayinSayisi.ToString();

                }
                else
                {

                    control.BackColor = Color.Green;
                    control.Text = mayinSayisi.ToString();


                }
            }
        }
        public void Mayin_doldur(int mayinSayisi, int boyut)
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

    }
}
