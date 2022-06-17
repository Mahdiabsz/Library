using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Classes
{
    public class BookGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
    }
}
