using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameCollection.Models
{
    public class CatalogGenre
    {
        [Key]
        public int GameId { get; set; }
        [Key]
        public int GenreId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [ForeignKey("GenreId")]
        public virtual GameGenre Genre { get; set; }
    }
}
