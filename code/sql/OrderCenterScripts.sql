create database AsiTechOrderCenter
go

use AsiTechOrderCenter

--drop table OrderCenterProduct
--drop table Customer

create table OrderCenterProduct
(
	Id int primary key,
	Name varchar(128) not null,
	Price float not null,
	AvailableAmount int,
)

create table Customer 
(
	Id int primary key,
	Address varchar(256) not null,
	Email varchar(128)
)
