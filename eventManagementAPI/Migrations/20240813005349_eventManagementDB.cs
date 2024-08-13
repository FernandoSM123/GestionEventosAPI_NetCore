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
                    user_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_type_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.user_type_id);
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
                        principalColumn: "user_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user_types",
                columns: new[] { "user_type_id", "user_type_description", "user_type_name" },
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
                    { 1, "1-522-256-9487 x1121", "Filiberto_Wolff@hotmail.com", "McClure", "$2a$11$msISkdlgDRy3D1UM3vsFLuovy6m/izvshqa54PLfSKlDyUMFQD6sa", 1, "Delilah_Russel" },
                    { 2, "823.410.9767 x6457", "Randy_Yost9@gmail.com", "Littel", "$2a$11$z6BBEG7UTd3jpx9w4gG/uOaqroys8fWKaxol7EkdN8qEEN6bPv3wW", 1, "Luciano4" },
                    { 3, "464.689.0674", "Ole_Mayert25@gmail.com", "Erdman", "$2a$11$DdEA/KvC8NmYYnYHA9OEQuHgUL3eGKGL0tzPGDofW4W.KVpVxGBR.", 1, "Dalton.Fritsch2" },
                    { 4, "505.238.8112", "Herta_Becker79@gmail.com", "Wuckert", "$2a$11$YTMoHwXJ/Spf2Q/6acmWFuXRuf/BJN0hEM4hSytCqETkNwr.qX/PS", 1, "Loraine_Spinka" },
                    { 5, "710-486-6657 x9755", "Kadin_Satterfield61@yahoo.com", "Bahringer", "$2a$11$3ZFc/BLILJn4qOpCLWqqZeGDT.nipbXoSuxvOiHceYjoNuQyrVrIK", 2, "Jordy28" },
                    { 6, "555.940.8213", "Clara_Olson40@yahoo.com", "Pollich", "$2a$11$nKzY5BBKPg85Z9aTe.REg.WYCT1r2HzzDms9bb9kcRgGOU3dXmf6a", 2, "Pasquale.Ernser" },
                    { 7, "1-523-744-7418", "Jarvis77@hotmail.com", "Sauer", "$2a$11$oUpZvNJ2equBaNj5dCBGPOQK92jlAGTDY13YjJlyLhdHS22es4Kj.", 2, "Jalon39" },
                    { 8, "1-720-600-7301 x067", "Ali96@hotmail.com", "Ledner", "$2a$11$Uey9Gl9zv2/H4lpq2zPfi.X2MxP9mICYFcQxGWwIqhmy9T89a0rn.", 1, "Lisandro.Metz" },
                    { 9, "463-513-3990", "Yessenia50@yahoo.com", "Rempel", "$2a$11$AX95PBYLTwu7mJ.UTOqBSuNT67QiQZ/yyn7gWtkSILG0c8gSNkoES", 2, "Earnest26" },
                    { 10, "1-513-725-3492 x74871", "Carlie.Hackett@hotmail.com", "Fay", "$2a$11$lUw1x82aYM.hd7dEu0Xnwua8oLThQ9o1uQzqOlWZuHLCFWqbKHp5.", 1, "Tracy_Douglas" },
                    { 11, "1-726-979-3560 x07213", "Mellie_Fadel@yahoo.com", "Shields", "$2a$11$Xw9q4gR.npIusYB2sbxUOOlPUcCaWmkhYOjo3uACWEX0r33jzcOKy", 2, "Lance.Marks" },
                    { 12, "521.480.5617 x412", "America26@gmail.com", "Ondricka", "$2a$11$xQQWoM.6t7b6YDhGOCajg.CMNX6IUcS.Stxd5bVxkW/OG34oxCQEO", 1, "Winifred47" },
                    { 13, "694.519.1085", "Andre_Schultz@yahoo.com", "Wolf", "$2a$11$ejpbqqlw.Ow5B7ljYZZR1u0vu5XSOOuCgI32M9DXt9GEofHXtLyvK", 1, "Maximillia26" },
                    { 14, "422.329.7588 x5792", "Marcella28@gmail.com", "Hayes", "$2a$11$a8Rryh9u.PXPgyaqbnBEXeznpp0XgTIlxY6p22MFrcYIUMhUAt5V6", 2, "Osborne0" },
                    { 15, "211-846-5452", "Roslyn45@gmail.com", "Weissnat", "$2a$11$TV8BIwrD65mGJpJqVYuwy.68JwF6t11qxZJOZoA0h5tsvnXYzMZo.", 1, "Stephanie_Erdman" },
                    { 16, "(270) 871-9190", "Reina.Kohler@yahoo.com", "Predovic", "$2a$11$PtP85s6N7QdTyilGul5zB.Cg5DuxrjqoA5JC8XWpB13JoILQkk/6q", 1, "Julius_Von" },
                    { 17, "851.998.0873", "Sadye60@yahoo.com", "Nader", "$2a$11$Akmx5vjZ5C.ftb.8yDvnDOODgmbKuLj/rglJZRu5sh9az4iH2i1BG", 2, "Lurline95" },
                    { 18, "1-857-495-4855 x7141", "Orrin_Hoeger70@hotmail.com", "Rowe", "$2a$11$biythLrujxYXEpxHK3UY5uZ7q2jrxFS7pw2Ajnc75WmxQUXcYEPKa", 2, "Bernadette85" },
                    { 19, "(525) 914-4598 x856", "Georgiana.Zieme@gmail.com", "Fadel", "$2a$11$KPbKdmQ4dnoV5X1.09h/I.Wk3Zczy.HaI7IJAVwi5k5XHgnKJc/mm", 1, "Amara87" },
                    { 20, "1-528-896-1224 x6684", "Ruben_Metz@yahoo.com", "Lakin", "$2a$11$v3EVVAEu01mLAnACqphAP.9DZe6OVU.h5eCH6kCFo2ldePOpI3KkG", 1, "Bertrand.OReilly99" },
                    { 21, "(467) 241-9390", "Myra.Wintheiser@gmail.com", "Schmitt", "$2a$11$.pm7pBdYIYZh4pg1nTqnNuHS9IdhBSRZVYS9WNMwKMfECxt4fBiWG", 1, "Nola_Hudson74" },
                    { 22, "(240) 689-7845", "Lolita_Predovic28@hotmail.com", "Wolff", "$2a$11$lTcEwSTkBUREIa0.4XTTT.MJusf.dj/WT.e06f0mtjPRIjPyGtA7i", 1, "Keshaun.Terry" },
                    { 23, "606.706.1016 x268", "Megane77@hotmail.com", "Lindgren", "$2a$11$qxDKCE02BnauRYrr0pyTJeYAzEOnKmClKLXAYX4WfkhiCSMh8A.cy", 2, "Lilian.Donnelly77" },
                    { 24, "624-718-6680", "Alec62@hotmail.com", "Bartoletti", "$2a$11$kg1J0gZcxhvO4tDdXc5ZluBOXR7iGR8SyLO47TxytD7cYiaxYYPju", 2, "Abel.Durgan" },
                    { 25, "290.787.4537", "Dameon_Block@hotmail.com", "Bernier", "$2a$11$XDXOcIXp0hJRz3vL1OCQSuDVuvmT7xVi83dh02SwGS10U2v0utpYq", 2, "Meda.Johnston39" },
                    { 26, "(414) 257-4080", "Jamir.Hegmann@hotmail.com", "Erdman", "$2a$11$/wpYCl61BVVEWfIekffKq.FigXM9DCvsXZqrq9CtAXuy6xditCvZO", 2, "Twila.Turner88" },
                    { 27, "(379) 937-2042", "Ozella.OConnell10@hotmail.com", "Rice", "$2a$11$zILoyPTepUJIvRDh/0ofT.UGfEo.HRsQisDdTXwlcEJRvsRMaUqVi", 2, "Julio.Simonis" },
                    { 28, "(883) 791-6852 x74047", "Jermey.Botsford@hotmail.com", "Olson", "$2a$11$CmHmPTsiQOHkMG11o3iPqOA6Hmwly2zPlF.g6sQ4zyEdNCN/f6vyy", 1, "Zelma_Bashirian20" },
                    { 29, "614-713-3601 x6086", "Mya.Franecki@hotmail.com", "Kuhlman", "$2a$11$bkYbAlpm9f3eL79TzzTUxenNUX8qMp7vLtUx1WYFh6D26.A8TC0qG", 2, "Wellington_King" },
                    { 30, "858.215.2932", "Brannon.Abernathy@gmail.com", "Nader", "$2a$11$m6qMiFHCUOzZ6K3DmQIoh.rWK6Xdy2Yxd2RyfgbMImxuHpAC0lL4G", 2, "Ludwig_Crona" },
                    { 31, "(917) 824-2155", "Zack_Rippin9@gmail.com", "Labadie", "$2a$11$CxkV23V0pj.ylz/xH7PliOeOW4yL1YvP4hcyIzegajseeu.lpmdsG", 1, "Nelson.Harvey" },
                    { 32, "341.500.6652", "Alta.Heidenreich70@yahoo.com", "Okuneva", "$2a$11$hA4xZkOFfhlVIwVrrRZcrOXlMsbe6FnU.CpmgZw8e27lA3qll5Cf6", 2, "Lizeth_Miller" },
                    { 33, "1-704-408-3507 x9669", "Tremaine.Denesik@yahoo.com", "Kunze", "$2a$11$/wE1eZ1JO9l9FBdwaCC/LOJxY002meNbWJJAYR3I4MIABSn5M5E02", 1, "Josie_Rempel84" },
                    { 34, "249-706-8458 x37413", "Maxime35@gmail.com", "Metz", "$2a$11$D3o5K9ik8nzf6.UPBIgdlOUsiwpUjrQE.Z.xXt51PGii6pTPbEVUS", 2, "Lukas.Braun0" },
                    { 35, "1-242-892-0326 x3762", "Boyd43@gmail.com", "Koelpin", "$2a$11$MQAiX5exFVdwKTurmHdGP.lOYxXBChzYaCf77mMBxcQFKwZ8GvKuy", 2, "Rhea.Zieme" },
                    { 36, "(870) 414-8033 x77104", "Antonietta67@yahoo.com", "Marks", "$2a$11$B1MeOQ55785PBTl7PkbvledN4FQOnXkVOY/RUze6VRDJYtg1P47Wu", 1, "Hosea.Legros" },
                    { 37, "844-393-7770", "Genesis_Koepp38@hotmail.com", "Johnson", "$2a$11$uYZlqGoCTZIdztzR6xlkFOs1sj8D2Kgchsc7mKWFOeqmboMr3m3oa", 2, "Katrina_Emard5" },
                    { 38, "1-302-487-0810", "Linnie69@yahoo.com", "Labadie", "$2a$11$K147BSi2q0.a/RFl7t03ReMTOHoCTFeDZDOoit9zUBUQbE44aywE2", 1, "Yasmin66" },
                    { 39, "759.304.8182", "Skye.Kreiger@gmail.com", "Hansen", "$2a$11$h7SaBMvyRXh8eJEdDfOwS.L8iUB3ZQCZzEpc.Nq.g/kWGEMLAh3Ya", 1, "Laurine88" },
                    { 40, "275-458-2494 x47206", "Anastacio53@hotmail.com", "Welch", "$2a$11$ZGWFPh1fi/rtG0cxPikXruUkWPmO5n1vGuAcq8TX/puHzvElxINnO", 2, "Austyn_Kreiger" },
                    { 41, "(618) 344-0368 x78461", "Elvis.Schmidt@gmail.com", "Corwin", "$2a$11$frc8XS8aYq.U4pyKSQ5GdeHPFaPDW7SX/Ug4YbzPQE7kbBKynCoXq", 1, "Antonietta.Upton17" },
                    { 42, "300-792-1164", "Anderson73@yahoo.com", "Treutel", "$2a$11$ZOAz0sEgJqTEt0vYgM/Q0eZ6k.gQ6bxgMbKLwrVD73DuOlcBWY46q", 2, "Rosalee41" },
                    { 43, "1-442-792-0314", "Lindsey.Nitzsche17@gmail.com", "Fadel", "$2a$11$jilRusorcd8YhjQIel5Bsuazp4wrjI2P67ODzHSDKS9c45TNjmvrm", 1, "Anya35" },
                    { 44, "573.584.9085", "Kelton21@yahoo.com", "Stanton", "$2a$11$j/mXooKj/ueAfJMxZ4i96uw0BglMzESWBksA0UCd.9o3mOLsrf6.K", 1, "Melody82" },
                    { 45, "675.296.0682 x188", "Stacy88@hotmail.com", "Boyle", "$2a$11$vDIJuyRYJr5H1Hg5bg7zeOgaaaoUidvpJzhkeSL.3jog5lGPa7Hma", 2, "Magdalena.Crist60" },
                    { 46, "1-381-321-8641", "Ezekiel_Koss45@yahoo.com", "Prosacco", "$2a$11$rXXGMGh33ofZ7gd9Bd3P/OS5ce6KsD/ReTqq5kvkhfNWGLIBFSUg.", 2, "Emile.Gulgowski32" },
                    { 47, "770.362.1749", "Clay.Goyette25@gmail.com", "Skiles", "$2a$11$kixwkjzd3mQSJV0ymHpoS.4Vy4Boy9vOg/RbEuDC6JOGC3YsTdtbq", 1, "Emily.Fay" },
                    { 48, "1-240-637-0034", "Erich.Farrell@yahoo.com", "Walker", "$2a$11$LCSEYeU25pHZmcWffq55EOx3GWZp2CtfUzvTP3KcAcO/FMfm9yqVa", 2, "Glenda.Crona" },
                    { 49, "652-904-2947 x0754", "Henry7@yahoo.com", "Pouros", "$2a$11$P5WksmfWa3q4GoLBcKMpYe1a/PxsJDM3sff2Ci1BgGrhN60ZBwDCK", 2, "Kayli42" },
                    { 50, "981-795-1145", "Martina_Schiller0@yahoo.com", "Abernathy", "$2a$11$l9odNoWaJvPX2RqNUGucWeytzvCozMbwUFg5xfPL6w7TEB7aXxfxm", 1, "Raina_Krajcik" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_fk_user_types",
                table: "users",
                column: "fk_user_types");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_types");
        }
    }
}
