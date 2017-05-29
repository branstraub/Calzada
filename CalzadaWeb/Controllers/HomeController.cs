using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CalzadaWeb.Models;

namespace CalzadaWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Formulario model)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Revise los campos del formulario");
                return View("Index", model);
            }

            var mailMsg = new MailMessage();
            mailMsg.To.Add(new MailAddress("recepcion.admyebra@gmail.com", "ADM Yebra"));
            mailMsg.From = new MailAddress(model.Email, model.Name);
            mailMsg.Subject = "Contacto";
                  
                  

            try
            { 
              
                var html = $"<p>Nombre: {model.Name} </p>" +
                    $"<p>Email: {model.Email} </p>" +
                    $"<p>Telefono: {model.Phone} </p>" +
                    $"<p>Comentarios: {model.Message} </p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                var smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                var credentials = new NetworkCredential("azure_247112f2851e96ce1624b2ebf88501cd@azure.com", "Nbt101296#");
                smtpClient.Credentials = credentials;
                smtpClient.Send(mailMsg);
            }

            catch (Exception ex)
            {
            Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index");
        }

       
    }
}