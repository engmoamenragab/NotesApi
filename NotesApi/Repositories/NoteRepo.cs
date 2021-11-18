using NotesApi.Interfaces;
using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Repositories
{
    public class NoteRepo : INoteRepo
    {
        public IEnumerable<Note> GetAllUserNotes()
        {
            throw new NotImplementedException();
        }

        public Note GetNoteById(int Id)
        {
            throw new NotImplementedException();
        }

        public Note AddNote(Note model)
        {
            throw new NotImplementedException();
        }

        public Note UpdateNote(Note model)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(Note model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> SearchByNoteTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
