using bookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository
{
    public class AddData
    {
        public AddData()
        {
            Data();
        }

        private void Data()
        {
           
        }

        private void AddAuthors()
        {
            Author author1= new Author("Sarah J. Maas");
            Author author2 = new Author("Stephanie Garber");
            Author author3 = new Author("Susan Ee");
            Author author4 = new Author("Andrzej Sapkowski");
            Author author5 = new Author("John Bellairs");
            Author author6 = new Author("Soman Chainani");
            Author author7 = new Author("Richelle Mead");
            Author author8 = new Author("Marissa Meyer");
            Author author9 = new Author("Kerri Maniskalko");
            Author author10 = new Author("Jennifer L. Armentrout");
        }

        private void AddGenres()
        {
            Genre genre1 = new Genre("Horror");
            Genre genre2 = new Genre("Romance");
            Genre genre3 = new Genre("Fantasy");
            Genre genre4 = new Genre("Drama");
            Genre genre5 = new Genre("Science Fiction");
            Genre genre6 = new Genre("Comedy");
            Genre genre7 = new Genre("Biography");
            Genre genre8 = new Genre("Comics");
            Genre genre9 = new Genre("Thriller");
            Genre genre10 = new Genre("Mystery");
            Genre genre11 = new Genre("Antiutopia");
        }
    }
}
