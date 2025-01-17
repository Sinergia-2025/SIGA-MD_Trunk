/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
CREATE TABLE dbo.UnidadesDeMedidas
	(
	IdUnidadDeMedida char(2) NOT NULL,
	NombreUnidadDeMedida varchar(15) NOT NULL,
	ConversionAKilos decimal(7, 3) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.UnidadesDeMedidas ADD CONSTRAINT
	PK_UnidadesDeMedidas PRIMARY KEY CLUSTERED 
	(
	IdUnidadDeMedida
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT


INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('CC', 'Cent. Cubico', 0.001)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('GR', 'Gramo', 0.001)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('KG', 'Kilogramo', 1.000)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('LT', 'Litro', 1.000)
GO

INSERT INTO UnidadesDeMedidas (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos)
 VALUES ('UN', 'Unidad', 0.000)
GO
