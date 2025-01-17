SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transportistas](
 [IdTransportista] [int] NOT NULL,
 [NombreTransportista] [varchar](100) NOT NULL,
 [DireccionTransportista] [varchar](100) NOT NULL,
 [IdLocalidadTransportista] [int] NOT NULL,
 [TelefonoTransportista] [varchar](100) NOT NULL,
 [IdCategoriaFiscalTransportista] [smallint] NOT NULL,
 [CuitTransportista] [varchar](13) NULL,
 [Observacion] [varchar](200) NULL,
 CONSTRAINT [PK_Transportistas] PRIMARY KEY CLUSTERED 
(
 [IdTransportista] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Transportistas]  WITH CHECK ADD  CONSTRAINT [FK_Transportistas_CategoriasFiscales] FOREIGN KEY([IdCategoriaFiscalTransportista])
REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal])
GO
ALTER TABLE [dbo].[Transportistas] CHECK CONSTRAINT [FK_Transportistas_CategoriasFiscales]
GO
ALTER TABLE [dbo].[Transportistas]  WITH CHECK ADD  CONSTRAINT [FK_Transportistas_Localidades] FOREIGN KEY([IdLocalidadTransportista])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Transportistas] CHECK CONSTRAINT [FK_Transportistas_Localidades]
GO
