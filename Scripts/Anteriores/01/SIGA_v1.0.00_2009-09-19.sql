

Mejoras
=======

Facturacion: permite cambiar la Categoria Fiscal del Cliente para esa operacion puntualmente. (Ejemplo: de RI a Consumidor Final).

Facturacion: Si se elije Cuenta Corriente muestra los dias prederminados de Vencimiento. Actualmente 1 (puede modificarse).

Facturacion: se agrega en pantalla el Numero que posiblemente tenga el comprobante. Dependera que en otra PC no lo utilicen.

Detalle de Movimientos de Productos: se permite filtrar por Cliente.

Detalle de Movimientos de Productos: se permite filtrar por Proveedor.

Detalle de Movimientos de Productos: se agrego el precio Sin IVA (Venta, Compra, etc).

Recibo a Cliente: Se puede modificar la fecha para permitir pasar cobrazas atrasadas. Predeterminada muestra la fecha del dia.

Recibo a Cliente: Se puede modificar el numero de Recibo. Predeterminado muestra el proximo.


Pago a Proveedores: Se puede modificar la fecha para permitir pasar pagos atrasados.

Compras: se permite digitar el descuento/recargo por monto y/o porcentaje.

Compras: activando un parametro de sistema permite recibir productos con precio en Cero. En forma predeterminada NO lo permite.

Empleados: se agrega la identificacion "Es Vendedor" y "Es Comprador". Filtrando por esa identificacion segun corresponda.

Productos: se agrega la identificacion si se encuentra Activo. Filtrando por esa identificacion segun corresponda. Aclaracion: un producto inactiva no podra elegirse pero si saldra en los informes si tuviese movimientos.

Caja: se amplio la observacion a 100 caracteres.

Mayor de cuenta de caja: se agrego el filtro de fechas de planilla o movimiento.

Libro de Bancos: se amplio la observacion a 100 caracteres.

Libro de Banco: muestra el símbolo del movimiento (como en todo el resto del sistema).

Utilidades por cliente: se agrego el filtro por Vendedor.

Total de Ventas por Vendedor: se agrega filtro Producto con comisión (TODOS, SI o NO).

Cta.cte. Clientes: Posibilidad de imprimir informes actuales (TODAS LAS PANTALLAS).

Saldos de Cta.Cte. de Clientes: Se permite sacar agrupado por Vendedores.

Saldo de C.C. de clientes: Ordenar por Vendedor y Cliente. 

Cta.Cte. de Clientes: Se permite sacar agrupado por Vendedores.

Cta.Cte. de Clientes: Se agrega el nombre del Cliente en el detalle y en la impresion agrupa para una mejor lectura.

Cta.Cte. de Clientes: Ordenar por Vendedor, Cliente y Comprobantes. 

Cta.Cte. Detallada de Clientes: Se permite sacar agrupado por Vendedores.

Cta.Cte. Detallada de Clientes: Se agrega el nombre del Cliente en el detalle y en la impresion agrupa para una mejor lectura.

Cta.Cte. Detallada de Clientes: se agrega el filtro de Comprobantes Vencidos (o todos).

Cta.Cte. Detallada de Clientes: Ordenar por Vendedor, Cliente y Comprobantes. 

Cta.cte. Proveedores: Posibilidad de imprimir informes actuales (TODAS LAS PANTALLAS).

Cta.Cte. de Proveedores: Ordenar por Proveedor y Comprobantes. 

Cta.Cte. de Proveedores: Se agrega el nombre del Proveedor en el detalle y en la impresion agrupa para una mejor lectura.

Cta.Cte. Detallada de Proveedores: Se agrega el nombre del Proveedor en el detalle y en la impresion agrupa para una mejor lectura.

Cta.Cte. Detallada de Proveedores: se agrega el filtro de Comprobantes Vencidos (o todos).

Cta.Cte. Detallada de Proveedores: Ordenar por Proveedor y Comprobantes. 

Movimientos de Stock: Habilitar la impresion (ajustes o carga de productos).

Comisiones: Posibilidad de imprimir informes actuales (TODAS LAS PANTALLAS).



Opciones Implementadas
======================

Opcion					Padre
--------------------------------------	----------------------------
Informe de Cheques de Terceros		Caja
Inf. de Comisiones Totales por Marcas	ComisionesVendedores
Anulación de Recibos			CuentasCorrientes
Consultar Recibos a Clientes		CuentasCorrientes
Anular Pagos a Proveedores		CuentasCorrientesProveedores
Consultar Pagos a Proveedores		CuentasCorrientesProveedores
Inf. Totales de Ventas por Dia		Ventas
Utilidades por Marca			Ventas
Anular Comprobantes			Ventas
Anular Comprobantes Sin Emitir		Ventas

Inf. de Kilos Totales por Vendedores	Kilos/Ventas
Inf. de Kilos Totales por Marcas	Kilos/Ventas
Inf. de Kilos Detallado por Productos	Kilos/Ventas




ALTER TABLE CajasDetalle ALTER COLUMN Observacion VARCHAR(100) ;

ALTER TABLE dbo.LibrosBancos ALTER COLUMN Observacion varchar(100) NULL ;


/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesProv ADD
	IdCuentaBancaria int NULL
GO
ALTER TABLE dbo.CuentasCorrientesProv ADD CONSTRAINT
	FK_CuentasCorrientesProv_CuentasBancarias FOREIGN KEY
	(
	IdCuentaBancaria
	) REFERENCES dbo.CuentasBancarias
	(
	IdCuentaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT





/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Empleados ADD
	EsVendedor bit NULL,
	EsComprador bit NULL
GO
COMMIT



/* INDICO TODOS QUE SI.*/

UPDATE dbo.Empleados SET
 EsVendedor = 1,
 EsComprador = 1

GO


ALTER TABLE dbo.Empleados ALTER COLUMN EsVendedor bit NOT NULL 
GO

ALTER TABLE dbo.Empleados ALTER COLUMN EsComprador bit NOT NULL 
GO


/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD
	Activo bit NULL
GO
COMMIT


UPDATE dbo.Productos
 SET Activo=1
GO


ALTER TABLE dbo.Productos ALTER COLUMN Activo bit NOT NULL 
GO


SELECT * FROM dbo.CajasDetalle
 WHERE IdCuentaCaja is NULL
GO

SELECT * FROM dbo.CajasDetalle
 WHERE IdCuentaCaja NOT IN 
(SELECT IdCuentaCaja FROM dbo.CuentasDeCajaS)
GO



ALTER TABLE [dbo].[CajasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CajasDetalle_CuentasDeCajas] FOREIGN KEY([IdCuentaCaja])
REFERENCES [dbo].[CuentasDeCajas] ([IdCuentaCaja])
GO
ALTER TABLE [dbo].[CajasDetalle] CHECK CONSTRAINT [FK_CajasDetalle_CuentasDeCajas]
GO

ALTER TABLE [dbo].[CajasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CajasDetalle_Cajas] FOREIGN KEY([IdSucursal], [NumeroPlanilla])
REFERENCES [dbo].[Cajas] ([IdSucursal], [NumeroPlanilla])
GO
ALTER TABLE [dbo].[CajasDetalle] CHECK CONSTRAINT [FK_CajasDetalle_Cajas]
GO


DROP TABLE dbo.CuentasBancosClase
GO

DROP TABLE dbo.Usuarios
GO


INSERT INTO Parametros 
           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
     VALUES
           ('VISUALIZACOMPROBANTESDECOMPRA', 'NO', NULL, 'Visualiza los comprobantes de Compras antes de imprimir')
GO


UPDATE TiposMovimientos 
 SET Imprime='True'
GO



/****** Objeto:  Table [dbo].[VentasCheques]    Fecha de la secuencia de comandos: 09/18/2009 17:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentasCheques](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_VentasCheques] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_Cheques] FOREIGN KEY([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_Cheques]
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_TiposComprobantes]
GO

