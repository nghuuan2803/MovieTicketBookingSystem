using Microsoft.AspNetCore.Identity;
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
    public class AppDbContext : IdentityDbContext<User,Role,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<PhongChieu> PhongChieus { get; set; }
        //public DbSet<Ghe> Ghes { get; set; }
        //public DbSet<Phim> Phims { get; set; }
        //public DbSet<KhachHang> KhachHangs { get; set; }
        //public DbSet<XuatChieu> XuatChieus { get; set; }
        //public DbSet<Ve> Ves { get; set; }
        //public DbSet<HoaDon> HoaDons { get; set; }
        //public DbSet<ChiTietHD> ChiTietHDs { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<FnBCombo> FnBCombos { get; set; }
        public DbSet<BookingTicket> BookingTickets { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<UserVoucher> UserVouchers { get; set; }
        public DbSet<BookingFnBCombo> BookingFnBCombos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //...
            builder.Entity<BookingFnBCombo>().HasKey(p => new { p.BookingId, p.FnBComboId });
            builder.Entity<BookingTicket>().HasKey(p => new { p.BookingId, p.TicketId });

            builder.Entity<Role>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<Role>().Property(p => p.NormalizedName).HasMaxLength(30);

            builder.Entity<User>().Property(p => p.PhoneNumber).HasMaxLength(15);
            builder.Entity<User>().Property(p => p.Email).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.NormalizedEmail).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.UserName).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.NormalizedUserName).HasMaxLength(50);

            builder.Entity<IdentityUserClaim<Guid>>().Property(p => p.ClaimType).HasMaxLength(100);
            builder.Entity<IdentityUserClaim<Guid>>().Property(p => p.ClaimValue).HasMaxLength(100);

            builder.Entity<IdentityRoleClaim<Guid>>().Property(p => p.ClaimType).HasMaxLength(100);
            builder.Entity<IdentityRoleClaim<Guid>>().Property(p => p.ClaimValue).HasMaxLength(100);

            builder.Entity<IdentityUserLogin<Guid>>().Property(p => p.LoginProvider).HasMaxLength(100);
            builder.Entity<IdentityUserLogin<Guid>>().Property(p => p.ProviderKey).HasMaxLength(100);
            builder.Entity<IdentityUserLogin<Guid>>().Property(p => p.ProviderDisplayName).HasMaxLength(100);

            builder.Entity<IdentityUserToken<Guid>>().Property(p => p.LoginProvider).HasMaxLength(100);
            builder.Entity<IdentityUserToken<Guid>>().Property(p => p.Name).HasMaxLength(100);
        }
    }
}
