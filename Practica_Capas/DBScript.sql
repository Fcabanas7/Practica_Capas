--Crea base de datos
create database Practica
go
use Practica
--Crea Tabla
CREATE table PRA_Productos
(
PR_id int identity (1,1) primary key,
PR_Nombre varchar (25),
PR_Descripcion Varchar(75),
PR_Marca varchar (20),
PR_Precio float,
PR_Stock int
)

--Inserta Productos
Insert into PRA_Productos
values
('Refresco','600 ml','CocaCola',12,24),
('Cerveza','1.200 ml','Victoria',39,12),
('Cafe','900 gr','Nescafe',25,36),
('Leche','1 ltr','Alpura',21,10),
('Chocolate','1 PZ','Abuelita',15,10)

--SELECCIONA Y BUSCA PRODUCCTOS
Select * from PRA_Productos


---PROCEDIMIENTOS ALMACENADOS 
--------------------------MOSTRAR 
create proc MostrarProductos
as
select *from PRA_Productos
go

--------------------------INSERTAR 
Create proc InsetarProductos
@nombre nvarchar (25),
@descrip nvarchar (75),
@marca nvarchar (25),
@precio float,
@stock int
as
insert into PRA_Productos values (@nombre,@descrip,@marca,@precio,@stock)
go

------------------------ELIMINAR
create proc EliminarProducto
@idpro int
as
delete from PRA_Productos where PR_Id=@idpro
go
------------------EDITAR

Create proc EditarProductos
@nombre nvarchar (25),
@descrip nvarchar (50),
@marca nvarchar (25),
@precio float,
@stock int,
@id int
as
update PRA_Productos set PR_Nombre=@nombre, PR_Descripcion=@descrip, PR_Marca=@marca, PR_Precio=@precio, PR_Stock=@stock where PR_Id=@id
go
