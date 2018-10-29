using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TwoFactorAuthentification_SMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            var user = Request["username"];
            var pass = Request["password"];

            // mockup username & pw check
            if(user == "user" && pass == "pass")
            {
                var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");
                var secret = "SuPeRdEmOsEcReT";
                var postData = "api_key=dbeb046f ";
                   postData += "&api_secret=7r6bQ1wkBFP6he0k";
                   postData += "&to=41768185145";
                   postData += "&from=\"\"Johnny\"\"";
                   postData += "&text=\"" + secret + "\"";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                ViewBag.Error = responseString;
            }
            else
            {
                ViewBag.Error = "Wrong Username or Password";
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}