using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_fechadura.DAO;
using api_fechadura.Models;
 
 
namespace api_fechadura.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private ReservasDAO _ReservasDAO;
 
        public ReservasController()
        {
            _ReservasDAO = new ReservasDAO();
        }
       
        [HttpGet]
        public IActionResult GetReservas()
        {
            var reservas= _ReservasDAO.GetAll();
            return Ok(reservas);
        }
 
        [HttpGet("{id}")]
        public IActionResult GetReserva(int id)
        {
            var reserva = _ReservasDAO.GetId(id);
 
            if (reserva == null)
            {
                return NotFound();
            }
 
            return Ok (reserva);
        }
 
        [HttpPost]
        public IActionResult CriarReserva(Reserva reserva)
        {
            _ReservasDAO.CriarReserva(reserva);
            return Ok();
 
        }
 
        [HttpPut("{id}")]
        public IActionResult AtualizarReserva(int id, Reserva reserva)
        {
            if (_ReservasDAO.GetId(id) == null)
            {
                return NotFound();
            }
 
            _ReservasDAO.AtualizarReserva(id, reserva);
 
            return Ok();
 
       
        }
 
        [HttpDelete("{id}")]
        public IActionResult DeletarReserva(int id)
        {
           
            if (_ReservasDAO.GetId(id) == null)
            {
                return NotFound();
            }
 
           _ReservasDAO.DeletarReserva(id);
           return Ok();
         
       
        }
    }
}