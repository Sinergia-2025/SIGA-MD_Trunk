
/****** Object:  Table [dbo].[EscalasRetGanancias]    Script Date: 29/12/2015 17:38:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EscalasRetGanancias](
	[IdEscala] [int] NOT NULL,
	[MontoMasDe] [decimal](14, 2) NULL,
	[MontoA] [decimal](14, 2) NULL,
	[Importe] [decimal](14, 2) NULL,
	[MasPorcentaje] [decimal](14, 2) NULL,
	[SobreExcedente] [decimal](14, 2) NULL
 CONSTRAINT [PK_EscalasRetGanancias] PRIMARY KEY CLUSTERED 
(
	[IdEscala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (1	,0.00	,2000.00	,0.00	,10.00	,0.00)
GO
INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (2	,2000.00	,4000.00	,200.00	,14.00	,2000.00)
GO

INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (3	,4000.00	,8000.00	,480.00	,18.00	,4000.00)
GO

INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (4	,8000.00	,14000.00	,1200.00	,22.00	,8000.00)
GO

INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (5	,14000.00	,24000.00	,2520.00	,26.00	,14000.00)
GO

INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (6	,24000.00	,40000.00	,5120.00	,28.00	,24000.00)
GO

INSERT INTO [dbo].[EscalasRetGanancias]
           ([IdEscala]
           ,[MontoMasDe]
           ,[MontoA]
           ,[Importe]
           ,[MasPorcentaje]
           ,[SobreExcedente])
     VALUES
           (7	,40000.00	,1000000.00	,9600.00	,30.00	,40000.00)
GO
