using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
        public DateTime dataUltimaAtt { get; set; }
        [ForeignKey("DonoRepositorio")]
        public int idDonoRepositorio { get; set; }
        public virtual DonoRepositorio DonoRepositorio { get; set; }
        [ForeignKey("Linguagens")]
        public int idLinguagem { get; set; }

        public virtual Linguagens Linguagens { get; set; }

        //public void GetAllData()
        //{
        //    try
        //    {
        //        String connectionStr = "server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true";
        //        using (SqlConnection connection = new SqlConnection(connectionStr))
        //        {
        //            connection.Open();
        //            String select = "Select r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_Repositorios as r join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id;";

        //            using(SqlDataReader reader = command.ExecuteReader())
        //            {

        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
    }


}
