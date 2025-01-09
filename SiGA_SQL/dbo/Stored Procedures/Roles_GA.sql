CREATE PROCEDURE [dbo].[Roles_GA]
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Roles_GA]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Roles_GA';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spRoles.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Roles_GA';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 60, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Roles_GA';

