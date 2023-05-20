using back_nomina.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace back_nomina.Controllers
{
    [ApiController]
    [Route("emisor")]
    public class emisorController : ControllerBase
    {
        [HttpGet]
        [Route("/emisor")]
        public dynamic getEmisor(string codigo)
        {

            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/GetEmisor";
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";


            try
            {
                List<respEmisor> resp = new List<respEmisor>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respEmisor>>(responseBody);

                var emisor = resp;
                var test = resp.Find(x => x.Codigo == codigo);
               

                return new
                {
                    ok = true,
                    msg = "exito emisor",
                    //test,
                    emisor,
                    

                };

            }
            catch (Exception ex)
            {
                return new
                {
                    ok = false,
                    msg = "Error no se pudo traer el emisor"
                };

            }
        }

        [HttpGet]
        [Route("/emisor/all")]
        public dynamic getEmisorAll()
        {
            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/GetEmisor";
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";


            try
            {
                List<respEmisor> resp = new List<respEmisor>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respEmisor>>(responseBody);

                var emisor = resp;
                


                return new
                {
                    ok = true,
                    msg = "exito emisor",
                    //test,
                    emisor,


                };

            }
            catch (Exception ex)
            {
                return new
                {
                    ok = false,
                    msg = "Error no se pudo traer el emisor"
                };

            }


            //return new
            //{
            //    ok = true,
            //    msg = "get all emisor"
            //};
        }




        }
}
