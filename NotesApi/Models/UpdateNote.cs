using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public class UpdateNote
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Min Length 3 characters")]
        [MaxLength(30, ErrorMessage = "Max Length 30 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MinLength(3, ErrorMessage = "Min Length 3 characters")]
        [MaxLength(100, ErrorMessage = "Max Length 100 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Color is required")]
        [MinLength(6, ErrorMessage = "Length 6 characters only")]
        [MaxLength(6, ErrorMessage = "Length 6 characters only")]
        public string Color { get; set; }
    }
}
