using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
{
    public partial class Form1 : Form
    {
        string nuevoTitulo = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nuevoTitulo = textBox1.Text;
            DialogResult result = MessageBox.Show($"¿Quieres cambiar el titulo a \"{nuevoTitulo}\"?", "Cambiar título", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Text = nuevoTitulo;
            }
        }
    }
}
