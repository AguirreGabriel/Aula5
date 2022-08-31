using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5
{
    public class Dinheiro : Pagamento
    {
        public override int ID_PAGAMENTO { get => 1; }
        public override string NOME_PAGAMENTO { get => "Dinheiro"; }

        public override string ToString()
        {
            return $"Pagamento Dinheiro: Valor - {this.ValorTotalCompra:C}";
        }

        public override void ValidaPagamento()
        {
            Console.WriteLine("Compra sendo efetuada com Dinheiro");
        }
    }
}
