using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_fechadura.DAO;
using api_fechadura.Models;
using ZstdSharp.Unsafe;
using System.Xml.Serialization;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuariosDAO _usuariosDAO;

        public UsuarioController()
        {
            _usuariosDAO = new UsuariosDAO();
        }
    
    [HttpGet]

    public IActionResult Get()
    {
        var usuario = _usuariosDAO.GetAll();
        return Ok(usuario);
    }

    [HttpGet("{id}")]

    public IActionResult GetId(int id)
    {
        var usuario = _usuariosDAO.GetId(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPost("login")]
    public IActionResult GetLoginAsync([FromBody] UsuarioCredenciais credenciais)
    {
        var usuario = _usuariosDAO.GetNif(credenciais.nif);

        if (usuario == null)
        {
            return Unauthorized("NIF não Existe");
        }
        else if (usuario.Senha != credenciais.senha)
        {
            return Unauthorized("Senha Incorreta");
        }
        else
        {
            return Ok(usuario);
        }

    }

    

    [HttpPost]

    public IActionResult CriarUsuario(Usuario usuario)
    {
        _usuariosDAO.CriarUsuario(usuario);
        return Ok();
    }

    [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            if (_usuariosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _usuariosDAO.AtualizarUsuario(id, usuario);
            return Ok();
        }

    [HttpDelete]
        public IActionResult DeletarUsuario(int id)
        {
            if (_usuariosDAO.GetId(id) == null)
            {
                return NotFound();
            }
            _usuariosDAO.DeletarUsuario(id);
            return Ok();
        }

    }
}