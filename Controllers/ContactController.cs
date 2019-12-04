using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErikVanDelft.Models;

namespace ErikVanDelft.Controllers
{
    public class ContactController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;
        public ContactController(EmailAddress _fromAddress, 
            IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {

                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Bericht afkomstig vanuit Erikvandelft.nl: " + 
                    $"Naam: {model.Name}," +
                    $"E-mail adres: {model.Email}" +
                    $"Bericht: {model.Message}",
                    Subject = "Ingevuld contactformulier via: www.ErikvanDelft.nl"
                };
                
                EmailService.Send(msgToSend);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return Index();
            }
        }





    }
}
