using AutoMapper;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Customer;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;

namespace Nihon4U.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Course mappings
        CreateMap<Course, CourseDTO>();
        CreateMap<CourseDTO, Course>();
        CreateMap<Course, CourseResponseDTO>();
        CreateMap<CourseDetail, CourseDetailDTO>();
        CreateMap<CourseDetailDTO, CourseDetail>();
        CreateMap<CourseDetail, CourseDetailResponseDTO>();

        // Customer mappings
        CreateMap<Customer, CustomerDTO>();
        CreateMap<CustomerDTO, Customer>();
        CreateMap<Customer, CustomerResponseDTO>();
        CreateMap<CustomerCreateDTO, Customer>();
        CreateMap<CustomerUpdateDTO, Customer>();

        // Order mappings
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();
        CreateMap<Order, OrderResponseDTO>();
        CreateMap<Order_Detail, OrderDetailDTO>();
        CreateMap<OrderDetailDTO, Order_Detail>();
        CreateMap<Order_Detail, OrderDetailResponseDTO>();

        // Course Enrollment mappings
        CreateMap<CourseEnrollment, CourseEnrollmentDTO>();
        CreateMap<CourseEnrollmentDTO, CourseEnrollment>();
        CreateMap<CourseEnrollment, CourseEnrollmentResponseDTO>();

        // Lesson mappings
        CreateMap<Lesson, LessonDTO>();
        CreateMap<LessonDTO, Lesson>();
        CreateMap<Lesson, LessonResponseDTO>();

        // Test mappings
        CreateMap<Test, TestDTO>();
        CreateMap<TestDTO, Test>();
        CreateMap<Test, TestResponseDTO>();

        // Certificate mappings
        CreateMap<Certificate, CertificateDTO>();
        CreateMap<CertificateDTO, Certificate>();
        CreateMap<Certificate, CertificateResponseDTO>();
        CreateMap<Customer_Certificate, CustomerCertificateDTO>();
        CreateMap<CustomerCertificateDTO, Customer_Certificate>();
        CreateMap<Customer_Certificate, CustomerCertificateResponseDTO>();

        // Cart mappings
        CreateMap<Cart, CartDTO>();
        CreateMap<CartDTO, Cart>();
        CreateMap<Cart, CartResponseDTO>();
        CreateMap<CartItem, CartItemDTO>();
        CreateMap<CartItemDTO, CartItem>();
        CreateMap<CartItem, CartItemResponseDTO>();

        // Learning Progress mappings
        CreateMap<LearningProgress, LearningProgressDTO>();
        CreateMap<LearningProgressDTO, LearningProgress>();
        CreateMap<LearningProgress, LearningProgressResponseDTO>();

        // Flashcard mappings
        CreateMap<Flashcard, FlashcardDTO>();
        CreateMap<FlashcardDTO, Flashcard>();
        CreateMap<Flashcard, FlashcardResponseDTO>();
        CreateMap<FlashcardProgress, FlashcardProgessDTO>();
        CreateMap<FlashcardProgessDTO, FlashcardProgress>();
        CreateMap<FlashcardProgress, FlashcardProgressResponseDTO>();

        // Feedback mappings
        CreateMap<Feedback, FeedbackDTO>();
        CreateMap<FeedbackDTO, Feedback>();
        CreateMap<Feedback, FeedbackResponseDTO>();

        // FAQ mappings
        CreateMap<Faq, FaqDTO>();
        CreateMap<FaqDTO, Faq>();
        CreateMap<Faq, FaqResponseDTO>();

        // Notification mappings
        CreateMap<Notification, NotificationDTO>();
        CreateMap<NotificationDTO, Notification>();
        CreateMap<Notification, NotificationResponseDTO>();

        // User mappings
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
        CreateMap<User, UserResponseDTO>();

        // Role mappings
        CreateMap<Role, RoleDTO>();
        CreateMap<RoleDTO, Role>();
        CreateMap<Role, RoleResponseDTO>();

        // Employee mappings
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
        CreateMap<Employee, EmployeeResponseDTO>();

        // Favourite Course mappings
        CreateMap<FavouriteCourse, FavouriteCourseDTO>();
        CreateMap<FavouriteCourseDTO, FavouriteCourse>();
        CreateMap<FavouriteCourse, FavouriteCourseResponseDTO>();

        // Learning Streak mappings
        CreateMap<LearningStreak, LearningStreakDTO>();
        CreateMap<LearningStreakDTO, LearningStreak>();
        CreateMap<LearningStreak, LearningStreakResponseDTO>();

        // Course Material mappings
        CreateMap<CourseMaterial, CourseMaterialDTO>();
        CreateMap<CourseMaterialDTO, CourseMaterial>();
        CreateMap<CourseMaterial, CourseMaterialResponseDTO>();

        // Quiz mappings
        CreateMap<Quizz, QuizzDTO>();
        CreateMap<QuizzDTO, Quizz>();
        CreateMap<Quizz, QuizzResponseDTO>();

        // Question mappings
        CreateMap<Question, QuestionDTO>();
        CreateMap<QuestionDTO, Question>();
        CreateMap<Question, QuestionResponseDTO>();
    }
}
