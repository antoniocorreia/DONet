using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace D.O.Net.Util
{
    public class SendEmail
    {
        public static void Enviar(string destinatario,string body,string subject)
        {
            MailMessage mail = new MailMessage("diariooficialnet@gmail.com", destinatario);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("diariooficialnet@gmail.com", "tonlipecpr2015");
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api","key-7a968776cb358f9735e24613d976a51d");
            RestRequest request = new RestRequest();
            request.AddParameter("domain","sandbox8625f952bfd94c12a070d9997e816a18.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox8625f952bfd94c12a070d9997e816a18.mailgun.org>");
            request.AddParameter("to", "Antonio <antonio.alves.correia@gmail.com>");
            request.AddParameter("subject", "Hello Antonio");
            request.AddParameter("text", "<h1>teste</h1>");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}