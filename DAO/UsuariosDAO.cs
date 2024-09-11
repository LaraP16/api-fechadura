using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Usuario usuario = new Usuario();
            string query =  $"SELECT * FROM usuario WHERE nif = {nif}";
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
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return usuario;
         }
         public Usuario GetSenha(string senha)
{
            Usuario usuario = null;
            string query = $"SELECT * FROM usuario WHERE senha = '{senha}'";
            try
            {
               _connection.Open();
               MySqlCommand command = new MySqlCommand(query, _connection);
               using (MySqlDataReader reader = command.ExecuteReader())
               {
                     if (reader.Read())
                     {
                        usuario = new Usuario();
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
               Console.WriteLine($"Erro no banco: {ex.Message}");
            }
            catch (Exception ex)
            {
               Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
               _connection.Close();
            }
            return usuario;
         }
        public void CriarUsuario(Usuario usuario)
        {
            string query = "INSERT INTO usuario (nome_completo, nif, senha, status, perfil) VALUES (@NomeCompleto, @Nif, @Senha, @Status, @Perfil)";
         
         try
         {
             _connection.Open();
         using (var command = new MySqlCommand (query, _connection))
         {
            command.Parameters.AddWithValue("@nome", usuario.Nome);
            command.Parameters.AddWithValue("@nif", usuario.Nif);
            command.Parameters.AddWithValue("@senha", usuario.Senha);
            command.Parameters.AddWithValue("@status", usuario.Status);
            command.Parameters.AddWithValue("@perfil", usuario.Perfil);
            command.ExecuteNonQuery();

         }
         }
          catch(MySqlException ex)
            {
            Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
            Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
         
        
        
        }
        public void AtualizarUsuario(int id, Usuario usuario)
        {
            string query = "UPDATE usuario SET" +
                           " nome = @nome, " +
                           " nif = @nif, " +
                           " senha = @senha, " +
                           " status = @status, " +
                           " perfil = @perfil " +
                           "WHERE idusuario = @idUsuario";
        try 
        {
         _connection.Open();
         using (var command = new MySqlCommand (query, _connection))
         {
            command.Parameters.AddWithValue("@nome", usuario.Nome);
            command.Parameters.AddWithValue("@nif", usuario.Nif);
            command.Parameters.AddWithValue("@senha", usuario.Senha);
            command.Parameters.AddWithValue("@status", usuario.Status);
            command.Parameters.AddWithValue("@perfil", usuario.Perfil);
            command.ExecuteNonQuery();

         }
        }
        catch(MySqlException ex)
            {
            Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
            Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }


        internal void DeletarUsuario(int id)
        {
           string query = "DELETE FROM usuario WHERE IdUsuario = @IdUsuario";

           try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);
                    command.ExecuteNonQuery();
                }
            }
             catch(MySqlException ex)
            {
            Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
            Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
    }
