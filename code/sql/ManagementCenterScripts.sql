use AsiTechManagementCenter
--drop proc sp_DeleteProduct
--drop proc sp_InsertProduct
--drop table CustomerOrder
--drop table SupplierOrder
--drop table ManagementCenterProduct
--drop table ProductSupplier
--drop table Customer

declare @PcName nvarchar(128)
declare @OrderCenterServer nvarchar(128)

set @PcName = ( select HOST_NAME());

if @PcName = 'DVD-PC'
begin
	set @OrderCenterServer = 'DVD-PC' 
end

exec sp_addlinkedserver @server = @OrderCenterServer, @srvproduct = 'SQL Server';

if @PcName = 'DVD-PC'
begin
	create synonym OrderCenterProduct for  [DVD-PC].[AsiTechOrderCenter].[dbo].[OrderCenterProduct]
end

create table ProductSupplier
(
	Id int primary key,
	Name varchar(128) not null,
	Address varchar(256) not null,

)

create table ManagementCenterProduct
(
	Id int primary key,
	Price float not null,
	AvailableAmount int,
	SupplierId int foreign key references ProductSupplier(Id)
)

create table Customer
(
	Id int primary key identity,
	Address varchar(256) not null,
	Email varchar(128)
)

create table CustomerOrder
(
	OrderDate datetime,
	State int not null,
	CustomerId int foreign key references Customer(Id),
	ProductId int foreign key references ManagementCenterProduct(Id),
	OrderAmount int, 
	check(OrderAmount > 0),
	primary key(CustomerId,ProductId,OrderDate)
)

create table SupplierOrder
(
	OrderDate datetime,
	ProductId int foreign key references ManagementCenterProduct(Id),
	SupplierId int foreign key references ProductSupplier(Id),
	OrderAmount int, 
	check(OrderAmount > 0),
	primary key (OrderDate,ProductId,SupplierId)
)


create proc sp_InsertProduct
	@id int,
	@name varchar(128),
	@supplierId int,
	@price float,
	@startAmount int
as
	set XACT_ABORT on
	begin distributed transaction
		insert into ManagementCenterProduct values(@id,@price,@startAmount,@supplierId)
		insert into OrderCenterProduct values(@id,@name,@price,@startAmount)
	commit transaction
go

create proc sp_DeleteProduct
	@id int
as
	set XACT_ABORT on
	begin distributed transaction
		delete from ManagementCenterProduct where Id=@id
		delete from OrderCenterProduct      where Id=@id
	commit transaction
go

select * from ManagementCenterProduct 
select * from OrderCenterProduct 