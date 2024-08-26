using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;
using System.Net.Security;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Tosdoyevski Rezervasyon", "erenkara35@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiveMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body; ;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);


            client.Authenticate("erenkara35@gmail.com", "kwgv lvxv xyvf gmfj");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
            //rezervasyon @erenkara.com.tr TestTest12!!


            //MimeMessage mimeMessage = new MimeMessage();

            //MailboxAddress mailboxAddressFrom = new MailboxAddress("Tosdoyevski Rezervasyon", "rezervasyon@erenkara.com.tr");
            //mimeMessage.From.Add(mailboxAddressFrom);

            //MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiveMail);
            //mimeMessage.To.Add(mailboxAddressTo);

            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.TextBody = createMailDto.Body;
            //mimeMessage.Body = bodyBuilder.ToMessageBody();

            //mimeMessage.Subject = createMailDto.Subject;

            //SmtpClient client = new SmtpClient();
            //client.Connect("mail.erenkara.com.tr", 587);


            //client.Authenticate("rezervasyon@erenkara.com.tr", "TestTest12!!");

            //client.Send(mimeMessage);
            //client.Disconnect(true);

            //return RedirectToAction("Index", "Category");


        }
    }
}