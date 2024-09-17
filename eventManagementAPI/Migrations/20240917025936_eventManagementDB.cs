using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class eventManagementDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    pk_provinces = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    province_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.pk_provinces);
                });

            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    pk_user_types = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_type_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.pk_user_types);
                });

            migrationBuilder.CreateTable(
                name: "Cantons",
                columns: table => new
                {
                    pk_cantons = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    canton_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fk_provinces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cantons", x => x.pk_cantons);
                    table.ForeignKey(
                        name: "FK_Cantons_Provinces_fk_provinces",
                        column: x => x.fk_provinces,
                        principalTable: "Provinces",
                        principalColumn: "pk_provinces",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    pk_users = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cellphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fk_user_types = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.pk_users);
                    table.ForeignKey(
                        name: "FK_users_user_types_fk_user_types",
                        column: x => x.fk_user_types,
                        principalTable: "user_types",
                        principalColumn: "pk_user_types",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    pk_districts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fk_cantons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.pk_districts);
                    table.ForeignKey(
                        name: "FK_Districts_Cantons_fk_cantons",
                        column: x => x.fk_cantons,
                        principalTable: "Cantons",
                        principalColumn: "pk_cantons",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    pk_tokens = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jwt_token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_revoked = table.Column<bool>(type: "bit", nullable: false),
                    fk_users = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.pk_tokens);
                    table.ForeignKey(
                        name: "FK_tokens_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "pk_users",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    pk_events = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    event_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exact_place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fk_provinces = table.Column<int>(type: "int", nullable: false),
                    fk_cantons = table.Column<int>(type: "int", nullable: false),
                    fk_districts = table.Column<int>(type: "int", nullable: false),
                    starting_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    finishing_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.pk_events);
                    table.ForeignKey(
                        name: "FK_Events_Cantons_fk_cantons",
                        column: x => x.fk_cantons,
                        principalTable: "Cantons",
                        principalColumn: "pk_cantons",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Districts_fk_districts",
                        column: x => x.fk_districts,
                        principalTable: "Districts",
                        principalColumn: "pk_districts",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Provinces_fk_provinces",
                        column: x => x.fk_provinces,
                        principalTable: "Provinces",
                        principalColumn: "pk_provinces",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cantons_fk_provinces",
                table: "Cantons",
                column: "fk_provinces");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_fk_cantons",
                table: "Districts",
                column: "fk_cantons");

            migrationBuilder.CreateIndex(
                name: "IX_Events_fk_cantons",
                table: "Events",
                column: "fk_cantons");

            migrationBuilder.CreateIndex(
                name: "IX_Events_fk_districts",
                table: "Events",
                column: "fk_districts");

            migrationBuilder.CreateIndex(
                name: "IX_Events_fk_provinces",
                table: "Events",
                column: "fk_provinces");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_UserId",
                table: "tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_fk_user_types",
                table: "users",
                column: "fk_user_types");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Cantons");

            migrationBuilder.DropTable(
                name: "user_types");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
