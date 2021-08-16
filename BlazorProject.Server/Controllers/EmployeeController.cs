using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    public class EmployeeController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
