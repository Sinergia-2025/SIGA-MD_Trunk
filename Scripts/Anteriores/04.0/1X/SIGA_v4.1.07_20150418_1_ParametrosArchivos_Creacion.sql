

CREATE TABLE [dbo].[ParametrosArchivos](
	[IdParametroArchivo] [varchar](50) NOT NULL,
	[ValorParametroArchivo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ParametrosArchivos] PRIMARY KEY CLUSTERED 
(
	[IdParametroArchivo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


