
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProduccionProcesos](
	[IdProduccionProceso] [int] NOT NULL,
	[NombreProduccionProceso] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ProduccionProcesos] PRIMARY KEY CLUSTERED ([IdProduccionProceso] ASC)
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProduccionFormas](
	[IdProduccionForma] [int] NOT NULL,
	[NombreProduccionForma] [varchar](30) NOT NULL,
	[FormulaCalculoKilaje] [varchar](300) NOT NULL,
 CONSTRAINT [PK_ProduccionFormas] PRIMARY KEY CLUSTERED ([IdProduccionForma] ASC)
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]

SET ANSI_PADDING OFF
GO

INSERT [dbo].[ProduccionFormas] ([IdProduccionForma], [NombreProduccionForma], [FormulaCalculoKilaje]) 
    VALUES (6, 'CUADRADA', '[LARGOEXTALTO] * [ANCHOINTBASE] * [ESPMM] * 0.000008');

INSERT [dbo].[ProduccionFormas] ([IdProduccionForma], [NombreProduccionForma], [FormulaCalculoKilaje]) 
    VALUES (2, 'TRIANGULO', '[LARGOEXTALTO] * [ANCHOINTBASE] * [ESPMM] * 0.000008 / 2');

INSERT [dbo].[ProduccionFormas] ([IdProduccionForma], [NombreProduccionForma], [FormulaCalculoKilaje]) 
    VALUES (3, 'DISCO', '([LARGOEXTALTO] / 2) * ([LARGOEXTALTO] / 2) * [ESPMM] * 8 * [PI] / 1000000');

INSERT [dbo].[ProduccionFormas] ([IdProduccionForma], [NombreProduccionForma], [FormulaCalculoKilaje]) 
    VALUES (4, 'BRIDA', '([LARGOEXTALTO] / 2) * ([LARGOEXTALTO] / 2) * [ESPMM] * 8 * [PI] / 1000000');

INSERT [dbo].[ProduccionFormas] ([IdProduccionForma], [NombreProduccionForma], [FormulaCalculoKilaje]) 
    VALUES (5, 'SEGUN PLANO', '[LARGOEXTALTO] * [ANCHOINTBASE] * [ESPMM] * 0.000008');

