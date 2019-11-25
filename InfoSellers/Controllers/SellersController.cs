using InfoSellers.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace InfoSellers.Controllers
{
    public class SellersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<SellerModel> Get()
        {
            return new List<SellerModel>()
            {
                new SellerModel(){ NIT = "9087123", FullName="ALLEN", Address = "ASDF"},
                new SellerModel(){ NIT = "1234567", FullName="ALLEN SALINAS", Address = "A DD SDF"},
            };
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