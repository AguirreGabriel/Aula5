using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5.Repositorio.RepositorioImplementacoes
{
    public class ServidorRepositorioA : IServidorRepositorio
    {
        public int ID_SERVIDOR { get => 1; }

        public string NOME_SERVIDOR => "Servidor A";

        public void InformaEmqualServidor()
        {
            Console.WriteLine($"Digite {ID_SERVIDOR} para {NOME_SERVIDOR}");
        }

        public void Salvar(Pagamento pagamento)
        {
            Console.WriteLine($"Servidor AAA - Salvando pagamento: {pagamento}");
        }
    }
}
