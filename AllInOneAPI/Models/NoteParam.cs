using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Models
{
    public class NoteParam
    {
        public string Id { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;
    }
}
