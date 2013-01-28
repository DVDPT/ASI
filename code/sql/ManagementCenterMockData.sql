use AsiTechManagementCenter

insert into ProductSupplier values(0,'Apple','US')


exec sp_InsertProduct @id = 0, @name='mac' , @supplierId = 


	@id int,
	@name varchar,
	@supplierId int,
	@price float,
	@startAmount int