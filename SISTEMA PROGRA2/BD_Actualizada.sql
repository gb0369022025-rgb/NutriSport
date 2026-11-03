USE NUTRISPORTS;
GO

if col_length('PRODUCTO', 'CodigoBarras') is null
	alter table PRODUCTO add CodigoBarras varchar(30) null;
GO

if not exists (select * from sys.indexes where name = 'UX_PRODUCTO_CodigoBarras' and object_id = object_id('PRODUCTO'))
	create unique nonclustered index UX_PRODUCTO_CodigoBarras
		on PRODUCTO (CodigoBarras)
		where CodigoBarras is not null;
GO

if not exists (select * from PRODUCTO where CodigoBarras is null)
   and exists (select * from sys.columns where object_id = object_id('PRODUCTO') and name = 'CodigoBarras' and is_nullable = 1)
begin
	drop index UX_PRODUCTO_CodigoBarras on PRODUCTO;
	alter table PRODUCTO alter column CodigoBarras varchar(30) not null;
	create unique nonclustered index UX_PRODUCTO_CodigoBarras on PRODUCTO (CodigoBarras);
end
GO

create or alter procedure SpSelectAllCategoria
as
begin
	select CategoriaId as 'Código',
	       Categoria as 'Nombre Categoria' 
	from CATEGORIA
	where Estado = 1
	order by Categoria asc;
end;
GO

create or alter procedure SpInsertCategoria
	@Categoria varchar(50)
as
begin
	if exists(select * from CATEGORIA where Categoria = @Categoria)
		begin
			print 'La categoría que intenta registrar ya existe en la BD.'
		end
	else
		begin
			insert into CATEGORIA (Categoria) values (@Categoria);
		end
end;
GO

create or alter procedure SpUpdateCategoria
	@CategoriaId int,
	@Categoria varchar(50)
as
begin
	if exists (select * from CATEGORIA where Categoria = @Categoria and CategoriaId <> @CategoriaId)
		begin
			print 'La categoría que intenta modificar ya existe.'
		end
	else
		begin
			update CATEGORIA set Categoria = @Categoria where CategoriaId = @CategoriaId;
		end
end;
GO

create or alter procedure SpDeleteCategoria
	@CategoriaId int
as
begin
	update CATEGORIA set Estado = 0 where CategoriaId = @CategoriaId;
end;
GO

create or alter procedure SpSelectAllProducto
as
begin
	select a.ProductoId as 'Cod.',
	       a.Producto as 'Producto',
	       a.Precio as 'P. Unitario',
	       a.Existencia as 'Existencia',
	       (cast(a.CategoriaId as varchar) + ' - ' + b.Categoria) as 'Categoria',
	       a.CodigoBarras as 'Codigo Barras'
	from PRODUCTO a
	inner join CATEGORIA b on a.CategoriaId = b.CategoriaId
	where a.Estado = 1
	order by a.Producto asc;
end;
GO

create or alter procedure SpSelectNombreProducto
	@Producto varchar(50)
as
begin
	select ProductoId as 'Codigo', Producto, Precio, Existencia,
	       CodigoBarras as 'Codigo Barras'
	from PRODUCTO
	where Producto like '%' + @Producto + '%' and Estado = 1;
end;
GO

create or alter procedure SpSelectProductoCodigoBarras
	@CodigoBarras varchar(30)
as
begin
	select a.ProductoId as 'Cod.',
	       a.Producto as 'Producto',
	       a.Precio as 'P. Unitario',
	       a.Existencia as 'Existencia',
	       (cast(a.CategoriaId as varchar) + ' - ' + b.Categoria) as 'Categoria',
	       a.CodigoBarras as 'Codigo Barras'
	from PRODUCTO a
	inner join CATEGORIA b on a.CategoriaId = b.CategoriaId
	where a.CodigoBarras = @CodigoBarras and a.Estado = 1;
end;
GO

create or alter procedure SpInsertProducto
	@Producto varchar(50),
	@Precio money,
	@Existencia int,
	@CategoriaId int,
	@CodigoBarras varchar(30)
as
begin
	set @CodigoBarras = ltrim(rtrim(@CodigoBarras));

	if exists(select * from PRODUCTO where Producto = @Producto)
	   or exists(select * from PRODUCTO where CodigoBarras = @CodigoBarras)
		begin
			print 'El producto o el código de barras ya existe en la BD.'
		end
	else
		begin
			insert into PRODUCTO (Producto, Precio, Existencia, CategoriaId, CodigoBarras)
			values (@Producto, @Precio, @Existencia, @CategoriaId, @CodigoBarras);
		end
end;
GO

create or alter procedure SpUpdateProducto
	@ProductoId smallint,
	@Producto varchar(50),
	@Precio money,
	@Existencia int,
	@CategoriaId int,
	@CodigoBarras varchar(30)
as
begin
	set @CodigoBarras = ltrim(rtrim(@CodigoBarras));

	if exists (select * from PRODUCTO where Producto = @Producto and ProductoId <> @ProductoId)
	   or exists (select * from PRODUCTO where CodigoBarras = @CodigoBarras and ProductoId <> @ProductoId)
		begin
			print 'El producto o el código de barras ya existe.'
		end
	else
		begin
			update PRODUCTO
			set Producto = @Producto,
			    Precio = @Precio,
			    Existencia = @Existencia,
			    CategoriaId = @CategoriaId,
			    CodigoBarras = @CodigoBarras
			where ProductoId = @ProductoId;
		end
end;
GO

create or alter procedure SpDeleteProducto
	@ProductoId smallint
as
begin
	update PRODUCTO set Estado = 0 where ProductoId = @ProductoId;
end;
GO

create or alter procedure SpSelectAllCliente
as
begin
	select ClienteId as 'Código',
	       Nombre as 'Nombre',
	       Apellido as 'Apellido',
	       Telefono as 'Teléfono',
	       Email as 'Correo',
	       DUI as 'DUI'
	from CLIENTE
	where Estado = 1
	order by Nombre asc;
end;
GO

create or alter procedure SpInsertCliente
	@Nombre varchar(50) = null,
	@Apellido varchar(50) = null,
	@Telefono varchar(15) = null,
	@Email varchar(50) = null,
	@DUI varchar(15) = null
as
begin
	if exists(select * from CLIENTE where DUI = @DUI and DUI is not null)
		begin
			print 'El DUI del cliente que intenta registrar ya existe en la BD.'
		end
	else
		begin
			insert into CLIENTE (Nombre, Apellido, Telefono, Email, DUI) 
			values (@Nombre, @Apellido, @Telefono, @Email, @DUI);
		end
end;
GO

create or alter procedure SpUpdateCliente
	@ClienteId int,
	@Nombre varchar(50) = null,
	@Apellido varchar(50) = null,
	@Telefono varchar(15) = null,
	@Email varchar(50) = null,
	@DUI varchar(15) = null
as
begin
	if exists (select * from CLIENTE where DUI = @DUI and ClienteId <> @ClienteId and DUI is not null)
		begin
			print 'El DUI que intenta modificar ya pertenece a otro cliente.'
		end
	else
		begin
			update CLIENTE 
			set Nombre = @Nombre,
			    Apellido = @Apellido,
			    Telefono = @Telefono,
			    Email = @Email,
			    DUI = @DUI
			where ClienteId = @ClienteId;
		end
end;
GO

create or alter procedure SpDeleteCliente
	@ClienteId int
as
begin
	update CLIENTE set Estado = 0 where ClienteId = @ClienteId;
end;
GO

create or alter procedure SpSelectAllProveedor
as
begin
	select ProveedorId as 'Código',
	       Nombre as 'Nombre',
	       Direccion as 'Dirección',
	       Telefono as 'Teléfono'
	from PROVEEDOR
	where Estado = 1
	order by Nombre asc;
end;
GO

create or alter procedure SpInsertProveedor
	@Nombre varchar(50),
	@Direccion varchar(100),
	@Telefono varchar(15) = null
as
begin
	if exists(select * from PROVEEDOR where Nombre = @Nombre)
		begin
			print 'El proveedor que intenta registrar ya existe en la BD.'
		end
	else
		begin
			insert into PROVEEDOR (Nombre, Direccion, Telefono)
			values (@Nombre, @Direccion, @Telefono);
		end
end;
GO

create or alter procedure SpUpdateProveedor
	@ProveedorId smallint,
	@Nombre varchar(50),
	@Direccion varchar(100),
	@Telefono varchar(15) = null
as
begin
	if exists(select * from PROVEEDOR where Nombre = @Nombre and ProveedorId <> @ProveedorId)
		begin
			print 'El nombre del proveedor ya pertenece a otro registro.'
		end
	else
		begin
			update PROVEEDOR
			set Nombre = @Nombre,
			    Direccion = @Direccion,
			    Telefono = @Telefono
			where ProveedorId = @ProveedorId;
		end
end;
GO

create or alter procedure SpDeleteProveedor
	@ProveedorId smallint
as
begin
	update PROVEEDOR set Estado = 0 where ProveedorId = @ProveedorId;
end;
GO

create or alter procedure SpSelectAllRol
as
begin
	select RolId as 'Código',
	       Nombre as 'Rol',
	       Descripcion as 'Descripción'
	from ROL
	where Estado = 1
	order by Nombre asc;
end;
GO

create or alter procedure SpInsertRol
	@Nombre varchar(25),
	@Descripcion varchar(25)
as
begin
	if exists(select * from ROL where Nombre = @Nombre)
		begin
			print 'El rol que intenta registrar ya existe.'
		end
	else
		begin
			insert into ROL (Nombre, Descripcion)
			values (@Nombre, @Descripcion);
		end
end;
GO

create or alter procedure SpUpdateRol
	@RolId smallint,
	@Nombre varchar(25),
	@Descripcion varchar(25)
as
begin
	if exists(select * from ROL where Nombre = @Nombre and RolId <> @RolId)
		begin
			print 'El rol ya existe.'
		end
	else
		begin
			update ROL
			set Nombre = @Nombre,
			    Descripcion = @Descripcion
			where RolId = @RolId;
		end
end;
GO

create or alter procedure SpDeleteRol
	@RolId smallint
as
begin
	update ROL set Estado = 0 where RolId = @RolId;
end;
GO

create or alter procedure SpSelectAllCargo
as
begin
	select CargoId as 'Código',
	       Nombre as 'Cargo'
	from CARGO
	where Estado = 1
	order by Nombre asc;
end;
GO

create or alter procedure SpInsertCargo
	@Nombre varchar(50)
as
begin
	if exists(select * from CARGO where Nombre = @Nombre)
		begin
			print 'El cargo que intenta registrar ya existe.'
		end
	else
		begin
			insert into CARGO (Nombre) values (@Nombre);
		end
end;
GO

create or alter procedure SpUpdateCargo
	@CargoId smallint,
	@Nombre varchar(50)
as
begin
	if exists(select * from CARGO where Nombre = @Nombre and CargoId <> @CargoId)
		begin
			print 'El cargo ya existe.'
		end
	else
		begin
			update CARGO set Nombre = @Nombre where CargoId = @CargoId;
		end
end;
GO

create or alter procedure SpDeleteCargo
	@CargoId smallint
as
begin
	update CARGO set Estado = 0 where CargoId = @CargoId;
end;
GO

create or alter procedure SpSelectAllEmpleado
as
begin
	select e.EmpleadoId as 'Código',
	       e.Nombre as 'Nombre',
	       e.Apellido as 'Apellido',
	       e.Telefono as 'Teléfono',
	       e.Email as 'Correo',
	       e.DUI as 'DUI',
	       e.Direccion as 'Dirección',
	       (cast(e.RolId as varchar) + ' - ' + r.Nombre) as 'Rol',
	       (cast(e.CargoId as varchar) + ' - ' + c.Nombre) as 'Cargo'
	from EMPLEADO e
	inner join ROL r on e.RolId = r.RolId
	inner join CARGO c on e.CargoId = c.CargoId
	where e.Estado = 1
	order by e.Nombre asc;
end;
GO

create or alter procedure SpInsertEmpleado
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Telefono varchar(15),
	@Email varchar(50),
	@DUI varchar(15),
	@Direccion varchar(50),
	@RolId smallint,
	@CargoId smallint
as
begin
	if exists(select * from EMPLEADO where DUI = @DUI)
		begin
			print 'El DUI del empleado ya existe en la BD.'
		end
	else
		begin
			insert into EMPLEADO (Nombre, Apellido, Telefono, Email, DUI, Direccion, RolId, CargoId)
			values (@Nombre, @Apellido, @Telefono, @Email, @DUI, @Direccion, @RolId, @CargoId);
		end
end;
GO

create or alter procedure SpUpdateEmpleado
	@EmpleadoId int,
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Telefono varchar(15),
	@Email varchar(50),
	@DUI varchar(15),
	@Direccion varchar(50),
	@RolId smallint,
	@CargoId smallint
as
begin
	if exists(select * from EMPLEADO where DUI = @DUI and EmpleadoId <> @EmpleadoId)
		begin
			print 'El DUI pertenece a otro empleado.'
		end
	else
		begin
			update EMPLEADO
			set Nombre = @Nombre,
			    Apellido = @Apellido,
			    Telefono = @Telefono,
			    Email = @Email,
			    DUI = @DUI,
			    Direccion = @Direccion,
			    RolId = @RolId,
			    CargoId = @CargoId
			where EmpleadoId = @EmpleadoId;
		end
end;
GO

create or alter procedure SpDeleteEmpleado
	@EmpleadoId int
as
begin
	update EMPLEADO set Estado = 0 where EmpleadoId = @EmpleadoId;
end;
GO

create or alter procedure SpSelectAllUsuario
as
begin
	select UsuarioId as 'Código',
	       Nombre as 'Usuario',
	       NombreEmpleado as 'Empleado',
	       Tipo as 'Tipo Usuario',
	       Estado
	from USUARIO
	where Estado = 'Activo'
	order by Nombre asc;
end;
GO

create or alter procedure SpUsuarioLogin
	@Nombre varchar(20),
	@Clave varchar(25)
as
begin
	select UsuarioId, Nombre, NombreEmpleado, Tipo, Estado
	from USUARIO
	where Nombre = @Nombre and Clave = @Clave and Estado = 'Activo';
end;
GO

create or alter procedure SpInsertUsuario
	@Nombre varchar(20),
	@NombreEmpleado varchar(60),
	@Clave varchar(25),
	@Tipo varchar(25),
	@Estado varchar(15) = 'Activo'
as
begin
	if exists(select * from USUARIO where Nombre = @Nombre)
		begin
			print 'El nombre de usuario ya está ocupado.'
		end
	else
		begin
			insert into USUARIO (Nombre, NombreEmpleado, Clave, Tipo, Estado)
			values (@Nombre, @NombreEmpleado, @Clave, @Tipo, @Estado);
		end
end;
GO

create or alter procedure SpUpdateUsuario
	@UsuarioId int,
	@Nombre varchar(20),
	@NombreEmpleado varchar(60),
	@Clave varchar(25),
	@Tipo varchar(25),
	@Estado varchar(15)
as
begin
	if exists(select * from USUARIO where Nombre = @Nombre and UsuarioId <> @UsuarioId)
		begin
			print 'El nombre de usuario ya pertenece a otra cuenta.'
		end
	else
		begin
			update USUARIO
			set Nombre = @Nombre,
			    NombreEmpleado = @NombreEmpleado,
			    Clave = @Clave,
			    Tipo = @Tipo,
			    Estado = @Estado
			where UsuarioId = @UsuarioId;
		end
end;
GO

create or alter procedure SpDeleteUsuario
	@UsuarioId int
as
begin
	update USUARIO set Estado = 'Inactivo' where UsuarioId = @UsuarioId;
end;
GO

create or alter procedure SpSelectAllPedido
as
begin
	select PedidoId as 'Código',
	       NumeroPedido as 'N° Pedido',
	       Fecha as 'Fecha Registro',
	       Estado
	from PEDIDO
	order by Fecha desc;
end;
GO

create or alter procedure SpInsertPedido
	@NumeroPedido int = null,
	@Estado varchar(25) = 'Pendiente'
as
begin
	insert into PEDIDO (NumeroPedido, Fecha, Estado)
	values (@NumeroPedido, getdate(), @Estado);
end;
GO

create or alter procedure SpUpdatePedido
	@PedidoId int,
	@NumeroPedido int = null,
	@Estado varchar(25)
as
begin
	update PEDIDO
	set NumeroPedido = @NumeroPedido,
	    Estado = @Estado
	where PedidoId = @PedidoId;
end;
GO

create or alter procedure SpSelectAllEstado
as
begin
	select EstadoId as 'Código',
	       Nombre as 'Estado'
	from ESTADO
	order by Nombre asc;
end;
GO

create or alter procedure SpDeletePedido
	@PedidoId int
as
begin
	delete from PEDIDO where PedidoId = @PedidoId;
end;
GO

create or alter procedure SpSelectAllVenta
as
begin
	select v.IdVenta as 'Código Venta',
	       v.FechaVenta as 'Fecha',
	       v.Estado as 'Estado',
	       v.Descripcion as 'Descripción',
	       (cast(v.ClienteId as varchar) + ' - ' + isnull(c.Nombre,'') + ' ' + isnull(c.Apellido,'')) as 'Cliente'
	from VENTA v
	left join CLIENTE c on v.ClienteId = c.ClienteId
	order by v.IdVenta desc;
end;
GO

create or alter procedure SpInsertVenta
	@FechaVenta date,
	@Estado varchar(20),
	@Descripcion varchar(250),
	@ClienteId int = null,
	@IdVentaGenerado int output
as
begin
	insert into VENTA (FechaVenta, Estado, Descripcion, ClienteId)
	values (@FechaVenta, @Estado, @Descripcion, @ClienteId);
	
	set @IdVentaGenerado = scope_identity();
end;
GO

create or alter procedure SpInsertDetalleVenta
	@Cantidad smallint,
	@PrecioUnitario money,
	@TotalPagar money,
	@IdVenta int,
	@ProductoId smallint
as
begin
	insert into DETALLE_VENTA (Cantidad, PrecioUnitario, TotalPagar, IdVenta, ProductoId)
	values (@Cantidad, @PrecioUnitario, @TotalPagar, @IdVenta, @ProductoId);

	-- Actualización de inventario
	update PRODUCTO
	set Existencia = Existencia - @Cantidad
	where ProductoId = @ProductoId;
end;
GO

create or alter procedure SpSelectDetalleVenta
	@IdVenta int
as
begin
	select DetalleVentaId as 'Código Detalle',
	       Cantidad as 'Cantidad',
	       PrecioUnitario as 'Precio Unitario',
	       TotalPagar as 'Total Pagar',
	       IdVenta as 'Código Venta',
	       ProductoId as 'Código Producto'
	from DETALLE_VENTA
	where IdVenta = @IdVenta
	order by DetalleVentaId asc;
end;
GO

create or alter procedure SpDeleteVenta
	@IdVenta int
as
begin
	set xact_abort on;
	begin transaction;

	update p
	set p.Existencia = p.Existencia + d.Cantidad
	from PRODUCTO p
	inner join (select ProductoId, sum(Cantidad) as Cantidad
	            from DETALLE_VENTA
	            where IdVenta = @IdVenta
	            group by ProductoId) d on d.ProductoId = p.ProductoId;

	delete from DETALLE_VENTA where IdVenta = @IdVenta;
	delete from VENTA where IdVenta = @IdVenta;

	commit transaction;
end;
GO

create or alter procedure SpRegistrarVenta
	@FechaVenta date,
	@Estado varchar(20),
	@Descripcion varchar(250),
	@ClienteId int = null,
	@Detalle nvarchar(max),
	@IdVentaGenerado int output
as
begin
	set xact_abort on;
	begin transaction;

	insert into VENTA (FechaVenta, Estado, Descripcion, ClienteId)
	values (@FechaVenta, @Estado, @Descripcion, @ClienteId);

	set @IdVentaGenerado = scope_identity();

	insert into DETALLE_VENTA (Cantidad, PrecioUnitario, TotalPagar, IdVenta, ProductoId)
	select d.Cantidad, p.Precio, d.Cantidad * p.Precio, @IdVentaGenerado, p.ProductoId
	from openjson(@Detalle) with (ProductoId smallint, Cantidad smallint) d
	inner join PRODUCTO p on p.ProductoId = d.ProductoId;

	update p
	set p.Existencia = p.Existencia - d.Cantidad
	from PRODUCTO p
	inner join (select ProductoId, sum(Cantidad) as Cantidad
	            from openjson(@Detalle) with (ProductoId smallint, Cantidad smallint)
	            group by ProductoId) d on d.ProductoId = p.ProductoId;

	commit transaction;
end;
GO

create or alter procedure SpSelectAllCompra
as
begin
	select c.CompraId as 'Código Compra',
	       c.FechaHora as 'Fecha Hora',
	       (cast(c.NombreProveedor as varchar) + ' - ' + p.Nombre) as 'Proveedor',
	       c.NumFact as 'N° Factura',
	       (cast(c.NombreUsuario as varchar) + ' - ' + u.Nombre) as 'Usuario',
	       c.SubTotal as 'SubTotal',
	       c.TotalPagar as 'Total Pagar',
	       c.Estado
	from COMPRA c
	inner join PROVEEDOR p on c.NombreProveedor = p.ProveedorId
	inner join USUARIO u on c.NombreUsuario = u.UsuarioId
	order by c.CompraId desc;
end;
GO

create or alter procedure SpInsertCompra
	@FechaHora datetime,
	@NombreProveedor smallint,
	@NumFact int,
	@NombreUsuario int,
	@SubTotal money,
	@TotalPagar money,
	@Estado varchar(25) = 'Completada',
	@CompraIdGenerada int output
as
begin
	insert into COMPRA (FechaHora, NombreProveedor, NumFact, NombreUsuario, SubTotal, TotalPagar, Estado)
	values (@FechaHora, @NombreProveedor, @NumFact, @NombreUsuario, @SubTotal, @TotalPagar, @Estado);

	set @CompraIdGenerada = scope_identity();
end;
GO

create or alter procedure SpInsertDetalleCompra
	@NombreCompra int,
	@NombreProducto smallint = null,
	@Cantidad int,
	@PrecioUnitario money,
	@Total money
as
begin
	insert into DETALLE_COMPRA (NombreCompra, NombreProducto, Cantidad, PrecioUnitario, Total)
	values (@NombreCompra, @NombreProducto, @Cantidad, @PrecioUnitario, @Total);

	-- Incremento de inventario
	if @NombreProducto is not null
		begin
			update PRODUCTO
			set Existencia = Existencia + @Cantidad
			where ProductoId = @NombreProducto;
		end
end;
GO

create or alter procedure SpDeleteCompra
	@CompraId int
as
begin
	set xact_abort on;
	begin transaction;

	update p
	set p.Existencia = p.Existencia - d.Cantidad
	from PRODUCTO p
	inner join (select NombreProducto, sum(Cantidad) as Cantidad
	            from DETALLE_COMPRA
	            where NombreCompra = @CompraId and NombreProducto is not null
	            group by NombreProducto) d on d.NombreProducto = p.ProductoId;

	delete from DETALLE_COMPRA where NombreCompra = @CompraId;
	delete from COMPRA where CompraId = @CompraId;

	commit transaction;
end;
GO

create or alter procedure SpSelectAllControlInventario
as
begin
	select ci.ControlInvId as 'Código Control',
	       (cast(ci.NombreUsuario as varchar) + ' - ' + u.Nombre) as 'Usuario',
	       ci.FechaHora as 'Fecha Hora',
	       ci.CantProducto as 'Cantidad Productos',
	       ci.Observacion as 'Observación',
	       ci.Estado
	from CONTROL_INVENTARIO ci
	inner join USUARIO u on ci.NombreUsuario = u.UsuarioId
	order by ci.ControlInvId desc;
end;
GO

create or alter procedure SpInsertControlInventario
	@NombreUsuario int,
	@FechaHora datetime,
	@CantProducto int,
	@Observacion varchar(200) = null,
	@Estado varchar(25),
	@ControlInvIdGenerado int output
as
begin
	insert into CONTROL_INVENTARIO (NombreUsuario, FechaHora, CantProducto, Observacion, Estado)
	values (@NombreUsuario, @FechaHora, @CantProducto, @Observacion, @Estado);

	set @ControlInvIdGenerado = scope_identity();
end;
GO

create or alter procedure SpDeleteControlInventario
	@ControlInvId int
as
begin
	set xact_abort on;
	begin transaction;

	delete from DET_CONTROL_INV where NombreControlInv = @ControlInvId;
	delete from CONTROL_INVENTARIO where ControlInvId = @ControlInvId;

	commit transaction;
end;
GO

create or alter procedure SpInsertDetControlInv
	@Cantidad int,
	@Observacion varchar(200),
	@NombreControlInv int
as
begin
	insert into DET_CONTROL_INV (Cantidad, Observacion, NombreControlInv)
	values (@Cantidad, @Observacion, @NombreControlInv);
end;
GO

create or alter procedure SpSelectAllDetControlInv
as
begin
	select DetControlInvId as 'Código',
	       Cantidad as 'Cantidad',
	       Observacion as 'Observación',
	       NombreControlInv as 'Código Control'
	from DET_CONTROL_INV
	order by DetControlInvId desc;
end;
GO

create or alter procedure SpSelectAllInventario
as
begin
	select InventarioId as 'Código',
	       Existencias as 'Existencias',
	       FechaActualizacion as 'Fecha Actualización'
	from INVENTARIO
	order by FechaActualizacion desc;
end;
GO

create or alter procedure SpSelectEmpresa
as
begin
	select EmpresaId, Nombre, Direccion, Telefono, CNR, Giro
	from EMPRESA;
end;
GO

create or alter procedure SpUpdateEmpresa
	@EmpresaId int,
	@Nombre varchar(50),
	@Direccion varchar(50),
	@Telefono varchar(15),
	@CNR varchar(20),
	@Giro varchar(50)
as
begin
	update EMPRESA
	set Nombre = @Nombre,
	    Direccion = @Direccion,
	    Telefono = @Telefono,
	    CNR = @CNR,
	    Giro = @Giro
	where EmpresaId = @EmpresaId;
end;
GO

select ProductoId, Producto as ProductosSinCodigo from PRODUCTO where CodigoBarras is null;

select case is_nullable when 0 then 'Obligatorio' else 'Pendiente: faltan productos sin codigo' end as CodigoBarras,
       (select count(*) from sys.procedures) as Procedimientos
from sys.columns
where object_id = object_id('PRODUCTO') and name = 'CodigoBarras';

select name as ColumnasDeClientes
from sys.dm_exec_describe_first_result_set_for_object(object_id('SpSelectAllCliente'), 0);
