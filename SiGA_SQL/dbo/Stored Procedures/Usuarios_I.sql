CREATE PROCEDURE [dbo].[Usuarios_I]
@id NVARCHAR (4000), @nombre NVARCHAR (4000), @clave NVARCHAR (4000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Usuarios_I]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spUsuarios.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_I';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 12, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_I';

