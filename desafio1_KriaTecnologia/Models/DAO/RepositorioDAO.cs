using desafio1_KriaTecnologia.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Models.DAO
{
    public class RepositorioDAO
    {
        private ApplicationDbContext db;

        public void InsertRepositorio(ViewModelRepo vmRepositorio)
        {
            using (db = new ApplicationDbContext())
            {
                string insertQuery = String.Format("Exec InsertRepositorio @nomeRepositorio,@dataUltimaAtt,@nomeDonoRepositorio,@nomeLinguagens,@descricao");
                SqlCommand command = new SqlCommand(insertQuery, db.connection);
                command.Parameters.Add("@nomeRepositorio", SqlDbType.VarChar).Value = vmRepositorio.Repositorio.nomeRepositorio;
                command.Parameters.Add("@dataUltimaAtt", SqlDbType.DateTime).Value = vmRepositorio.Repositorio.dataUltimaAtt;
                command.Parameters.Add("@nomeDonoRepositorio", SqlDbType.VarChar).Value = vmRepositorio.DonoRepositorio.nomeDonoRepositorio;
                command.Parameters.Add("@nomeLinguagens", SqlDbType.VarChar).Value = vmRepositorio.Linguagens.nomeLinguagens;
                command.Parameters.Add("@descricao", SqlDbType.VarChar).Value = vmRepositorio.Repositorio.descricao;

                
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTodosRepositorios()
        {
            string deleteQuery = String.Format("Exec DeletarAll;");

            using (db = new ApplicationDbContext())
            {
               
                db.CommandExecuter(deleteQuery);
            }
        }

        public void DeleteRepositorio(int id)
        {
            string deleteQuery = String.Format("Exec Deletar '{0}'", id);
            using (db = new ApplicationDbContext())
            {
                db.CommandExecuter(deleteQuery);
            }
        }

        public void FavoritarRepositorio(int id)
        {
            string insertQueryFavoritos = String.Format("Exec Favoritos '{0}'", id);
            using (db = new ApplicationDbContext())
            {
                db.CommandExecuter(insertQueryFavoritos);
            }
        }

        public List<ViewModelRepo> SelectTodosRepositorios() 
        {
            using (db = new ApplicationDbContext())
            {
                string selectQuery = "Select r.Id, r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_Repositorios as r join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id order by r.Id desc;";
                var leitor = db.CommandRetuner(selectQuery);
                return ConvertReaderToListRepositorio(leitor);
            }
        }

        public List<ViewModelRepo> SelectTodosRepositoriosFavoritados()
        {
            using (db = new ApplicationDbContext())
            {
                string selectQuery = "Select r.Id, r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_favoritos as f join tb_Repositorios as r on f.idRepositorio = r.Id join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id  order by r.Id desc;";
                var leitor = db.CommandRetuner(selectQuery);
                return ConvertReaderToListRepositorio(leitor);
            }
        }

        public List<ViewModelRepo> SelectPesquisaRepositorios(string search)
        {
            using (db = new ApplicationDbContext())
            {
                string selectQuery = String.Format("Select r.Id, r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_Repositorios as r join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id where r.nomeRepositorio like '%{0}%' or l.nomeLinguagens like '%{0}%' ;", search);
                var leitor = db.CommandRetuner(selectQuery);
                return ConvertReaderToListRepositorio(leitor);
            }
        }

        public ViewModelRepo SelectRepositorioPorId(int Id) 
        {
            using (db = new ApplicationDbContext())
            {
                string selectQuery = String.Format("Exec SelectRepositoById '{0}'", Id);
                var leitor = db.CommandRetuner(selectQuery);
                return ConvertReaderToListRepositorio(leitor).FirstOrDefault();
            }
        }

        public List<ViewModelRepo> ConvertReaderToListRepositorio(SqlDataReader leitor)
        {
            var repo = new List<ViewModelRepo>();

            while (leitor.Read())
            {
                var lstRepositorio = new ViewModelRepo()
                {
                    Repositorio = new Repositorio
                    {
                        Id = Convert.ToInt32(leitor["Id"]),
                        nomeRepositorio = Convert.ToString(leitor["nomeRepositorio"]),
                        dataUltimaAtt = Convert.ToDateTime(leitor["dataUltimaAtt"]),
                        descricao = Convert.ToString(leitor["descricao"])
                    },
                    DonoRepositorio = new DonoRepositorio
                    {
                        nomeDonoRepositorio = Convert.ToString(leitor["nomeDonoRepositorio"])
                    },
                    Linguagens = new Linguagens
                    {
                        nomeLinguagens = Convert.ToString(leitor["nomeLinguagens"])
                    }
                };
                repo.Add(lstRepositorio);
            }

            leitor.Close();
            return repo;
        }

    
    }
}