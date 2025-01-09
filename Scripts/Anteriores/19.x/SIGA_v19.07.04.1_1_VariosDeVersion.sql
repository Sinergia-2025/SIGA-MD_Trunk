
PRINT ''
PRINT '1. Tabla Compras: Nuevos Campos IdCaja, NumeroPlanilla y NumeroMovimiento'
ALTER TABLE Compras ADD IdCaja int null
ALTER TABLE Compras ADD NumeroPlanilla int null
ALTER TABLE Compras ADD NumeroMovimiento int null
GO
PRINT ''
PRINT '1.1. Tabla Compras: FK a CajasDetalle'
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_CajasDetalle] FOREIGN KEY([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento])
REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_CajasDetalle]
GO

PRINT ''
PRINT '1.2. Tabla Compras: Recuperar lo que se pueda de la historia'
UPDATE C 
SET C.IdCaja = CD.idCaja,
	C.NumeroPlanilla = CD.NumeroPlanilla,
	C.NumeroMovimiento = CD.NumeroMovimiento
FROM Compras C
INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante
INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = C.IdFormasPago
INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor
LEFT JOIN CajasDetalle CD ON CD.Observacion LIKE '%' + TC.Descripcion + '%' 
AND CD.Observacion LIKE '%' + convert(varchar(40),C.NumeroComprobante) + '%' 
AND CD.Observacion LIKE '%' + P.NombreProveedor + '%'  
 where C.IdCaja is null
 AND C.Fecha = CD.FechaMovimiento
 AND FP.Dias = 0;


PRINT ''
PRINT '2. Tabla Repartos: Nuevos Campos'
ALTER TABLE dbo.Repartos ADD TotalResumenComprobante decimal(16,4) null;
ALTER TABLE dbo.Repartos ADD TotalResumenEfectivo decimal(16,4) null;
ALTER TABLE dbo.Repartos ADD TotalResumenCtaCte decimal(16,4) null;
ALTER TABLE dbo.Repartos ADD TotalResumenCheques decimal(16,4) null;
ALTER TABLE dbo.Repartos ADD TotalResumenNCred decimal(16,4) null;
ALTER TABLE dbo.Repartos ADD TotalResumenReenvio decimal(16,4) null;
ALTER TABLE dbo.Repartos ADD TotalResumenSaldoGeneral decimal(16,4) null;
GO

PRINT ''
PRINT '2.1. Tabla Repartos: Valores por defecto a nuevos campos'
UPDATE dbo.Repartos
   SET TotalResumenComprobante=0
     , TotalResumenEfectivo=0
     , TotalResumenCtaCte=0
     , TotalResumenCheques=0
     , TotalResumenNCred=0
     , TotalResumenReenvio=0
     , TotalResumenSaldoGeneral=0;

PRINT ''
PRINT '2.2. Tabla Repartos: NOT NULL a nuevos campos'
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenComprobante decimal(16,4) not null
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenEfectivo decimal(16,4) not null
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenCtaCte decimal(16,4) not null
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenCheques decimal(16,4) not null
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenNCred decimal(16,4) not null
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenReenvio decimal(16,4) not null
ALTER TABLE dbo.Repartos ALTER COLUMN  TotalResumenSaldoGeneral decimal(16,4) not null
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
PRINT ''
PRINT '3. Tabla TareasProgramadas: Nueva tabla'
CREATE TABLE [dbo].[TareasProgramadas](
	[IdTareaProgramada] [int] NOT NULL,
	[IdFuncion] [varchar](30) NOT NULL,
	[Usuario] [varchar](10) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[UltimaFechaEjecucion] [datetime] NULL,
 CONSTRAINT [PK_TareasProgramadas] PRIMARY KEY CLUSTERED 
([IdTareaProgramada] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '3.1. Tabla TareasProgramadasHorarios: Nueva tabla'
CREATE TABLE [dbo].[TareasProgramadasHorarios](
	[IdTareaProgramada] [int] NOT NULL,
	[DiaSemana] [smallint] NOT NULL,
	[HoraProgramada] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TareasProgramadasHorarios] PRIMARY KEY CLUSTERED 
([IdTareaProgramada] ASC,[DiaSemana] ASC,[HoraProgramada] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

PRINT ''
PRINT '3.2. Tabla TareasProgramadasHorarios: FK a TareasProgramadas'
ALTER TABLE [dbo].[TareasProgramadasHorarios]  WITH CHECK ADD  CONSTRAINT [FK_TareasProgramadasHorarios_TareasProgramadas] FOREIGN KEY([IdTareaProgramada])
REFERENCES [dbo].[TareasProgramadas] ([IdTareaProgramada])
GO

ALTER TABLE [dbo].[TareasProgramadasHorarios] CHECK CONSTRAINT [FK_TareasProgramadasHorarios_TareasProgramadas]
GO


PRINT ''
PRINT '4.1. Nueva Opción de Menu: TareasProgramadasABM'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('TareasProgramadasABM', 'Tareas Programadas', 'Tareas Programadas', 'True', 'False', 'True', 'True'
        ,'Configuraciones', 110, 'Eniac.Win', 'TareasProgramadasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
PRINT ''
PRINT '4.2. Roles: TareasProgramadasABM'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TareasProgramadasABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

