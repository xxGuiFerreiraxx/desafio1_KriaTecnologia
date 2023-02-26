using desafio1_KriaTecnologia.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models.DAO
{
    public class LinguagensDAO
    {
        private ApplicationDbContext db;

        public List<Linguagens> SelectTodasLinguagens()
        {
            using (db = new ApplicationDbContext())
            {
                string selectQuery = "Select * from tb_Linguagens";
                var leitor = db.CommandRetuner(selectQuery);
                return ConvertReaderLinguagensToList(leitor);
            }
        }

        public List<Linguagens> ConvertReaderLinguagensToList(SqlDataReader leitor)
        {
            var listLinguagens = new List<Linguagens>();

            while (leitor.Read())
            {
                var tempLinguagem = new Linguagens()
                {
                    Id = Convert.ToInt32(leitor["Id"]),
                    nomeLinguagens = Convert.ToString(leitor["nomeLinguagens"])
                };
                listLinguagens.Add(tempLinguagem);
            }

            leitor.Close();
            return listLinguagens;
        }
    }
}
