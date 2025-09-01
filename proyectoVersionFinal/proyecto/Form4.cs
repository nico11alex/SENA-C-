using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();

        }


        public static class DatosGlobales
        {
            public static List<string> ListaElementos = new List<string>();
            public static List<string> ListaNumeros = new List<string>();
            public static List<string>ListaCorreos = new List<string>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0|| textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("NO PUEDES DEJAR LOS CAMPOS VACÍOS");
                return;
            }

            
            if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("EL TELÉFONO DEBE TENER 10 DÍGITOS");
                textBox2.Text = "";
                return;
            }

            
            string correo = textBox3.Text.Trim();
            if (!EsCorreoValido_MailAddress(correo))
            {
                MessageBox.Show("Correo inválido");
                return;
            }

            string nombres = FormatearNombre(textBox1.Text.Trim());

            if (string.IsNullOrWhiteSpace(nombres))
            {
                MessageBox.Show("Por favor ingrese un nombre valido");
                return;
            }

            string númeroTelefono = textBox2.Text;

            if (DatosGlobales.ListaElementos.Contains(nombres) || DatosGlobales.ListaNumeros.Contains(númeroTelefono))
            {
                MessageBox.Show("Ya existe un contacto con ese nombre o teléfono.", "Duplicado",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string correos = textBox3.Text;
            DatosGlobales.ListaElementos.Add(nombres);
            DatosGlobales.ListaNumeros.Add(númeroTelefono);
            DatosGlobales.ListaCorreos.Add(correos);
            MessageBox.Show("Datos guardados correctamente");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 10)
            {

                MessageBox.Show("EL TELEFONO DEBE TENER 10 DIGITOS");
                textBox2.Text = "";
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
