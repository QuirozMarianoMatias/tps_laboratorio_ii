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

namespace CalculadoraTp1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Insert(0, "");
            this.cmbOperador.Items.Insert(1, "+");
            this.cmbOperador.Items.Insert(2, "-");
            this.cmbOperador.Items.Insert(3, "*");
            this.cmbOperador.Items.Insert(4, "/");


            this.cmbOperador.SelectedIndex = 0;


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// este metodo se encarga de vaciar los controles txtNumero1 , txtNumero1 , cmbOperador y lblResultado
        /// </summary>
        private void Limpiar ()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
          this.Close();
        }
        /// <summary>
        /// esta funcion se encarga de llamar a las clases Numero y calculara para realizar la operacion entre dos numeros
        /// </summary>
        /// <param name="numero1">string que despues se ultilizara para el atributo del objeto</param>
        /// <param name="numero2">string que despues se ultilizara para el atributo del objeto</param>
        /// <param name="operador">string que despues se ultilizara para saber el operador</param>
        /// <returns>retorna el resultado de la operacion entre los dos objetos</returns>
        public static double Operar (string numero1, string numero2,string operador)
        {
            double resultado;

            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

          lblResultado.Text =  Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
          lstOperaciones.Text += $"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}\n";
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando binario = new Operando(lblResultado.Text);

            lblResultado.Text = binario.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            Operando decimals = new Operando(lblResultado.Text);

            lblResultado.Text = decimals.BinarioDecimal(lblResultado.Text);

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?","Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            

        }
    }
}
