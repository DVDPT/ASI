use AsiTechOrderCenter

create table OrderCenterProduct
(
	Id int primary key,
	Name varchar not null,
	Price float not null,
	AvailableAmount int,
)

create table Customer 
(
	Id int primary key,
	Address varchar not null,
	Email varchar
)
