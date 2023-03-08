using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Models
{
    public class BookGenre
    {
        public BookGenre()
        {
            
        }
        public BookGenre(int bookId, int genreId)
        {
            BookId = bookId;
            GenreId = genreId;
        }

        [Key]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        [Key]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Book Book { get; set; }

        
        public virtual Genre Genre { get; set; }    
    }
}
