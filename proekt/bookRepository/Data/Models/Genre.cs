using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Models
{
    public class Genre
    {
        public Genre()
        {
            
        }
        public Genre( string name)
        {
           
            Name = name;
            IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } 

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
