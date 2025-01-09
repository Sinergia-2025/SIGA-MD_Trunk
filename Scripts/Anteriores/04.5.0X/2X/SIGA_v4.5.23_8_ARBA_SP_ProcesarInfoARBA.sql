-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'ProcesarInfoARBA' 
)
   DROP PROCEDURE dbo.ProcesarInfoARBA
GO

CREATE PROCEDURE dbo.ProcesarInfoARBA
@PeriodoInformado int
AS

-- Declaración del cursor
INSERT INTO dbo.PadronARBA ([PeriodoInformado], [IdPadronARBA], [TipoRegimen], [FechaPublicacion] ,
	[FechaVigenciaDesde],[FechaVigenciaHasta],
	[CUIT],[TipoContribuyente],[AccionARBA],[CambioAlicuota],
	[Alicuota],[Grupo]) 
SELECT @PeriodoInformado
	,row_number() OVER(ORDER BY TipoRegimen DESC) AS Row
	,[TipoRegimen]
      ,convert(datetime, substring([FechaPublicacion], 5, 4) + substring([FechaPublicacion], 3,2) + substring([FechaPublicacion], 1,2) + ' 00:00:00', 120)
      ,convert(datetime, substring([FechaVigenciaDesde], 5,4) + substring([FechaVigenciaDesde], 3,2) + substring([FechaVigenciaDesde], 1,2) + ' 00:00:00', 120)
      ,convert(datetime, substring([FechaVigenciaHasta], 5,4) + substring([FechaVigenciaHasta], 3,2) + substring([FechaVigenciaHasta], 1,2) + ' 00:00:00', 120)
      ,CAST([CUIT] AS bigint) as [CUIT]
      ,[TipoContribuyente]
      ,[AccionARBA]
      ,(CASE WHEN [CambioAlicuota] = 'N' THEN 0 ELSE 1 END) AS [CambioAlicuota]
	  ,cast(replace([Alicuota], ',', '.') as decimal(5,2)) as [Alicuota]
      ,CAST([Grupo] AS int) as [Grupo]
FROM dbo.PadronARBA_temp
;

GO

