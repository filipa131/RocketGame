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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void gumbZatvori_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gumbPokreni_Click(object sender, EventArgs e)
        {
            Form1 formaZaIgru = new Form1();
            formaZaIgru.brzinaBroda = brzinaBroda;
            formaZaIgru.brzinaPozadine = brzinaBroda;
            formaZaIgru.brzinaZida = brzinaBroda;
            formaZaIgru.kolicinaKometa = kolicinaKometa;
            formaZaIgru.kut = kut;
            formaZaIgru.letjelica = letjelica;
            Visible = false;
            formaZaIgru.ShowDialog();
            Visible = true;
        }

        public float brzinaBroda { get; set; } = 5.0f;
        public float brzinaPozadine { get; set; } = 5.0f;
        public float brzinaZida { get; set; } = 5.0f;
        public int kolicinaKometa { get; set; } = 1;
        public float kut { get; set; } = 0.02f;
        public int letjelica { get; set; } = 1;


        private void gumbPostavke_Click(object sender, EventArgs e)
        {
            PostavkeForm postavkeForma = new PostavkeForm();
            postavkeForma.BrzinaBrodaChanged += (s, brzina) =>
            {
                brzinaBroda = brzina;
                brzinaPozadine = brzina;
                brzinaZida = brzina;
            };
            postavkeForma.KolicinaKometaChanged += (s, kolicina) =>
            {
                kolicinaKometa = kolicina;
            };
            postavkeForma.OdabirLetjeliceChanged += (s, Letjelica) =>
            {
                letjelica = Letjelica;
            };
            postavkeForma.ShowDialog();
        }
        
    }
}
