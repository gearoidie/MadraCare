using System;
using System.ComponentModel.DataAnnotations;

namespace MadraCare.Models
{
    public class Kennel
    {
        [Key]
        public Guid KennelId { get; set; }

        [MaxLength (1000)]
        [Required]
        public String Name { get; set; }
    }
}