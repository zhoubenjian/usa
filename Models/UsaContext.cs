using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace usa.Models;

public partial class UsaContext : DbContext
{
    public UsaContext()
    {
    }

    public UsaContext(DbContextOptions<UsaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=xia0yu;database=usa", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("state", tb => tb.HasComment("州"))
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CreateTime, "create_time");

            entity.HasIndex(e => e.StateName, "state_name").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(50)
                .HasComment("缩写")
                .HasColumnName("abbreviation");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.EndDate)
                .HasComment("结束日期")
                .HasColumnName("end_date");
            entity.Property(e => e.Governor)
                .HasMaxLength(50)
                .HasComment("州长")
                .HasColumnName("governor");
            entity.Property(e => e.NumberOfReps)
                .HasComment("代表人数")
                .HasColumnName("number_of_reps");
            entity.Property(e => e.PartyId)
                .HasComment("党派，0：摇摆州")
                .HasColumnName("party_id");
            entity.Property(e => e.Rank)
                .HasComment("经济排名")
                .HasColumnName("rank");
            entity.Property(e => e.StartDate)
                .HasComment("开始日期")
                .HasColumnName("start_date");
            entity.Property(e => e.StateCapital)
                .HasMaxLength(50)
                .HasComment("首府")
                .HasColumnName("state_capital");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .HasComment("州名")
                .HasColumnName("state_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("独立倾向, 0:不独立；1:独立")
                .HasColumnName("status");
            entity.Property(e => e.UpdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("修改时间")
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
