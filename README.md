# Micro-services Demo Project
Project chia sẻ cách viết và triển khai 1 dự án sử dụng micro-services kết hợp với mô hình Domain Driven Design. Mục tiêu giúp làm quen với cách tổ chức và tích hợp các thành phần trong kiến trúc micro-services. 

## Kiến trúc triển khai

![Architecture](/Architecture.png?raw=true "Software Architecture")

## Use case (demo)
Business case sử dụng để làm ví dụ:
![Architecture](/UseCase.png?raw=true "Use cases")

```mermaid
sequenceDiagram
User ->> Web: Xem danh sách products
Web ->> Product Service: ListProducts
Product Service ->> Web: Products
Note right of User: User quyết định chọn <br/> 1 sản phẩm để mua
User ->> Web: Đặt hàng
Web ->> Order Service: PlaceOrder
Web -->> Web: Mở trang thanh toán Order
Note right of User: User quyết định <br/> thanh toán đơn hàng
User ->> Web: Thanh toán
Web -->> Payment Service: Pay
Payment Service->> Payment Service: Validate payment
Payment Service-->> Order Service: Payment Received Event
Order Service->> Order Service: Update Order status to PAID
Order Service-->> Web: Order Paid Successfully Event
```

## Bounded context
Tư duy Bounded context được áp dụng để phân tách các micro-services.

## Công nghệ 
Các công nghệ sử dụng trong project:
 - Backend
	- *Web API*
	- *.NET Core (2.1)*
	- *SQLite*
 - Fontend: *ASP.NET Core MVC (Razor view)*
 - Unit test
	 - *NUnit3*
	 - *Moq*
- CI: *Travis CI*
 - Deployment
	 - *Docker*
	 - *VM*
 - Queuing: *Rabbit MQ*
 - Service Discovery: *Zookeeper*

