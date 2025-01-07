
using System.Text;

using ConferenceManager.Data;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;

namespace ConferenceManager
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
            builder.Services.AddSwaggerGen();

                //Adding my custom controls
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventModel, EventModel>();

            //Adding authentication
            var key = Encoding.UTF8.GetBytes("Key-must-be-longer-than-32-chars-(256bytes)-else-debug-problems");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "meta",
                    ValidateAudience = true,
                    ValidAudience = "confMang",
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            //JWT token
            // eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgVXNlciIsImlhdCI6MTczNjI0OTkwNSwiZXhwIjoxNzM5ODUwMDcxLCJpc3MiOiJtZXRhIiwiYXVkIjoiQ29uZk1hbmciLCJyb2xlcyI6W119.Hvaw18wetCrflzIbJzFPUJaohInkWmHfsGTztJxNuVI

            var app = builder.Build();

            app.UseAuthentication(); app.UseAuthorization();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
