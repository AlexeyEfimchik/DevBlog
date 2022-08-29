namespace Identity.API.Services
{
    public class EFLoginService : ILoginService<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public EFLoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<ApplicationUser> FindByUsername(string user)
        {
            return await this.userManager.FindByEmailAsync(user);
        }

        public Task SignIn(ApplicationUser user)
        {
            return this.signInManager.SignInAsync(user, true);
        }

        public Task SignInAsync(ApplicationUser user, AuthenticationProperties properties, string authenticationMethod = null)
        {
            return this.signInManager.SignInAsync(user, properties, authenticationMethod);
        }

        public Task<bool> ValidateCredentials(ApplicationUser user, string password)
        {
            return this.userManager.CheckPasswordAsync(user, password);
        }
    }
}
