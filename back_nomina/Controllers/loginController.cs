using back_nomina.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace back_nomina.Controllers
{
    [ApiController]
    [Route("login")]
    public class loginController : ControllerBase
    {
        [HttpGet]
        [Route("/")]

        public dynamic login(string usuario, string password)
        {

            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Usuarios?usuario=" + usuario + "&password=" + password;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";


            try
            {
                List<respLoginModel> resp = new List<respLoginModel>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respLoginModel>>(responseBody);

                

                //Console.Write(resp[0].CODIGOPERFIL);
                var codEmisor = resp[0].Emisor;
                var obs = resp[0].OBSERVACION;
                //Console.Write(codEmisor);
                //return new
                //{
                //    resp
                //};

                if ( obs == "INGRESO EXITOSO" )
                {
                    Console.Write("INGRESO EXITOSO");

                    emisorController emisor = new emisorController();
                    var listarEmisor = emisor.getEmisor(codEmisor.ToString());
                    //var prueba = listarEmisor.Find();

                    return new
                    {
                        ok = true,
                        codEmisor,
                        listarEmisor,
                        
                    };
                }
                else
                {
                    return new
                    {
                        Ok = false,
                        msg = "CREDENCIALES INVÁLIDAS"
                    };
                }


                //    if (listarEmisor != codEmisor)
                //    {
                //        return new
                //        {
                //            ok = true,
                //            msg = "INGRESO EXITOSO",
                //            codEmisor,
                //            listarEmisor
                //        };

                //    }

                //}
                //else
                //{
                //    Console.Write("CONTRASEÑA INVALIDA");
                //}


                //return new
                //{
                //    ok = true,
                //    msg = "exito login",
                //    codEmisor,
                //    obs
                //};

            }
            catch (Exception ex)
            {
                return new { 
                    ok = false,
                    msg = "error no se pudo traer el usuario",
                    //err = ex
                };
            }
            return null;
        }

    }
}
