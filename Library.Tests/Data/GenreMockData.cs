using Library.DomainClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Data
{
    public class GenreMockData
    {
        public static List<Genre> GetGenres()
        {
            return new List<Genre>{
                 new Genre{
                     Id = 1,
                     Name = "test1"
                 },
                 new Genre{
                     Id = 2,
                     Name = "test2"
                 },
                 new Genre{
                     Id = 3,
                     Name = "test3"
                 }
            };
        }


        public static List<Genre> GetEmptyGenres()
        {
            return new List<Genre>();
        }

        public static Genre GetExistingGenre()
        {
            return new Genre() { Id = 1, Name = "test1"};
        }

        public static Genre GetNotExistingGenre()
        {
            return null;
        }
    }
}
