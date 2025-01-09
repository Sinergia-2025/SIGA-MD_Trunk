
/****** Object:  Table [dbo].[EstadosVisitas]    Script Date: 08/03/2016 16:04:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstadosVisitas](
	[IdEstadoVisita] [int] NOT NULL,
	[NombreEstadoVisita] [varchar](30) NOT NULL,
	[AdmitePedidoSinLineas] [bit] NOT NULL,
	[AdmintePedidoConLineas] [bit] NOT NULL,
 CONSTRAINT [PK_EstadosVisitas] PRIMARY KEY CLUSTERED 
(
	[IdEstadoVisita] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO [EstadosVisitas]
           ([IdEstadoVisita], [NombreEstadoVisita], [AdmitePedidoSinLineas], [AdmintePedidoConLineas])
    VALUES (1, 'Normal', 'False', 'True')
GO

-- SEGUN MOVIL
--AVisitar = 0;
--VisitaNormal = 1;
--CerradoEventual = 2;
--Completo = 3;
--NoPaso = 4;
--NoQuisoComprar = 5;
--RetirarMercaderia = 6;
--OtroProblema = 7;
--CerradoDefinitivamente = 8;
--PasarOtroDia = 9;
--NoRepusoGalletitas = 10;
--NoReciboMercaderia = 11;
--ClienteConProblema = 12;
--Nada = 13;
