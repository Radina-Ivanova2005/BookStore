﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookRepository.Models
{
    public class Serie
    {
        public Serie()
        {
            
        }
        public Serie(string title)
        {
            Title = title;          
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public ICollection<Book> Books { get; set;}





    }
}
