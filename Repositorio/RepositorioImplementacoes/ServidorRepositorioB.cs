using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5.Repositorio.RepositorioImplementacoes
{
    public class ServidorRepositorioB : IServidorRepositorio
    {
        public int ID_SERVIDOR { get => 2;}
        public string NOME_SERVIDOR => "Servidor B";

        public void Salvar(Pagamento pagamento)
        {
            Console.WriteLine($"Servidor BBB - Salvando pagamento: {pagamento}");
        }

        public void InformaEmqualServidor()
        {
            Console.WriteLine($"Digite {ID_SERVIDOR} para {NOME_SERVIDOR}");
        }
    }
}
