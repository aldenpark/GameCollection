using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GameCollection.Models
{
    public class ReviewerGameScore
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
        [Display(Name = "Score Date")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Range(0, 10)]
        [Display(Name = "Score")]
        public int Score { get; set; }
    }
}
