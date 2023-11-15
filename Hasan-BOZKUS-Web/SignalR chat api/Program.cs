using SignalR_chat_api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddCors(optuons => optuons.AddDefaultPolicy(policy =>
                                    policy.AllowAnyMethod()
                                          .AllowAnyHeader()
                                          .AllowCredentials()
                                          .SetIsOriginAllowed(origin => true)
                        ));
builder.Services.AddControllers();
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

app.UseCors();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<AdminandClientsChatHub>("/adminandclientschathub");

app.Run();
