using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competition_state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercise_state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "competition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    start_date_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_date_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    number_conc_tasks = table.Column<int>(type: "int", nullable: false),
                    hashtag = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition", x => x.id);
                    table.ForeignKey(
                        name: "FK_competition_competition_state",
                        column: x => x.state_id,
                        principalTable: "competition_state",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competition_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    points_summary = table.Column<int>(type: "int", nullable: true),
                    current_competition_id = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_competition",
                        column: x => x.current_competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_role",
                        column: x => x.role_id,
                        principalTable: "user_role",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercise_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercise_category_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercise_category_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercise_category_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercise_lang",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_lang", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercise_lang_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercise_lang_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercise_lang_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercise_platform",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_platform", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercise_platform_status_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercise_platform_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercise_platform_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "operators_to_competitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operators_to_competitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_operators_to_competitions_competition",
                        column: x => x.competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operators_to_competitions_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operators_to_competitions_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operators_to_competitions_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_operators_to_competitions_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    icon = table.Column<byte[]>(type: "image", nullable: true),
                    sum_points = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.id);
                    table.ForeignKey(
                        name: "FK_team_team_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_team_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_team_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    content = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    lang_id = table.Column<int>(type: "int", nullable: false),
                    platform_id = table.Column<int>(type: "int", nullable: false),
                    timeframe = table.Column<TimeSpan>(type: "time", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    fine = table.Column<int>(type: "int", nullable: false),
                    if_has_bonus = table.Column<bool>(type: "bit", nullable: false),
                    bonus_content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    bonus_timeframe = table.Column<TimeSpan>(type: "time", nullable: true),
                    bonus_points = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise", x => x.id);
                    table.ForeignKey(
                        name: "FK_task_category",
                        column: x => x.category_id,
                        principalTable: "exercise_category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_task_lang",
                        column: x => x.lang_id,
                        principalTable: "exercise_lang",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_task_platform",
                        column: x => x.platform_id,
                        principalTable: "exercise_platform",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_task_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_task_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_task_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "teams_to_competitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    taken_tasks = table.Column<int>(type: "int", nullable: true),
                    team_points = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams_to_competitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_competition",
                        column: x => x.competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_team",
                        column: x => x.team_id,
                        principalTable: "team",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users_to_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    is_captain = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_to_teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_users_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_users_team",
                        column: x => x.team_id,
                        principalTable: "team",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_users_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_users_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_users_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercises_to_competition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    exercise_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises_to_competition", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercises_to_competition_competition",
                        column: x => x.competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_competition_exercise",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_competition_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_competition_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_competition_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercises_to_teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    exercise_id = table.Column<int>(type: "int", nullable: false),
                    take_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    timeframe = table.Column<TimeSpan>(type: "time", nullable: false),
                    exercise_state_id = table.Column<int>(type: "int", nullable: false),
                    submit_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    submit_duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    solution_link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    file_link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    approved_points = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises_to_teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_tasks_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_tasks_task",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_tasks_task_state",
                        column: x => x.exercise_state_id,
                        principalTable: "exercise_state",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_tasks_team",
                        column: x => x.team_id,
                        principalTable: "team",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_tasks_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_competitions_to_teams_to_tasks_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_teams_competition",
                        column: x => x.competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "exercises_to_users_to_competitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    exercise_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_user_id = table.Column<int>(type: "int", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_user_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises_to_users_to_competitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_exercises_to_users_exercise",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_users_to_competitions_competition",
                        column: x => x.competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_users_to_competitions_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_users_to_competitions_user_create",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_users_to_competitions_user_update",
                        column: x => x.update_user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_exercises_to_users_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_competition_create_user_id",
                table: "competition",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_state_id",
                table: "competition",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_status_id",
                table: "competition",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_update_user_id",
                table: "competition",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_category_id",
                table: "exercise",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_create_user_id",
                table: "exercise",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_lang_id",
                table: "exercise",
                column: "lang_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_platform_id",
                table: "exercise",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_status_id",
                table: "exercise",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_update_user_id",
                table: "exercise",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_category_create_user_id",
                table: "exercise_category",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_category_status_id",
                table: "exercise_category",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_category_update_user_id",
                table: "exercise_category",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_lang_create_user_id",
                table: "exercise_lang",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_lang_status_id",
                table: "exercise_lang",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_lang_update_user_id",
                table: "exercise_lang",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_platform_create_user_id",
                table: "exercise_platform",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_platform_status_id",
                table: "exercise_platform",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_platform_update_user_id",
                table: "exercise_platform",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_competition_competition_id",
                table: "exercises_to_competition",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_competition_create_user_id",
                table: "exercises_to_competition",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_competition_exercise_id",
                table: "exercises_to_competition",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_competition_status_id",
                table: "exercises_to_competition",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_competition_update_user_id",
                table: "exercises_to_competition",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_competition_id",
                table: "exercises_to_teams",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_create_user_id",
                table: "exercises_to_teams",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_exercise_id",
                table: "exercises_to_teams",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_exercise_state_id",
                table: "exercises_to_teams",
                column: "exercise_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_status_id",
                table: "exercises_to_teams",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_team_id",
                table: "exercises_to_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_teams_update_user_id",
                table: "exercises_to_teams",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_users_to_competitions_competition_id",
                table: "exercises_to_users_to_competitions",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_users_to_competitions_create_user_id",
                table: "exercises_to_users_to_competitions",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_users_to_competitions_exercise_id",
                table: "exercises_to_users_to_competitions",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_users_to_competitions_status_id",
                table: "exercises_to_users_to_competitions",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_users_to_competitions_update_user_id",
                table: "exercises_to_users_to_competitions",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercises_to_users_to_competitions_user_id",
                table: "exercises_to_users_to_competitions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_to_competitions_competition_id",
                table: "operators_to_competitions",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_to_competitions_create_user_id",
                table: "operators_to_competitions",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_to_competitions_status_id",
                table: "operators_to_competitions",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_to_competitions_update_user_id",
                table: "operators_to_competitions",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_operators_to_competitions_user_id",
                table: "operators_to_competitions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_create_user_id",
                table: "team",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_status_id",
                table: "team",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_update_user_id",
                table: "team",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_to_competitions_competition_id",
                table: "teams_to_competitions",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_to_competitions_create_user_id",
                table: "teams_to_competitions",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_to_competitions_status_id",
                table: "teams_to_competitions",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_to_competitions_team_id",
                table: "teams_to_competitions",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_to_competitions_update_user_id",
                table: "teams_to_competitions",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_create_user_id",
                table: "user",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_current_competition_id",
                table: "user",
                column: "current_competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_status_id",
                table: "user",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_update_user_id",
                table: "user",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_to_teams_create_user_id",
                table: "users_to_teams",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_to_teams_status_id",
                table: "users_to_teams",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_to_teams_team_id",
                table: "users_to_teams",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_to_teams_update_user_id",
                table: "users_to_teams",
                column: "update_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_to_teams_user_id",
                table: "users_to_teams",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_competition_user_create",
                table: "competition",
                column: "create_user_id",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_competition_user_modify",
                table: "competition",
                column: "update_user_id",
                principalTable: "user",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_competition_competition_state",
                table: "competition");

            migrationBuilder.DropForeignKey(
                name: "FK_competition_status",
                table: "competition");

            migrationBuilder.DropForeignKey(
                name: "FK_user_user_status",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_competition_user_create",
                table: "competition");

            migrationBuilder.DropForeignKey(
                name: "FK_competition_user_modify",
                table: "competition");

            migrationBuilder.DropTable(
                name: "exercises_to_competition");

            migrationBuilder.DropTable(
                name: "exercises_to_teams");

            migrationBuilder.DropTable(
                name: "exercises_to_users_to_competitions");

            migrationBuilder.DropTable(
                name: "operators_to_competitions");

            migrationBuilder.DropTable(
                name: "teams_to_competitions");

            migrationBuilder.DropTable(
                name: "users_to_teams");

            migrationBuilder.DropTable(
                name: "exercise_state");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "exercise_category");

            migrationBuilder.DropTable(
                name: "exercise_lang");

            migrationBuilder.DropTable(
                name: "exercise_platform");

            migrationBuilder.DropTable(
                name: "competition_state");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "competition");

            migrationBuilder.DropTable(
                name: "user_role");
        }
    }
}
