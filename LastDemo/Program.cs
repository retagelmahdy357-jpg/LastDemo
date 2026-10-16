
using System.Diagnostics;
using System.Text;
using LastDemo.Data;
using LastDemo.Repo;
using LastDemo.Repo.IRepo;
using LastDemo.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LastDemo
{
    public class Program
    {
        public static  void Main(string[] args)
        {
         
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IAuth, AuthRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepo>();
            builder.Services.AddScoped<IProduct, ProductRepo>();
            builder.Services.AddScoped<IOrder, OrderRepo>();

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                Console.WriteLine($"Methoud:{context.Request.Method}");
                await next();
                Console.WriteLine( $"Time:{s.ElapsedMilliseconds}ms");

            });


            app.Use(async (context, next) =>
            {
                Console.WriteLine("Hello First MiddleWare");
                await next();
                Console.WriteLine("GodBye");
            });
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
