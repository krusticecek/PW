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
    }
}
