
/****** Object:  Table [dbo].[ProspectosActividades]    Script Date: 10/13/2016 14:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProspectosActividades](
	[IdProvincia] [char](2) NOT NULL,
	[IdActividad] [int] NOT NULL,
	[IdProspecto] [bigint] NOT NULL,
 CONSTRAINT [PK_ProspectosActividades] PRIMARY KEY CLUSTERED 
(
	[IdProspecto] ASC,
	[IdProvincia] ASC,
	[IdActividad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProspectosActividades]  WITH CHECK ADD  CONSTRAINT [FK_ProspectosActividades_Prospectos] FOREIGN KEY([IdProspecto])
REFERENCES [dbo].[Prospectos] ([IdProspecto])
GO

ALTER TABLE [dbo].[ProspectosActividades] CHECK CONSTRAINT [FK_ProspectosActividades_Prospectos]
GO
