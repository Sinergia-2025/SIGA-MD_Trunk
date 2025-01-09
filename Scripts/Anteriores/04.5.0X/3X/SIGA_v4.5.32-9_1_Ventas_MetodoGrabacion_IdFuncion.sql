
/* ----- Agrego el Campo y coloco X para el Historial ----- */
/* ----- Lo nuevo sera "A" Automatico o "M" Manual ----- */

ALTER TABLE Ventas ADD MetodoGrabacion char(1) NULL
GO
ALTER TABLE Ventas ADD IdFuncion varchar(30) NULL
GO

UPDATE Ventas 
   SET MetodoGrabacion = 'X'
      ,IdFuncion = 'FacturacionV2'
GO

ALTER TABLE Ventas ALTER COLUMN MetodoGrabacion char(1) NOT NULL
GO
ALTER TABLE Ventas ALTER COLUMN IdFuncion varchar(30) NOT NULL
GO

/* ------------- */

ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_IdFuncion FOREIGN KEY
	(
	IdFuncion
	) REFERENCES dbo.Funciones
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
