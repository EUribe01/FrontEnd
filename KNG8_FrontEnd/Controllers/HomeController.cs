using KNG8_FrontEnd.Models;
using System.Web.Mvc;

namespace KNG8_FrontEnd.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class HomeController : Controller
    {
        private UsuarioModel usuarioModel = new UsuarioModel();

        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }

        [FiltroDatos]
        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarAcceso(UsuarioObj usuario)
        {
            var respuesta = usuarioModel.Validar_Usuario(usuario);

            if (respuesta != null && respuesta.Codigo == 1)
            {
                Session["codigoToken"] = respuesta.objeto.Token;
                Session["nombreCompleto"] = respuesta.objeto.NombreCompleto;
                Session["tipoUsuario"] = respuesta.objeto.TipoUsuario;

                return RedirectToAction("Principal", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [FiltroDatos]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SobreNosotros()
        {
            

            return View();
        }

        [HttpGet]
        public ActionResult Contactar()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        public ActionResult passwordEdit()
        { return View(); }

        [HttpGet]
        public ActionResult RecuperarPassword()
        { return RedirectToAction("passwordEdit", "Home"); }

        [HttpGet]
        public ActionResult CrearUsuario()
        {
            return RedirectToAction("Registro", "Home");
        }

        [HttpGet]
        public ActionResult Calendar()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PageNotFound()
        {
            return View();
        }

    }
}