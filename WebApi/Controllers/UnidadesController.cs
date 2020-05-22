using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:50165", headers: "*", methods: "*")]
    [RoutePrefix("Api/Unidades")]
    public class UnidadesController : ApiController
    {

        UnidadData unidadData = UnidadData.Instance();

        [HttpGet]
        public IHttpActionResult Materiales()
        {
            var lstUnidades = unidadData.GetAll();
            return (Json(lstUnidades));
        }
    }
}
