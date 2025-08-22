using Microsoft.EntityFrameworkCore;
using Nihon4U.Models.Entities;

namespace Nihon4U;

public class MyDbContext : DbContext
{
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
}
   