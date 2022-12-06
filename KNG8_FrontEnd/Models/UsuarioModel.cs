using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace KNG8_FrontEnd.Models
{
    public class UsuarioModel
    {
        /*Llamamos al API por este metodo atraves del Controlador*/

        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Validar_Usuario";

                JsonContent datos = JsonContent.Create(usuario);

                HttpResponseMessage respuestahttp = client.PostAsync(rutaApi, datos).Result;

                if (respuestahttp.IsSuccessStatusCode)
                {
                    return respuestahttp.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuarioObj Consultar_Usuarios()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Consultar_Usuarios";

                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuestahttp = client.GetAsync(rutaApi).Result;

                if (respuestahttp.IsSuccessStatusCode)
                {
                    return respuestahttp.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }

        }

        public RespuestaroleObj Consultar_Roles()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Consultar_Roles";

                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuestahttp = client.GetAsync(rutaApi).Result;

                if (respuestahttp.IsSuccessStatusCode)
                {
                    return respuestahttp.Content.ReadAsAsync<RespuestaroleObj>().Result;
                }
                return null;
            }

        }

        public RespuestatiposCitasObj Consultar_Tipos_Citas()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Consultar_Tipos_Citas";

                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuestahttp = client.GetAsync(rutaApi).Result;

                if (respuestahttp.IsSuccessStatusCode)
                {
                    return respuestahttp.Content.ReadAsAsync<RespuestatiposCitasObj>().Result;
                }
                return null;
            }

        }

    }
}