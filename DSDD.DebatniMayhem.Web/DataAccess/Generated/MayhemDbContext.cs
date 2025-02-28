using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public partial class MayhemDbContext : DbContext
{
    public MayhemDbContext(DbContextOptions<MayhemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071C880D66");

            entity.Property(e => e.Cg1).HasColumnName("CG_1");
            entity.Property(e => e.Cg1SpeakerPoints).HasColumnName("CG_1_SpeakerPoints");
            entity.Property(e => e.Cg2).HasColumnName("CG_2");
            entity.Property(e => e.Cg2SpeakerPoints).HasColumnName("CG_2_SpeakerPoints");
            entity.Property(e => e.CgPoints).HasColumnName("CG_Points");
            entity.Property(e => e.Co1).HasColumnName("CO_1");
            entity.Property(e => e.Co1SpeakerPoints).HasColumnName("CO_1_SpeakerPoints");
            entity.Property(e => e.Co2).HasColumnName("CO_2");
            entity.Property(e => e.Co2SpeakerPoints).HasColumnName("CO_2_SpeakerPoints");
            entity.Property(e => e.CoPoints).HasColumnName("CO_Points");
            entity.Property(e => e.Og1).HasColumnName("OG_1");
            entity.Property(e => e.Og1SpeakerPoints).HasColumnName("OG_1_SpeakerPoints");
            entity.Property(e => e.Og2).HasColumnName("OG_2");
            entity.Property(e => e.Og2SpeakerPoints).HasColumnName("OG_2_SpeakerPoints");
            entity.Property(e => e.OgPoints).HasColumnName("OG_Points");
            entity.Property(e => e.Oo1).HasColumnName("OO_1");
            entity.Property(e => e.Oo1SpeakerPoints).HasColumnName("OO_1_SpeakerPoints");
            entity.Property(e => e.Oo2).HasColumnName("OO_2");
            entity.Property(e => e.Oo2SpeakerPoints).HasColumnName("OO_2_SpeakerPoints");
            entity.Property(e => e.OoPoints).HasColumnName("OO_Points");

            entity.HasOne(d => d.Cg1Navigation).WithMany(p => p.MatchCg1Navigations)
                .HasForeignKey(d => d.Cg1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_CG_1");

            entity.HasOne(d => d.Cg2Navigation).WithMany(p => p.MatchCg2Navigations)
                .HasForeignKey(d => d.Cg2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_CG_2");

            entity.HasOne(d => d.Co1Navigation).WithMany(p => p.MatchCo1Navigations)
                .HasForeignKey(d => d.Co1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_CO_1");

            entity.HasOne(d => d.Co2Navigation).WithMany(p => p.MatchCo2Navigations)
                .HasForeignKey(d => d.Co2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_CO_2");

            entity.HasOne(d => d.Og1Navigation).WithMany(p => p.MatchOg1Navigations)
                .HasForeignKey(d => d.Og1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_OG_1");

            entity.HasOne(d => d.Og2Navigation).WithMany(p => p.MatchOg2Navigations)
                .HasForeignKey(d => d.Og2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_OG_2");

            entity.HasOne(d => d.Oo1Navigation).WithMany(p => p.MatchOo1Navigations)
                .HasForeignKey(d => d.Oo1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_OO_1");

            entity.HasOne(d => d.Oo2Navigation).WithMany(p => p.MatchOo2Navigations)
                .HasForeignKey(d => d.Oo2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_OO_2");

            entity.HasOne(d => d.Room).WithMany(p => p.Matches)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_Room");

            entity.HasOne(d => d.Round).WithMany(p => p.Matches)
                .HasForeignKey(d => d.RoundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_Round");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Players__3214EC07CFC818A6");

            entity.ToTable(tb => tb.HasTrigger("TR_PlaceholderZeroValues"));

            entity.HasIndex(e => e.PublicId, "IX_Players_PublicId").IsUnique();

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PublicId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Score).HasDefaultValue(1500);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC074D3F6BD2");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rounds__3214EC076CA9BC27");

            entity.ToTable(tb => tb.HasTrigger("TR_EnsureSingleOngoingRound"));

            entity.Property(e => e.ShowInfoSlide).HasDefaultValue(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
