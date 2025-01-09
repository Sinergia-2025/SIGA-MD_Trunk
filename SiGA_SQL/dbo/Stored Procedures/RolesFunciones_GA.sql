CREATE PROCEDURE [dbo].[RolesFunciones_GA]
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[RolesFunciones_GA]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'RolesFunciones_GA';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spRolesFunciones.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'RolesFunciones_GA';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 43, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'RolesFunciones_GA';

