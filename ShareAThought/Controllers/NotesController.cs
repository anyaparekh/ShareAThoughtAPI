using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote(Note note) 
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getNote", new {id = note.NoteId}, note);
        }

        // delete note
        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            Note note = new Note() {NoteId = id};
            _context.Remove(note);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        // update note
        // POST: api/Notes/5
    }
}
