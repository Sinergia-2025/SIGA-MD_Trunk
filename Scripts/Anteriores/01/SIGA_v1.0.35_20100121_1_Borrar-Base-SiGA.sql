DELETE FROM MovimientosComprasProductos
GO


DELETE FROM MovimientosCompras
GO


DELETE FROM ComprasProductos
GO


DELETE FROM Compras
GO


DELETE FROM ComprasNumeros
GO


DELETE FROM RubrosCompras WHERE IdRubro>2
GO


DELETE FROM CuentasCorrientesProvCheques
GO


DELETE FROM CuentasCorrientesProvPagos
GO


DELETE FROM CuentasCorrientesProv
GO


DELETE FROM Proveedores
GO


DELETE FROM MovimientosVentasProductos
GO


DELETE FROM MovimientosVentas
GO


DELETE FROM MovimientosNumeros
GO


DELETE FROM CuentasCorrientesCheques
GO


DELETE FROM CuentasCorrientesPagos
GO


DELETE FROM CuentasCorrientes
GO


DELETE FROM VentasCheques
GO


DELETE FROM VentasProductos
GO


DELETE FROM Ventas
GO


DELETE FROM ClientesSucursales
GO

DELETE FROM Clientes
GO


DELETE FROM VentasNumeros
 WHERE IdTipoComprobante NOT IN ('FACT','NCRED','NDEB')
   OR IdSucursal>1
GO 
 
UPDATE VentasNumeros SET
   Numero=0
 WHERE IdTipoComprobante IN ('FACT','NCRED','NDEB')
GO


DELETE FROM HistorialPrecios
GO


DELETE FROM ProductosSucursalesPrecios
GO


DELETE FROM ProductosSucursales
GO


DELETE FROM Productos
GO


DELETE FROM Rubros
GO


DELETE FROM Marcas
GO


DELETE FROM UnidadesDeMedidas
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('CC', 'Cent. Cubico', 0.001)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('GR', 'Gramo', 0.001)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('KG', 'Kilogramo', 1.000)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('LT', 'Litro', 1.000)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('UN', 'Unidad', 0.000)
GO



DELETE FROM DepositosCheques
GO


DELETE FROM Depositos
GO


DELETE FROM CajasDetalle
GO


DELETE FROM Cajas
 WHERE NumeroPlanilla>1
GO 
 

UPDATE Cajas SET
   FechaPlanilla = GETDATE(),
   PesosSaldoInicial = 0, 
   PesosSaldoFinal = 0, 
   DolaresSaldoInicial = 0, 
   DolaresSaldoFinal = 0, 
   EurosSaldoInicial = 0, 
   EurosSaldoFinal = 0, 
   ChequesSaldoInicial = 0, 
   ChequesSaldoFinal = 0, 
   TarjetasSaldoInicial = 0, 
   TarjetasSaldoFinal = 0,  
   TicketsSaldoInicial = 0, 
   TicketsSaldoFinal = 0
 WHERE NumeroPlanilla = 1
GO 
 

DELETE FROM CuentasDeCajas
  WHERE IdCuentaCaja>6
GO


DELETE FROM LibrosBancos
GO


DELETE FROM CuentasBancos
  WHERE IdCuentaBanco > 6
GO


DELETE FROM CuentasBancarias
GO


DELETE FROM Cheques
GO


DELETE FROM SincronizaRegistros
GO


DELETE FROM SincronizaTablas
GO


DELETE FROM Transportistas
GO


DELETE FROM Empleados
GO

INSERT INTO Empleados
   (TipoDocEmpleado, NroDocEmpleado, NombreEmpleado, TelefonoEmpleado, CelularEmpleado, EsVendedor,EsComprador)
     VALUES
   ('COD', 1, 'Empresa', NULL, NULL, 'True', 'True') 
GO


DELETE FROM Categorias
 WHERE IdCategoria > 1
GO

 
UPDATE Categorias SET
   NombreCategoria = 'General'
 WHERE IdCategoria = 1
GO
  

DELETE FROM Tareas
GO


DELETE FROM Localidades
 WHERE IdLocalidad NOT IN (1000, 2000, 2121)
GO


DELETE FROM ListasDePrecios
 WHERE IdListaPrecios>0
GO

UPDATE ListasDePrecios
   SET FechaVigencia = GETDATE()
 WHERE IdListaPrecios = 0
GO


DELETE FROM TiposComprobantesLetras
GO


DELETE FROM Impresoras
 WHERE IdImpresora NOT IN ('NORMAL','FISCAL1')
GO


DELETE FROM ImpresorasPCs
  WHERE NombrePC NOT IN ('TERRA-PC', 'DIEGOPROMANC-PC')
GO


DELETE FROM UsuariosRoles WHERE IdUsuario NOT IN ('Admin','Supervisor')
GO


DELETE FROM Usuarios WHERE Id NOT IN ('Admin','Supervisor')
GO

DELETE FROM Sucursales WHERE IdSucursal > 1
GO


/* ------ NO SE BORRAN --------------- */


/* CategoriasFiscales */
/* CuentasBancariasClase */
/* Bancos */
/* Estados */
/* TiposComprobantes */
/* TiposDocumento */
/* TiposMovimientos */
/* RolesFunciones */
/* VentasFormasPago */
/* Provincias */
/* Parametros */
/* Funciones */
/* Monedas */
/* Roles */




