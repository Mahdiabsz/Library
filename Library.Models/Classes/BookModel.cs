using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Classes
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Stock { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
