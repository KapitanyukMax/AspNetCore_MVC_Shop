﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cars & Transport"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pets"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Home & Garden"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fashion"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hobbies & Sport"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Musical Instruments"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Art"
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Description = "Excellent condition as new\nPassed the test for 30 points for workability\nThere is a warranty for the device from the store up to 2 years",
                            Discount = 33.299999999999997,
                            ImagePath = "https://www.reliancedigital.in/medias/Apple-MLPF3HN-A-Smart-Phone-491997699-i-1-1200Wx1200H?context=bWFzdGVyfGltYWdlc3wyNTU5NTZ8aW1hZ2UvanBlZ3xpbWFnZXMvaDU5L2hlOC85ODc4MDkwMDg4NDc4LmpwZ3wxNGQzODYyZWJiYjYwZDVjZjNhM2Q5YzQ4ZmE5OTljMmZiYmM2MDE0ZjE1YzhhMTRmYjM2ZDkzZGEyODcxNTU2",
                            Name = "iPhone 13 256GB",
                            Price = 25610.200000000001,
                            Rating = 6,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Discount = 0.0,
                            ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/dddvh1ibzptb-UA/image",
                            Name = "2020 Volvo S60",
                            Price = 473027.70000000001,
                            Rating = 8,
                            Status = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 7,
                            Description = "Great synthesizer professional line YAMAHA PSR E-343!\nPerfect condition!\nBoth adults and children can easily master the user-friendly control interface. This is a tool in which the design is organically combined with the necessary functionality",
                            Discount = 0.0,
                            ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/utm4vzs67i893-UA/image",
                            Name = "Synthesizer Yamaha PSR E-343",
                            Price = 7900.0,
                            Rating = 6,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "A great printer that is suitable for both office and home use.\nThe printer allows you to print color photos and black and white text, as well as scan images. It has energy-saving functions, in particular sleep mode and auto-off mode",
                            Discount = 10.0,
                            ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/66wfny594cwu3-UA/image",
                            Name = "Printer HP DeskJet 2300",
                            Price = 2000.0,
                            Rating = 5,
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Discount = 0.0,
                            ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/w80mjaevar2s-UA/image",
                            Name = "Sofa",
                            Price = 10830.0,
                            Rating = 7,
                            Status = 0
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Item", b =>
                {
                    b.HasOne("DataAccess.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataAccess.Entities.Category", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
