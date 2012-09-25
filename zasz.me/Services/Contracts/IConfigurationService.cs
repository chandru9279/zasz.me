using zasz.me.Services.Concrete.Config;

namespace zasz.me.Services.Contracts
{
    public interface IConfigurationService
    {
        BlogConfig Blog { get; }

        SettingsConfig Settings { get; }
    }
}