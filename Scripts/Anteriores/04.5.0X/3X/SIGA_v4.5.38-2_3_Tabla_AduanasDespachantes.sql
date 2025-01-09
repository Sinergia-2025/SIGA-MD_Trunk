
/****** Object:  Table [dbo].[AduanasDespachantes]    Script Date: 04/18/2017 17:59:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AduanasDespachantes](
	[IdDespachante] [int] NOT NULL,
	[NombreDespachante] [varchar](100) NOT NULL,
	[Cuit] [varchar](13) NOT NULL,
 CONSTRAINT [PK_AduanasDespachantes] PRIMARY KEY CLUSTERED 
(
	[IdDespachante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
