
--- Genero los registros antes de los cambios para evitar error al crear la PK que NO Existia!!

PRINT '1. Inserto Registro en Bancos de aquellos que Estan en VentasTarjetas y no existen (Muy Mal!).';

IF EXISTS (SELECT 1 FROM VentasTarjetas VT WHERE NOT EXISTS (SELECT 1 FROM Bancos B WHERE B.IdBanco = VT.IdBanco))
	INSERT INTO Bancos
           (IdBanco, NombreBanco, DebitoDirecto, Empresa, Convenio, Servicio)
		SELECT DISTINCT IdBanco, 'A Definir' AS xxNombreBanco, 'False' AS xxDebitoDirecto, NULL AS xxEmpresa, NULL AS xxConvenio, NULL AS xxServicio FROM VentasTarjetas VT WHERE NOT EXISTS (SELECT 1 FROM Bancos B WHERE B.IdBanco = VT.IdBanco)
;


PRINT '2. Agrego Campo VentasTarjetas.Orden';
PRINT '3. Actualizo Campo VentasTarjetas.Orden con 1 (es para repetir tarjeta';
PRINT '4. Borro VentasTarjetas.PK_VentasTarjetas';
PRINT '5. Creo VentasTarjetas.PK_VentasTarjetas incluyendo campo Orden';
PRINT '5. Creo VentasTarjetas.FK_VentasTarjetas_Bancos que no existia';

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
ALTER TABLE dbo.Bancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasTarjetas ADD Orden int NULL
GO
UPDATE VentasTarjetas SET Orden = 1;
ALTER TABLE dbo.VentasTarjetas ALTER COLUMN Orden int NOT NULL
GO
ALTER TABLE dbo.VentasTarjetas DROP CONSTRAINT PK_VentasTarjetas
GO
ALTER TABLE dbo.VentasTarjetas ADD CONSTRAINT
	PK_VentasTarjetas PRIMARY KEY CLUSTERED 
	(IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdTarjeta,IdBanco,Orden)
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.VentasTarjetas ADD CONSTRAINT FK_VentasTarjetas_Bancos
    FOREIGN KEY (IdBanco)
    REFERENCES dbo.Bancos (IdBanco)
    ON UPDATE  NO ACTION ON DELETE NO ACTION
GO
ALTER TABLE dbo.VentasTarjetas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



