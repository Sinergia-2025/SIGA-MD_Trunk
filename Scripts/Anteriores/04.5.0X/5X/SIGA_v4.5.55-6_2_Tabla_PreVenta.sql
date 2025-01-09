
/****** Object:  Table [dbo].[PreVenta]    Script Date: 10/10/2017 15:37:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PreVenta](
	[Id] [int] NOT NULL,
	[FileNamePed] [varchar](80) NULL,
	[TipoDocEmpleado] [varchar](5) NULL,
	[NroDocEmpleado] [varchar](12) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_PreVenta] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
