﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sirius.Domain.Entity;

#nullable disable

namespace Sirius.Domain.Migrations
{
    [DbContext(typeof(SiriusContext))]
    [Migration("20240225183755_ChangeDescriptionPaymentTable")]
    partial class ChangeDescriptionPaymentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sirius.Domain.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("category_pkey");

                    b.HasIndex(new[] { "Name" }, "category_name_key")
                        .IsUnique();

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Sirius.Domain.Entity.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<int?>("PayDay")
                        .HasColumnType("integer")
                        .HasColumnName("pay_day");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("payment_pkey");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Name" }, "payment_name_key")
                        .IsUnique();

                    b.ToTable("payment", (string)null);
                });

            modelBuilder.Entity("Sirius.Domain.Entity.Register", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uuid")
                        .HasColumnName("payment_id");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("register_pkey");

                    b.HasIndex("PaymentId");

                    b.ToTable("register", (string)null);
                });

            modelBuilder.Entity("Sirius.Domain.Entity.Payment", b =>
                {
                    b.HasOne("Sirius.Domain.Entity.Category", "CategoryNavigation")
                        .WithMany("PaymentNavigation")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("payment_category_id_fkey");

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("Sirius.Domain.Entity.Register", b =>
                {
                    b.HasOne("Sirius.Domain.Entity.Payment", "PaymentNavigation")
                        .WithMany("RegisterNavigation")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("register_payment_id_fkey");

                    b.Navigation("PaymentNavigation");
                });

            modelBuilder.Entity("Sirius.Domain.Entity.Category", b =>
                {
                    b.Navigation("PaymentNavigation");
                });

            modelBuilder.Entity("Sirius.Domain.Entity.Payment", b =>
                {
                    b.Navigation("RegisterNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
