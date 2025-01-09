
/****** Object:  Table [dbo].[ContabilidadAsientosCuentasTmp]    Script Date: 11/20/2012 12:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContabilidadAsientosCuentasTmp](
	[IdPlanCuenta] [int] NOT NULL,
	[IdAsiento] [int] NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[IdRenglon] [int] NOT NULL,
	[Debe] [decimal](12, 2) NOT NULL,
	[Haber] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ContabilidadAsientosCuentasTmp] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC,
	[IdAsiento] ASC,
	[IdCuenta] ASC,
	[IdRenglon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientos] FOREIGN KEY([IdPlanCuenta], [IdAsiento])
REFERENCES [dbo].[ContabilidadAsientos] ([IdPlanCuenta], [IdAsiento])
GO

ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientos]
GO

ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadCuentas] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta])
GO

ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadCuentas]
GO


