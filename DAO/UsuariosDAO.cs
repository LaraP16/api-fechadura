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
                     usuario.Nif = reader.GetInt32("nif");
                     usuario.Senha = reader.GetString("senha");
                     usuario.Status = reader.GetString("senha");
                     usuario.Perfil = reader.GetString("perfil");
                     usuarios.Add(usuario);

                  }
               }
             }
             catch (MySqlException ex)
             {
               Console.WriteLine($"Erro do BANCO: {ex.Message}");
             }
             catch(Exception ex)
             {
               Console.WriteLine($"Erro Desconhecido: {ex.Message}");
             }
             finally {
               _connection.Close();
             }

             return usuarios;
         }

         public Usuario GetId(int id)
         {
            Usuario usuario = new Usuario();
            string query = $"SELECT * FROM usuario WHERE idusuario = {id}";
            try
            {
               _connection.Open();
               MySqlCommand command = new MySqlCommand(query, _connection);
               using(MySqlDataReader reader = command.ExecuteReader())
               {
                  if(reader.Read())
                  {
                     usuario.IdUsuario = reader.GetInt32("idusuario");
                     usuario.Nome = reader.GetString("nome");
                     usuario.Nif = reader.GetInt32("nif");
                     usuario.Senha = reader.GetString("senha");
                     usuario.Status = reader.GetString("senha");
                     usuario.Perfil = reader.GetString("perfil");
                  }
               }
            }
            catch (MySqlException ex)
            {
               Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
             catch(Exception ex)
             {
               Console.WriteLine($"Erro Desconhecido: {ex.Message}");
             }
             finally 
             {
               _connection.Close();
             }
             return usuario;
         }

         public Usuario GetNif (int nif)
         {
            
         }
    }
}