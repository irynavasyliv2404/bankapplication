﻿// <auto-generated />
using System;
using BankApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankApp.DAL.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20190128121548_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankApp.Domain.SenderAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance");

                    b.Property<int>("UserId");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankApp.Domain.Transactions.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<double>("Amount");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("BankApp.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankApp.Domain.Transactions.Deposit", b =>
                {
                    b.HasBaseType("BankApp.Domain.Transactions.Transaction");

                    b.HasDiscriminator().HasValue("Deposit");
                });

            modelBuilder.Entity("BankApp.Domain.Transactions.Transfer", b =>
                {
                    b.HasBaseType("BankApp.Domain.Transactions.Transaction");

                    b.Property<int?>("DestinationId");

                    b.HasIndex("DestinationId");

                    b.HasDiscriminator().HasValue("Transfer");
                });

            modelBuilder.Entity("BankApp.Domain.Transactions.Withdraw", b =>
                {
                    b.HasBaseType("BankApp.Domain.Transactions.Transaction");

                    b.HasDiscriminator().HasValue("Withdraw");
                });

            modelBuilder.Entity("BankApp.Domain.SenderAccount", b =>
                {
                    b.HasOne("BankApp.Domain.User", "User")
                        .WithOne("SenderAccount")
                        .HasForeignKey("BankApp.Domain.SenderAccount", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankApp.Domain.Transactions.Transaction", b =>
                {
                    b.HasOne("BankApp.Domain.SenderAccount", "SenderAccount")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankApp.Domain.Transactions.Transfer", b =>
                {
                    b.HasOne("BankApp.Domain.SenderAccount", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId");
                });
#pragma warning restore 612, 618
        }
    }
}
