using System.Net;
using System.Net.Mail;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public class EnvioDeEmail
    {
        private IMailServices CriarMailService()
        {
            MailSettings settings = Configurations.MailSetting;
            SmtpClient smtp = new()
            {
                Host = settings.Servidor,
                Port = settings.Porta,
                Credentials = new NetworkCredential(settings.Usuario, settings.Senha),
                EnableSsl = true,
                UseDefaultCredentials = false
            };
            return new SmtpClientMailServices(smtp);
        }
    }
}