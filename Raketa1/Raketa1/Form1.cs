using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raketa1
{
    public partial class Form1 : Form
    {
        float sirina, visina;
        public Form1()
        {
            InitializeComponent();
            sirina = ClientSize.Width;
            visina = ClientSize.Height;
            PocetnePostavke();
            timer1.Start();
            DoubleBuffered = true;
        }
        private void povecajBodove(int dobiveniBodovi)
        {
            bodovi += dobiveniBodovi;
            labelaBodovi.Text = "Bodovi: " + bodovi;
        }
        private void PocetnePostavke()
        {
            bodovi = 0;
            povecajBodove(0);
            lijevo = desno = false;
            kretanje = false;
            brzinaPozadine = 0.5f;
            brzinaZida = 4;
            brzinaBroda = 5;
            koordPozadina = new float[] { -visina, 0 };
            koordZid = new float[] { -visina, 0 };
            brod.Location = new Point(
                (int)sirina / 2 - brod.Size.Width / 2,
                (int)visina - brod.Size.Height - 10
            );
        }

        Image pozadina = Properties.Resources.pozadina;
        Image zid = Properties.Resources.zid;
        float brzinaPozadine, brzinaZida, brzinaBroda;
        float[] koordPozadina, koordZid;
        bool kretanje, lijevo, desno;
        int bodovi;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && kretanje)
                kretanje = false;
            if (e.KeyCode == Keys.Left)
                lijevo = false;
            if (e.KeyCode == Keys.Right)
                desno = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up && !kretanje)
                kretanje = true;
            if (e.KeyCode == Keys.Left)
                lijevo = true;
            if (e.KeyCode == Keys.Right)
                desno = true;
        }

        private void PomakniPozadinu()
        {
            for (int i = 0; i < 2; i++)
            {
                if (koordPozadina[i] > visina)
                    koordPozadina[i] -= 2 * visina;
                if (koordZid[i] > visina)
                    koordZid[i] -= 2 * visina;
                if (kretanje == true)
                {
                    koordPozadina[i] += brzinaPozadine;
                    koordZid[i] += brzinaZida;
                }
            }
            Invalidate();
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
                }
                if (prepreka2.Top > visina)
                {
                    povecajBodove(1);
                    prepreka2.Top = -prepreka2.Height;
                }
            }
            Invalidate();
            if (brod.Bounds.IntersectsWith(prepreka1.Bounds)
                || brod.Bounds.IntersectsWith(prepreka2.Bounds))
                GameOver();
        }

        private void GameOver()
        {
            timer1.Stop();
            MessageBox.Show("Osvojeni bodovi: "
                + bodovi, "Igra je završila!");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 2; ++i)
            {
                e.Graphics.DrawImage(pozadina, 0, koordPozadina[i], sirina, visina);
            }
            for (int i = 0; i < 2; ++i)
            {
                e.Graphics.DrawImage(zid, 0, koordZid[i], 0.1f * sirina, visina);
                e.Graphics.DrawImage(zid, 0.9f * sirina, koordZid[i],
                    0.1f * sirina, visina);
            }
        }
    }
}
