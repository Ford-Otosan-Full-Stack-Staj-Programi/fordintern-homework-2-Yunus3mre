using hw2.API.Extensions;
using hw2.Core.Jwt;
using hw2.Core.Repositories;
using hw2.Core.Services;
using hw2.Core.UnitOfWork;
using hw2.Repository;
using hw2.Repository.Repositories;
using hw2.Repository.UnitOfWork;
using hw2.Service.Mapping;
using hw2.Service.Services;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    public static JwtConfig JwtConfig { get; private set; }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        JwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

        builder.Services.AddJwtAuthentication(builder.Configuration);
        builder.Services.AddCutomSwagger();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<DbContext, AppDbContext>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        //builder.Services.AddScoped<IGenericRepository<Product>,GenericRepository<Product>>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //Bu generic ile karþýlaþýrsan git 2. tipinde nesne örneði al.
        builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
        builder.Services.AddScoped<ITokenManagementService, TokenManagementService>();

        builder.Services.AddAutoMapper(typeof(MapProfile));

        var dbConfig = builder.Configuration.GetConnectionString("SqlConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConfig));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}