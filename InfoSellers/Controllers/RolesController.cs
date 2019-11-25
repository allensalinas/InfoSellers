using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InfoSellers.Controllers
{
    public class RolesController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var resultado = new Domain.Seller().ListRoles();
            if (resultado.SuccessResult)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resultado.Result);
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, $"{resultado.ErrorID}: {resultado.ErrorDescription}");
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}