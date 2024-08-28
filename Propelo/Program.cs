
using Microsoft.EntityFrameworkCore;
using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Repository;

namespace Propelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IApartmentDocumentRepository,ApartmentDocumentRepository>();
            builder.Services.AddScoped<IApartmentPictureRepository,ApartmentPictureRepository>();
            builder.Services.AddScoped<IApartmentRepository,ApartmentRepository>();
            builder.Services.AddScoped<IPromoterRepository,PromoterRepository>();
            builder.Services.AddScoped<IPropertyPictureRepository,PropertyPictureRepository>();
            builder.Services.AddScoped<IPropertyRepository,PropertyRepository>();
            builder.Services.AddScoped<IAreaRepository,AreaRepository>();
            builder.Services.AddScoped<IOrderRepository,OrderRepository>();
            builder.Services.AddScoped<ISettingRepository,SettingRepository>();
            


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
