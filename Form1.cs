using AlgoritmoMonteCarlo.Algoritmos;

namespace AlgoritmoMonteCarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                   textBox2.Text.Equals("") ||
                   textBox3.Text.Equals("") ||
                   textBox4.Text.Equals("") ||
                   textBox5.Text.Equals(""))
            {
                MessageBox.Show("Los números tienen que ser diferente de VACÍOS");
                return;
            }

            double limiteInferior = Convert.ToDouble(textBox1.Text);
            double limiteSuperior = Convert.ToDouble(textBox2.Text);
            int totalPaneles = Convert.ToInt32(textBox3.Text);

            int totalExperimentos = Convert.ToInt32(textBox4.Text);
            int seleccionado = Convert.ToInt32(textBox5.Text);


            if (limiteInferior > limiteSuperior)
            {
                MessageBox.Show("Limite Superior debe ser mayor quue limite inferior");
                return;
            }
            List<double> listaSalida = new List<double>();
            SimulacionMonteCarlo simulacion = new SimulacionMonteCarlo();
            listaSalida = simulacion.MonteCarlo(limiteInferior, limiteSuperior, totalPaneles, totalExperimentos, seleccionado);

            textBox7.Text = listaSalida[1].ToString();
            textBox6.Text = listaSalida[0].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
