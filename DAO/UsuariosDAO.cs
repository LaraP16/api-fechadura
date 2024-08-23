using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_fechadura.Models;
using api_fechadura.Repository;
using MySql.Data.MySqlClient;

namespace api_fechadura.DAO
{
    public class UsuariosDAO
    {
         private MySqlConnection _connection;

         public UsuariosDAO()
         {
            _connection = MySqlConnectionFactory.GetConnection();
         }

         public List<Usuario> GetAll()
         {
             List<Usuario> usuarios = new List<Usuario>();
             string query = "SELECT * FROM usuario";

             try
             {
               _connection.Open();
               MySqlCommand command = new MySqlCommand(query, _connection);
               using(MySqlDataReader reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     Usuario usuario = new Usuario();
                     usuario.IdUsuario = reader.GetInt32("idusuario");
                     usuario.Nome = reader.GetString("nome");

                  }
               }
             }
         }
    }
}