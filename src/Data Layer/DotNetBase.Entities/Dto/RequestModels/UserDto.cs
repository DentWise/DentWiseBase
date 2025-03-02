using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Dto.RequestModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public bool IsMailConfirmed { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } // Role adını da DTO'ya ekliyoruz.
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
