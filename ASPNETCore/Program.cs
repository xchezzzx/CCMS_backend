using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using ASPNETCore.BuisnessLogic.Managers.ExercisesManager;
using ASPNETCore.BuisnessLogic.Managers.TeamsManager;
using ASPNETCore.BuisnessLogic.Providers.CompetitionsToAdministratorsProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityToCompetitionProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using ASPNETCore.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SharedLib.Services.ExceptionBuilderService;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
	{
		c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
		c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
		{
			ValidAudience = builder.Configuration["Auth0:Audience"],
			ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}"
		};
	});

builder.Services.AddControllers();
builder.Services.AddSignalR();

string DB_CONNECTION_STRING =
    "Server=tcp:ccmsdbserver.database.windows.net,1433;Initial Catalog=ccms;Persist Security Info=False;User ID=ccmsadmin;Password=Q!w2e3r4t5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<CCMSContext>(options => options.UseSqlServer(DB_CONNECTION_STRING));

builder.Services.AddCors(c => c.AddPolicy("policy", a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddTransient<IEntityRepository<Competition>, EntityRepository<Competition>>();
builder.Services.AddTransient<IEntityRepository<Exercise>, EntityRepository<Exercise>>();
builder.Services.AddTransient<IEntityRepository<ExerciseCategory>, EntityRepository<ExerciseCategory>>();
builder.Services.AddTransient<IEntityRepository<ExerciseLang>, EntityRepository<ExerciseLang>>();
builder.Services.AddTransient<IEntityRepository<ExercisePlatform>, EntityRepository<ExercisePlatform>>();
builder.Services.AddTransient<IEntityRepository<ExercisesToCompetition>, EntityRepository<ExercisesToCompetition>>();
builder.Services.AddTransient<IEntityRepository<ExercisesToTeamToCompetition>, EntityRepository<ExercisesToTeamToCompetition>>();
//builder.Services.AddTransient<IEntityRepository<ExercisesToUser>, EntityRepository<ExercisesToUser>>();
builder.Services.AddTransient<IEntityRepository<Team>, EntityRepository<Team>>();
builder.Services.AddTransient<IEntityRepository<TeamsToCompetition>, EntityRepository<TeamsToCompetition>>();
builder.Services.AddTransient<IEntityRepository<User>, EntityRepository<User>>();
builder.Services.AddTransient<IEntityRepository<OperatorsToCompetition>, EntityRepository<OperatorsToCompetition>>();
builder.Services.AddTransient<IEntityRepository<UsersToTeam>, EntityRepository<UsersToTeam>>();


builder.Services.AddTransient<IEntityToCompetitionProvider, EntityToCompetitionProvider>();
builder.Services.AddTransient<IEntityProvider<Competition>, EntityProvider<Competition>>();
builder.Services.AddTransient<IEntityProvider<Exercise>, EntityProvider<Exercise>>();
builder.Services.AddTransient<IEntityProvider<ExerciseCategory>, EntityProvider<ExerciseCategory>>();
builder.Services.AddTransient<IEntityProvider<ExerciseLang>, EntityProvider<ExerciseLang>>();
builder.Services.AddTransient<IEntityProvider<ExercisePlatform>, EntityProvider<ExercisePlatform>>();
builder.Services.AddTransient<IEntityProvider<ExercisesToTeamToCompetition>, EntityProvider<ExercisesToTeamToCompetition>>();
//builder.Services.AddTransient<IEntityProvider<ExercisesToUser>, EntityProvider<ExercisesToUser>>();
builder.Services.AddTransient<IEntityProvider<Team>, EntityProvider<Team>>();
builder.Services.AddTransient<IEntityProvider<TeamsToCompetition>, EntityProvider<TeamsToCompetition>>();
builder.Services.AddTransient<IEntityProvider<User>, EntityProvider<User>>();
builder.Services.AddTransient<IEntityProvider<OperatorsToCompetition>, EntityProvider<OperatorsToCompetition>>();
builder.Services.AddTransient<IEntityProvider<UsersToTeam>, EntityProvider<UsersToTeam>>();

builder.Services.AddSingleton<IExceptionBuilderService, ExceptionBuilderService>();


builder.Services.AddTransient<ICompetitionManager, CompetitionManager>();
builder.Services.AddTransient<ITeamManager, TeamManager>();
builder.Services.AddTransient<IExercisesManager, ExercisesManager>();


builder.Services.AddTransient<IGenerateUsers, UsersStorage>();

builder.Services.AddTransient<IReadUsers, UsersStorage>();


builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });






var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CCMSContext>();

    //SQLHelper.OpenConnection(context);
}

app.UseCors("policy");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<CompetitionHub>("/competitions");
app.MapHub<ExerciseHub>("/exercises");
app.MapHub<TeamHub>("/teams");


app.Run();
