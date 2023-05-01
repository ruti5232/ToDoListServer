using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi;

public partial class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseMySql("name=ToDoDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        // You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
        // For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

        // Replace the connection string below with the Clever Cloud MySQL database connection string provided for your database
        optionsBuilder.UseMySql("server=bf5smc2n3kcst6cvpmna-mysql.services.clever-cloud.com;user=ugzaveinomeenqcu;password=ARy2v5X8JepflMRpGR9a;database=bf5smc2n3kcst6cvpmna", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
      //  optionsBuilder.UseMySql("server=bulq8zkrltahy8mjmvj2-mysql.services.clever-cloud.com;user=umxlzipsbs4lqzbd;password=QZtw4C38EWYrnIRduc01;database=bulq8zkrltahy8mjmvj2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
        // "ToDoDB":"server=localhost;user=root;password=1234;database=ToDoDB"
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Items");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
