create database AsiTechOrderCenter
go

use AsiTechOrderCenter

declare @PcName nvarchar(128)
declare @ManagementCenterServer nvarchar(128)

set @PcName = ( select HOST_NAME());

if @PcName = 'DVD-PC'
begin
	set @ManagementCenterServer = 'DVD-PC\SQLSERVER' 
end

exec sp_addlinkedserver @server = @ManagementCenterServer, @srvproduct = 'SQL Server';

if @PcName = 'DVD-PC'
begin
	create synonym ManagementCenterProduct for  [DVD-PC\SQLSERVER].[AsiTechManagementCenter].[dbo].[ManagementCenterProduct]
	create synonym CustomerOrder for [DVD-PC\SQLSERVER].[AsiTechManagementCenter].[dbo].[CustomerOrder]
	create synonym SupplierOrder for [DVD-PC\SQLSERVER].[AsiTechManagementCenter].[dbo].[SupplierOrder]
end

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

create view Product
as 
select m.Id, m.Price, m.AvailableAmount, m.SupplierId, o.Name
FROM ManagementCenterProduct as m join OrderCenterProduct as o 
on(m.Id = o.Id)
