using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InfoSellers.Controllers
{
    public class CommissionTypesController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var resultado = new Domain.Seller().ListCommisionTypes();
            if (resultado.SuccessResult)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resultado.Result);
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, $"{resultado.ErrorID}: {resultado.ErrorDescription}");
            }
        }
    }
}