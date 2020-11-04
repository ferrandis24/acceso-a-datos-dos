using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        [Authorize(Roles ="admin")]
        public IEnumerable<string> Get()
            
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mercado/5
        public MercadoDTO Get(int id)
            
        {
            var repo = new MercadoRepository();
            MercadoDTO m = repo.RetrieveMercado();
            return m;
        }

        // GET: api/Evento/?idEvento=id&tipoMercado=tipo
        public Mercado RetrieveMercado(int idEvento, double tipoMercado)
        {
            var repoMercado = new MercadoRepository();
            Mercado m = repoMercado.RetrieveMercado(idEvento, tipoMercado);
            return m;

        }

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
