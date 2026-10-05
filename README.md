# 🐾 Vet Clinic Database

A relational database system designed to manage the day-to-day operations of a veterinary clinic: owners, pets, veterinarians, appointments, medical records, treatments, medications, billing, and more.


---

## 📑 Table of Contents

1. [Overview](#-overview)
2. [Features](#-features)
3. [Tech Stack](#-tech-stack)
4. [Database Design](#-database-design)
5. [Entity Relationship Diagram](#-entity-relationship-diagram)
6. [Tables and Schema](#-tables-and-schema)
7. [Relationships and Constraints](#-relationships-and-constraints)
8. [Project Structure](#-project-structure)
9. [Getting Started](#-getting-started)
10. [Sample Data](#-sample-data)
11. [Example Queries](#-example-queries)
12. [Views, Stored Procedures, Functions and Triggers](#-views-stored-procedures-functions-and-triggers)
13. [Normalization](#-normalization)
14. [Business Rules](#-business-rules)
15. [Reporting and Analytics](#-reporting-and-analytics)
16. [Testing](#-testing)
17. [Future Improvements](#-future-improvements)
18. [Contributing](#-contributing)
19. [License](#-license)
20. [Author](#-author)

---

## 📖 Overview

**Problem:** Veterinary clinics often track owners, pets, visits, and payments on paper or in scattered spreadsheets. This leads to duplicated data, lost medical history, and double-booked appointments.

**Solution:** This project provides a normalized relational database that centralizes all clinic data and supports common operations such as scheduling appointments, recording diagnoses and treatments, tracking vaccinations, managing inventory, and generating invoices.

**Goals**
- Store clinic data consistently with no unnecessary redundancy
- Enforce data integrity through keys, constraints, and triggers
- Make common clinic questions answerable with simple queries
- Serve as a solid foundation for a future application or dashboard

---

## ✨ Features

- **Owner and pet management:** one owner can have many pets, with species, breed, birth date, and weight
- **Veterinarian and staff records:** specialties, schedules, and contact info
- **Appointment scheduling:** prevents double booking for the same vet and time slot
- **Medical records:** diagnoses, treatments, prescriptions, and notes per visit
- **Vaccination tracking:** history and upcoming due dates
- **Medication and inventory:** stock levels and low-stock alerts
- **Billing and payments:** itemized invoices, payment status, and methods
- **Reports:** revenue, busiest vets, most common diagnoses, overdue vaccinations

---

## 🛠 Tech Stack

| Component | Technology |
|---|---|
| Database engine | SQL Server |
| Language | SQL - C# |
| Modeling tool | PowerDesigner |

---

## 🧩 Database Design

The database follows these steps:

1. **Requirements analysis:** identifying the entities, actors, and workflows of a vet clinic
2. **Conceptual design:** an ER model with entities, attributes, and relationships
3. **Logical design:** mapping the ER model to relational tables
4. **Normalization:** to remove redundancy
5. **Physical design:** data types, keys, constraints, and indexes

---

## 🗺 Entity Relationship Diagram

![ERD](docs/erd.png)


**Main entities:** `Owner`, `Pet`, `Veterinarian`, `Appointment`, `MedicalRecord`, `Treatment`, `Medication`, `Prescription`, `Vaccination`, `Invoice`, `Payment`
*(Adjust to match your actual tables.)*

---

## 🗃 Tables and Schema

### `Owner`
| Column | Type | Constraints | Description |
|---|---|---|---|
| owner_id | INT | PK, auto-increment | Unique owner ID |
| first_name | VARCHAR(50) | NOT NULL | First name |
| last_name | VARCHAR(50) | NOT NULL | Last name |
| phone | VARCHAR(20) | NOT NULL, UNIQUE | Contact number |
| email | VARCHAR(100) | UNIQUE | Email address |
| address | VARCHAR(255) | | Home address |

### `Pet`
| Column | Type | Constraints | Description |
|---|---|---|---|
| pet_id | INT | PK | Unique pet ID |
| owner_id | INT | FK → Owner | Owner of the pet |
| name | VARCHAR(50) | NOT NULL | Pet name |
| species | VARCHAR(30) | NOT NULL | Dog, cat, bird, etc. |
| breed | VARCHAR(50) | | Breed |
| birth_date | DATE | | Date of birth |
| gender | CHAR(1) | CHECK (M/F) | Gender |
| weight_kg | DECIMAL(5,2) | CHECK (> 0) | Weight in kg |

### `Veterinarian`
| Column | Type | Constraints | Description |
|---|---|---|---|
| vet_id | INT | PK | Unique vet ID |
| full_name | VARCHAR(100) | NOT NULL | Vet name |
| specialty | VARCHAR(50) | | e.g. surgery, dermatology |
| phone | VARCHAR(20) | | Contact |
| hire_date | DATE | | Date hired |

### `Appointment`
| Column | Type | Constraints | Description |
|---|---|---|---|
| appointment_id | INT | PK | Unique appointment ID |
| pet_id | INT | FK → Pet | Pet being seen |
| vet_id | INT | FK → Veterinarian | Assigned vet |
| appointment_datetime | DATETIME | NOT NULL | Date and time |
| reason | VARCHAR(255) | | Reason for visit |
| status | VARCHAR(20) | CHECK (Scheduled/Completed/Cancelled) | Status |

### `MedicalRecord`
| Column | Type | Constraints | Description |
|---|---|---|---|
| record_id | INT | PK | Unique record ID |
| appointment_id | INT | FK → Appointment | Related visit |
| diagnosis | VARCHAR(255) | | Diagnosis |
| treatment | VARCHAR(255) | | Treatment given |
| notes | TEXT | | Additional notes |

### Other tables
[Add the remaining tables in the same format: `Medication`, `Prescription`, `Vaccination`, `Invoice`, `Payment`, etc.]

---

## 🔗 Relationships and Constraints

| Relationship | Type | Description |
|---|---|---|
| Owner → Pet | One-to-Many | An owner can have many pets |
| Pet → Appointment | One-to-Many | A pet can have many appointments |
| Veterinarian → Appointment | One-to-Many | A vet handles many appointments |
| Appointment → MedicalRecord | One-to-One / One-to-Many | Each visit produces a record |
| Medication ↔ Prescription | Many-to-Many | Via a junction table |

**Integrity rules**
- Primary keys on every table
- Foreign keys with `ON DELETE` / `ON UPDATE` rules: [RESTRICT / CASCADE]
- `NOT NULL`, `UNIQUE`, `CHECK`, and `DEFAULT` constraints for validation
- Indexes on frequently searched columns, e.g. `Pet(owner_id)`, `Appointment(appointment_datetime)`

---

## 📂 Project Structure

```
vet-clinic-database/
├── README.md
├── docs/
│   ├── erd.png                 # Entity relationship diagram
│   └── data-dictionary.md      # Full column descriptions
├── schema/
│   ├── 01_create_database.sql  # Create database
│   ├── 02_create_tables.sql    # Tables, keys, constraints
│   └── 03_create_indexes.sql   # Indexes
├── data/
│   └── 04_insert_sample_data.sql
├── programmability/
│   ├── views.sql
│   ├── stored_procedures.sql
│   ├── functions.sql
│   └── triggers.sql
├── queries/
│   ├── basic_queries.sql
│   └── analytical_queries.sql
└── tests/
    └── test_cases.sql
```

*(Update this tree to match your actual repository.)*

---

## 🚀 Getting Started

### Prerequisites
- [SQL Server 2019+ and SQL Server Management Studio / MySQL 8+ / PostgreSQL 14+]
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/[your-username]/vet-clinic-database.git
   cd vet-clinic-database
   ```

2. **Create the database**
   Run the scripts in this order:
   1. `schema/01_create_database.sql`
   2. `schema/02_create_tables.sql`
   3. `schema/03_create_indexes.sql`
   4. `data/04_insert_sample_data.sql`
   5. Scripts in `programmability/`

3. **Verify the setup**
   ```sql
   SELECT COUNT(*) FROM Owner;
   SELECT COUNT(*) FROM Pet;
   ```

---

## 🧪 Sample Data

The sample data script includes:
- [X] owners
- [X] pets across [dogs, cats, birds, etc.]
- [X] veterinarians
- [X] appointments and medical records

The data is fictional and intended for testing and demonstration only.

---

## 🔍 Example Queries

**1. All pets of a specific owner**
```sql
SELECT p.name, p.species, p.breed
FROM Pet p
JOIN Owner o ON p.owner_id = o.owner_id
WHERE o.last_name = 'Hassan';
```

**2. Upcoming appointments for a vet**
```sql
SELECT a.appointment_datetime, p.name AS pet_name, a.reason
FROM Appointment a
JOIN Pet p ON a.pet_id = p.pet_id
WHERE a.vet_id = 1
  AND a.status = 'Scheduled'
ORDER BY a.appointment_datetime;
```

**3. Number of appointments per veterinarian**
```sql
SELECT v.full_name, COUNT(a.appointment_id) AS total_appointments
FROM Veterinarian v
LEFT JOIN Appointment a ON v.vet_id = a.vet_id
GROUP BY v.full_name
ORDER BY total_appointments DESC;
```

**4. Most common diagnoses**
```sql
SELECT diagnosis, COUNT(*) AS occurrences
FROM MedicalRecord
GROUP BY diagnosis
ORDER BY occurrences DESC;
```

**5. Total revenue per month**
```sql
SELECT YEAR(payment_date) AS yr, MONTH(payment_date) AS mo, SUM(amount) AS revenue
FROM Payment
GROUP BY YEAR(payment_date), MONTH(payment_date)
ORDER BY yr, mo;
```

*(Adjust the syntax to your SQL dialect and replace with your real queries.)*

---

## ⚙️ Views, Stored Procedures, Functions and Triggers

| Object | Name | Purpose |
|---|---|---|
| View | `vw_UpcomingAppointments` | Shows all scheduled future appointments |
| View | `vw_PetMedicalHistory` | Full medical history per pet |
| Procedure | `sp_BookAppointment` | Books an appointment after checking vet availability |
| Procedure | `sp_GenerateInvoice` | Creates an invoice for a completed visit |
| Function | `fn_GetPetAge` | Returns a pet's age from its birth date |
| Trigger | `trg_UpdateStockAfterPrescription` | Reduces medication stock when prescribed |

*(Replace with the objects you actually created.)*

---

## 📐 Normalization

- **1NF:** all attributes are atomic and there are no repeating groups
- **2NF:** no partial dependencies on composite keys
- **3NF:** no transitive dependencies; non-key attributes depend only on the key

[Optionally describe one design decision, e.g. why prescriptions are in a separate table.]

---

## 📋 Business Rules

- A pet must belong to exactly one owner
- A vet cannot have two appointments at the same date and time
- An appointment must be completed before a medical record is created
- Medication stock cannot go below zero
- An invoice is linked to one completed appointment
- [Add your own rules]

---

## 📊 Reporting and Analytics

The database supports reports such as:
- Monthly revenue and unpaid invoices
- Most frequent species and diagnoses
- Vet workload and appointment completion rate
- Pets overdue for vaccination
- Low-stock medications

*(If you built a Power BI dashboard, add screenshots under `docs/` and link them here.)*

---

## ✅ Testing

- Constraint tests (invalid inserts should fail)
- Join and aggregation checks against expected results
- Trigger and stored procedure tests in `tests/test_cases.sql`

---

## 🔮 Future Improvements

- Connect a front-end (web or desktop) application
- Add user roles and permissions (admin, vet, receptionist)
- Add automated vaccination reminders
- Add an audit log for record changes
- Add backup and restore scripts

---

## 🤝 Contributing

Contributions are welcome.

1. Fork the repository
2. Create a branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push: `git push origin feature/your-feature`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the [MIT License](LICENSE). *(Add a LICENSE file, or remove this section.)*

---

## 👤 Author

**Seif Hussein Aboelazaim**
Computer Science and AI student, Cairo University (FCAI)

- LinkedIn: [linkedin.com/in/seifaboelazaim](https://linkedin.com/in/seifaboelazaim)
- Email: seifhuss74@gmail.com

⭐ If you found this project useful, consider giving it a star!
