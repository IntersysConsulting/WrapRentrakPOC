using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WrapRentrakWeb1.Controllers
{
    public class ReportAPIController : ApiController
    {
        // GET: api/ReportAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReportAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReportAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReportAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReportAPI/5
        public void Delete(int id)
        {
        }
    }
}
