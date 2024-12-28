
using Microsoft.Extensions.DependencyInjection;

namespace AudioCollectorPOC1
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

            IAudioRepository _audioRepository = new AudioRepository();
            builder.Services.AddSingleton(_audioRepository);
            //builder.Services.AddScoped<IAudioRepository, AudioRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //app.UseAuthorization();

            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.MapControllers();

            app.Run();
        }
    }
}
