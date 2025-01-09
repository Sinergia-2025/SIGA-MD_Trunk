
ALTER TABLE SueldosCierreLiqDatos ADD NroLiquidacion int null
GO

UPDATE SueldosCierreLiqDatos SET NroLiquidacion = 1
GO

ALTER TABLE SueldosCierreLiqDatos ALTER COLUMN NroLiquidacion int not null
GO

ALTER TABLE SueldosCierreLiqDatos DROP CONSTRAINT [PK_SueldosCierreLiqDatos]
GO

ALTER TABLE SueldosCierreLiqDatos ADD CONSTRAINT [PK_SueldosCierreLiqDatos] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[IdTipoRecibo] ASC,
	[PeriodoLiquidacion] ASC,
	[NroLiquidacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
