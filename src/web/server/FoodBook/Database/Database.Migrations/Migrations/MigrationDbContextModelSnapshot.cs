﻿// <auto-generated />
using System;
using FoodBook.Database.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodBook.Database.Migrations.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    partial class MigrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("FoodBook.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EntityId");

                    b.Property<int>("RatingNumber");

                    b.HasKey("Id")
                        .HasName("RatingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("FoodBook.Domain.Entities.Recipes.Recipe", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("RecipeId");

                    b.HasIndex("CreatedById");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodBook.Domain.Entities.Recipes.RecipeStep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<Guid>("RecipeId");

                    b.Property<int>("StepNumber");

                    b.HasKey("Id")
                        .HasName("RecipeStepId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("FoodBook.Domain.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<string>("SecurityStamp")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasName("UserAccountId");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("Login");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("FoodBook.Domain.Entities.Recipes.Recipe", b =>
                {
                    b.HasOne("FoodBook.Domain.Entities.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodBook.Domain.Entities.Rating", "Rating")
                        .WithOne()
                        .HasForeignKey("FoodBook.Domain.Entities.Recipes.Recipe", "Id")
                        .HasPrincipalKey("FoodBook.Domain.Entities.Rating", "EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FoodBook.Domain.Entities.Recipes.RecipeStep", b =>
                {
                    b.HasOne("FoodBook.Domain.Entities.Recipes.Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
