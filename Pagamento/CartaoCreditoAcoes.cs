using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5
{
    public static class CartaoCreditoAcoes
    {
        public static void SolicitaInformacaoNumeroCartao(CartaoDeCredito pagamento)
        {
            bool validado = false;
            do
            {
                try
                {
                    Console.WriteLine("Informe o numero do cartao:");
                    string numeroCartaoDigitado = Console.ReadLine();
                    validado = pagamento.ValidaNumeroCartaoEPopulaPropriedade(numeroCartaoDigitado);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (validado == false);

        }

        public static void SolicitaInformacaoCodigoSeguranca(CartaoDeCredito pagamento)
        {
            bool validado = false;
            do
            {
                try
                {
                    Console.WriteLine("Informe o Código de Segurança:");
                    string codigoSegurancaDigitado = Console.ReadLine();
                    validado = pagamento.ValidaCodigoSegurancaEPopulaPropriedade(codigoSegurancaDigitado);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (validado == false);
        }
}
}
