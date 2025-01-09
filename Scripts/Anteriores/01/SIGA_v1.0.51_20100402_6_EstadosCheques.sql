
/****** Object:  Table [dbo].[EstadosCheques]    Script Date: 04/02/2010 23:38:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstadosCheques](
	[IdEstadoCheque] [varchar](10) NOT NULL,
 CONSTRAINT [PK_EstadosCheques] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/*--------------------*/

INSERT INTO EstadosCheques
 (IdEstadoCheque) VALUES ('ALTA')
GO
INSERT INTO EstadosCheques
 (IdEstadoCheque) VALUES ('ENCARTERA')
GO
INSERT INTO EstadosCheques
 (IdEstadoCheque) VALUES ('DEPOSITADO')
GO
INSERT INTO EstadosCheques
 (IdEstadoCheque) VALUES ('PROVEEDOR')
GO
INSERT INTO EstadosCheques
 (IdEstadoCheque) VALUES ('RECHAZADO')
GO
INSERT INTO EstadosCheques
 (IdEstadoCheque) VALUES ('EGRESOCAJA')
GO



