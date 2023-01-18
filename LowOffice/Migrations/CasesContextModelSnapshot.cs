﻿// <auto-generated />
using LowOffice.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LowOffice.Migrations
{
    [DbContext(typeof(CasesContext))]
    partial class CasesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("LowOffice.db.Cases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hall")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastone")
                        .HasColumnType("TEXT");

                    b.Property<string>("attribute")
                        .HasColumnType("TEXT");

                    b.Property<string>("caseDecision")
                        .HasColumnType("TEXT");

                    b.Property<string>("caseNum")
                        .HasColumnType("TEXT");

                    b.Property<string>("circleNum")
                        .HasColumnType("TEXT");

                    b.Property<string>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("dateOflast")
                        .HasColumnType("TEXT");

                    b.Property<string>("describtion")
                        .HasColumnType("TEXT");

                    b.Property<string>("oppenentName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
