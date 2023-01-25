using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public User(string userName) : base(userName) { }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [ForeignKey(nameof(MemberName))]
        public int MemberId { get; set; }
        public Membership MemberName { get; set; }
        

    }
}
