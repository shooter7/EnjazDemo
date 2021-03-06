﻿// <auto-generated />
using System;
using EnjazDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EnjazDemo.Migrations
{
    [DbContext(typeof(EnjazDemoContext))]
    partial class EnjazDemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EnjazDemo.Models.Attachment", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("attachmentUrl");

                    b.Property<string>("carArabicChar");

                    b.Property<string>("carEnglishChar");

                    b.Property<string>("carNumber");

                    b.Property<string>("drivingLicenseNumber");

                    b.Property<string>("fileUrl");

                    b.Property<string>("fullName");

                    b.Property<string>("nationIdentity");

                    b.HasKey("Guid");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("EnjazDemo.Models.UserModel", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Role");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("Guid");

                    b.ToTable("UserModels");
                });
#pragma warning restore 612, 618
        }
    }
}
