
ALTER TABLE ProductosComponentes ADD
	IdFormula int NULL	
GO

UPDATE ProductosComponentes 
   SET IdFormula = 1
GO


ALTER TABLE ProductosComponentes ALTER COLUMN IdFormula int NOT NULL
GO

ALTER TABLE ProductosComponentes DROP CONSTRAINT [PK_ProductosComponentes]
GO

ALTER TABLE ProductosComponentes ADD
 CONSTRAINT [PK_ProductosComponentes] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,	
	[IdFormula] ASC,
	[IdProductoComponente] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

