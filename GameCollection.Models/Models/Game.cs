using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCollection.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [ForeignKey("GenreId")]
        public virtual GameGenre GameGenre { get; set; }

    }
}
