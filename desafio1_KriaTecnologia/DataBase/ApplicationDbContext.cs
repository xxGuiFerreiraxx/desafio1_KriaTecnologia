using desafio1_KriaTecnologia.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace desafio1_KriaTecnologia.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Repositorio> tb_Repositorios { get; set; }
        public DbSet<DonoRepositorio> tb_DonoRepositorio { get; set; }
        public DbSet<Linguagens> tb_linguagens { get; set; }
    }
}

