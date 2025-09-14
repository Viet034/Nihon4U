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

        // Configure User-Role many-to-many relationship
        modelBuilder.Entity<User_Role>()
            .HasKey(ur => ur.Id);

        modelBuilder.Entity<User_Role>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.User_Roles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User_Role>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.User_Roles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure User relationships
        modelBuilder.Entity<User>()
            .HasMany(u => u.Customers)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Employees)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Notifications)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

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

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Order_Details)
            .WithOne(od => od.Course)
            .HasForeignKey(od => od.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Lesson relationships
        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.Materials)
            .WithOne(cm => cm.Lesson)
            .HasForeignKey(cm => cm.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.Quizzes)
            .WithOne(q => q.Lesson)
            .HasForeignKey(q => q.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.Flashcards)
            .WithOne(f => f.Lesson)
            .HasForeignKey(f => f.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Customer relationships
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

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Customer_Certificates)
            .WithOne(cc => cc.Customer)
            .HasForeignKey(cc => cc.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Employee relationships
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Orders)
            .WithOne(o => o.Employee)
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Order relationships
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.CourseEnrollments)
            .WithOne(ce => ce.Order)
            .HasForeignKey(ce => ce.OrderId)
            .OnDelete(DeleteBehavior.SetNull);

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

        // Configure Question relationships
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Quizz)
            .WithMany(qu => qu.Questions)
            .HasForeignKey(q => q.QuizzId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.Test)
            .WithMany(t => t.Questions)
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Certificate relationships
        modelBuilder.Entity<Certificate>()
            .HasOne(c => c.Course)
            .WithMany()
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Certificate>()
            .HasMany(c => c.Customer_Certificates)
            .WithOne(cc => cc.Certificate)
            .HasForeignKey(cc => cc.CertificateId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Customer_Certificate relationships
        modelBuilder.Entity<Customer_Certificate>()
            .HasOne(cc => cc.Customer)
            .WithMany(c => c.Customer_Certificates)
            .HasForeignKey(cc => cc.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer_Certificate>()
            .HasOne(cc => cc.Certificate)
            .WithMany(c => c.Customer_Certificates)
            .HasForeignKey(cc => cc.CertificateId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Test relationships
        modelBuilder.Entity<Test>()
            .HasOne(t => t.Course)
            .WithMany(c => c.Tests)
            .HasForeignKey(t => t.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Test>()
            .HasMany(t => t.Questions)
            .WithOne(q => q.Test)
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure CourseComboItem relationships
        modelBuilder.Entity<CourseComboItem>()
            .HasOne(cci => cci.ComboCourse)
            .WithMany(c => c.CourseComboItems)
            .HasForeignKey(cci => cci.ComboCourseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseComboItem>()
            .HasOne(cci => cci.IncludedCourse)
            .WithMany()
            .HasForeignKey(cci => cci.IncludedCourseId)
            .OnDelete(DeleteBehavior.Restrict);

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
   