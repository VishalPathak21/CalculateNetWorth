// <auto-generated />
using System;
using CalculateNetWorth9Microservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalculateNetWorth9Microservice.Migrations
{
    [DbContext(typeof(NetWorthContext))]
    partial class NetWorthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.MutualFundDetails", b =>
                {
                    b.Property<int>("MutualFunBuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("MutualFundId")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.HasKey("MutualFunBuyId");

                    b.HasIndex("MutualFundId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("MutualFundDetails");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.MutualFundPriceDetails", b =>
                {
                    b.Property<int>("MutualFundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MutualFundName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MutualFundPrice")
                        .HasColumnType("int");

                    b.HasKey("MutualFundId");

                    b.ToTable("MutualFundPriceDetails");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.PortfolioDetails", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("PortfolioDetails");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.StockDetails", b =>
                {
                    b.Property<int>("StockBuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("StockBuyId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("StockDetails");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.StockPriceDetails", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StockName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StockPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StockId");

                    b.ToTable("StockPriceDetails");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.MutualFundDetails", b =>
                {
                    b.HasOne("CalculateNetworth9Microservice.Models.MutualFundPriceDetails", "MutualFundPriceDetails")
                        .WithMany()
                        .HasForeignKey("MutualFundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalculateNetworth9Microservice.Models.PortfolioDetails", "PortfolioDetails")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MutualFundPriceDetails");

                    b.Navigation("PortfolioDetails");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.PortfolioDetails", b =>
                {
                    b.HasOne("CalculateNetworth9Microservice.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CalculateNetworth9Microservice.Models.StockDetails", b =>
                {
                    b.HasOne("CalculateNetworth9Microservice.Models.PortfolioDetails", "PortfolioDetails")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalculateNetworth9Microservice.Models.StockPriceDetails", "StockPriceDetails")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortfolioDetails");

                    b.Navigation("StockPriceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
