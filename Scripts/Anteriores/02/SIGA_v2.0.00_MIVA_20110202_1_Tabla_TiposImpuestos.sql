
/* ------ TABLA ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposImpuestos](
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[NombreTipoImpuesto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposImpuestos] PRIMARY KEY CLUSTERED 
(
	[IdTipoImpuesto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/* ------ REGISTROS ------ */

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('IIBB', 'Ingresos Brutos')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('IVA', 'Impuesto al Valor Agregado')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('PGANA', 'Percepcion Ganancias')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('PIIBB', 'Percepcion Ingresos Brutos')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('PIVA', 'Percepcion IVA')
GO

INSERT INTO TiposImpuestos  (IdTipoImpuesto, NombreTipoImpuesto)
     VALUES ('PVAR', 'Percepcion Varias')
GO

