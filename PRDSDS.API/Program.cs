using Amazon;
using Amazon.Runtime;
using PRDSDS.API.Configuration.Sections;
using PRDSDS.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddOptions<UserManagementOptions>().BindConfiguration("UserManagement");

builder.Configuration.AddSecretsManager(new BasicAWSCredentials(), 
    RegionEndpoint.EUWest1, 
    configurator: config =>
        {
            config.PollingInterval = TimeSpan.FromDays(1);
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
