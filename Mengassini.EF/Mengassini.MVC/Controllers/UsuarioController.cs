using Mengassini.EF.Logic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mengassini.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        readonly UsuarioLogic logic = new UsuarioLogic();
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuarios = await logic.GetUsuarios();

            return View(usuarios);
        }
    }
}