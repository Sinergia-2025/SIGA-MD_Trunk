
/****** Object:  Table [dbo].[ContabilidadAsientosModelo]    Script Date: 07/27/2012 14:41:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContabilidadAsientosModelo](
    [idAsiento] [int] NOT NULL,
    [nombreAsiento] [nvarchar](50) NOT NULL,
    [idPlanCuenta] [int] NOT NULL,
    [idCuenta] [int] NOT NULL,
 CONSTRAINT [PK_ContabilidadAsientosModelo] PRIMARY KEY CLUSTERED 
(
    [idAsiento] ASC,
    [nombreAsiento] ASC,
    [idPlanCuenta] ASC,
    [idCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
