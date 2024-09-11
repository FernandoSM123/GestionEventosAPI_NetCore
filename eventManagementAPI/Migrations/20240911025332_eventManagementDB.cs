using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    event_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    event_details = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "user_types",
                columns: new[] { "pk_user_types", "user_type_description", "user_type_name" },
                values: new object[,]
                {
                    { 1, "User with full administrative rights", "Administrator" },
                    { 2, "User with read-only access", "Viewer" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "pk_users", "cellphone", "email", "lastname", "password", "fk_user_types", "username" },
                values: new object[,]
                {
                    { 1, "1-910-611-3821 x801", "Emelie_Keeling@yahoo.com", "Herman", "$2a$11$eTwJG7xJHHwn4mea5LrfieOpB1x3FRTiLepIW/UJezvEx4dzi6bkK", 1, "Alexzander66" },
                    { 2, "(706) 616-2121 x772", "Rebekah52@hotmail.com", "Pfannerstill", "$2a$11$6FJNjqUBHJb14yxN1aWee.k3DbIzGg00kz90h0ng.C3mrnW95dDT6", 1, "Kamryn.Daniel" },
                    { 3, "1-416-316-1051", "Nicholaus.Tillman32@gmail.com", "Beier", "$2a$11$qqTvRyZLLC9Cj.TxuddRBe4kdfa38Uz7aRS/Ojf6AHymdQZ1AhaGq", 2, "Gloria.Koch85" },
                    { 4, "651.705.4009", "Clementina70@gmail.com", "Wunsch", "$2a$11$yf1lyuwSzICFCUBxKFSFvuAxeJymH5U1rsQ5/FGzXOZjgr/cFdune", 2, "Daphne.Lang" },
                    { 5, "(340) 702-3695 x726", "Alfreda.Schimmel@hotmail.com", "Moen", "$2a$11$hvpXX2VMzKzLatrqSh1svu4n/AhYv0vMa0SluUHT46vpxBBMNnC4O", 2, "Lorine_Hand97" },
                    { 6, "1-284-401-8648 x039", "Gussie.Sauer70@hotmail.com", "Morissette", "$2a$11$W/Z1zMBor21xfRpq2zyIEOGOfhUXDyx.T4RFaY9XrqPkyWwstwAJ2", 2, "Mavis58" },
                    { 7, "1-308-741-0671 x992", "Lia_Fahey@gmail.com", "Greenfelder", "$2a$11$gKirFDjKGQ2Ew1UgXGvNCOfkOL29Ss0BAIVhJwMhkNKFGkXcmK35C", 1, "Michel57" },
                    { 8, "445.304.1820 x05637", "Marilou92@yahoo.com", "Aufderhar", "$2a$11$7wOAnsHYw8aJ65q8ypdDpum/dXUdCH4W74HsWOSd72nlByw4tRFo.", 2, "Enos.Gusikowski12" },
                    { 9, "657-859-2853 x16522", "Kali_Corwin65@yahoo.com", "Crooks", "$2a$11$VzfKXnEZMgcerXZeEQCJmu9hGR.oUXwYFy34bSVldAgHPljI7yIlq", 2, "Jeremy.Cormier42" },
                    { 10, "(904) 636-7904 x9924", "Elena_Wilderman24@hotmail.com", "Reynolds", "$2a$11$gtWvD0p8KLT/EUY0VZ5aO.8ndKlXRlHnNQbSl1fkP/qW.tUeyDAR6", 2, "Giovani42" },
                    { 11, "586.753.3963", "Hailey.Nicolas@yahoo.com", "Murray", "$2a$11$LZRb.L93ArncwlZhTPNCN.H7DiSMfBZgmesEdYuAcBjyXFSzKOIHi", 1, "Eliane.Keeling" },
                    { 12, "(424) 923-7923 x19608", "Angela3@gmail.com", "White", "$2a$11$eiuKPsamGKQODE9C004I7Ow4YYsYvXm0fy7jpN6BGxWoxYUDqJUqi", 1, "Janice19" },
                    { 13, "1-285-500-0561", "Rhiannon.Mraz@gmail.com", "Weimann", "$2a$11$j5S5yB9AKkqq12GRCCq.J.fKSQKSY7Qaj78wXEqQfQgssxBt0KXHK", 1, "Lela18" },
                    { 14, "1-419-473-2352 x73721", "Houston.Wunsch36@gmail.com", "Ratke", "$2a$11$LJRakr5Cg/kAF/NcciO2ee8bdcClR8Ly67NH45WlcrrHzLNyPvTpO", 2, "Agnes_Kirlin" },
                    { 15, "927-924-3630", "Julia.Keeling@hotmail.com", "Jacobs", "$2a$11$K/H8yZCTacVpJCzGFrdPROC3Lz1k19q0VWIZEp0/kHEDU83RA68lW", 1, "Thomas.Windler" },
                    { 16, "(712) 298-5191", "Alisha.Murphy@gmail.com", "Macejkovic", "$2a$11$jjaVzE5BPPXn0E2xTWrSo.zsZh2b6eVarT.dgMrOuNQb3N8FsQZnq", 2, "Tara.Pouros" },
                    { 17, "309.945.8753", "Vicky.Wisoky48@yahoo.com", "Purdy", "$2a$11$eCG8miFlc2AAmjzDHqtDgexhg3FdRie1NxQYCbAzvJFc00dMg3BpS", 2, "Lavon64" },
                    { 18, "1-507-707-0018 x82874", "Carlee79@hotmail.com", "Homenick", "$2a$11$LoT71b5dSkvyxUH.Cd07GeN.Fm9NeR35D5fB.66phiSZL4sLJBv2a", 2, "Jennings72" },
                    { 19, "800.791.0462", "Virginie.Leannon39@yahoo.com", "Armstrong", "$2a$11$1Ht0GUAX23FOiwFQraGgVuoaUYrIzuAGSc/5t2LWCVxkhfCgulVQ6", 2, "Maye.Terry" },
                    { 20, "585.747.4871", "Felipe_Zulauf@hotmail.com", "Kulas", "$2a$11$sBZ6upUkKfbxyXhuSBBkIOu4mwr2F5Z5QN5DVnJvQ5bUZlt28KFfW", 1, "Sven.Torp" },
                    { 21, "562.489.7316", "Noemi25@hotmail.com", "Wunsch", "$2a$11$oTGEoSKW2ZZG5syf8u/RVOwNChXQK0utW1C5T/j2ZnYKeIel/XGpG", 2, "Jarod.Schulist" },
                    { 22, "920-378-8447 x2246", "Lupe.Yost@gmail.com", "Von", "$2a$11$Mj2Eo/VOo2yloIHGUDw81uVneQEgyAcm6gIXO7UMSv3TdUNWtkinS", 2, "Craig57" },
                    { 23, "515-425-7223 x182", "Melvina4@gmail.com", "Connelly", "$2a$11$9xl8kEB3.SO9Ix7c8jDv4OBpN2Xx6fxQqBToXYlqrpsBpc3v/euAG", 1, "Kaya.Satterfield89" },
                    { 24, "493.295.9244 x402", "Magnus_Gutkowski@hotmail.com", "Ondricka", "$2a$11$IlxAE.9hCsDcGv9gR8nRz.yfGpofQ87E1VgbJLOFrLBV1pUQqolKm", 1, "Olen.Aufderhar" },
                    { 25, "1-994-758-7370 x1392", "Green_Fay47@gmail.com", "Conroy", "$2a$11$ZXM7nuxFNdHgC4wv3OX2EO6/TpMLyaLRs2BQ6IeBfbrjkA7L5q/eO", 1, "Koby_Bailey" },
                    { 26, "(250) 489-2512 x716", "Kaylee_Mayer71@gmail.com", "Hermiston", "$2a$11$fsLY0EjGyNoj2khqGjiyYePfnQTj4EusislI5trL3AMWaav5DClmu", 1, "Alva30" },
                    { 27, "(842) 798-2048", "Ellsworth31@hotmail.com", "Osinski", "$2a$11$rzVuHTL/.a2KuXXVUGSq..MmgD4UAf9Q0HUZUcRRm6mNiB7/GXKcG", 1, "Zoey.Muller5" },
                    { 28, "659-468-1448 x3509", "Patience.Bauch@yahoo.com", "Schaefer", "$2a$11$ZNGO4sZJ7LZKtAplq3L7/O/6dmmn0/FRFQvaa8Qt51X8eYZUzE4DC", 1, "Henri_Bauch" },
                    { 29, "955-502-6208 x879", "Mittie.Breitenberg99@yahoo.com", "Morar", "$2a$11$tutrnPDqnRbJfsiyOBC0L.G6tP/BfUveiyOOwpa7ohHHMaruZMZj.", 2, "Vicente48" },
                    { 30, "(614) 405-6375", "Edward41@yahoo.com", "Deckow", "$2a$11$FVLHMuYmmbyBSNiFsblasu2OcFyisI9D//aerzaTFmS1PBmmbNeH2", 1, "Lora_Rutherford4" },
                    { 31, "1-533-550-3287 x52583", "Ashlynn.Collier22@hotmail.com", "Schulist", "$2a$11$cw.0mwGk/lj2Es9YSfsBTeW5QAtVlu2YKzoJ1FXFRt4RD6DXUJ/g6", 1, "Anne38" },
                    { 32, "736-391-2117", "Chasity.Rempel13@gmail.com", "Mayer", "$2a$11$bTb/y1YF0tRe4eRQk/0b2eqmCWs4s7pL.aKJ8STrcKOZxsYu7sZCa", 2, "Titus_Kuhlman25" },
                    { 33, "994-466-9370 x9253", "Tyson.Johnston@yahoo.com", "Langworth", "$2a$11$hxVPVLCsbTMafsrs2Q6eBO2an416JpvRo9XOqRKFJ2s2boY2egPE2", 1, "Evans14" },
                    { 34, "215.660.5589 x5368", "Francis92@yahoo.com", "Dach", "$2a$11$vgwYhD9gTfBtQocTZ3NMWe8dYmLLqLJKPLZ75YSjzyjraUa5GviRa", 1, "Brayan.Considine99" },
                    { 35, "(787) 713-4450 x106", "Lauryn83@gmail.com", "Botsford", "$2a$11$vXxXxG2PoK6TDlLrgt.NguV6S.FWwMtnfCve9vXU1L8rVs4d5CpVm", 1, "Clemmie_Grady41" },
                    { 36, "1-244-227-5107", "Estevan_Brekke@yahoo.com", "Hettinger", "$2a$11$.n52YyPhQNrrcvLSEHEfxuEQn5jatedPHImPpG5kTQcC/vFYEkRkm", 2, "Valentin68" },
                    { 37, "(317) 725-4687 x0916", "Krystel84@hotmail.com", "Yundt", "$2a$11$ifZaNPEVBTYAI9nhjZLIW.iJoPaUdMFFk6pn0BEwEzMP8IMAms.72", 2, "Howard_Von" },
                    { 38, "994-671-6129 x166", "Linnie_Durgan14@yahoo.com", "Funk", "$2a$11$GuozC5fyC4Sy3ZH2eq4N9uskddJL0BPvi.LzO/AXemMh4aAtmlxBO", 1, "Grady_Boyer" },
                    { 39, "327.452.3992", "Cleora25@gmail.com", "Koss", "$2a$11$kmckVAy6egoiupwORoML6.4kzB12ocylPcmV8huAsGuY7LeHLt2Fq", 1, "Adolph.Breitenberg" },
                    { 40, "1-549-434-0910 x5179", "Marques47@gmail.com", "Hudson", "$2a$11$f870dPlsH833wgvCjZHYW.NoAopS/miX5OJGEoz9L3CzCNuMG2MQe", 2, "Warren5" },
                    { 41, "1-405-546-1199", "Bartholome.Kuhlman@hotmail.com", "Schuster", "$2a$11$9o/n7X9gYHOyYt7gHA97DuUCjButNRRp7AxRdN.Ud4B0a4TMI8Q0S", 1, "Micaela_Klocko20" },
                    { 42, "(796) 684-6662", "Alda.Kreiger@gmail.com", "Satterfield", "$2a$11$SQEvF0kWABSEuEkRSHtlZuhrp0RdA40NeWPkwJwHk.7ma.d69/YH2", 2, "Kaleb.Parisian" },
                    { 43, "(702) 757-8966", "Priscilla.Balistreri@hotmail.com", "Ruecker", "$2a$11$Lu8AcmPFm5nPHh1iwTiQO.9WtY9XktDo8DvSNgZ.qS1Ir9TxMuFrW", 1, "Tierra7" },
                    { 44, "977-680-7737", "Elaina_Beer@hotmail.com", "Blanda", "$2a$11$lY3xVkt/EH4kyVuXSCk7FOHdk.h381k4zO/IJPGwPOZ7PpVZ11D42", 2, "Preston_Rohan" },
                    { 45, "237-406-3979", "Clair79@yahoo.com", "Keebler", "$2a$11$CWo6DcxbvxLsLO5Ldmk9M.TJLr0fyf1x2m5zJnpbrFOMvr3VqRugu", 1, "Alta_Nicolas" },
                    { 46, "(456) 633-0961", "Verla.Bailey@yahoo.com", "Lehner", "$2a$11$M6/zhb8mTuwVwcmiVqg8U.bRZ51pmjsXcv3nTx/c6v4hTlPRLhU4C", 1, "Anika_Lockman" },
                    { 47, "1-510-348-5339 x72878", "Shaniya25@gmail.com", "Cruickshank", "$2a$11$o.VR/G22pypGR4Y8t0mkrOfF6CpTFPaLvuSJ/pNQ92bR2VftaByFi", 1, "Clarissa_Powlowski" },
                    { 48, "696.234.5017", "Santa_Grimes12@gmail.com", "Greenfelder", "$2a$11$Fi6Es/WFLmYe6LBsdL.5VO79Fh9x80ZEEwx/O3prW3WZ3FFJAc4YO", 1, "Thad_Zieme" },
                    { 49, "(567) 307-7893 x4292", "Christina_Swaniawski73@yahoo.com", "Reichel", "$2a$11$.d.nm5rcTNnsfGxCj/th3uXRyU/Kbv5xlHzu1iMA/ajSX5sGac.Hy", 2, "Alena_Turner20" },
                    { 50, "519.956.1685 x0897", "Berniece.Ankunding@gmail.com", "Hilll", "$2a$11$F/9i7PtCFYDfPrnht83yp.ECpZZu1K2a8ty1n6ErN1SEX89Xb2WuG", 2, "Kamille6" }
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
