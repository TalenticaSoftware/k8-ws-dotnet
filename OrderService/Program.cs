using OrderServiceApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register IOrderService for dependency injection
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.WebHost.ConfigureKestrel(options =>
{
    var kestrelConfig = builder.Configuration.GetSection("Kestrel");
    options.Configure(kestrelConfig);
});

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
