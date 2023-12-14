using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Data;
using OnlineGame.Interfaces;
using OnlineGame.MappingProfiles;
using OnlineGame.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameSessionService, GameSessionService>();
builder.Services.AddScoped<IModeService, ModeService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new GameProfile());
    mc.AddProfile(new GameSessionProfile());
    mc.AddProfile(new ModeProfile());
    mc.AddProfile(new PlayerProfile());
    mc.AddProfile(new AchievementProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("EnableCORS");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
