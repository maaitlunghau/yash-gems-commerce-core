# 🗺️ ROADMAP — YashGems Commerce Demo Project (Revised)

> **Mục tiêu:** Demo 5 tính năng commerce core trên Clean Architecture đơn giản (.NET 8)
> **Stack:** .NET 8 · Clean Architecture · EF Core · MySQL · RabbitMQ · QuestPDF

---

## 🏗️ Kiến trúc Clean Architecture (Đơn giản)

```
YashGems.Commerce.Domain         → Entities, Repository Interfaces
YashGems.Commerce.Application    → Services (Logic), DTOs, Service Interfaces
YashGems.Commerce.Infrastructure → EF Core, Repositories, External APIs, Background Jobs
YashGems.Commerce.Api            → Controllers, Middleware, DI Configuration
```

---

## 📋 DANH SÁCH CÁC BƯỚC (Incremental Approach)

### PHASE 0 — Nền tảng (Foundation)
*Chỉ cài đặt và cấu hình đủ để kết nối Database.*

| Bước | Nội dung | Layer chính |
|------|----------|------------|
| 0.1 | Thiết kế base classes (BaseEntity) | Domain |
| 0.2 | Setup project references giữa các layer | Solution |
| 0.3 | Cấu hình MySQL connection + DbContext | Infrastructure |
| 0.4 | Chạy migration đầu tiên (Initial) | Infrastructure |

---

### PHASE 1 — Quản lý Danh mục (Category Management)

| Bước | Nội dung | Layer chính |
|------|----------|------------|
| 1.1 | Tạo Entities: Category, JewelType, Brand, GoldKarat, Certification | Domain |
| 1.2 | Tạo Repository Interfaces cho các thực thể trên | Domain |
| 1.3 | Viết Service xử lý Logic CRUD | Application |
| 1.4 | Implement Repositories với EF Core | Infrastructure |
| 1.5 | Tạo Controllers + Endpoints API | Api |
| 1.6 | Seed data mẫu (18K/22K, nhẫn/dây chuyền...) | Infrastructure |

---

### PHASE 2 — Quản lý Sản phẩm (Product Management)

| Bước | Nội dung | Layer chính |
|------|----------|------------|
| 2.1 | Tạo Entity Product (ItemMst) + Diamond (DimMst) + Stone (StoneMst) | Domain |
| 2.2 | Tạo IProductRepository | Domain |
| 2.3 | Viết ProductService (chứa logic tính MRP cơ bản) | Application |
| 2.4 | Implement ProductRepository | Infrastructure |
| 2.5 | Tạo ProductsController | Api |

---

### PHASE 3 — Cập nhật giá vàng tự động (Gold Price Background Job)

| Bước | Nội dung | Layer chính |
|------|----------|------------|
| 3.1 | Tạo Entity GoldPrice lưu lịch sử | Domain |
| 3.2 | Implement GoldPriceApiClient (gọi API mock) | Infrastructure |
| 3.3 | Cấu hình RabbitMQ & MassTransit để xử lý Job cập nhật | Infrastructure |
| 3.4 | Logic Background Job: Cập nhật giá sản phẩm hàng loạt | Application/Infra |

---

### PHASE 4 — Generate Certificate PDF

| Bước | Nội dung | Layer chính |
|------|----------|------------|
| 4.1 | Cài đặt QuestPDF & thiết kế template | Infrastructure |
| 4.2 | Implement Certificate Service (Xuất PDF từ ID đơn hàng/sản phẩm) | Infrastructure |
| 4.3 | Endpoint lấy file PDF | Api |

---

### PHASE 5 — Search & Filter nâng cao

| Bước | Nội dung | Layer chính |
|------|----------|------------|
| 5.1 | Viết logic Search/Filter dynamic trong Product Service | Application |
| 5.2 | Thêm Pagination & Sorting | Application |
| 5.3 | Endpoint tìm kiếm nâng cao | Api |

---

## 🗂️ Commit Convention

Format: `type(scope): mô tả ngắn`

Ví dụ: `feat(domain): add Category entity`

---

> Quy tắc: Làm tới đâu, cài tới đó. Xong từng bước mới qua bước tiếp theo.
