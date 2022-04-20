using OnlineChat;


CreateHostBuilder(args).UseDefaultServiceProvider(options =>
options.ValidateScopes = false).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });