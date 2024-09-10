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
                name: "tokens",
                columns: table => new
                {
                    pk_tokens = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jwt_token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_revoked = table.Column<bool>(type: "bit", nullable: false),
                    fk_users = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.pk_tokens);
                    table.ForeignKey(
                        name: "FK_tokens_users_fk_users",
                        column: x => x.fk_users,
                        principalTable: "users",
                        principalColumn: "pk_users",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "562.264.2742 x544", "Keira.Nicolas84@gmail.com", "Legros", "$2a$11$yNrfGQzhbVqeK6zQonrgl.tWvCFtikIMhqKI7y15aftS7bQX1/Q6G", 1, "Lucas36" },
                    { 2, "448-442-9521", "Hailee.OConnell18@yahoo.com", "Herzog", "$2a$11$uzc5xMAdXdGyAKxnFk07u.T/E4V/gFIqeq8QwZF9CtC/cw338yrtW", 1, "Ethyl44" },
                    { 3, "450-357-4059 x030", "Baron.Connelly0@gmail.com", "Stanton", "$2a$11$NI.vrK.U4qiVRIKYH0HaYOlMN1zFPWlB0vl4Hhf2vkukODhucyOv6", 2, "Allene8" },
                    { 4, "968-665-7658", "Curtis.Reichel2@gmail.com", "Botsford", "$2a$11$a0V1rWi5lgUFa2/DfrPF6eb9fq8OLCsnx25TfR7Oq61iX52/C17ZW", 1, "Abby_Oberbrunner75" },
                    { 5, "378-357-8910 x055", "Lesley_Rath14@gmail.com", "Kulas", "$2a$11$RKOHWrwpHeCvoqa18p2iBut0tbZ6vWIwzajhJOJ11ppCW2nb0jTHm", 1, "Clarabelle_Murray" },
                    { 6, "759.980.8957", "Jadyn13@yahoo.com", "Gleichner", "$2a$11$y4Rschu8GHQyFf.T94Q9P.GZKXZmPRuYprd3hH0doYcmnpbp2o60e", 2, "Major_Hammes" },
                    { 7, "(942) 505-8234 x9374", "Izaiah.Heidenreich@yahoo.com", "Conn", "$2a$11$wO.l3qjQpj1v5jtc3xkAbuR3YIi3uiTGhTdSc8YiqWGDyQ8K58106", 1, "Jessie80" },
                    { 8, "343.357.7542 x779", "Therese61@hotmail.com", "Monahan", "$2a$11$S.KWeypuCqlJO5pUpCK2m.4wmX.3GOLUqPW8nAWlNQ4ruSY2yyv8q", 1, "Lavon_Schowalter32" },
                    { 9, "1-544-882-1230", "Roberta.Schroeder80@hotmail.com", "Skiles", "$2a$11$AeDpcs279/vt3PFKjYtL0u.f1TnPfttfxZzRD/OyTlRFAl5Cbu77q", 2, "Marge.Hansen73" },
                    { 10, "418.296.9745", "Guiseppe6@yahoo.com", "Champlin", "$2a$11$PbjHcUoh7/HZK/ZHkPfpweDmudarI.kFa6rPhXd/WEoqgqS9PGrH2", 2, "Janie.Howe34" },
                    { 11, "1-814-387-4321 x798", "Marisol49@hotmail.com", "Larson", "$2a$11$4BtTkB..xAnXkHiitusgJuLGTs90XZI7YewQU3tR21DNDpJxXdVEC", 1, "Toy.Osinski" },
                    { 12, "863-866-9267 x66199", "Mabel.Stoltenberg@hotmail.com", "Wilderman", "$2a$11$UVHxUcqXgsB0KBy7HH9VNeqYUN.M7/6VEXpUPPHa1AXNJKZTByB7i", 2, "Nellie.Kuhn" },
                    { 13, "(445) 360-4561 x8402", "Benton.Hilpert68@hotmail.com", "Feest", "$2a$11$1Eq.OB0Ig/DKrRai8k2Apu/HPPw9KSDH7ERA4uTSqGP2EebRYNE/C", 2, "Vicenta_Trantow94" },
                    { 14, "779-337-8428 x781", "Ona54@gmail.com", "Mertz", "$2a$11$Ou88NLFT5RBYmzl0ImrcxO818ep6iFix3JQiSknc3aYqh7FUHy64G", 1, "Shanna8" },
                    { 15, "1-254-905-5443 x81123", "Al18@gmail.com", "Ziemann", "$2a$11$0bUsPJHO7TBMNzWy0PtD3uYiqr5B/FR3eh6yOnF6JB2DF7T3Q4PQC", 1, "Marian.Lindgren" },
                    { 16, "690-372-8123", "Enola.Langosh40@hotmail.com", "King", "$2a$11$glCDryekWUP7qp5p/a2FEua/7PwcZJZVqInsDI15jg8b9ayDdjsQ6", 1, "Lempi_Price" },
                    { 17, "458.297.7981 x80095", "Kennedi74@yahoo.com", "Schuppe", "$2a$11$5x.HrDlSl5Od9tjzl3DMLePLFszMXkIt0ekn4nYcQ61bo/mXvzsmq", 2, "Ozella51" },
                    { 18, "570-781-0290", "Dylan_Wuckert8@hotmail.com", "Parisian", "$2a$11$v6AdgYriw3DM756E1/rPbOGHRT6e8twAnHnxd6aPZ5PwjvMfg/PaO", 2, "Tina51" },
                    { 19, "(489) 207-6122 x13188", "Mikayla79@hotmail.com", "Auer", "$2a$11$DursMF74O6zN1uz1b8WDt.pGi.pgSCPMiEXCeKlpyXAPjG3UwSYgi", 2, "Celine80" },
                    { 20, "(849) 352-5296 x33093", "Beth.Walker33@gmail.com", "Cummerata", "$2a$11$4m9koawdzhclrOM/ic4z6uZyOEmmzT73jS1gD/.cINOBaqGUrBBrO", 2, "Libby_Bernhard12" },
                    { 21, "1-867-460-4764", "Citlalli.Cormier@hotmail.com", "Breitenberg", "$2a$11$fUMR7obktZ1OoYXW7.1/gOmKl1f35m4jWxPouGiDzXOhbxKcdqjuS", 2, "Gilberto7" },
                    { 22, "474-590-8290 x3442", "Cordie9@yahoo.com", "Bruen", "$2a$11$AxHGum272pmmIKdiWdgBkeNgqy347mBbm5iciZfe651bvdEXSxBIe", 2, "Consuelo29" },
                    { 23, "426.508.0614 x102", "Charles52@gmail.com", "Lubowitz", "$2a$11$eDAr6XScOLAUVjVCKhN8EeoCKhReDtKElQ7Zg1hjvEmw1/qL.1psW", 1, "Elda1" },
                    { 24, "837-972-4259 x76252", "Rahul.Mraz@yahoo.com", "Jacobson", "$2a$11$5JNTcboI6A3VrqhZQwYjVuuPYfZntciJgkGQDBnfygRtPBCmPkU3S", 1, "Stanton.Dooley16" },
                    { 25, "738.508.8176 x4781", "Reese_Schultz6@hotmail.com", "Boyle", "$2a$11$SEZP20KybWCUtMt6XqLO3OORAUcx0RlkMgTqDLwUSBPQMvNKx/csi", 1, "Wiley86" },
                    { 26, "1-538-467-4961", "Elwyn.Sawayn72@gmail.com", "Hyatt", "$2a$11$nHHfQWsomS2JWcsN9W61JO.O8FkWBJyrggLolp8wNiXAmE1iVzhqS", 1, "Germaine_Mayer" },
                    { 27, "(688) 576-5530", "Lawson70@hotmail.com", "Wisozk", "$2a$11$Ymd0eDKWCZHcArBJ.V6muesqsOYI5V7rOSOb4lc6gcgMIivHMne0y", 2, "Doyle.Rutherford" },
                    { 28, "778.590.7520 x710", "Lexie.Feeney@yahoo.com", "Renner", "$2a$11$9sppO.oNNhqnSz5ojsoJp.3Cc5HKfCElAjI7Xq9QxKpBiRPCWU61G", 1, "Paolo56" },
                    { 29, "529-386-6617", "Leslie_Quigley@yahoo.com", "McLaughlin", "$2a$11$ErMQcmdthKU692ZkXKuYo.F8umUDwuQ.hhm3BvXJnTrntN0xLAIJC", 2, "Alessia81" },
                    { 30, "1-771-938-9146", "Fanny_Daniel17@yahoo.com", "Ernser", "$2a$11$NoijU92UrgkdW1po7C7NP.9OPZ4Nv.nhccdcBVYWk8F5DQIBcSaqe", 2, "Frederic_Connelly74" },
                    { 31, "892.414.4094 x058", "Ron58@yahoo.com", "Borer", "$2a$11$kwmD3VJ3oR/ZuwyjkZr/HeBdZceHxrv4APJILb64JZPfV8VeEW7Xa", 1, "Kade_Lehner" },
                    { 32, "701.618.8356 x3380", "Kayli.White@gmail.com", "Schinner", "$2a$11$RFE7eQc0RzTYtm/eBD2OA.5mGaBKzfrBCu4HY7Hwghc4zBcJCkOIO", 1, "Jesse_Purdy" },
                    { 33, "628.947.2594 x970", "Aurelio.Braun16@yahoo.com", "Heller", "$2a$11$nw3WyU3UjurZ7ujNVqLEmuuyBHduhY2CNvZG.OjnziQXH80dmUkbC", 2, "Kaylin_Lakin" },
                    { 34, "1-356-988-1828", "Rollin_Cummings69@gmail.com", "Tremblay", "$2a$11$H7XkK/lcITerudiiMji8veEZ08MBXwg2/gmJs0WwmNCZX8fDxejnO", 2, "Tamara_Lindgren" },
                    { 35, "738-637-3062", "Peggie20@gmail.com", "Konopelski", "$2a$11$cL/RWbWb9QcZcweFsRJ4cOPRPAajCtsI1FV6X/SR6FkMVsBK49AoG", 2, "Aurelia.Wehner89" },
                    { 36, "1-939-409-7572 x8211", "Zane78@hotmail.com", "Dickinson", "$2a$11$0pZTQ2uRSudfMqZknz31XO/YVZR3zi9C7pFRxczAO3zR5FJGUn5xm", 2, "Aric95" },
                    { 37, "711-459-1259 x850", "Dorothy71@gmail.com", "Hilpert", "$2a$11$dvV3XNxY7frcTBd7WNlcq.xwyJ8monwhdkXc6M23pb74iocu2rKiy", 2, "Hillary87" },
                    { 38, "282.911.3114 x183", "Melyna_Kuvalis@hotmail.com", "Fadel", "$2a$11$ctAFsweSQJnR58BQZdNrYeZ8Z7ZuQZ9j7xkJwUiSyS27oFf9BLBUS", 1, "Doris_Halvorson" },
                    { 39, "519.747.4805 x47266", "Yvette_Schneider2@yahoo.com", "Lemke", "$2a$11$R1S0HAB5tly4f4RW5CnpBuiHa1Peibfk3iDWeoOBC0X7M7hvlbM7q", 2, "Zackary90" },
                    { 40, "(954) 652-4950 x570", "Loyce.VonRueden81@hotmail.com", "Koch", "$2a$11$moyTsqhkQU3sANLSCkQlhufTrDsqSMXultSSEkxYV7pf3TgdX7tny", 2, "Kristian_Dietrich51" },
                    { 41, "317-864-9733", "Gordon26@hotmail.com", "Ryan", "$2a$11$7Aj.KNvUS8PUc9xdzblam.NU1oIAKe5n.ZxTLeId76BDFAVtgmCxG", 2, "Phyllis.Cormier" },
                    { 42, "(430) 833-1364 x0240", "Juliana_Casper32@gmail.com", "Smitham", "$2a$11$EqdOtXA1nuWakZBglKFMxOolpZAYlq7B9B48NknO30asPB2r1PpDy", 2, "Burnice12" },
                    { 43, "1-498-976-8188", "Zander46@hotmail.com", "Jast", "$2a$11$qshdz8gpqP7E/VOHD0WFR.pBvy95DyG.yoa4/Y5I0tXipanQ9xlmi", 2, "Lori.Bahringer33" },
                    { 44, "432-629-9908 x4290", "Sabryna30@gmail.com", "Powlowski", "$2a$11$Fr3mIZOe5ZnOAiS2BaWphOed/xzZdSe4NS8CrXwDKK38Sqk9TnXG6", 2, "Maxine.Jenkins" },
                    { 45, "1-266-565-6194 x29250", "Joyce_Feest11@yahoo.com", "Bartoletti", "$2a$11$RCovUEr4Pn6AnIGhfmb2KOVUUoDDWaKOoOU6LFBMyOSt1pC9koo6O", 1, "Norene18" },
                    { 46, "551-608-9905 x4136", "Webster.Haley@yahoo.com", "Bashirian", "$2a$11$qknjSF7DRpOdbFE30GaqPeOp.PoeYAr9E3ewLBFSf07.0GBLlLWBS", 1, "Alia.Stehr" },
                    { 47, "768-948-9352", "Nels.Jenkins@gmail.com", "Kub", "$2a$11$crdNA264wfdSvYWqwhFxruka4TA1B.5QF9bUJBfXILgpfhzaVlBdS", 1, "Lue.Lowe" },
                    { 48, "1-363-486-4712", "Isabell.Hermiston67@gmail.com", "Koch", "$2a$11$TdgUIPtZdOcjuoSFuqt.beMl.lilc7TmilQNkwrTM16w.htskfise", 2, "Beryl.Lemke99" },
                    { 49, "1-865-447-6597", "Ellis_Mayert@gmail.com", "Larson", "$2a$11$/IC7Oqb8b2.VqTkKMlvLzOnsMqfQR3JQjZUrfIBuI8LNbQPiDxLDy", 1, "Vida_Rosenbaum" },
                    { 50, "1-489-557-0122 x722", "Luciano21@yahoo.com", "Monahan", "$2a$11$USjY5jzsHlq/xZdCNT8.pOackLbRFX1p5cjuuvxblXTdZmoCfUeJO", 1, "Nannie40" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tokens_fk_users",
                table: "tokens",
                column: "fk_users");

            migrationBuilder.CreateIndex(
                name: "IX_users_fk_user_types",
                table: "users",
                column: "fk_user_types");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_types");
        }
    }
}
