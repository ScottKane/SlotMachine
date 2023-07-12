using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SlotMachine;

internal static class Program
{
    private static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        
        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<GameSettingsFactory>();
        services.AddTransient(provider => provider.GetRequiredService<GameSettingsFactory>().Create());
        
        services.AddSingleton<IConsoleReader, ConsoleReader>();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        
        services.AddTransient<ISymbolTranslator, SymbolTranslator>();
        services.AddSingleton<IUserInputValidator, PositiveTwoDecimalPlacesValidator>();
        services.AddSingleton<IUserInputService, UserInputService>();
        
        services.AddSingleton<IBoardGenerator, RandomNumberBoardGenerator>();
        services.AddSingleton<Game>();
        
        var provider =  services.BuildServiceProvider();
        provider.GetRequiredService<Game>().Start();
    }
}