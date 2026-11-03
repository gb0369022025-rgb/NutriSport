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

create or alter procedure SpDeletePedido
	@PedidoId int
as
begin
	delete from PEDIDO where PedidoId = @PedidoId;
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

select ProductoId, Producto as ProductosSinCodigo from PRODUCTO where CodigoBarras is null;

select case is_nullable when 0 then 'Obligatorio' else 'Pendiente: faltan productos sin codigo' end as CodigoBarras,
       (select count(*) from sys.procedures) as Procedimientos
from sys.columns
where object_id = object_id('PRODUCTO') and name = 'CodigoBarras';
