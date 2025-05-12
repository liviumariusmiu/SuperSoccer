using PokeApiNet;
using SharpTrooper.Core;
using System.Threading.RateLimiting;

namespace SuperSoccer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // Set the path to the XML documentation file
                var xmlFile = Path.Combine(AppContext.BaseDirectory, "SuperSoccer.xml");
                c.IncludeXmlComments(xmlFile);
            });
            builder.Services.AddHttpClient();

            //DI
            builder.Services.AddSingleton<PokeApiClient>();
            builder.Services.AddSingleton<SharpTrooperCore>();

            builder.Services.AddScoped<PokemonApiService>();
            builder.Services.AddScoped<StarWarsApiService>();

            builder.Services.AddTransient<Func<UniverseType, IUniverseApiService>>(sp => key =>
            {
                return key switch
                {
                    UniverseType.StarWars => sp.GetRequiredService<StarWarsApiService>(),
                    UniverseType.Pokemon => sp.GetRequiredService<PokemonApiService>(),
                    _ => throw new ArgumentException($"Unsupported key: {key}")
                };
            });

            builder.Services.AddScoped<IUniverseProcessor, UniverseProcessor>();
            builder.Services.AddScoped<ITeamService, TeamService>();

            //Creating rate limiter to prevent abuse from spambots
            builder.Services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 10,
                            Window = TimeSpan.FromMinutes(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 2
                        }));
                options.RejectionStatusCode = 429;
            });

            builder.Services.AddResponseCaching();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRateLimiter();

            app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
