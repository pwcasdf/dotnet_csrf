using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace samesitedemo.Pages
{
    public class IndexModel : PageModel
    {
        public string ReturnCookie { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpContext.Response.Cookies.Append(
                                 "cookie_1", "Strict",
                                 new CookieOptions() { SameSite = SameSiteMode.Strict });

            HttpContext.Response.Cookies.Append(
                                 "cookie_2", "Lax",
                                 new CookieOptions() { SameSite = SameSiteMode.Lax });

            HttpContext.Response.Cookies.Append(
                                 "cookie_3", "None",
                                 new CookieOptions() { SameSite = SameSiteMode.None, Secure = true });

            HttpContext.Response.Cookies.Append(
                                 "cookie_4", "None",
                                 new CookieOptions() { SameSite = SameSiteMode.None });
        }

        public void OnPostRequest()
        {
            ReturnCookie = Request.Headers["cookie"];
            ReturnCookie = ReturnCookie.Replace(",", " \n");
        }
    }
}