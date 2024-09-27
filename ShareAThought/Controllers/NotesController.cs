using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            var notes = await _context.Notes.ToListAsync();

            if (notes == null) {
                return NotFound();
            }

            return notes;
        }

        // get a note by id
        // GET: api/Notes/5

        // create new note
        // POST: api/Notes

        // delete note
        // DELETE: api/Authors/5

        // update note
        // POST: api/Notes/5
    }
}
