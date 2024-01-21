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
    public partial class PostavkeForm : Form
    {
        public PostavkeForm()
        {
            InitializeComponent();
        }

        public float brzinaBroda { get; set; } = 5.0f;
        public float brzinaPozadine { get; set; } = 5.0f;
        public float brzinaZida { get; set; } = 5.0f;
        public int kolicinaKometa { get; set; } = 1;
        public float kut { get; set; } = 0.02f;
        public int letjelica { get; set; } = 1;


        public event EventHandler<float> BrzinaBrodaChanged;
        public event EventHandler<int> KolicinaKometaChanged;
        public event EventHandler<int> OdabirLetjeliceChanged;

        private void brzinaBrodaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (brzinaBrodaComboBox.SelectedItem != null && float.TryParse(brzinaBrodaComboBox.SelectedItem.ToString(), out float brzina))
            {
                brzinaBroda = brzina;
                brzinaPozadine = brzina;
                brzinaZida = brzina;
                kut = brzina / 250;
            }
            BrzinaBrodaChanged?.Invoke(this, brzinaBroda);
        }

        private void kolicinaKometaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kolicinaKometaComboBox.SelectedItem != null)
            {
                if (kolicinaKometaComboBox.SelectedItem.ToString() == "x2")
                    kolicinaKometa = 2;
                else if (kolicinaKometaComboBox.SelectedItem.ToString() == "x1")
                    kolicinaKometa = 1;
                else
                    kolicinaKometa = 0;
            }
            KolicinaKometaChanged?.Invoke(this, kolicinaKometa);
        }
        private void odabirLetjeliceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (odabirLetjeliceComboBox.SelectedItem != null)
            {
                if (odabirLetjeliceComboBox.SelectedItem.ToString() == "raketa")
                    letjelica = 2;
                else     
                    letjelica = 1;
            }
            OdabirLetjeliceChanged?.Invoke(this, letjelica);
        }

        private void gumbSpremi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
