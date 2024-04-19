using TaskList_API;
using TaskList_API.Middleware;
using TaskList_API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuracion ef
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("conectiondb"));

//inyeccion de dependecias
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//middleware para capturar errores
app.UseErrorMiddleware();
//middleware para logging
app.UseLoggingMiddleware();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
