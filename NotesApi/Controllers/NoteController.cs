using Microsoft.AspNetCore.Mvc;
using NotesApi.Interfaces;
using NotesApi.Models;
using NotesApi.Repositories;
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
        [Route("~/api/Note/GetAllUserNotes")]
        public IEnumerable<Note> GetAllUserNotes(string userId)
        {
            var data = note.GetAllUserNotes(userId);
            return data;
        }

        [HttpPost]
        [Route("~/api/Note/AddNote")]
        public IActionResult AddNote(Note model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = note.AddNote(model);
                    return Ok(new Response()
                    {
                        Code = "200",
                        Status = "Added",
                        Message = "Note Added"
                    });
                }
                else
                {
                    return BadRequest(new Response()
                    {
                        Code = "402",
                        Status = "Bad Request",
                        Message = "No Note Created"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new Response()
                {
                    Code = "402",
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/api/Note/UpdateNote")]
        public IActionResult UpdateNote(Note model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = note.UpdateNote(model);
                    return Ok(new Response()
                    {
                        Code = "200",
                        Status = "Updated",
                        Message = "Note Updated"
                    });
                }
                else
                {
                    return BadRequest(new Response()
                    {
                        Code = "402",
                        Status = "Bad Request",
                        Message = "No Note Updated"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new Response()
                {
                    Code = "402",
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/api/Note/DeleteNote")]
        public IActionResult DeleteNote(Note model)
        {
            try
            {
                note.DeleteNote(model);
                return Ok(new Response()
                {
                    Code = "200",
                    Status = "Deleted",
                    Message = "Note Deleted"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new Response()
                {
                    Code = "402",
                    Status = "Bad Request",
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/api/Note/SearchByNoteTitle")]
        public IEnumerable<Note> SearchByNoteTitle(string title)
        {
            var data = note.SearchByNoteTitle(title);
            return data;
        }
        #endregion
    }
}
