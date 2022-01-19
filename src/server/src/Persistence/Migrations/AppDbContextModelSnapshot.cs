﻿// <auto-generated />
using System;
using GitNode.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GitNode.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GitNode.Domain.Entities.AccountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text")
                        .HasColumnName("avatar_url");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("OriginId")
                        .HasColumnType("text")
                        .HasColumnName("origin_id");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer")
                        .HasColumnName("platform_id");

                    b.Property<string>("Token")
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("PlatformId")
                        .HasDatabaseName("ix_accounts_platform_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_accounts_user_id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.PlatformEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_platforms");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_platforms_name");

                    b.ToTable("platforms");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.RepoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<int>("OriginId")
                        .HasColumnType("integer")
                        .HasColumnName("origin_id");

                    b.Property<bool>("Private")
                        .HasColumnType("boolean")
                        .HasColumnName("private");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_repos");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_repos_account_id");

                    b.HasIndex("Name", "AccountId")
                        .IsUnique()
                        .HasDatabaseName("ix_repos_name_account_id");

                    b.ToTable("repos");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("character varying(65)")
                        .HasColumnName("email");

                    b.Property<string>("GivenName")
                        .HasColumnType("text")
                        .HasColumnName("given_name");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.AccountEntity", b =>
                {
                    b.HasOne("GitNode.Domain.Entities.PlatformEntity", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .HasConstraintName("fk_accounts_platforms_platform_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitNode.Domain.Entities.UserEntity", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_accounts_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.RepoEntity", b =>
                {
                    b.HasOne("GitNode.Domain.Entities.AccountEntity", "Account")
                        .WithMany("Repository")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_repos_accounts_account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.AccountEntity", b =>
                {
                    b.Navigation("Repository");
                });

            modelBuilder.Entity("GitNode.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
