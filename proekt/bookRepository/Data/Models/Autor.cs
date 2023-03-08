using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookRepository.Models
{
    public class Autor
    {
        public Autor()
        {
            
        }
        public Autor( string name)
        {
          
            Name = name;
            IsDeleted = false;
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } 

        
    }
}
