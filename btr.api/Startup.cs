using btr.infrastructure.Helpers;
using Microsoft.Extensions.Caching.Memory;
using Nuna.Lib.AutoNumberHelper;

namespace btr.api;

public class Startup
{
    private const string APPLICATION_ASSEMBLY = "btr.application";
    public void ConfigureServices(IServiceCollection services)
    {
        // //  USMAN
        // services.AddScoped<IUsmanUserDal, UsmanUserDal>();
        // services.AddScoped<IUsmanUserRoleDal, UsmanUserRoleDal>();
        // services.AddScoped<IUsmanPegDal, UsmanPegDal>();
        // services.AddScoped<CommandHandler, CommandHandler>();
        
        //  NUNA-LIB
        services.AddScoped<INunaCounterDal, ParamNoDal>();
        services.AddScoped<INunaCounterBL, NunaCounterBL>();
        
        //  SUPPORT
        //services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IMemoryCache, MemoryCache>();
        
    }
}