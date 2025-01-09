
CREATE TABLE [dbo].[Traducciones](
	[IdIdioma] [varchar](10) NOT NULL,
	[Pantalla] [varchar](90) NOT NULL,
	[Control] [varchar](90) NOT NULL,
	[Texto] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Traducciones] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC,
	[Pantalla] ASC,
	[Control] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

