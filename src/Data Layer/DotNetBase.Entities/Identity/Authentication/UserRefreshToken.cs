using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetBase.Entities.Identity.Authentication
{
    public class UserRefreshToken : BaseEntity
    {
        public int UserId { get; set; }
        [Required]
        public string Token { get; set; } = default!;
        public DateTime Expiration { get; set; }
        public bool isUsed { get; set; } = false;
    }
}
