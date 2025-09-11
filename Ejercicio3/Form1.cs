#define PRUEBA
namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        int dinero = 50;
        public Form1()
        {
            InitializeComponent();
        }

        public static (int, int, int) valorAleatorio(int min, int max)
        {
            Random random = new Random();
            int numeroAleatorio1 = random.Next(min, max + 1);
            int numeroAleatorio2 = random.Next(min, max + 1);
            int numeroAleatorio3 = random.Next(min, max + 1);
            return (numeroAleatorio1, numeroAleatorio2, numeroAleatorio3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label1.Text = "";
            dinero -= 2;
            (int, int, int) valoresAleatorios = valorAleatorio(1, 7);
            textBox1.Text = valoresAleatorios.Item1.ToString();
            textBox2.Text = valoresAleatorios.Item2.ToString();
            textBox3.Text = valoresAleatorios.Item3.ToString();
            if (textBox1.Text == textBox2.Text && textBox2.Text == textBox3.Text)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Premio Gordo";
                dinero += 20;
            }
            else
            {
                if (textBox1.Text == textBox2.Text || textBox2.Text == textBox3.Text || textBox1.Text == textBox3.Text)
                {
                    label1.ForeColor = Color.Blue;
                    label1.Text = "Premio";
#if PRUEBA
                    dinero -= 5;
#else
                    dinero += 5;
#endif
                }
            }
            label2.Text = "Dinero: " + dinero;
            if (dinero < 2)
            {
                button1.Enabled = false;
                label1.Text = "Te has quedado sin dinero";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dinero += 10;
            label2.Text = "Dinero: " + dinero;
            button1.Enabled = true;
        }
    }
}
