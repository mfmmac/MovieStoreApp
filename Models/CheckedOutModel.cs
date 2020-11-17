using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApp.Models
{
    public class CheckedOutModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public DateTime DueDate { get; set; }
        public List<MoviesModel> Movie { get; set; }
    }
}
