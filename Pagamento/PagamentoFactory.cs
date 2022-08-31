using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5
{
    public static class PagamentoFactory
    {        
        public static Pagamento ValidaIDPagamentoERetornaObjetoPagamento(string id_pagamento) 
        {
            bool converteuEmMeioPagamento = Enum.TryParse(id_pagamento, out EnumMeioPagamento meioPagamento);
            if (converteuEmMeioPagamento)
            {
                switch (meioPagamento)
                {
                    case EnumMeioPagamento.Dinheiro:
                        return new Dinheiro();
                    case EnumMeioPagamento.CartaoDeCredito:
                        return new CartaoDeCredito();
                    default:
                        throw new Exception("Meio de pagamento não identificado!");
                }               
            }
            else
            {
                throw new Exception("ID inválido, meio de pagamento não identificado!");
            }
        }
    }
}
