
PRINT ''
PRINT '1. Tabla dbo.EstadosPedidos: Agrego Varios Campos Divide.'
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
ALTER TABLE dbo.EstadosPedidos ADD Divide bit NULL
ALTER TABLE dbo.EstadosPedidos ADD IdEstadoDivideA varchar(10) NULL
ALTER TABLE dbo.EstadosPedidos ADD IdEstadoDivideB varchar(10) NULL
ALTER TABLE dbo.EstadosPedidos ADD PorcDivideA decimal(6, 2) NULL
ALTER TABLE dbo.EstadosPedidos ADD PorcDivideB decimal(6, 2) NULL
ALTER TABLE dbo.EstadosPedidos ADD SolicitaSucursalParaTipoComprobante bit NULL
GO
UPDATE EstadosPedidos SET Divide = 0, PorcDivideA = 0, PorcDivideB = 0, SolicitaSucursalParaTipoComprobante = 0;
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN Divide bit NOT NULL
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN PorcDivideA decimal(6, 2) NOT NULL
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN PorcDivideB decimal(6, 2) NOT NULL
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN SolicitaSucursalParaTipoComprobante bit NOT NULL
GO
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Creo Tabla Aplicaciones.'
GO

/****** Object:  Table [dbo].[Aplicaciones]    Script Date: 09/14/2018 11:49:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Aplicaciones](
	[IdAplicacion] [varchar](20) NOT NULL,
	[NombreAplicacion] [varchar](40) NOT NULL,
	[IdAplicacionBase] [varchar](20) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


PRINT ''
PRINT '3. Tabla Aplicaciones: Creo PK.'
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
ALTER TABLE dbo.Aplicaciones ADD CONSTRAINT
	PK_Aplicaciones PRIMARY KEY CLUSTERED 
	(
	IdAplicacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Aplicaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla Aplicaciones: Creo FK Aplicacion Base.'
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
ALTER TABLE dbo.Aplicaciones ADD CONSTRAINT
	FK_Aplicaciones_Aplicaciones FOREIGN KEY
	(
	IdAplicacionBase
	) REFERENCES dbo.Aplicaciones
	(
	IdAplicacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Aplicaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla Aplicaciones: Inserto Registro Aplicacion de Parametros.'
GO

-- Inserto la Aplicacion que se registro en Parametros.

INSERT INTO Aplicaciones (IdAplicacion, NombreAplicacion, IdAplicacionBase)
SELECT ValorParametro, ValorParametro, NULL FROM Parametros
 WHERE IdParametro = 'IDAPLICACION'
GO


PRINT ''
PRINT '6. Tabla Aplicaciones: Solo HAR - Inserto Zonas Geograficas.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN

	INSERT INTO Aplicaciones (IdAplicacion, NombreAplicacion, IdAplicacionBase)
		SELECT IdZonaGeografica, NombreZonaGeografica, null
		  FROM ZonasGeograficas
		 WHERE IdZonaGeografica NOT IN 
			  (
			   SELECT ValorParametro FROM Parametros
				WHERE IdParametro = 'IDAPLICACION'
			  )  

END
;


PRINT ''
PRINT '7. Nueva Pantalla: CRM\Aplicaciones.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CRM')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('AplicacionesABM', 'Aplicaciones', 'Aplicaciones', 'True', 'False', 'True', 'True',
              'CRM', 10, 'Eniac.Win', 'AplicacionesABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'AplicacionesABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm' );
    END;



PRINT ''
PRINT '8. Tabla Clientes/Prospectos: Agrego Campos IdAplicacion/Edicion.'
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
ALTER TABLE dbo.Clientes ADD IdAplicacion varchar(20) null
ALTER TABLE dbo.Clientes ADD Edicion varchar(15) null
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaClientes ADD IdAplicacion varchar(20) null
ALTER TABLE dbo.AuditoriaClientes ADD Edicion varchar(15) null
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Prospectos ADD IdAplicacion varchar(20) null
ALTER TABLE dbo.Prospectos ADD Edicion varchar(15) null
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProspectos ADD IdAplicacion varchar(20) null
ALTER TABLE dbo.AuditoriaProspectos ADD Edicion varchar(15) null
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '8. Tabla Aplicaciones: Agrego FK IdAplicacion.'
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
ALTER TABLE dbo.Aplicaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_Aplicaciones FOREIGN KEY
	(
	IdAplicacion
	) REFERENCES dbo.Aplicaciones
	(
	IdAplicacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '9. Tabla Clientes: Solo HAR - Setear IdAplicacion por Zonas Geograficas.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN

	UPDATE Clientes
	   SET IdAplicacion = IdZonaGeografica

END
;

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
ALTER TABLE dbo.Aplicaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT
	FK_Prospectos_Aplicaciones FOREIGN KEY
	(
	IdAplicacion
	) REFERENCES dbo.Aplicaciones
	(
	IdAplicacion
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '10. Tabla Prospectos: Solo HAR - Setear IdAplicacion por Zonas Geograficas.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN

	UPDATE Prospectos
	   SET IdAplicacion = IdZonaGeografica

END
;

PRINT ''
PRINT '11. Tablas CargosClientes/LiquidacionesDetallesClientes: Agrego Campo DescuentoRecargoPorcGral.'
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
ALTER TABLE dbo.CargosClientes ADD DescuentoRecargoPorcGral decimal(10, 5) NULL
GO
UPDATE CargosClientes SET DescuentoRecargoPorcGral = 0;
ALTER TABLE dbo.CargosClientes ALTER COLUMN DescuentoRecargoPorcGral decimal(10, 5) NOT NULL
GO
ALTER TABLE dbo.CargosClientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes ADD DescuentoRecargoPorcGral decimal(10, 5) NULL
GO
UPDATE LiquidacionesDetallesClientes SET DescuentoRecargoPorcGral = 0;
ALTER TABLE dbo.LiquidacionesDetallesClientes ALTER COLUMN DescuentoRecargoPorcGral decimal(10, 5) NOT NULL
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '12. Traducciones: Solo Met. Alm. - Agrego Traduccion Kilaje.'
GO

--Metalurgica Almafuerte.
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('20231852698'))
BEGIN
    INSERT INTO Traducciones
               (IdFuncion,Pantalla,Control,IdIdioma,Texto)
         VALUES
               ('SIGA','PedidosClientesV2','lblTamanio','es_AR','Kilaje')
END;
