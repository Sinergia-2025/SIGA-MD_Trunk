CREATE PROCEDURE [dbo].[Funciones_GA]
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Funciones_GA]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Funciones_GA';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spFunciones.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Funciones_GA';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 117, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Funciones_GA';

