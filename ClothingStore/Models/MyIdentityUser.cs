using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStore.Models
{
    public class MyIdentityUser:IdentityUser
    {
        public DateTime RegisterDate { get; set; } = DateTime.Now.Date;
        
    }
}
