using back_nomina.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace back_nomina.Controllers
{
    [ApiController]
    [Route("movimientoPlanilla")]
    public class movimientoPlanilla : ControllerBase
    {
        [HttpGet]
        [Route("/movimientoPlanillaAll")]
        public dynamic getmovimientoPlanilla()
        {
            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/MovimientoPlanillaSelect";
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {
                List<respMovimientoPlanilla> resp = new List<respMovimientoPlanilla>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respMovimientoPlanilla>>(responseBody);

                return new
                {
                    ok = true,
                    movp = resp
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write(ex.ToString());
                return new
                {
                    ok = false,
                    msg = "Error ==> " + ex.ToString()
                };
            }


 
        
        }

        [HttpGet]
        [Route("/movimientoPlanillaUpdate")]
        public dynamic updatetmovimientoPlanilla(
            string? codigoConcepto,
            string? concepto,
            string? prioridad,
            string? tipoOperacion,
            string? cuenta1,
            string? cuenta2,
            string? cuenta3,
            string? cuenta4,
            string? movimientoExcepcion1,
            string? movimientoExcepcion2,
            string? movimientoExcepcion3,
            string? aplica_iess,
            string? aplica_imp_renta,
            string? empresa_Afecta_Iess

            )
        {
            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/MovimientoPlanillaUpdate?codigoplanilla="+ codigoConcepto +
                "&conceptos="+ concepto +
                "&prioridad="+ prioridad +
                "&tipooperacion="+ tipoOperacion +
                "&cuenta1="+ cuenta1 +
                "&cuenta2="+ cuenta2 +
                "&cuenta3="+ cuenta3 +
                "&cuenta4="+ cuenta4 +
                "&MovimientoExcepcion1="+ movimientoExcepcion1 +
                "&MovimientoExcepcion2="+ movimientoExcepcion2 +
                "&MovimientoExcepcion3="+ movimientoExcepcion3 +
                "&Traba_Aplica_iess="+ aplica_iess +
                "&Traba_Proyecto_imp_renta="+ aplica_imp_renta +
                "&Aplica_Proy_Renta="+ empresa_Afecta_Iess +
                "&Empresa_Afecta_Iess="+ empresa_Afecta_Iess;

            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";

            try
            {
                List<respMovimientoPlanilla> resp = new List<respMovimientoPlanilla>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respMovimientoPlanilla>>(responseBody);

                return new
                {
                    ok = true,
                    planilla = resp
                };

            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return new
                {
                    ok = false,
                    msg = "Error ==> " + ex.ToString()
                };

            }


 

        }

        [HttpGet]
        [Route("/movimientoPlanillaInsert")]
        public dynamic insertmovimientoPlanilla(
            string? concepto,
            string? prioridad,
            string? tipoOperacion,
            string? cuenta1,
            string? cuenta2,
            string? cuenta3,
            string? cuenta4,
            string? movimientoExcepcion1,
            string? movimientoExcepcion2,
            string? movimientoExcepcion3,
            string? aplica_iess,
            string? aplica_imp_renta,
            string? empresa_Afecta_Iess
            )
        {

            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/MovimientoPlanillaInsert?conceptos=" + concepto +
                "&prioridad=" + prioridad +
                "&tipooperacion=" + tipoOperacion +
                "&cuenta1=" + cuenta1 +
                "&cuenta2=" + cuenta2 +
                "&cuenta3=" + cuenta3 +
                "&cuenta4=" + cuenta4 +
                "&MovimientoExcepcion1=" + movimientoExcepcion1 +
                "&MovimientoExcepcion2=" + movimientoExcepcion2 +
                "&MovimientoExcepcion3=" + movimientoExcepcion3 +
                "&Traba_Aplica_iess=" + aplica_iess +
                "&Traba_Proyecto_imp_renta=" + aplica_imp_renta +
                "&Aplica_Proy_Renta=" + empresa_Afecta_Iess +
                "&Empresa_Afecta_Iess=" + empresa_Afecta_Iess;

            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";


            try
            {
                List<respMovimientoPlanilla> resp = new List<respMovimientoPlanilla>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respMovimientoPlanilla>>(responseBody);

                return new
                {
                    ok = true,
                    planilla = resp
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


        [HttpGet]
        [Route("/movimientoPlanillaDelete")]
        public dynamic deletemovimientoPlanilla(
            string codigomovimiento,
            string descripcionomovimiento
            )
        {

            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/MovimeintoPlanillaDelete?codigomovimiento=" + codigomovimiento +
                "&descripcionomovimiento=" + descripcionomovimiento;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";


            try
            {
                List<respMovimientoPlanilla> resp = new List<respMovimientoPlanilla>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respMovimientoPlanilla>>(responseBody);

                return new
                {
                    ok = true,
                    planilla = resp
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


        [HttpGet]
        [Route("/movimientoPlanillaSearch")]
        public dynamic searchmovimientoPlanilla(
                string word
            )
        {


            var url = "http://apiservicios.ecuasolmovsa.com:3009/api/Varios/MovimientoPlanillaSearch?Concepto=" + word;
            var request = (HttpWebRequest)WebRequest.Create(url);
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            request.Method = "GET";
            request.Accept = "application/text; charset: UTF-8";


            try
            {
                List<respMovimientoPlanilla> resp = new List<respMovimientoPlanilla>();

                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                StreamReader objReader = new StreamReader(strReader);
                string responseBody = objReader.ReadToEnd();

                resp = JsonConvert.DeserializeObject<List<respMovimientoPlanilla>>(responseBody);

                return new
                {
                    ok = true,
                    planilla = resp
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

        // Excepciones


        [HttpGet]
        [Route("/movimientoPlanillaEx12")]
        public dynamic ex12tmovimientoPlanilla()
        {

            return new
            {
                ok = true,
                msg = "movimiento planilla insert"
            };

        }


        [HttpGet]
        [Route("/movimientoPlanillaEx3")]
        public dynamic ex3movimientoPlanilla()
        {

            return new
            {
                ok = true,
                msg = "movimiento planilla insert"
            };

        }

    }
}
