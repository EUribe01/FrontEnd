using KNG8_FrontEnd.Models;
using System.Web.Mvc;

namespace KNG8_FrontEnd.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioModel usuarioModel = new UsuarioModel();

        [FiltroDatos]
        [HttpGet]
        public ActionResult MostrarUsuarios()
        {
            var resultado = usuarioModel.Consultar_Usuarios();

            if (resultado != null && resultado.Codigo == 1)
            {
                return View(resultado.lista);
            }
            else
            {
                return View("Error");
            }
        }

        [FiltroDatos]
        [HttpGet]
        public ActionResult MostrarRoles()
        {
            var resultado = usuarioModel.Consultar_Roles();

            if (resultado != null && resultado.Codigo == 1)
            {
                return View(resultado.lista);
            }
            else
            {
                return View("Error");
            }
        }

        [FiltroDatos]
        [HttpGet]
        public ActionResult MostrarTiposCitas()
        {
            var resultado = usuarioModel.Consultar_Tipos_Citas();

            if (resultado != null && resultado.Codigo == 1)
            {
                return View(resultado.lista);
            }
            else
            {
                return View("Error");
            }
        }


    }
}