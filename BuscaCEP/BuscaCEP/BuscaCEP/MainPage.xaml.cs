using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BuscaCEP.Servico;
using BuscaCEP.Servico.Model;

namespace BuscaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = ""; 

            if (!string.IsNullOrEmpty(CEP.Text))
            {
                cep = CEP.Text.Trim();
            }
            
            if (IsValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    
                    if(end != null)
                    {
                        Resultado.Text = end.ToString();
                        
                    }
                    else
                    {
                        DisplayAlert("Ops", "Não encontramos um endereço para o CEP informado.", "Ok");
                        CEP.Text = "";
                    }
                    
                }
                catch (Exception)
                {
                    DisplayAlert("Erro", "Falha de comunicação com o serviço, verifique sua conexão com a internet.", "Ok");
                }
            }
            
        }

        private bool IsValidCep(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Ops", "Cep Inválido! O Cep deve conter 8 caracteres.", "Ok");
                return false;
            }

            //Converte o valor de cep para o novoCep
            int novoCep;
            if (!int.TryParse(cep, out novoCep))
            {
                //Todo - Erro: Cep inválido
                DisplayAlert("Ops", "Cep Inválido! O Cep deve conter apenas números.", "Ok");
                return false;
            }

            return true;
        }

    }
}
