DECLARE @idParametro VARCHAR(MAX) = 'IDEDICIONAPLICACION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Edición Aplicación Sinergia'
DECLARE @valorParametro VARCHAR(MAX) = 'PLUS'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


ALTER TABLE dbo.TiposUsuarios ADD EsDeProceso bit NULL
GO
UPDATE TiposUsuarios SET EsDeProceso = CASE WHEN NombreTipoUsuario LIKE 'Proceso%' THEN 'True' ELSE 'False' END

ALTER TABLE dbo.TiposUsuarios ALTER COLUMN EsDeProceso bit NOT NULL
GO

