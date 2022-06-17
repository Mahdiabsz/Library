using Library.DomainClasses.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainClasses.Classes
{
    public class Borrow : Base
    {
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public MyUser User { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Required]
        public DateTime DateOfBorrow { get; set; }
        [Required]
        public DateTime DateOfDeliver { get; set; }
        public bool IsDeivered { get; set; }
    }
}
