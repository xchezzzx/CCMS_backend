using System;
using System.Collections.Generic;
using ASPNETCore.Models.CloudServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCore.Models.DBModels
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

        public virtual DbSet<Competition> Competitions { get; set; } = null!;
        public virtual DbSet<CompetitionState> CompetitionStates { get; set; } = null!;
        public virtual DbSet<CompetitionsToTeam> CompetitionsToTeams { get; set; } = null!;
        public virtual DbSet<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTasks { get; set; } = null!;
        public virtual DbSet<CompetitionsToTeamsToUser> CompetitionsToTeamsToUsers { get; set; } = null!;
        public virtual DbSet<CompetitionsToUser> CompetitionsToUsers { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Exercise> Tasks { get; set; } = null!;
        public virtual DbSet<ExerciseCategory> TaskCategories { get; set; } = null!;
        public virtual DbSet<ExerciseLang> TaskLangs { get; set; } = null!;
        public virtual DbSet<ExercisePlatform> TaskPlatforms { get; set; } = null!;
        public virtual DbSet<ExerciseState> TaskStates { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamState> TeamStates { get; set; } = null!;
        public virtual DbSet<Uihistory> Uihistories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;



        //public virtual DbSet<Models.CloudServiceModels.Action> Actions { get; set; } = null!;
        //public virtual DbSet<Userdatabase> Userdatabases { get; set; } = null!;
        //public virtual DbSet<UserRoleDssTracking> UserRoleDssTrackings { get; set; } = null!;
        //public virtual DbSet<UserDssTracking> UserDssTrackings { get; set; } = null!;
        //public virtual DbSet<TeamStateDssTracking> TeamStateDssTrackings { get; set; } = null!;
        //public virtual DbSet<TeamDssTracking> TeamDssTrackings { get; set; } = null!;
        //public virtual DbSet<TaskStateDssTracking> TaskStateDssTrackings { get; set; } = null!;
        //public virtual DbSet<TaskPlatformDssTracking> TaskPlatformDssTrackings { get; set; } = null!;
        //public virtual DbSet<TaskLangDssTracking> TaskLangDssTrackings { get; set; } = null!;
        //public virtual DbSet<TaskDssTracking> TaskDssTrackings { get; set; } = null!;
        //public virtual DbSet<TaskCategoryDssTracking> TaskCategoryDssTrackings { get; set; } = null!;
        //public virtual DbSet<Task1> Tasks1 { get; set; } = null!;
        //public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        //public virtual DbSet<SyncObjectDatum> SyncObjectData { get; set; } = null!;
        //public virtual DbSet<Syncgroup> Syncgroups { get; set; } = null!;
        //public virtual DbSet<Syncgroupmember> Syncgroupmembers { get; set; } = null!;
        //public virtual DbSet<StatusDssTracking> StatusDssTrackings { get; set; } = null!;
        //public virtual DbSet<CompetitionsToTeamsToUsersDssTracking> CompetitionsToTeamsToUsersDssTrackings { get; set; } = null!;
        //public virtual DbSet<CompetitionsToTeamsToTasksDssTracking> CompetitionsToTeamsToTasksDssTrackings { get; set; } = null!;
        //public virtual DbSet<CompetitionsToTeamsDssTracking> CompetitionsToTeamsDssTrackings { get; set; } = null!;
        //public virtual DbSet<CompetitionStateDssTracking> CompetitionStateDssTrackings { get; set; } = null!;
        //public virtual DbSet<CompetitionDssTracking> CompetitionDssTrackings { get; set; } = null!;
        //public virtual DbSet<CompetitionsToUsersDssTracking> CompetitionsToUsersDssTrackings { get; set; } = null!;
        //public virtual DbSet<Configuration> Configurations { get; set; } = null!;
        //public virtual DbSet<EnumType> EnumTypes { get; set; } = null!;
        //public virtual DbSet<Job> Jobs { get; set; } = null!;
        //public virtual DbSet<MessageQueue> MessageQueues { get; set; } = null!;
        //public virtual DbSet<MetaInformation> MetaInformations { get; set; } = null!;
        //public virtual DbSet<MetaInformation1> MetaInformations1 { get; set; } = null!;
        //public virtual DbSet<ProvisionMarkerDss> ProvisionMarkerDsses { get; set; } = null!;
        //public virtual DbSet<Scaleunitlimit> Scaleunitlimits { get; set; } = null!;
        //public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        //public virtual DbSet<ScheduleTask> ScheduleTasks { get; set; } = null!;
        //public virtual DbSet<ScheduleTask1> ScheduleTasks1 { get; set; } = null!;
        //public virtual DbSet<SchemaInfoDss> SchemaInfoDsses { get; set; } = null!;
        //public virtual DbSet<ScopeConfigDss> ScopeConfigDsses { get; set; } = null!;
        //public virtual DbSet<ScopeInfoDss> ScopeInfoDsses { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:ccmsdbserver.database.windows.net,1433;Initial Catalog=ccms;Persist Security Info=False;User ID=ccmsadmin;Password=Q!w2e3r4t5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Models.CloudServiceModels.Action>(entity =>
            //{
            //    entity.ToTable("action", "dss");

            //    entity.HasIndex(e => new { e.State, e.Lastupdatetime }, "index_action_state_lastupdatetime");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Creationtime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("creationtime")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.Lastupdatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastupdatetime");

            //    entity.Property(e => e.State).HasColumnName("state");

            //    entity.Property(e => e.Syncgroupid).HasColumnName("syncgroupid");

            //    entity.Property(e => e.Type).HasColumnName("type");
            //});

            //modelBuilder.Entity<Agent>(entity =>
            //{
            //    entity.ToTable("agent", "dss");

            //    entity.HasIndex(e => new { e.Subscriptionid, e.Name }, "IX_Agent_SubId_Name")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.IsOnPremise).HasColumnName("is_on_premise");

            //    entity.Property(e => e.Lastalivetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastalivetime");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(140)
            //        .HasColumnName("name");

            //    entity.Property(e => e.PasswordHash)
            //        .HasMaxLength(256)
            //        .HasColumnName("password_hash");

            //    entity.Property(e => e.PasswordSalt)
            //        .HasMaxLength(256)
            //        .HasColumnName("password_salt");

            //    entity.Property(e => e.State)
            //        .HasColumnName("state")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

            //    entity.Property(e => e.Version)
            //        .HasMaxLength(40)
            //        .HasColumnName("version");

            //    entity.HasOne(d => d.Subscription)
            //        .WithMany(p => p.Agents)
            //        .HasForeignKey(d => d.Subscriptionid)
            //        .HasConstraintName("FK__agent__subscript");
            //});

            //modelBuilder.Entity<AgentInstance>(entity =>
            //{
            //    entity.ToTable("agent_instance", "dss");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Agentid).HasColumnName("agentid");

            //    entity.Property(e => e.Lastalivetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastalivetime");

            //    entity.Property(e => e.Version)
            //        .HasMaxLength(40)
            //        .HasColumnName("version");

            //    entity.HasOne(d => d.Agent)
            //        .WithMany(p => p.AgentInstances)
            //        .HasForeignKey(d => d.Agentid)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__agent_ins__agent");
            //});

            //modelBuilder.Entity<AgentVersion>(entity =>
            //{
            //    entity.ToTable("agent_version", "dss");

            //    entity.HasIndex(e => e.Version, "UQ__agent_ve__0F5401343538BD02")
            //        .IsUnique();

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Comment).HasMaxLength(200);

            //    entity.Property(e => e.ExpiresOn)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("('9999-12-31 23:59:59.997')");

            //    entity.Property(e => e.Version).HasMaxLength(50);
            //});

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
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hashtag");

                entity.Property(e => e.Name)
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

                //entity.Navigation(c => c.State).AutoInclude();
                //entity.Navigation(c => c.Status).AutoInclude();
            });

            //modelBuilder.Entity<CompetitionDssTracking>(entity =>
            //{
            //    entity.ToTable("competition_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<CompetitionState>(entity =>
            {
                entity.ToTable("competition_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

            });

            //modelBuilder.Entity<CompetitionStateDssTracking>(entity =>
            //{
            //    entity.ToTable("competition_state_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<CompetitionsToTeam>(entity =>
            {
                entity.ToTable("competitions_to_teams");

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
                    .WithMany(p => p.CompetitionsToTeams)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_competition");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CompetitionsToTeamCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CompetitionsToTeams)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_status");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CompetitionsToTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_team");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CompetitionsToTeamUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_user_update");
            });

            //modelBuilder.Entity<CompetitionsToTeamsDssTracking>(entity =>
            //{
            //    entity.ToTable("competitions_to_teams_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<CompetitionsToTeamsToExercise>(entity =>
            {
                entity.ToTable("competitions_to_teams_to_tasks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApprovedPoints).HasColumnName("approved_points");

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .HasColumnName("comment");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUserId).HasColumnName("create_user_id");

                entity.Property(e => e.FileLink)
                    .HasMaxLength(250)
                    .HasColumnName("file_link");

                entity.Property(e => e.SolutionLink)
                    .HasMaxLength(250)
                    .HasColumnName("solution_link");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.SubmitTime)
                    .HasColumnName("submit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Timeframe)
                    .HasColumnName("timeframe");

                entity.Property(e => e.SubmitDuration)
                    .HasColumnName("submit_duration");

                entity.Property(e => e.TakeTime)
                    .HasColumnName("take_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.TaskStateId).HasColumnName("task_state_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdateUserId).HasColumnName("update_user_id");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionsToTeamsToTasks)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_competition");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CompetitionsToTeamsToTaskCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CompetitionsToTeamsToTasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_status");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.CompetitionsToTeamsToTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_task");

                entity.HasOne(d => d.TaskState)
                    .WithMany(p => p.CompetitionsToTeamsToTasks)
                    .HasForeignKey(d => d.TaskStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_task_state");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CompetitionsToTeamsToTasks)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_team");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CompetitionsToTeamsToTaskUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_tasks_user_update");
            });

            //modelBuilder.Entity<CompetitionsToTeamsToTasksDssTracking>(entity =>
            //{
            //    entity.ToTable("competitions_to_teams_to_tasks_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<CompetitionsToTeamsToUser>(entity =>
            {
                entity.ToTable("competitions_to_teams_to_users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

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

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionsToTeamsToUsers)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_competition");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CompetitionsToTeamsToUserCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CompetitionsToTeamsToUsers)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_status");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CompetitionsToTeamsToUsers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_team");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CompetitionsToTeamsToUserUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_user_update");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompetitionsToTeamsToUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_teams_to_users_user");
            });

            //modelBuilder.Entity<CompetitionsToTeamsToUsersDssTracking>(entity =>
            //{
            //    entity.ToTable("competitions_to_teams_to_users_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<CompetitionsToUser>(entity =>
            {
                entity.ToTable("competitions_to_users");

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
                    .WithMany(p => p.CompetitionsToUsers)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_competition");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CompetitionsToUserCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_user_create");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CompetitionsToUsers)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CompetitionsToUserUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_user_update");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompetitionsToUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competitions_to_users_user");
            });

            //modelBuilder.Entity<CompetitionsToUsersDssTracking>(entity =>
            //{
            //    entity.ToTable("competitions_to_users_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            //modelBuilder.Entity<Configuration>(entity =>
            //{
            //    entity.ToTable("configuration", "dss");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.ConfigKey).HasMaxLength(100);

            //    entity.Property(e => e.ConfigValue).HasMaxLength(256);

            //    entity.Property(e => e.LastModified)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getutcdate())");
            //});

            //modelBuilder.Entity<EnumType>(entity =>
            //{
            //    entity.ToTable("EnumType", "dss");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.LastModified)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.Name).HasMaxLength(100);

            //    entity.Property(e => e.Type)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Job>(entity =>
            //{
            //    entity.ToTable("Job", "TaskHosting");

            //    entity.HasIndex(e => e.IsCancelled, "index_job_iscancelled");

            //    entity.Property(e => e.JobId).HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.InitialInsertTimeUtc)
            //        .HasColumnType("datetime")
            //        .HasColumnName("InitialInsertTimeUTC")
            //        .HasDefaultValueSql("(getutcdate())");
            //});

            //modelBuilder.Entity<MessageQueue>(entity =>
            //{
            //    entity.HasKey(e => e.MessageId)
            //        .HasName("PK__MessageQ__C87C0C9CFBB39E72");

            //    entity.ToTable("MessageQueue", "TaskHosting");

            //    entity.HasIndex(e => new { e.QueueId, e.UpdateTimeUtc, e.InsertTimeUtc, e.ExecTimes, e.Version }, "index_messagequeue_getnextmessage");

            //    entity.HasIndex(e => new { e.QueueId, e.MessageType, e.UpdateTimeUtc, e.InsertTimeUtc, e.ExecTimes, e.Version }, "index_messagequeue_getnextmessagebytype");

            //    entity.HasIndex(e => e.JobId, "index_messagequeue_jobid");

            //    entity.Property(e => e.MessageId).HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.InitialInsertTimeUtc)
            //        .HasColumnType("datetime")
            //        .HasColumnName("InitialInsertTimeUTC")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.InsertTimeUtc)
            //        .HasColumnType("datetime")
            //        .HasColumnName("InsertTimeUTC");

            //    entity.Property(e => e.UpdateTimeUtc)
            //        .HasColumnType("datetime")
            //        .HasColumnName("UpdateTimeUTC");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.MessageQueues)
            //        .HasForeignKey(d => d.JobId)
            //        .HasConstraintName("FK__MessageQu__JobId__6D9742D9");
            //});

            //modelBuilder.Entity<MetaInformation>(entity =>
            //{
            //    entity.ToTable("MetaInformation", "dss");

            //    entity.Property(e => e.State)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Timestamp)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.VersionString)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('1.0.0.0')");
            //});

            //modelBuilder.Entity<MetaInformation1>(entity =>
            //{
            //    entity.ToTable("MetaInformation", "TaskHosting");

            //    entity.Property(e => e.State)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.Timestamp)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.VersionString)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('1.0.0.0')");
            //});

            //modelBuilder.Entity<ProvisionMarkerDss>(entity =>
            //{
            //    entity.HasKey(e => new { e.OwnerScopeLocalId, e.ObjectId })
            //        .HasName("PK_DataSync.provision_marker_dss");

            //    entity.ToTable("provision_marker_dss", "DataSync");

            //    entity.Property(e => e.OwnerScopeLocalId).HasColumnName("owner_scope_local_id");

            //    entity.Property(e => e.ObjectId).HasColumnName("object_id");

            //    entity.Property(e => e.ProvisionDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("provision_datetime");

            //    entity.Property(e => e.ProvisionLocalPeerKey).HasColumnName("provision_local_peer_key");

            //    entity.Property(e => e.ProvisionScopeLocalId).HasColumnName("provision_scope_local_id");

            //    entity.Property(e => e.ProvisionScopePeerKey).HasColumnName("provision_scope_peer_key");

            //    entity.Property(e => e.ProvisionScopePeerTimestamp).HasColumnName("provision_scope_peer_timestamp");

            //    entity.Property(e => e.ProvisionTimestamp).HasColumnName("provision_timestamp");

            //    entity.Property(e => e.State).HasColumnName("state");

            //    entity.Property(e => e.Version)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("version");
            //});

            //modelBuilder.Entity<Scaleunitlimit>(entity =>
            //{
            //    entity.ToTable("scaleunitlimits", "dss");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.LastModified)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.Name).HasMaxLength(100);
            //});

            //modelBuilder.Entity<Schedule>(entity =>
            //{
            //    entity.ToTable("Schedule", "TaskHosting");
            //});

            //modelBuilder.Entity<ScheduleTask>(entity =>
            //{
            //    entity.HasKey(e => e.SyncGroupId);

            //    entity.ToTable("ScheduleTask", "dss");

            //    entity.Property(e => e.SyncGroupId).ValueGeneratedNever();

            //    entity.Property(e => e.ExpirationTime).HasColumnType("datetime");

            //    entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.LastUpdate).HasColumnType("datetime");

            //    entity.HasOne(d => d.SyncGroup)
            //        .WithOne(p => p.ScheduleTask)
            //        .HasForeignKey<ScheduleTask>(d => d.SyncGroupId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__ScheduleT__SyncG");
            //});

            //modelBuilder.Entity<ScheduleTask1>(entity =>
            //{
            //    entity.HasKey(e => e.ScheduleTaskId)
            //        .HasName("PK__Schedule__8DAD173AE2407087");

            //    entity.ToTable("ScheduleTask", "TaskHosting");

            //    entity.HasIndex(e => e.MessageId, "ScheduleTask_MessageId_Index");

            //    entity.Property(e => e.ScheduleTaskId).ValueGeneratedNever();

            //    entity.Property(e => e.NextRunTime).HasColumnType("datetime");

            //    entity.Property(e => e.TaskName).HasMaxLength(128);

            //    entity.HasOne(d => d.ScheduleNavigation)
            //        .WithMany(p => p.ScheduleTask1s)
            //        .HasForeignKey(d => d.Schedule)
            //        .HasConstraintName("FK__ScheduleT__Sched__7814D14C");
            //});

            //modelBuilder.Entity<SchemaInfoDss>(entity =>
            //{
            //    entity.HasKey(e => new { e.SchemaMajorVersion, e.SchemaMinorVersion })
            //        .HasName("PK_DataSync.schema_info_dss");

            //    entity.ToTable("schema_info_dss", "DataSync");

            //    entity.Property(e => e.SchemaMajorVersion).HasColumnName("schema_major_version");

            //    entity.Property(e => e.SchemaMinorVersion).HasColumnName("schema_minor_version");

            //    entity.Property(e => e.SchemaExtendedInfo)
            //        .HasMaxLength(100)
            //        .HasColumnName("schema_extended_info");
            //});

            //modelBuilder.Entity<ScopeConfigDss>(entity =>
            //{
            //    entity.HasKey(e => e.ConfigId)
            //        .HasName("PK_DataSync.scope_config_dss");

            //    entity.ToTable("scope_config_dss", "DataSync");

            //    entity.Property(e => e.ConfigId)
            //        .ValueGeneratedNever()
            //        .HasColumnName("config_id");

            //    entity.Property(e => e.ConfigData)
            //        .HasColumnType("xml")
            //        .HasColumnName("config_data");

            //    entity.Property(e => e.ScopeStatus)
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .HasColumnName("scope_status")
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<ScopeInfoDss>(entity =>
            //{
            //    entity.HasKey(e => e.SyncScopeName)
            //        .HasName("PK_DataSync.scope_info_dss");

            //    entity.ToTable("scope_info_dss", "DataSync");

            //    entity.Property(e => e.SyncScopeName)
            //        .HasMaxLength(100)
            //        .HasColumnName("sync_scope_name");

            //    entity.Property(e => e.ScopeConfigId).HasColumnName("scope_config_id");

            //    entity.Property(e => e.ScopeId)
            //        .HasColumnName("scope_id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.ScopeLocalId)
            //        .ValueGeneratedOnAdd()
            //        .HasColumnName("scope_local_id");

            //    entity.Property(e => e.ScopeRestoreCount).HasColumnName("scope_restore_count");

            //    entity.Property(e => e.ScopeSyncKnowledge).HasColumnName("scope_sync_knowledge");

            //    entity.Property(e => e.ScopeTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("scope_timestamp");

            //    entity.Property(e => e.ScopeTombstoneCleanupKnowledge).HasColumnName("scope_tombstone_cleanup_knowledge");

            //    entity.Property(e => e.ScopeUserComment).HasColumnName("scope_user_comment");
            //});

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<StatusDssTracking>(entity =>
            //{
            //    entity.ToTable("status_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            //modelBuilder.Entity<Subscription>(entity =>
            //{
            //    entity.ToTable("subscription", "dss");

            //    entity.HasIndex(e => e.Syncserveruniquename, "IX_SyncServerUniqueName")
            //        .IsUnique()
            //        .HasFilter("([syncserveruniquename] IS NOT NULL)");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Creationtime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("creationtime");

            //    entity.Property(e => e.EnableDetailedProviderTracing).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Lastlogintime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastlogintime");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(140)
            //        .HasColumnName("name");

            //    entity.Property(e => e.Policyid)
            //        .HasColumnName("policyid")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Subscriptionstate).HasColumnName("subscriptionstate");

            //    entity.Property(e => e.Syncserveruniquename)
            //        .HasMaxLength(256)
            //        .HasColumnName("syncserveruniquename");

            //    entity.Property(e => e.Tombstoneretentionperiodindays).HasColumnName("tombstoneretentionperiodindays");

            //    entity.Property(e => e.Version)
            //        .HasMaxLength(40)
            //        .HasColumnName("version");
            //});

            //modelBuilder.Entity<SyncObjectDatum>(entity =>
            //{
            //    entity.HasKey(e => new { e.ObjectId, e.DataType })
            //        .HasName("PK_SyncObjectExtInfo");

            //    entity.ToTable("SyncObjectData", "dss");

            //    entity.Property(e => e.CreatedTime).HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.LastModified)
            //        .IsRowVersion()
            //        .IsConcurrencyToken();
            //});

            //modelBuilder.Entity<Syncgroup>(entity =>
            //{
            //    entity.ToTable("syncgroup", "dss");

            //    entity.HasIndex(e => e.HubMemberid, "index_syncgroup_hub_memberid");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.ConflictResolutionPolicy).HasColumnName("conflict_resolution_policy");

            //    entity.Property(e => e.ConflictTableRetentionInDays).HasDefaultValueSql("((30))");

            //    entity.Property(e => e.HubMemberid).HasColumnName("hub_memberid");

            //    entity.Property(e => e.Hubhasdata).HasColumnName("hubhasdata");

            //    entity.Property(e => e.Lastupdatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastupdatetime");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(140)
            //        .HasColumnName("name");

            //    entity.Property(e => e.Ocsschemadefinition).HasColumnName("ocsschemadefinition");

            //    entity.Property(e => e.SchemaDescription)
            //        .HasColumnType("xml")
            //        .HasColumnName("schema_description");

            //    entity.Property(e => e.State)
            //        .HasColumnName("state")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

            //    entity.Property(e => e.SyncEnabled)
            //        .IsRequired()
            //        .HasColumnName("sync_enabled")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.SyncInterval).HasColumnName("sync_interval");

            //    entity.HasOne(d => d.HubMember)
            //        .WithMany(p => p.Syncgroups)
            //        .HasForeignKey(d => d.HubMemberid)
            //        .HasConstraintName("FK__syncgroup__hub_m");

            //    entity.HasOne(d => d.Subscription)
            //        .WithMany(p => p.Syncgroups)
            //        .HasForeignKey(d => d.Subscriptionid)
            //        .HasConstraintName("FK__syncgroup__subsc");
            //});

            //modelBuilder.Entity<Syncgroupmember>(entity =>
            //{
            //    entity.ToTable("syncgroupmember", "dss");

            //    entity.HasIndex(e => new { e.Syncgroupid, e.Databaseid }, "IX_SyncGroupMember_SyncGroupId_DatabaseId")
            //        .IsUnique();

            //    entity.HasIndex(e => e.Databaseid, "index_syncgroupmember_databaseid");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Databaseid).HasColumnName("databaseid");

            //    entity.Property(e => e.HubJobId).HasColumnName("hubJobId");

            //    entity.Property(e => e.Hubstate).HasColumnName("hubstate");

            //    entity.Property(e => e.HubstateLastupdated)
            //        .HasColumnType("datetime")
            //        .HasColumnName("hubstate_lastupdated")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.JobId).HasColumnName("jobId");

            //    entity.Property(e => e.Lastsynctime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastsynctime");

            //    entity.Property(e => e.LastsynctimeZerofailuresHub)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastsynctime_zerofailures_hub");

            //    entity.Property(e => e.LastsynctimeZerofailuresMember)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastsynctime_zerofailures_member");

            //    entity.Property(e => e.Memberhasdata).HasColumnName("memberhasdata");

            //    entity.Property(e => e.Memberstate).HasColumnName("memberstate");

            //    entity.Property(e => e.MemberstateLastupdated)
            //        .HasColumnType("datetime")
            //        .HasColumnName("memberstate_lastupdated")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(140)
            //        .HasColumnName("name");

            //    entity.Property(e => e.Noinitsync).HasColumnName("noinitsync");

            //    entity.Property(e => e.Scopename)
            //        .HasMaxLength(100)
            //        .HasColumnName("scopename")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Syncdirection).HasColumnName("syncdirection");

            //    entity.Property(e => e.Syncgroupid).HasColumnName("syncgroupid");

            //    entity.HasOne(d => d.Database)
            //        .WithMany(p => p.Syncgroupmembers)
            //        .HasForeignKey(d => d.Databaseid)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__syncmember__datab");

            //    entity.HasOne(d => d.Syncgroup)
            //        .WithMany(p => p.Syncgroupmembers)
            //        .HasForeignKey(d => d.Syncgroupid)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__syncmember__syncg");
            //});

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BonusContent)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("bonus_content");

                entity.Property(e => e.BonusPoints).HasColumnName("bonus_points");

                entity.Property(e => e.BonusTimeframe).HasColumnName("bonus_timeframe");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Content)
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
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_category");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TaskCreateUsers)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_user_create");

                entity.HasOne(d => d.Lang)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.LangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_lang");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_platform");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_status");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.TaskUpdateUsers)
                    .HasForeignKey(d => d.UpdateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_task_user_update");
            });

            //modelBuilder.Entity<Task1>(entity =>
            //{
            //    entity.ToTable("task", "dss");

            //    entity.HasIndex(e => e.Actionid, "index_task_actionid");

            //    entity.HasIndex(e => new { e.Agentid, e.State }, "index_task_agentid_state")
            //        .HasFilter("([state]=(0))");

            //    entity.HasIndex(e => e.Completedtime, "index_task_completedtime");

            //    entity.HasIndex(e => new { e.State, e.Agentid, e.DependencyCount, e.Priority, e.Creationtime }, "index_task_gettask");

            //    entity.HasIndex(e => new { e.State, e.Completedtime }, "index_task_state")
            //        .HasFilter("([state]=(2))");

            //    entity.HasIndex(e => new { e.Lastheartbeat, e.State }, "index_task_state_lastheartbeat")
            //        .HasFilter("([state]<(0))");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Actionid).HasColumnName("actionid");

            //    entity.Property(e => e.Agentid).HasColumnName("agentid");

            //    entity.Property(e => e.Completedtime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("completedtime");

            //    entity.Property(e => e.Creationtime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("creationtime")
            //        .HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.DependencyCount).HasColumnName("dependency_count");

            //    entity.Property(e => e.Lastheartbeat)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastheartbeat");

            //    entity.Property(e => e.Lastresettime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("lastresettime");

            //    entity.Property(e => e.OwningInstanceid).HasColumnName("owning_instanceid");

            //    entity.Property(e => e.Pickuptime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("pickuptime");

            //    entity.Property(e => e.Priority)
            //        .HasColumnName("priority")
            //        .HasDefaultValueSql("((100))");

            //    entity.Property(e => e.Request).HasColumnName("request");

            //    entity.Property(e => e.Response).HasColumnName("response");

            //    entity.Property(e => e.RetryCount).HasColumnName("retry_count");

            //    entity.Property(e => e.State)
            //        .HasColumnName("state")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.TaskNumber)
            //        .ValueGeneratedOnAdd()
            //        .HasColumnName("taskNumber");

            //    entity.Property(e => e.Type).HasColumnName("type");

            //    entity.Property(e => e.Version).HasColumnName("version");

            //    entity.HasOne(d => d.Action)
            //        .WithMany(p => p.Task1s)
            //        .HasForeignKey(d => d.Actionid)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__task__actionid");

            //    entity.HasMany(d => d.Nexttasks)
            //        .WithMany(p => p.Prevtasks)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "Taskdependency",
            //            l => l.HasOne<Task1>().WithMany().HasForeignKey("Nexttaskid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__taskdepen__nextt"),
            //            r => r.HasOne<Task1>().WithMany().HasForeignKey("Prevtaskid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__taskdepen__prevt"),
            //            j =>
            //            {
            //                j.HasKey("Nexttaskid", "Prevtaskid").HasName("PK_TaskTask");

            //                j.ToTable("taskdependency", "dss");

            //                j.IndexerProperty<Guid>("Nexttaskid").HasColumnName("nexttaskid");

            //                j.IndexerProperty<Guid>("Prevtaskid").HasColumnName("prevtaskid");
            //            });

            //    entity.HasMany(d => d.Prevtasks)
            //        .WithMany(p => p.Nexttasks)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "Taskdependency",
            //            l => l.HasOne<Task1>().WithMany().HasForeignKey("Prevtaskid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__taskdepen__prevt"),
            //            r => r.HasOne<Task1>().WithMany().HasForeignKey("Nexttaskid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__taskdepen__nextt"),
            //            j =>
            //            {
            //                j.HasKey("Nexttaskid", "Prevtaskid").HasName("PK_TaskTask");

            //                j.ToTable("taskdependency", "dss");

            //                j.IndexerProperty<Guid>("Nexttaskid").HasColumnName("nexttaskid");

            //                j.IndexerProperty<Guid>("Prevtaskid").HasColumnName("prevtaskid");
            //            });
            //});

            modelBuilder.Entity<ExerciseCategory>(entity =>
            {
                entity.ToTable("task_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<TaskCategoryDssTracking>(entity =>
            //{
            //    entity.ToTable("task_category_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            //modelBuilder.Entity<TaskDssTracking>(entity =>
            //{
            //    entity.ToTable("task_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<ExerciseLang>(entity =>
            {
                entity.ToTable("task_lang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<TaskLangDssTracking>(entity =>
            //{
            //    entity.ToTable("task_lang_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<ExercisePlatform>(entity =>
            {
                entity.ToTable("task_platform");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<TaskPlatformDssTracking>(entity =>
            //{
            //    entity.ToTable("task_platform_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<ExerciseState>(entity =>
            {
                entity.ToTable("task_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<TaskStateDssTracking>(entity =>
            //{
            //    entity.ToTable("task_state_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

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

            //modelBuilder.Entity<TeamDssTracking>(entity =>
            //{
            //    entity.ToTable("team_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<TeamState>(entity =>
            {
                entity.ToTable("team_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<TeamStateDssTracking>(entity =>
            //{
            //    entity.ToTable("team_state_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            //modelBuilder.Entity<Uihistory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("UIHistory", "dss");

            //    entity.HasIndex(e => e.Agentid, "Idx_UIHistory_AgentId");

            //    entity.HasIndex(e => e.CompletionTime, "Idx_UIHistory_CompletionTime");

            //    entity.HasIndex(e => e.Databaseid, "Idx_UIHistory_DatabaseId");

            //    entity.HasIndex(e => e.Id, "Idx_UIHistory_Id");

            //    entity.HasIndex(e => e.Serverid, "Idx_UIHistory_ServerId")
            //        .IsClustered();

            //    entity.HasIndex(e => e.SyncgroupId, "Idx_UIHistory_SyncgroupId");

            //    entity.Property(e => e.Agentid).HasColumnName("agentid");

            //    entity.Property(e => e.CompletionTime).HasColumnName("completionTime");

            //    entity.Property(e => e.Databaseid).HasColumnName("databaseid");

            //    entity.Property(e => e.DetailEnumId)
            //        .HasMaxLength(400)
            //        .HasColumnName("detailEnumId");

            //    entity.Property(e => e.DetailStringParameters).HasColumnName("detailStringParameters");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.IsWritable)
            //        .HasColumnName("isWritable")
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.RecordType).HasColumnName("recordType");

            //    entity.Property(e => e.Serverid).HasColumnName("serverid");

            //    entity.Property(e => e.SyncgroupId).HasColumnName("syncgroupId");

            //    entity.Property(e => e.TaskType).HasColumnName("taskType");
            //});

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

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
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

            //modelBuilder.Entity<UserDssTracking>(entity =>
            //{
            //    entity.ToTable("user_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            //modelBuilder.Entity<UserRoleDssTracking>(entity =>
            //{
            //    entity.ToTable("user_role_dss_tracking", "DataSync");

            //    entity.HasIndex(e => new { e.LocalUpdatePeerTimestamp, e.Id }, "local_update_peer_timestamp_index");

            //    entity.HasIndex(e => new { e.SyncRowIsTombstone, e.LocalUpdatePeerTimestamp }, "tombstone_index");

            //    entity.Property(e => e.Id)
            //        .ValueGeneratedNever()
            //        .HasColumnName("id");

            //    entity.Property(e => e.CreateScopeLocalId).HasColumnName("create_scope_local_id");

            //    entity.Property(e => e.LastChangeDatetime)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_change_datetime");

            //    entity.Property(e => e.LocalCreatePeerKey).HasColumnName("local_create_peer_key");

            //    entity.Property(e => e.LocalCreatePeerTimestamp).HasColumnName("local_create_peer_timestamp");

            //    entity.Property(e => e.LocalUpdatePeerKey).HasColumnName("local_update_peer_key");

            //    entity.Property(e => e.LocalUpdatePeerTimestamp)
            //        .IsRowVersion()
            //        .IsConcurrencyToken()
            //        .HasColumnName("local_update_peer_timestamp");

            //    entity.Property(e => e.ScopeCreatePeerKey).HasColumnName("scope_create_peer_key");

            //    entity.Property(e => e.ScopeCreatePeerTimestamp).HasColumnName("scope_create_peer_timestamp");

            //    entity.Property(e => e.ScopeUpdatePeerKey).HasColumnName("scope_update_peer_key");

            //    entity.Property(e => e.ScopeUpdatePeerTimestamp).HasColumnName("scope_update_peer_timestamp");

            //    entity.Property(e => e.SyncRowIsTombstone).HasColumnName("sync_row_is_tombstone");

            //    entity.Property(e => e.UpdateScopeLocalId).HasColumnName("update_scope_local_id");
            //});

            //modelBuilder.Entity<Userdatabase>(entity =>
            //{
            //    entity.ToTable("userdatabase", "dss");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Agentid).HasColumnName("agentid");

            //    entity.Property(e => e.ConnectionString).HasColumnName("connection_string");

            //    entity.Property(e => e.Database)
            //        .HasMaxLength(256)
            //        .HasColumnName("database");

            //    entity.Property(e => e.DbSchema).HasColumnName("db_schema");

            //    entity.Property(e => e.IsOnPremise).HasColumnName("is_on_premise");

            //    entity.Property(e => e.JobId).HasColumnName("jobId");

            //    entity.Property(e => e.LastSchemaUpdated)
            //        .HasColumnType("datetime")
            //        .HasColumnName("last_schema_updated");

            //    entity.Property(e => e.LastTombstonecleanup)
            //        .HasColumnType("datetime")    
            //        .HasColumnName("last_tombstonecleanup");

            //    entity.Property(e => e.Region)
            //        .HasMaxLength(256)
            //        .HasColumnName("region");

            //    entity.Property(e => e.Server)
            //        .HasMaxLength(256)
            //        .HasColumnName("server");

            //    entity.Property(e => e.SqlazureInfo)
            //        .HasColumnType("xml")
            //        .HasColumnName("sqlazure_info");

            //    entity.Property(e => e.State).HasColumnName("state");

            //    entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

            //    entity.HasOne(d => d.Subscription)
            //        .WithMany(p => p.Userdatabases)
            //        .HasForeignKey(d => d.Subscriptionid)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__userdatab__subsc");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
