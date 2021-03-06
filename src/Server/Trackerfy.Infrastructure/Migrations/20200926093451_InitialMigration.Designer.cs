// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trackerfy.Infrastructure;
using Trackerfy.Infrastructure.Persistence;

namespace Trackerfy.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200926093451_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trackerfy.Domain.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IssueStateId")
                        .HasColumnType("int");

                    b.Property<int>("IssueTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueStateId");

                    b.HasIndex("IssueTypeId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("Trackerfy.Domain.Entities.IssueState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IssueState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "To Do"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Completed"
                        });
                });

            modelBuilder.Entity("Trackerfy.Domain.Entities.IssueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IssueType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Story"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bug"
                        });
                });

            modelBuilder.Entity("Trackerfy.Domain.Entities.Issue", b =>
                {
                    b.HasOne("Trackerfy.Domain.Entities.IssueState", "IssueState")
                        .WithMany()
                        .HasForeignKey("IssueStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trackerfy.Domain.Entities.IssueType", "IssueType")
                        .WithMany()
                        .HasForeignKey("IssueTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
