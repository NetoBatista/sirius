﻿using Microsoft.EntityFrameworkCore;

namespace Sirius.Domain.Entity
{
    public partial class SiriusContext : DbContext
    {
        public SiriusContext()
        {
        }

        public SiriusContext(DbContextOptions<SiriusContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Payment> Payment { get; set; }

        public virtual DbSet<Register> Register { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Host=localhost;Database=sirius;Username=postgres;Password=Senha123!";
            }
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("category_pkey");

                entity.ToTable("category");

                entity.HasIndex(e => e.Name, "category_name_key").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("gen_random_uuid()")
                    .HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("createdat");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("payment_pkey");

                entity.ToTable("payment");

                entity.HasIndex(e => e.Name, "payment_name_key").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("gen_random_uuid()")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.PayDay).HasColumnName("pay_day");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.PaymentNavigation)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("payment_category_id_fkey");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("register_pkey");

                entity.ToTable("register");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("gen_random_uuid()")
                    .HasColumnName("id");

                entity.Property(e => e.PaidAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("createdat");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.PaymentNavigation)
                    .WithMany(p => p.RegisterNavigation)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("register_payment_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
