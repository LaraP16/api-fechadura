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
    public class SalasController : ControllerBase
    {
        private SalasDAO _SalasDAO;

        public SalasController()
        {
            _SalasDAO = new SalasDAO();
        }
        
        [HttpGet]
        public IActionResult GetSalas()
        {
            var salas= _SalasDAO.GetAll();
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public IActionResult GetSala(int id)
        {
            var sala = _SalasDAO.GetId(id);

            if (sala == null)
            {
                return NotFound();
            }

            return Ok (sala);
        }

        [HttpPost]
        public IActionResult CriarSala(Sala sala)
        {
            _SalasDAO.CriarSala(sala);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSala(int id, Sala sala)
        {
            if (_SalasDAO.GetId(id) == null)
            {
                return NotFound();
            }

            _SalasDAO.AtualizarSala(id, sala);

            return Ok();

        
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSala(int id)
        {
           
            if (_SalasDAO.GetId(id) == null)
            {
                return NotFound();
            }

           _SalasDAO.DeletarSala(id);
           return Ok();
          
        
        }
    }
}
