using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public class Signup
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3, ErrorMessage = "Min Length 3 characters")]
        [MaxLength(10, ErrorMessage = "Max Length 10 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage = "Min Length 3 characters")]
        [MaxLength(10, ErrorMessage = "Max Length 10 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Min Length 6 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(16, 80, ErrorMessage = "Age Range Between 16 and 80")]
        public int Age { get; set; }
    }
}
