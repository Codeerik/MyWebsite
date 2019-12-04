using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErikVanDelft.Models;

namespace ErikVanDelft.Controllers
{
    public class WieController : Controller
    {

        /// <summary>
        /// Returns the partial view of the "Wie? Wie is Erik?: (initial landing) page
        /// </summary>
        /// <returns>Home/Index</returns>
        public IActionResult Index()
        {
            return View();
        }

    }
}
