using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
using ErikVanDelft.Models;

namespace ErikVanDelft.Controllers
{
    public class CvController : Controller
    {

        private readonly InformationDbContext db;

        public CvController(InformationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CvViewModel model = new CvViewModel()
            {
                CvList = db.CvContent.OrderByDescending(x => x.Start).ToList()
            };
            return View(model);
        }
        [HttpGet]
        public JsonResult GetCvContent(int functionId)
        {
            // (factory)
            if (!(functionId > 0))
            {
                return null;
            }
            CvContent model = db.CvContent.Where(e => e.FunctieID == functionId).FirstOrDefault();
            
            string startdate = "Selecteer begindatum";
            if (model.Start != null)
            {
                startdate = model.Start.Value.Date.ToString("dd MMMM yyyy");
            }
            else
            {
                startdate = null;
            }
            string finishdate = "Momenteel werkzaam.";
            if (model.Finish != null)
            {
                finishdate = model.Finish.Value.Date.ToString("dd MMMM yyyy");
            }
            // Controller
            // fill viewmodel after new; from factory.
            return Json(new {
                bedrijf = model.Bedrijf, 
                start = startdate,
                finish = finishdate,
                website = model.Website,
                werkzaamheden = model.Werkzaamheden
            });
        }

        /// <summary>
        /// Updates a <see cref="CvContent"/> record in the database.
        /// </summary>
        /// <param name="model">The new parameters of the <see cref="CvContent"/>.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCvContent(CvContent model, int functieId)
        {
            if (ModelState.IsValid)
            {
                
                db.Add(model);
                await db.SaveChangesAsync();
            }
            return View();
        }


    }
}