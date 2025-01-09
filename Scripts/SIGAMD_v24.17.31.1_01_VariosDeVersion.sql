/****** Object:  Table dbo.Borrar_CalidadListasControlTipos    Script Date: 24/4/2024 08:41:06 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
IF dbo.ExisteTabla('CalidadListasControlTipos') = 0
BEGIN
    CREATE TABLE CalidadListasControlTipos(
	    IdListaControlTipo int NOT NULL,
	    NombreListaControlTipo varchar(100) NOT NULL,
     CONSTRAINT PK_CalidadListasControlTipos PRIMARY KEY CLUSTERED (IdListaControlTipo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlTipos)
BEGIN
    INSERT INTO CalidadListasControlTipos (IdListaControlTipo, NombreListaControlTipo)
                                   VALUES (1, 'General')
END
GO

IF dbo.ExisteTabla('CalidadListasControl') = 0
BEGIN
    CREATE TABLE CalidadListasControl(
	    IdListaControl int NOT NULL,
	    NombreListaControl varchar(100) NOT NULL,
	    Orden int NOT NULL,
	    IdListaControlTipo int NOT NULL,
     CONSTRAINT PK_CalidadListasControl PRIMARY KEY CLUSTERED (IdListaControl ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CalidadListasControl_CalidadListasControlTipos') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControl  WITH CHECK ADD  CONSTRAINT FK_CalidadListasControl_CalidadListasControlTipos FOREIGN KEY(IdListaControlTipo)
    REFERENCES dbo.CalidadListasControlTipos (IdListaControlTipo)
    ALTER TABLE dbo.CalidadListasControl CHECK CONSTRAINT FK_CalidadListasControl_CalidadListasControlTipos
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControl)
BEGIN
    INSERT INTO CalidadListasControl (IdListaControl, NombreListaControl, Orden, IdListaControlTipo)
     VALUES
           (1, 'Lista 1', 1, 1),
           (2, 'Lista 2', 2, 1)
END
GO

IF dbo.ExisteTabla('CalidadListasControlItemsGrupos') = 0
BEGIN
    CREATE TABLE CalidadListasControlItemsGrupos(
	    IdListaControlItemGrupo varchar(20) NOT NULL,
	    NombreListaControlItemGrupo varchar(100) NOT NULL,
     CONSTRAINT PK_Borrar_CalidadListasControlItemsGrupos PRIMARY KEY CLUSTERED (IdListaControlItemGrupo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlItemsGrupos)
BEGIN
    INSERT INTO CalidadListasControlItemsGrupos
               (IdListaControlItemGrupo, NombreListaControlItemGrupo)
        VALUES ('GRP-1', 'Grupo 1'),
               ('GRP-2', 'Grupo 2'),
               ('GRP-3', 'Grupo 3')
END
GO

IF dbo.ExisteTabla('CalidadListasControlItemsSubGrupos') = 0
BEGIN
    CREATE TABLE CalidadListasControlItemsSubGrupos(
	    IdListaControlItemGrupo varchar(20) NOT NULL,
	    IdListaControlItemSubGrupo varchar(20) NOT NULL,
	    NombreListaControlItemSubGrupo varchar(100) NOT NULL,
     CONSTRAINT PK_CalidadListasControlItemsSubGrupos PRIMARY KEY CLUSTERED (IdListaControlItemGrupo ASC, IdListaControlItemSubGrupo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CalidadListasControlItemsSubGrupos_CalidadListasControlItemsGrupos') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControlItemsSubGrupos  WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlItemsSubGrupos_CalidadListasControlItemsGrupos FOREIGN KEY(IdListaControlItemGrupo)
                REFERENCES dbo.CalidadListasControlItemsGrupos (IdListaControlItemGrupo)
    ALTER TABLE dbo.CalidadListasControlItemsSubGrupos CHECK CONSTRAINT FK_CalidadListasControlItemsSubGrupos_CalidadListasControlItemsGrupos
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlItemsSubGrupos)
BEGIN
    INSERT INTO CalidadListasControlItemsSubGrupos
               (IdListaControlItemGrupo, IdListaControlItemSubGrupo, NombreListaControlItemSubGrupo)
        VALUES ('GRP-2', 'SGRP-2-1', 'Sub Grupo 2 / 1')
END
GO

MERGE INTO UnidadesDeMedidas AS DEST
        USING (SELECT 'CC' IdUnidadDeMedida, 'Cent. Cubico' NombreUnidadDeMedida, 0.001 ConversionAKilos, 27 IdAFIP UNION ALL
               SELECT 'GR' IdUnidadDeMedida, 'Gramo'        NombreUnidadDeMedida, 0.001 ConversionAKilos, 14 IdAFIP UNION ALL
               SELECT 'KG' IdUnidadDeMedida, 'Kilogramo'    NombreUnidadDeMedida, 1.000 ConversionAKilos,  1 IdAFIP UNION ALL
               SELECT 'LT' IdUnidadDeMedida, 'Litro'        NombreUnidadDeMedida, 1.000 ConversionAKilos,  5 IdAFIP UNION ALL
               SELECT 'UN' IdUnidadDeMedida, 'Unidad'       NombreUnidadDeMedida, 0.000 ConversionAKilos,  7 IdAFIP UNION ALL
               SELECT 'TN' IdUnidadDeMedida, 'Toneladas'    NombreUnidadDeMedida,  1000 ConversionAKilos, 29 IdAFIP)
              AS ORIG ON DEST.IdUnidadDeMedida = ORIG.IdUnidadDeMedida
    WHEN NOT MATCHED THEN 
        INSERT (IdUnidadDeMedida, NombreUnidadDeMedida, ConversionAKilos, IdAFIP) VALUES (ORIG.IdUnidadDeMedida, ORIG.NombreUnidadDeMedida, ORIG.ConversionAKilos, ORIG.IdAFIP)
;

MERGE INTO UnidadesDeMedidasConversiones AS DEST
        USING (SELECT 'KG' IdUnidadMedidaDesde, 'GR' IdUnidadMedidaHacia, 1000 FactorConversion, 'True' Fija UNION ALL
               SELECT 'TN' IdUnidadMedidaDesde, 'KG' IdUnidadMedidaHacia, 1000 FactorConversion, 'True' Fija UNION ALL
               SELECT 'LT' IdUnidadMedidaDesde, 'CC' IdUnidadMedidaHacia, 1000 FactorConversion, 'True' Fija)
              AS ORIG ON DEST.IdUnidadMedidaDesde = ORIG.IdUnidadMedidaDesde AND DEST.IdUnidadMedidaHacia = ORIG.IdUnidadMedidaHacia
    WHEN MATCHED THEN
        UPDATE SET DEST.FactorConversion = ORIG.FactorConversion
                 , DEST.Fija = ORIG.Fija
    WHEN NOT MATCHED THEN 
        INSERT (IdUnidadMedidaDesde, IdUnidadMedidaHacia, FactorConversion, Fija) VALUES (ORIG.IdUnidadMedidaDesde, ORIG.IdUnidadMedidaHacia, ORIG.FactorConversion, ORIG.Fija)
;

