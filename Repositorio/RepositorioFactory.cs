using Aula5.Repositorio.RepositorioImplementacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5.Repositorio
{
    public static class RepositorioFactory
    {
        public static IServidorRepositorio ValidaIDServidorERetornaObjetoParaUtilizar(string id_servidor)
        {
            bool converteuServidor = Enum.TryParse(id_servidor, out EnumServidor servidor);
            if (converteuServidor)
            {
                switch (servidor)
                {
                    case EnumServidor.ServidorA:
                        return new ServidorRepositorioA();
                    case EnumServidor.ServidorB:
                        return new ServidorRepositorioB();
                    default:
                        throw new Exception("Servidor não identificado!");
                }
            }
            else
            {
                throw new Exception("ID inválido, Servidor não identificado!");
            }
        }
    }
}
