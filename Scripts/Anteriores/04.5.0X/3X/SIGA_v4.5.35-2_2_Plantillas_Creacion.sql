
/****** Object:  Table [dbo].[Plantillas]    Script Date: 17/11/2016 12:28:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Plantillas](
	[IdPlantilla] [int] NOT NULL,
	[NombrePlantilla] [varchar](200) NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[FilaInicial] [int] NOT NULL,
 CONSTRAINT [PK_Plantillas] PRIMARY KEY CLUSTERED 
(
	[IdPlantilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Plantillas]  WITH CHECK ADD  CONSTRAINT [FK_Plantillas_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO

ALTER TABLE [dbo].[Plantillas] CHECK CONSTRAINT [FK_Plantillas_Proveedores]
GO


