use NUTRISPORTS



INSERT INTO EMPRESA (Nombre, Direccion, Telefono, CNR, Giro) VALUES
('NutriSport El Salvador S.A. de C.V.', 'Bulevar de Los Héroes #125, San Salvador', '2225-7000', '198234-5', 'Venta de Ropa, Calzado Deportivo y Suplementos');


INSERT INTO CATEGORIA (Categoria, Estado) VALUES
('Calzado Deportivo', 1),
('Ropa Deportiva', 1),
('Accesorios Deportivos', 1),
('Proteínas y Suplementos', 1);

INSERT INTO PRODUCTO (Producto, Precio, Existencia, CategoriaId, Estado) VALUES
('Nike Air Zoom Pegasus 40', 145.00, 20, 1, 1),
('Adidas Ultraboost Light', 190.00, 15, 1, 1),
('Camiseta Adidas Training Heat.Rdy', 45.00, 30, 2, 1),
('Licra Nike Pro Dri-FIT', 40.00, 25, 2, 1),
('Mochila Nike Brasilia Training', 35.00, 18, 3, 1),
('Gorra Adidas Aeroready', 22.00, 40, 3, 1),
('Whey Gold Standard 5lb', 78.00, 25, 4, 1);

INSERT INTO CLIENTE (Nombre, Apellido, Telefono, Email, DUI, Estado) VALUES
('Fernando', 'Beteta', '7845-1122', 'f.beteta@gmail.com', '05123456-7', 1),
('Gabriela', 'Rivas', '7210-9988', 'gaby.rivas@hotmail.com', '06182934-2', 1),
('Alejandro', 'Escalante', '7955-4433', 'a.escalante@outlook.com', '04987654-1', 1);


INSERT INTO ROL (Nombre, Descripcion, Estado) VALUES
('Administrador', 'Control del sistema', 1),
('Vendedor', 'Ventas y facturacion', 1),
('Bodeguero', 'Gestion de inventario', 1);

SELECT * FROM ROL;

INSERT INTO CARGO (Nombre, Estado) VALUES
('Gerente de Sucursal', 1),
('Cajero / Asesor de Ventas', 1),
('Encargado de Inventario', 1);


SELECT * FROM CARGO;

INSERT INTO EMPLEADO (Nombre, Apellido, Telefono, Email, DUI, Direccion, RolId, CargoId, Estado) VALUES
('Mauricio', 'Zelaya', '7011-2233', 'm.zelaya@nutrisport.sv', '03412567-9', 'Santa Tecla, La Libertad', 3, 1, 1),
('Sofía', 'Mendoza', '7822-4455', 's.mendoza@nutrisport.sv', '05891234-0', 'Antiguo Cuscatlán, La Libertad', 4, 2, 1);

SELECT * FROM EMPLEADO;


INSERT INTO USUARIO (Nombre, NombreEmpleado, Clave, Tipo, Estado) VALUES
('admin_sv', 'Mauricio Zelaya', 'Nutri2026*', 'Administrador', 'Activo'),
('smendoza', 'Sofía Mendoza', 'Ventas2026', 'Vendedor', 'Activo');


INSERT INTO PROVEEDOR (Nombre, Direccion, Telefono, Estado) VALUES
('Distribuidora Adidas El Salvador', 'CC Multiplaza, Nivel 2, Antiguo Cuscatlán', '2243-8000', 1),
('Nike Store Central America', 'CC Galerías, Escalón, San Salvador', '2264-9100', 1),
('Sportline El Salvador S.A.', 'Plaza Merliot, Santa Tecla', '2288-3344', 1);


INSERT INTO INVENTARIO (Existencias, FechaActualizacion) VALUES
(173, GETDATE());

INSERT INTO PEDIDO (NumeroPedido, Fecha, Estado) VALUES
(5001, GETDATE(), 'Pendiente'),
(5002, GETDATE(), 'Entregado');


INSERT INTO VENTA (FechaVenta, Estado, Descripcion, ClienteId) VALUES
(GETDATE(), 'Completada', 'Compra en tienda física - Sucursal San Salvador', 1);

INSERT INTO DETALLE_VENTA (Cantidad, PrecioUnitario, TotalPagar, IdVenta, ProductoId) VALUES
(1, 145.00, 145.00, 1, 1),
(1, 45.00, 45.00, 1, 3);


INSERT INTO COMPRA (FechaHora, NombreProveedor, NumFact, NombreUsuario, SubTotal, TotalPagar, Estado) VALUES
(GETDATE(), 1, 88412, 1, 1450.00, 1450.00, 'Completada');


INSERT INTO DETALLE_COMPRA (NombreCompra, NombreProducto, Cantidad, PrecioUnitario, Total) VALUES
(1, 2, 10, 145.00, 1450.00);

INSERT INTO CONTROL_INVENTARIO (NombreUsuario, FechaHora, CantProducto, Observacion, Estado) VALUES
(1, GETDATE(), 173, 'Conteo físico de calzado y ropa Nike / Adidas', 'Procesado');

INSERT INTO DET_CONTROL_INV (Cantidad, Observacion, NombreControlInv) VALUES
(20, 'Existencia verificada de Nike Pegasus 40 en bodega', 1);