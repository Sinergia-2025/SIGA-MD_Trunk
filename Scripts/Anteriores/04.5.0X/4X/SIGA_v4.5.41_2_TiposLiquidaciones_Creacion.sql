
/****** Object:  Table [dbo].[TiposLiquidaciones]    Script Date: 12/5/2017 14:27:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposLiquidaciones](
	[IdTipoLiquidacion] [int] NOT NULL,
	[NombreTipoLiquidacion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TiposLiquidaciones] PRIMARY KEY CLUSTERED 
(
	[IdTipoLiquidacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* -------------------- */

INSERT INTO [dbo].[TiposLiquidaciones]
           ([IdTipoLiquidacion]
           ,[NombreTipoLiquidacion])
     VALUES
           (1, 'UNICA')
GO
