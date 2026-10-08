/*
	Fecha: 08 de octubre de 2026
	Integrantes: Marlon Alexander Álvarez Cea
				 Anderson Wilfredo Árevalo Gonzalez
				 Jose Fernando García Beteta
				 Danilo Alejandro Linares Escalante
	Proyecto: Sistema NUTRISPORT
*/



create database NUTRISPORTS;

use NUTRISPORTS


create table EMPRESA(
	EmpresaId int primary key identity,
	Nombre varchar(50) not null,
	Direccion varchar(50) not null,
	Telefono varchar(15) not null,
	CNR varchar(20) not null,
	Giro varchar(50) not null
);

create table CATEGORIA(
	CategoriaId int primary key identity,
	Categoria varchar(50) not null,
	Estado int not null default 1
);

create table PRODUCTO(
	ProductoId smallint primary key identity,
	Producto varchar(50) not null,
	Precio money check(Precio>0.00) not null,
	Existencia int not null check(Existencia>=0),
	CategoriaId int foreign key references CATEGORIA (CategoriaId),
	Estado int not null default 1
);

create table CLIENTE(
	ClienteId int primary key identity,
	Nombre varchar(50) null,
	Apellido varchar(50) null,
	Telefono varchar(15) null,
	Email varchar(50) null,
	DUI varchar(15) unique null,
	Estado int not null default 1
);

create table VENTA(
	IdVenta int primary key identity,
	FechaVenta date not null,
	Estado varchar(20) not null,
	Descripcion varchar(250) not null,
	ClienteId int foreign key references CLIENTE (ClienteId)
);

create table DETALLE_VENTA(
	DetalleVentaId int primary key identity,
	Cantidad smallint check (Cantidad>0) not null,
	PrecioUnitario money check (PrecioUnitario>0.00) not null,
	TotalPagar money check (TotalPagar>0.00) not null,
	IdVenta int foreign key references VENTA (IdVenta),
	ProductoId smallint foreign key references PRODUCTO (ProductoId)
);

create table ROL(
	RolId smallint primary key identity,
	Nombre varchar(25) not null,
	Descripcion varchar(25) not null,
	Estado int not null default 1
);

create table CARGO(
	CargoId smallint primary key identity,
	Nombre varchar(50) not null,
	Estado int not null default 1
);

create table EMPLEADO(
	EmpleadoId int primary key identity,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Telefono varchar(15) not null,
	Email varchar(50) not null,
	DUI varchar(15) unique not null,
	Direccion varchar(50) not null,
	RolId smallint foreign key references ROL (RolId) not null,
	CargoId smallint foreign key references CARGO (CargoId) not null,
	Estado int not null default 1
);

create table INVENTARIO(
	InventarioId int primary key identity,
	Existencias int not null,
	FechaActualizacion date not null
);

create table USUARIO(
	UsuarioId int primary key identity,
	Nombre varchar(20) not null,
	NombreEmpleado varchar(60) not null,
	Clave varchar(25) not null,
	Tipo varchar(25) not null,
	Estado varchar(15) not null
);

create table CONTROL_INVENTARIO(
	ControlInvId int primary key identity,
	NombreUsuario int foreign key references USUARIO(UsuarioId) not null,
	FechaHora datetime not null,
	CantProducto int not null,
	Observacion varchar(200) null,
	Estado varchar(25) not null
);

create table DET_CONTROL_INV(
	DetControlInvId int primary key identity,
	Cantidad int not null,
	Observacion varchar(200) not null,
	NombreControlInv int foreign key references CONTROL_INVENTARIO (ControlInvId)
);

create table PROVEEDOR(
	ProveedorId smallint primary key identity,
	Nombre varchar(50) not null,
	Direccion varchar(100) not null,
	Telefono varchar(15) null,
	Estado int not null default 1
);

create table PEDIDO(
	PedidoId int primary key identity,
	NumeroPedido int null,
	Fecha datetime default getdate(),
	Estado varchar(25) not null default 'Pendiente'
);

create table COMPRA(
	CompraId int primary key identity,
	FechaHora datetime not null,
	NombreProveedor smallint foreign key references PROVEEDOR(ProveedorId) not null,
	NumFact int not null,
	NombreUsuario int foreign key references USUARIO(UsuarioId) not null,
	SubTotal money not null,
	TotalPagar money not null,
	Estado varchar(25) not null default 'Completada'
);

create table DETALLE_COMPRA (
	DetalleCompraId int primary key identity,
	NombreCompra int foreign key references COMPRA(CompraId) not null,
	NombreProducto smallint foreign key references PRODUCTO(ProductoId) null,
	Cantidad int not null,
	PrecioUnitario money not null,
	Total money not null
);

create table ESTADO (
    EstadoId int primary key identity,
    Nombre varchar(50) not null
);