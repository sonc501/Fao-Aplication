	insert Student(Name,Gender,Email,Phone,MajorId) values ('nguyen xuan tue','male','t@gmail.com',01234526789,1)
	insert Student(Name,Gender,Email,Phone,MajorId) values ('nguyen sa hung','male','t@gmail.com',01234426789,1)
	insert Student(Name,Gender,Email,Phone,MajorId) values ('nguyen tan sa','male','t@gmail.com',01234556789,1)
	insert Major(Name,Description) values ('abc xyz','jsdljaldfjklas')
	insert Subject(Name,Description,prerequisites) values ('abc xyz','jsdljaldfjklas','acd')
	insert MajorSubject(MajorId,SubjectId) values (1,1)
	insert Semester(Name,StartDate,EndDate,Status) values ('Summer 23','2023-4-5','2023-5-30','z')
	insert Course(Name,Description,Code,Status,SubjectId,SemesterId) values ('English 23','ENG','ENG','z',1,1)
	insert StudentInCourse(StudentId,CourseId,Grade) values (4,1,10)
	insert Attendance(StudentInCourseId,Date,Status) values (5,'2023-5-5','absent')

	drop database CourseManagement
	go
	create database CourseManagement
	go
	Use CourseManagement
	go
	CREATE TABLE StudentInCourse (
	  Id int NOT NULL IDENTITY(1,1) unique,
	  StudentId int NOT NULL,
	  CourseId int NOT NULL,
	  Grade int,
	  PRIMARY KEY (StudentId, CourseId)
	)
	
	go
		CREATE TABLE Attendance (
	  Id int NOT NULL IDENTITY(1,1) primary key,
	StudentInCourseId int not null,
	[Date] date not null,
	[Status] varchar (10) ,
	)
	go


	CREATE TABLE Student (
	  Id int NOT NULL Primary key  IDENTITY(1,1),
	  [Name] NVARCHAR (150) not null,
	  Gender NVARCHAR (150) not null,
	  Email NVARCHAR (255) NOT NULL,
	  Phone Char(11) UNIQUE CHECK(Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	  MajorId int  not null,
	
	)

	go
	CREATE TABLE Major (
	  id integer NOT NULL Primary key  IDENTITY(1,1),
	  [Name] NVARCHAR(255) NOT NULL,
	  [Description] NVARCHAR (255) NOT NULL,
	);
	CREATE TABLE [Subject] (
	  id integer NOT NULL Primary key  IDENTITY(1,1),
	  [Name] NVARCHAR(255) NOT NULL,
	  [Description] NVARCHAR (255) NOT NULL,
	  prerequisites NVARCHAR (255) NOT NULL,
	);
	go
	CREATE TABLE Semester (
	  id integer NOT NULL Primary key  IDENTITY(1,1),
	  [Name] NVARCHAR (255) NOT NULL,
	  StartDate DATE not null,
	  EndDate DATE not null,
		[Status]  varchar(10) not null,

	);
	go
	CREATE TABLE Course (
	  id integer NOT NULL Primary key  IDENTITY(1,1),
	  [Name] NVARCHAR (255) NOT NULL,
	  [Description] NVARCHAR (255) NOT NULL,
	  [Code] varchar(10) not null,
	 [Status] varchar(10) not null,
	 SubjectId int not null,
	 SemesterId int not null,
	);
	go
	-- Kết thúc bảng chính--
	-- Tạo Bảng nối--
	CREATE TABLE MajorSubject(
		MajorId int not null,
		SubjectId int not null,
		PRIMARY KEY (MajorId,SubjectId)
	)
	go 
	-- kết thúc bảng nối--
	-- Thêm Khóa Ngoại--
	ALTER TABLE StudentInCourse
	ADD FOREIGN KEY (StudentId) REFERENCES Student(Id)
	ALTER TABLE StudentInCourse
	ADD FOREIGN KEY (CourseId) REFERENCES Course(Id)
	ALTER TABLE	Student
	ADD FOREIGN KEY (MajorId) REFERENCES Major(id)
	ALTER TABLE Course 
	ADD FOREIGN KEY (SubjectId) REFERENCES [Subject](id)
	ALTER TABLE Course 
	ADD FOREIGN KEY (SemesterId) REFERENCES Semester(id)
	AlTER TABLE MajorSubject
	ADD FOREIGN KEY (MajorId) REFERENCES Major(id)
	AlTER TABLE MajorSubject
	ADD FOREIGN KEY (SubjectId) REFERENCES [Subject](id)
	AlTER TABLE Attendance
	ADD FOREIGN KEY (StudentInCourseId) REFERENCES StudentInCourse(id)
