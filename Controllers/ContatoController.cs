using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoHemobancoWeb.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Nome, string Email, string Mensagem, string Assunto)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(Email);
            message.To.Add(new MailAddress("seuemail@gmail.com")); //email para o qual deseja enviar
            message.Subject = "Cliente: " + Nome + " - " + "Assunto:" + Assunto;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "Email: " + Email + "\n" + "Mensagem:" + Mensagem;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("seuemail@gmail.com", "suasenha"); //login e senha do seu email para aplicação enviar o email (precisa ser uma conta que permita aplicativos de terceiros usarem e sem autenticação de 2 fatores)
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(message);
                ViewBag.lblMensagem = Nome + "," + '\n' + "mensagem enviada com sucesso!";
            }
            catch
            {
                ViewBag.lblMensagem = Nome + "," + '\n' + "erro ao enviar a mensagem!";
            }
           
            return View();
        }
    }
}
