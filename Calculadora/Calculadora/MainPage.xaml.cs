using System;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        int estadoAtual = 1;
        string operadorMatematico;
        double numeroUm, numeroDois;
        public MainPage()
        {


            InitializeComponent();
            Limpar(new object(), new EventArgs()); // chama o Limpar e passa obj e evento em branco.

        }
        // metodo Clear
        private void Limpar(object sender, EventArgs e)
        {
            numeroUm = 0;
            numeroDois = 0;
            estadoAtual = 1;
            this.resultado.Text = "0";
        }

        // metedo para adicionar no resultado os numeros pressionados.
        private void SelecionandoNum(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            string pressionado = botao.Text;

            if (this.resultado.Text == "0" || estadoAtual < 0)
            {
                this.resultado.Text = " ";
                if (estadoAtual < 0)
                {
                    estadoAtual *= -1;
                }
            }
            this.resultado.Text += pressionado;

            double numero;
            if (double.TryParse(this.resultado.Text, out numero))
            {
                this.resultado.Text = numero.ToString("N0");
                if (estadoAtual == 1)
                {
                    numeroUm = numero;
                }
                else
                {
                    numeroDois = numero;
                }
            }
        }
        // metodo para definir os operadores matemáticos.
        private void SelecaoOperador(object sender, EventArgs e)
        {
            estadoAtual = -2;
            Button botao = (Button)sender;
            string pressionado = botao.Text;
            operadorMatematico = pressionado;
        }

        private void ResultadoCalculo(object sender, EventArgs e)
        {
            if (estadoAtual == 2)
            {
                var resultado = 0.0;
                
                if (operadorMatematico == "+")
                {
                    resultado = numeroUm + numeroDois;
                }

                if (operadorMatematico == "-")
                {
                    resultado = numeroUm - numeroDois;
                }

                if (operadorMatematico == "X")
                {
                    resultado = numeroUm * numeroDois;
                }

                if (operadorMatematico == "/")
                {
                    resultado = numeroUm / numeroDois;
                }

                this.resultado.Text = resultado.ToString("N0");
                numeroUm = resultado;
                estadoAtual = -1;
            }
        }



    }
}
