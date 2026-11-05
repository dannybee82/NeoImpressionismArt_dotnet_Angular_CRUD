using Application.Services;
using Application.Settings;
using Domain.Interfaces;
using FileSignatures;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//For PostgreSQL Databases and DateTime.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Check — null connection strings produce cryptic format errors  
if (string.IsNullOrWhiteSpace(dbConnectionString))
    throw new InvalidOperationException(
        "ConnectionStrings:DefaultConnection is not set. " +
        "Check your appsettings.LocalDocker.json or environment variables.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS - Cross Origin Resource Sharing
// Note: "http://localhost" = for Docker Desktop.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

// Set allowed File Types. See: FileSignatures.Formats for available formats.
//Also see: https://github.com/neilharvey/FileSignatures/
var allowedFileList = new AllowedFileFormatList()
{
    AllowedFileList = new List<AllowedFileFormat>()
    {
        new AllowedFileFormat()
        {
            Extension = "jpg",
            FileFormat = FileFormatLocator.GetFormats().OfType<FileSignatures.Formats.Jpeg>()
        },
        new AllowedFileFormat()
        {
            Extension = "jpeg",
            FileFormat = FileFormatLocator.GetFormats().OfType<FileSignatures.Formats.Jpeg>()
        },
        new AllowedFileFormat()
        {
            Extension = "png",
            FileFormat = FileFormatLocator.GetFormats().OfType<FileSignatures.Formats.Png>()
        },
        new AllowedFileFormat()
        {
            Extension = "gif",
            FileFormat = FileFormatLocator.GetFormats().OfType<FileSignatures.Formats.Gif>()
        }
    }
};

// Repositories
builder.Services.AddScoped<IArtworkRepository, ArtworkRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtImageRepository, ArtImageRepository>();

// Services
builder.Services.AddScoped<IArtworkService, ArtworkService>();
builder.Services.AddScoped<IArtistService, ArtistService>();

// Allowed files.
builder.Services.AddSingleton<IAllowedFileFormatList, AllowedFileFormatList>((IServiceProvider sp) => allowedFileList);
builder.Services.AddSingleton<IFileFormatInspector>(new FileFormatInspector());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
