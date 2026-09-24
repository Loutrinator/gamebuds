using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GamebudsAPI.Models;
using GamebudsAPI.Data;

namespace GamebudsAPI.Controllers
{
    [Route("api/Wordle/Words")]
    [ApiController]
    public class WordleWordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public WordleWordsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        #region API Endpoints

        //GET: api/Wordle/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordleWord>>> GetWords()
        {
            return await _context.WordleWords.ToListAsync();
        }

        //GET: api/Wordle/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WordleWord>> GetWord(int id)
        {
            var word = await _context.WordleWords.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        //PUT: api/Wordle/Words/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, WordleWord word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        //POST: api/Wordle/Words
        [HttpPost]
        public async Task<ActionResult<WordleWord>> PostWord(WordleWord word)
        {
            _context.WordleWords.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        //DELETE: api/Wordle/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var word = await _context.WordleWords.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.WordleWords.Remove(word);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private Methods

        private bool WordExists(int id)
        {
            return _context.WordleWords.Any(e => e.Id == id);
        }

        #endregion
    }
}