using Blogger.API.Models.DataTransferObjects;
using Blogger.API.Repository;
using Blogger.API.Requests.Commands;
using Blogger.API.Requests.Queries;
using Blogger.API.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

#region MinimalAPIs

app.MapGet("/blogs/{id:guid}", async (IMediator mediator, Guid id) => 
        await mediator.Send(new GetBlogByIdQuery(id)) is var blog 
            ? Results.Ok(blog) 
            : Results.NotFound())
    .WithName("BlogById");

app.MapPost("/blogs", async (IMediator mediator, CreateBlogRequest request) =>
{
    var newBlog = await mediator.Send(new CreateBlogCommand(request));
    return Results.CreatedAtRoute("BlogById", new { id = newBlog.Id }, newBlog);
});

#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.MapControllers();

app.Run();
