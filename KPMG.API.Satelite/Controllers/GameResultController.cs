using KPMG.API.Satelite.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.API.Satelite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase
    {
        // GET: api/<GameResult>
        [HttpGet]
        public IEnumerable<KPMG.Domain.Models.GameResultModel> Get()
        {
            Context ct = new Context();

            return ct.get();
        }

        //// GET api/<GameResult>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GameResult>
        [HttpPost]
        public void Post([FromBody] KPMG.Domain.Models.GameResultModel value)
        {
            Context ct = new Context();

            ct.Add(value);
        }

        //// PUT api/<GameResult>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GameResult>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
