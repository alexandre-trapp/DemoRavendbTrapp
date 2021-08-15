using Newtonsoft.Json;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;

namespace DemoRavendbTrapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ravenDb = new DocumentStore()
            {
                Database = "demo-raven",
                Urls = new[] { "http://localhost:8080" }
            }.Initialize();

            using var session = ravenDb.OpenSession();
            var pedido = session.Load<Pedido>("pedidos/1-a");

            pedido.PedidoItens = new List<PedidoItem>()
            {
                new PedidoItem
                {
                    Produto = "Brahma duplo malte",
                    Valor = 8.00m,
                    Quantidade = 12
                },
                new PedidoItem
                {
                    Produto = "Geladeira frost free brahma",
                    Valor = 3000m,
                    Quantidade = 2
                }
            };

            //var pedido = new Pedido { Nome = "Brahma", ValorUnitario = 10.50m };

            //pedido.ClientePedido = new ClientePedido()
            //{
            //    Nome = "Alexandre Trapp",
            //    Idade = 28
            //};

            session.SaveChanges();

            Console.WriteLine(JsonConvert.SerializeObject(pedido));
            Console.ReadKey();
        }
    }
}
