using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Api/Materiales")]
    public class MaterialesController : ApiController
    {
        MaterialData materialData = MaterialData.Instance();

        [HttpGet]
        public IHttpActionResult Materiales()
        {
            var lstMateriales = materialData.GetAll();
            return (Json(lstMateriales));
        }

        [HttpGet]
        [Route("ObtenerMaterial/{id}")]
        public IHttpActionResult ObtenerMaterial(int id)
        {
            var lstMateriales = materialData.ObtenerMaterial(id);
            return (Json(lstMateriales));
        }

        [HttpPost]
        [Route("GuardarMaterial")]
        public IHttpActionResult GuardarMaterial(Material material)
        {
            var idMaterial = materialData.Guardar(material);
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(new { Success = true, Message = idMaterial });
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = string.Join("; ", ModelState.Values
                                                                    .SelectMany(x => x.Errors)
                                                                    .Select(x => x.ErrorMessage))
                    });
                }
            }
            catch (Exception exp)
            {
                return (Json(new { Success = false, Message = exp.Message }));
            }
        }

        [HttpDelete]
        [Route("EliminarMaterial/{id}")]
        public IHttpActionResult EliminarMaterial(int id)
        {
            var idMaterial = materialData.Eliminar(id);
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(new { Success = true, Message = idMaterial });
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = string.Join("; ", ModelState.Values
                                                                    .SelectMany(x => x.Errors)
                                                                    .Select(x => x.ErrorMessage))
                    });
                }
            }
            catch (Exception exp)
            {
                return (Json(new { Success = false, Message = exp.Message }));
            }
        }

        [HttpPut]
        [Route("ActualizarMaterial")]
        public IHttpActionResult ActualizarMaterial([FromBody] Material material)
        {
            var idMaterial = materialData.Actualizar(material);
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(new { Success = true, Message = idMaterial });
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = string.Join("; ", ModelState.Values
                                                                    .SelectMany(x => x.Errors)
                                                                    .Select(x => x.ErrorMessage))
                    });
                }
            }
            catch (Exception exp)
            {
                return (Json(new { Success = false, Message = exp.Message }));
            }
        }
    }
}
