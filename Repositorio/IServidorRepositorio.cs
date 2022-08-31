using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5.Repositorio
{
    public interface IServidorRepositorio
    {
        public int ID_SERVIDOR { get; }
        public string NOME_SERVIDOR { get; }
        public void Salvar(Pagamento pagamento);
        public virtual void InformaEmqualServidor()
        {
            Console.WriteLine($"Digite {ID_SERVIDOR} para {NOME_SERVIDOR}");
        }
    }
}
