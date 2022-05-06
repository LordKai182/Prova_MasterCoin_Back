using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Entity
{
    public class Cotacao
    {

        public double valor { get; set; }
        public Cotacao(float valorEmReal)
        {
            var client = new RestClient("https://economia.awesomeapi.com.br/all/USD-BRL");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var teste = Newtonsoft.Json.JsonConvert.DeserializeObject<Cotacao.Root>(response.Content);

            var Valor_dolar = Math.Round((float)teste.USD.bid, 2);

            var Valor_real = valorEmReal;

            var Conversao = Math.Round((Valor_real * Valor_dolar), 2);

            valor = Conversao;


        }

        private class USD
        {
            public string code { get; set; }
            public string codein { get; set; }
            public string name { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string varBid { get; set; }
            public string pctChange { get; set; }
            public float bid { get; set; }
            public string ask { get; set; }
            public string timestamp { get; set; }
            public string create_date { get; set; }
        }

        private class Root
        {
            public USD USD { get; set; }



        }
    }
}
