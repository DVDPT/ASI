use AsiTechManagementCenter

--drop table CustomerOrder
--drop table ManagementCenterProduct
--drop table ProductProvider

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
	Name varchar not null,
	Address varchar not null,

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
	Id int primary key,
	Address varchar not null,
	Email varchar
)

create table CustomerOrder
(
	State int not null,
	CustomerId int foreign key references Customer(Id),
	ProductId int foreign key references ManagementCenterProduct(Id),
	OrderAmount int, 
	check(OrderAmount > 0)
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
	@name varchar,
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

