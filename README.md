# Football Forum Project

Bu proje, Türkiye'deki futbol severler için geliştirilmiş bir forum platformudur. Kullanıcılar takımlar hakkında tartışabilir, maçları yorumlayabilir ve canlı maç sohbetlerine katılabilirler.

## Özellikler

- 👤 Kullanıcı Yönetimi (Authentication & Authorization)
  - Kayıt olma
  - Giriş yapma
  - JWT tabanlı kimlik doğrulama

- ⚽ Takım Yönetimi
  - Takım oluşturma
  - Takım bilgilerini görüntüleme
  - Takım listesi

- 📝 Forum Özellikleri
  - Takıma özel tartışma forumları
  - Post oluşturma
  - Yorum yapma

- 🏟️ Maç Yönetimi
  - Maç oluşturma
  - Maç detayları
  - Maç sonuçları

- 💬 Canlı Sohbet
  - SignalR ile gerçek zamanlı sohbet
  - Maça özel sohbet odaları
  - Anlık mesajlaşma

## Teknolojiler

- .NET 8
- Entity Framework Core
- SQL Server
- SignalR
- JWT Authentication
- Swagger/OpenAPI

## Proje Yapısı

```
FootballForum/
├── src/
│   ├── Core/
│   │   ├── FootballForum.Domain/
│   │   └── FootballForum.Application/
│   ├── Infrastructure/
│   │   ├── FootballForum.Infrastructure/
│   │   └── FootballForum.Persistence/
│   └── FootballForum.WebAPI/
```

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/kullanıcı-adı/FootballForum.git
```

2. Veritabanını oluşturun:
```bash
Update-Database
```

3. API'yi çalıştırın:
```bash
dotnet run --project src/FootballForum.WebAPI
```

4. Swagger UI'a erişin:
```
https://localhost:{port}/swagger
```

## API Endpoints

### Auth
- POST /api/Auth/register - Yeni kullanıcı kaydı
- POST /api/Auth/login - Kullanıcı girişi

### Teams
- GET /api/Team - Tüm takımları listele
- GET /api/Team/{id} - Takım detayı
- POST /api/Team - Yeni takım oluştur
- PUT /api/Team/{id} - Takım güncelle
- DELETE /api/Team/{id} - Takım sil

### Posts
- GET /api/Post - Tüm postları listele
- GET /api/Post/{id} - Post detayı
- POST /api/Post - Yeni post oluştur
- PUT /api/Post/{id} - Post güncelle
- DELETE /api/Post/{id} - Post sil

### Comments
- GET /api/Comment - Tüm yorumları listele
- POST /api/Comment - Yeni yorum oluştur
- PUT /api/Comment/{id} - Yorum güncelle
- DELETE /api/Comment/{id} - Yorum sil

### Matches
- GET /api/Match - Tüm maçları listele
- GET /api/Match/{id} - Maç detayı
- POST /api/Match - Yeni maç oluştur
- PUT /api/Match/{id} - Maç güncelle
- DELETE /api/Match/{id} - Maç sil

## Canlı Sohbet

Maç sohbet odalarına katılmak için:
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

await connection.start();
await connection.invoke("JoinMatch", matchId);
```

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır.