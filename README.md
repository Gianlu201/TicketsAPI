# TicketAPI

API REST sviluppata con .NET 8 che gestisce utenti, artisti, eventi e biglietti. Supporta registrazione e login sicuro tramite JWT + token di refresh e consente agli utenti autenticati di acquistare biglietti e recuperare i propri acquisti.

---

## Sommario
- [Caratteristiche principali](#caratteristiche-principali)  
- [Tecnologie](#tecnologie)  
- [Architettura](#architettura)  
- [Modelli principali / Schema DB (concept)](#modelli-principali--schema-db-concept)  
- [Endpoint principali (mappa logica e esempi)](#endpoint-principali-mappa-logica-e-esempi)  
- [Autenticazione e flusso JWT](#autenticazione-e-flusso-jwt)  
- [Installazione & Esecuzione (sviluppo)](#installazione--esecuzione-sviluppo)    
- [Migrazioni EF Core](#migrazioni-ef-core)  
- [Considerazioni di sicurezza](#considerazioni-di-sicurezza)  

---

## Caratteristiche principali
- Registrazione utente e login con JWT (access token) + refresh token.  
- CRUD per **Artist** e **Event** (creazione, modifica, cancellazione, lettura).  
- Acquisto di biglietti associati a eventi.  
- Endpoint che restituisce i biglietti acquistati dall'account autenticato.  
- Documentazione API (Swagger) e ambiente configurabile via `appsettings.json`.

---

## Tecnologie
- .NET 8 (C#) — Web API (ASP.NET Core)  
- Entity Framework Core (migrations, DbContext)  
- JWT Bearer Authentication  
- AutoMapper (per DTO <-> Modello), FluentValidation (opzionale per DTO)  
- Swashbuckle (Swagger) per documentazione API  
- Database: SQL Server (configurabile tramite connection string)  

---

## Architettura
- `Controllers/` — espone gli endpoint REST  
- `Services/` — logica di business  
- `Repositories/` — accesso a DB tramite EF Core  
- `Models/` — entità EF Core  
- `DTOs/` — oggetti per request/response  
- `Migrations/` — migrazioni EF Core  
- `Program.cs` — bootstrap e registrazione servizi

---

## Modelli principali / Schema DB (concept)

**User**
- `Id`  
- `Email`  
- `PasswordHash`  
- `Role`  
- `RefreshTokens`

**Artist**
- `Id`  
- `Name`  
- `Bio`  
- `Website`

**Event**
- `Id`  
- `Title`  
- `Description`  
- `ArtistId`  
- `Venue`  
- `StartDate`  
- `EndDate`  
- `AvailableSeats`  
- `Price`

**Ticket**
- `Id`  
- `EventId`  
- `UserId`  
- `PurchaseDate`  
- `SeatNumber`  
- `PricePaid`

---

## Endpoint principali (mappa logica e esempi)

### Autenticazione
- `POST /api/auth/register`  
- `POST /api/auth/login`  
- `POST /api/auth/refresh`  

### Artist
- `GET /api/artists`  
- `GET /api/artists/{id}`  
- `POST /api/artists`  
- `PUT /api/artists/{id}`  
- `DELETE /api/artists/{id}`  

### Event
- `GET /api/events`  
- `GET /api/events/{id}`  
- `POST /api/events`  
- `PUT /api/events/{id}`  
- `DELETE /api/events/{id}`  

### Ticket
- `POST /api/events/{eventId}/tickets`  
- `GET /api/tickets`  
- `GET /api/tickets/{id}`  

---

## Autenticazione e flusso JWT
1. Registrazione con `/api/auth/register`  
2. Login con `/api/auth/login` → restituisce `accessToken` e `refreshToken`  
3. Access token usato come `Authorization: Bearer <jwt>`  
4. Refresh token scambia il token scaduto con uno nuovo  
5. I refresh token devono essere memorizzati e gestiti in sicurezza  

---

## Installazione & Esecuzione (sviluppo)
```bash
git clone https://github.com/Gianlu201/Progetto_S19-L5.git
cd Progetto_S19-L5
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

Swagger: `https://localhost:5001/swagger`

---

## Migrazioni EF Core
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Considerazioni di sicurezza
- Non committare chiavi JWT o credenziali DB  
- Usare HTTPS sempre  
- Validare ogni input lato server  
- Gestire revoca refresh token  
- Proteggere endpoint con policy/ruoli  

---
