using System.Collections.Generic;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;

namespace UTB.Eshop.Web.Models.ViewModels
{
    public class UserViewModel : User
    {
        public IList<Membership> membershipslist { get; set; }
    }
}
