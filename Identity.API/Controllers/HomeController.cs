
namespace Identity.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService interaction;
        private readonly IRedirectService redirectSvc;

        public HomeController(IIdentityServerInteractionService interaction, IRedirectService redirectSvc)
        {
            this.interaction = interaction;
            this.redirectSvc = redirectSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReturnToOriginalApplication(string returnUrl)
        {
            if (returnUrl != null)
            {
                return Redirect(this.redirectSvc.ExtractRedirectUriFromReturnUrl(returnUrl));
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await this.interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }
    }
}
