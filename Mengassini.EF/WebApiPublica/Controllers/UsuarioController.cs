using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiPublica.Models;
using Mengassini.EF.Logic;

namespace WebApiPublica.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioLogic logic = new UsuarioLogic();   
        // GET: Usuario
        public ActionResult ListUsuarios()
        {
            var usuarios = logic.GetUsuarios();

            return View(usuarios);
        }
    }
}