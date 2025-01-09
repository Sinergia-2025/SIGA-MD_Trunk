CREATE PROCEDURE [dbo].[Usuarios_UClave]
@id NVARCHAR (4000), @claveActual NVARCHAR (4000), @claveNueva NVARCHAR (4000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Usuarios_UClave]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_UClave';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spUsuarios.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_UClave';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 102, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Usuarios_UClave';

