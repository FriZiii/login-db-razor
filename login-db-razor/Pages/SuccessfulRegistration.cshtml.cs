using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace login_db_razor.Pages
{
    public class SuccessfulRegistrationModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string FirstName { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                FirstName = "User";
            }
        }
    }
}
