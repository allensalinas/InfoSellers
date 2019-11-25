using InfoSellers.DTO;
using InfoSellers.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InfoSellers.Controllers
{
    public class SellersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var resultado = new Domain.Seller().ListSellers();
            if (resultado.SuccessResult)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resultado.Result);
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, $"{resultado.ErrorID}: {resultado.ErrorDescription}");
            }
        }
        
        public string Get(int id)
        {
            return "value";
        }
        
        public HttpResponseMessage Post([FromBody]SellerDTO value)
        {
            var resultado = new Domain.Seller().Create(value);
            if (resultado.SuccessResult)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resultado.Result);
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, $"{resultado.ErrorID}: {resultado.ErrorDescription}");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]SellerDTO value)
        {
            var resultado = new Domain.Seller().Update(value);
            if (resultado.SuccessResult)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resultado.Result);
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, $"{resultado.ErrorID}: {resultado.ErrorDescription}");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            var resultado = new Domain.Seller().Delete(id);
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