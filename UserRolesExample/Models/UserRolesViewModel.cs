using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRolesExample.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
