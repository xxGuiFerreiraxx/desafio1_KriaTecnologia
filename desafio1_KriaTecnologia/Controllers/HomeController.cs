using desafio1_KriaTecnologia.DataBase;
using desafio1_KriaTecnologia.Models;
using desafio1_KriaTecnologia.Models.DAO;
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

        public IActionResult Index(string queryString)
        {
            RepositorioDAO dao = new RepositorioDAO();
            var listRepositorios = new List<ViewModelRepo>();
            TempData["NullMessage"] = null;

            if (String.IsNullOrEmpty(queryString))
            {

                listRepositorios = dao.SelectTodosRepositorios();
                if (listRepositorios.Count == 0)              
                    TempData["NullMessage"] = "Nenhum resultado encontrado :( Cadastre um novo repositório!";
                
            }
            else
            {
                listRepositorios = dao.SelectPesquisaRepositorios(queryString);

                if(listRepositorios.Count == 0)
                    TempData["NullMessage"] = "Nenhum resultado encontrado :(";
               
            }
            return View(listRepositorios);
        }

        public IActionResult detalhes(int Id)
        {
            RepositorioDAO dao = new RepositorioDAO();
            var repositorioSelecionado = dao.SelectRepositorioPorId(Id);
            return View(repositorioSelecionado);

        }

        public IActionResult CadastrarRepositorio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarRepositorio(ViewModelRepo vmRepositorio)
        {
            RepositorioDAO dao = new RepositorioDAO();
            dao.InsertRepositorio(vmRepositorio);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExcluirTodosRepositorios()
        {
            RepositorioDAO dao = new RepositorioDAO();
            dao.DeleteTodosRepositorios();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExcluirRepositorioPeloID(int id)
        {
            RepositorioDAO dao = new RepositorioDAO();
            dao.DeleteRepositorio(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Favoritos()
        {
            RepositorioDAO dao = new RepositorioDAO();
            var listRepositoriosFavoritados = dao.SelectTodosRepositoriosFavoritados();

            if (listRepositoriosFavoritados.Count == 0)
                TempData["NullMessage"] = "Nenhum resultado encontrado :(";

            return View(listRepositoriosFavoritados);
        }

        public IActionResult FavoritarRepositorioPeloID(int id)
        {
            RepositorioDAO dao = new RepositorioDAO();
            dao.FavoritarRepositorio(id);
            return RedirectToAction("Favoritos", "Home");
        }

        //Favoritos
    }
}
