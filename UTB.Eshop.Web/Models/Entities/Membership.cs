using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Eshop.Web.Models.Entities
{
    [Table(nameof(Membership))]
    public class Membership
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,100)]
        public int Discount { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Must be 0 or 1 only.")]
        public int Status { get; set; }
    }
}
