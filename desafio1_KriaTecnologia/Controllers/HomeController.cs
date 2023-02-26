using desafio1_KriaTecnologia.DataBase;
using desafio1_KriaTecnologia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace desafio1_KriaTecnologia.Controllers
{
    public class HomeController : Controller
    {

        /*readonly private ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }*/


        public IActionResult Index()
        {
            var repositorios = ListaMeusRepositorios();
            return View(repositorios);
        }

        [Route("detalhes/{id?}")]
        public IActionResult detalhes(int Id)
        {
            string conexao = "server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true";
            using (SqlConnection connection = new SqlConnection(conexao))
            { 
                string selectQuery = String.Format("Exec SelectRepositoById '{0}'", Id);
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Connection.Open();
                var dados = command.ExecuteReader();
                return View(listaRepositorio(dados).FirstOrDefault());
            }   
        }

        public List<ViewModelRepo> ListaMeusRepositorios()
        {
            string conexao = "server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true";
            using (SqlConnection connection = new SqlConnection(conexao))
            {
                string queryString = "Select r.Id, r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_Repositorios as r join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id order by r.Id desc;";
                SqlCommand exibir = new SqlCommand(queryString,connection);
                exibir.Connection.Open();
                var leitor = exibir.ExecuteReader();

                return listaRepositorio(leitor);
            }
         
        }

        

        public List<ViewModelRepo> listaRepositorio(SqlDataReader leitor)
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
                        nomeDonoRepositorio =  Convert.ToString(leitor["nomeDonoRepositorio"])
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
        
        public List<Linguagens> SelectTodasLinguagens()
        {
            string conexao = "server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true";
            using (SqlConnection connection = new SqlConnection(conexao))
            {
                string queryString = "Select * from tb_Linguagens";
                SqlCommand exibir = new SqlCommand(queryString, connection);
                exibir.Connection.Open();
                var leitor = exibir.ExecuteReader();
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

        public IActionResult CadastrarRepositorio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarRepositorio(ViewModelRepo vmRepositorio)
        {

            InsertRepositorio(vmRepositorio);
            return RedirectToAction("Index","Home");
        }

        public void InsertRepositorio(ViewModelRepo vmRepositorio)
        {
            string conexao = "server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true";
            using (SqlConnection connection = new SqlConnection(conexao))
            {
                string insertQuery = String.Format("Exec InsertRepositorio @nomeRepositorio,@dataUltimaAtt,@nomeDonoRepositorio,@nomeLinguagens,@descricao");
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.Add("@nomeRepositorio", SqlDbType.VarChar).Value = vmRepositorio.Repositorio.nomeRepositorio;
                command.Parameters.Add("@dataUltimaAtt", SqlDbType.DateTime).Value = vmRepositorio.Repositorio.dataUltimaAtt;
                command.Parameters.Add("@nomeDonoRepositorio", SqlDbType.VarChar).Value = vmRepositorio.DonoRepositorio.nomeDonoRepositorio;
                command.Parameters.Add("@nomeLinguagens", SqlDbType.VarChar).Value = vmRepositorio.Linguagens.nomeLinguagens;
                command.Parameters.Add("@descricao", SqlDbType.VarChar).Value = vmRepositorio.Repositorio.descricao;


                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

        }


        public IActionResult ExcluirRepositorioPeloID(int id)
        {

            string conexao = "server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true";
            using (SqlConnection connection = new SqlConnection(conexao))
            {
                string deleteQuery = String.Format("delete from tb_Repositorios where id = '{0}'", id);
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

                command.Connection.Close();
                return RedirectToAction("Index");
            }
        }





    }
}
