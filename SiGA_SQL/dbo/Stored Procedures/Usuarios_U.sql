CREATE PROCEDURE [dbo].[Usuarios_U]
@id NVARCHAR (4000), @nombre NVARCHAR (4000), @clave NVARCHAR (4000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Usuarios_U]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_U';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spUsuarios.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_U';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 32, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_U';

