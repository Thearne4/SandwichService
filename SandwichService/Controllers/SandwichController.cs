using System.Collections.Generic;
using System.Web.Http;
using TheArne4.SandwichService.Models;

namespace TheArne4.SandwichService.Controllers
{
    public class SandwichController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Sandwich> Get()
        {
            return SandwichProvider.GetSandwiches();
        }

        // GET api/<controller>/5
        public Sandwich Get(int id)
        {
            return SandwichProvider.GetSandwich(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Sandwich value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Sandwich value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}