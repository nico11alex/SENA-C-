using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyecto.Form4;

namespace proyecto
{
    public partial class Form3 : Form
    {
        public string ValorBusqueda { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            textBox1.Text = ValorBusqueda;
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private List<int> indicesResultados = new List<int>();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string criterio = textBox1.Text.Trim();
            listBox1.Items.Clear();
            indicesResultados.Clear();

            for (int i = 0; i < DatosGlobales.ListaElementos.Count; i++)
            {
                if (DatosGlobales.ListaElementos[i].Contains(criterio) ||
                    DatosGlobales.ListaNumeros[i].Contains(criterio))
                {
                    listBox1.Items.Add(DatosGlobales.ListaElementos[i]);
                    indicesResultados.Add(i);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = listBox1.SelectedIndex;
            if (sel < 0 || sel >= indicesResultados.Count)
                return;

            int realIndex = indicesResultados[sel];

            var form5 = new Form5(
                DatosGlobales.ListaElementos[realIndex],
                DatosGlobales.ListaNumeros[realIndex],
                DatosGlobales.ListaCorreos[realIndex],
                realIndex
            );

            form5.Show();
            this.Hide();
        }
    }
}
