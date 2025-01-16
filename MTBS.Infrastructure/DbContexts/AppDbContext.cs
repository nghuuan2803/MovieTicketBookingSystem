using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTBS.Domain.Entities;
using MTBS.Domain.SampleModels;
using MTBS.Domain.SimpleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }

        //public DbSet<Movie> Movies { get; set; }
        public DbSet<PhongChieu> PhongChieus { get; set; }
        public DbSet<Ghe> Ghes { get; set; }
        public DbSet<Phim> Phims { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<XuatChieu> XuatChieus { get; set; }
        public DbSet<Ve> Ves { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHD> ChiTietHDs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //...

            //builder.Entity<Ve>().HasOne<XuatChieu>().WithMany().HasForeignKey(p=>p.XuatChieuId).OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<XuatChieu>().HasOne<Phim>().WithMany().HasForeignKey(p=>p.PhimId).OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<Ve>().HasOne<Ghe>().WithMany().HasForeignKey(p=>p.GheId).OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<ChiTietHD>().HasOne<Ve>().WithMany().HasForeignKey(p=>p.VeId).OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<XuatChieu>().HasOne<PhongChieu>().WithMany().HasForeignKey(p=>p.PhongChieuId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
