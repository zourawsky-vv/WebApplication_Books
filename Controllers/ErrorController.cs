using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Books.Controllers
{
    [Controller]
    public class ErrorController : Controller
    {
        [Route("/Error/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            switch (code)
            {
                default:
                    ViewData["ErrorCode"] = code;
                    ViewData["ErrorMessage"] = "HTTP Error occured ... ";
                    return View("HandleError");
            }
        }
    }
}
