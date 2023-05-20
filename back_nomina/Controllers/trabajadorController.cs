using back_nomina.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace back_nomina.Controllers
{
    public class trabajadorController : ControllerBase
    {
        [HttpGet]
        [Route("/trabajadorAll")]
        public dynamic getTrabajador( int codigo )
        {
            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/TrabajadorSelect?sucursal=" + codigo;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {
                List<respTrabajador> resp = new List<respTrabajador>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respTrabajador>>(responseBody);

                return new
                {
                    ok = true,
                    trabajador = resp
                };

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return new
                {
                    ok = false,
                    msg = "Error ==> " + ex.ToString()
                };
            }


        }

    }
}
