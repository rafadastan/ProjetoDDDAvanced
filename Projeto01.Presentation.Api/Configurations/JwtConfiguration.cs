using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Projeto01.Presentation.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Presentation.Api.Configurations
{
    public class JwtConfiguration
    {
        public static void AddJwt(IServiceCollection services, IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(settingsSection);

            var appSettings = settingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new JwtToken(appSettings));
        }

        public static void UseJwt(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
