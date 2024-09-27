using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIWithf1db.Data;

public partial class ClassSharedRoContext : DbContext
{
    public ClassSharedRoContext()
    {
    }

    public ClassSharedRoContext(DbContextOptions<ClassSharedRoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Circuit> Circuits { get; set; }

    public virtual DbSet<Constructor> Constructors { get; set; }

    public virtual DbSet<Constructorresult> Constructorresults { get; set; }

    public virtual DbSet<Constructorstanding> Constructorstandings { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Driverstanding> Driverstandings { get; set; }

    public virtual DbSet<Driverstat> Driverstats { get; set; }

    public virtual DbSet<Laptime> Laptimes { get; set; }

    public virtual DbSet<Pitstop> Pitstops { get; set; }

    public virtual DbSet<Qualifying> Qualifyings { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Circuit>(entity =>
        {
            entity.HasKey(e => e.Circuitid).HasName("idx_17102_primary");

            entity.ToTable("circuits", "f1db");

            entity.HasIndex(e => e.Position, "circuits_position_idx").HasMethod("gist");

            entity.HasIndex(e => e.Url, "idx_17102_url").IsUnique();

            entity.Property(e => e.Circuitid).HasColumnName("circuitid");
            entity.Property(e => e.Alt).HasColumnName("alt");
            entity.Property(e => e.Circuitref)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("circuitref");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("country");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lng).HasColumnName("lng");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("url");
        });

        modelBuilder.Entity<Constructor>(entity =>
        {
            entity.HasKey(e => e.Constructorid).HasName("idx_17125_primary");

            entity.ToTable("constructors", "f1db");

            entity.HasIndex(e => e.Name, "idx_17125_name").IsUnique();

            entity.Property(e => e.Constructorid).HasColumnName("constructorid");
            entity.Property(e => e.Constructorref)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("constructorref");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("nationality");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("url");
        });

        modelBuilder.Entity<Constructorresult>(entity =>
        {
            entity.HasKey(e => e.Constructorresultsid).HasName("idx_17116_primary");

            entity.ToTable("constructorresults", "f1db");

            entity.Property(e => e.Constructorresultsid).HasColumnName("constructorresultsid");
            entity.Property(e => e.Constructorid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("constructorid");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Raceid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("raceid");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.Constructor).WithMany(p => p.Constructorresults)
                .HasForeignKey(d => d.Constructorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("constructorresults_fk_1");

            entity.HasOne(d => d.Race).WithMany(p => p.Constructorresults)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("constructorresults_fk_2");
        });

        modelBuilder.Entity<Constructorstanding>(entity =>
        {
            entity.HasKey(e => e.Constructorstandingsid).HasName("idx_17138_primary");

            entity.ToTable("constructorstandings", "f1db");

            entity.Property(e => e.Constructorstandingsid).HasColumnName("constructorstandingsid");
            entity.Property(e => e.Constructorid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("constructorid");
            entity.Property(e => e.Points)
                .HasDefaultValueSql("'0'::double precision")
                .HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Positiontext)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("positiontext");
            entity.Property(e => e.Raceid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("raceid");
            entity.Property(e => e.Wins)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("wins");

            entity.HasOne(d => d.Constructor).WithMany(p => p.Constructorstandings)
                .HasForeignKey(d => d.Constructorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("constructorstandings_fk_1");

            entity.HasOne(d => d.Race).WithMany(p => p.Constructorstandings)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("constructorstandings_fk");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Driverid).HasName("idx_17149_primary");

            entity.ToTable("drivers", "f1db");

            entity.HasIndex(e => e.Url, "idx_17149_url").IsUnique();

            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("code");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Driverref)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("driverref");
            entity.Property(e => e.Forename)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("forename");
            entity.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("nationality");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("surname");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("url");
        });

        modelBuilder.Entity<Driverstanding>(entity =>
        {
            entity.HasKey(e => e.Driverstandingsid).HasName("idx_17164_primary");

            entity.ToTable("driverstandings", "f1db");

            entity.Property(e => e.Driverstandingsid).HasColumnName("driverstandingsid");
            entity.Property(e => e.Driverid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("driverid");
            entity.Property(e => e.Points)
                .HasDefaultValueSql("'0'::double precision")
                .HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Positiontext)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("positiontext");
            entity.Property(e => e.Raceid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("raceid");
            entity.Property(e => e.Wins)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("wins");

            entity.HasOne(d => d.Driver).WithMany(p => p.Driverstandings)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("driverstandings_fk");

            entity.HasOne(d => d.Race).WithMany(p => p.Driverstandings)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("driverstandings_fk_1");
        });

        modelBuilder.Entity<Driverstat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("driverstats", "f1db");

            entity.Property(e => e.Dname).HasColumnName("dname");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Numcircuits).HasColumnName("numcircuits");
        });

        modelBuilder.Entity<Laptime>(entity =>
        {
            entity.HasKey(e => new { e.Raceid, e.Driverid, e.Lap }).HasName("idx_17173_primary");

            entity.ToTable("laptimes", "f1db");

            entity.HasIndex(e => e.Raceid, "idx_17173_raceid");

            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Lap).HasColumnName("lap");
            entity.Property(e => e.Milliseconds).HasColumnName("milliseconds");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Time)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("time");

            entity.HasOne(d => d.Driver).WithMany(p => p.Laptimes)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("laptimes_fk_1");

            entity.HasOne(d => d.Race).WithMany(p => p.Laptimes)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("laptimes_fk");
        });

        modelBuilder.Entity<Pitstop>(entity =>
        {
            entity.HasKey(e => new { e.Raceid, e.Driverid, e.Stop }).HasName("idx_17177_primary");

            entity.ToTable("pitstops", "f1db");

            entity.HasIndex(e => e.Raceid, "idx_17177_raceid");

            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Stop).HasColumnName("stop");
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("duration");
            entity.Property(e => e.Lap).HasColumnName("lap");
            entity.Property(e => e.Milliseconds).HasColumnName("milliseconds");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Driver).WithMany(p => p.Pitstops)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pitstops_fk");

            entity.HasOne(d => d.Race).WithMany(p => p.Pitstops)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pitstops_fk_1");
        });

        modelBuilder.Entity<Qualifying>(entity =>
        {
            entity.HasKey(e => e.Qualifyid).HasName("idx_17183_primary");

            entity.ToTable("qualifying", "f1db");

            entity.Property(e => e.Qualifyid).HasColumnName("qualifyid");
            entity.Property(e => e.Constructorid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("constructorid");
            entity.Property(e => e.Driverid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("driverid");
            entity.Property(e => e.Number)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("number");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Q1)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("q1");
            entity.Property(e => e.Q2)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("q2");
            entity.Property(e => e.Q3)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("q3");
            entity.Property(e => e.Raceid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("raceid");

            entity.HasOne(d => d.Constructor).WithMany(p => p.Qualifyings)
                .HasForeignKey(d => d.Constructorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("qualifying_fk_1");

            entity.HasOne(d => d.Driver).WithMany(p => p.Qualifyings)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("qualifying_fk");

            entity.HasOne(d => d.Race).WithMany(p => p.Qualifyings)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("qualifying_fk_2");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Raceid).HasName("idx_17199_primary");

            entity.ToTable("races", "f1db");

            entity.HasIndex(e => e.Url, "idx_17199_url").IsUnique();

            entity.Property(e => e.Raceid).HasColumnName("raceid");
            entity.Property(e => e.Circuitid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("circuitid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("name");
            entity.Property(e => e.Round)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("round");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("url");
            entity.Property(e => e.Year)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("year");

            entity.HasOne(d => d.Circuit).WithMany(p => p.Races)
                .HasForeignKey(d => d.Circuitid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("races_fk");

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.Races)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("races_fk_1");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Resultid).HasName("idx_17213_primary");

            entity.ToTable("results", "f1db");

            entity.Property(e => e.Resultid).HasColumnName("resultid");
            entity.Property(e => e.Constructorid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("constructorid");
            entity.Property(e => e.Driverid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("driverid");
            entity.Property(e => e.Fastestlap).HasColumnName("fastestlap");
            entity.Property(e => e.Fastestlapspeed)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("fastestlapspeed");
            entity.Property(e => e.Fastestlaptime)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("fastestlaptime");
            entity.Property(e => e.Grid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("grid");
            entity.Property(e => e.Laps)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("laps");
            entity.Property(e => e.Milliseconds).HasColumnName("milliseconds");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Points)
                .HasDefaultValueSql("'0'::double precision")
                .HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Positionorder)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("positionorder");
            entity.Property(e => e.Positiontext)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("positiontext");
            entity.Property(e => e.Raceid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("raceid");
            entity.Property(e => e.Rank)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("rank");
            entity.Property(e => e.Statusid)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("statusid");
            entity.Property(e => e.Time)
                .HasMaxLength(255)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("time");

            entity.HasOne(d => d.Constructor).WithMany(p => p.Results)
                .HasForeignKey(d => d.Constructorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_fk_2");

            entity.HasOne(d => d.Driver).WithMany(p => p.Results)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_fk");

            entity.HasOne(d => d.Race).WithMany(p => p.Results)
                .HasForeignKey(d => d.Raceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_fk_1");

            entity.HasOne(d => d.Status).WithMany(p => p.Results)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_fk_3");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Year).HasName("idx_17233_primary");

            entity.ToTable("seasons", "f1db");

            entity.HasIndex(e => e.Url, "idx_17233_url").IsUnique();

            entity.Property(e => e.Year)
                .HasDefaultValueSql("'0'::bigint")
                .HasColumnName("year");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("url");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("idx_17240_primary");

            entity.ToTable("status", "f1db");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Status1)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
