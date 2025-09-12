# Nihon4U - Online Japanese Learning Platform

## Tổng quan
Nihon4U là một nền tảng học tiếng Nhật trực tuyến được xây dựng bằng ASP.NET Core 8.0 với kiến trúc Clean Architecture.

## Kiến trúc dự án

### 1. Models
- **Entities**: Các entity chính của hệ thống
- **DTOs**: Data Transfer Objects cho việc truyền dữ liệu
- **Enums**: Các enum cho trạng thái (Status) của các entity

### 2. Mappers
- **AutoMapperProfile**: Cấu hình mapping giữa Entity và DTO

### 3. Services
- **Interfaces**: Định nghĩa contract cho các service
- **Implementations**: Triển khai business logic

### 4. Controllers
- **API Controllers**: Các endpoint RESTful API

## Các chức năng chính

### 1. Quản lý Khóa học (Courses)
- Tạo, sửa, xóa khóa học
- Tìm kiếm khóa học theo từ khóa
- Lọc khóa học theo trạng thái, level (N5-N1)
- Quản lý combo courses

### 2. Quản lý Khách hàng (Customers)
- Đăng ký, cập nhật thông tin khách hàng
- Quản lý trạng thái khách hàng
- Tìm kiếm khách hàng

### 3. Quản lý Đơn hàng (Orders)
- Tạo, cập nhật đơn hàng
- Quản lý trạng thái đơn hàng và thanh toán
- Thống kê doanh thu

### 4. Quản lý Đăng ký khóa học (Course Enrollments)
- Đăng ký khách hàng vào khóa học
- Quản lý trạng thái đăng ký
- Kiểm tra trạng thái đăng ký

### 5. Quản lý Giỏ hàng (Cart)
- Thêm, sửa, xóa sản phẩm trong giỏ hàng
- Tính tổng tiền giỏ hàng
- Quản lý session giỏ hàng

## Cấu hình Database

### Connection String
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Nihon4UDb;Uid=root;Pwd=123456;Port=3306;"
  }
}
```

### Entity Framework Migrations
```bash
# Tạo migration
dotnet ef migrations add InitialCreate

# Cập nhật database
dotnet ef database update
```

## API Endpoints

### Courses
- `GET /api/courses` - Lấy tất cả khóa học
- `GET /api/courses/{id}` - Lấy khóa học theo ID
- `GET /api/courses/status/{status}` - Lấy khóa học theo trạng thái
- `GET /api/courses/level/{level}` - Lấy khóa học theo level
- `GET /api/courses/combo` - Lấy combo courses
- `GET /api/courses/search?keyword={keyword}` - Tìm kiếm khóa học
- `POST /api/courses` - Tạo khóa học mới
- `PUT /api/courses/{id}` - Cập nhật khóa học
- `DELETE /api/courses/{id}` - Xóa khóa học
- `PATCH /api/courses/{id}/status` - Thay đổi trạng thái khóa học

### Customers
- `GET /api/customers` - Lấy tất cả khách hàng
- `GET /api/customers/{id}` - Lấy khách hàng theo ID
- `GET /api/customers/user/{userId}` - Lấy khách hàng theo User ID
- `GET /api/customers/status/{status}` - Lấy khách hàng theo trạng thái
- `GET /api/customers/search?keyword={keyword}` - Tìm kiếm khách hàng
- `POST /api/customers` - Tạo khách hàng mới
- `PUT /api/customers/{id}` - Cập nhật khách hàng
- `DELETE /api/customers/{id}` - Xóa khách hàng
- `PATCH /api/customers/{id}/status` - Thay đổi trạng thái khách hàng

### Orders
- `GET /api/orders` - Lấy tất cả đơn hàng
- `GET /api/orders/{id}` - Lấy đơn hàng theo ID
- `GET /api/orders/customer/{customerId}` - Lấy đơn hàng theo khách hàng
- `GET /api/orders/status/{status}` - Lấy đơn hàng theo trạng thái
- `GET /api/orders/payment-status/{paymentStatus}` - Lấy đơn hàng theo trạng thái thanh toán
- `GET /api/orders/date-range?startDate={date}&endDate={date}` - Lấy đơn hàng theo khoảng thời gian
- `GET /api/orders/revenue/total` - Lấy tổng doanh thu
- `POST /api/orders` - Tạo đơn hàng mới
- `PUT /api/orders/{id}` - Cập nhật đơn hàng
- `DELETE /api/orders/{id}` - Xóa đơn hàng
- `PATCH /api/orders/{id}/status` - Thay đổi trạng thái đơn hàng
- `PATCH /api/orders/{id}/payment-status` - Thay đổi trạng thái thanh toán

### Course Enrollments
- `GET /api/courseenrollments` - Lấy tất cả đăng ký
- `GET /api/courseenrollments/{id}` - Lấy đăng ký theo ID
- `GET /api/courseenrollments/customer/{customerId}` - Lấy đăng ký theo khách hàng
- `GET /api/courseenrollments/customer/{customerId}/active` - Lấy đăng ký active theo khách hàng
- `GET /api/courseenrollments/course/{courseId}` - Lấy đăng ký theo khóa học
- `GET /api/courseenrollments/status/{status}` - Lấy đăng ký theo trạng thái
- `GET /api/courseenrollments/check?customerId={id}&courseId={id}` - Kiểm tra đăng ký
- `POST /api/courseenrollments` - Tạo đăng ký mới
- `POST /api/courseenrollments/enroll` - Đăng ký khách hàng vào khóa học
- `PUT /api/courseenrollments/{id}` - Cập nhật đăng ký
- `DELETE /api/courseenrollments/{id}` - Xóa đăng ký
- `PATCH /api/courseenrollments/{id}/status` - Thay đổi trạng thái đăng ký

### Cart
- `GET /api/cart/customer/{customerId}` - Lấy giỏ hàng theo khách hàng
- `GET /api/cart/customer/{customerId}/items` - Lấy giỏ hàng với items
- `POST /api/cart/customer/{customerId}` - Tạo giỏ hàng mới
- `POST /api/cart/customer/{customerId}/items` - Thêm item vào giỏ hàng
- `PUT /api/cart/items/{cartItemId}` - Cập nhật số lượng item
- `DELETE /api/cart/items/{cartItemId}` - Xóa item khỏi giỏ hàng
- `DELETE /api/cart/customer/{customerId}` - Xóa toàn bộ giỏ hàng
- `GET /api/cart/customer/{customerId}/total` - Lấy tổng tiền giỏ hàng
- `GET /api/cart/customer/{customerId}/count` - Lấy số lượng items
- `GET /api/cart/customer/{customerId}/check?courseId={id}` - Kiểm tra item trong giỏ hàng

## Các Enum Status

### CourseStatus
- Pending = 0
- Active = 1
- Inactive = 2
- Draft = 3
- Archived = 4

### CustomerStatus
- Pending = 0
- Active = 1
- Inactive = 2
- Suspended = 3
- Banned = 4

### OrderStatus
- Pending = 0
- Confirmed = 1
- Processing = 2
- Shipped = 3
- Delivered = 4
- Cancelled = 5
- Refunded = 6

### PaymentStatus
- Pending = 0
- Paid = 1
- Failed = 2
- Refunded = 3
- Cancelled = 4

### EnrollmentStatus
- Pending = 0
- Active = 1
- Completed = 2
- Suspended = 3
- Cancelled = 4

## Cài đặt và chạy dự án

1. **Clone repository**
```bash
git clone <repository-url>
cd Nihon4U
```

2. **Cài đặt dependencies**
```bash
dotnet restore
```

3. **Cấu hình database**
- Cập nhật connection string trong `appsettings.json`
- Tạo database MySQL
- Chạy migrations

4. **Chạy dự án**
```bash
dotnet run
```

5. **Truy cập Swagger UI**
- Mở trình duyệt và truy cập: `https://localhost:7000/swagger`

## Công nghệ sử dụng

- **.NET 8.0**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **MySQL Database**
- **AutoMapper**
- **Swagger/OpenAPI**

## Cấu trúc thư mục

```
Nihon4U/
├── Controllers/          # API Controllers
├── Data/                # DbContext và cấu hình database
├── Mappers/             # AutoMapper profiles
├── Models/              # Entities, DTOs, Enums
│   ├── DTO/
│   │   ├── EntitiesDTO/
│   │   ├── RequestDTO/
│   │   └── ResponseDTO/
│   ├── Entities/
│   └── Enums/
├── Services/            # Business logic
│   └── Interfaces/
└── Program.cs           # Entry point và cấu hình services
```

## Lưu ý

- Tất cả các entity đều kế thừa từ `BaseEntity` với các trường audit cơ bản
- Sử dụng enum cho các trạng thái thay vì string để đảm bảo type safety
- Service layer chứa toàn bộ business logic, Controller chỉ xử lý HTTP requests
- AutoMapper được sử dụng để mapping giữa Entity và DTO
- Entity Framework được cấu hình với MySQL và lazy loading
