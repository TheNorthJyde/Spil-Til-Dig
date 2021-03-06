// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spil_Til_Dig.Backend.Database;

namespace Spil_Til_Dig.Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenreProduct", b =>
                {
                    b.Property<long>("GenresId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductsId")
                        .HasColumnType("bigint");

                    b.HasKey("GenresId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("GenreProduct");
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.Genre", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Developer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Publicher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.ProduktKey", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IsSold");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("GenreProduct", b =>
                {
                    b.HasOne("Spil_Til_Dig.Shared.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spil_Til_Dig.Shared.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.ProduktKey", b =>
                {
                    b.HasOne("Spil_Til_Dig.Shared.Entities.Order", null)
                        .WithMany("Keys")
                        .HasForeignKey("OrderId");

                    b.HasOne("Spil_Til_Dig.Shared.Entities.Product", "Product")
                        .WithMany("Keys")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.Order", b =>
                {
                    b.Navigation("Keys");
                });

            modelBuilder.Entity("Spil_Til_Dig.Shared.Entities.Product", b =>
                {
                    b.Navigation("Keys");
                });
#pragma warning restore 612, 618
        }
    }
}
