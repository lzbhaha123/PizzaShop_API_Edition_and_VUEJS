// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaMaker.Data;

#nullable disable

namespace PizzaMaker.Migrations
{
    [DbContext(typeof(PizzaMakerContext))]
    [Migration("20220712031526_pi")]
    partial class pi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("PizzaMaker.Models.Pizza", b =>
                {
                    b.Property<Guid>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaMaker.Models.Topping", b =>
                {
                    b.Property<Guid>("ToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("ToppingId");

                    b.ToTable("Topping");
                });

            modelBuilder.Entity("PizzaMaker.Models.ToppingPizza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PizzaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ToppingId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ToppingSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("ToppingId");

                    b.ToTable("ToppingPizza");
                });

            modelBuilder.Entity("PizzaMaker.Models.ToppingPizza", b =>
                {
                    b.HasOne("PizzaMaker.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaMaker.Models.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });
#pragma warning restore 612, 618
        }
    }
}
