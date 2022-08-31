using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5.SistemaValidador
{
    public static class ValidadorSistema
    {
        public const string EXIT = "EXIT";
        public static void ValidadorGeral(Configuracao configuracao, List<Pagamento> listaPagamentosDisponiveis)
        {
            ValidaConfiguracao(configuracao);
            ValidaListaPagamentoCadastrado(listaPagamentosDisponiveis);
        }
        private static void ValidaConfiguracao(Configuracao configuracao)
        {
            bool configuracaoInvalida = configuracao == null || configuracao.RepositorioUtilizar == null;
            if (configuracaoInvalida)
            {
                throw new Exception("Atenção Sistema inoperante, não contém configuração");
            }
        }
        private static void ValidaListaPagamentoCadastrado(List<Pagamento> listaPagamentosDisponiveis)
        {
            bool NaoContemListaPagamento = listaPagamentosDisponiveis == null || listaPagamentosDisponiveis.Count == 0;
            if (NaoContemListaPagamento)
            {
                throw new Exception("Atenção Sistema inoperante, não contém lista de pagamentos cadastrados");
            }
        }

        public static void LoopingInformaValoresEValida(string PerguntaSolicitacao, Func<string, bool> validador)
        {
            bool ValorValido = false;
            bool DIGITOU_EXIT = false;
            do
            {
                try
                {
                    Console.WriteLine(PerguntaSolicitacao);
                    string valorDigitado = Console.ReadLine();

                    if (valorDigitado.ToLower() == EXIT)
                    {
                        DIGITOU_EXIT = true;
                        return;
                    }

                    ValorValido = validador.Invoke(valorDigitado);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (ValorValido == false || DIGITOU_EXIT == false);
        }


        public static Object LoopingInformaValoresValidaERetornObjeto(Func<string, Object> validador, List<Action> listaPerguntas, Object entidade)
        {
            bool ValorValido = false;
            bool DIGITOU_EXIT = false;
            do
            {
                try
                {
                    foreach (var item in listaPerguntas)
                    {
                        item.Invoke();
                    }

                    string valorDigitado = Console.ReadLine();

                    if (valorDigitado.ToUpper() == EXIT)
                    {
                        DIGITOU_EXIT = true;
                        throw new Exception(EXIT);
                    }

                    entidade = validador.Invoke(valorDigitado);
                }
                catch (Exception e)
                {
                    if (e.Message == EXIT)
                    {
                        throw new Exception("Sistema encerrado pelo usuário.");
                    }
                    Console.WriteLine(e.Message);
                }
            } while (ValorValido == false || DIGITOU_EXIT == false);
            return entidade;
        }
    }
}
