using Microsoft.EntityFrameworkCore;
using NotesApi.Context;
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
        #region Fields
        private readonly NotesApiDbContext db;
        #endregion

        #region Constructors
        public NoteRepo(NotesApiDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public IEnumerable<Note> GetAllUserNotes(string userId)
        {
            var data = db.Notes.Where(N => N.UserId == userId);
            return data;
        }

        public Note GetNoteById(Note model)
        {
            var data = db.Notes.Where(N => N.Id == model.Id).FirstOrDefault();
            return data;
        }

        public Note AddNote(Note model)
        {
            db.Notes.Add(model);
            db.SaveChanges();
            return db.Notes.OrderBy(N => N.Id).LastOrDefault();
        }

        public Note UpdateNote(Note model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return db.Notes.Where(E => E.Id == model.Id).FirstOrDefault();
        }

        public void DeleteNote(Note model)
        {
            db.Notes.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Note> SearchByNoteTitle(string title)
        {
            var data = db.Notes.Where(N => N.Title.Contains(title));
            return data;
        }
        #endregion
    }
}
