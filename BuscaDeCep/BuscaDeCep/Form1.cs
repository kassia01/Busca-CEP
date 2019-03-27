using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaDeCep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscaCep_Click(object sender, EventArgs e)
        {
            string enderecoCompleto = "";

            try
            {
                var service = new CORREIOS.AtendeClienteClient();
                var resposta = service.consultaCEP(txtCep.Text);
                txtRua.Text = resposta.end;
                txtBairro.Text = resposta.bairro;
                txtCidade.Text = resposta.cidade;
                txtEstado.Text = resposta.uf;
                txtComplemento.Text = resposta.complemento2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Esse CEP não esta cadastrado!");
                txtRua.Clear();
                txtBairro.Clear();
                txtCidade.Clear();
                txtEstado.Clear();
                txtComplemento.Clear();
            }
        }
    }
}
