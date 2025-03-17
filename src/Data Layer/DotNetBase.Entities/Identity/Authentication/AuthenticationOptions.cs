using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.Identity.Authentication
{
    public record AuthenticationOptions
    {
        public string Secret { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Authority { get; set; } = default!;
        public List<string> Audiences { get; set; } = default!;
        public string DefaultRole { get; set; } = default!;
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }

    }
}
