# 📚 MyLibrary – Desktop Application with Database Integration
## 🧑‍💻 Author
**[Yonas Tilahun]**  
**[DBU 1501577]** 
**Year**: 3rd Year Information Systems   
[yonitilahun1221@gmail.com]
**Course**: Event-Driven Programming with C#    
**Submission Date**: June 2, 2025

---

## 📖 Overview

**MyLibrary** is a Windows Forms desktop application developed in C# using the .NET framework. The application helps a small library manage its books and borrower records, implementing key event-driven programming principles and database integration using ADO.NET.

---

## 🎯 Features

### 🔐 Login System
- Secure login screen using a `Users` table.
- Redirects to the main application on successful login.
- Displays error on invalid credentials.

### 📚 Books Management
- View all books in a `DataGridView`.
- Add, edit, and delete books.
- Input validation for title, author, year, and available copies.

### 👤 Borrowers Management
- Manage library members: view, add, edit, and delete borrowers.
- Input validation for name, email, and phone number.

### 🔄 Issue/Return System
- Issue a book to a borrower (decrements `AvailableCopies`).
- Return a book (increments `AvailableCopies`).
- Tracks issued books in an `IssuedBooks` table with `IssueDate` and `DueDate`.

### 📊 Bonus Features
- Filter books by author or year range.
- Generate a report of overdue books (`DueDate < Today`).

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET (WinForms)
- **Database:** SQLite (can be changed to SQL Server or MySQL)
- **Data Access:** ADO.NET (with parameterized queries)
- **IDE:** Visual Studio 2022+

---

## 💽 Database Setup

1. Ensure SQLite is installed or your chosen database engine is ready.
2. Run the `database.sql` script located in `/db/` to create and seed all required tables:
    - `Users`
    - `Books`
    - `Borrowers`
    - `IssuedBooks`

---

## 🚀 Getting Started

### ✅ Prerequisites

- Visual Studio 2022 or later
- .NET Desktop Development workload
- SQLite NuGet packages (if using SQLite)

### 🔧Build and Run

1. Clone this repository:

    ```bash
    git clone https://github.com/your-username/mylibrary.git
    ```

2. Open the `.sln` file in Visual Studio.
3. Restore NuGet packages (right-click on solution > Restore NuGet Packages).
4. Build the solution (Ctrl + Shift + B).
5. Run the application (F5 or green Start button).

---

## 🔑 Default Login Credentials
Username: yoni
Password: yoni20

These credentials are seeded in the `Users` table. You can modify them in the `database.sql` file or via the database directly.

---

## 🖼️ Screenshots

All major screens are captured and available in the `/docs/screenshots/` folder.

| Screen | Preview |
|--------|---------|
| Login  | ![Login](docs/screenshots/login.png) |
| Main Window | ![Main](docs/screenshots/main_window.png) |
| Books Management | ![Books](docs/screenshots/books.png) |
| Borrowers Management | ![Borrowers](docs/screenshots/borrowers.png) |
| Issue Book | ![Issue](docs/screenshots/issue.png) |
| Return Book | ![Return](docs/screenshots/return.png) |
| Overdue Report | ![Overdue](docs/screenshots/overdue.png) |

---

## 📂 Project Structure

/MyLibrary
├── /bin
├── /db
│ └── database.sql
├── /docs
│ └── /screenshots
├── /Forms
│ ├── LoginForm.cs
│ ├── MainForm.cs
│ ├── BookForm.cs
│ ├── BorrowerForm.cs
│ ├── IssueForm.cs
│ └── ReturnForm.cs
├── /Models
│ └── Book.cs, Borrower.cs, User.cs, IssuedBook.cs
├── /DAL
│ └── DbHelper.cs, BookRepository.cs, etc.
├── Program.cs
└── MyLibrary.csproj

---

## ✅ Validation & Error Handling

- All inputs validated (e.g., non-empty fields, numeric ranges, email format).
- Exception handling on all DB operations using `try-catch`.
- User-friendly error messages are displayed via MessageBoxes.

---


