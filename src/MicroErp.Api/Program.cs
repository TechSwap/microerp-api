using MicroErp.Api.Filters;
using MicroErp.Infra.Bootstrap.AutoMapper;
using MicroErp.Infra.Bootstrap.Configuration;
using MicroErp.Infra.Bootstrap.Database;
using MicroErp.Infra.Bootstrap.Hangfire;
using MicroErp.Infra.Bootstrap.MediatR;
using MicroErp.Infra.Bootstrap.Service;
using MicroErp.Infra.Bootstrap.Swagger;
using MicroErp.Infra.Bootstrap.Validation;
using MicroErp.Infra.Bootstrap.Version;

var applicationName = "MicroErp";
var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddCustomAutoMapper()
    .AddCustomMediatR()
    .AddServices()
    .AddRepositories(builder.Configuration)
    .AddHangfire(builder.Configuration)
    .AddVersion()
    .AddValidation()
    .AddSwaggerApi<RemoveQueryApiVersionParamOperationFilter, RemoveDefaultApiVersionRouteDocumentFilter>(applicationName)
    .AddCustomConfiguration(typeof(ValidatorFilter))        
    .AddCors(options =>
     {
         options.AddPolicy(name: "CorsPolicy",
            policy =>
            {
                policy.WithOrigins("*")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
     });

var app = builder.Build();
app.UseCors("CorsPolicy");
app.UseDefaultConfigure(app.Environment, applicationName);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();