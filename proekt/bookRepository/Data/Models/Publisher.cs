using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Models
{
    public class Publisher
    {
        public Publisher()
        {
            
        }
        public Publisher( string name)
        {
           
            Name = name;
            IsDeleted = false;
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        
    }
}
