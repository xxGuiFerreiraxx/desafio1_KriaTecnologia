using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models
{
    public class DonoRepositorio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do dono deste repositório")]
        [MaxLength(20, ErrorMessage = "O nome deve conter no máximo 20 caracteres")]
        public string nomeDonoRepositorio { get; set; }
    }
}
