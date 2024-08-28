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
                    { 1, "971-467-9434 x154", "Piper.Stracke@gmail.com", "Bode", "$2a$11$RQ8YPar4dmE8.8ZhHKoKbe0noU5sYNHh5hI.Lpsdb541AO7XbjAmq", 2, "Trudie.Sanford" },
                    { 2, "(213) 443-2034", "Lawrence_Schimmel9@hotmail.com", "Rodriguez", "$2a$11$WBaCHzdzXaH.fvHVW5tMKuJvsX0m/QxmLjEgJlM6TeChrJm8Pureu", 1, "Dean.Goldner63" },
                    { 3, "1-575-853-6229 x94969", "Minnie.Durgan86@hotmail.com", "Schuster", "$2a$11$TIXQJjP284p0MNA.gJyzD.a6.60rcoC7mhqtyYMrJJHFrxmP4FKQi", 1, "Margarett_Denesik" },
                    { 4, "1-710-527-9369 x8581", "Forrest35@yahoo.com", "Romaguera", "$2a$11$YUoS7dyN4EJMZAClOebJ3u6yAU9gyjJsFZYDViNsL3ylqMfH5BEa6", 1, "Faye_Reynolds" },
                    { 5, "767-993-9828 x982", "Darrick8@hotmail.com", "Hirthe", "$2a$11$ka3snR21UAsPrCV46BMlQee8v91hGF1EJn9lcycgGavsbodeic7BW", 1, "Natasha_Lakin" },
                    { 6, "(409) 622-1187 x4166", "Kameron10@gmail.com", "Waters", "$2a$11$K2nCa9KCvMpy2nCy7vphM.QFaB84G9GXIvAQegSo9IrQq57UcyaLG", 1, "Amina.Labadie19" },
                    { 7, "1-435-910-5517 x88857", "Mavis_Paucek@hotmail.com", "Lang", "$2a$11$F0vD6.9wy.fIhJD4Lq9xjOnUtxjS7Vb9cmWh/Mr9KkUmGydU0EJPG", 2, "Darlene_Skiles" },
                    { 8, "227.669.6114 x619", "Vickie.OKeefe@hotmail.com", "Metz", "$2a$11$ipL8Wanj8nD.jtlpXco65eYFspNB5m8WvU/BL3OibpbJzFAhOEq52", 2, "Krystel_Okuneva" },
                    { 9, "463-565-3787 x2980", "Hope72@yahoo.com", "Denesik", "$2a$11$malVMN7Xr./fXHBPLq8PGungMYrNw/xqbHqdc6QhyrGsIMn5hY/um", 2, "Emelia99" },
                    { 10, "(329) 483-2404 x1649", "Jacey.Kuhn28@hotmail.com", "Donnelly", "$2a$11$QkDJlem/qVrIQQ2mkLUg.euzbkUkS7tpKwNsqtheZS.H4gqhup8Py", 1, "Alessandra94" },
                    { 11, "(313) 391-2834 x272", "Cortney_Stroman17@gmail.com", "Koepp", "$2a$11$szSt95ihPX7VHOugOl1I0eySqp56gYKw0D7cQB0mhADevRPZJHFQG", 1, "Louvenia56" },
                    { 12, "1-698-401-4258", "Gwendolyn.Wisozk@gmail.com", "Abbott", "$2a$11$Iy.AL0CiflSf2ODrs5RcfeaRBkht9iwDLmd5ozDQA1/u1z7KrI5F6", 2, "Jo93" },
                    { 13, "659.767.1621 x065", "Jerel60@gmail.com", "Morar", "$2a$11$EwOOKiXvzP9PSi4p/lYkoub/dIAE.m/AAanm1kUVADnljzgqRlL/m", 1, "Tara16" },
                    { 14, "306-458-6776", "Joanie.Murray@hotmail.com", "Stiedemann", "$2a$11$EgvmgwbMvLjB/omJEVrsKu4wmwyNVW/sHWfnmi/BJpE51l43kTiwy", 2, "Eric.Hilll" },
                    { 15, "347.518.8918 x233", "Olga.Boyer34@gmail.com", "Barrows", "$2a$11$d5nt24GmQW/6jfXo3ABeA.gUUobr8HKsqMnWBp.Dd1qJ65qjb7d06", 1, "Emmie.Jones" },
                    { 16, "(374) 700-3745", "Edward_Miller@gmail.com", "Spencer", "$2a$11$xHcfH71AkImzgKkHP6kgTukU/yi3XiLFIkCxErrxQj9jgQC/txloC", 2, "Kris20" },
                    { 17, "327.944.6221 x62361", "Deangelo_Hickle70@gmail.com", "Kerluke", "$2a$11$3Gr0vr8I.5SLfGpkw2osZ.YBcXgBxVFKah6bPFZsF8QrUiLJMiIni", 1, "Darrick.Koepp88" },
                    { 18, "208-527-9704 x035", "Loyal_Kuhn56@gmail.com", "Weber", "$2a$11$z9emXImpSERpFw/AtyVKFuvebEd.hQ1hKgYnyDbvEkoxOGxB6AcTy", 1, "Theo_Keeling" },
                    { 19, "616.286.3806 x696", "Aletha.Kuhn@gmail.com", "Hills", "$2a$11$/nwqGqe5yCJznUIyIz7ILesGOGIiDdnB45HC4x3ZbsWna2PsBgneu", 1, "Winston_Larkin68" },
                    { 20, "(253) 329-5080", "Helga10@gmail.com", "Steuber", "$2a$11$RsOwA0pEwkIWUWcwWrnU8.KAS6NpwRAShxROnYJTj3afhDJORDxVG", 2, "Novella97" },
                    { 21, "854.727.7612 x1244", "Bryon.Hudson@yahoo.com", "Labadie", "$2a$11$Sou2U/8qA7tktrMRAovmouqVeTkau6KiwFuKLrnQ4oUwt8kRiinoC", 2, "Joanne.Barrows8" },
                    { 22, "634-910-5859 x075", "Janae62@hotmail.com", "Fadel", "$2a$11$4sOExTMMVdEQ.sFrB8QdnefEFJFBFLPrMFPcfX7PqKopSBo9l6V5K", 1, "Maureen_Nicolas82" },
                    { 23, "891.275.3851 x271", "Jermain_Hackett3@yahoo.com", "Sporer", "$2a$11$uyG20qq5WaXj52rAGmpGb.l9ls5We9aGjbLCUCXB3v8cIyYyqCqde", 1, "Pearline.Collins" },
                    { 24, "333.655.8803 x4726", "Alta.Marvin@gmail.com", "Mills", "$2a$11$WTRk.O5oPEHayUMIlxJoseUHD9dkKRhqDrWv4EQH0ksM6S7YJ72QO", 2, "Casimir44" },
                    { 25, "1-232-804-3617", "Vanessa_Feest48@yahoo.com", "Mosciski", "$2a$11$HQNFUGypP1mCdMyM/h7a..q/M5YGy7sQzFJig/w/Jvpf8ppNsnW8K", 1, "Art.Schultz8" },
                    { 26, "962.767.5894 x30035", "Furman.Aufderhar@hotmail.com", "Renner", "$2a$11$oyAzSSbniUuDmHD2Xnz5muEarMwCI/.gazTZGwHVC8njk1JsODri6", 2, "Americo_Keebler74" },
                    { 27, "729-933-6159 x75973", "Fay75@yahoo.com", "Weber", "$2a$11$76hWV3ldhRhMa1w.6kS4iOHibW458R9On6R9w5iSvFHc2yIy6qiei", 2, "Jade86" },
                    { 28, "714-913-1952 x6387", "Lon_Gerlach84@hotmail.com", "Crooks", "$2a$11$Vaqg90Xr9r096Fbjwca8XOG3Fce7ITttiIAJmgcoHiNXNZ2kE8BU2", 1, "Hal88" },
                    { 29, "775-271-8133 x64338", "Rachelle_Simonis58@yahoo.com", "Volkman", "$2a$11$cgVLGCwxbHJbnrAAz6TnzO7FreXb218c/0NtvSGaVLZolpjL12i16", 2, "Ashlee_Graham" },
                    { 30, "(407) 585-6178 x280", "Adolph_Dooley@hotmail.com", "Zemlak", "$2a$11$iGTL9WvSCpVvda2MM.ttNuzxYSBI8qIq.lU8LGahr9EPfKO6Yppoq", 2, "Fredy.Predovic84" },
                    { 31, "1-938-323-6686 x10439", "Caterina.Lynch87@hotmail.com", "Cartwright", "$2a$11$YWYgDa600dxBazMM4Q6jseV0Abre3Cgcg63aMgx1Zx2Habmi8eUWa", 1, "Amber_Lehner" },
                    { 32, "723-672-4149 x49566", "Joesph.Nienow38@hotmail.com", "Wehner", "$2a$11$2XaO0AxUXPXXnlzZhoW22uD9HLBeuee2agiPxsuthRkp0MhEQgm02", 2, "Obie.Gottlieb" },
                    { 33, "(210) 231-8832 x551", "Jayce40@hotmail.com", "Kunze", "$2a$11$81f.fpsE8KBdyYEM6njru..D9vJ95fsRpFEajEREBiwE6nJsFG28m", 1, "Audrey99" },
                    { 34, "717-279-4697 x54407", "Angus.Hartmann44@hotmail.com", "Roberts", "$2a$11$aMINsnji5dQAOmhG1BGmse0gKWEa.9VzcjMt810B86Rrifg1I3Sdi", 2, "Abigail_Mohr89" },
                    { 35, "865.568.8491", "Meagan.Predovic@hotmail.com", "Beer", "$2a$11$bAqaIK8pYDdd9NtNDsoJrO7rOqavgUV6aDB/5iCJYlX1t3D0pkzpa", 2, "Timmothy.Wilkinson96" },
                    { 36, "873-772-1945 x2998", "Lula74@gmail.com", "Paucek", "$2a$11$K6dWyBwCW03yXSbU9P68dOIAM2X/Aun.ms7veYDXv69SQ.huvSLPK", 1, "Otilia.Christiansen22" },
                    { 37, "1-464-679-6389 x765", "Ruth_Hagenes@gmail.com", "Kuhic", "$2a$11$dS4R0Ys1JDc/lKWuvT9rqOqhEmOEOwZ7PLcFw57G5OR/g8hZkMILu", 1, "Kaci58" },
                    { 38, "706.284.4732", "Alice33@yahoo.com", "Hamill", "$2a$11$JL8C4cV.XB1NrgGaQVUaU.XXkPUI6YtunYj9nQ0Hu.ACQf6fH1Yx.", 2, "Rey64" },
                    { 39, "780-679-4768 x52872", "Nora15@yahoo.com", "Effertz", "$2a$11$KVkErIlYemhCi6M0fP72FufH0ap0IeslqC1pWVqdQ21sErQE.0k9W", 2, "Raymond.Ziemann41" },
                    { 40, "(977) 233-8825", "Rubye_Legros@yahoo.com", "Gutmann", "$2a$11$Iw/7vchl8vu1Sp9TT.V4Nefy/esMmFJinAMTt8Yqhd.WtfjRgwCZi", 2, "Jaylen.Pouros" },
                    { 41, "966-929-8464", "Tillman.Hand22@hotmail.com", "Hilpert", "$2a$11$poYUY0lviMuwK.Ssri4pT.D5wd3D6RQFEeafo9KE7YJTvnEZqdi1q", 1, "Eudora.Emmerich12" },
                    { 42, "249.422.0321 x054", "Bettye11@gmail.com", "Romaguera", "$2a$11$lL2yT5dO345uEATuxWklNekDEjbip..MZ28Oo4hsOCtNui2eJcOr.", 1, "Walker_Bins" },
                    { 43, "979-278-3419 x22247", "Alford_Abbott94@hotmail.com", "Welch", "$2a$11$yzskJGcktd1JPIrkdSZ8jONk8zAeHGfpkzK.JOBzuLD531ZsjEZcq", 2, "Giovanna.Lemke" },
                    { 44, "1-495-576-0853 x9706", "Orrin_White74@hotmail.com", "Durgan", "$2a$11$cC.QFFSIF0Z2dfZo0Gw3nuahg.3uBf2122ZTO.57UH6LMXeDSK5HG", 1, "Israel_McCullough60" },
                    { 45, "628.895.7280", "Miguel47@gmail.com", "Heaney", "$2a$11$9GceYGi1E8iC9wHLeM5B0Oxz.3RvHpHgj1sYJiLeLI/PV77IYA1Xe", 2, "Darius64" },
                    { 46, "1-230-624-1739 x15746", "Randall.Barton96@hotmail.com", "Beatty", "$2a$11$/83MjJfPPSA4k6LwDOATW.VMJ7dD2wRyGzQkNQALsdn095BViFGFm", 2, "Rylee74" },
                    { 47, "(329) 464-4851", "Dimitri_Rogahn81@gmail.com", "King", "$2a$11$6mYwac6ebFYohqHbwXTd9OHG0IVbwdn6APKlCwao2WTQ38lbTnOdi", 2, "Ellie.Hodkiewicz" },
                    { 48, "(692) 559-9742 x0751", "Preston.Keebler28@gmail.com", "Ratke", "$2a$11$IMjq0aGYNIpJCbIqhgUXpeb9ONdKAAstS6621E3G/daH4TZntR37y", 1, "Koby_Schneider" },
                    { 49, "258.248.7519", "Clay.Kuhn@hotmail.com", "Wiegand", "$2a$11$DxQhCINOKOx0a0qYSZ.13OKE91KJZwBNnCYBalT7HuQuVnMYbkZrS", 2, "Myron.Lowe" },
                    { 50, "(618) 269-2461 x9009", "Hermann.Ziemann8@gmail.com", "Bode", "$2a$11$/WVSD/3aM06anWib.zRsDeqvZqzQDGW1auIaiYHyvEp6fND3ucWkC", 2, "Lavada.Zemlak72" }
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
