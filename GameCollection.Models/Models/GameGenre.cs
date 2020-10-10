using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GameCollection.Models
{
    public class GameGenre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}
