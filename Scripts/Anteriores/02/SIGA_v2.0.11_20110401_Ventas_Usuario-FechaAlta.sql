
ALTER TABLE dbo.Ventas ADD
	Usuario varchar(10) NULL,
	FechaAlta datetime NULL
GO


UPDATE dbo.Ventas SET
	 Usuario = 'admin'
	,FechaAlta = Fecha
GO


ALTER TABLE dbo.Ventas ALTER COLUMN Usuario varchar(10) NOT NULL
GO


ALTER TABLE dbo.Ventas ALTER COLUMN FechaAlta datetime NOT NULL
GO

