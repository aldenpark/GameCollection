using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace GameCollection.Models
{
    public class GameHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        [Required]
        public int GameId { get; set; }
        public DateTime DateModified { get; set; }

        //[NotMapped]
        //[ForeignKey("GameId")]
        //public virtual Game Game { get; set; }

        //[NotMapped]
        //[ForeignKey("ApplicationUserId")]
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
