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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Activated += Form2_Activated;
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (string item in DatosGlobales.ListaElementos)
            {
                listBox1.Items.Add(item);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx < 0) return;

            string nombre = DatosGlobales.ListaElementos[idx];
            string telefono = DatosGlobales.ListaNumeros[idx];
            string correo = DatosGlobales.ListaCorreos[idx];

            var detalle = new Form5(nombre, telefono, correo,idx);
            detalle.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
