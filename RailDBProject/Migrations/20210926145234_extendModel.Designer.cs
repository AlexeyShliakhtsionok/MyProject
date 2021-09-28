﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailDBProject;

namespace RailDBProject.Migrations
{
    [DbContext(typeof(RailDBContext))]
    [Migration("20210926145234_extendModel")]
    partial class extendModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GlobalSectionOrganisation", b =>
                {
                    b.Property<int>("GlobalSectionsGlobalSectId")
                        .HasColumnType("int");

                    b.Property<int>("OrganisationsOrganisationId")
                        .HasColumnType("int");

                    b.HasKey("GlobalSectionsGlobalSectId", "OrganisationsOrganisationId");

                    b.HasIndex("OrganisationsOrganisationId");

                    b.ToTable("GlobalSectionOrganisation");
                });

            modelBuilder.Entity("RailDBProject.Model.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kilometer")
                        .HasColumnType("int");

                    b.Property<int?>("LocalSectionLocalSectoionId")
                        .HasColumnType("int");

                    b.Property<int>("Pkt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalSectionLocalSectoionId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("RailDBProject.Model.Defect", b =>
                {
                    b.Property<int>("DefectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoordinateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfDetection")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefectCode")
                        .HasColumnType("int");

                    b.Property<double>("DefectDepth")
                        .HasColumnType("float");

                    b.Property<double>("DefectLenght")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Manufacture")
                        .HasColumnType("int");

                    b.Property<string>("ManufactureYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Path")
                        .HasColumnType("int");

                    b.Property<int>("WaySide")
                        .HasColumnType("int");

                    b.HasKey("DefectId");

                    b.HasIndex("CoordinateId");

                    b.ToTable("Defects");
                });

            modelBuilder.Entity("RailDBProject.Model.DefectAudit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfDetection")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefectCode")
                        .HasColumnType("int");

                    b.Property<double>("DefectDepth")
                        .HasColumnType("float");

                    b.Property<double>("DefectLenght")
                        .HasColumnType("float");

                    b.Property<int>("Manufacture")
                        .HasColumnType("int");

                    b.Property<string>("ManufactureYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Path")
                        .HasColumnType("int");

                    b.Property<int>("WaySide")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DefectAudits");
                });

            modelBuilder.Entity("RailDBProject.Model.Defectoscope", b =>
                {
                    b.Property<int>("DefectoScopeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefectoScopeType")
                        .HasColumnType("int");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SubOrgId")
                        .HasColumnType("int");

                    b.HasKey("DefectoScopeId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Defectoscopes");
                });

            modelBuilder.Entity("RailDBProject.Model.GlobalSection", b =>
                {
                    b.Property<int>("GlobalSectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GlobaSectionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GlobalWayNumber")
                        .HasColumnType("int");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int?>("SubOrgId")
                        .HasColumnType("int");

                    b.HasKey("GlobalSectId");

                    b.ToTable("GlobalSections");
                });

            modelBuilder.Entity("RailDBProject.Model.LocalSection", b =>
                {
                    b.Property<int>("LocalSectoionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GlobalSectionGlobalSectId")
                        .HasColumnType("int");

                    b.Property<string>("LocaSectionlName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LocalWayNumber")
                        .HasColumnType("int");

                    b.HasKey("LocalSectoionId");

                    b.HasIndex("GlobalSectionGlobalSectId");

                    b.ToTable("LocalSections");
                });

            modelBuilder.Entity("RailDBProject.Model.Operator", b =>
                {
                    b.Property<int>("OperatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DefectoScopeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DismissalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastQualificationTraning")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<int?>("SubOrgId")
                        .HasColumnType("int");

                    b.HasKey("OperatorId");

                    b.HasIndex("DefectoScopeId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("RailDBProject.Model.Organisation", b =>
                {
                    b.Property<int>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int?>("ParentOrganisationId")
                        .HasColumnType("int");

                    b.HasKey("OrganisationId");

                    b.HasIndex("ParentOrganisationId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("RailDBProject.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GlobalSectionOrganisation", b =>
                {
                    b.HasOne("RailDBProject.Model.GlobalSection", null)
                        .WithMany()
                        .HasForeignKey("GlobalSectionsGlobalSectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailDBProject.Model.Organisation", null)
                        .WithMany()
                        .HasForeignKey("OrganisationsOrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RailDBProject.Model.Coordinate", b =>
                {
                    b.HasOne("RailDBProject.Model.LocalSection", "LocalSection")
                        .WithMany("Coordinates")
                        .HasForeignKey("LocalSectionLocalSectoionId");

                    b.Navigation("LocalSection");
                });

            modelBuilder.Entity("RailDBProject.Model.Defect", b =>
                {
                    b.HasOne("RailDBProject.Model.Coordinate", "Coordinate")
                        .WithMany("Defects")
                        .HasForeignKey("CoordinateId");

                    b.Navigation("Coordinate");
                });

            modelBuilder.Entity("RailDBProject.Model.Defectoscope", b =>
                {
                    b.HasOne("RailDBProject.Model.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("RailDBProject.Model.LocalSection", b =>
                {
                    b.HasOne("RailDBProject.Model.GlobalSection", "GlobalSection")
                        .WithMany("LocalSections")
                        .HasForeignKey("GlobalSectionGlobalSectId");

                    b.Navigation("GlobalSection");
                });

            modelBuilder.Entity("RailDBProject.Model.Operator", b =>
                {
                    b.HasOne("RailDBProject.Model.Defectoscope", "Defectoscope")
                        .WithMany("Operators")
                        .HasForeignKey("DefectoScopeId");

                    b.HasOne("RailDBProject.Model.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defectoscope");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("RailDBProject.Model.Organisation", b =>
                {
                    b.HasOne("RailDBProject.Model.Organisation", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentOrganisationId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("RailDBProject.Model.User", b =>
                {
                    b.HasOne("RailDBProject.Model.Organisation", "Organisation")
                        .WithMany("Users")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("RailDBProject.Model.Coordinate", b =>
                {
                    b.Navigation("Defects");
                });

            modelBuilder.Entity("RailDBProject.Model.Defectoscope", b =>
                {
                    b.Navigation("Operators");
                });

            modelBuilder.Entity("RailDBProject.Model.GlobalSection", b =>
                {
                    b.Navigation("LocalSections");
                });

            modelBuilder.Entity("RailDBProject.Model.LocalSection", b =>
                {
                    b.Navigation("Coordinates");
                });

            modelBuilder.Entity("RailDBProject.Model.Organisation", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
