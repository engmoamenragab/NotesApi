using Microsoft.AspNetCore.Mvc;
using NotesApi.Interfaces;
using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        #region Fields
        private readonly INoteRepo note;
        #endregion

        #region Constructors
        public NoteController(INoteRepo note)
        {
            this.note = note;
        }
        #endregion

        #region Actions
        [HttpGet]
        [Route("~/api/Account/GetAllUserNotes")]
        public IActionResult GetAllUserNotes(User user)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/Account/AddNote")]
        public IActionResult AddNote(Note note)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/Account/UpdateNote")]
        public IActionResult UpdateNote(Note note)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/Account/DeleteNote")]
        public IActionResult DeleteNote(Note note)
        {
            return View();
        }

        [HttpPost]
        [Route("~/api/Account/SearchByNoteTitle")]
        public IActionResult SearchByNoteTitle(string title)
        {
            return View();
        }
        #endregion
    }
}
