using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models
{
    public class Linguagens
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome da linguagem")]
        [MaxLength(20, ErrorMessage = "O nome deve conter no máximo 20 caracteres")]
        public string nomeLinguagens { get; set; }
    }
}
