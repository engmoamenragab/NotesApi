using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required]
        [Range(16, 80)]
        public int Age { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
