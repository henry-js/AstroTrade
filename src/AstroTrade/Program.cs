#if DEBUG
#else
using AstroTrade;

using Velopack;

VelopackApp.Build().Run();

SetupHelper.EnsureUserConfigFileExists();
SetupHelper.EnsureCurrentApplicationDirectoryIsInPath();
#endif

MyServiceProvider sp = new();

ConsoleApp.ServiceProvider = sp;
var app = ConsoleApp.Create();
app.Add<MyCommands>();

app.UseFilter<ExceptionFilter>();

await app.RunAsync(args);