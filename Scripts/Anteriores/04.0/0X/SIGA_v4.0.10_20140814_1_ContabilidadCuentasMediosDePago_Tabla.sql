
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContabilidadCuentasMediosDePago]') AND type in (N'U'))
	DROP TABLE [dbo].[ContabilidadCuentasMediosDePago]
GO

CREATE TABLE [dbo].[ContabilidadCuentasMediosDePago](
	[IdCuentaMedioDePago] [int] NOT NULL,
	[IdCuentaPesos] [int] NULL,
	[IdCuentaDolares] [int] NULL,
	[IdCuentaCheques] [int] NULL,
	[IdCuentaTickets] [int] NULL,
	[IdCuentaTarjetas] [int] NULL,
 CONSTRAINT [PK_ContabilidadCuentasMediosDePago] PRIMARY KEY CLUSTERED 
(
	[IdCuentaMedioDePago] ASC
)) ON [PRIMARY]
GO


INSERT INTO ContabilidadCuentasMediosDePago 
     VALUES (1,0,0,0,0,0)
GO
