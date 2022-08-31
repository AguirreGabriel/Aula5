using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5
{
    public abstract class Pagamento
    {
        public abstract int ID_PAGAMENTO { get; }
        public abstract string NOME_PAGAMENTO { get; }
        public decimal ValorTotalCompra { get; set; }
        public EnumMeioPagamento MeioPagamento { get; set; }
        public bool ValidaValorPagamento(string ValorPagamento)
        {
            bool valorValido = decimal.TryParse(ValorPagamento, out decimal valorConvertido) && valorConvertido > 0;
            if (valorValido)
            {
                this.ValorTotalCompra = valorConvertido;
                return valorValido;
            }
            else
            {
                throw new Exception("Valor inválido, verifique!");
            }
        }
        public abstract void ValidaPagamento();
    }
}
