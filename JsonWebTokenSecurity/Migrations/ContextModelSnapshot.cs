﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using JsonWebTokenSecurity._DataAccessLayer.Context;

#nullable disable

namespace Web_UI.Migrations
{
    [DbContext(typeof(SQLContext))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_UI._EntityLayer.Concrete.AppRole", b =>
                {
                    b.Property<int>("AppRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppRoleId"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppRoleId");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("Web_UI._EntityLayer.Concrete.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppUserId"));

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppUserId");

                    b.HasIndex("AppRoleId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Web_UI._EntityLayer.Concrete.AppUser", b =>
                {
                    b.HasOne("Web_UI._EntityLayer.Concrete.AppRole", "AppRole")
                        .WithMany("AppUsers")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("Web_UI._EntityLayer.Concrete.AppRole", b =>
                {
                    b.Navigation("AppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
