﻿// <auto-generated />
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
    [Migration("20220712011950_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("PizzaMaker.Models.Topping", b =>
                {
                    b.Property<Guid>("ToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ToppingId");

                    b.ToTable("Topping");
                });
#pragma warning restore 612, 618
        }
    }
}
