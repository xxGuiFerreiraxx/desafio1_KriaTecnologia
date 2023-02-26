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
    public class LinguagensController : Controller
    {

        public IActionResult Linguagem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Linguagem(Linguagens linguagens)
        {
            LinguagensDAO dao = new LinguagensDAO();
            dao.InsertLinguagem(linguagens);
            return RedirectToAction("Index", "Home");
        }

    }
}
