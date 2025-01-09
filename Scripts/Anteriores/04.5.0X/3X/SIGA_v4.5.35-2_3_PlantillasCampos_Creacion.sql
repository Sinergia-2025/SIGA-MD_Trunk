
/****** Object:  Table [dbo].[PlantillasCampos]    Script Date: 17/11/2016 12:28:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlantillasCampos](
	[IdPlantilla] [int] NOT NULL,
	[IdCampo] [int] NOT NULL,
	[OrdenColumna] [int] NULL,
 CONSTRAINT [PK_PlantillasCampos] PRIMARY KEY CLUSTERED 
(
	[IdPlantilla] ASC,
	[IdCampo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlantillasCampos]  WITH CHECK ADD  CONSTRAINT [FK_PlantillasCampos_Campos] FOREIGN KEY([IdCampo])
REFERENCES [dbo].[Campos] ([IdCampo])
GO

ALTER TABLE [dbo].[PlantillasCampos] CHECK CONSTRAINT [FK_PlantillasCampos_Campos]
GO

ALTER TABLE [dbo].[PlantillasCampos]  WITH CHECK ADD  CONSTRAINT [FK_PlantillasCampos_Plantillas] FOREIGN KEY([IdPlantilla])
REFERENCES [dbo].[Plantillas] ([IdPlantilla])
GO

ALTER TABLE [dbo].[PlantillasCampos] CHECK CONSTRAINT [FK_PlantillasCampos_Plantillas]
GO


