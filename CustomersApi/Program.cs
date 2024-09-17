using CustomersApi.Interface;
using CustomersApi.Repositories;
using CustomersApi.Services;
using Microsoft.EntityFrameworkCore;

   var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

            builder.Services.AddDbContext<CustomerDatabaseContext>(mySqlBuilder => 
            
            {
                mySqlBuilder.UseMySQL(builder.Configuration.GetConnectionString("Connection1")); 
                
            }) ;


builder.Services.AddScoped<IUpdateCustomer, UpdateCustomer>();
builder.Services.AddScoped<IAddCustomer, AddCustomer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } 

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
