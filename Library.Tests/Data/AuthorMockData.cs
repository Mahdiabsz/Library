using Library.DomainClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Data
{
    public class AuthorMockData
    {
        public static List<Author> GetAuthors()
        {
            return new List<Author>{
                 new Author{
                     Id = 1,
                     Name = "mahdi",
                     Family = "abbaszadeh"
                 },
                 new Author{
                     Id = 2,
                     Name = "arash",
                     Family = "abbaszadeh"
                 },
                 new Author{
                     Id = 3,
                     Name = "mehran",
                     Family = "jamali"
                 }
            };
        }


        public static List<Author> GetEmptyAuthor()
        {
            return new List<Author>();
        }

        public static Author GetExistingAuthor()
        {
            return new Author() { Id = 1, Name = "mahdi", Family = "abbaszadeh" };
        }

        public static Author GetNotExistingAuthor()
        {
            return null;
        }
    }
}
