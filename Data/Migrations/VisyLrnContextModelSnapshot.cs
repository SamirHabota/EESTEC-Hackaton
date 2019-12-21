﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(VisyLrnContext))]
    partial class VisyLrnContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int>("OrganizationId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("VisyPoints");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OrganizationId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Data.Models.AccountGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId");

                    b.Property<int>("GroupId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GroupId");

                    b.ToTable("AccountGroup");
                });

            modelBuilder.Entity("Data.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("QuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Data.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<DateTime?>("LastShwon");

                    b.Property<int>("LectureId");

                    b.Property<DateTime?>("NextShowMin");

                    b.Property<string>("OriginalAuthorId");

                    b.Property<string>("Question");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("OriginalAuthorId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId");

                    b.Property<int>("PostId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Data.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentPath");

                    b.Property<string>("Extension");

                    b.Property<int>("LectureId");

                    b.Property<string>("OriginalAuthor");

                    b.Property<string>("OriginalAuthorNavigationId");

                    b.Property<string>("Title");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("OriginalAuthorNavigationId");

                    b.HasIndex("TypeId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Data.Models.DocumetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DocumetType");
                });

            modelBuilder.Entity("Data.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatorId");

                    b.Property<string>("CreatorId1");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId1");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Data.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("Number");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("Data.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId");

                    b.Property<int>("GroupId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GroupId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LectureId");

                    b.Property<string>("OriginalAuthorId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Data.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId");

                    b.Property<int?>("Ects");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizationId");

                    b.Property<string>("Professor");

                    b.Property<int?>("SemesterNumber");

                    b.Property<string>("SyllabusPath");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Data.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId");

                    b.Property<DateTime>("BeginDate");

                    b.Property<DateTime>("EndDate");

                    b.Property<double>("TotalScore");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Data.Models.TestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TestId");

                    b.ToTable("TestQuestion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Data.Models.Account", b =>
                {
                    b.HasOne("Data.Models.Organization", "Organization")
                        .WithMany("Account")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.AccountGroup", b =>
                {
                    b.HasOne("Data.Models.Account", "Account")
                        .WithMany("AccountGroup")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Group", "Group")
                        .WithMany("AccountGroup")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Answer", b =>
                {
                    b.HasOne("Data.Models.Question", "Question")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Card", b =>
                {
                    b.HasOne("Data.Models.Lecture", "Lecture")
                        .WithMany("Card")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Account", "OriginalAuthor")
                        .WithMany("Card")
                        .HasForeignKey("OriginalAuthorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Comment", b =>
                {
                    b.HasOne("Data.Models.Account", "Account")
                        .WithMany("Comment")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Post", "Post")
                        .WithMany("Comment")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Document", b =>
                {
                    b.HasOne("Data.Models.Lecture", "Lecture")
                        .WithMany("Document")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Account", "OriginalAuthorNavigation")
                        .WithMany("Document")
                        .HasForeignKey("OriginalAuthorNavigationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.DocumetType", "Type")
                        .WithMany("Document")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Group", b =>
                {
                    b.HasOne("Data.Models.Account", "Creator")
                        .WithMany("Group")
                        .HasForeignKey("CreatorId1")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Lecture", b =>
                {
                    b.HasOne("Data.Models.Subject", "Subject")
                        .WithMany("Lecture")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Post", b =>
                {
                    b.HasOne("Data.Models.Account", "Account")
                        .WithMany("Post")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Group", "Group")
                        .WithMany("Post")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Question", b =>
                {
                    b.HasOne("Data.Models.Lecture", "Lecture")
                        .WithMany("Question")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Subject", b =>
                {
                    b.HasOne("Data.Models.Account", "Account")
                        .WithMany("Subject")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Organization", "Organization")
                        .WithMany("Subject")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.Test", b =>
                {
                    b.HasOne("Data.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Models.TestQuestion", b =>
                {
                    b.HasOne("Data.Models.Question", "Question")
                        .WithMany("TestQuestion")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Test", "Test")
                        .WithMany("TestQuestion")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Models.Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
