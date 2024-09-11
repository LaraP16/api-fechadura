using System;
using System.Collections.Generic;
using System.Linq;
using api_fechadura.Models;
using api_fechadura.Repository;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace api_fechadura.DAO
{
    public class SalasDAO
    {
        private MySqlConnection _connection;

        public SalasDAO()
            {
                _connection = MySqlConnectionFactory.GetConnection();
            }

            public List<Sala> GetAll()
            {
                List<Sala> salas= new List<Sala>();
                string query = "SELECT * FROM sala";


                try
                {
                    _connection.Open();
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Sala sala =new Sala();
                            sala.IdSala = reader.GetInt32("idsala");
                            sala.Nome = reader.GetString("nome");
                            sala.IdUsuario = reader.GetInt32("usuario_idusuario");

                            salas.Add(sala);
                        }
                    }
                }
                catch(MySqlException ex)
                {
                   
                    Console.WriteLine($"Erro do BANCO: {ex.Message}");
                }
                catch(Exception ex)
                {
                   
                    Console.WriteLine($"Erro Desconhecido {ex.Message}");
                }
                finally
                {
                   
                    _connection.Close();
                }

                return salas;
            }

                public Sala GetId(int id)
                {
                    Sala sala = new Sala();
                    string query = $"SELECT * FROM sala WHERE idsala = {id}";
                    try 
                    {
                        _connection.Open();
                        MySqlCommand command = new MySqlCommand(query, _connection);
                        using(MySqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                Sala sala1 =new Sala();
                                sala.IdSala = reader.GetInt32("idlote");
                                sala.Nome = reader.GetString("nome");
                                sala.IdUsuario = reader.GetInt32("usuario_idusuario");
                               
                                
                               
                                
                            }
                        }
                    }
                    catch(MySqlException ex)
                    {
                        Console.WriteLine($"Erro no Banco: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Erro Desconhecido: {ex.Message}");
                    }
                    finally
                    {
                        _connection.Close();
                    }
                    return sala;
                }

                public void CriarSala(Sala sala)
                {
                    string query = "INSERT INTO sala (nome,usuario_idusuario ) VALUES (@Nome,@IdUsuario)";
                    


                    try
                    {
                        _connection.Open();
                        using(var command = new MySqlCommand(query, _connection))
                        {
                            command.Parameters.AddWithValue("@Nome", sala.Nome);
                            command.Parameters.AddWithValue("@IdUsuario", sala.IdUsuario);
                            
                            
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

            public void AtualizarSala(int id, Sala sala)
            {
                string query = "UPDATE sala SET " +
                                " nome=@Nome, " +
                                " usuario_idusuario=@IdUsuario, " +

                                "WHERE idsala=@idsala"
                                 ;
                        

                try
                {
                   
                   _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                        
                    {       command.Parameters.AddWithValue("@idsala", id);
                            command.Parameters.AddWithValue("@Nome", sala.Nome);
                            command.Parameters.AddWithValue("@IdUsuario", sala.IdUsuario);
                           

                            command.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }

            public void DeletarSala (int id)
            {
                string query = "DELETE FROM sala WHERE idsala = @idsala";

                try 
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@idsala", id);
                        command.ExecuteNonQuery();
                    }
                }
                
                catch(MySqlException ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }

    }
}