using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Features;
using ETicaretAPI.Infrastructure.Services.Storage.Local;
using ETicaretAPI.Application;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

//builder.Services.AddStorage(StoregeType.Azure);
builder.Services.AddStorage<LocalStorage>();

//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddCors();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1000000000;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer("Admin",options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateAudience = true, //olusacak tokenin hangi domainlerin kullanaca��n� belirten de�er
                ValidateIssuer = true, //olusacak token de�erini kimin da��taca��n� belirten alan.
                ValidateLifetime = true, //olusacak token de�erinin s�resini kontrol edecek olan do�rulamad�r.
                ValidateIssuerSigningKey = true, //�retilecek token de�erinin uygulamam�za ait bir de�er oldugunu ifade eden security key verisinin do�rulamas�d�r.

                ValidAudience = builder.Configuration["Token:Audience"],
                ValidIssuer = builder.Configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
            };
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
