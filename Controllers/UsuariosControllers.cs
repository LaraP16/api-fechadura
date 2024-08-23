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
    public class Usuarios : ControllerBase
    {
        private UsuariosDAO _usuariosDAO;

    }
}