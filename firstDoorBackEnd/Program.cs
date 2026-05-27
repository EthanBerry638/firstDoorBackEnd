using firstDoorBackEnd.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<ICareerJetRepository, CareerJetRepository>(client =>
{
    client.BaseAddress = new Uri("https://placeholder.com");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();