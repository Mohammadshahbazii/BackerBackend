using Backer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Software> Software { get; set; }
    public DbSet<SoftwareVersion> SoftwareVersion { get; set; }

    public DbSet<Hardware> Hardwares { get; set; }

    public DbSet<DifficultGroup> DifficultGroups { get; set; }

    public DbSet<Difficult> Difficults { get; set; }

    public DbSet<Solution> Solutions { get; set; }

    public DbSet<SolutionAssignToDifficult> SolutionAssignToDifficult { get; set; }

    public DbSet<JobTitle> JobTitles { get; set; }

    public DbSet<AskPoll> AskPolls { get; set; }

    public DbSet<AnswerPoll> AnswerPolls { get; set; }

    public DbSet<PollSample> PollSample { get; set; }

    public DbSet<HardwareCartReader> HardwareCartReaders { get; set; }

    public DbSet<HardwarePortal> HardwarePortals { get; set; }

    public DbSet<HardwareConnection> HardwareConnections { get; set; }

    public DbSet<HardwareRepair> HardwareRepairs { get; set; }

    public DbSet<HardwareChange> HardwareChanges { get; set; }

    public DbSet<HardwareReplace> HardwareReplaces { get; set; }

    public DbSet<ContractPackage> ContractPackages { get; set; }

    public DbSet<DeviceContractSample> DeviceContractSamples { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<DeviceContractSamplePrice> DeviceContractSamplePrices { get; set; }

    public DbSet<AccessGroup> AccessGroups { get; set; }
    public DbSet<JobsAccess> JobsAccesses { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Telephone> Telephones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Software>(entity =>
        {
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(350);

            entity.Property(e => e.IsActive)
                .HasDefaultValue(true);
        });

        modelBuilder.Entity<Hardware>(entity =>
        {
            entity.Property(e => e.ModelName)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.IsActive)
                .HasDefaultValue(true);
        });

        modelBuilder.Entity<DifficultGroup>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired(); 
        });

        modelBuilder.Entity<Difficult>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsRequired();

            entity.HasOne(d => d.DifficultGroup)
                .WithMany()
                .HasForeignKey(d => d.DifficultGroupId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade based on your needs
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(400)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(MAX)"); // MAX instead of ntext
        });

        modelBuilder.Entity<SolutionAssignToDifficult>(entity =>
        {
            // Configure foreign key to Difficults
            entity.HasOne(a => a.Difficult)
                .WithMany()
                .HasForeignKey(a => a.DifficultId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure foreign key to Solutions
            entity.HasOne(a => a.Solution)
                .WithMany()
                .HasForeignKey(a => a.SolutionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: Add unique constraint to prevent duplicate assignments
            entity.HasIndex(a => new { a.DifficultId, a.SolutionId })
                .IsUnique();
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            // Optional: Add unique constraint
            entity.HasIndex(e => e.Title)
                .IsUnique();
        });

        modelBuilder.Entity<AskPoll>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsRequired();
        });

        modelBuilder.Entity<AnswerPoll>(entity =>
        {
            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();
        });

        modelBuilder.Entity<PollSample>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            // Configure foreign key to JobTitles
            entity.HasOne(p => p.JobTitle)
                .WithMany()
                .HasForeignKey(p => p.JobTitleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<HardwareCartReader>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            // Optional: Add unique constraint
            entity.HasIndex(e => e.Title)
                .IsUnique();
        });

        modelBuilder.Entity<HardwarePortal>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            // Optional: Add unique constraint
            entity.HasIndex(e => e.Title)
                .IsUnique();
        });

        modelBuilder.Entity<HardwareConnection>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            // Optional: Add unique constraint
            entity.HasIndex(e => e.Title)
                .IsUnique();
        });

        modelBuilder.Entity<HardwareRepair>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            // Optional: Add unique constraint
            entity.HasIndex(e => e.Title)
                .IsUnique();
        });

        modelBuilder.Entity<HardwareChange>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            // Optional: Add unique constraint
            entity.HasIndex(e => e.Title)
                .IsUnique();
        });

        modelBuilder.Entity<HardwareReplace>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<ContractPackage>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired(); 

            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsRequired(false); 
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.CallCount)
                .IsRequired(false);
        });

        modelBuilder.Entity<DeviceContractSample>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(400)
                .IsRequired();

            entity.Property(e => e.Priority)
                .IsRequired(false); // Makes column nullable
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(400)
                .IsRequired();

            // Self-referencing relationship
            entity.HasOne(r => r.Parent)
                .WithMany(r => r.Children)
                .HasForeignKey(r => r.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            entity.HasIndex(r => r.ParentId); // Index for better query performance
        });

        modelBuilder.Entity<DeviceContractSamplePrice>(entity =>
        {
            entity.ToTable("DeviceContractSamplePrices"); // Explicit table name

            entity.HasOne(p => p.DeviceContractSample)
                .WithMany()
                .HasForeignKey(p => p.DeviceContractSampleId);

            entity.HasCheckConstraint(
                "CK_DeviceContractSamplePrices_ValidDateRange",
                "EndDate >= BeginDate");
        });

        modelBuilder.Entity<AccessGroup>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(300)
                .IsRequired();

            // Add ParentId (nullable for hierarchy)
            entity.Property(e => e.ParentId)
                .IsRequired(false); // Optional parent-child structure

            // Self-referencing foreign key relationship
            entity.HasOne(e => e.ParentGroup)
                .WithMany()
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            entity.HasIndex(e => e.ParentId); // Optimize queries for hierarchy
        });

        modelBuilder.Entity<JobsAccess>(entity =>
        {
            entity.HasKey(e => e.Id); // Primary Key

            entity.Property(e => e.AccessGroupID)
                .IsRequired();

            entity.Property(e => e.JobTitleID)
                .IsRequired();

            // Foreign Key Relationship: AccessGroup
            entity.HasOne(e => e.AccessGroup)
                .WithMany()
                .HasForeignKey(e => e.AccessGroupID)
                .OnDelete(DeleteBehavior.Cascade); // Delete JobsAccess if AccessGroup is deleted

            // Foreign Key Relationship: JobTitle
            entity.HasOne(e => e.JobTitle)
                .WithMany()
                .HasForeignKey(e => e.JobTitleID)
                .OnDelete(DeleteBehavior.Cascade); // Delete JobsAccess if JobTitle is deleted
        });


        modelBuilder.Entity<User>(entity =>
        {
            // Required fields
            entity.Property(u => u.Username)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(u => u.Password)
                .HasMaxLength(128)
                .IsRequired();

            entity.Property(u => u.BeginDate)
                .IsRequired();

            // Foreign key relationships
            entity.HasOne(u => u.JobTitle)
                .WithMany()
                .HasForeignKey(u => u.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(u => u.Group)
                .WithMany()
                .HasForeignKey(u => u.GroupId)
                .OnDelete(DeleteBehavior.SetNull); // Set null if group deleted

            entity.HasOne(u => u.Region)
                .WithMany()
                .HasForeignKey(u => u.RegionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Optional fields
            entity.Property(u => u.Fullname)
                .HasMaxLength(200);

            entity.Property(u => u.Tel)
                .HasMaxLength(25);

            entity.Property(u => u.Address)
                .HasMaxLength(300);

            entity.Property(u => u.Fax)
                .HasMaxLength(10);

            entity.Property(u => u.Email)
                .HasMaxLength(100);

            // Indexes
            entity.HasIndex(u => u.Username)
                .IsUnique();

            entity.HasIndex(u => u.JobId);
            entity.HasIndex(u => u.GroupId);
            entity.HasIndex(u => u.RegionId);
        });

        modelBuilder.Entity<SoftwareVersion>(entity =>
        {
            // Required fields
            entity.Property(v => v.SoftwareId)
                .IsRequired();

            entity.Property(v => v.Version)
                .HasMaxLength(20)
                .IsRequired();

            // Optional fields
            entity.Property(v => v.Link)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired(false);

            entity.Property(v => v.CreateDate)
                .IsRequired(false);

            // Foreign key (if Software table exists)
            entity.HasOne(v => v.Software)
                .WithMany()
                .HasForeignKey(v => v.SoftwareId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Telephone>(entity =>
        {
            // Configure primary key (inherited from BaseEntity)
            entity.HasKey(t => t.Id);

            // Configure TellNo (char(10))
            entity.Property(t => t.TellNumber)
                .HasColumnType("char(10)")
                .IsFixedLength()
                .IsRequired(false);  // Nullable (Checked)

            // Configure Description (nvarchar(50))
            entity.Property(t => t.Description)
                .HasMaxLength(50)
                .IsRequired(false);  // Nullable (Checked)

            // Optional: Add index for TellNo if you'll query by it frequently
            entity.HasIndex(t => t.TellNumber);
        });
    }
}
