using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models
{
    public class ViewModelRepo
    {
        [Required(ErrorMessage = "Digite o nome do Repositório")]
        public Repositorio Repositorio { get; set; }
        [Required(ErrorMessage = "Digite o nome do Repositório")]
        public Linguagens Linguagens { get; set; }
        [Required(ErrorMessage = "Digite o nome do Repositório")]
        public DonoRepositorio DonoRepositorio { get; set; }
        [Required(ErrorMessage = "Digite o nome do Repositório")]
        public Favoritos Favoritos { get; set; }
    }
}
