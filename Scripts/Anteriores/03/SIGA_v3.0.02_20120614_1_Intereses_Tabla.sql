

/****** Object:  Table [dbo].[Intereses]    Script Date: 06/14/2012 08:52:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Intereses](
	[DiasDesde] [int] NOT NULL,
	[DiasHasta] [int] NOT NULL,
	[Interes] [decimal](5, 2) NULL,
 CONSTRAINT [PK_Intereses_1] PRIMARY KEY CLUSTERED 
(
	[DiasDesde] ASC,
	[DiasHasta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-----------------------------------------------------

INSERT INTO Intereses
   (DiasDesde, DiasHasta, Interes)
 VALUES
 (1, 30, 0),
 (31, 60, 2)
GO
