using Microsoft.AspNetCore.Mvc;

namespace ShareAThought.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DyslexicoContext _context;

        public NotesController(DyslexicoContext context)
        {
            _context = context;
        }

        // get list of notes
        // GET: api/Notes
        

        // get a note by id
        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // create new note
        // POST: api/Notes

        // delete note
        // DELETE: api/Authors/5

        // update note
        // POST: api/Notes/5
    }
}
