using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SSD20172WebAPI.Models
{
    public partial class SimulationDbContext : DbContext
    {
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Simulation> Simulation { get; set; }

        public SimulationDbContext(DbContextOptions<SimulationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.Utilization).HasColumnType("decimal(6, 5)");

                entity.HasOne(d => d.Simulation)
                    .WithMany(p => p.Agent)
                    .HasForeignKey(d => d.SimulationId)
                    .HasConstraintName("FK__Agent__Simulatio__59FA5E80");
            });

            modelBuilder.Entity<Simulation>(entity =>
            {
                entity.Property(e => e.AgentLunchDuration).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.AvgNumberInQueue).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.AvgTimeInSystem).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.AvgWaitingTime).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ExpertAgentMeanServiceDuration).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.LowerTransferTime).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.MaxNumberInQueue).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.MeanArrivalTime).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.NewAgentMeanServiceDuration).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.TotalServiceDuration).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.UpperTransferTime).HasColumnType("decimal(6, 5)");
            });
        }
    }
}
