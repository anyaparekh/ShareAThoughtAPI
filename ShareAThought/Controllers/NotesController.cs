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
        [HttpGet]
        public async Task<ActionResult<List<Note>>> getNotes() {
            var notes = await _context.Notes.ToListAsync();

            return notes;
        }
        // get a note by id
        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> getNote(int id) 
        {
            var note = _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();

            }

            return note;
        }

        // create new note
        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Note>> createNote(Note note) 
        {
            _context.Notes.Add(note);
            await _context.Notes.SaveChangesAsync();

            return CreatedAtAction("getNote", new {id = note.id}, note);
        }

        // delete note
        // DELETE: api/Authors/5

        // update note
        // POST: api/Notes/5
    }
}
