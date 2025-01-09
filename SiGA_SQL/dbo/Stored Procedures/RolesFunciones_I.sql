CREATE PROCEDURE [dbo].[RolesFunciones_I]
@idRol NVARCHAR (4000), @idFuncion NVARCHAR (4000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[RolesFunciones_I]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'RolesFunciones_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spRolesFunciones.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'RolesFunciones_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 11, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'RolesFunciones_I';

