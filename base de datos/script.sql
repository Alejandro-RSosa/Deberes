--creo la base de datos de ventas
use master
go

if exists(Select * FROM SysDataBases WHERE name='Ventas')
BEGIN
	DROP DATABASE Ventas
END
go

CREATE DATABASE Ventas
go

--pone en uso la bd
USE Ventas
go

--creo la tabla de Articulos
CREATE TABLE Articulos
(
	CodArt int NOT NULL PRIMARY KEY,
	NomArt varchar(20) NOT NULL,
	PreArt Money,
	Activo bit not null Default(1)
) 
go

CREATE TABLE Facturas
(
	CodFac int not null primary key identity,
	FechaFac datetime not null default getdate(),
	CantFac int not null,
	CodArt int not null foreign key references Articulos(CodArt)
)
go

--SP ALTA FACTURA
CREATE PROC AltaFactura @cant int, @codArt int as
begin
	if not exists(select * from Articulos where CodArt = @codArt and Activo = 1)
		return -1
	else
		begin
			Insert Facturas(CantFac, CodArt) values (@cant, @codArt)
			return 1
		end
end
go

--SP LISTAR FACTURA
CREATE PROC ListarFacturas as
begin
	select * from Facturas
end
go

--creo SP de alta
Create Procedure AltaArticulo @cod int, @nom varchar(20), @pre money AS
Begin	
	if (exists(select * from Articulos where codArt = @cod and Activo = 0))
		begin
			update Articulos set NomArt = @nom, PreArt = @pre, Activo = 1 where CodArt = @cod
			return 1
		end
	if exists(select * from Articulos where CodArt = @cod and Activo = 1)
		return -1
		
	else
	begin
		Insert Articulos(CodARt, NomArt, PreArt) Values (@cod, @nom, @pre)
		return 1
	end
end
go

--creo SP de Baja
Create Procedure BajaArticulo @cod int AS
Begin
	if (not exists(select * from Articulos where codArt = @cod))
		return -1
		
	if exists (select * from Facturas where CodArt = @cod)
		begin
			update Articulos set Activo = 0 where CodArt = @cod
			return 1
		end
	else
	begin
		Delete From Articulos where codArt = @cod
		return 1
	end
end
go

--creo SP de modificacion
Create Procedure ModArticulo @cod int, @nom varchar(20), @pre money AS
Begin
	if (not exists(select * from Articulos where codArt = @cod and Activo = 1))
		return -1
		
	else
	begin
		Update Articulos Set NomArt=@nom, PreArt=@pre where codArt = @cod
		return 1
	end
end
go

--creo SP de busqueda
Create Procedure BuscoArticuloTodos @cod int AS
Begin
	Select *
	From Articulos
	where codArt = @cod
end
go

Create Procedure BuscoArticuloActivos @cod int AS
Begin
	Select *
	From Articulos
	where codArt = @cod and Activo = 1
end
go

--creo SP de listado
Create Procedure ListoArticulo AS
Begin
	Select *
	From Articulos
end
go

--ingreso datos de prueba
Exec AltaArticulo 23, "Licuadora", 2500
go
Exec AltaArticulo 48, "Maquina de Coser", 6700
go
Exec AltaArticulo 514, "Ventilador de Techo Vertical", 250
go
