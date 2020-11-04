using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Evento/5
        public Eventos Get(int id)
        {
            var repo = new EventoRepository();
            Eventos e = repo.Retrieve();
            return e;
        }

        // POST: api/Evento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}
