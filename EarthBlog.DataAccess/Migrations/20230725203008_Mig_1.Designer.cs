﻿// <auto-generated />
using EarthBlog.DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EarthBlog.DataAccess.Migrations
{
    [DbContext(typeof(EarthBlogContext))]
    [Migration("20230725203008_Mig_1")]
    partial class Mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EarthBlog.Entities.Concrete.AppSeo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppSeoCode")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<string>("Home")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDinamicPage")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsStaticPage")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("AppSeos");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderBy")
                        .HasColumnType("int");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("UrlCode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.AppSeoLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppSeoId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<string>("Keyword")
                        .HasColumnType("longtext");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppSeoId");

                    b.ToTable("AppSeoLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.BlogLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("SubTitle2")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.CategoryLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.SliderLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<int>("SliderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SliderId");

                    b.ToTable("SliderLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GuId")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.AppSeoLanguage", b =>
                {
                    b.HasOne("EarthBlog.Entities.Concrete.AppSeo", "AppSeo")
                        .WithMany("AppSeoLanguages")
                        .HasForeignKey("AppSeoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppSeo");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.BlogLanguage", b =>
                {
                    b.HasOne("EarthBlog.Entities.Concrete.Blog", "Blog")
                        .WithMany("BlogLanguages")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.CategoryLanguage", b =>
                {
                    b.HasOne("EarthBlog.Entities.Concrete.Category", "Category")
                        .WithMany("CategoryLanguages")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Languages.SliderLanguage", b =>
                {
                    b.HasOne("EarthBlog.Entities.Concrete.Slider", "Slider")
                        .WithMany("SliderLanguages")
                        .HasForeignKey("SliderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slider");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.AppSeo", b =>
                {
                    b.Navigation("AppSeoLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Blog", b =>
                {
                    b.Navigation("BlogLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Category", b =>
                {
                    b.Navigation("CategoryLanguages");
                });

            modelBuilder.Entity("EarthBlog.Entities.Concrete.Slider", b =>
                {
                    b.Navigation("SliderLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
