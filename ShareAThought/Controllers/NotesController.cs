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

        // get a note by id
        // GET: api/Notes/5

        // create new note
        // POST: api/Notes

        // delete note
        // DELETE: api/Authors/5

        // update note
        // POST: api/Notes/5

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult> EditNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteToUpdate = await _context.Notes.FirstOrDefaultAsync(s => s.NoteId == id);

            // _context.Authors.Add(author);
            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Note>(
                noteToUpdate,
                "",
                s => s.AuthorId, s => s.Title, s => s.Body, s => s.Author))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return Ok(noteToUpdate);
        }

        [HttpPost("create"), ActionName("Create")]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.NoteId }, note);
        }
    }
}
