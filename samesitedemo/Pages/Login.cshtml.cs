using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace samesitedemo.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMsg { get; set; }
        string path2 = @"c:\temp\sessionID.txt";

        public void OnGet()
        {
            System.IO.File.Delete(path2);
        }

        public IActionResult OnPost()
        {
            if (Username.Equals("abc") && Password.Equals("123"))
            {
                //HttpContext.Session.SetString("sessionID", Guid.NewGuid().ToString());

                string sessionID = Guid.NewGuid().ToString();

                using (StreamWriter sw = System.IO.File.CreateText(path2))
                {
                    sw.WriteLine(sessionID);
                }

                HttpContext.Response.Cookies.Append(
                                 "sessionID", sessionID,
                                 new CookieOptions() { SameSite = SameSiteMode.None, Secure = true });

                return RedirectToPage("Welcome");
            }
            else
            {
                ErrorMsg = "Invalid";
                return Page();
            }
        }
    }
}
