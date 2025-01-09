DROP TABLE [dbo].[ContabilidadCuentasRubros]
GO

/****** Object:  Table [dbo].[ContabilidadCuentasRubros]    Script Date: 09/17/2012 15:42:52 ******/
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
 CONSTRAINT [PK_ContabilidadCuentasRubros] PRIMARY KEY CLUSTERED 
(
    [idRubro] ASC,
    [IdCuenta] ASC,
    [IdPlanCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

