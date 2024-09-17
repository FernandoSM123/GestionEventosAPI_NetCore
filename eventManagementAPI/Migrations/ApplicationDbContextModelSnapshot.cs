﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eventManagementAPI.Data;

#nullable disable

namespace eventManagementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eventManagementAPI.Models.Canton", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_cantons");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("canton_name");

                    b.Property<int>("provinceId")
                        .HasColumnType("int")
                        .HasColumnName("fk_provinces");

                    b.HasKey("id");

                    b.HasIndex("provinceId");

                    b.ToTable("Cantons", (string)null);
                });

            modelBuilder.Entity("eventManagementAPI.Models.District", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_districts");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantonId")
                        .HasColumnType("int")
                        .HasColumnName("fk_cantons");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("district_name");

                    b.HasKey("id");

                    b.HasIndex("cantonId");

                    b.ToTable("Districts", (string)null);
                });

            modelBuilder.Entity("eventManagementAPI.Models.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_events");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantonId")
                        .HasColumnType("int")
                        .HasColumnName("fk_cantons");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("event_description");

                    b.Property<string>("details")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("event_details");

                    b.Property<int>("districtId")
                        .HasColumnType("int")
                        .HasColumnName("fk_districts");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<string>("exactPlace")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("exact_place");

                    b.Property<TimeSpan>("finishingTime")
                        .HasColumnType("time")
                        .HasColumnName("finishing_time");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("event_name");

                    b.Property<int>("provinceId")
                        .HasColumnType("int")
                        .HasColumnName("fk_provinces");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<TimeSpan>("startingTime")
                        .HasColumnType("time")
                        .HasColumnName("starting_time");

                    b.HasKey("id");

                    b.HasIndex("cantonId");

                    b.HasIndex("districtId");

                    b.HasIndex("provinceId");

                    b.ToTable("Events", (string)null);
                });

            modelBuilder.Entity("eventManagementAPI.Models.Province", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_provinces");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("province_name");

                    b.HasKey("id");

                    b.ToTable("Provinces", (string)null);
                });

            modelBuilder.Entity("eventManagementAPI.Models.Token", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_tokens");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("expiration")
                        .HasColumnType("datetime2")
                        .HasColumnName("expiration");

                    b.Property<bool>("isRevoked")
                        .HasColumnType("bit")
                        .HasColumnName("is_revoked");

                    b.Property<string>("jwtToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("jwt_token");

                    b.Property<int>("userId")
                        .HasColumnType("int")
                        .HasColumnName("fk_users");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("tokens", (string)null);
                });

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
                });

            modelBuilder.Entity("eventManagementAPI.Models.Canton", b =>
                {
                    b.HasOne("eventManagementAPI.Models.Province", "province")
                        .WithMany("cantons")
                        .HasForeignKey("provinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("province");
                });

            modelBuilder.Entity("eventManagementAPI.Models.District", b =>
                {
                    b.HasOne("eventManagementAPI.Models.Canton", "canton")
                        .WithMany("districts")
                        .HasForeignKey("cantonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("canton");
                });

            modelBuilder.Entity("eventManagementAPI.Models.Event", b =>
                {
                    b.HasOne("eventManagementAPI.Models.Canton", "canton")
                        .WithMany("events")
                        .HasForeignKey("cantonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("eventManagementAPI.Models.District", "district")
                        .WithMany("events")
                        .HasForeignKey("districtId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("eventManagementAPI.Models.Province", "province")
                        .WithMany("events")
                        .HasForeignKey("provinceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("canton");

                    b.Navigation("district");

                    b.Navigation("province");
                });

            modelBuilder.Entity("eventManagementAPI.Models.Token", b =>
                {
                    b.HasOne("eventManagementAPI.Models.User", "user")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
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

            modelBuilder.Entity("eventManagementAPI.Models.Canton", b =>
                {
                    b.Navigation("districts");

                    b.Navigation("events");
                });

            modelBuilder.Entity("eventManagementAPI.Models.District", b =>
                {
                    b.Navigation("events");
                });

            modelBuilder.Entity("eventManagementAPI.Models.Province", b =>
                {
                    b.Navigation("cantons");

                    b.Navigation("events");
                });

            modelBuilder.Entity("eventManagementAPI.Models.User", b =>
                {
                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("eventManagementAPI.Models.UserType", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
