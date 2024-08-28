﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eventManagementAPI.Data;

#nullable disable

namespace eventManagementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240828040224_eventManagementDB")]
    partial class eventManagementDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eventManagementAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_users");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cellphone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("cellphone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<int>("userTypeId")
                        .HasColumnType("int")
                        .HasColumnName("fk_user_types");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("id");

                    b.HasIndex("userTypeId");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            cellphone = "971-467-9434 x154",
                            email = "Piper.Stracke@gmail.com",
                            lastname = "Bode",
                            password = "$2a$11$RQ8YPar4dmE8.8ZhHKoKbe0noU5sYNHh5hI.Lpsdb541AO7XbjAmq",
                            userTypeId = 2,
                            username = "Trudie.Sanford"
                        },
                        new
                        {
                            id = 2,
                            cellphone = "(213) 443-2034",
                            email = "Lawrence_Schimmel9@hotmail.com",
                            lastname = "Rodriguez",
                            password = "$2a$11$WBaCHzdzXaH.fvHVW5tMKuJvsX0m/QxmLjEgJlM6TeChrJm8Pureu",
                            userTypeId = 1,
                            username = "Dean.Goldner63"
                        },
                        new
                        {
                            id = 3,
                            cellphone = "1-575-853-6229 x94969",
                            email = "Minnie.Durgan86@hotmail.com",
                            lastname = "Schuster",
                            password = "$2a$11$TIXQJjP284p0MNA.gJyzD.a6.60rcoC7mhqtyYMrJJHFrxmP4FKQi",
                            userTypeId = 1,
                            username = "Margarett_Denesik"
                        },
                        new
                        {
                            id = 4,
                            cellphone = "1-710-527-9369 x8581",
                            email = "Forrest35@yahoo.com",
                            lastname = "Romaguera",
                            password = "$2a$11$YUoS7dyN4EJMZAClOebJ3u6yAU9gyjJsFZYDViNsL3ylqMfH5BEa6",
                            userTypeId = 1,
                            username = "Faye_Reynolds"
                        },
                        new
                        {
                            id = 5,
                            cellphone = "767-993-9828 x982",
                            email = "Darrick8@hotmail.com",
                            lastname = "Hirthe",
                            password = "$2a$11$ka3snR21UAsPrCV46BMlQee8v91hGF1EJn9lcycgGavsbodeic7BW",
                            userTypeId = 1,
                            username = "Natasha_Lakin"
                        },
                        new
                        {
                            id = 6,
                            cellphone = "(409) 622-1187 x4166",
                            email = "Kameron10@gmail.com",
                            lastname = "Waters",
                            password = "$2a$11$K2nCa9KCvMpy2nCy7vphM.QFaB84G9GXIvAQegSo9IrQq57UcyaLG",
                            userTypeId = 1,
                            username = "Amina.Labadie19"
                        },
                        new
                        {
                            id = 7,
                            cellphone = "1-435-910-5517 x88857",
                            email = "Mavis_Paucek@hotmail.com",
                            lastname = "Lang",
                            password = "$2a$11$F0vD6.9wy.fIhJD4Lq9xjOnUtxjS7Vb9cmWh/Mr9KkUmGydU0EJPG",
                            userTypeId = 2,
                            username = "Darlene_Skiles"
                        },
                        new
                        {
                            id = 8,
                            cellphone = "227.669.6114 x619",
                            email = "Vickie.OKeefe@hotmail.com",
                            lastname = "Metz",
                            password = "$2a$11$ipL8Wanj8nD.jtlpXco65eYFspNB5m8WvU/BL3OibpbJzFAhOEq52",
                            userTypeId = 2,
                            username = "Krystel_Okuneva"
                        },
                        new
                        {
                            id = 9,
                            cellphone = "463-565-3787 x2980",
                            email = "Hope72@yahoo.com",
                            lastname = "Denesik",
                            password = "$2a$11$malVMN7Xr./fXHBPLq8PGungMYrNw/xqbHqdc6QhyrGsIMn5hY/um",
                            userTypeId = 2,
                            username = "Emelia99"
                        },
                        new
                        {
                            id = 10,
                            cellphone = "(329) 483-2404 x1649",
                            email = "Jacey.Kuhn28@hotmail.com",
                            lastname = "Donnelly",
                            password = "$2a$11$QkDJlem/qVrIQQ2mkLUg.euzbkUkS7tpKwNsqtheZS.H4gqhup8Py",
                            userTypeId = 1,
                            username = "Alessandra94"
                        },
                        new
                        {
                            id = 11,
                            cellphone = "(313) 391-2834 x272",
                            email = "Cortney_Stroman17@gmail.com",
                            lastname = "Koepp",
                            password = "$2a$11$szSt95ihPX7VHOugOl1I0eySqp56gYKw0D7cQB0mhADevRPZJHFQG",
                            userTypeId = 1,
                            username = "Louvenia56"
                        },
                        new
                        {
                            id = 12,
                            cellphone = "1-698-401-4258",
                            email = "Gwendolyn.Wisozk@gmail.com",
                            lastname = "Abbott",
                            password = "$2a$11$Iy.AL0CiflSf2ODrs5RcfeaRBkht9iwDLmd5ozDQA1/u1z7KrI5F6",
                            userTypeId = 2,
                            username = "Jo93"
                        },
                        new
                        {
                            id = 13,
                            cellphone = "659.767.1621 x065",
                            email = "Jerel60@gmail.com",
                            lastname = "Morar",
                            password = "$2a$11$EwOOKiXvzP9PSi4p/lYkoub/dIAE.m/AAanm1kUVADnljzgqRlL/m",
                            userTypeId = 1,
                            username = "Tara16"
                        },
                        new
                        {
                            id = 14,
                            cellphone = "306-458-6776",
                            email = "Joanie.Murray@hotmail.com",
                            lastname = "Stiedemann",
                            password = "$2a$11$EgvmgwbMvLjB/omJEVrsKu4wmwyNVW/sHWfnmi/BJpE51l43kTiwy",
                            userTypeId = 2,
                            username = "Eric.Hilll"
                        },
                        new
                        {
                            id = 15,
                            cellphone = "347.518.8918 x233",
                            email = "Olga.Boyer34@gmail.com",
                            lastname = "Barrows",
                            password = "$2a$11$d5nt24GmQW/6jfXo3ABeA.gUUobr8HKsqMnWBp.Dd1qJ65qjb7d06",
                            userTypeId = 1,
                            username = "Emmie.Jones"
                        },
                        new
                        {
                            id = 16,
                            cellphone = "(374) 700-3745",
                            email = "Edward_Miller@gmail.com",
                            lastname = "Spencer",
                            password = "$2a$11$xHcfH71AkImzgKkHP6kgTukU/yi3XiLFIkCxErrxQj9jgQC/txloC",
                            userTypeId = 2,
                            username = "Kris20"
                        },
                        new
                        {
                            id = 17,
                            cellphone = "327.944.6221 x62361",
                            email = "Deangelo_Hickle70@gmail.com",
                            lastname = "Kerluke",
                            password = "$2a$11$3Gr0vr8I.5SLfGpkw2osZ.YBcXgBxVFKah6bPFZsF8QrUiLJMiIni",
                            userTypeId = 1,
                            username = "Darrick.Koepp88"
                        },
                        new
                        {
                            id = 18,
                            cellphone = "208-527-9704 x035",
                            email = "Loyal_Kuhn56@gmail.com",
                            lastname = "Weber",
                            password = "$2a$11$z9emXImpSERpFw/AtyVKFuvebEd.hQ1hKgYnyDbvEkoxOGxB6AcTy",
                            userTypeId = 1,
                            username = "Theo_Keeling"
                        },
                        new
                        {
                            id = 19,
                            cellphone = "616.286.3806 x696",
                            email = "Aletha.Kuhn@gmail.com",
                            lastname = "Hills",
                            password = "$2a$11$/nwqGqe5yCJznUIyIz7ILesGOGIiDdnB45HC4x3ZbsWna2PsBgneu",
                            userTypeId = 1,
                            username = "Winston_Larkin68"
                        },
                        new
                        {
                            id = 20,
                            cellphone = "(253) 329-5080",
                            email = "Helga10@gmail.com",
                            lastname = "Steuber",
                            password = "$2a$11$RsOwA0pEwkIWUWcwWrnU8.KAS6NpwRAShxROnYJTj3afhDJORDxVG",
                            userTypeId = 2,
                            username = "Novella97"
                        },
                        new
                        {
                            id = 21,
                            cellphone = "854.727.7612 x1244",
                            email = "Bryon.Hudson@yahoo.com",
                            lastname = "Labadie",
                            password = "$2a$11$Sou2U/8qA7tktrMRAovmouqVeTkau6KiwFuKLrnQ4oUwt8kRiinoC",
                            userTypeId = 2,
                            username = "Joanne.Barrows8"
                        },
                        new
                        {
                            id = 22,
                            cellphone = "634-910-5859 x075",
                            email = "Janae62@hotmail.com",
                            lastname = "Fadel",
                            password = "$2a$11$4sOExTMMVdEQ.sFrB8QdnefEFJFBFLPrMFPcfX7PqKopSBo9l6V5K",
                            userTypeId = 1,
                            username = "Maureen_Nicolas82"
                        },
                        new
                        {
                            id = 23,
                            cellphone = "891.275.3851 x271",
                            email = "Jermain_Hackett3@yahoo.com",
                            lastname = "Sporer",
                            password = "$2a$11$uyG20qq5WaXj52rAGmpGb.l9ls5We9aGjbLCUCXB3v8cIyYyqCqde",
                            userTypeId = 1,
                            username = "Pearline.Collins"
                        },
                        new
                        {
                            id = 24,
                            cellphone = "333.655.8803 x4726",
                            email = "Alta.Marvin@gmail.com",
                            lastname = "Mills",
                            password = "$2a$11$WTRk.O5oPEHayUMIlxJoseUHD9dkKRhqDrWv4EQH0ksM6S7YJ72QO",
                            userTypeId = 2,
                            username = "Casimir44"
                        },
                        new
                        {
                            id = 25,
                            cellphone = "1-232-804-3617",
                            email = "Vanessa_Feest48@yahoo.com",
                            lastname = "Mosciski",
                            password = "$2a$11$HQNFUGypP1mCdMyM/h7a..q/M5YGy7sQzFJig/w/Jvpf8ppNsnW8K",
                            userTypeId = 1,
                            username = "Art.Schultz8"
                        },
                        new
                        {
                            id = 26,
                            cellphone = "962.767.5894 x30035",
                            email = "Furman.Aufderhar@hotmail.com",
                            lastname = "Renner",
                            password = "$2a$11$oyAzSSbniUuDmHD2Xnz5muEarMwCI/.gazTZGwHVC8njk1JsODri6",
                            userTypeId = 2,
                            username = "Americo_Keebler74"
                        },
                        new
                        {
                            id = 27,
                            cellphone = "729-933-6159 x75973",
                            email = "Fay75@yahoo.com",
                            lastname = "Weber",
                            password = "$2a$11$76hWV3ldhRhMa1w.6kS4iOHibW458R9On6R9w5iSvFHc2yIy6qiei",
                            userTypeId = 2,
                            username = "Jade86"
                        },
                        new
                        {
                            id = 28,
                            cellphone = "714-913-1952 x6387",
                            email = "Lon_Gerlach84@hotmail.com",
                            lastname = "Crooks",
                            password = "$2a$11$Vaqg90Xr9r096Fbjwca8XOG3Fce7ITttiIAJmgcoHiNXNZ2kE8BU2",
                            userTypeId = 1,
                            username = "Hal88"
                        },
                        new
                        {
                            id = 29,
                            cellphone = "775-271-8133 x64338",
                            email = "Rachelle_Simonis58@yahoo.com",
                            lastname = "Volkman",
                            password = "$2a$11$cgVLGCwxbHJbnrAAz6TnzO7FreXb218c/0NtvSGaVLZolpjL12i16",
                            userTypeId = 2,
                            username = "Ashlee_Graham"
                        },
                        new
                        {
                            id = 30,
                            cellphone = "(407) 585-6178 x280",
                            email = "Adolph_Dooley@hotmail.com",
                            lastname = "Zemlak",
                            password = "$2a$11$iGTL9WvSCpVvda2MM.ttNuzxYSBI8qIq.lU8LGahr9EPfKO6Yppoq",
                            userTypeId = 2,
                            username = "Fredy.Predovic84"
                        },
                        new
                        {
                            id = 31,
                            cellphone = "1-938-323-6686 x10439",
                            email = "Caterina.Lynch87@hotmail.com",
                            lastname = "Cartwright",
                            password = "$2a$11$YWYgDa600dxBazMM4Q6jseV0Abre3Cgcg63aMgx1Zx2Habmi8eUWa",
                            userTypeId = 1,
                            username = "Amber_Lehner"
                        },
                        new
                        {
                            id = 32,
                            cellphone = "723-672-4149 x49566",
                            email = "Joesph.Nienow38@hotmail.com",
                            lastname = "Wehner",
                            password = "$2a$11$2XaO0AxUXPXXnlzZhoW22uD9HLBeuee2agiPxsuthRkp0MhEQgm02",
                            userTypeId = 2,
                            username = "Obie.Gottlieb"
                        },
                        new
                        {
                            id = 33,
                            cellphone = "(210) 231-8832 x551",
                            email = "Jayce40@hotmail.com",
                            lastname = "Kunze",
                            password = "$2a$11$81f.fpsE8KBdyYEM6njru..D9vJ95fsRpFEajEREBiwE6nJsFG28m",
                            userTypeId = 1,
                            username = "Audrey99"
                        },
                        new
                        {
                            id = 34,
                            cellphone = "717-279-4697 x54407",
                            email = "Angus.Hartmann44@hotmail.com",
                            lastname = "Roberts",
                            password = "$2a$11$aMINsnji5dQAOmhG1BGmse0gKWEa.9VzcjMt810B86Rrifg1I3Sdi",
                            userTypeId = 2,
                            username = "Abigail_Mohr89"
                        },
                        new
                        {
                            id = 35,
                            cellphone = "865.568.8491",
                            email = "Meagan.Predovic@hotmail.com",
                            lastname = "Beer",
                            password = "$2a$11$bAqaIK8pYDdd9NtNDsoJrO7rOqavgUV6aDB/5iCJYlX1t3D0pkzpa",
                            userTypeId = 2,
                            username = "Timmothy.Wilkinson96"
                        },
                        new
                        {
                            id = 36,
                            cellphone = "873-772-1945 x2998",
                            email = "Lula74@gmail.com",
                            lastname = "Paucek",
                            password = "$2a$11$K6dWyBwCW03yXSbU9P68dOIAM2X/Aun.ms7veYDXv69SQ.huvSLPK",
                            userTypeId = 1,
                            username = "Otilia.Christiansen22"
                        },
                        new
                        {
                            id = 37,
                            cellphone = "1-464-679-6389 x765",
                            email = "Ruth_Hagenes@gmail.com",
                            lastname = "Kuhic",
                            password = "$2a$11$dS4R0Ys1JDc/lKWuvT9rqOqhEmOEOwZ7PLcFw57G5OR/g8hZkMILu",
                            userTypeId = 1,
                            username = "Kaci58"
                        },
                        new
                        {
                            id = 38,
                            cellphone = "706.284.4732",
                            email = "Alice33@yahoo.com",
                            lastname = "Hamill",
                            password = "$2a$11$JL8C4cV.XB1NrgGaQVUaU.XXkPUI6YtunYj9nQ0Hu.ACQf6fH1Yx.",
                            userTypeId = 2,
                            username = "Rey64"
                        },
                        new
                        {
                            id = 39,
                            cellphone = "780-679-4768 x52872",
                            email = "Nora15@yahoo.com",
                            lastname = "Effertz",
                            password = "$2a$11$KVkErIlYemhCi6M0fP72FufH0ap0IeslqC1pWVqdQ21sErQE.0k9W",
                            userTypeId = 2,
                            username = "Raymond.Ziemann41"
                        },
                        new
                        {
                            id = 40,
                            cellphone = "(977) 233-8825",
                            email = "Rubye_Legros@yahoo.com",
                            lastname = "Gutmann",
                            password = "$2a$11$Iw/7vchl8vu1Sp9TT.V4Nefy/esMmFJinAMTt8Yqhd.WtfjRgwCZi",
                            userTypeId = 2,
                            username = "Jaylen.Pouros"
                        },
                        new
                        {
                            id = 41,
                            cellphone = "966-929-8464",
                            email = "Tillman.Hand22@hotmail.com",
                            lastname = "Hilpert",
                            password = "$2a$11$poYUY0lviMuwK.Ssri4pT.D5wd3D6RQFEeafo9KE7YJTvnEZqdi1q",
                            userTypeId = 1,
                            username = "Eudora.Emmerich12"
                        },
                        new
                        {
                            id = 42,
                            cellphone = "249.422.0321 x054",
                            email = "Bettye11@gmail.com",
                            lastname = "Romaguera",
                            password = "$2a$11$lL2yT5dO345uEATuxWklNekDEjbip..MZ28Oo4hsOCtNui2eJcOr.",
                            userTypeId = 1,
                            username = "Walker_Bins"
                        },
                        new
                        {
                            id = 43,
                            cellphone = "979-278-3419 x22247",
                            email = "Alford_Abbott94@hotmail.com",
                            lastname = "Welch",
                            password = "$2a$11$yzskJGcktd1JPIrkdSZ8jONk8zAeHGfpkzK.JOBzuLD531ZsjEZcq",
                            userTypeId = 2,
                            username = "Giovanna.Lemke"
                        },
                        new
                        {
                            id = 44,
                            cellphone = "1-495-576-0853 x9706",
                            email = "Orrin_White74@hotmail.com",
                            lastname = "Durgan",
                            password = "$2a$11$cC.QFFSIF0Z2dfZo0Gw3nuahg.3uBf2122ZTO.57UH6LMXeDSK5HG",
                            userTypeId = 1,
                            username = "Israel_McCullough60"
                        },
                        new
                        {
                            id = 45,
                            cellphone = "628.895.7280",
                            email = "Miguel47@gmail.com",
                            lastname = "Heaney",
                            password = "$2a$11$9GceYGi1E8iC9wHLeM5B0Oxz.3RvHpHgj1sYJiLeLI/PV77IYA1Xe",
                            userTypeId = 2,
                            username = "Darius64"
                        },
                        new
                        {
                            id = 46,
                            cellphone = "1-230-624-1739 x15746",
                            email = "Randall.Barton96@hotmail.com",
                            lastname = "Beatty",
                            password = "$2a$11$/83MjJfPPSA4k6LwDOATW.VMJ7dD2wRyGzQkNQALsdn095BViFGFm",
                            userTypeId = 2,
                            username = "Rylee74"
                        },
                        new
                        {
                            id = 47,
                            cellphone = "(329) 464-4851",
                            email = "Dimitri_Rogahn81@gmail.com",
                            lastname = "King",
                            password = "$2a$11$6mYwac6ebFYohqHbwXTd9OHG0IVbwdn6APKlCwao2WTQ38lbTnOdi",
                            userTypeId = 2,
                            username = "Ellie.Hodkiewicz"
                        },
                        new
                        {
                            id = 48,
                            cellphone = "(692) 559-9742 x0751",
                            email = "Preston.Keebler28@gmail.com",
                            lastname = "Ratke",
                            password = "$2a$11$IMjq0aGYNIpJCbIqhgUXpeb9ONdKAAstS6621E3G/daH4TZntR37y",
                            userTypeId = 1,
                            username = "Koby_Schneider"
                        },
                        new
                        {
                            id = 49,
                            cellphone = "258.248.7519",
                            email = "Clay.Kuhn@hotmail.com",
                            lastname = "Wiegand",
                            password = "$2a$11$DxQhCINOKOx0a0qYSZ.13OKE91KJZwBNnCYBalT7HuQuVnMYbkZrS",
                            userTypeId = 2,
                            username = "Myron.Lowe"
                        },
                        new
                        {
                            id = 50,
                            cellphone = "(618) 269-2461 x9009",
                            email = "Hermann.Ziemann8@gmail.com",
                            lastname = "Bode",
                            password = "$2a$11$/WVSD/3aM06anWib.zRsDeqvZqzQDGW1auIaiYHyvEp6fND3ucWkC",
                            userTypeId = 2,
                            username = "Lavada.Zemlak72"
                        });
                });

            modelBuilder.Entity("eventManagementAPI.Models.UserType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_user_types");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_type_description");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_type_name");

                    b.HasKey("id");

                    b.ToTable("user_types", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "User with full administrative rights",
                            name = "Administrator"
                        },
                        new
                        {
                            id = 2,
                            description = "User with read-only access",
                            name = "Viewer"
                        });
                });

            modelBuilder.Entity("eventManagementAPI.Models.User", b =>
                {
                    b.HasOne("eventManagementAPI.Models.UserType", "userType")
                        .WithMany("users")
                        .HasForeignKey("userTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userType");
                });

            modelBuilder.Entity("eventManagementAPI.Models.UserType", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
