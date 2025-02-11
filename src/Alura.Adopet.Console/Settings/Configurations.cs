using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public class Configurations
{
    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("2bc5258b-580f-499a-9429-2758b5952e82")
            .Build();
    }

    public static AppSettings ApiSetting
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(AppSettings.Section)
                .Get<AppSettings>() ??
                throw new ArgumentException("Seção para configuração da API não encontrada!");
        }
    }

    public static MailSettings MailSetting
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(MailSettings.EmailSection)
                .Get<MailSettings>() ??
                throw new ArgumentException("Seção para configuração do e-mail não encontrada!");
        }
    }
}
