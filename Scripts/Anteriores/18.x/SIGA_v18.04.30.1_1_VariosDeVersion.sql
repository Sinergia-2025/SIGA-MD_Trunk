
PRINT '1. Ventas: Menu_PaisesABM - AFIP\PaisesABM'
GO

--Inserto la pantalla nueva
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
    VALUES
        ('PaisesABM', 'ABM de Paises', 'ABM de Paises', 'True', 'False', 'True', 'True',
        'AFIP', 145, 'Eniac.Win', 'PaisesABM', NULL, NULL);

INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'PaisesABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

PRINT '2. Ventas: Tabla_Paises.'
GO

/****** Object:  Table [dbo].[Paises]    Script Date: 27/04/2018 14:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paises](
	[IdPais] [varchar](3) NOT NULL,
	[NombrePais] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
([IdPais] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

INSERT INTO [dbo].[Paises]
           ([IdPais],[NombrePais])
     VALUES
           ('ARS', 'Argentina'),
           ('BOL', 'Bolivia'),
           ('BRA', 'Brasil'),
           ('CHL', 'Chile'),
           ('CHN', 'China'),
           ('PER', 'Perú'),
           ('PRY', 'Paraguay'),
           ('USA', 'Estados Unidos'),
           ('URY', 'Uruguay'),
           ('VEN', 'Venezuela')
GO



PRINT '3. Campos_Provincias_IdPais.'
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
ALTER TABLE dbo.Paises SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Provincias ADD IdPais varchar(3) NULL
GO
UPDATE Provincias SET IdPais = 'ARS';
ALTER TABLE dbo.Provincias ALTER COLUMN IdPais varchar(3) NOT NULL
GO
ALTER TABLE dbo.Provincias ADD CONSTRAINT FK_Provincias_Paises
    FOREIGN KEY (IdPais)
    REFERENCES dbo.Paises (IdPais)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Provincias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



PRINT '4. Campos_Proveedores_IdCuentaBanco.'
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
ALTER TABLE dbo.CuentasBancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Proveedores ADD IdCuentaBanco int NULL
GO
DECLARE @CTABANCOTRANSFBANCARIA int
SELECT @CTABANCOTRANSFBANCARIA = ValorParametro FROM Parametros WHERE IdParametro = 'CTABANCOTRANSFBANCARIA'
UPDATE Proveedores SET IdCuentaBanco = @CTABANCOTRANSFBANCARIA
ALTER TABLE dbo.Proveedores ALTER COLUMN IdCuentaBanco int NOT NULL
GO
ALTER TABLE dbo.Proveedores ADD CONSTRAINT FK_Proveedores_CuentasBancos
    FOREIGN KEY (IdCuentaBanco)
    REFERENCES dbo.CuentasBancos (IdCuentaBanco)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '5. Desactivo función MovimientosDeComprasV2.'
GO
UPDATE Funciones
   SET Visible = 0
 WHERE Id = 'MovimientosDeComprasV2'

