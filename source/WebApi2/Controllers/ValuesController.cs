using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Debug.WriteLine(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Debug.WriteLine(id);
        }

        [HttpPost]
        [Route("api/Values/PostCity")]
        public void PostCity(CityModel value)
        {
            Debug.WriteLine(value);
        }

        [HttpPut]
        [Route("api/Values/UpdateWithPut")]
        public void UpdateWithPut(CityModel value)
        {
            Debug.WriteLine(value);
        }
    }

    public class CityModel
    {
        public string IcaoCode { get; set; }
        public string CityShortName { get; set; }
    }
}
