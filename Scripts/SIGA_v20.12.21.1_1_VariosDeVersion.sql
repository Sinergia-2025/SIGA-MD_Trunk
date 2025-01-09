ALTER TABLE dbo.Calendarios ADD SolicitaEmbarcacion bit NULL
ALTER TABLE dbo.Calendarios ADD SolicitaBotado bit NULL
GO

UPDATE Calendarios SET SolicitaEmbarcacion = 'False', SolicitaBotado = 'False';

ALTER TABLE dbo.Calendarios ALTER COLUMN SolicitaEmbarcacion bit NOT NULL
ALTER TABLE dbo.Calendarios ALTER COLUMN SolicitaBotado bit NOT NULL
GO

IF dbo.BaseConCuit('30711934088') = 1
BEGIN
    UPDATE Calendarios
       SET SolicitaEmbarcacion = 'True';
    UPDATE Calendarios
       SET SolicitaBotado = 'True'
     WHERE IdCalendario BETWEEN 5 AND 7;

    UPDATE Calendarios
       SET PublicarEnWeb = 'True'
         , IdNave = IdCalendario - 1
     WHERE IdCalendario BETWEEN 2 AND 4

END


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
EXECUTE sp_rename N'dbo.Reservas', N'ReservasTurismo', 'OBJECT' 
EXECUTE sp_rename N'dbo.ReservasPasajeros', N'ReservasTurismoPasajeros', 'OBJECT' 
EXECUTE sp_rename N'dbo.ReservasProductos', N'ReservasTurismoProductos', 'OBJECT' 
GO
ALTER TABLE dbo.ReservasTurismo SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.ReservasTurismoPasajeros SET (LOCK_ESCALATION = TABLE)
ALTER TABLE dbo.ReservasTurismoProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


