// <auto-generated />
using System;
using LIR.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LIR.DAL.Migrations
{
    [DbContext(typeof(LIRDbContext))]
    partial class LIRDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LIR.DOMAIN.Entities.ConsumerBenefitResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Benefits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BenefitsAmountQuotation")
                        .HasColumnType("float");

                    b.Property<Guid>("ConsumerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Multiple")
                        .HasColumnType("int");

                    b.Property<double>("PendedAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransactionDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerProfileId");

                    b.ToTable("ConsumerBenefitResults");
                });

            modelBuilder.Entity("LIR.DOMAIN.Entities.ConsumerProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BasicSalary")
                        .HasColumnType("float");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConsumerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConsumerProfiles");
                });

            modelBuilder.Entity("LIR.DOMAIN.Entities.RetirementSetup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("GuaranteedIssue")
                        .HasColumnType("float");

                    b.Property<int>("Increments")
                        .HasColumnType("int");

                    b.Property<int>("MaxAgeLimit")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("MaximumRange")
                        .HasColumnType("int");

                    b.Property<int>("MinAgeLimit")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("MinimumRange")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RetirementSetups");
                });

            modelBuilder.Entity("LIR.DOMAIN.Entities.ConsumerBenefitResult", b =>
                {
                    b.HasOne("LIR.DOMAIN.Entities.ConsumerProfile", "ConsumerProfile")
                        .WithMany("ConsumerBenefitResults")
                        .HasForeignKey("ConsumerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerProfile");
                });

            modelBuilder.Entity("LIR.DOMAIN.Entities.ConsumerProfile", b =>
                {
                    b.Navigation("ConsumerBenefitResults");
                });
#pragma warning restore 612, 618
        }
    }
}
