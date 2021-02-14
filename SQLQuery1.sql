Create table Cars(
	Id int primary key identity(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Descriptions nvarchar(25),
	Foreign Key (BrandId) References Brands(BrandId),
	Foreign Key (ColorId) References Colors(ColorId)
)
Create table Colors(
	ColorId int primary Key identity(1,1),
	ColorName nvarchar(25)
)
Create table Brands(
	BrandId int Primary Key identity (1,1),
	BrandName nvarchar(25)
)
Create table Users(
	Id int Primary Key Identity (1,1),
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Email nvarchar(25),
	Password nvarchar(25)
)
Create table Customers(
	UserId int Primary Key Identity (1,1),
	CompanyName nvarchar(25)
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)
Create table Rentals(
	Id int Primary Key Identity (1,1),
	CarId int,
	CustomerId int,
	RentDate DateTime,
	ReturnDate DateTime
)

Select * from Cars
Select * from Brands
Select * from Colors
Select * from Users
Select * from Customers

