using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using static proyecto.Form4;

namespace proyecto
{
    public partial class Form5 : Form
    {
        private int contactoIndex;
        public Form5(string nombre, string telefono, string correo, int idx)
        {
            InitializeComponent();
            label1.Text = nombre;
            label2.Text = telefono;
            label3.Text = correo;
            contactoIndex = idx;
            CargarDatos();
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;


        }

        private void CargarDatos()
        {
            label1.Text = DatosGlobales.ListaElementos[contactoIndex];
            label2.Text = DatosGlobales.ListaNumeros[contactoIndex];
            label3.Text = DatosGlobales.ListaCorreos[contactoIndex];
            textBox1.Text = DatosGlobales.ListaElementos[contactoIndex];
            textBox2.Text = DatosGlobales.ListaNumeros[contactoIndex];
            textBox3.Text = DatosGlobales.ListaCorreos[contactoIndex];
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            nombreDeContacto.Visible = false;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatosGlobales.ListaElementos.RemoveAt(contactoIndex);
            DatosGlobales.ListaNumeros.RemoveAt(contactoIndex);
            DatosGlobales.ListaCorreos.RemoveAt(contactoIndex);

            MessageBox.Show("Contacto eliminado correctamente.");
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("NO PUEDES DEJAR LOS CAMPOS VACÍOS");
                return;
            }

            if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("“Error el campo número de teléfono ha superado el límite que son 10 digitos”");
                textBox2.Text = "";
                return;
            }

            string correo = textBox3.Text.Trim();
            if (!EsCorreoValido_MailAddress(correo))
            {
                MessageBox.Show("Correo inválido");
                return;
            }

            string nuevoNombre = FormatearNombre(textBox1.Text.Trim());
            string nuevoTelefono = textBox2.Text.Trim();
            string nuevoCorreo = textBox3.Text.Trim();

            // Verificar duplicados excluyendo el índice actual
            bool nombreDuplicado = DatosGlobales.ListaElementos
                .Where((val, idx) => idx != contactoIndex)
                .Contains(nuevoNombre);

            bool telefonoDuplicado = DatosGlobales.ListaNumeros
                .Where((val, idx) => idx != contactoIndex)
                .Contains(nuevoTelefono);

            if (nombreDuplicado || telefonoDuplicado)
            {
                MessageBox.Show("Ya existe un contacto con ese nombre o teléfono.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizar contacto
            DatosGlobales.ListaElementos[contactoIndex] = nuevoNombre;
            DatosGlobales.ListaNumeros[contactoIndex] = nuevoTelefono;
            DatosGlobales.ListaCorreos[contactoIndex] = nuevoCorreo;

            MessageBox.Show("Contacto modificado correctamente.");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private string FormatearNombre(string nombre)
        {
            var palabras = nombre.Split(' ');
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i].Length > 0)
                {
                    palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", palabras);
        }

        private bool EsCorreoValido_MailAddress(string correo)
        {
            try
            {
                var direccion = new MailAddress(correo);
                if (!correo.Contains("."))
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 10)
            {
                MessageBox.Show("EL TELEFONO DEBE TENER 10 DIGITOS");
                textBox2.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("EL CAMPO NOMBRE TIENE QUE RECIBIR UNICAMENTE LETRAS");
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("EL CAMPO TELEFONO TIENE QUE RECIBIR UNICAMENTE NÚMERICOS");
                e.Handled = true;
            }
        }
    }
}
