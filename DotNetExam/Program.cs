using BusinessLogicDataBase.BattleLogic;
using BusinessLogicDataBase.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MonstersDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Monsters")));

builder.Services.AddTransient<IBattle, Battle>();
builder.Services.AddTransient<IMonsterService, MonsterService>();

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
