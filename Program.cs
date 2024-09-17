using DotNetEnv;

Env.Load();

string host = Environment.GetEnvironmentVariable("DB_HOST");
string databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
string port = Environment.GetEnvironmentVariable("DB_PORT");
string username = Environment.GetEnvironmentVariable("DB_USERNAME");
string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"server={host};port={port};database={databaseName};uid={username};password={password};";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
