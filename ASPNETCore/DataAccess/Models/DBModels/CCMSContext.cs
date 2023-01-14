using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class CCMSContext : DbContext
    {
        public CCMSContext()
        {
        }

        public CCMSContext(DbContextOptions<CCMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionState> CompetitionStates { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public virtual DbSet<ExerciseLang> ExerciseLangs { get; set; }
        public virtual DbSet<ExercisePlatform> ExercisePlatforms { get; set; }
        public virtual DbSet<ExerciseState> ExerciseStates { get; set; }
        public virtual DbSet<ExercisesToTeam> ExercisesToTeams { get; set; }
        public virtual DbSet<ExercisesToUser> ExercisesToUsers { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamsToCompetition> TeamsToCompetitions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UsersToCompetition> UsersToCompetitions { get; set; }
        public virtual DbSet<UsersToTeam> UsersToTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:ccmsdbserver.database.windows.net,1433;Initial Catalog=ccms;Persist Security Info=False;User ID=ccmsadmin;Password=Q!w2e3r4t5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition>(entity =>
            {
                entity.ToTable("competition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.EndDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date_time");

                entity.Property(e => e.Hashtag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hashtag");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumberConcTasks).HasColumnName("number_conc_tasks");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date_time");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CompetitionCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competition_user_create");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competition_competition_state");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competition_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CompetitionUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competition_user_modify");
            });

            modelBuilder.Entity<CompetitionState>(entity =>
            {
                entity.ToTable("competition_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("exercise");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BonusContent)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("bonus_content");

                entity.Property(e => e.BonusPoints).HasColumnName("bonus_points");

                entity.Property(e => e.BonusTimeframe).HasColumnName("bonus_timeframe");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.Fine).HasColumnName("fine");

                entity.Property(e => e.IfHasBonus).HasColumnName("if_has_bonus");

                entity.Property(e => e.LangId).HasColumnName("lang_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PlatformId).HasColumnName("platform_id");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Timeframe).HasColumnName("timeframe");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_category");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.ExerciseCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_user_create");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.LangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_lang");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_platform");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ExerciseUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_user_update");
            });

            modelBuilder.Entity<ExerciseCategory>(entity =>
            {
                entity.ToTable("exercise_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.ExerciseCategoryCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_category_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ExerciseCategories)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_category_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ExerciseCategoryUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_category_user_update");
            });

            modelBuilder.Entity<ExerciseLang>(entity =>
            {
                entity.ToTable("exercise_lang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.ExerciseLangCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_lang_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ExerciseLangs)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_lang_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ExerciseLangUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_lang_user_update");
            });

            modelBuilder.Entity<ExercisePlatform>(entity =>
            {
                entity.ToTable("exercise_platform");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.ExercisePlatformCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_platform_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ExercisePlatforms)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_platform_status_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ExercisePlatformUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercise_platform_user_update");
            });

            modelBuilder.Entity<ExerciseState>(entity =>
            {
                entity.ToTable("exercise_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ExercisesToTeam>(entity =>
            {
                entity.ToTable("exercises_to_teams");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovedPoints).HasColumnName("approved_points");

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .HasColumnName("comment");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

                entity.Property(e => e.ExerciseStateId).HasColumnName("exercise_state_id");

                entity.Property(e => e.FileLink)
                    .HasMaxLength(250)
                    .HasColumnName("file_link");

                entity.Property(e => e.SolutionLink)
                    .HasMaxLength(250)
                    .HasColumnName("solution_link");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.SubmitDuration).HasColumnName("submit_duration");

                entity.Property(e => e.SubmitTime)
                    .HasColumnType("datetime")
                    .HasColumnName("submit_time");

                entity.Property(e => e.TakeTime)
                    .HasColumnType("datetime")
                    .HasColumnName("take_time");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.Timeframe).HasColumnName("timeframe");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.ExercisesToTeamCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_user_create");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExercisesToTeams)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_task");

                entity.HasOne(d => d.ExerciseState)
                    .WithMany(p => p.ExercisesToTeams)
                    .HasForeignKey(d => d.ExerciseStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_task_state");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ExercisesToTeams)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_status");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ExercisesToTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_team");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ExercisesToTeamUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_user_update");
            });

            modelBuilder.Entity<ExercisesToUser>(entity =>
            {
                entity.ToTable("exercises_to_users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExercisesToUsers)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercises_to_users_exercise");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExercisesToUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exercises_to_users_user");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.Icon)
                    .HasColumnType("image")
                    .HasColumnName("icon");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.SumPoints).HasColumnName("sum_points");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TeamCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_team_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_team_team_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.TeamUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_team_user_update");
            });

            modelBuilder.Entity<TeamsToCompetition>(entity =>
            {
                entity.ToTable("teams_to_competitions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TakenTasks).HasColumnName("taken_tasks");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TeamPoints).HasColumnName("team_points");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.TeamsToCompetitions)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_competition");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TeamsToCompetitionCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TeamsToCompetitions)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_status");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamsToCompetitions)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_team");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.TeamsToCompetitionUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_user_update");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.CurrentCompetitionId).HasColumnName("current_competition_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.PointsSummary).HasColumnName("points_summary");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.InverseCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_user_create");

                entity.HasOne(d => d.CurrentCompetition)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CurrentCompetitionId)
                    .HasConstraintName("FK_user_competition");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_user_role");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_user_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.InverseUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_user_update");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UsersToCompetition>(entity =>
            {
                entity.ToTable("users_to_competitions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.UsersToCompetitions)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_competition");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.UsersToCompetitionCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UsersToCompetitions)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.UsersToCompetitionUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_user_update");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersToCompetitionUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_user");
            });

            modelBuilder.Entity<UsersToTeam>(entity =>
            {
                entity.ToTable("users_to_teams");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.IsCaptain).HasColumnName("is_captain");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.UsersToTeamCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UsersToTeams)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_status");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.UsersToTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_team");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.UsersToTeamUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_user_update");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersToTeamUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
