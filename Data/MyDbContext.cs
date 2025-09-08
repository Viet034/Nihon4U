using Microsoft.EntityFrameworkCore;
using Nihon4U.Models.Entities;

namespace Nihon4U.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User_Role> UserRoles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseDetail> CourseDetails { get; set; }
    public DbSet<CourseComboItem> CourseComboItems { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<CourseMaterial> CourseMaterials { get; set; }
    public DbSet<Quizz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<FlashcardProgress> FlashcardProgresses { get; set; }
    public DbSet<LearningProgress> LearningProgresses { get; set; }
    public DbSet<LearningStreak> LearningStreaks { get; set; }
    public DbSet<FavouriteCourse> FavouriteCourses { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order_Detail> OrderDetails { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Customer_Certificate> CustomerCertificates { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<SupportRequest> SupportRequests { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Course relationships
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Tests)
            .WithOne(t => t.Course)
            .HasForeignKey(t => t.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Enrollments)
            .WithOne(ce => ce.Course)
            .HasForeignKey(ce => ce.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Customer relationships
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.CourseEnrollments)
            .WithOne(ce => ce.Customer)
            .HasForeignKey(ce => ce.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Order relationships
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Employee)
            .WithMany()
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Cart relationships
        modelBuilder.Entity<Cart>()
            .HasOne(c => c.Customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Cart>()
            .HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Course)
            .WithMany()
            .HasForeignKey(ci => ci.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure CourseEnrollment relationships
        modelBuilder.Entity<CourseEnrollment>()
            .HasOne(ce => ce.Order)
            .WithMany(o => o.CourseEnrollments)
            .HasForeignKey(ce => ce.OrderId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure enum conversions
        modelBuilder.Entity<Course>()
            .Property(c => c.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Customer>()
            .Property(c => c.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Order>()
            .Property(o => o.PaymentStatus)
            .HasConversion<int>();

        modelBuilder.Entity<CourseEnrollment>()
            .Property(ce => ce.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Lesson>()
            .Property(l => l.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Test>()
            .Property(t => t.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Certificate>()
            .Property(c => c.Status)
            .HasConversion<int>();
    }
}
   