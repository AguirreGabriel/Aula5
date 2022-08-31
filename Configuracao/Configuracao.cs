using Aula5.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula5
{
    public class Configuracao
    {
        public IServidorRepositorio RepositorioUtilizar { get; set; }
        public Configuracao(IServidorRepositorio servidorRepositorio)
        {
            this.RepositorioUtilizar = servidorRepositorio;
        }
    }
}
