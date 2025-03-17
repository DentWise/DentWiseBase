using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Identity.Authentication
{
    public record AuthenticationClientOptions
    {
        public string Secret { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Authority { get; set; } = default!;
        public string Audience { get; set; } = default!;
    }
}
