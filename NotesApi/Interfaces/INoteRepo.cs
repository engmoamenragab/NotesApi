using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Interfaces
{
    public interface INoteRepo
    {
        IEnumerable<Note> GetAllUserNotes(string userId);
        Note GetNoteById(Note model);
        Note AddNote(Note model);
        Note UpdateNote(Note model);
        void DeleteNote(Note model);
        IEnumerable<Note> SearchByNoteTitle(string title);
    }
}
