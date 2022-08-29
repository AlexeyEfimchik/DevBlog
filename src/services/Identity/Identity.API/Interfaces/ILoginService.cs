namespace Identity.API.Interfaces
{
    public interface ILoginService<T>
    {
        public Task<bool> ValidateCredentials(T user, string password);
        public Task<T> FindByUsername(string user);
        public Task SignIn(T user);
        public Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
