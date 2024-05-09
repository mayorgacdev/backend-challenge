using Technical.Interview.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddExtensions(builder.Configuration);

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Application = builder.Build();

// Configure the HTTP request pipeline.
if (Application.Environment.IsDevelopment())
{
    Application.UseSwagger();
    Application.UseSwaggerUI();
}

Application.UseHttpsRedirection();

Application.UseAuthorization();

Application.MapControllers();

using var Scope = Application.Services.CreateScope();
var Services = Scope.ServiceProvider;
var InterviewContext = Services.GetRequiredService<InterviewContext>();
var Logger = Services.GetRequiredService<ILogger<Program>>();
try
{
    await InterviewContext.Database.EnsureCreatedAsync();
    await InterviewContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    Logger.LogError(ex, "An error occured during migration");
}

Application.Run();
