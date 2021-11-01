using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPMG.Domain.Models;
using KPMG.Infrastructure.Data;

namespace KPMG.API.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase
    {
        private readonly KPMGAPIContext _context;

        public GameResultController(KPMGAPIContext context)
        {
            _context = context;
        }

        // GET: api/GameResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResultModel>>> GetGameResultModel()
        {
            return await _context.GameResultModel.ToListAsync();
        }

        // GET: api/GameResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameResultModel>> GetGameResultModel(int id)
        {
            var gameResultModel = await _context.GameResultModel.FindAsync(id);

            if (gameResultModel == null)
            {
                return NotFound();
            }

            return gameResultModel;
        }

        // PUT: api/GameResult/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameResultModel(int id, GameResultModel gameResultModel)
        {
            if (id != gameResultModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameResultModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameResultModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameResult
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameResultModel>> PostGameResultModel(GameResultModel gameResultModel)
        {
            _context.GameResultModel.Add(gameResultModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameResultModel", new { id = gameResultModel.Id }, gameResultModel);
        }

        // DELETE: api/GameResult/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameResultModel(int id)
        {
            var gameResultModel = await _context.GameResultModel.FindAsync(id);
            if (gameResultModel == null)
            {
                return NotFound();
            }

            _context.GameResultModel.Remove(gameResultModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameResultModelExists(int id)
        {
            return _context.GameResultModel.Any(e => e.Id == id);
        }
    }
}
