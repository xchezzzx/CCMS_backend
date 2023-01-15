using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using ASPNETCore.BuisnessLogic.Managers.ExercisesManager;
using ASPNETCore.BuisnessLogic.Managers.TeamsManager;
using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using ASPNETCore.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<Competition>, EntityRepository<Competition>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<Exercise>, EntityRepository<Exercise>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<ExerciseCategory>, EntityRepository<ExerciseCategory>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<ExerciseLang>, EntityRepository<ExerciseLang>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<ExercisePlatform>, EntityRepository<ExercisePlatform>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<ExercisesToTeam>, EntityRepository<ExercisesToTeam>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<ExercisesToUser>, EntityRepository<ExercisesToUser>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<Team>, EntityRepository<Team>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<TeamsToCompetition>, EntityRepository<TeamsToCompetition>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<User>, EntityRepository<User>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<UsersToCompetition>, EntityRepository<UsersToCompetition>>();
builder.Services.AddTransient<ASPNETCore.DataAccess.Repositories.IEntityProvider<UsersToTeam>, EntityRepository<UsersToTeam>>();

builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<Competition>, EntityProvider<Competition>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<Exercise>, EntityProvider<Exercise>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<ExerciseCategory>, EntityProvider<ExerciseCategory>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<ExerciseLang>, EntityProvider<ExerciseLang>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<ExercisePlatform>, EntityProvider<ExercisePlatform>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<ExercisesToTeam>, EntityProvider<ExercisesToTeam>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<ExercisesToUser>, EntityProvider<ExercisesToUser>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<Team>, EntityProvider<Team>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<TeamsToCompetition>, EntityProvider<TeamsToCompetition>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<User>, EntityProvider<User>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<UsersToCompetition>, EntityProvider<UsersToCompetition>>();
builder.Services.AddTransient<ASPNETCore.BuisnessLogic.Providers.EntityProvider.IEntityProvider<UsersToTeam>, EntityProvider<UsersToTeam>>();


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
