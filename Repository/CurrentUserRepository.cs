using AfroBeachApp.Interfaces;

namespace AfroBeachApp.Repository
{
    public class CurrentUserRepository : ICurrentUserRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        public CurrentUserRepository(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }
        public string GetCurrentUser()
        {
            return contextAccessor.HttpContext.User.Identity.Name;
        }
    }
}
