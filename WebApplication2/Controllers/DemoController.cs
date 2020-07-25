using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    public interface IServico
    {
        Task<int> GetNum(int seconds);
    }

    public class Servico : IServico
    {
        public Servico()
        {

        }
        public async Task<int> GetNum(int seconds)
        {
            if (seconds < 1)
            {
                throw new ArgumentException($"Tempo inválido {seconds}");
            }

            int i = 0;
            do
            {
                await Task.Delay(1000);
                
                System.Diagnostics.Debug.WriteLine($"Aguardando {i}");
            
                i += 1;
            
            } while (i < seconds);

            int n = new Random().Next();

            System.Diagnostics.Debug.WriteLine($"Devolvendo resultado {n}");

            return n;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IServico servico;

        public DemoController(IServico servico)
        {
            this.servico = servico;
        }

        // GET: api/<DemoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DemoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DemoController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] int seconds)
        {
            var result = await servico.GetNum(seconds);

            return Ok(result);
        }

        // PUT api/<DemoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DemoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
