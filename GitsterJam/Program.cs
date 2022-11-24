using GitsterJam;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Mindster Jam - Git",
        Description = "This API exposes nothing, to support the Mindster Jam presentation"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Exception middleware
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is HttpStatusCodeException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            context.Response.ContentType = ex.ContentType;
            await context.Response.WriteAsync(ex.ToJson());
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("{ \"statusCode\": 500, \"error\": \"An unexpected error occured \"" + exceptionHandlerPathFeature?.Error.Message + "\". Please try again later.\" } ");
        }
    });
});

app.UseAuthorization();

app.MapControllers();

app.Run();
