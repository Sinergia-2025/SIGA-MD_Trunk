
CREATE TABLE [dbo].[ClientesDirecciones](
	[IdCliente] [bigint] NOT NULL,
	[IdDireccion] [int] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_ClientesDirecciones] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


