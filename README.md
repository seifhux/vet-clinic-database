# 🐾 VetClinic: Full Database Project

A complete veterinary clinic management database, built end to end: from conceptual modeling in **PowerDesigner**, to a physical schema in **SQL Server**, to a **C# Windows Forms** desktop application that connects to it through **ADO.NET** and presents six analytical inquiry reports.

Developed as a university database systems project (May 2026) at the Faculty of Computer Science and Artificial Intelligence, Cairo University.

---

## 📑 Table of Contents

1. [Overview](#-overview)
2. [Tech Stack](#-tech-stack)
3. [System Architecture](#-system-architecture)
4. [Database Design](#-database-design)
5. [Desktop Application](#-desktop-application)
6. [Analytical Inquiry Reports](#-analytical-inquiry-reports)
7. [Project Structure](#-project-structure)
8. [Getting Started](#-getting-started)
9. [Screenshots](#-screenshots)
10. [What I Learned](#-what-i-learned)
11. [Future Improvements](#-future-improvements)
12. [Author](#-author)

---

## 📖 Overview

Veterinary clinics handle a lot of connected information: owners, their pets, visits, treatments, and billing. This project models that workflow in a relational database and exposes it through a desktop application so that the data can be queried and analyzed without writing SQL by hand.

The project covers the **full database development lifecycle**:

- **Conceptual and logical design:** ER modeling in PowerDesigner
- **Physical implementation:** SQL Server DDL scripts (tables, keys, constraints)
- **Data population:** sample data scripts for testing and demonstration
- **Application layer:** a C# Windows Forms app using ADO.NET
- **Analytics:** six inquiry reports that turn the stored data into useful answers

---

## 🛠 Tech Stack

| Layer | Technology |
|---|---|
| Data modeling | SAP PowerDesigner |
| Database | Microsoft SQL Server |
| Query language | T-SQL |
| Application | C# with Windows Forms (.NET) |
| Data access | ADO.NET |

---

## 🏗 System Architecture

```
┌─────────────────────────┐
│  C# Windows Forms UI    │   Forms, inputs, report views
└───────────┬─────────────┘
            │  ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter)
┌───────────▼─────────────┐
│     SQL Server          │   Tables, constraints, queries
└─────────────────────────┘
```

The UI never stores data itself. Every form reads from and writes to SQL Server through ADO.NET, so the database remains the single source of truth.

---

## 🗃 Database Design

### Modeling workflow

1. **Requirements:** identify what a vet clinic needs to store and the questions it needs answered
2. **ERD in PowerDesigner:** define entities, attributes, and relationships (the Conceptual Data Model)
3. **Physical model:** generate the relational structure with primary keys, foreign keys, and data types
4. **SQL Server DDL:** create the tables and constraints from the model
5. **Sample data:** populate every table with realistic fictional records

### Entities and schema

> 📝 *Fill in from your PowerDesigner model.*

| Table | Purpose | Key columns |
|---|---|---|
| [Table 1] | [what it stores] | [PK, important FKs] |
| [Table 2] | [what it stores] | [PK, important FKs] |
| [Table 3] | [what it stores] | [PK, important FKs] |
| [add more rows] | | |

### Relationships

> 📝 *List the main relationships, for example "one X has many Y".*

- [Entity A] → [Entity B]: [one-to-many / many-to-many], enforced by [foreign key]
- [add more]

### Entity Relationship Diagram

![ERD](docs/erd.png)

---

## 💻 Desktop Application

A Windows Forms application built in C# provides a user interface over the database.

**How it works**
- Connects to SQL Server using a connection string via `SqlConnection`
- Runs queries and commands with `SqlCommand` and fills grids using `SqlDataAdapter` / `DataTable`
- Displays results in forms and `DataGridView` controls
- Provides a dedicated screen for each analytical inquiry

> 📝 *Add anything else the app does, e.g. adding or editing records, search, validation.*

---

## 📊 Analytical Inquiry Reports

The application includes **six analytical inquiries** that answer business questions directly from the database.

| # | Inquiry | What it answers |
|---|---|---|
| 1 | [Name] | [question it answers] |
| 2 | [Name] | [question it answers] |
| 3 | [Name] | [question it answers] |
| 4 | [Name] | [question it answers] |
| 5 | [Name] | [question it answers] |
| 6 | [Name] | [question it answers] |

> 📝 *Optionally add the SQL behind one or two of the most interesting reports in a collapsible block.*

---

## 📂 Project Structure

> 📝 *Update to match your repository.*

```
VetClinic/
├── README.md
├── docs/
│   ├── erd.png
│   └── screenshots/
├── database/
│   ├── PowerDesigner model (.cdm / .pdm)
│   ├── create_tables.sql
│   └── insert_sample_data.sql
└── VetClinicApp/
    ├── VetClinicApp.sln
    └── (C# Windows Forms source)
```

---

## 🚀 Getting Started

### Prerequisites
- Windows
- Microsoft SQL Server (and SQL Server Management Studio)
- Visual Studio with the **.NET desktop development** workload

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/[your-username]/[repo-name].git
   ```
2. **Create the database**
   Open SSMS and run, in order:
   1. the table creation script
   2. the sample data script
3. **Configure the connection string**
   In the C# project, update the connection string with your server name:
   ```csharp
   string connectionString =
       "Data Source=YOUR_SERVER_NAME;Initial Catalog=[DatabaseName];Integrated Security=True";
   ```
4. **Run the app**
   Open the `.sln` file in Visual Studio, build the solution, and press **F5**.

### Troubleshooting
- **Cannot connect to the server:** check the server name in the connection string and that SQL Server is running
- **Login failed:** confirm Windows Authentication is enabled, or switch to a SQL login
- **Empty reports:** make sure the sample data script ran successfully

---

## 🖼 Screenshots

> 📝 *Add screenshots of the ERD, the main form, and each report to `docs/screenshots/`.*

| Main window | Report example |
|---|---|
| ![Main](docs/screenshots/main.png) | ![Report](docs/screenshots/report.png) |

---

## 🎓 What I Learned

- Translating real-world requirements into an ER model and then a normalized relational schema
- Using PowerDesigner to move from conceptual to physical design
- Writing SQL Server DDL with proper keys and constraints
- Connecting a desktop application to a database with ADO.NET
- Designing analytical queries that answer business questions

---

## 🔮 Future Improvements

- Add user roles and login (admin, vet, receptionist)
- Add appointment reminders
- Build a Power BI dashboard on top of the database
- Move data access to stored procedures for better security and reuse

---

## 👤 Author

**Seif Hussein Aboelazaim**
Computer Science and AI student, Cairo University (FCAI), aspiring Data Scientist

- LinkedIn: [linkedin.com/in/seifaboelazaim](https://linkedin.com/in/seifaboelazaim)
- Email: seifhuss74@gmail.com
