using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GameCollection.Models
{
    public class PurchaseHistory
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
        [Display(Name = "Purchase Date")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Range(0.0, 1000)]
        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }
    }
}
