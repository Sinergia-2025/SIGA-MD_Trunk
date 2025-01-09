SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
PRINT ''
PRINT '1. Nueva tabla CRMNovedadesCambiosEstados'
CREATE TABLE [dbo].[CRMNovedadesCambiosEstados](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[IdNovedad] [bigint] NOT NULL,
	[IdCambioEstado] [int] NOT NULL,
	[FechaCambioEstado] [datetime] NOT NULL,
	[IdEstadoNovedad] [int] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CRMNovedadesCambiosEstados] PRIMARY KEY CLUSTERED 
([IdTipoNovedad] ASC,[Letra] ASC,[CentroEmisor] ASC,[IdNovedad] ASC,[IdCambioEstado] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CRMNovedadesCambiosEstados]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesCambiosEstados_CRMEstadosNovedades] FOREIGN KEY([IdEstadoNovedad])
REFERENCES [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad])
GO
ALTER TABLE [dbo].[CRMNovedadesCambiosEstados] CHECK CONSTRAINT [FK_CRMNovedadesCambiosEstados_CRMEstadosNovedades]
GO

ALTER TABLE [dbo].[CRMNovedadesCambiosEstados]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesCambiosEstados_CRMNovedades] FOREIGN KEY([IdTipoNovedad], [Letra], [CentroEmisor], [IdNovedad])
REFERENCES [dbo].[CRMNovedades] ([IdTipoNovedad], [Letra], [CentroEmisor], [IdNovedad])
GO
ALTER TABLE [dbo].[CRMNovedadesCambiosEstados] CHECK CONSTRAINT [FK_CRMNovedadesCambiosEstados_CRMNovedades]
GO

ALTER TABLE [dbo].[CRMNovedadesCambiosEstados]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesCambiosEstados_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[CRMNovedadesCambiosEstados] CHECK CONSTRAINT [FK_CRMNovedadesCambiosEstados_Usuarios]
GO

PRINT ''
PRINT '2. Tabla Productos: Nuevo campo NombreProductoWeb'
-- Verifica no Exista Campo en Productos.- --
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Productos' AND COLUMN_NAME = 'NombreProductoWeb')
BEGIN
    ALTER TABLE dbo.Productos ADD NombreProductoWeb varchar(60) NULL
    ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
END

PRINT ''
PRINT '2.1. Tabla AuditoriaProductos: Nuevo campo NombreProductoWeb'
-- Verifica no Exista Campo en Auditoria Productos.- --
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AuditoriaProductos' AND COLUMN_NAME = 'NombreProductoWeb')
BEGIN
    ALTER TABLE dbo.AuditoriaProductos ADD NombreProductoWeb varchar(60) NULL
    ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
END

PRINT ''
PRINT '3. Tabla CategoriasFiscales: Se actualiza el valor del campo Es Pasible Percepcion IIBB a True'
UPDATE CategoriasFiscales
   SET EsPasiblePercIIBB = 'True'
 WHERE IdCategoriaFiscal = 9


PRINT ''
PRINT '4. Tabla CRMNovedadesCambiosEstados: Inicializar tabla con datos iniciales'
INSERT INTO [dbo].[CRMNovedadesCambiosEstados]
           ([IdTipoNovedad]
           ,[Letra]
           ,[CentroEmisor]
           ,[IdNovedad]
           ,[IdCambioEstado]
           ,[FechaCambioEstado]
           ,[IdEstadoNovedad]
           ,[IdUsuario])

SELECT S.IdTipoNovedad, S.Letra, S.CentroEmisor, S.IdNovedad
     , ROW_NUMBER() OVER(PARTITION BY S.IdNovedad ORDER BY S.IdNovedad ASC, CASE WHEN S.Hist = 1 THEN S.FechaSeguimiento ELSE N.FechaAlta END ASC) AS IdCambioEstado
     , CASE WHEN S.Hist = 1 THEN S.FechaSeguimiento ELSE N.FechaAlta END FechaCambioEstado
     , E.IdEstadoNovedad IdEstadoNovedad --, E.NombreEstadoNovedad NombreEstado
     , CASE WHEN S.Hist = 1 THEN S.UsuarioSeguimiento ELSE N.IdUsuarioAlta END IdUsuario
  FROM (SELECT *
             , SUBSTRING(S.ParEstado, 0, CHARINDEX('|', S.ParEstado)) NombreEstadoOrigen
             , SUBSTRING(S.ParEstado, CHARINDEX('|', S.ParEstado) + 1, LEN(S.ParEstado) - CHARINDEX('|', S.ParEstado) - 1) NombreEstadoDestino
          FROM (
                SELECT S.IdTipoNovedad, S.Letra, S.CentroEmisor, S.IdNovedad, S.IdSeguimiento, S.FechaSeguimiento, UsuarioSeguimiento
                     , REPLACE(REPLACE(S.Comentario, 'Cambió el Estado de ', ''), ' a ', '|') ParEstado
                     , 0 Hist
                     --, ' ', *
                  FROM (SELECT IdTipoNovedad, Letra, CentroEmisor, IdNovedad, MIN(IdSeguimiento) IdSeguimiento FROM CRMNovedadesSeguimiento WHERE Comentario LIKE 'Cambió el Estado de %' GROUP BY IdTipoNovedad, Letra, CentroEmisor, IdNovedad) Q
                 INNER JOIN CRMNovedadesSeguimiento S ON S.IdTipoNovedad = Q.IdTipoNovedad
                                                     AND S.Letra         = Q.Letra
                                                     AND S.CentroEmisor  = Q.CentroEmisor
                                                     AND S.IdNovedad     = Q.IdNovedad
                                                     AND S.IdSeguimiento = Q.IdSeguimiento
                 WHERE S.Comentario LIKE 'Cambió el Estado de %'
                   AND S.IdTipoNovedad = 'PENDIENTE'
--                   AND S.IdNovedad = 21000
                UNION ALL
                SELECT IdTipoNovedad, Letra, CentroEmisor, IdNovedad, IdSeguimiento, FechaSeguimiento, UsuarioSeguimiento
                     , REPLACE(REPLACE(Comentario, 'Cambió el Estado de ', ''), ' a ', '|') ParEstado
                     , 1 Hist
                     --, ' ', *
                  FROM CRMNovedadesSeguimiento
                 WHERE Comentario LIKE 'Cambió el Estado de %'
                   AND IdTipoNovedad = 'PENDIENTE'
--                   AND IdNovedad = 21000
               ) S
       ) S
 INNER JOIN CRMNovedades N ON S.IdTipoNovedad = N.IdTipoNovedad
                          AND S.Letra         = N.Letra
                          AND S.CentroEmisor  = N.CentroEmisor
                          AND S.IdNovedad     = N.IdNovedad
 INNER JOIN CRMEstadosNovedades E ON E.NombreEstadoNovedad = CASE WHEN Hist = 1 THEN S.NombreEstadoDestino ELSE S.NombreEstadoOrigen END
                                 AND E.IdTipoNovedad       = S.IdTipoNovedad
 ORDER BY S.IdTipoNovedad, S.Letra, S.CentroEmisor, S.IdNovedad, FechaCambioEstado

PRINT ''
PRINT '4.1. Tabla CRMNovedadesSeguimiento: Ocultar los comentarios de Cambio de Estado viejos'
UPDATE CRMNovedadesSeguimiento
   SET EsComentario = 'False'
  FROM CRMNovedadesSeguimiento
 WHERE Comentario LIKE '%Cambio de estado%'


PRINT ''
PRINT '5. Menu: Alerta de Cambio de Categoria de Cliente'
/*FUNCION ALERTA CLIENTES CON CAMBIO DE CATEGORIA*/
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('AlertaCambioCategoriaCliente', 'Alerta de Cambio de Categoria de Cliente', 'Alerta de Cambio de Categoria de Cliente', 'False', 'False', 'True', 'False'
        ,'Clientes', 280, 'Eniac.Win', 'Clientes', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AlertaCambioCategoriaCliente' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '6. Parametros: Corrección de ValorParametro para evitar error en la carga de Parámetros'
IF dbo.BaseConCuit('30715534181') = 1 
BEGIN
	DECLARE @valorParametro VARCHAR(MAX)

	IF (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CTACAJALIQUIDACIONTARJETA') = 'True'
	BEGIN
	PRINT '1.1 Corrección parámetro CTACAJALIQUIDACIONTARJETA'
		SET @valorParametro = (SELECT IdCuentaCaja FROM CuentasDeCajas WHERE NombreCuentaCaja = 'Liquidaciones Tarjeta')
		UPDATE P SET P.ValorParametro = @valorParametro FROM Parametros P WHERE P.IdParametro = 'CTACAJALIQUIDACIONTARJETA'
	END

	IF (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CTABANCOLIQUIDACIONTARJETA') = 'True'
	BEGIN
	PRINT '1.2 Corrección parámetro CTABANCOLIQUIDACIONTARJETA'
		SET @valorParametro = (SELECT IdCuentaBanco FROM CuentasBancos WHERE NombreCuentaBanco = 'Liquidaciones Tarjeta')
		UPDATE P SET P.ValorParametro = @valorParametro FROM Parametros P WHERE P.IdParametro = 'CTABANCOLIQUIDACIONTARJETA'
	END

END
GO
