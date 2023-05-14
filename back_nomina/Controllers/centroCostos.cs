using back_nomina.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace back_nomina.Controllers
{
    [ApiController]
    [Route("centroCostos")]
    public class centroCostos : ControllerBase
    {

        [HttpGet]
        [Route("/centroCostosAll")]
        public dynamic getCentroCostos()
        {
            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/CentroCostosSelect";
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {
                List<respCentroCostos> resp = new List<respCentroCostos>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respCentroCostos>>(responseBody);

                return new
                {
                    ok = true,
                    costos = resp
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

            return null;

            //return new
            //{
            //    ok = true,
            //    msg = "Get all centro costos"
            //};

        }

        [HttpGet]
        [Route("/centroCostosInsert")]
        public dynamic insertCentroCostos( int codigo, string descripcion )
        {
            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/CentroCostosInsert?codigocentrocostos=" + codigo + "&descripcioncentrocostos=" + descripcion;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {

                List<respCentroCostos> resp = new List<respCentroCostos>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respCentroCostos>>(responseBody);

                return new
                {
                    ok = true,
                    costosi = resp
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

            return null;

            //return new
            //{
            //    ok = true,
            //    msg = "INSERT centro costos"
            //};

        }

        [HttpGet]
        [Route("/centroCostosUpdate")]
        public dynamic updateCentroCostos( int codigo, string descripcion )
        {

            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/CentroCostosUpdate?codigocentrocostos=" + codigo + "&descripcioncentrocostos=" + descripcion;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {
                List<respCentroCostos> resp = new List<respCentroCostos>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respCentroCostos>>(responseBody);

                return new
                {
                    ok = true,
                    costosi = resp
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

            return null;

            //return new
            //{
            //    ok = true,
            //    msg = "UPDATE centro costos"
            //};

        }

        [HttpGet]
        [Route("/centroCostosDelete")]
        public dynamic deleteCentroCostos( int codigo, string descripcion )
        {

            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/CentroCostosDelete?codigocentrocostos=" + codigo + "&descripcioncentrocostos=" + descripcion;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {
                List<respCentroCostos> resp = new List<respCentroCostos>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respCentroCostos>>(responseBody);

                return new
                {
                    ok = true,
                    costosi = resp
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

            return null;

            //return new
            //{
            //    ok = true,
            //    msg = "DELETE centro costos"
            //};

        }


    }
}
