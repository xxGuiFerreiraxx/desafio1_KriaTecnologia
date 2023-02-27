using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models
{
    public class Repositorio
    {
        public int Id { get; set; }


        public string nomeRepositorio { get; set; }

        public string descricao { get; set; }
        [Required(ErrorMessage = "Indique a data da última atualização")]
        public DateTime dataUltimaAtt { get; set; }
        [ForeignKey("DonoRepositorio")]
        public int idDonoRepositorio { get; set; }
        public virtual DonoRepositorio DonoRepositorio { get; set; }
        [ForeignKey("Linguagens")]
        public int idLinguagem { get; set; }

        public virtual Linguagens Linguagens { get; set; }

       
    }


}
