using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingApp.Models
{
    public partial class BookingContext : DbContext
    {
        public BookingContext()
        {
        }

        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<EventsDetail> EventsDetails { get; set; } = null!;
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; } = null!;
        public virtual DbSet<PromoCode> PromoCodes { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:yash555.database.windows.net,1433;Initial Catalog=Booking;Persist Security Info=False;User ID=yash;Password=Yes@312000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_Details");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.BookingAmount)
                    .HasColumnType("money")
                    .HasColumnName("Booking_Amount");

                entity.Property(e => e.BookingEventId).HasColumnName("Booking_Event_Id");

                entity.Property(e => e.BookingNumberofTickets).HasColumnName("Booking_NumberofTickets");

                entity.Property(e => e.BookingSingleUnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("Booking_Single_UnitPrice");

                entity.Property(e => e.BookingUserId).HasColumnName("Booking_User_Id");

                entity.HasOne(d => d.BookingEvent)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingEventId)
                    .HasConstraintName("FK_Booking_Details");

                entity.HasOne(d => d.BookingUser)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingUserId)
                    .HasConstraintName("FK__Booking_D__Booki__71D1E811");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Category");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.ClassType).HasMaxLength(50);
            });

            modelBuilder.Entity<EventsDetail>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Events_Details");

                entity.Property(e => e.EventId).HasColumnName("Event_ID");

                entity.Property(e => e.EventAvilableTickets).HasColumnName("Event_AvilableTickets");

                entity.Property(e => e.EventEnddate)
                    .HasColumnType("date")
                    .HasColumnName("Event_Enddate");

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Event_Location");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Event_Name");

                entity.Property(e => e.EventStartdate)
                    .HasColumnType("date")
                    .HasColumnName("Event_Startdate");

                entity.Property(e => e.EventStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Event_Status");

                entity.Property(e => e.EventType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Event_Type");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("Payment_Details");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("money")
                    .HasColumnName("Payment_Amount");

                entity.Property(e => e.PaymentEventId).HasColumnName("Payment_Event_Id");

                entity.Property(e => e.PaymentPromoId).HasColumnName("Payment_Promo_Id");

                entity.Property(e => e.PaymentUserId).HasColumnName("Payment_User_Id");

                entity.HasOne(d => d.PaymentEvent)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.PaymentEventId)
                    .HasConstraintName("FK__Payment_D__Payme__73BA3083");

                entity.HasOne(d => d.PaymentPromo)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.PaymentPromoId)
                    .HasConstraintName("FK__Payment_D__Payme__74AE54BC");

                entity.HasOne(d => d.PaymentUser)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.PaymentUserId)
                    .HasConstraintName("FK_Payment_Details");
            });

            modelBuilder.Entity<PromoCode>(entity =>
            {
                entity.HasKey(e => e.PromoId);

                entity.ToTable("PromoCode");

                entity.Property(e => e.PromoId)
                    .ValueGeneratedNever()
                    .HasColumnName("Promo_Id");

                entity.Property(e => e.Discount).HasColumnName("Discount%");

                entity.Property(e => e.PromoCodename).HasMaxLength(50);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_Details");

                entity.HasIndex(e => e.UserUserName, "UQ__User_Det__1C7BA84D4D745FDD")
                    .IsUnique();

                entity.HasIndex(e => e.UserEmail, "UQ__User_Det__4C70A05C4E0F772D")
                    .IsUnique();

                entity.HasIndex(e => e.UserContact, "UQ__User_Det__C84FD24D5D21DFAD")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserContact).HasColumnName("User_Contact");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserFirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_FirstName");

                entity.Property(e => e.UserGender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("User_Gender");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_LastName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserUserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_UserName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
