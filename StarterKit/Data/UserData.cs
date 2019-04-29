
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarterKit.MainModels;

namespace StarterKit.Data
{
  public class SampleItemData : DbContext
  {
    public SampleItemData(DbContextOptions<SampleItemData> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.SetStringMaxLengthConvention(255);
      modelBuilder.Entity<SampleTable>(entity =>
      {
        entity.HasKey(e => e.UserId)
                        .HasName("PK_Users");
      });
    }

    public DbSet<SampleTable> Users { get; set; }
  }
}
