
PRINT ''
PRINT '1. Nueva Tabla: Dispositivos.'
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Dispositivos](
	[IdDispositivo] [varchar](100) NOT NULL,
	[NombreDispositivo] [varchar](50) NOT NULL,
	[FechaUltimoLogin] [datetime] NOT NULL,
	[UsuarioUltimoLogin] [varchar](10) NOT NULL,
	[IdTipoDispositivo] [varchar](10) NOT NULL,
	[SistemaOperativo] [varchar](100) NOT NULL,
	[ArquitecturaSO] [varchar](10) NOT NULL,
	[NumeroSerieDiscoRigido] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Dispositivos] PRIMARY KEY CLUSTERED 
(
	[IdDispositivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


PRINT ''
PRINT '2. Tabla Calendarios: Nuevo Campo DiasHabilitacionReserva y Seteo a 365.'
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
ALTER TABLE dbo.Calendarios ADD DiasHabilitacionReserva int NULL
GO
UPDATE Calendarios SET DiasHabilitacionReserva = 365;
ALTER TABLE dbo.Calendarios ALTER COLUMN DiasHabilitacionReserva int NOT NULL
GO
ALTER TABLE dbo.Calendarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla CargosClientes: Ajuste de Precio de Lista incorrecto.'
GO

-- Ajusto en caso de NO Utilizar Descuento o NO existir el parametro.

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CARGOSUTILIZADESCUENTOSRECARGOS' 
                AND P.ValorParametro IN ('False'))
 OR NOT EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CARGOSUTILIZADESCUENTOSRECARGOS')

BEGIN

	UPDATE CargosClientes
	   SET DescuentoRecargoPorc1 = 0
	      ,DescuentoRecargoPorc2 = 0
	      ,PrecioLista = Monto
	 WHERE PrecioLista <> Monto
	;
	
END


PRINT ''
PRINT '4. Parametros: Activar Cargos Utiliza Descuentos Recargos.'
GO

MERGE INTO Parametros AS P
        USING (SELECT 'CARGOSUTILIZADESCUENTOSRECARGOS' AS IdParametro, 'True' ValorParametro, 'Cargos Utiliza Precios'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
