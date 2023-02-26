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

        public IActionResult Index()
        {
            RepositorioDAO dao = new RepositorioDAO();
            var listRepositorios = dao.SelectTodosRepositorios();
            return View(listRepositorios);
        }

        //[Route("detalhes/{id?}")]
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
