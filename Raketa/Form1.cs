using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        Image pozadina = Properties.Resources.pozadina;
        Image zid = Properties.Resources.zid;
        float sirina, visina;
        float brzinaPozadine, brzinaZida, brzinaBroda;
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
            labelaBodovi.Text = labelaBodovi1.Text
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
            brzinaPozadine = 0.5f;
            brzinaZida = 4;
            brzinaBroda = 5;
            brod.Location = new Point
                ((int)sirina / 2 - brod.Size.Width / 2,
                (int)visina - brod.Size.Height - 10);
        }

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
                if (prepreka1.Top > visina)
                {
                    povecajBodove(1);
                    prepreka1.Top = -prepreka1.Height;
                    progressBar1.Value = Math.Min
                        (progressBar1.Value + 60, 1000);
                }
                if (prepreka2.Top > visina)
                {
                    povecajBodove(1);
                    prepreka2.Top = -prepreka2.Height;
                    progressBar1.Value = Math.Min
                        (progressBar1.Value + 60, 1000);
                }
            }
            progressBar1.Value -= 1;

            if (random.Next() % 100 == 0)
                StvoriKomet();

            foreach (Control kontrola in Controls)
            {
                if (kontrola is PictureBox x &&
                    (string)x.Tag == "komet")
                {
                    x.Top += (int)(kretanje ? (brzinaZida + brzinaBroda)
                        : brzinaZida);
                    if (x.Top > visina)
                    {
                        Controls.Remove(kontrola);
                        x.Dispose();
                    }
                }
            }

            Invalidate();
            if (brod.Bounds.IntersectsWith(prepreka1.Bounds)
                || brod.Bounds.IntersectsWith(prepreka2.Bounds)
                || progressBar1.Value == 0)
            {
                GameOver();
                return;
            }
            foreach (Control kontrola in Controls)
            {
                if (kontrola is PictureBox x && (string)x.Tag == "komet")
                {
                    if (brod.Bounds.IntersectsWith(x.Bounds))
                    {
                        GameOver();
                        return;
                    }
                }
            }
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
                if (Controls[i] is PictureBox x && (string)x.Tag == "komet")
                {
                    x.Visible = false;
                    Controls.Remove(Controls[i]);
                    x.Dispose();
                }
            }
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
            komet.BackColor = Color.LightSalmon;
            komet.BorderStyle = BorderStyle.FixedSingle;
            komet.Top = -komet.Height;
            komet.Left = (int)(0.1 * sirina + 1)
                + random.Next(0, (int)(0.8 * sirina - komet.Width));
            komet.Tag = "komet";

            Controls.Add(komet);
            komet.BringToFront();
        }
    }
}
