/****** Object:  Table dboOficina.AjustesStock    Script Date: 24/11/2022 08:45:32 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTablaSchema('AjustesStock', 'dboOficina') = 0
BEGIN
    CREATE TABLE dboOficina.AjustesStock(
	    IdEjecucionAjusteStock uniqueidentifier NOT NULL,
	    IdSucursal int NOT NULL,
	    IdProducto varchar(15) NOT NULL,
	    Stock decimal(16, 4) NOT NULL,
	    IdUsuario varchar(10) NOT NULL,
	    FechaAlta datetime NOT NULL,
	    Estado varchar(15) NOT NULL,
	    MensajeError varchar(max) NOT NULL,
     CONSTRAINT PK_AjusteStock PRIMARY KEY CLUSTERED (IdEjecucionAjusteStock ASC,IdSucursal ASC,IdProducto ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
