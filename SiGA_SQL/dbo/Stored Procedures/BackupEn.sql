CREATE PROCEDURE [dbo].[BackupEn]
@base NVARCHAR (4000), @path NVARCHAR (4000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[BackupEn]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'BackupEn';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spGenerales.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'BackupEn';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 7, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'BackupEn';

