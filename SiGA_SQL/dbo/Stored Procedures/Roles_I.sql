CREATE PROCEDURE [dbo].[Roles_I]
@id NVARCHAR (4000), @nombre NVARCHAR (4000), @descripcion NVARCHAR (4000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Roles_I]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Roles_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spRoles.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Roles_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 12, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Roles_I';

