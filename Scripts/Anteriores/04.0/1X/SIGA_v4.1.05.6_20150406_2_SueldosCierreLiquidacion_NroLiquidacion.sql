
ALTER TABLE SueldosCierreLiquidacion ADD NroLiquidacion int null
GO

UPDATE SueldosCierreLiquidacion SET NroLiquidacion = 1
GO

ALTER TABLE SueldosCierreLiquidacion ALTER COLUMN NroLiquidacion int not null
GO

ALTER TABLE SueldosCierreLiquidacion DROP CONSTRAINT [PK_SueldosCierreLiquidacion_1]
GO

ALTER TABLE SueldosCierreLiquidacion ADD CONSTRAINT [PK_SueldosCierreLiquidacion] PRIMARY KEY CLUSTERED 
(
	[IdLegajo] ASC,
	[IdTipoConcepto] ASC,
	[IdConcepto] ASC,
	[IdTipoRecibo] ASC,
	[PeriodoLiquidacion] ASC,
	[NroLiquidacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
