using System.Net.Mail;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public class SmtpClientMailServices : IMailServices
    {
        private readonly SmtpClient smtpClient;

        public SmtpClientMailServices(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }

        public Task SendMailAsync(string remetente, string destinatario, string titulo, string corpo)
        {
            MailMessage message = new()
            {
                From = new MailAddress(remetente),
                Subject = titulo,
                Body = corpo
            };

            message.To.Add(new MailAddress(destinatario));
            smtpClient.Send(message);
            return Task.CompletedTask;
        }
    }
}