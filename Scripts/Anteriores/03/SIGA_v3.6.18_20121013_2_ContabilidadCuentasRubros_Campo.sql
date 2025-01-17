
ALTER TABLE [dbo].[ContabilidadCuentasRubros] ADD [Campo] [varchar](20) NOT NULL
GO

/*

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContabilidadCuentasRubros](
	[idRubro] [int] NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[IdPlanCuenta] [int] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[debe] [bit] NULL,
	[haber] [bit] NULL,
	[grupoAsiento] [int] NULL,
	[campo] [nvarchar](20) NULL,
 CONSTRAINT [PK_ContabilidadCuentasRubros] PRIMARY KEY CLUSTERED 
(
	[idRubro] ASC,
	[IdCuenta] ASC,
	[IdPlanCuenta] ASC,
	[Tipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

*/

/*
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (1, 10401007, 1, N'COMPRAS', 1, 0, NULL, N'Iva Compra')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (1, 20101001, 1, N'COMPRAS', 0, 1, NULL, N'Imp Total')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (1, 40102001, 1, N'COMPRAS', 1, 0, NULL, N'Sub Total')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (1, 40102002, 1, N'COMPRAS', 1, 0, NULL, N'Sub Total')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 10301002, 1, N'VENTAS', 1, 0, NULL, N'Imp. Total')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 10401007, 1, N'COMPRAS', 1, 0, NULL, N'Iva Compra')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 10401007, 1, N'VENTAS', 0, 1, NULL, N'IVA 21%')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 10501001, 1, N'VENTAS', 0, 1, NULL, N'Stock Costo')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 20101001, 1, N'COMPRAS', 0, 1, NULL, N'Imp Total')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 40102001, 1, N'COMPRAS', 1, 0, NULL, N'Sub Total')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 40102001, 1, N'VENTAS', 1, 0, NULL, N'Inventario')
INSERT [dbo].[ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [campo]) VALUES (2, 40102002, 1, N'VENTAS', 0, 1, NULL, N'Imp. Bruto')
*/
