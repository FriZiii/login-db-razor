using login_db_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
namespace login_db_razor.Pages.Forms
{
    public class LoginAndRegisterModel : PageModel
    {
        [BindProperty]
        public UserModel User { get; set; }

        public DataBase dataBase { get; set; } = new DataBase();
        public void OnGet()
        {
        }

        public IActionResult OnPostRegister()
        {
            if (ModelState.IsValid == false)
            {
                Console.WriteLine("Is not valid");
                return Page();
            }
            if (!User.Password2.Equals(User.Password1)) {
                Console.WriteLine("Passwords are not equal");
                return Page();
            }

            dataBase.AddUser(User.FirstName, User.LastName, User.Email, User.Password1);
            dataBase.save();
            Console.WriteLine("Successful Registration");
            return RedirectToPage("/SuccessfulRegistration");
        }

        public IActionResult OnPostLogin()
        {
            Console.WriteLine("Login");

            if(dataBase.login(User.Email, User.Password1))
            {
                return RedirectToPage("/SuccessfulLogin");
            }
            return Page();
        }
    }
}
