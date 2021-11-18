using Microsoft.AspNetCore.Identity;
using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Interfaces
{
    public interface IUserRepo
    {
        Task<IdentityResult> Signup(Signup model);
        Task<string> Signin(Signin model);
    }
}
