using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using ASPNETCore.BuisnessLogic.Managers.ExercisesManager;
using ASPNETCore.BuisnessLogic.Managers.TeamsManager;
using ASPNETCore.BuisnessLogic.Managers.UserManager;
using ASPNETCore.BuisnessLogic.Providers.CompetitionsToAdministratorsProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityToCompetitionProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityToTeamProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using ASPNETCore.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SharedLib.Services.ExceptionBuilderService;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
	// Identity made Cookie authentication the default.
	// However, we want JWT Bearer Auth to be the default.
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.Authority = "https://code-competition.eu.auth0.com";
	options.Audience = "https://CCMS_Server";
	options.Events = new JwtBearerEvents
	{
		OnMessageReceived = context =>
		{
			var accessToken = context.Request.Query["access_token"];

			// If the request is for our hub...

			var path = context.HttpContext.Request.Path;
			if (!string.IsNullOrEmpty(accessToken))
			{
				context.Token = accessToken;
			}
			return Task.CompletedTask;
		}
	};
});

builder.Services.AddControllers();
builder.Services.AddSignalR();

string DB_CONNECTION_STRING =
    "Server=tcp:ccmsdbserver.database.windows.net,1433;Initial Catalog=ccms;Persist Security Info=False;User ID=ccmsadmin;Password=Q!w2e3r4t5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<CCMSContext>(options => options.UseSqlServer(DB_CONNECTION_STRING));

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyGet",
		builder => builder.AllowAnyOrigin()
			.WithMethods("GET")
			.AllowAnyHeader());
	options.AddPolicy("AllowExampleDomain",
		builder => builder.WithOrigins("https://code-competition.eu.auth0.com")
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials());
});

builder.Services.AddTransient<IEntityRepository<Competition>, EntityRepository<Competition>>();
builder.Services.AddTransient<IEntityRepository<Exercise>, EntityRepository<Exercise>>();
builder.Services.AddTransient<IEntityRepository<ExerciseCategory>, EntityRepository<ExerciseCategory>>();
builder.Services.AddTransient<IEntityRepository<ExerciseLang>, EntityRepository<ExerciseLang>>();
builder.Services.AddTransient<IEntityRepository<ExercisePlatform>, EntityRepository<ExercisePlatform>>();
builder.Services.AddTransient<IEntityRepository<ExercisesToCompetition>, EntityRepository<ExercisesToCompetition>>();
builder.Services.AddTransient<IEntityRepository<ExercisesToTeamToCompetition>, EntityRepository<ExercisesToTeamToCompetition>>();
builder.Services.AddTransient<IEntityRepository<ExercisesToUsersToCompetition>, EntityRepository<ExercisesToUsersToCompetition>>();
builder.Services.AddTransient<IEntityRepository<Team>, EntityRepository<Team>>();
builder.Services.AddTransient<IEntityRepository<TeamsToCompetition>, EntityRepository<TeamsToCompetition>>();
builder.Services.AddTransient<IEntityRepository<User>, EntityRepository<User>>();
builder.Services.AddTransient<IEntityRepository<OperatorsToCompetition>, EntityRepository<OperatorsToCompetition>>();
builder.Services.AddTransient<IEntityRepository<UsersToTeam>, EntityRepository<UsersToTeam>>();


builder.Services.AddTransient<IEntityToCompetitionProvider, EntityToCompetitionProvider>();
builder.Services.AddTransient<IEntityToTeamProvider, EntityToTeamProvider>();
builder.Services.AddTransient<IEntityProvider<Competition>, EntityProvider<Competition>>();
builder.Services.AddTransient<IEntityProvider<Exercise>, EntityProvider<Exercise>>();
builder.Services.AddTransient<IEntityProvider<ExerciseCategory>, EntityProvider<ExerciseCategory>>();
builder.Services.AddTransient<IEntityProvider<ExerciseLang>, EntityProvider<ExerciseLang>>();
builder.Services.AddTransient<IEntityProvider<ExercisePlatform>, EntityProvider<ExercisePlatform>>();
builder.Services.AddTransient<IEntityProvider<ExercisesToCompetition>, EntityProvider<ExercisesToCompetition>>();
builder.Services.AddTransient<IEntityProvider<ExercisesToTeamToCompetition>, EntityProvider<ExercisesToTeamToCompetition>>();
builder.Services.AddTransient<IEntityProvider<ExercisesToUsersToCompetition>, EntityProvider<ExercisesToUsersToCompetition>>();
builder.Services.AddTransient<IEntityProvider<Team>, EntityProvider<Team>>();
builder.Services.AddTransient<IEntityProvider<TeamsToCompetition>, EntityProvider<TeamsToCompetition>>();
builder.Services.AddTransient<IEntityProvider<User>, EntityProvider<User>>();
builder.Services.AddTransient<IEntityProvider<OperatorsToCompetition>, EntityProvider<OperatorsToCompetition>>();
builder.Services.AddTransient<IEntityProvider<UsersToTeam>, EntityProvider<UsersToTeam>>();

builder.Services.AddSingleton<IExceptionBuilderService, ExceptionBuilderService>();


builder.Services.AddTransient<ICompetitionManager, CompetitionManager>();
builder.Services.AddTransient<ITeamManager, TeamManager>();
builder.Services.AddTransient<IExercisesManager, ExercisesManager>();
builder.Services.AddTransient<IUserManager, UserManager>();


//builder.Services.AddTransient<IGenerateUsers, UsersStorage>();
//builder.Services.AddTransient<IReadUsers, UsersStorage>();


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

app.UseCors("AllowAnyGet")
   .UseCors("AllowExampleDomain");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<CompetitionHub>("/competitions");
app.MapHub<ExerciseHub>("/exercises");
app.MapHub<TeamHub>("/teams");
app.MapHub<UserHub>("/users");


app.Run();

