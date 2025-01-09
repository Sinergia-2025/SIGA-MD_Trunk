
/* ----- Agrego el Campo y coloco X para el Historial ----- */
/* ----- Lo nuevo sera "A" Automatico o "M" Manual ----- */

ALTER TABLE Compras ADD MetodoGrabacion char(1) NULL
GO
ALTER TABLE Compras ADD IdFuncion varchar(30) NULL
GO

UPDATE Compras
   SET MetodoGrabacion = 'X'
      ,IdFuncion = 'MovimientosDeCompras'
GO

ALTER TABLE Compras ALTER COLUMN MetodoGrabacion char(1) NOT NULL
GO
ALTER TABLE Compras ALTER COLUMN IdFuncion varchar(30) NOT NULL
GO

/* ------------- */

ALTER TABLE dbo.Compras ADD CONSTRAINT
	FK_Compras_IdFuncion FOREIGN KEY
	(
	IdFuncion
	) REFERENCES dbo.Funciones
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
