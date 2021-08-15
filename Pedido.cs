using System.Collections.Generic;

namespace DemoRavendbTrapp
{
    public class Pedido
    {
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public ClientePedido ClientePedido { get; set; }
        public List<PedidoItem> PedidoItens { get; set; }
    }
}