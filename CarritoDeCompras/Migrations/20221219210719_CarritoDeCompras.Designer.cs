// <auto-generated />
using System;
using CarritoDeCompras.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarritoDeCompras.Migrations
{
    [DbContext(typeof(DbContextCarrito))]
    [Migration("20221219210719_CarritoDeCompras")]
    partial class CarritoDeCompras
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarritoDeCompras.Models.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("totalDescuento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("idUsuario");

                    b.ToTable("Carrito", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("CarritoDeCompras.Models.FechaPromocional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FechaPromocional", (string)null);
                });

            modelBuilder.Entity("CarritoDeCompras.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarritoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarritoId");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("CarritoDeCompras.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vip")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("CarritoDeCompras.Models.CarroPromocional", b =>
                {
                    b.HasBaseType("CarritoDeCompras.Models.Carrito");

                    b.ToTable("CarroPromocional", (string)null);
                });

            modelBuilder.Entity("CarritoDeCompras.Models.CarroVip", b =>
                {
                    b.HasBaseType("CarritoDeCompras.Models.Carrito");

                    b.ToTable("CarroVip", (string)null);
                });

            modelBuilder.Entity("CarritoDeCompras.Models.Carrito", b =>
                {
                    b.HasOne("CarritoDeCompras.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CarritoDeCompras.Models.Producto", b =>
                {
                    b.HasOne("CarritoDeCompras.Models.Carrito", null)
                        .WithMany("Productos")
                        .HasForeignKey("CarritoId");
                });

            modelBuilder.Entity("CarritoDeCompras.Models.CarroPromocional", b =>
                {
                    b.HasOne("CarritoDeCompras.Models.Carrito", null)
                        .WithOne()
                        .HasForeignKey("CarritoDeCompras.Models.CarroPromocional", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarritoDeCompras.Models.CarroVip", b =>
                {
                    b.HasOne("CarritoDeCompras.Models.Carrito", null)
                        .WithOne()
                        .HasForeignKey("CarritoDeCompras.Models.CarroVip", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarritoDeCompras.Models.Carrito", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
