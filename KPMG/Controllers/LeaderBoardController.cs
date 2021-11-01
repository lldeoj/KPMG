using KPMG.Domain.Models;
using KPMG.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KPMG.API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly KPMGAPIContext _context;

        public LeaderBoardController(KPMGAPIContext context)
        {
            _context = context;
        }
        // GET: api/<LeaderBoardController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaderBoardModel>>> GetLeaderBoardModel()
        {
            var GameR = _context.GameResultModel.ToList();


            var result = GameR.GroupBy(s => s.PlayerId)
                         .Select(v => new LeaderBoardModel() 
                         { PlayerId = v.First().PlayerId, 
                           Balance = v.Sum(c => c.Win), 
                           LastUpdateDate = v.Max(g => g.Timestamp).ToString() 
                         }).OrderBy(s => s.Balance).Take(100);


            return Ok(result);

         }

        // GET api/<LeaderBoardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LeaderBoardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeaderBoardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeaderBoardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
