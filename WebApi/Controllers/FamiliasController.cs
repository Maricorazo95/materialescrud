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
    public class FamiliasController : ApiController
    {
        FamiliaData familiaData = FamiliaData.Instance();

        [HttpGet]
        public IHttpActionResult Familias()
        {
            var lstFamilias = familiaData.GetAll();
            return (Json(lstFamilias));
        }
    }
}
