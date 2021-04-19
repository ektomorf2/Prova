using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("/moeda")]
    public class MoedaController : ControllerBase
    {
        static List<Moeda> listaMoeda = new List<Moeda>();
        
        [HttpGet]
        [Route("additemfila/{json}")]
        public HttpResponseMessage AddItemFila(string json = null)
        {
            try
            {
                List<Moeda> lista = new List<Moeda>();
                if (!json.StartsWith("[") && !json.EndsWith("]")) lista.Add(JsonConvert.DeserializeObject<Moeda>(json));
                else lista = JsonConvert.DeserializeObject<List<Moeda>>(json);
                foreach (Moeda m in lista)
                {
                    listaMoeda.Add(m);
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception) 
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("getitemfila")]
        public string GetItemFila()
        {
            try
            {
                Moeda m = new Moeda();
                if(listaMoeda.Count > 0)
                {
                    m = listaMoeda.LastOrDefault();
                    listaMoeda.Remove(m);
                }
                return JsonConvert.SerializeObject(m);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
