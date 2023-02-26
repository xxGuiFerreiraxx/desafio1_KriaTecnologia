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
    /*public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Repositorio> tb_Repositorios { get; set; }
        public DbSet<DonoRepositorio> tb_DonoRepositorio { get; set; }
        public DbSet<Linguagens> tb_linguagens { get; set; }
    }*/

    public class ApplicationDbContext : IDisposable
    {
        public SqlConnection connection;

        public ApplicationDbContext()
        {
            /*connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);*/
            connection = new SqlConnection("server=DESKTOP-86L3AUD; DataBase=db_MeusRepositoriosKria; trusted_connection=true");
            connection.Open();
        }

        public SqlConnection conectarDb()
        {
            connection.Open();
            return connection;
        }

        public SqlConnection desconectarDb()
        {
            connection.Close();
            return connection;
        }

        public void CommandExecuter(string queryString)
        {
            var command = new SqlCommand
            {
                CommandText = queryString,
                CommandType = CommandType.Text,
                Connection = connection
            };
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader CommandRetuner(string queryString)
        {
            var command = new SqlCommand(queryString, connection);
            try
            {
                return command.ExecuteReader();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

       public void Dispose()
       {
            if (connection.State == ConnectionState.Open)
                connection.Close();
       }
    }
}
 

