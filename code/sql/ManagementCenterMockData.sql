use AsiTechManagementCenter


insert into ProductSupplier values(0,'Apple','US')
insert into ProductSupplier values(1,'Microsoft','US')
insert into ProductSupplier values(2,'Google','US')
insert into ProductSupplier values(3,'Rodo Cargo','PT')
insert into ProductSupplier values(4,'Matutano','PT')
insert into ProductSupplier values(5,'Pantene','FR')



exec sp_InsertProduct @id = 0, @name='mac' , @supplierId = 0, @price =2000.123, @startAmount=10
exec sp_InsertProduct @id = 1, @name='ipod' , @supplierId = 0, @price =300, @startAmount=10
exec sp_InsertProduct @id = 2, @name='iphone' , @supplierId = 0, @price =600, @startAmount=10
exec sp_InsertProduct @id = 3, @name='ipad' , @supplierId = 0, @price =700, @startAmount=10
exec sp_InsertProduct @id = 4, @name='surface' , @supplierId = 1, @price =500, @startAmount=10
exec sp_InsertProduct @id = 5, @name='surface pro' , @supplierId = 1, @price =999, @startAmount=10
exec sp_InsertProduct @id = 6, @name='surface phone' , @supplierId = 1, @price =320, @startAmount=10
exec sp_InsertProduct @id = 7, @name='Renault AE' , @supplierId = 3, @price =120000, @startAmount=1
exec sp_InsertProduct @id = 8, @name='Ruffles' , @supplierId = 4, @price =1.12, @startAmount=100
exec sp_InsertProduct @id = 9, @name='Pantene Pro V' , @supplierId = 5, @price =4.12, @startAmount=100
exec sp_InsertProduct @id = 10, @name='Nexus 4' , @supplierId = 2, @price =280, @startAmount=100