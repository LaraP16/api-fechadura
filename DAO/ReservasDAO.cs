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
    public class ReservasDAO
    {
        private MySqlConnection _connection;
 
        public ReservasDAO()
            {
                _connection = MySqlConnectionFactory.GetConnection();
            }
 
            public List<Reserva> GetAll()
            {
                List<Reserva> reservas= new List<Reserva>();
                string query = "SELECT * FROM reserva";
 
 
                try
                {
                    _connection.Open();
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Reserva reserva =new Reserva();
                            reserva.IdReserva = reader.GetInt32("idreserva");
                            reserva.IdUsuario = reader.GetInt32("idusuario");
                            reserva.IdSala = reader.GetInt32("idsala");
 
                            reservas.Add(reserva);
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
 
                return reservas;
            }
 
                public Reserva GetId(int id)
                {
                    Reserva reserva = new Reserva();
                    string query = $"SELECT * FROM sala WHERE idreserva = {id}";
                    try
                    {
                        _connection.Open();
                        MySqlCommand command = new MySqlCommand(query, _connection);
                        using(MySqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                Reserva reserva1 =new Reserva();
                                reserva.IdReserva = reader.GetInt32("idreserva");
                                reserva.IdUsuario = reader.GetInt32("idusuario");
                                reserva.IdSala = reader.GetInt32("idsala");
                               
                               
                               
                               
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
                    return reserva;
                }
 
                public void CriarReserva(Reserva reserva)
                {
                    string query = "INSERT INTO reserva (idusuario,idsala  ) VALUES (@IdUsuario,@IdSala)";
                   
 
 
                    try
                    {
                        _connection.Open();
                        using(var command = new MySqlCommand(query, _connection))
                        {
                            command.Parameters.AddWithValue("@IdUsuario", reserva.IdUsuario);
                            command.Parameters.AddWithValue("@IdSala", reserva.IdSala);
                           
                           
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
 
            public void AtualizarReserva(int id, Reserva reserva)
            {
                string query = "UPDATE reserva SET " +
                                " idusuario=@IdUsuario, " +
                                " idsala=@IdSala, " +
 
                                "WHERE idreserva=@idreserva"
                                 ;
                       
 
                try
                {
                   
                   _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                       
                    {       command.Parameters.AddWithValue("@idreserva", id);
                            command.Parameters.AddWithValue("@IdUsuario", reserva.IdUsuario);
                            command.Parameters.AddWithValue("@IdSala", reserva.IdSala);
                           
 
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
 
            public void DeletarReserva (int id)
            {
                string query = "DELETE FROM reserva WHERE idreserva = @idreserva";
 
                try
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@idreserva", id);
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