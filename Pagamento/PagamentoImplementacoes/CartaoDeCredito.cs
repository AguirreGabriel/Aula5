using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aula5
{
    public class CartaoDeCredito : Pagamento
    {
        public override int ID_PAGAMENTO { get => 2; }
        public override string NOME_PAGAMENTO { get => "Cartão De Crédito"; }
        public string NumeroCartao { get; set; }
        public string CodigoSeguranca { get; set; }       

        public override string ToString()
        {
            return $"Pagamento Cartão de Crédito: Valor - {ValorTotalCompra:C} *** Cartão - {NumeroCartao}";
        }

        public override void ValidaPagamento()
        {
            Console.WriteLine("Compra sendo efetuada com Cartão de Crédito");

            CartaoCreditoAcoes.SolicitaInformacaoNumeroCartao(this);
            CartaoCreditoAcoes.SolicitaInformacaoCodigoSeguranca(this);
        }
        public bool ValidaNumeroCartaoEPopulaPropriedade(string numeroCartaoDigitado)
        {
            bool numeroCartaoInvalido = string.IsNullOrEmpty(numeroCartaoDigitado) || Regex.IsMatch(numeroCartaoDigitado, @"^[0-9]+$") == false;
            if (numeroCartaoInvalido)
            {
                throw new Exception("Número do Cartão digitado inválido");
            }
            this.NumeroCartao = numeroCartaoDigitado;
            return true;
        }

        public bool ValidaCodigoSegurancaEPopulaPropriedade(string codigoSegurancaDigitado)
        {
            bool codigoSegurancaInvalido = string.IsNullOrEmpty(codigoSegurancaDigitado) || Regex.IsMatch(codigoSegurancaDigitado, @"^[0-9]+$") == false || codigoSegurancaDigitado.Length != 3;
            if (codigoSegurancaInvalido)
            {
                throw new Exception("Código de Segurança inválido");
            }
            this.CodigoSeguranca = codigoSegurancaDigitado;
            return true;
        }
    }
}
