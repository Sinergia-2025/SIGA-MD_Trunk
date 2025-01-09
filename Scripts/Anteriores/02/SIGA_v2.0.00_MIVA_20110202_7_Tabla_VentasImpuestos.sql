
/* ------ TABLA ------ */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasImpuestos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[Bruto] [decimal](12, 2) NOT NULL,
	[Neto] [decimal](12, 2) NOT NULL,
	[Importe] [decimal](12, 2) NOT NULL,
	[Total] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_VentasImpuestos_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdTipoImpuesto] ASC,
	[Alicuota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasImpuestos]  WITH CHECK ADD  CONSTRAINT [FK_VentasImpuestos_Impuestos] FOREIGN KEY([IdTipoImpuesto], [Alicuota])
REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota])
GO

ALTER TABLE [dbo].[VentasImpuestos] CHECK CONSTRAINT [FK_VentasImpuestos_Impuestos]
GO

ALTER TABLE [dbo].[VentasImpuestos]  WITH CHECK ADD  CONSTRAINT [FK_VentasImpuestos_Ventas] FOREIGN KEY([IdTipoImpuesto], [Alicuota])
REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota])
GO

ALTER TABLE [dbo].[VentasImpuestos] CHECK CONSTRAINT [FK_VentasImpuestos_Ventas]
GO



/* ------ REGISTROS ------ */


INSERT INTO VentasImpuestos
      (IdSucursal
      ,IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,IdTipoImpuesto
      ,Alicuota
      ,Bruto
      ,Neto
      ,Importe
      ,Total)
SELECT IdSucursal
      ,IdTipoComprobante
      ,Letra
      ,CentroEmisor
      ,NumeroComprobante
      ,'IVA' AS IdTipoImpuesto
      ,AlicuotaImpuesto
      ,SUM(ImporteTotal) AS Bruto
      ,SUM(ImporteTotalNeto) AS Neto
      ,SUM(ImporteImpuesto) AS Importe
      ,SUM(ImporteTotalNeto + ImporteImpuesto) AS Total
  FROM VentasProductos
  GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, AlicuotaImpuesto

