﻿// <auto-generated />
using System;
using MMSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMSystem.Migrations
{
    [DbContext(typeof(AppDbCon))]
    [Migration("20210724200625_Mail_inbox1")]
    partial class Mail_inbox1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMSystem.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPhotos")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfMail")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MMSystem.Model.External_Mail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<int>("Sectionid")
                        .HasColumnType("int");

                    b.Property<string>("action_Requierd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MailID")
                        .IsUnique();

                    b.HasIndex("Sectionid");

                    b.ToTable("External_Mails");
                });

            modelBuilder.Entity("MMSystem.Model.Extrenal_inbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Send_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("action_Requierd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("section_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("to")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MailID")
                        .IsUnique();

                    b.HasIndex("SectionId");

                    b.ToTable("Extrenal_Inboxes");
                });

            modelBuilder.Entity("MMSystem.Model.Extrmal_Section", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Section_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number_of_mail")
                        .HasColumnType("int");

                    b.Property<int>("perent")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Extrmal_Section");
                });

            modelBuilder.Entity("MMSystem.Model.Mail", b =>
                {
                    b.Property<int>("MailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action_Required")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Of_Mail")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genaral_inbox_Number")
                        .HasColumnType("int");

                    b.Property<int>("Genaral_inbox_year")
                        .HasColumnType("int");

                    b.Property<string>("Mail_Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Management_Id")
                        .HasColumnType("int");

                    b.Property<int>("Message_Number")
                        .HasColumnType("int");

                    b.Property<string>("classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("currentYear")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("MailID");

                    b.HasIndex("userId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("MMSystem.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstMACAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecandMACAddress")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MMSystem.Model.External_Mail", b =>
                {
                    b.HasOne("MMSystem.Model.Mail", "Mail")
                        .WithOne("external_Mail")
                        .HasForeignKey("MMSystem.Model.External_Mail", "MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MMSystem.Model.Extrmal_Section", "Section")
                        .WithMany("External_Mails")
                        .HasForeignKey("Sectionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MMSystem.Model.Extrenal_inbox", b =>
                {
                    b.HasOne("MMSystem.Model.Mail", "Mail")
                        .WithOne("extrenal_Inbox")
                        .HasForeignKey("MMSystem.Model.Extrenal_inbox", "MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MMSystem.Model.Extrmal_Section", "Section")
                        .WithMany("Extrenal_Inboxes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MMSystem.Model.Mail", b =>
                {
                    b.HasOne("MMSystem.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MMSystem.Model.User", b =>
                {
                    b.HasOne("MMSystem.Model.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MMSystem.Model.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MMSystem.Model.Extrmal_Section", b =>
                {
                    b.Navigation("External_Mails");

                    b.Navigation("Extrenal_Inboxes");
                });

            modelBuilder.Entity("MMSystem.Model.Mail", b =>
                {
                    b.Navigation("external_Mail");

                    b.Navigation("extrenal_Inbox");
                });
#pragma warning restore 612, 618
        }
    }
}