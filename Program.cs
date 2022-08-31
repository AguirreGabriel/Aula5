using Aula5.Repositorio;
using Aula5.Repositorio.RepositorioImplementacoes;
using Aula5.SistemaValidador;
using System;
using System.Collections.Generic;

namespace Aula5
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Pagamento> listaPagamentosDisponiveis = new List<Pagamento> { new Dinheiro(), new CartaoDeCredito() };
            List<IServidorRepositorio> listaServidoresImplementados = new List<IServidorRepositorio> { new ServidorRepositorioA(), new ServidorRepositorioB() };
            IServidorRepositorio repositorioUtilizar = new ServidorRepositorioA();
            try
            {
                Configuracao configuracao = EscolherConiguracaoServidorRepositorio(listaServidoresImplementados);
                configuracao.RepositorioUtilizar = configuracao.RepositorioUtilizar;
                ValidadorSistema.ValidadorGeral(configuracao, listaPagamentosDisponiveis);

                Pagamento meioPagamentoSelecionado = EscolherMeioDePagamento(listaPagamentosDisponiveis);
                meioPagamentoSelecionado.ValidaPagamento();
                InformaValorPassagem(meioPagamentoSelecionado);

                repositorioUtilizar.Salvar(meioPagamentoSelecionado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void InformaValorPassagem(Pagamento meioPagamentoSelecionado)
        {
            bool ValorValido = false;
            do
            {
                try
                {
                    Console.WriteLine("Qual o Valor da Passagem?");
                    string valorTotalCompra = Console.ReadLine();
                    ValorValido = meioPagamentoSelecionado.ValidaValorPagamento(valorTotalCompra);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (ValorValido == false);
        }

        private static Pagamento EscolherMeioDePagamento(List<Pagamento> listaPagamentosDisponiveis)
        {
            bool EscolheuUmaFormaDePagamento = false;
            Pagamento meioPagamentoSelecionado = null;
            do
            {
                try
                {
                    Console.WriteLine("Escolha o meio de Pagamento de sua Passagem:");
                    foreach (var pagamentoDisponivel in listaPagamentosDisponiveis)
                    {
                        Console.WriteLine($"Digite {pagamentoDisponivel.ID_PAGAMENTO} para {pagamentoDisponivel.NOME_PAGAMENTO}");
                    }

                    string ID_PAGAMENTO = Console.ReadLine();
                    meioPagamentoSelecionado = PagamentoFactory.ValidaIDPagamentoERetornaObjetoPagamento(ID_PAGAMENTO);
                    EscolheuUmaFormaDePagamento = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Tente novamente!");
                }

            } while (EscolheuUmaFormaDePagamento == false);
            return meioPagamentoSelecionado;
        }

        private static Configuracao EscolherConiguracaoServidorRepositorio(List<IServidorRepositorio> listaServidoresImplementados)
        {
            bool EscolheuUmServidor = false;
            IServidorRepositorio ServidorSelecionado;
            Configuracao configuracao = null;

            do
            {
                try
                {
                    Console.WriteLine("Configure em qual servidor vai ser salva a passagem:");
                    foreach (var servidor in listaServidoresImplementados)
                    {
                        Console.WriteLine($"Digite {servidor.ID_SERVIDOR} para {servidor.NOME_SERVIDOR}");
                    }

                    string ID_SERVIDOR = Console.ReadLine();
                    ServidorSelecionado = RepositorioFactory.ValidaIDServidorERetornaObjetoParaUtilizar(ID_SERVIDOR);
                    configuracao = new Configuracao(ServidorSelecionado);
                    EscolheuUmServidor = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Tente novamente!");
                }

            } while (EscolheuUmServidor == false);
            return configuracao;
        }
    }
}