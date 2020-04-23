﻿// <auto-generated />
using System;
using FINAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FINAL.Migrations
{
    [DbContext(typeof(PropDbContext))]
    [Migration("20200422084701_CreatedPropertyProjectTable")]
    partial class CreatedPropertyProjectTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FINAL.Models.AddType", b =>
                {
                    b.Property<int>("AddTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AddTypeId");

                    b.ToTable("AddTypes");
                });

            modelBuilder.Entity("FINAL.Models.Addvertisiment", b =>
                {
                    b.Property<int>("AddvertisimentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddStatus")
                        .HasColumnType("int");

                    b.Property<int>("AddTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("date");

                    b.Property<decimal>("PropPrice")
                        .HasColumnType("money");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddvertisimentID");

                    b.HasIndex("AddTypeID");

                    b.HasIndex("PropertyID");

                    b.HasIndex("UserId");

                    b.ToTable("Addvertisiments");
                });

            modelBuilder.Entity("FINAL.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FINAL.Models.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("DistrictId");

                    b.HasIndex("CityID");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("FINAL.Models.Feature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("FeatureID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("FINAL.Models.Flat", b =>
                {
                    b.Property<int>("FlatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlatID");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("FINAL.Models.Floor", b =>
                {
                    b.Property<int>("FloorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FloorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FloorID");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("FINAL.Models.PropDoc", b =>
                {
                    b.Property<int>("PropDocID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PropDocName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PropDocID");

                    b.ToTable("PropDocs");
                });

            modelBuilder.Entity("FINAL.Models.PropFeature", b =>
                {
                    b.Property<int>("PropFeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.HasKey("PropFeatureID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("PropertyID");

                    b.ToTable("PropFeatures");
                });

            modelBuilder.Entity("FINAL.Models.PropPhoto", b =>
                {
                    b.Property<int>("PropPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PropPhotoName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("PropPhotoId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropPhotos");
                });

            modelBuilder.Entity("FINAL.Models.PropProject", b =>
                {
                    b.Property<int>("PropProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PropProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PropProjectID");

                    b.ToTable("PropProjects");
                });

            modelBuilder.Entity("FINAL.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BuildingVolume")
                        .HasColumnType("money");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int?>("FlatId")
                        .HasColumnType("int");

                    b.Property<int?>("FloorId")
                        .HasColumnType("int");

                    b.Property<int?>("FloorSum")
                        .HasColumnType("int");

                    b.Property<string>("FullAbout")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasMaxLength(500);

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<decimal>("LandVolume")
                        .HasColumnType("money");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("MainPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PropDocId")
                        .HasColumnType("int");

                    b.Property<int?>("PropProjectId")
                        .HasColumnType("int");

                    b.Property<int>("PropertySortId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("FlatId");

                    b.HasIndex("FloorId");

                    b.HasIndex("PropDocId");

                    b.HasIndex("PropProjectId");

                    b.HasIndex("PropertySortId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("FINAL.Models.PropertySort", b =>
                {
                    b.Property<int>("PropertySortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataFilter")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PropertySortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("PropertySortId");

                    b.ToTable("PropertySorts");
                });

            modelBuilder.Entity("FINAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutCompany")
                        .HasColumnType("ntext");

                    b.Property<string>("Adress")
                        .HasColumnType("ntext")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FINAL.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("FINAL.Models.WebsiteSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FacebookAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FooterLogo")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LinkedinAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LocalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MainLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("TwitterAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("WebsiteSettings");
                });

            modelBuilder.Entity("FINAL.Models.Addvertisiment", b =>
                {
                    b.HasOne("FINAL.Models.AddType", "AddType")
                        .WithMany("Adds")
                        .HasForeignKey("AddTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FINAL.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FINAL.Models.User", "User")
                        .WithMany("Adds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FINAL.Models.District", b =>
                {
                    b.HasOne("FINAL.Models.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FINAL.Models.PropFeature", b =>
                {
                    b.HasOne("FINAL.Models.Feature", "Feature")
                        .WithMany("PropFeatures")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FINAL.Models.Property", "Property")
                        .WithMany("PropFeatures")
                        .HasForeignKey("PropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FINAL.Models.PropPhoto", b =>
                {
                    b.HasOne("FINAL.Models.Property", "Property")
                        .WithMany("Photos")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FINAL.Models.Property", b =>
                {
                    b.HasOne("FINAL.Models.City", "City")
                        .WithMany("Properties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FINAL.Models.District", "District")
                        .WithMany("Properties")
                        .HasForeignKey("DistrictId");

                    b.HasOne("FINAL.Models.Flat", "Flat")
                        .WithMany("Properties")
                        .HasForeignKey("FlatId");

                    b.HasOne("FINAL.Models.Floor", "Floor")
                        .WithMany("Properties")
                        .HasForeignKey("FloorId");

                    b.HasOne("FINAL.Models.PropDoc", "PropDoc")
                        .WithMany("Properties")
                        .HasForeignKey("PropDocId");

                    b.HasOne("FINAL.Models.PropProject", "Project")
                        .WithMany("Properties")
                        .HasForeignKey("PropProjectId");

                    b.HasOne("FINAL.Models.PropertySort", "PropertySort")
                        .WithMany("Properties")
                        .HasForeignKey("PropertySortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FINAL.Models.User", b =>
                {
                    b.HasOne("FINAL.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
