﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperPerros.Context;

namespace SuperPerros.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210106211302_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SuperPerros.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("SuperPerros.Models.PostDetail", b =>
                {
                    b.Property<int>("PostDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("LongDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Race")
                        .HasColumnType("TEXT");

                    b.HasKey("PostDetailId");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("PostDetail");
                });

            modelBuilder.Entity("SuperPerros.Models.PostDetail", b =>
                {
                    b.HasOne("SuperPerros.Models.Post", "Post")
                        .WithOne("PostDetail")
                        .HasForeignKey("SuperPerros.Models.PostDetail", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SuperPerros.Models.Post", b =>
                {
                    b.Navigation("PostDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
