using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace samesitedemo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeNameController : ControllerBase
    {
        string path = @"c:\temp\username.txt";
        string path2 = @"c:\temp\sessionID.txt";

        public string sessionID { get; set; }
        // GET: api/<ChangeNameController>
        [HttpGet]
        public string Get([FromQuery]string name)
        {
            //sessionID = HttpContext.Session.GetString("sessionID");

            using (StreamReader sr = System.IO.File.OpenText(path2))
            {
                sessionID = sr.ReadLine();
            }

            if (sessionID != null && sessionID == Request.Cookies["sessionID"])
            {
                if (!System.IO.File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = System.IO.File.CreateText(path))
                    {
                        sw.WriteLine(name);
                    }
                }
                else
                {
                    System.IO.File.Delete(path);
                    using (StreamWriter sw = System.IO.File.CreateText(path))
                    {
                        sw.WriteLine(name);
                    }
                }
                return "done";
            }
            else
            {
                return "sessionID_not_matched";
            }
        }

        // POST api/<ChangeNameController>
        [HttpPost]
        public void Post([FromForm] IFormCollection form)
        {
            //sessionID = HttpContext.Session.GetString("sessionID");

            using (StreamReader sr = System.IO.File.OpenText(path2))
            {
                sessionID = sr.ReadLine();
            }

            if (sessionID != null && sessionID == Request.Cookies["sessionID"])
            {
                if (!System.IO.File.Exists(path))
                {
                    using (StreamWriter sw = System.IO.File.CreateText(path))
                    {
                        sw.WriteLine(form["PostAttack"]);
                    }
                }
                else
                {
                    System.IO.File.Delete(path);
                    using (StreamWriter sw = System.IO.File.CreateText(path))
                    {
                        sw.WriteLine(form["PostAttack"]);
                    }
                }
            }
        }
    }
}
