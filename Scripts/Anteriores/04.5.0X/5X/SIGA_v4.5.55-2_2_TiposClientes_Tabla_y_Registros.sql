
/****** Object:  Table [dbo].[TiposClientes]    Script Date: 07/13/2016 17:24:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposClientes](
	[IdTipoCliente] [int] NOT NULL,
	[NombreTipoCliente] [varchar](30) NULL,
 CONSTRAINT [PK_TiposCliente] PRIMARY KEY CLUSTERED 
(
	[IdTipoCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* -------------- */

INSERT INTO TiposClientes
    (IdTipoCliente, NombreTipoCliente)
  VALUES
    (1, 'General')
GO
