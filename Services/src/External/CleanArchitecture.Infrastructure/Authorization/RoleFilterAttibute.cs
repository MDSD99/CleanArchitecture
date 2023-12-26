using Microsoft.AspNetCore.Mvc;
namespace CleanArchitecture.Infrastructure.Authorization
{
    public sealed class RoleFilterAttibute : TypeFilterAttribute
    {
        public  RoleFilterAttibute(string role) : base(typeof(RoleAttibute))
        {
            Arguments = new object[] { role};
        }
    }
}
