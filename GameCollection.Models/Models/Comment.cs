using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GameCollection.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Game")]
        public int GameId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Comment Date")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string FeedBack { get; set; }

    }
}
