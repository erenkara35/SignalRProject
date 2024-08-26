using Microsoft.AspNetCore.Identity;

namespace SignalR.EntityLayer.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}