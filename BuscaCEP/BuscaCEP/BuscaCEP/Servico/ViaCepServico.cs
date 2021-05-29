using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using BuscaCEP.Servico.Model;
using Newtonsoft.Json;

namespace BuscaCEP.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.Cep == null) return null;

            return end;
        }
    }
}
