using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace samesitedemo.Pages
{
    public class WelcomeModel : PageModel
    {
        public string sessionID { get; set; }
        public string userName { get; set; }

        string path = @"c:\temp\username.txt";
        string path2 = @"c:\temp\sessionID.txt";

        public void OnGet()
        {
            //sessionID = HttpContext.Session.GetString("sessionID");
            if (System.IO.File.Exists(path2))
            {
                using (StreamReader sr = System.IO.File.OpenText(path2))
                {
                    sessionID = sr.ReadLine();
                }
            }
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            Response.Cookies.Delete("username");

            return RedirectToPage("Index");
        }

        public IActionResult OnGetCheckName()
        {
            //sessionID = HttpContext.Session.GetString("sessionID");
            if (System.IO.File.Exists(path2))
            {
                using (StreamReader sr = System.IO.File.OpenText(path2))
                {
                    sessionID = sr.ReadLine();
                }
            }
            else
            {
                return RedirectToPage("Login");
            }

            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine("wonchul");
                }
            }

            using (StreamReader sr = System.IO.File.OpenText(path))
            {
                userName = sr.ReadLine();
            }
            return Page();
        }

        public IActionResult OnGetRestore()
        {
            //sessionID = HttpContext.Session.GetString("sessionID");
            if (System.IO.File.Exists(path2))
            {
                using (StreamReader sr = System.IO.File.OpenText(path2))
                {
                    sessionID = sr.ReadLine();
                }
            }
            else
            {
                return RedirectToPage("Login");
            }

            System.IO.File.Delete(path);

            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine("wonchul");
            }

            using (StreamReader sr = System.IO.File.OpenText(path))
            {
                userName = sr.ReadLine();
            }
            return Page();
        }
    }
}
