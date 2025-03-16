using BLServiceOrder;
using DLServiceWebApp.DataService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Register the connection string as a singleton
builder.Services.AddSingleton(builder.Configuration.GetConnectionString("DefaultConnection"));


// Register the OrderRepository and inject the connection string
builder.Services.AddScoped<ServiceOrderRepository, ServiceOrderRepository>(provider =>
{
    var connectionString = provider.GetRequiredService<string>();
    return new ServiceOrderRepository(connectionString);
});

// Registering OrderService as a Singleton
builder.Services.AddTransient<BLServiceOrderDetails, BLServiceOrderDetails>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
