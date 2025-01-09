
UPDATE Clientes
   SET NombreCliente = LEFT(NombreCliente,12)
      ,NombreDeFantasia = LEFT(NombreDeFantasia,12)
	  ,CorreoAdministrativo = LEFT(CorreoAdministrativo,8)
	  ,CorreoElectronico = LEFT(CorreoElectronico,8)
	  ,Telefono = LEFT(Telefono,8)
	  ,Celular = LEFT(Celular,8)
	  ,Direccion =LEFT(Direccion,12)
GO

UPDATE AuditoriaClientes
   SET NombreCliente = LEFT(NombreCliente,12)
      ,NombreDeFantasia = LEFT(NombreDeFantasia,12)
	  ,CorreoAdministrativo = LEFT(CorreoAdministrativo,8)
	  ,CorreoElectronico = LEFT(CorreoElectronico,8)
	  ,Telefono = LEFT(Telefono,8)
	  ,Celular = LEFT(Celular,8)
	  ,Direccion =LEFT(Direccion,12)
GO

UPDATE Ventas
   SET NombreCliente = LEFT(NombreCliente,12)
	  ,Direccion =LEFT(Direccion,12)
GO

UPDATE VentasProductos
   SET NombreProducto = LEFT(NombreProducto,12)
GO

UPDATE ComprasProductos
   SET NombreProducto = LEFT(NombreProducto,12)
GO

UPDATE Productos
   SET NombreProducto = LEFT(NombreProducto,12)
GO

UPDATE AuditoriaProductos
   SET NombreProducto = LEFT(NombreProducto,12)
GO

UPDATE Proveedores
   SET NombreProveedor = LEFT(NombreProveedor,12)
      ,NombreDeFantasia =LEFT(NombreDeFantasia,12)
	  ,DireccionProveedor = LEFT(DireccionProveedor,12)
	  ,CorreoElectronico = LEFT(CorreoElectronico,8)
	  ,TelefonoProveedor = LEFT(TelefonoProveedor,8)
GO

UPDATE CuentasBancarias
   SET NombreCuenta = LEFT(NombreCuenta,12)
GO

UPDATE CuentasBancos
   SET NombreCuentaBanco = LEFT(NombreCuentaBanco,12)
GO

UPDATE CuentasDeCajas
   SET NombreCuentaCaja = LEFT(NombreCuentaCaja,12)
GO

UPDATE CajasNombres
   SET NombreCaja = LEFT(NombreCaja,8)
GO

UPDATE Empleados
   SET NombreEmpleado = LEFT(NombreEmpleado,8)
     , Direccion = LEFT(Direccion,8)
     , TelefonoEmpleado = LEFT(TelefonoEmpleado,8)
	 , CelularEmpleado = LEFT(CelularEmpleado,8)
GO


UPDATE ProductosSucursales 
   SET PrecioFabrica = ROUND(PrecioFabrica*2,2)
     , PrecioCosto = ROUND(PrecioCosto*2,2)
     , Usuario='Admin'
GO

UPDATE ProductosSucursalesPrecios 
   SET PrecioVenta = ROUND(PrecioVenta*2,2)
     , Usuario='Admin'
GO

--UPDATE Rutas
--   SET NombreRuta = LEFT(NombreRuta,12)
--GO

UPDATE MovilRutas
   SET NombreRuta = LEFT(NombreRuta,12)
GO

UPDATE Transportistas
   SET NombreTransportista = LEFT(NombreTransportista,12)
GO
