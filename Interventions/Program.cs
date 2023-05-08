using Interventions.DbContexts;
using Interventions.Services;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
});

builder.Services.AddDbContext<InterventionsDbContext>(
    cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("InterventionsConnection"))
    );




builder.Services.AddScoped<ITypesProblemeRepository, TypesProblemeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter(new Microsoft.AspNetCore.RateLimiting.RateLimiterOptions()
{
    RejectionStatusCode = StatusCodes.Status429TooManyRequests
}
.AddConcurrencyLimiter("LimiterConcurrence", options =>
{
    options.PermitLimit = 2;
})
.AddFixedWindowLimiter("LimiterFenetre", options =>
{
    options.Window = TimeSpan.FromSeconds(5);
    options.PermitLimit = 10;
    options.QueueLimit = 5;
    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
}));

app.UseAuthorization();

app.MapControllers();

app.Run();
