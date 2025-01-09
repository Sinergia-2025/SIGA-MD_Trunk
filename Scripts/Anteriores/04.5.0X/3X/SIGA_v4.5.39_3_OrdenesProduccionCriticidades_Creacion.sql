
/****** Object:  Table [dbo].[OrdenesProduccionCriticidades]    Script Date: 18/4/2017 16:24:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdenesProduccionCriticidades](
	[IdCriticidad] [varchar](10) NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_OrdenesProduccionCriticidades] PRIMARY KEY CLUSTERED 
(
	[IdCriticidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* ---------- */

INSERT INTO OrdenesProduccionCriticidades
           (IdCriticidad, Orden)
     VALUES
           ('Normal', 1),
           ('Alta', 2),
           ('Muy Alta', 3),
           ('Baja', 4)
GO


