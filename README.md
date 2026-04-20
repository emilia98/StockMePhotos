# 🚀 StockMePhotos

> A short, one-sentence description of what this project does and its purpose.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Features](#features)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

---

## 📖 About the Project

This is a simple stock photos web application, that contains photos, categories and users.
The application is buil as a part of the *Asp.NET Fundamentals* course. 
It demonstrates core concepts like MVC architecture, EF Core, Identity and using a framework for UI/UX design, like Bootstrap.


---

## 🛠️ Technologies Used

| Technology            | Version  | Purpose                          |
|-----------------------|----------|----------------------------------|
| ASP.NET Core MVC      | 8.0      | Web framework                    |
| Entity Framework Core | 8.0      | ORM / Database access            |
| SQL Server / SQLite   | -        | Database                         |
| Bootstrap             | 5.3      | Frontend styling                 |
| Razor Pages / Views   | -        | Server-side HTML rendering       |

---

## ✅ Prerequisites

Make sure you have the following installed before running the project:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or SQLite (if used)
- [Git](https://git-scm.com/)

---

## 🚀 Getting Started

Follow these steps to get the project running locally.

### 1. Clone the repository

```bash
git clone https://github.com/emilia98/StockMePhotos
cd StockMePhotos/StockMePhotos
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Apply database migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

The app will be available at `https://localhost:5001` or `http://localhost:5000`.

---

## 📁 Project Structure

```
YourProjectName/
│
├── Controllers/          # MVC Controllers
├── Models/               # Domain models and ViewModels
├── Views/                # Razor Views (.cshtml)
├── Data/                 # DbContext and migrations
├── Services/             # Business logic / service layer
├── wwwroot/              # Static files (CSS, JS, images)
├── appsettings.json      # App configuration
└── Program.cs            # App entry point and middleware setup
```

---

## ✨ Features

- [ x ] User registration and login (ASP.NET Identity)
- [ x ] CRUD operations for [main entity]
- [ ] RESTful API endpoints
- [ x ] Input validation (server-side & client-side)
- [ x ] Responsive UI with Bootstrap

---

## 💻 Usage

Describe how to use the main features of the app after launching it. Add screenshots if possible.

```
1. Navigate to /Register to create an account.
  1.1 Or use the already seeded ones* (for each seeded user, there is data that corresponds to the user - added photos, favorite photos)
2. Log in at /Login.
3. You can use the 'Add Photo' button to add a new photo.
4. An already added photo can be updated by the user, that created it.
5. An already added photo can be deleted by the user, that created it.
6. As a logged-in user, you can see all the photos you've added.
6. All users (authorized or not) can see list of all the already added photos and details about each of the photo.
7. You can use the 'Favorites' to see all the photos, added to Favorites Collection.
8. You can add photo to 'Favorites', as a logged-in user.
9. You can remove photo from 'Favorites', as a logged-in user.
```
* Credentials for already seeded users:

| Username | Password |
| -------- | ------ |
| user1@example.com | user1.1234 |
| emilia@example.com | emilia.1234 |
| WhaTheFuck@example.com | WhaTheFuck.1234 |


> 💡 **Tip:** You can add screenshots using: `![Screenshot](docs/screenshot.png)`

---

## 🗄️ Database Setup

The project uses **Entity Framework Core** with a Code-First approach.

Connection string is configured in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultDevConnection": "Server=(localdb)\\MSSQLLocalDB;Database=StockMePhotosAppDB;Trusted_Connection=True;Encrypt=False;"
},
```

To create and seed the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ⚙️ Configuration

Key settings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string-here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "Cloudinary": {
    "CloudName": "",
    "ApiKey": "",
    "ApiSecret": ""
  }
}
```
**!!! I usually don't do that, but this time, left the API Key/API Secret for Cloudinary in the appsettings.json, that will be revoked, immediately after the project is reviewed. !!!**

> ⚠️ **Never commit sensitive data** (passwords, API keys) to source control. Use `appsettings.Development.json` or environment variables for local secrets.

---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add some feature"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📬 Contact

**Emilia Nedyalkova** – [emilia98](https://github.com/emilia98)

Project Link: [https://github.com/emilia98/StockMePhotos](https://github.com/emilia98/StockMePhotos)

---

*Built as part of the **ASP.NET Fundamentals** course.*
