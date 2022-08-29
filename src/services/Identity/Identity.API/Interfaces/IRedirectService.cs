namespace Identity.API.Interfaces
{
    public interface IRedirectService
    {
        public string ExtractRedirectUriFromReturnUrl(string url);
    }
}
