using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raketa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sirina = ClientSize.Width;
            visina = ClientSize.Height;
            PocetnePostavke();
            timer1.Start();
            DoubleBuffered = true;
            labelaBodovi.Parent = prepreka1;
            labelaBodovi1.Parent = prepreka2;
            labelaBodovi.Location = labelaBodovi1.Location
                = new Point(4, 4);

            this.brzinaBroda = brzinaBroda;
            this.brzinaPozadine = brzinaPozadine;
            this.brzinaZida = brzinaZida;
            this.kolicinaKometa = kolicinaKometa;
            this.kut = kut;
            this.letjelica = letjelica;

            if (letjelica == 1)
                this.brod.Image = Properties.Resources.brod;
            else if (letjelica == 2)
                this.brod.Image = Properties.Resources.brod2;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Bottom;
            tableLayoutPanel.Height = 40;
            tableLayoutPanel.BackColor = Color.Black;  
            tableLayoutPanel.BringToFront();
            this.Controls.Add(tableLayoutPanel);

            labelaBodovi2.Parent = tableLayoutPanel;
            labelaBodovi2.Dock = DockStyle.Right;
            labelaBodovi2.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(labelaBodovi2);

            string currentDirectory = Environment.CurrentDirectory;
            string documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.Write("currentDirectory: " + currentDirectory);
            string path = Path.Combine(currentDirectory, "mambo.wav");
            PlayMusic(path);
        }

        public static void PlayMusic(string filepath)
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();
        }

        private void StopMusic()
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            if (musicPlayer != null)
            {
                musicPlayer.Stop();
                musicPlayer.Dispose();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopMusic();
        }

        int brojZivota;
        Image pozadina = Properties.Resources.pozadina;
        Image zid = Properties.Resources.zid;
        float sirina, visina;

        public float brzinaBroda { get; set; } = 5.0f;
        public float brzinaPozadine { get; set; } = 5.0f;
        public float brzinaZida { get; set; } = 5.0f;
        public int kolicinaKometa { get; set; } = 1;
        public float kut { get; set; } = 0.02f;

        public int Letjelica;
        public int letjelica
        {
            get { return Letjelica; }
            set
            {
                Letjelica = value;
                if (Letjelica == 1)
                    brod.Image = Properties.Resources.brod;
                else if (Letjelica == 2)
                    brod.Image = Properties.Resources.brod2;
            }
        }

        float[] koordPozadina, koordZid;
        bool lijevo, desno;
        bool krajIgre;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && !kretanje)
                kretanje = true;
            if (e.KeyCode == Keys.Left)
                lijevo = true;
            if (e.KeyCode == Keys.Right)
                desno = true;
            if (e.KeyCode == Keys.P)
                TogglePauza();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && kretanje)
                kretanje = false;
            if (e.KeyCode == Keys.Left)
                lijevo = false;
            if (e.KeyCode == Keys.Right)
                desno = false;
            if (e.KeyCode == Keys.R && krajIgre)
            {
                PocetnePostavke();
                timer1.Start();
            }
        }

        bool kretanje;
        int bodovi;

        void povecajBodove(int dobiveniBodovi)
        {
            bodovi += dobiveniBodovi;
            labelaBodovi.Text = labelaBodovi1.Text = labelaBodovi2.Text
                = "Bodovi: " + bodovi;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (!krajIgre)
            {
                timer1.Stop();
                if (kretanje || lijevo || desno)
                    kretanje = lijevo = desno = false;
                labelaPauza.Visible = true;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (!krajIgre)
            {
                labelaPauza.Visible = false;
                timer1.Start();
            }
        }

        private void PocetnePostavke()
        {
            progressBar1.Value = 1000;
            labelaPauza.Visible = false;
            krajIgre = false;
            labelaRestartPoruka.Visible = false;
            prepreka1.Location = new Point(10, 205);
            prepreka2.Location = new Point(205, 10);
            bodovi = 0;
            povecajBodove(0);
            lijevo = desno = false;
            kretanje = false;
            koordPozadina = new float[] { -visina, 0 };
            koordZid = new float[] { -visina, 0 };
            brod.Location = new Point
                ((int)sirina / 2 - brod.Size.Width / 2,
                (int)visina - brod.Size.Height - 10 - 40);
            brojZivota = 3;
            srce1.Visible = true;
            srce2.Visible = true;
            srce3.Visible = true;
        }

        private void NastavnePostavke()
        {
            progressBar1.Value = 1000;
            labelaPauza.Visible = false;
            krajIgre = false;
            labelaRestartPoruka.Visible = false;
            prepreka1.Location = new Point(10, 205);
            prepreka2.Location = new Point(205, 10);
            lijevo = desno = false;
            kretanje = false;
            koordPozadina = new float[] { -visina, 0 };
            koordZid = new float[] { -visina, 0 };
            brod.Location = new Point
                ((int)sirina / 2 - brod.Size.Width / 2,
                (int)visina - brod.Size.Height - 10 - 40);
            if (brojZivota == 2) 
            {
                srce1.Visible = true;
                srce2.Visible = true;
                srce3.Visible = false;
            }
            else if (brojZivota == 1)
            {
                srce1.Visible = true;
                srce2.Visible = false;
                srce3.Visible = false;
            }
            else if (brojZivota == 0)
            {
                srce1.Visible = false;
                srce2.Visible = false;
                srce3.Visible = false;
            }
        }

        private double Kut = 0.0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            PomakniPozadinu();
            if (lijevo && !desno &&
                brod.Left - brzinaBroda >= 0.1 * sirina)
                brod.Left -= (int)brzinaBroda;
            if (desno && !lijevo &&
                brod.Right + brzinaBroda <= 0.9 * sirina)
                brod.Left += (int)brzinaBroda;

            if (kretanje)
            {
                prepreka1.Top += (int)brzinaZida;
                prepreka2.Top += (int)brzinaZida;

                if (prepreka1.Top > visina - 80)
                {
                    povecajBodove(1);
                    prepreka1.Top = -prepreka1.Height;
                    progressBar1.Value = Math.Min
                        (progressBar1.Value + 60, 1000);
                }
                if (prepreka2.Top > visina - 80)
                {
                    povecajBodove(1);
                    prepreka2.Top = -prepreka2.Height;
                    progressBar1.Value = Math.Min
                        (progressBar1.Value + 60, 1000);
                }
            }

            prepreka1.Left = (int)(Math.Sin(Kut) * sirina / 4 + sirina / 2 - 90);
            prepreka2.Left = (int)(Math.Sin(Kut + Math.PI) * sirina / 4 + sirina / 2 - 90);

            Kut += kut;

            progressBar1.Value -= 1;

            if (random.Next() % 100 == 0)
                for (int i = 0; i < kolicinaKometa; i++)
                    StvoriKomet();

            if (random.Next() % 100 == 0)
                StvoriBonus();

            foreach (Control kontrola in Controls)
            {
                if (kontrola is PictureBox x &&
                    ((string)x.Tag == "komet" || (string)x.Tag == "bonus"))
                {
                    x.Top += (int)(kretanje ? (brzinaZida + brzinaBroda)
                        : brzinaZida);
                    if (x.Top > visina - 60)
                    {
                        Controls.Remove(kontrola);
                        x.Dispose();
                    }
                }
            }

            Invalidate();
            if(progressBar1.Value == 0)
            {
                GameOver();
                return;
            }       
            if (brod.Bounds.IntersectsWith(prepreka1.Bounds))
            {
                brojZivota -= 1;
                if (brojZivota == 2)
                {
                    srce1.Visible = true;
                    srce2.Visible = true;
                    srce3.Visible = false;
                    NotGameOver();
                }
                else if (brojZivota == 1)
                {
                    srce1.Visible = true;
                    srce2.Visible = false;
                    srce3.Visible = false;
                    NotGameOver();
                }
                else if (brojZivota == 0)
                {
                    srce1.Visible = false;
                    srce2.Visible = false;
                    srce3.Visible = false;
                    GameOver();
                    return;
                }
            }
            if (brod.Bounds.IntersectsWith(prepreka2.Bounds))
            {
                brojZivota -= 1;
                if (brojZivota == 2)
                {
                    srce1.Visible = true;
                    srce2.Visible = true;
                    srce3.Visible = false;
                    NotGameOver();
                }
                else if (brojZivota == 1)
                {
                    srce1.Visible = true;
                    srce2.Visible = false;
                    srce3.Visible = false;
                    NotGameOver();
                }
                else if (brojZivota == 0)
                {
                    srce1.Visible = false;
                    srce2.Visible = false;
                    srce3.Visible = false;
                    GameOver();
                    return;
                }
            }
            foreach (Control kontrola in Controls)
            {
                if (kontrola is PictureBox x)
                {
                    if ((string)x.Tag == "komet")
                    {
                        if (brod.Bounds.IntersectsWith(x.Bounds))
                        {
                            brojZivota -= 1;
                            if (brojZivota == 2)
                            {
                                Controls.Remove(kontrola);
                                x.Dispose();
                                srce1.Visible = true;
                                srce2.Visible = true;
                                srce3.Visible = false;
                            }
                            else if (brojZivota == 1)
                            {
                                Controls.Remove(kontrola);
                                x.Dispose();
                                srce1.Visible = true;
                                srce2.Visible = false;
                                srce3.Visible = false;
                            }
                            else if (brojZivota == 0)
                            {
                                srce1.Visible = false;
                                srce2.Visible = false;
                                srce3.Visible = false;
                                GameOver();
                                return;
                            }
                        }
                    }
                    else if ((string)x.Tag == "bonus")
                    {
                        if (brod.Bounds.IntersectsWith(x.Bounds))
                        {
                            povecajBodove(5);
                            Controls.Remove(kontrola);
                            x.Dispose();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GameOver()
        {
            timer1.Stop();
            krajIgre = true;
            labelaRestartPoruka.Visible = true;
            MessageBox.Show("Osvojeni bodovi: " + bodovi,
                "Igra je završila!");
            for(int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is PictureBox x && ((string)x.Tag == "komet" || (string)x.Tag == "bonus"))
                {
                    x.Visible = false;
                    Controls.Remove(Controls[i]);
                    x.Dispose();
                }
            }
        }

        private void NotGameOver()
        {
            timer1.Stop();
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is PictureBox x && ((string)x.Tag == "komet" || (string)x.Tag == "bonus"))
                {
                    x.Visible = false;
                    Controls.Remove(Controls[i]);
                    x.Dispose();
                }
            }
            NastavnePostavke();
            timer1.Start();
        }

        private void PomakniPozadinu()
        {
            for (int i = 0; i < 2; i++)
            {
                if (koordPozadina[i] > visina)
                    koordPozadina[i] -= 2 * visina;
                if (koordZid[i] > visina)
                    koordZid[i] -= 2 * visina;
                if (kretanje)
                {
                    koordPozadina[i] += brzinaPozadine;
                    koordZid[i] += brzinaZida;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 2; ++i)
            {
                e.Graphics.DrawImage(pozadina, 0, koordPozadina[i],
                sirina, visina);
            }
            for (int i = 0; i < 2; ++i)
            {
                e.Graphics.DrawImage(zid, 0, koordZid[i],
                    0.1f * sirina, visina);
                e.Graphics.DrawImage(zid, 0.9f * sirina, koordZid[i],
                    0.1f * sirina, visina);
            }
        }

        Random random = new Random();
        private void StvoriKomet()
        {
            PictureBox komet = new PictureBox();
            komet.Size = new Size(20, 20);
            komet.Image = Properties.Resources.komet;
            komet.SizeMode = PictureBoxSizeMode.StretchImage;
            komet.BackColor = Color.Transparent;
            komet.BorderStyle = BorderStyle.None;
            komet.Top = -komet.Height;
            komet.Left = (int)(0.1 * sirina + 1)
                + random.Next(0, (int)(0.8 * sirina - komet.Width));
            komet.Tag = "komet";
            Controls.Add(komet);
            komet.SendToBack();
        }

        private void StvoriBonus()
        {
            PictureBox bonus = new PictureBox();
            bonus.Size = new Size(20, 20);
            bonus.Image = Properties.Resources.bonus;
            bonus.SizeMode = PictureBoxSizeMode.StretchImage;
            bonus.BackColor = Color.Transparent;
            bonus.BorderStyle = BorderStyle.None;
            bonus.Top = -bonus.Height;
            bonus.Left = (int)(0.1 * sirina + 1)
                + random.Next(0, (int)(0.8 * sirina - bonus.Width));
            bonus.Tag = "bonus";

            Controls.Add(bonus);
            bonus.SendToBack();
        }

        bool pauza = false;
        private void TogglePauza()
        {
            if (!krajIgre)
            {
                pauza = !pauza;
                if (pauza)
                {
                    timer1.Stop();
                    if (kretanje || lijevo || desno)
                        kretanje = lijevo = desno = false;
                    labelaPauza.Visible = true;
                }
                else
                {
                    labelaPauza.Visible = false;
                    timer1.Start();
                }
            }
        }
    }
}
