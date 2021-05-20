using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPPAppShare.Entities;

namespace VPPAppApi.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<HinhAnh> HinhAnhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Id
            modelBuilder.Entity<ThuongHieu>().HasKey(x => x.Id);
            modelBuilder.Entity<LoaiSP>().HasKey(x => x.Id);
            modelBuilder.Entity<SanPham>().HasKey(x => x.Id);
            modelBuilder.Entity<HinhAnh>().HasKey(x => x.Id);
            //Generated ID
            modelBuilder.Entity<ThuongHieu>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<LoaiSP>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<SanPham>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<HinhAnh>().Property(x => x.Id).ValueGeneratedOnAdd();

            //Relation
            modelBuilder.Entity<SanPham>().HasOne(x => x.ThuongHieu).WithMany(x => x.SanPhams).HasForeignKey(x=>x.ThuongHieuId);
            modelBuilder.Entity<SanPham>().HasOne(x => x.LoaiSP).WithMany(x => x.SanPhams).HasForeignKey(x=>x.LoaiSPId);
            modelBuilder.Entity<HinhAnh>().HasOne(x => x.SanPham).WithMany(x => x.HinhAnhs).HasForeignKey(x=>x.SanPhamId);
        }
    }
}
