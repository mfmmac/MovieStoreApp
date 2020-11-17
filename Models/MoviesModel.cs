using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApp.Models
{
    public class MoviesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Runtime { get; set; }
        public CheckedOutModel CheckedOutModel { get; set; }
    }
}
