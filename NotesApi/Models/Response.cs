using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public class Response
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public Type Data { get; set; }
        public Type Error { get; set; }
    }
}
