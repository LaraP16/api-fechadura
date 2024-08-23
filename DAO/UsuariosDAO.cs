using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_fechadura.Models;
//using api_fechadura.Repository;
//using MySql.Data.MySqlClient;

namespace api_fechadura.DAO
{
    public class UsuariosDAO
    {
         //private MySqlConnection _connection;

         public UsuariosDAO()
         {
            //_connection = MySqlConnectionFactory.GetConnection();
         }

         public<Usuario> usuarios = new List<Usuario>();
         string query = "SELECT * FROM Usuario";

         try
         {
            _connection.Open();
            MySqlCommand command = new MySqlCommand(query, _connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                
            }
         }
         catch (System.Exception)
         {
            
            throw;
         }
    }
}