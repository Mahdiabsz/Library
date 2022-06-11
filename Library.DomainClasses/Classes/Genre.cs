using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DomainClasses.Classes
{
    public class Genre : Base
    {
        [Required]
        public string Name { get; set; }
    }
}
