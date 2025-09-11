using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temas1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Alguno de los campos están vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try 
                {
                    int numero1 = int.Parse(textBox1.Text);
                    int numero2 = int.Parse(textBox2.Text);
                    label2.Text = "= " + (numero1 + numero2).ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Alguno de los campos no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label2.Text = "= ";
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Alguno de los números es demasiado grande o demasiado pequeño", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label2.Text = "= ";
                }
            }
        }
    }
}
