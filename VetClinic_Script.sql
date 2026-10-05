
-- This file contains the full script for the database
-- First execute "create database VetClinic;" in another query then execute the script 
-- This script creates the tables and inserts some sample data

Use VetClinic;

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLINICAL_NOTE') and o.name = 'FK_CLINICAL_REFERENCE_MEDICAL_')
alter table CLINICAL_NOTE
   drop constraint FK_CLINICAL_REFERENCE_MEDICAL_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INVENTORY') and o.name = 'FK_INVENTOR_HAS2_CLINIC')
alter table INVENTORY
   drop constraint FK_INVENTOR_HAS2_CLINIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('INVENTORY') and o.name = 'FK_INVENTOR_REFERENCE_VACCINE')
alter table INVENTORY
   drop constraint FK_INVENTOR_REFERENCE_VACCINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDICAL_VISIT') and o.name = 'FK_MEDICAL__CONDUCTS_VETERINA')
alter table MEDICAL_VISIT
   drop constraint FK_MEDICAL__CONDUCTS_VETERINA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEDICAL_VISIT') and o.name = 'FK_MEDICAL__SCHEDULED_PET')
alter table MEDICAL_VISIT
   drop constraint FK_MEDICAL__SCHEDULED_PET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PET') and o.name = 'FK_PET_OWNS_OWNER')
alter table PET
   drop constraint FK_PET_OWNS_OWNER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VACCINATION_RECORD') and o.name = 'FK_VACCINAT_DOCUMENTE_VACCINE')
alter table VACCINATION_RECORD
   drop constraint FK_VACCINAT_DOCUMENTE_VACCINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VACCINATION_RECORD') and o.name = 'FK_VACCINAT_SCORES_PET')
alter table VACCINATION_RECORD
   drop constraint FK_VACCINAT_SCORES_PET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VETERINARIAN') and o.name = 'FK_VETERINA_EMPLOYS_CLINIC')
alter table VETERINARIAN
   drop constraint FK_VETERINA_EMPLOYS_CLINIC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLINIC')
            and   type = 'U')
   drop table CLINIC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLINICAL_NOTE')
            and   type = 'U')
   drop table CLINICAL_NOTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('INVENTORY')
            and   name  = 'HAS2_FK'
            and   indid > 0
            and   indid < 255)
   drop index INVENTORY.HAS2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('INVENTORY')
            and   type = 'U')
   drop table INVENTORY
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEDICAL_VISIT')
            and   name  = 'CONDUCTS_FK'
            and   indid > 0
            and   indid < 255)
   drop index MEDICAL_VISIT.CONDUCTS_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEDICAL_VISIT')
            and   name  = 'SCHEDULED_FOR_FK'
            and   indid > 0
            and   indid < 255)
   drop index MEDICAL_VISIT.SCHEDULED_FOR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEDICAL_VISIT')
            and   type = 'U')
   drop table MEDICAL_VISIT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OWNER')
            and   type = 'U')
   drop table OWNER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PET')
            and   name  = 'OWNS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PET.OWNS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PET')
            and   type = 'U')
   drop table PET
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VACCINATION_RECORD')
            and   name  = 'DOCUMENTED_IN_FK'
            and   indid > 0
            and   indid < 255)
   drop index VACCINATION_RECORD.DOCUMENTED_IN_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VACCINATION_RECORD')
            and   name  = 'SCORES_FK'
            and   indid > 0
            and   indid < 255)
   drop index VACCINATION_RECORD.SCORES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VACCINATION_RECORD')
            and   type = 'U')
   drop table VACCINATION_RECORD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VACCINE')
            and   type = 'U')
   drop table VACCINE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VETERINARIAN')
            and   name  = 'EMPLOYS_FK'
            and   indid > 0
            and   indid < 255)
   drop index VETERINARIAN.EMPLOYS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VETERINARIAN')
            and   type = 'U')
   drop table VETERINARIAN
go

/*==============================================================*/
/* Table: CLINIC                                                */
/*==============================================================*/
create table CLINIC (
   CLINICID             int   IDENTITY(1,1)  not null,
   CLINIC_NAME          varchar(50)          null,
   CLINIC_ADDRESS       varchar(50)          not null,
   HAS_EMERGENCY        bit                  not null,
   constraint PK_CLINIC primary key (CLINICID)
)
go

/*==============================================================*/
/* Table: CLINICAL_NOTE                                         */
/*==============================================================*/
create table CLINICAL_NOTE (
   NOTEID               int   IDENTITY(1,1)  not null,
   VISITID              int                  null,
   PET_WEIGHT           float                null,
   NOTE_TEXT            varchar(500)         null,
   constraint PK_CLINICAL_NOTE primary key (NOTEID)
)
go

/*==============================================================*/
/* Table: INVENTORY                                             */
/*==============================================================*/
create table INVENTORY (
   CLINICID             int                  not null,
   VACCID               int                  not null,
   QUANTITY             int                  null,
   PRICE                int                  null,
   EXPIRY_DATE          datetime             null,
   constraint PK_INVENTORY primary key (CLINICID, VACCID)
)
go

/*==============================================================*/
/* Index: HAS2_FK                                               */
/*==============================================================*/




create nonclustered index HAS2_FK on INVENTORY (CLINICID ASC)
go

/*==============================================================*/
/* Table: MEDICAL_VISIT                                         */
/*==============================================================*/
create table MEDICAL_VISIT (
   VISITID              int   IDENTITY(1,1)  not null,
   VETID                int                  not null,
   PETID                int                  not null,
   VISIT_DATE           datetime             null,
   VISIT_TIME           datetime             null,
   constraint PK_MEDICAL_VISIT primary key (VISITID)
)
go

/*==============================================================*/
/* Index: SCHEDULED_FOR_FK                                      */
/*==============================================================*/




create nonclustered index SCHEDULED_FOR_FK on MEDICAL_VISIT (PETID ASC)
go

/*==============================================================*/
/* Index: CONDUCTS_FK                                           */
/*==============================================================*/




create nonclustered index CONDUCTS_FK on MEDICAL_VISIT (VETID ASC)
go

/*==============================================================*/
/* Table: OWNER                                                 */
/*==============================================================*/
create table OWNER (
   OWNERID              int   IDENTITY(1,1)  not null,
   OWNER_NAME           varchar(50)          null,
   EMERGENCY_CONTACT     varchar(50)          null,
   BILLING_ADDRESS      varchar(50)          null,
   constraint PK_OWNER primary key (OWNERID)
)
go

/*==============================================================*/
/* Table: PET                                                   */
/*==============================================================*/
create table PET (
   PETID                int   IDENTITY(1,1)  not null,
   OWNERID              int                  not null,
   PET_NAME             varchar(50)          null,
   SPECIES              varchar(20)          null,
   BREED                varchar(20)          null,
   AGE                  int                  null,
   constraint PK_PET primary key (PETID)
)
go

/*==============================================================*/
/* Index: OWNS_FK                                               */
/*==============================================================*/




create nonclustered index OWNS_FK on PET (OWNERID ASC)
go

/*==============================================================*/
/* Table: VACCINATION_RECORD                                    */
/*==============================================================*/
create table VACCINATION_RECORD (
   PETID                int                  not null,
   VACCID               int                  not null,
   BATCH_NO             int                  null,
   DATE_GIVEN           datetime             null,
   NEXT_BOOSTER_DATE    datetime             null,
   constraint PK_VACCINATION_RECORD primary key (PETID, VACCID)
)
go

/*==============================================================*/
/* Index: SCORES_FK                                             */
/*==============================================================*/




create nonclustered index SCORES_FK on VACCINATION_RECORD (PETID ASC)
go

/*==============================================================*/
/* Index: DOCUMENTED_IN_FK                                      */
/*==============================================================*/




create nonclustered index DOCUMENTED_IN_FK on VACCINATION_RECORD (VACCID ASC)
go

/*==============================================================*/
/* Table: VACCINE                                               */
/*==============================================================*/
create table VACCINE (
   VACCID               int   IDENTITY(1,1)  not null,
   VACC_NAME            varchar(50)          null,
   TYPE                 varchar(50)          null,
   constraint PK_VACCINE primary key (VACCID)
)
go

/*==============================================================*/
/* Table: VETERINARIAN                                          */
/*==============================================================*/
create table VETERINARIAN (
   VETID                int   IDENTITY(1,1)  not null,
   CLINICID             int                  not null,
   VET_NAME             varchar(50)          null,
   SPECIALIZED_IN       varchar(50)          null,
   constraint PK_VETERINARIAN primary key (VETID)
)
go

/*==============================================================*/
/* Index: EMPLOYS_FK                                            */
/*==============================================================*/




create nonclustered index EMPLOYS_FK on VETERINARIAN (CLINICID ASC)
go

alter table CLINICAL_NOTE
   add constraint FK_CLINICAL_REFERENCE_MEDICAL_ foreign key (VISITID)
      references MEDICAL_VISIT (VISITID)
      on delete cascade on update cascade
go

alter table INVENTORY
   add constraint FK_INVENTOR_HAS2_CLINIC foreign key (CLINICID)
      references CLINIC (CLINICID)
      on delete cascade on update cascade
go

alter table INVENTORY
   add constraint FK_INVENTOR_REFERENCE_VACCINE foreign key (VACCID)
      references VACCINE (VACCID)
      on delete cascade on update cascade
go

alter table MEDICAL_VISIT
   add constraint FK_MEDICAL__CONDUCTS_VETERINA foreign key (VETID)
      references VETERINARIAN (VETID)
      on delete cascade on update cascade
go

alter table MEDICAL_VISIT
   add constraint FK_MEDICAL__SCHEDULED_PET foreign key (PETID)
      references PET (PETID)
      on delete cascade on update cascade
go

alter table PET
   add constraint FK_PET_OWNS_OWNER foreign key (OWNERID)
      references OWNER (OWNERID)
      on delete cascade on update cascade
go

alter table VACCINATION_RECORD
   add constraint FK_VACCINAT_DOCUMENTE_VACCINE foreign key (VACCID)
      references VACCINE (VACCID)
      on delete cascade on update cascade
go

alter table VACCINATION_RECORD
   add constraint FK_VACCINAT_SCORES_PET foreign key (PETID)
      references PET (PETID)
      on delete cascade on update cascade
go

alter table VETERINARIAN
   add constraint FK_VETERINA_EMPLOYS_CLINIC foreign key (CLINICID)
      references CLINIC (CLINICID)
      on delete cascade on update cascade
go



-- Sample Data --

-- 1. CLINIC
INSERT INTO CLINIC (clinic_name, clinic_address, has_emergency) VALUES
('Cairo Veterinary Clinic',   'Tahrir Street, Downtown, Cairo',       1),
('Alexandria Animal Center',  'Nile Street, Smouha, Alexandria',      0),
('Giza Veterinary Clinic',    'Haram Street, Dokki, Giza',            1);

-- 2. VACCINE
INSERT INTO VACCINE (vacc_name, type) VALUES
('Rabies Vaccine',     'Core'),
('Parvovirus Vaccine', 'Core'),
('Feline Calicivirus', 'Core'),
('Bordetella',         'Non-Core');

-- 3. VETERINARIAN
INSERT INTO VETERINARIAN (clinicID, vet_name, specialized_in) VALUES
(1, 'Dr. Ahmed Mahmoud',    'Animal Surgery'),
(1, 'Dr. Sara Ibrahim',     'Feline Diseases'),
(2, 'Dr. Omar Hassan',      'Vaccination and Prevention'),
(3, 'Dr. Noureddine Farouk','Canine Diseases');

-- 4. OWNER
INSERT INTO OWNER (owner_name, emergency_contact, billing_address) VALUES
('Mohamed Abdullah', '01012345678', 'Falaki Street, Zamalek, Cairo'),
('Fatma Hassan',     '01198765432', 'Geish Street, Heliopolis, Cairo'),
('Khaled Ibrahim',   '01234567890', 'Corniche Street, Alexandria'),
('Mona El-Sayed',    '01156789012', 'Marioutiya Street, Giza'),
('Youssef Omar',     '01067891234', 'Thawra Street, Mansoura'),
('Amira Salah',      '01012987654', 'Mohandessin Street, Giza'),
('Tariq Nasser',     '01198123456', 'Nasr City, Cairo'),
('Hana Mostafa',     '01234098765', 'Stanley Street, Alexandria'),
('Karim El-Shafei',  '01556781234', 'Maadi Corniche, Cairo'),
('Dina Abdel-Rahman','01067345678', 'Port Said Street, Ismailia'),
('Sherif Mansour',   '01112345987', 'El-Horreya Street, Alexandria'),
('Nadia Fouad',      '01098761234', 'Helwan Street, Cairo');

-- 5. PET
INSERT INTO PET (ownerID, pet_name, species, breed, age) VALUES
(1,  'Basbousa', 'Cat',    'Persian',          3),
(1,  'Rocky',    'Dog',    'Labrador',         5),
(2,  'Mimi',     'Cat',    'Siamese',          2),
(3,  'Max',      'Dog',    'German Shepherd',  4),
(4,  'Loulou',   'Rabbit', 'Dutch',            1),
(5,  'Zizi',     'Cat',    'Mixed',            6),
(6,  'Simba',    'Cat',    'Maine Coon',       2),
(6,  'Toby',     'Dog',    'Golden Retriever', 3),
(7,  'Nono',     'Parrot', 'African Grey',     5),
(7,  'Bibo',     'Cat',    'Mixed',            1),
(8,  'Sultan',   'Dog',    'Rottweiler',       6),
(9,  'Snowball', 'Cat',    'Angora',           4),
(9,  'Rambo',    'Dog',    'Husky',            2),
(10, 'Fifi',     'Rabbit', 'Angora',           1),
(10, 'Coco',     'Cat',    'Persian',          3),
(11, 'Bruno',    'Dog',    'Doberman',         5),
(12, 'Luna',     'Cat',    'Siamese',          2),
(12, 'Peanut',   'Rabbit', 'Mini Lop',         1);

-- 6. INVENTORY
INSERT INTO INVENTORY (clinicID, vaccID, quantity, price, expiry_date) VALUES
(1, 1, 50, 150, '2026-12-31'),
(1, 2, 30, 200, '2026-06-30'),
(2, 3, 40, 175, '2027-01-15'),
(2, 4, 25, 120, '2026-09-01'),
(3, 1, 60, 150, '2026-11-30'),
(3, 2, 20, 200, '2026-08-15');

-- 7. MEDICAL VISIT
INSERT INTO MEDICAL_VISIT (vetID, petID, visit_date, visit_time) VALUES
(1, 1,  '2025-01-10', '10:00:00'),
(1, 2,  '2025-01-15', '11:30:00'),
(2, 3,  '2025-02-05', '09:00:00'),
(3, 4,  '2025-02-20', '14:00:00'),
(4, 5,  '2025-03-01', '16:00:00'),
(4, 6,  '2025-03-10', '12:00:00'),
(1, 7,  '2025-03-15', '09:00:00'),
(2, 8,  '2025-03-18', '10:30:00'),
(3, 11, '2025-04-02', '11:00:00'),
(4, 12, '2025-04-10', '14:30:00'),
(4, 13, '2025-04-10', '16:00:00'),
(1, 15, '2025-04-20', '09:30:00'),
(2, 17, '2025-05-01', '11:00:00'),
(3, 16, '2025-05-05', '13:00:00'),
(1, 7,  '2025-06-15', '10:00:00'),
(3, 9,  '2025-05-12', '10:00:00'),
(2, 10, '2025-05-14', '11:30:00'),
(4, 14, '2025-05-20', '09:00:00'),
(1, 18, '2025-05-25', '14:00:00');

-- 8. CLINICAL NOTE
INSERT INTO CLINICAL_NOTE (visitID, pet_weight, note_text) VALUES
(1,  4.2,  'Cat is healthy, teeth and eyes examined'),
(2,  28.5, 'Dog has skin allergy, antibiotic prescribed'),
(3,  3.8,  'Routine checkup, cat needs booster vaccine'),
(4,  32.0, 'Dog in excellent condition, annual vaccine given'),
(5,  2.1,  'Rabbit has ear infection, drops prescribed'),
(6,  5.0,  'Routine checkup, animal is in good health'),
(7,  4.8,  'Maine Coon in good health, fur coat examined'),
(8,  31.0, 'Golden Retriever needs dental cleaning soon'),
(9,  42.5, 'Rottweiler overweight, diet plan recommended'),
(10, 5.2,  'Angora cat healthy, routine vaccination done'),
(11, 28.0, 'Husky in excellent condition, playful and active'),
(12, 4.1,  'Persian cat has mild eye discharge, drops prescribed'),
(13, 3.9,  'Siamese cat routine checkup, all clear'),
(14, 38.0, 'Doberman annual vaccine administered'),
(15, 5.0,  'Simba follow-up visit, eye discharge fully cleared'),
(16, 0.4,  'African Grey parrot healthy, beak and feathers in good condition'),
(17, 3.5,  'Mixed cat routine checkup, vaccines up to date'),
(18, 1.8,  'Angora rabbit healthy, nails trimmed'),
(19, 0.9,  'Mini Lop rabbit first visit, general checkup all clear');

-- 9. VACCINATION RECORD
INSERT INTO VACCINATION_RECORD (petID, vaccID, batch_no, date_given, next_booster_date) VALUES
(1,  1, 1001, '2025-01-10', '2026-01-10'),
(2,  2, 1002, '2025-01-15', '2026-01-15'),
(3,  3, 1003, '2025-02-05', '2026-02-05'),
(4,  1, 1004, '2025-02-20', '2026-02-20'),
(5,  4, 1005, '2025-03-01', '2026-03-01'),
(6,  3, 1006, '2025-03-10', '2026-03-10'),
(7,  3, 1007, '2025-03-15', '2026-03-15'),
(8,  2, 1008, '2025-03-18', '2026-03-18'),
(11, 1, 1009, '2025-04-02', '2026-04-02'),
(12, 3, 1010, '2025-04-10', '2026-04-10'),
(13, 2, 1011, '2025-04-10', '2026-04-10'),
(15, 3, 1012, '2025-04-20', '2026-04-20'),
(16, 1, 1013, '2025-05-05', '2026-05-05'),
(17, 3, 1014, '2025-05-01', '2026-05-01'),
(9,  4, 1015, '2025-05-12', '2026-05-12'),
(10, 3, 1016, '2025-05-14', '2026-05-14'),
(14, 4, 1017, '2025-05-20', '2026-05-20'),
(18, 2, 1018, '2025-05-25', '2026-05-25');