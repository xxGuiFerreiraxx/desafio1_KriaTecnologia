using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models
{
    public class ViewModelRepo
    {
        public Repositorio Repositorio { get; set; }
        public Linguagens Linguagens { get; set; }
        public DonoRepositorio DonoRepositorio { get; set; }
        public Favoritos Favoritos { get; set; }
    }
}
