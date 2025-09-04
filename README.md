# ECommerce_TG

ECommerce_TG, modern yazılım geliştirme prensiplerine uygun olarak hazırlanmış bir **E-Ticaret Backend** projesidir.  
Proje geliştirilirken **Clean Architecture**, **CQRS (Command Query Responsibility Segregation)** ve **Domain Driven Design (DDD)** yaklaşımları benimsenmiştir.  

---

## Mimari Yapı

Proje, katmanlı bir mimariye sahiptir:

- **ECommerce_TG.API**  
  Uygulamanın giriş noktasıdır. HTTP isteklerini karşılayan Web API katmanıdır.  

- **ECommerce_TG.Application**  
  İş mantığının uygulandığı katmandır. CQRS patternine uygun şekilde Command ve Query handler’larını içerir.  

- **ECommerce_TG.Domain**  
  İş kurallarının ve domain modellerinin bulunduğu katmandır. DDD prensiplerine uygun olarak saf domain nesnelerini barındırır.  

- **ECommerce_TG.Infrastructure**  
  Veritabanı işlemlerini yöneten katmandır. Entity Framework Core kullanılarak repository ve migration yönetimi burada yapılır.  

- **ECommerce_TG.SharedKernel**  
  Katmanlar arasında paylaşılan ortak bileşenleri içerir.  

---

## Kullanılan Teknolojiler

- .NET 8  
- Entity Framework Core  
- MSSQL Server 2022  
- Docker & Docker Compose  

---

## Kurulum ve Çalıştırma

1. Depoyu klonlayın  
   git clone https://github.com/kullaniciadi/ECommerce_TG.git  
   cd ECommerce_TG  

2. Docker servislerini ayağa kaldırın  
   docker-compose up --build  

3. Erişim Bilgileri  
   - API: http://localhost:5000  
   - MSSQL Server: localhost,1433  
     - Kullanıcı Adı: sa  
     - Parola: Your_password123  

---

## Veritabanı Yönetimi

- Projede yer alan migration’lar, uygulama başlatıldığında otomatik olarak uygulanır.  
- InsertData metotları ile tanımlanan başlangıç verileri de tabloya eklenmektedir.  
- Veritabanı bağlantısı appsettings.json dosyasında aşağıdaki connection string ile yapılandırılmıştır:  

  Server=db;Database=ECommerceTG;User=sa;Password=Your_password123;TrustServerCertificate=True;  

---

## Geliştirici Notları

- Geliştirme ortamında ASPNETCORE_ENVIRONMENT=Development olarak çalışmaktadır.  
- Farklı ortamlar için (Test, Production) appsettings.{Environment}.json dosyaları kullanılabilir.  
- CQRS patterni sayesinde, sorgular (Query) ile komutlar (Command) birbirinden ayrılmıştır.  
 
