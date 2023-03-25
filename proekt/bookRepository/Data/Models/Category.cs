using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookRepository.Data.Models
{
    public class Category
    {
        public Category()
        {

        }
        public Category(string name)
        {
            Name = name;          
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

       
    }
}
