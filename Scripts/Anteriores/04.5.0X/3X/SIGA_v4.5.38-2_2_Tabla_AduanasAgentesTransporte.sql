
/****** Object:  Table [dbo].[AduanasAgentesTransporte]    Script Date: 04/18/2017 17:59:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AduanasAgentesTransporte](
	[IdAgenteTransporte] [int] NOT NULL,
	[NombreAgenteTransporte] [varchar](100) NOT NULL,
	[Cuit] [varchar](13) NOT NULL,
 CONSTRAINT [PK_AduanasAgentesTransporte] PRIMARY KEY CLUSTERED 
(
	[IdAgenteTransporte] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


