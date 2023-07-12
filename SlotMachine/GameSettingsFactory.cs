using Microsoft.Extensions.Configuration;

namespace SlotMachine;

public sealed class GameSettingsFactory
{
    private readonly IConfiguration _configuration;

    public GameSettingsFactory(IConfiguration configuration) => _configuration = configuration;

    public GameSettings Create() => _configuration.GetSection(nameof(GameSettings)).Get<GameSettings>() ?? new GameSettings();
}