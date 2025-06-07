# HookedUp Backend API

HookedUp is a backend RESTful API built with **ASP.NET Core 8** and **Entity Framework Core** that powers a platform for matching clients and artists on project requests, reviews, messaging, and user management. It offers full CRUD functionality across multiple resources with an in-memory database for testing and easy horizontal scalability.

---

## Ideal User

HookedUp is designed for creative project coordinators, freelance artists, and clients who need a centralized system to:

* Submit and track project requests
* Manage artist profiles and portfolios
* Leave ratings and reviews for completed work
* Communicate directly via messaging
* Handle user registration and roles

Whether you’re an art director coordinating assignments or a freelancer showcasing your expertise, HookedUp simplifies collaboration and feedback.

---

## Setup Instructions

### 1. Clone the Repo

```bash
git clone https://github.com/your-username/HookedUp.git  
cd HookedUp
```

### 2. Configure the Database

HookedUp uses SQLite by default for simplicity. In `appsettings.json`, ensure you have:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=hookedup.db"
}
```

For production, swap to PostgreSQL or SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=...;Port=...;Database=HookedUp;Username=...;Password=..."
}
```

### 3. Apply Migrations & Run

```bash
cd HookedUp
dotnet ef database update
dotnet run
```

Browse the API docs at `https://localhost:5001/swagger`.

---

## API Endpoints

### Project Requests

* `GET    /projectrequests`                 – List all project requests
* `GET    /projectrequests/{id}`            – Retrieve a single request by ID
* `POST   /projectrequests`                 – Create a new request
* `PUT    /projectrequests/{id}`            – Update an existing request
* `DELETE /projectrequests/{id}`            – Delete a request

### Artist Profiles

* `GET    /artistprofiles`                 – List all artist profiles
* `GET    /artistprofiles/{id}`            – Get profile by ID
* `POST   /artistprofiles`                 – Create a profile
* `PUT    /artistprofiles/{id}`            – Update a profile
* `DELETE /artistprofiles/{id}`            – Remove a profile

### Users

* `GET    /users`                          – List all users
* `GET    /users/{id}`                     – Get user by ID
* `POST   /users`                          – Register a new user
* `PUT    /users/{id}`                     – Update user info
* `DELETE /users/{id}`                     – Delete a user

### Review & Ratings

* `GET    /reviewratings`                  – List all reviews
* `GET    /reviewratings/{id}`             – Retrieve review by ID
* `POST   /reviewratings`                  – Create a review/rating
* `PUT    /reviewratings/{id}`             – Update review/rating
* `DELETE /reviewratings/{id}`             – Delete a review

### Direct Messages

* `GET    /directmessages`                 – Get all messages
* `GET    /directmessages/{id}`            – Get message by ID
* `GET    /directmessages/sender/{sender}` – Messages sent by a user
* `GET    /directmessages/receiver/{receiv}` – Messages received by a user
* `POST   /directmessages`                 – Send a new message
* `PUT    /directmessages/{id}`            – Update a message
* `DELETE /directmessages/{id}`            – Delete a message

---

## Unit Testing

Unit tests use **xUnit**, **FluentAssertions**, and EF Core InMemory to verify CRUD operations for each resource:

```bash
cd HookedUp.Tests
dotnet test
```

Test coverage includes:

*  Create, read, update, delete flows for all endpoints
*  Model validation and HTTP status codes
*  Isolation with in-memory database

---

## Tech Stack

* **.NET 8.0** with Minimal APIs
* **Entity Framework Core** (InMemory + SQLite/PostgreSQL)
* **Swagger/OpenAPI** for interactive documentation
* **xUnit** + **FluentAssertions** for testing

---

## Future Improvements

* Authentication & role-based authorization
* Pagination, filtering, and sorting
* Full-text search on descriptions
* File storage for images (S3, Azure Blob)

---

## Contributing

1. Fork the repo
2. Create a branch: `git checkout -b feature/name`
3. Commit your changes: `git commit -m "Add feature"`
4. Push branch: `git push origin feature/name`
5. Open a Pull Request

---

## Loom Video
Coming Soon

## ERD

https://dbdiagram.io/d/Hooked-Up-682bd27a1227bdcb4e0c5c32

## Postman Documentation

https://documenter.getpostman.com/view/36778695/2sB2x2Luhp

## Project Board

https://github.com/users/sirenabailie/projects/5

## Contributors

https://github.com/sirenafoster

## License

This project is licensed under the **MIT License**. Feel free to use and modify.
