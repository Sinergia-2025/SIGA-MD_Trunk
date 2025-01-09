
/* ------------ Creacion de Tabla PERIODOSFISCALES ------------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PeriodosFiscales](
	[PeriodoFiscal] [int] NOT NULL,
	[TotalNetoVentas] [decimal](10, 2) NOT NULL,
	[TotalImpuestosVentas] [decimal](10, 2) NOT NULL,
	[TotalVentas] [decimal](10, 2) NOT NULL,
	[TotalNetoCompras] [decimal](10, 2) NOT NULL,
	[TotalImpuestosCompras] [decimal](10, 2) NOT NULL,
	[TotalCompras] [decimal](10, 2) NOT NULL,
	[Posicion] [decimal](10, 2) NOT NULL,
	[FechaCierre] [date] NULL,
	[UsuarioCierre] [varchar](10) NULL,
 CONSTRAINT [PK_PeriodosFiscales] PRIMARY KEY CLUSTERED 
(
	[PeriodoFiscal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PeriodosFiscales]  WITH CHECK ADD  CONSTRAINT [FK_PeriodosFiscales_Usuarios] FOREIGN KEY([UsuarioCierre])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[PeriodosFiscales] CHECK CONSTRAINT [FK_PeriodosFiscales_Usuarios]
GO

/* ------------ Agregar Campo de la Tabla COMPRAS y FK ------------ */

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
ALTER TABLE dbo.PeriodosFiscales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Compras ADD
	PeriodoFiscal int NULL
GO
ALTER TABLE dbo.Compras ADD CONSTRAINT
	FK_Compras_PeriodosFiscales FOREIGN KEY
	(
	PeriodoFiscal
	) REFERENCES dbo.PeriodosFiscales
	(
	PeriodoFiscal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO

COMMIT


/* ------------ Registros de la Tabla PERIODOSFISCALES ------------ */

INSERT INTO PeriodosFiscales
   (PeriodoFiscal, TotalNetoVentas, TotalImpuestosVentas, TotalVentas, TotalNetoCompras, 
    TotalImpuestosCompras, TotalCompras, Posicion, FechaCierre, UsuarioCierre)
SELECT PeriodoFiscal
      ,SUM(TotalNetoVentas) AS TotalNetoVentas
      ,SUM(TotalIVAVentas) AS TotalIVAVentas
      ,SUM(TotalVentas) as TotalVentas      
      ,SUM(TotalNetoCompras) AS TotalNetoCompras
      ,SUM(TotalIVACompras) AS TotalIVACompras
      ,SUM(TotalCompras) as TotalCompras
      ,SUM(TotalIVAVentas) - SUM(TotalIVACompras) AS Posicion
      ,CONVERT(date, FechaCierre) AS FechaCierre
      ,'Admin' AS UsuarioCierre
FROM 
(
SELECT YEAR(Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
      ,SUM(Subtotal) AS TotalNetoVentas
      ,SUM(TotalImpuestos) AS TotalIVAVentas
      ,SUM(ImporteTotal) as TotalVentas      
      ,0 AS TotalNetoCompras
      ,0 AS TotalIVACompras
      ,0 AS TotalCompras
      ,CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120) AS FechaCierre
  FROM Ventas
  GROUP BY YEAR(Fecha)*100+MONTH(Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120)
UNION ALL
SELECT YEAR(Fecha)*100+MONTH(Fecha) AS PeriodoFiscal
      ,0 AS TotalNetoVentas
      ,0 AS TotalIVAVentas
      ,0 AS TotalVentas      
      ,SUM(Neto210+Neto105+Neto270) AS TotalNetoCompras
      ,SUM(IVA210+IVA105+IVA270) AS TotalIVACompras
      ,SUM(ImporteTotal) as TotalCompras
      ,CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120) AS FechaCierre
  FROM Compras
  GROUP BY YEAR(Fecha)*100+MONTH(Fecha), CONVERT(varchar(11), DATEADD(MONTH, 1, Fecha-DAY(Fecha)), 120)
) A
  GROUP BY A.PeriodoFiscal, A.FechaCierre
GO

/* ------------ Dejo abierto el Periodo Fiscal Actual  ------------ */

UPDATE PeriodosFiscales SET 
    FechaCierre = NULL
   ,UsuarioCierre = NULL
 WHERE YEAR(FechaCierre) = YEAR(GETDATE()) AND MONTH(FechaCierre) = MONTH(GETDATE())
GO


/* ------------ Actualizar Campo de la Tabla COMPRAS ------------ */


UPDATE Compras SET PeriodoFiscal = YEAR(Fecha)*100+MONTH(Fecha) 
  WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
GO


--ALTER TABLE dbo.Compras ALTER COLUMN PeriodoFiscal int NOT NULL
--GO
