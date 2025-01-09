
PRINT ''
PRINT '1. Tabla ChequesHistorial:  Agrego Campos FechaActualizacion, Orden y IdProveedorPreasignado.'
GO
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
ALTER TABLE dbo.ChequesHistorial 
ADD 
[FechaActualizacion] [datetime] NULL ,
[Orden] [int] IDENTITY(1,1) NOT NULL,
[IdProveedorPreasignado][bigint] NULL
GO
COMMIT


PRINT ''
PRINT '2. Tabla ChequesHistorial: Asigno valores a FechaActualizacion.'
PRINT ''
PRINT '2.1. Se Asgina la fecha de Emision porque no tengo manera de saber como ingreso.'
GO
UPDATE ChequesHistorial 
  SET FechaActualizacion = FechaEmision
WHERE NroPlanillaIngreso IS NULL AND NroPlanillaEgreso IS NULL
GO

PRINT ''
PRINT '2.2. Se Asgina la fecha del Movimiento en Caja si detecto que es un Ingreso.'
GO
UPDATE ChequesHistorial
 SET ChequesHistorial.FechaActualizacion =   
       ( SELECT FechaMovimiento FROM CajasDetalle CD
           WHERE ChequesHistorial.IdSucursal = CD.IdSucursal
             AND ChequesHistorial.IdCajaIngreso = CD.IdCaja
             AND ChequesHistorial.NroPlanillaIngreso = CD.NumeroPlanilla
             AND ChequesHistorial.NroMovimientoIngreso = CD.NumeroMovimiento
         )
 WHERE NroPlanillaIngreso>0 AND NroPlanillaEgreso IS NULL
GO

PRINT ''
PRINT '2.3. Se Asgina la fecha del Movimiento en Caja si detecto que es un Egreso.'
GO
UPDATE ChequesHistorial
 SET ChequesHistorial.FechaActualizacion =   
       ( SELECT FechaMovimiento FROM CajasDetalle CD
           WHERE ChequesHistorial.IdSucursal = CD.IdSucursal
             AND ChequesHistorial.IdCajaEgreso = CD.IdCaja
             AND ChequesHistorial.NroPlanillaEgreso = CD.NumeroPlanilla
             AND ChequesHistorial.NroMovimientoEgreso = CD.NumeroMovimiento
         )
 WHERE (NroPlanillaIngreso>0 AND NroPlanillaEgreso>0)
   OR (NroPlanillaIngreso IS NULL AND NroPlanillaEgreso>0)
GO

PRINT ''
PRINT '2.4. Se Asgina la fecha del Movimiento en Caja de Ingreso porque el de Egreso ya no existe.'
GO
UPDATE ChequesHistorial
 SET ChequesHistorial.FechaActualizacion =   
       ( SELECT FechaMovimiento FROM CajasDetalle CD
           WHERE ChequesHistorial.IdSucursal = CD.IdSucursal
             AND ChequesHistorial.IdCajaIngreso = CD.IdCaja
             AND ChequesHistorial.NroPlanillaIngreso = CD.NumeroPlanilla
             AND ChequesHistorial.NroMovimientoIngreso = CD.NumeroMovimiento
         )
 WHERE (NroPlanillaIngreso>0 AND NroPlanillaEgreso>0)
   AND FechaActualizacion IS NULL
GO

--Falta para cheques Rechazados. Ver que hacer.

--
--SELECT * FROM ChequesHistorial
--  WHERE FechaActualizacion IS NULL
--GO
--

-- 
PRINT ''
PRINT '2.4. Se Asgina la fecha de Emision No existe el movimiento de entrada ni salida en caja.'
GO
UPDATE ChequesHistorial 
  SET FechaActualizacion = FechaEmision
WHERE FechaActualizacion IS NULL
GO

PRINT ''
PRINT '3. Tabla ChequesHistorial: Paso FechaActualizacion a NOT NULL y Valor Default GETDATE().'
GO
ALTER TABLE ChequesHistorial ALTER COLUMN [FechaActualizacion] [datetime] NOT NULL
GO

ALTER TABLE ChequesHistorial 
    ADD CONSTRAINT DF_ChequesHistorial_FechaActualizacion DEFAULT getdate() FOR FechaActualizacion
GO

PRINT ''
PRINT '4. Tabla ChequesHistorial: Creo Clave Primaria.'
GO
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.ChequesHistorial ADD CONSTRAINT
	PK_ChequesHistorial PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	NumeroCheque,
	IdBanco,
	IdBancoSucursal,
	IdLocalidad,
	Orden
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ChequesHistorial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Menu Nuevo: Caja\Informe Historico de Cheques.'
GO
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Caja')
--Inserto la Pantalla Nueva
BEGIN
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('InformeHistoricoCheques', 'Informe Historico de Cheques', 'Informe Historico de Cheques', 
		'True', 'False', 'True', 'True', 'Caja',77, 'Eniac.Win', 'InformeHistoricoCheques', null, null,'N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeHistoricoCheques' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END;
GO


PRINT ''
PRINT '6. TRIGGER ChequesActualizaHistorial: Se vuelve a crear con los campos nuevbos.'
GO
ALTER TRIGGER [dbo].[ChequesActualizaHistorial] 
   ON  [dbo].[Cheques] 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
   INSERT INTO ChequesHistorial
			(IdSucursal
			, NumeroCheque
			, IdBanco
			, IdBancoSucursal
			, IdLocalidad
			, FechaEmision
			, FechaCobro
			, Titular
			, Importe
			, IdCajaIngreso
			, NroPlanillaIngreso
			, NroMovimientoIngreso
			, IdCajaEgreso
			, NroPlanillaEgreso
			, NroMovimientoEgreso
			, EsPropio
			, IdCuentaBancaria
			, IdEstadoCheque
			, IdEstadoChequeAnt
			, Cuit
			, IdCliente
			, IdProveedor
			, IdProveedorPreasignado)
    SELECT IdSucursal
		, NumeroCheque
		, IdBanco
		, IdBancoSucursal
		, IdLocalidad
		, FechaEmision
		, FechaCobro
		, Titular
		, Importe
		, IdCajaIngreso
		, NroPlanillaIngreso
		, NroMovimientoIngreso
		, IdCajaEgreso
		, NroPlanillaEgreso
		, NroMovimientoEgreso
		, EsPropio
		, IdCuentaBancaria
		, IdEstadoCheque
		, IdEstadoChequeAnt
		, Cuit
		, IdCliente
		, IdProveedor
		, IdProveedorPreasignado
  FROM INSERTED
END
GO


PRINT ''
PRINT '7. Tabla Parametros: Creo los nuevos para el Actualizador Automatico.'
GO
INSERT INTO [Parametros]          
			([IdParametro],[ValorParametro],[CategoriaParametro],[DescripcionParametro])
     VALUES
           ('FTPSUBEINFOALSERVIDOR2','False','','Controla si sube info al segundo servidor.'),
           ('FTPPASSWORD2','','','Clave del FTP.'),
           ('FTPSERVIDOR2','','','Servidor de FTP.'),
           ('FTPUSUARIO2','','','Usuario del FTP.'),
           ('FTPCARPETAREMOTA2','','','Clave del servidor de FTP.'),
           ('FTPCONEXIONPASIVA2','True','','Tipo de conexión de FTP.')
GO
