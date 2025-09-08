using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPosterController : ControllerBase
    {
        // GET: api/<JobPosterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JobPosterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobPosterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobPosterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobPosterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
