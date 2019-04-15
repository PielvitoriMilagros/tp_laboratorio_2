using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        Numero numero = new Numero();

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.cmbOperador.Text = "";
            this.txtNumero2.Text = "";
            this.lblResult.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResult.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void btnBinADecimal_Click(object sender, EventArgs e)
        {
            string resultado;
            resultado = numero.BinarioDecimal(this.lblResult.Text);
            this.lblResult.Text = resultado;
        }

        private void btnDecABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            resultado = numero.DecimalBinario(this.lblResult.Text);
            this.lblResult.Text = resultado;
        }
    }
}
