﻿// <auto-generated />
using System;
using KPICatalog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KPICatalog.API.Migrations
{
    [DbContext(typeof(KPICatalogDbContext))]
    [Migration("20240719160617_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusScheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CostCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefaulBonusScheme")
                        .HasColumnType("bit");

                    b.Property<int>("PlanningCycleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanningCycleId");

                    b.ToTable("BonusSchemes");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusSchemeLinkMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BonusSchemeLinkMethod");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "На сотрудника"
                        },
                        new
                        {
                            Id = 2,
                            Name = "На бонусную схему"
                        },
                        new
                        {
                            Id = 3,
                            Name = "На всех"
                        });
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusSchemeObjectLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BonusSchemeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LinkEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LinkPercent")
                        .HasColumnType("int");

                    b.Property<DateTime>("LinkStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LinkedObjectId")
                        .HasColumnType("int");

                    b.Property<int>("LinkedObjectTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BonusSchemeId");

                    b.HasIndex("LinkedObjectTypeId");

                    b.ToTable("BonusSchemeObjectLinks");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.EvaluationMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EvaluationMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Прямой"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Обратно-пропорциональный"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Шкала SLA"
                        });
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.LinkedObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LinkedObjectTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BS-Employee"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BS-Goal"
                        },
                        new
                        {
                            Id = 3,
                            Name = "BS-Request"
                        },
                        new
                        {
                            Id = 4,
                            Name = "BS-Group"
                        });
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.PlanningCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlanningCycles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Годовая цель"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ЛОКР"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Критерий достижения"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Квартальная цель"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Месячная цель"
                        });
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.TypicalGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentGoalId")
                        .HasColumnType("int");

                    b.Property<int>("PlanningCycleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeightTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanningCycleId");

                    b.HasIndex("WeightTypeId");

                    b.ToTable("TypicalGoals");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.TypicalGoalInBonusScheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BonusSchemeLinkMethodId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Evaluation")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("EvaluationMethodId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluationProvider")
                        .HasColumnType("int");

                    b.Property<decimal?>("Fact")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("ParentBSTypicalGoalId")
                        .HasColumnType("int");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<decimal>("Plan")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("RatingScaleId")
                        .HasColumnType("int");

                    b.Property<int>("TypeKeyResultId")
                        .HasColumnType("int");

                    b.Property<int>("TypicalGoalId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("BonusSchemeLinkMethodId");

                    b.HasIndex("EvaluationMethodId");

                    b.HasIndex("TypicalGoalId");

                    b.ToTable("TypicalGoalInBonusSchemes");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.UserAccessControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAccessGranted")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccessControls");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.WeightType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeightTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Процент"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Тариф"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Комиссия"
                        });
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusScheme", b =>
                {
                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.PlanningCycle", "PlanningCycle")
                        .WithMany("BonusSchemes")
                        .HasForeignKey("PlanningCycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanningCycle");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusSchemeObjectLink", b =>
                {
                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.BonusScheme", "BonusScheme")
                        .WithMany("BonusSchemeObjectLinks")
                        .HasForeignKey("BonusSchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.LinkedObjectType", "LinkedObjectType")
                        .WithMany("BonusSchemeObjectLinks")
                        .HasForeignKey("LinkedObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BonusScheme");

                    b.Navigation("LinkedObjectType");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.TypicalGoal", b =>
                {
                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.PlanningCycle", "PlanningCycle")
                        .WithMany("TypicalGoals")
                        .HasForeignKey("PlanningCycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.WeightType", "WeightType")
                        .WithMany("TypicalGoals")
                        .HasForeignKey("WeightTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanningCycle");

                    b.Navigation("WeightType");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.TypicalGoalInBonusScheme", b =>
                {
                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.BonusSchemeLinkMethod", "BonusSchemeLinkMethod")
                        .WithMany("TypicalGoalInBonusSchemes")
                        .HasForeignKey("BonusSchemeLinkMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.EvaluationMethod", "EvaluationMethod")
                        .WithMany("TypicalGoalInBonusSchemes")
                        .HasForeignKey("EvaluationMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KPICatalog.Domain.Models.Entities.KPICatalog.TypicalGoal", "TypicalGoal")
                        .WithMany("TypicalGoalInBonusSchemes")
                        .HasForeignKey("TypicalGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BonusSchemeLinkMethod");

                    b.Navigation("EvaluationMethod");

                    b.Navigation("TypicalGoal");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusScheme", b =>
                {
                    b.Navigation("BonusSchemeObjectLinks");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.BonusSchemeLinkMethod", b =>
                {
                    b.Navigation("TypicalGoalInBonusSchemes");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.EvaluationMethod", b =>
                {
                    b.Navigation("TypicalGoalInBonusSchemes");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.LinkedObjectType", b =>
                {
                    b.Navigation("BonusSchemeObjectLinks");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.PlanningCycle", b =>
                {
                    b.Navigation("BonusSchemes");

                    b.Navigation("TypicalGoals");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.TypicalGoal", b =>
                {
                    b.Navigation("TypicalGoalInBonusSchemes");
                });

            modelBuilder.Entity("KPICatalog.Domain.Models.Entities.KPICatalog.WeightType", b =>
                {
                    b.Navigation("TypicalGoals");
                });
#pragma warning restore 612, 618
        }
    }
}
