﻿using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    using static Common.EntityValidations.Writer;
    public class Writer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
           = new HashSet<Song>();
    }
}
