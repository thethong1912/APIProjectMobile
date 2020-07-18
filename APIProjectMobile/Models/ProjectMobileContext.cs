using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIProjectMobile.Models
{
    public partial class ProjectMobileContext : DbContext
    {
        public ProjectMobileContext()
        {
        }

        public ProjectMobileContext(DbContextOptions<ProjectMobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccount { get; set; }
        public virtual DbSet<TblActorRole> TblActorRole { get; set; }
        public virtual DbSet<TblEquipment> TblEquipment { get; set; }
        public virtual DbSet<TblEquipmentInScenario> TblEquipmentInScenario { get; set; }
        public virtual DbSet<TblRoleScenario> TblRoleScenario { get; set; }
        public virtual DbSet<TblScenario> TblScenario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SE130152\\SQLEXPRESS;Initial Catalog=ProjectMobile;Persist Security Info=True;User ID=sa;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PK_User");

                entity.ToTable("tblAccount");

                entity.HasIndex(e => e.AccEmail)
                    .HasName("Unique_Email")
                    .IsUnique();

                entity.Property(e => e.AccId).HasColumnName("accID");

                entity.Property(e => e.AccAdress)
                    .HasColumnName("accAdress")
                    .HasMaxLength(100);

                entity.Property(e => e.AccCreateBy)
                    .HasColumnName("accCreateBy")
                    .HasMaxLength(50);

                entity.Property(e => e.AccDescription)
                    .HasColumnName("accDescription")
                    .HasMaxLength(255);

                entity.Property(e => e.AccEmail)
                    .IsRequired()
                    .HasColumnName("accEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.AccImage).HasColumnName("accImage");

                entity.Property(e => e.AccIsDelete).HasColumnName("accIsDelete");

                entity.Property(e => e.AccName)
                    .IsRequired()
                    .HasColumnName("accName")
                    .HasMaxLength(50);

                entity.Property(e => e.AccPassword)
                    .IsRequired()
                    .HasColumnName("accPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.AccPhoneNum)
                    .HasColumnName("accPhoneNum")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AccRole).HasColumnName("accRole");

                entity.Property(e => e.AccStatus).HasColumnName("accStatus");

                entity.Property(e => e.AccUpdateBy)
                    .HasColumnName("accUpdateBy")
                    .HasMaxLength(50);

                entity.Property(e => e.AccUpdateTime)
                    .HasColumnName("accUpdateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblActorRole>(entity =>
            {
                entity.HasKey(e => e.ActorRoleId)
                    .HasName("PK_ActorRole");

                entity.ToTable("tblActorRole");

                entity.Property(e => e.ActorRoleId).HasColumnName("actorRoleID");

                entity.Property(e => e.ActorInScenario).HasColumnName("actorInScenario");

                entity.Property(e => e.ActorRoleDescription).HasColumnName("actorRoleDescription");

                entity.Property(e => e.AdminId).HasColumnName("adminID");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("dateUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleScenarioId).HasColumnName("roleScenarioID");

                entity.Property(e => e.ScenarioId).HasColumnName("scenarioId");

                entity.HasOne(d => d.ActorInScenarioNavigation)
                    .WithMany(p => p.TblActorRoles)
                    .HasForeignKey(d => d.ActorInScenario)
                    .HasConstraintName("FK_ActorRole_User");

                entity.HasOne(d => d.RoleScenario)
                    .WithMany(p => p.TblActorRoles)
                    .HasForeignKey(d => d.RoleScenarioId)
                    .HasConstraintName("FK_ActorRole_RoleScenarios");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.TblActorRoles)
                    .HasForeignKey(d => d.ScenarioId)
                    .HasConstraintName("FK_ActorRole_Scenario");
            });

            modelBuilder.Entity<TblEquipment>(entity =>
            {
                entity.HasKey(e => e.EquipmentId)
                    .HasName("PK_Equipment");

                entity.ToTable("tblEquipment");

                entity.HasIndex(e => e.EquipmentName)
                    .HasName("Unique_EquipmentName")
                    .IsUnique();

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentID");

                entity.Property(e => e.EquipmentDes)
                    .HasColumnName("equipmentDes")
                    .HasMaxLength(50);

                entity.Property(e => e.EquipmentImage).HasColumnName("equipmentImage");

                entity.Property(e => e.EquipmentIsDelete).HasColumnName("equipmentIsDelete");

                entity.Property(e => e.EquipmentName)
                    .IsRequired()
                    .HasColumnName("equipmentName")
                    .HasMaxLength(50);

                entity.Property(e => e.EquipmentQuantity).HasColumnName("equipmentQuantity");

                entity.Property(e => e.EquipmentStatus).HasColumnName("equipmentStatus");
            });

            modelBuilder.Entity<TblEquipmentInScenario>(entity =>
            {
                entity.HasKey(e => e.EquipInScenario)
                    .HasName("PK_EquipmentInScenario");

                entity.ToTable("tblEquipmentInScenario");

                entity.Property(e => e.EquipInScenario).HasColumnName("equipInScenario");

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentID");

                entity.Property(e => e.EquipmentQuantity).HasColumnName("equipmentQuantity");

                entity.Property(e => e.ScenarioId).HasColumnName("scenarioID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.TblEquipmentInScenarios)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_EquipmentInScenario_Equipment");

                entity.HasOne(d => d.Scenario)
                    .WithMany(p => p.TblEquipmentInScenarios)
                    .HasForeignKey(d => d.ScenarioId)
                    .HasConstraintName("FK_EquipmentInScenario_Scenario");
            });

            modelBuilder.Entity<TblRoleScenario>(entity =>
            {
                entity.HasKey(e => e.RoleScenarioId)
                    .HasName("PK_RoleScenarios");

                entity.ToTable("tblRoleScenario");

                entity.Property(e => e.RoleScenarioId).HasColumnName("roleScenarioID");

                entity.Property(e => e.RoleScenarioName)
                    .HasColumnName("roleScenarioName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblScenario>(entity =>
            {
                entity.HasKey(e => e.ScenarioId)
                    .HasName("PK_Scenario");

                entity.ToTable("tblScenario");

                entity.HasIndex(e => e.ScenarioName)
                    .HasName("Unique_ScenarioName")
                    .IsUnique();

                entity.Property(e => e.ScenarioId).HasColumnName("scenarioID");

                entity.Property(e => e.ScenarioCastAmout).HasColumnName("scenarioCastAmout");

                entity.Property(e => e.ScenarioDes)
                    .IsRequired()
                    .HasColumnName("scenarioDes")
                    .HasMaxLength(255);

                entity.Property(e => e.ScenarioImage).HasColumnName("scenarioImage");

                entity.Property(e => e.ScenarioIsDelete).HasColumnName("scenarioIsDelete");

                entity.Property(e => e.ScenarioLocation)
                    .IsRequired()
                    .HasColumnName("scenarioLocation")
                    .HasMaxLength(50);

                entity.Property(e => e.ScenarioName)
                    .IsRequired()
                    .HasColumnName("scenarioName")
                    .HasMaxLength(50);

                entity.Property(e => e.ScenarioScript).HasColumnName("scenarioScript");

                entity.Property(e => e.ScenarioStatus).HasColumnName("scenarioStatus");

                entity.Property(e => e.ScenarioTimeFrom)
                    .HasColumnName("scenarioTimeFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScenarioTimeTo)
                    .HasColumnName("scenarioTimeTo")
                    .HasColumnType("datetime");
            });
        }
    }
}
