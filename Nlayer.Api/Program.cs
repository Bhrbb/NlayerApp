using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nlayer.Api.Filters;
using Nlayer.Api.Middlewares;
using Nlayer.Api.Modules;
using Nlayer.Core.IUnitOfWork;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Repository;
using Nlayer.Repository.Repositories;
using Nlayer.Repository.UnýtOfWork;
using Nlayer.Service.Mapping;
using Nlayer.Service.Services;
using Nlayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=> options.Filters.Add(new ValidateFilterAtribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidater>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;//Validationun modelini baskýla beným verdiðimi dön 

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddMemoryCache();
//MemoryCache i bildirdik



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
//Modules klasörü 



 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();


app.UseAuthorization();

app.MapControllers();

app.Run();
