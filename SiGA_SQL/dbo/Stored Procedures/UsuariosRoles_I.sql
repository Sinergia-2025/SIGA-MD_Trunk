CREATE PROCEDURE [dbo].[UsuariosRoles_I]
@idUsuario NVARCHAR (4000), @idRol NVARCHAR (4000), @idSucursal INT
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[UsuariosRoles_I]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'UsuariosRoles_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spUsuariosRoles.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'UsuariosRoles_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 11, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'UsuariosRoles_I';

