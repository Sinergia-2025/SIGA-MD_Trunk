--USE [PadronesARBA]
--GO

/****** Object:  StoredProcedure [dbo].[ProcesarInfoAGIP]    Script Date: 11/22/2016 16:32:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcesarInfoAGIP]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ProcesarInfoAGIP]
GO

--USE [PadronesARBA]
--GO

/****** Object:  StoredProcedure [dbo].[ProcesarInfoAGIP]    Script Date: 11/22/2016 16:32:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ProcesarInfoAGIP]
@PeriodoInformado int
AS

-- Declaración del cursor
INSERT INTO dbo.PadronAGIP ([PeriodoInformado], [IdPadronAGIP],
    [FechaPublicacion],[FechaVigenciaDesde],[FechaVigenciaHasta],
	[CUIT],[TipoContribuyente],[MarcaAlta],[MarcaAlicuota],
	[AlicuotaPercepcion],[AlicuotaRetencion],[GrupoPercepcion],[GrupoRetencion],
	[RazonSocial]) 
SELECT @PeriodoInformado
	,row_number() OVER(ORDER BY FechaPublicacion DESC) AS Row
    
    ,convert(datetime, substring([FechaPublicacion], 5, 4) + substring([FechaPublicacion], 3,2) + substring([FechaPublicacion], 1,2) + ' 00:00:00', 120)
    ,convert(datetime, substring([FechaVigenciaDesde], 5,4) + substring([FechaVigenciaDesde], 3,2) + substring([FechaVigenciaDesde], 1,2) + ' 00:00:00', 120)
    ,convert(datetime, substring([FechaVigenciaHasta], 5,4) + substring([FechaVigenciaHasta], 3,2) + substring([FechaVigenciaHasta], 1,2) + ' 00:00:00', 120)
    
    ,CAST([CUIT] AS bigint) as [CUIT]
    ,[TipoContribuyente]
    ,[MarcaAlta]
    ,[MarcaAlicuota]
    
    ,cast(replace([AlicuotaPercepcion], ',', '.') as decimal(5,2)) as [AlicuotaPercepcion]
    ,cast(replace([AlicuotaRetencion], ',', '.') as decimal(5,2)) as [AlicuotaRetencion]
    ,CAST([GrupoPercepcion] AS int) as [GrupoPercepcion]
    ,CAST([GrupoRetencion] AS int) as [GrupoRetencion]
    
    ,[RazonSocial]
FROM dbo.PadronAGIP_temp
;

GO


